using System;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Кнопка выхода из игры
        private void ExitLabel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из приложения?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void ExitLabel_MouseEnter(object sender, EventArgs e)
        {
            ExitLabel.ForeColor = Color.LightCoral;
        }

        private void ExitLabel_MouseLeave(object sender, EventArgs e)
        {
            ExitLabel.ForeColor = Color.Red;
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

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm();
            gameForm.Owner = this;
            Hide();
            gameForm.ShowDialog();
        }

        private void LeaderBoardButton_Click(object sender, EventArgs e)
        {
            LeaderBoardForm leaderBoardForm = new LeaderBoardForm();
            leaderBoardForm.Owner = this;
            Hide();
            leaderBoardForm.ShowDialog();
        }
    }
}
