using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainingPractice_02
{
    public partial class WinForm : Form
    {
        public WinForm(string spentTime)
        {
            InitializeComponent();
            TimerLabel.Text = spentTime;
        }

        private void SaveResultsButton_Click(object sender, EventArgs e)
        {
            if(NameTextBox.Text != "")
            {
                File.AppendAllText("leaderboard.txt", $"{NameTextBox.Text} {TimerLabel.Text}\n");
                MessageBox.Show("Данные записаны! Таблицу лидеров вы можете посмотреть в главном меню!", "Готово!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                foreach (Form form in Application.OpenForms)
                {
                    form.Show();
                }
                Close();
            }
            else
            {
                MessageBox.Show("Сначала укажите имя!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region Кнопка выхода из игры
        private void ExitLabel_MouseEnter(object sender, EventArgs e)
        {
            ExitLabel.ForeColor = Color.LightCoral;
        }

        private void ExitLabel_MouseLeave(object sender, EventArgs e)
        {
            ExitLabel.ForeColor = Color.Red;
        }

        private void ExitLabel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?\nВаши достижения не будут сохранены!", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Form form in Application.OpenForms)
                {
                    form.Show();
                }
                Close();
            }
        }
        #endregion

        #region Перетягивание формы по экрану
        Point lastPoint;
        private void GameNamePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void GameNamePanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        #endregion
    }
}
