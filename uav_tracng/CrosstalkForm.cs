using System;
using System.Drawing;
using System.Windows.Forms;

namespace uav_tracng
{
    public partial class CrosstalkForm : Form
    {
        int i, j, m,n;
        int[,] mas_x;
        Project project;
        Solver sol;
        public CrosstalkForm(Project project, Solver sol)
        {
            InitializeComponent();
            this.sol = sol;
            this.project = project;
            m = project.countCon;
            n = project.countDevices;
            mas_x = new int[m, m];
            
            conn.ReadOnly = true;
            dataGridView1.ColumnCount = dataGridView1.RowCount = m;
            conn.ColumnCount = 2; conn.RowCount = m;
            conn.Columns[0].HeaderCell.Value = "№ Соединения";
            for (i = 0; i < m; i++)
            {
                conn.Rows[i].Cells[0].Value = i+1;
                dataGridView1.Columns[i].HeaderCell.Value = (i + 1).ToString();
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                for (j = i+1; j < m; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = mas_x[i, j];
                    if (sol.matrix_x.GetLength(0) == m) 
                    { 
                        dataGridView1.Rows[i].Cells[j].Value = sol.matrix_x[i, j];
                        mas_x[i, j] = sol.matrix_x[i, j];
                    }
                    dataGridView1.Rows[j].Cells[i].ReadOnly = true;
                    dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.Gray;
                }
                dataGridView1.Rows[i].Cells[i].ReadOnly = true;
                dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.Gray;
            }
            i = 0;
            for (int k = 0; k < n; k++)
            {
                for (int z = k + 1; z < n; z++)
                {
                    if (sol.matrix_conn[k, z] == 1)
                    {
                        conn.Rows[i].Cells[1].Value = (k + 1) + " - " + (z + 1);
                        i++;
                    }
                }
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
            if (project.is_opened)
            {
                dataGridView1.ReadOnly = true;
            }
            else dataGridView1.ReadOnly = false;
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && e.ColumnIndex>e.RowIndex)
            {
                if (int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString(), out int res))
                {
                    if (res != 0 && res != 1)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    }
                }
                else dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
            }
        }
        private void set_cross_matrix_click(object sender, EventArgs e)
        {
            if (project.is_opened == false)
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = i + 1; j < m; j++)
                    {
                        mas_x[i, j] = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }
                }
                sol.matrix_x = mas_x;
                MessageBox.Show("Данные успешно сохранены.");
            }
            Close();
        }
    }
}
