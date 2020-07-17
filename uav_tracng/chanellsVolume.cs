using System;
using System.Windows.Forms;

namespace uav_tracng
{
    public partial class ChanellsVolume : Form
    {
        Project project;
        public ChanellsVolume(Project project)
        {
            this.project = project;
            InitializeComponent();
            textBox1.Text = project.chanellsVolume.ToString();
        }
        private void set_chanellsVolume_Click(object sender, EventArgs e)
        {
            if (project.is_opened == false)
            {
                if (int.TryParse(textBox1.Text, out int result))
                {
                    if (project.chanellsVolume != result)
                    {
                        if (result >= 1 && result <= 20)
                        {
                            project.chanellsVolume = result;
                            Close();
                        }
                        else MessageBox.Show("Введите корректное значение вместимости каналов в диапазоне от 1 до 20.");
                    }  else MessageBox.Show("Это значения вместимости каналов уже установлено в проекте.");
                }  else MessageBox.Show("Введите корректное значение вместимости каналов.");
            }
            else Close();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != (char)Keys.Back && number != (char)Keys.Delete) e.Handled = true;
            if (e.KeyChar == (char)Keys.Enter) set_chanellsVolume_Click(new object(), new EventArgs());
        }
    }
}
