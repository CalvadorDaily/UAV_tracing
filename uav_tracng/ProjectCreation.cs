using System;
using System.Data;
using System.Windows.Forms;

namespace uav_tracng
{
    public partial class ProjectCreation : Form
    {         
        Project project;
        DataSet dataSet;
        bool is_unique;
        MainForm mainform;
        Solver sol;
        public ProjectCreation(Project project, MainForm mainform, Solver sol)
        {
            this.sol = sol;
            this.mainform = mainform;
            this.project = project;
            InitializeComponent();
        }
        private void set_projectName_Click(object sender, EventArgs e)
        {
            is_unique = true;
            dataSet = SqlDataBaseClient.SQLCommandSelectAllFromColumn("Project", "ProjectName");
            if (textBox1.Text.Length != 0)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count && is_unique; i++)
                {
                    if (dataSet.Tables[0].Rows[i][0].ToString() == textBox1.Text)
                    {
                        MessageBox.Show("Такое название проекта уже существует, выберите другое.");
                        is_unique = false;
                    }
                }
                if (is_unique)
                {
                    sol = new Solver();
                    mainform.TARAT(sol);
                    project.projectID = SqlDataBaseClient.SQLCustomCommandSelectMAXFrom("Project", "ProjectID") + 1;
                    project.set_default();
                    project.projectName = textBox1.Text;
                    Close();
                    mainform.Activate();
                }
            } else MessageBox.Show("Введите название проекта.");
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (number==44 || number == 39|| number==59) e.Handled = true;
            if (e.KeyChar == (char)Keys.Enter) set_projectName_Click(new object(), new EventArgs());
        }
    }
}
