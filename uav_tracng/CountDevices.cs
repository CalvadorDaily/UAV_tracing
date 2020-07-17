using System;
using System.Windows.Forms;

namespace uav_tracng
{
    public partial class CountDevices : Form
    {
        Project project;
        MainForm mainForm;
        public CountDevices(Project project, MainForm mainForm)
        {
            InitializeComponent();
            this.project = project;
            this.mainForm = mainForm;
            textBox1.Text = project.countDevices.ToString();
        }
        private void set_countDevices_Click(object sender, EventArgs e)
        {
            if (project.is_opened == false)
            {
                if (int.TryParse(textBox1.Text, out int res))
                {
                    if (res != project.countDevices)
                    {
                        if (res >= 3 && res <= 20)
                        {
                            project.countDevices = res;
                            mainForm.Activate();
                            Close();
                            project.countCon = 0;
                        }
                        else MessageBox.Show("Введите количество устройств в диапазоне от 3 до 20.");
                    }  else MessageBox.Show("Это значения количества устройств уже установлено в проекте.");
                } else MessageBox.Show("Введите корректное значение.");
            } else Close();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != (char)Keys.Back && number != (char)Keys.Delete) e.Handled = true;
            if (e.KeyChar == (char)Keys.Enter) set_countDevices_Click(new object(), new EventArgs());
        }
    }
}
