using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace uav_tracng
{
    public partial class MainForm : Form
    {
        int n, i, j, m,m_det,m_chan;
        double[,] matrix_chan;
        int[,] matrix_con;
        Project project;
        DataSet dataset_con;
        DataSet dataset_chan;
        DataSet dataset_x;
        DataSet dataset_y;
        Solver sol;
        public MainForm() 
        {
            sol = new Solver();
            project = new Project();
            n = 0;
            m = 0;
            m_det = 0;
            InitializeComponent();
        }
        public void TARAT(Solver sol)
        {
            this.sol = sol;
        }
        private void справкаToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (project.projectID != 0 && project.is_opened==false)
            {
                if (e.Button == MouseButtons.Right && e.ColumnIndex >= 0 && e.RowIndex >= 0 && e.ColumnIndex > e.RowIndex)
                {
                    if (project.countCon != 0)
                    {
                        if (m_det < m && matrix_con[e.RowIndex, e.ColumnIndex] == 0)
                        {
                            matrix_con[e.RowIndex, e.ColumnIndex] = 1;
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                            m_det++;
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.Green;
                        }
                        else if (matrix_con[e.RowIndex, e.ColumnIndex] == 1)
                        {
                            matrix_con[e.RowIndex, e.ColumnIndex] = 0;
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                            m_det--;
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = default;
                        }
                    }
                    else MessageBox.Show("Перед заполнением информации о кабельных соединениях введите их количество во кладке " + "Входные данные");
                }
            }
        }
        private void входныеДанныеToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (project.projectID != 0)
            {
                if (crossTalkItem.Selected)
                {
                    if (project.countDevices != 0 && project.countCon != 0 && m_det == m)
                    {
                        sol.matrix_conn = matrix_con;
                        CrosstalkForm crosstalkForm = new CrosstalkForm(project, sol);
                        crosstalkForm.ShowDialog();
                    }
                    else MessageBox.Show("Для заполнения информации о совместимости соединений введите информацию о количестве устройств, количестве соединений и " +
                        "определите эти соединения на главной форме.");
                }
                else if (countDevicesItem.Selected)
                {
                    CountDevices countDevicesView = new CountDevices(project, this);
                    countDevicesView.ShowDialog();
                }
                else if (chanellsVolumeItem.Selected)
                {
                    ChanellsVolume chanellsVolumeView = new ChanellsVolume(project);
                    chanellsVolumeView.ShowDialog();
                }
                else if (countCon.Selected)
                {
                    if (project.countDevices != 0)
                    {
                        CountCon countCon_View = new CountCon(project);
                        countCon_View.ShowDialog();
                    }
                    else MessageBox.Show("Введите данные о количестве устройств.");
                } 
            }
            else MessageBox.Show("Выберите проект либо создайте новый.");
        }
        private void решениеToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (project.projectID != 0)
            {
                if (getSolutionItem.Selected && project.chanellsVolume != 0 && project.countDevices != 0 && project.countCon != 0 && m_det == m && sol.matrix_x!=null)
                {
                    if (sol.matrix_x.GetLength(0) == project.countCon)
                    {
                        bool stan = false;
                        sol.m = project.countCon;
                        sol.n = project.countDevices;
                        sol.w = project.chanellsVolume;
                        if (project.is_opened == false)
                        {
                            for (i = 0; i < n; i++)
                            {
                                for (j = i + 1; j < n; j++)
                                {
                                    if (double.TryParse(dataGridView1.Rows[i].Cells[j].EditedFormattedValue.ToString(),out double res))
                                    {
                                        if (res != 0)
                                        {
                                            matrix_chan[i, j] = res;
                                        }
                                    }
                                    else stan = true;
                                }
                            }
                            sol.matrix_conn = matrix_con;
                            sol.matrix_chan = matrix_chan;
                            sol.get_solution();
                        }
                        if (stan) MessageBox.Show("Редактируемая ячейка содержит некорректное значение.");
                        else
                        {
                            try
                            {
                                ResultForm resultForm = new ResultForm(project, sol, this);
                                resultForm.ShowDialog();
                            }
                            catch { MessageBox.Show("Ошибка получения решения! Проверьте входные данные и запустите решение повторно.", "Внимание"); }
                        }
                    }
                    else MessageBox.Show("Заполните матрицу совместимости перед продолжением");
                }
                else MessageBox.Show("Введите все необходимые данные для получения решения.");
            }
            else MessageBox.Show("Выберите проект либо создайте новый.");
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            Start start = new Start(project, this, sol);
            start.ShowDialog();
        }
        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && e.ColumnIndex > e.RowIndex)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText =
                    "Для установки соединения между вершинами кликните один раз правой кнопкой мыши на активную ячейку.\n" +
                    "Уже установленное соединение имеет зелёный цвет ячейки.\n" +
                    "Для удаления соединения кликните на ячейку один раз правой кнопкой мыши.";
            }
        }
        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (project.projectID != 0)
            {
                if (project.is_opened && project.is_set==false)
                {
                    Text = "Просмотр открытого проекта: "+project.projectName;
                    project.is_set = true;
                    n = project.countDevices;
                    dataGridView1.ColumnCount = dataGridView1.RowCount = n;
                    matrix_chan = new double[n, n];
                    matrix_con = new int[n, n];
                    dataGridView1_setDefault_Chan();
                    dataGridView1_setDefault_Con();
                    dataset_con = SqlDataBaseClient.SQLCustomCommandSelectAllFrom("DeviceConnectionSettings", "projectid=" + project.projectID);
                    dataset_chan = SqlDataBaseClient.SQLCustomCommandSelectAllFrom("ChannelConnectionParameters", "projectid=" + project.projectID);
                    dataset_x = SqlDataBaseClient.SQLCustomCommandSelectAllFrom("EmcParameters", "projectid=" + project.projectID);
                    dataset_y = SqlDataBaseClient.SQLCustomCommandSelectAllFrom("trackoptions", "projectid=" + project.projectID);
                    m_chan = dataset_chan.Tables[0].Rows.Count;
                    project.countCon = m = dataset_con.Tables[0].Rows.Count;
                    sol.matrix_y = new int[m, n];
                    dataGridView1_setOpen();
                    sol.matrix_kol_versh_v_soed = new int[m];
                    sol.matrix_x = new int[m, m];
                    sol.dist_put_all = new double[m];
                    sol.crossEstimate = project.crossEstimate;
                    for (int gh = 0; gh < m; gh++)
                    {
                        sol.matrix_kol_versh_v_soed[gh] = SqlDataBaseClient.SQLCustomCommandSelectOneFromInt("trackoptions", "ConnectionID=" + gh+" and projectid="+project.projectID)+1;
                        for (i = 0; i < dataset_x.Tables[0].Rows.Count; i++)
                        {
                            sol.matrix_x[int.Parse(dataset_x.Tables[0].Rows[i][1].ToString()), int.Parse(dataset_x.Tables[0].Rows[i][2].ToString())] = 1;
                        }
                    }
                    int[] ter_soed = new int[m];
                    for (int dh = 0; dh < m;) //текущее соединение
                    {
                        for (int gh = 0; gh < dataset_y.Tables[0].Rows.Count; gh++)//текущая запись в трэк опшинс перебираем
                        {
                            if (dh == int.Parse(dataset_y.Tables[0].Rows[gh][1].ToString()))//если запись трек опшенс принадлежит этому соединению
                            {
                                for (int zh = 0; zh < dataset_chan.Tables[0].Rows.Count; zh++)  //текущая запись в перечне каналов перебираем
                                {
                                    if (dataset_y.Tables[0].Rows[gh][2].ToString() == dataset_chan.Tables[0].Rows[zh][0].ToString())//если в текущей записи трэка содержится текущий канал
                                    {
                                        if (int.Parse(dataset_chan.Tables[0].Rows[zh][2].ToString()) ==sol.matrix_y[dh, ter_soed[dh]])
                                        {
                                            ter_soed[dh]++;
                                            sol.matrix_y[dh,ter_soed[dh]] = int.Parse(dataset_chan.Tables[0].Rows[zh][3].ToString());
                                            sol.dist_put_all[dh] += double.Parse(dataset_chan.Tables[0].Rows[zh][4].ToString());
                                        }
                                        else if (int.Parse(dataset_chan.Tables[0].Rows[zh][3].ToString()) == sol.matrix_y[dh, ter_soed[dh]])
                                        {
                                            ter_soed[dh]++;
                                            sol.matrix_y[dh, ter_soed[dh]] = int.Parse(dataset_chan.Tables[0].Rows[zh][2].ToString());
                                            sol.dist_put_all[dh] += double.Parse(dataset_chan.Tables[0].Rows[zh][4].ToString());
                                        }
                                    }
                                }
                            }
                        }
                        if (ter_soed[dh] == sol.matrix_kol_versh_v_soed[dh]-1) dh++;
                    }
                }
                else
                {
                    if (m != project.countCon)
                    {
                        m_det = 0;
                        m = project.countCon;
                        dataGridView1_setDefault_Con();
                        matrix_con = new int[n, n];
                    }
                    else if (n != project.countDevices)
                    {
                        m_det = 0;
                        n = project.countDevices;
                        matrix_chan = new double[n, n];
                        matrix_con = new int[n, n];
                        dataGridView1.ColumnCount = dataGridView1.RowCount = n;
                        dataGridView1_setDefault_Chan();
                        dataGridView1_setDefault_Con();
                    }
                }
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != (char)Keys.Back && number != (char)Keys.Delete) e.Handled = true;
        }

        private void dataGridView1_setDefault_Con()
        {
            for (i = 0; i < n; i++)
            {
                for (j = i + 1; j < n; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Style.BackColor == Color.Green)
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White; dataGridView1.Rows[i].Cells[j].Style.SelectionBackColor = default;
                    }
                }    
            }
        }
        private void dataGridView1_setOpen()
        {
            int ytt = 0;
            m_det = 0;
            for (i = 0; i < n; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Value = (i + 1).ToString();
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                for (j = i + 1; j < n; j++)
                {
                    if (m_det < m)
                    {
                        if (int.Parse(dataset_con.Tables[0].Rows[m_det][2].ToString()) == i && int.Parse(dataset_con.Tables[0].Rows[m_det][3].ToString()) == j)
                        {
                            sol.matrix_y[m_det, 0] = i;
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Green;
                            matrix_con[i, j] = 1;
                            dataGridView1.Rows[i].Cells[j].Style.SelectionBackColor = Color.Green;
                            m_det++;
                        }
                    }
                   dataGridView1.Rows[i].Cells[j].Value = matrix_chan[i, j];
                    if (ytt<m_chan)
                    {
                        if (int.Parse(dataset_chan.Tables[0].Rows[ytt][2].ToString()) == i && int.Parse(dataset_chan.Tables[0].Rows[ytt][3].ToString()) == j)
                        {
                            dataGridView1.Rows[i].Cells[j].Value  = double.Parse(dataset_chan.Tables[0].Rows[ytt][4].ToString());
                            matrix_chan[i, j] = double.Parse(dataset_chan.Tables[0].Rows[ytt][4].ToString());
                            ytt++;
                        }
                    }
                    dataGridView1.Rows[j].Cells[i].ReadOnly = dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                    dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.Gray;
                }
                dataGridView1.Rows[i].Cells[i].ReadOnly = true;
                dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.Gray;
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void dataGridView1_setDefault_Chan()
        {
            for (i = 0; i < n; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Value = (i + 1).ToString();
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                for (j = i + 1; j < n; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Style.BackColor == Color.Green) 
                    { dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White; 
                        dataGridView1.Rows[i].Cells[j].Style.SelectionBackColor = default; }
                    dataGridView1.Rows[j].Cells[i].ReadOnly = true;
                    dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.Gray;
                    dataGridView1.Rows[i].Cells[j].Value = matrix_chan[i, j];
                    dataGridView1.Rows[i].Cells[j].ReadOnly = false;
                }
                dataGridView1.Rows[i].Cells[i].ReadOnly = true;
                dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.Gray;
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
            private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
            if (project.projectID != 0)
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && e.ColumnIndex > e.RowIndex)
                {
                    if (!double.TryParse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out double res))
                    {
                         dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    }
                    else
                    {
                        if (res < 0)
                        {
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                        }
                    }
                }
            }
        }
        private void проектToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (exitProjectItem.Selected) { Start start = new Start(project, this, sol); start.ShowDialog(); }
        }
    }
    }

