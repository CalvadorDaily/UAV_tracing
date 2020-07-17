using System;
using System.Data;
using System.Windows.Forms;

namespace uav_tracng
{
    public partial class Start : Form
    {
        int u;
        private DataSet dataSet;
        private string[] files;
        Project project;
        MainForm mainform;
        Solver sol;
        public Start(Project project, MainForm mainform, Solver sol)
        {
            this.sol = sol;
            u= -1;
            this.project = project;
            this.mainform = mainform;
            InitializeComponent();
            dataSet = SqlDataBaseClient.SQLCommandSelectAllFrom("Project");
            files = new string[dataSet.Tables[0].Rows.Count];
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                files[i] = dataSet.Tables[0].Rows[i][1].ToString();
            }
            foreach (string file in files)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = file;
                listView1.Items.Add(lvi);
            }
        }
        private void creation_Project_Click(object sender, EventArgs e)
        {
            ProjectCreation project_window = new ProjectCreation(project, mainform, sol);
            project_window.ShowDialog();
            Close(); 

        }
        private void open_Project_Click(object sender, EventArgs e)
        {
            if (u!=-1)
            {
                if (project.projectID != int.Parse(dataSet.Tables[0].Rows[u][0].ToString()))
                {
                    sol = new Solver();
                    mainform.TARAT(sol);
                    project.set_default();
                    project.projectID = int.Parse(dataSet.Tables[0].Rows[u][0].ToString());
                    project.projectName = dataSet.Tables[0].Rows[u][1].ToString();
                    project.is_opened = true;
                    project.countDevices = int.Parse(dataSet.Tables[0].Rows[u][2].ToString());
                    project.crossEstimate = double.Parse(dataSet.Tables[0].Rows[u][3].ToString());
                    project.chanellsVolume = int.Parse(dataSet.Tables[0].Rows[u][4].ToString());
                    MessageBox.Show("При открытии проекта редактирование данных невозможно.");
                    mainform.Activate();
                    Close();
                } else MessageBox.Show("Не удалось выполнить открытие, так как проект открыт в программе.");
            } else MessageBox.Show("Выберите проект.");
        }
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected) u = e.Item.Index;
            else u = -1;
        }
        private void deleteClick(object sender, EventArgs e)
        {
            if (u != -1)
            {
                if (project.projectID != int.Parse(dataSet.Tables[0].Rows[u][0].ToString()))
                {
                    SqlDataBaseClient.SQLCommandDeleteProject(dataSet.Tables[0].Rows[u][0].ToString());
                    dataSet = SqlDataBaseClient.SQLCommandSelectAllFrom("Project");
                    files = new string[dataSet.Tables[0].Rows.Count];
                    listView1.Items.Clear();
                    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    {
                        files[i] = dataSet.Tables[0].Rows[i][1].ToString();
                    }
                    foreach (string file in files)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = file;
                        listView1.Items.Add(lvi);
                    }
                    u = -1;
                } else MessageBox.Show("Не удалось выполнить удаление, так как проект открыт в программе. Закройте текущий проект и повторите удаление.");
            } else MessageBox.Show("Выберите проект.");
        }
    }
}
