using System;
using System.Windows.Forms;
namespace uav_tracng
{
    public partial class ResultForm : Form
    {
        Solver sol;
        int i, j, p = 0, t = 0;
        double sum;
        MainForm mainform;
        Project project;
        public ResultForm(Project project, Solver sol, MainForm mainform)
        {
            
            InitializeComponent();
            if (project.is_opened)
            {
                button1.Visible = false;
                button1.Enabled = false;
            }
            sum = 0;
            this.mainform = mainform;
            this.sol = sol;
            this.project = project;
            project.crossEstimate = sol.crossEstimate;
            textBox1.Text += sol.crossEstimate;
            dataGridView1.RowCount = project.countCon;
            for (i = 0; i < project.countCon; i++)
            {
                for (j = 0; j < sol.matrix_kol_versh_v_soed[i]; j++)
                {
                    dataGridView1.Rows[i].Cells[3].Value += (sol.matrix_y[i, j] + 1) + " - ";
                }
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
                dataGridView1.Rows[i].Cells[1].Value = sol.matrix_y[i, 0] + 1;
                dataGridView1.Rows[i].Cells[2].Value = sol.matrix_y[i, sol.matrix_kol_versh_v_soed[i]-1] + 1;
                dataGridView1.Rows[i].Cells[4].Value = sol.dist_put_all[i].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dataGridView1.Rows[i].Cells[3].Value.ToString().Remove(dataGridView1.Rows[i].Cells[3].Value.ToString().Length - 2, 2);
                sum += sol.dist_put_all[i];
            }  textBox2.Text += sum;  
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlDataBaseClient.SQLCommandCreateProject(project.projectID+", N\'"+ project.projectName + "\',"
                + project.countDevices,  project.crossEstimate, project.chanellsVolume.ToString());
            for (i = 0; i < project.countDevices; i++)
            {
                for (j = i+1; j < project.countDevices; j++)
                {
                    if (sol.matrix_conn[i, j] != 0)
                    {
                        SqlDataBaseClient.SQLCommandCreateCon(p + "," + project.projectID + "," + i + "," + j);
                        p++;
                    }
                    if (sol.matrix_chan[i, j] != 0)
                    {
                        SqlDataBaseClient.SQLCommandCreateChan(t + "," + project.projectID + "," + i + "," + j+", ",sol.matrix_chan[i, j]);
                        for (int iu = 0; iu < project.countCon; iu++)
                        {
                            
                            for (int ju = 0; ju < sol.matrix_kol_versh_v_soed[iu] - 1; ju++)
                            {
                                if ((sol.matrix_y[iu, ju] ==i && sol.matrix_y[iu, ju+1]==j)|| (sol.matrix_y[iu, ju+1] == i && sol.matrix_y[iu, ju ] == j))
                                {
                                    SqlDataBaseClient.SQLCommandCreateTrack(project.projectID + "," + iu + "," + t);
                                    
                                }
                            }
                        }
                        t++;
                    }
                }
            }
            for (i = 0; i < project.countCon; i++)
            {
                for (j = i; j < project.countCon; j++)
                {
                    if (sol.matrix_x[i, j] != 0) SqlDataBaseClient.SQLCommandCreateEMC(project.projectID + "," + i + "," + j);
                }
            }
            project.is_opened = true;
            project.is_set = false;
            mainform.Activate();
            Close();
           
        }
    }
}
