using System;
using System.Windows.Forms;

namespace uav_tracng
{
    public partial class CountCon : Form
    {
        Project project;
        int g;
        public CountCon(Project project)
        {
            InitializeComponent();
            this.project = project;
            textBox1.Text = project.countCon.ToString();
            g = (project.countDevices * project.countDevices - project.countDevices) / 2;
            label1.Text = "Введите количество соединений в диапазоне от " + (project.countDevices - 1) + " до " + g;
        }
        private void set_countCon_Click(object sender, EventArgs e)
        {
            if (project.is_opened == false)
            {
                if (int.TryParse(textBox1.Text, out int result))
                {
                    if (project.countCon != result)
                    {
                        if (result >= project.countDevices - 1 && result <= g)
                        {
                            project.countCon = result;
                            Close();
                        } else MessageBox.Show("Введите корректное количество соединений в диапазоне от " + (project.countDevices - 1) + " до " + g);
                    } else MessageBox.Show("Такое значение количества соединений уже установлено в проекте.");
                }
                else MessageBox.Show("Введите корректное значение.");
            }
            else Close();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != (char)Keys.Back && number != (char)Keys.Delete) e.Handled = true;
            if (e.KeyChar == (char)Keys.Enter) set_countCon_Click(new object(), new EventArgs());
        }
    }
}
