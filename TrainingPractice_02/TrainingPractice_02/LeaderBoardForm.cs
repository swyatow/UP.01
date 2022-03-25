using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainingPractice_02
{
    public partial class LeaderBoardForm : Form
    {
        Dictionary<String,String> leaderBoard = new Dictionary<String,String>();

        public LeaderBoardForm()
        {
            InitializeComponent();
            using(StreamReader sr = new StreamReader("leaderboard.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(" ");
                    leaderBoard.Add(line[0], line[1]);
                }
            }
            int i = 0;
            if(leaderBoard.Count > 0)
            {
                foreach (var pair in leaderBoard.OrderBy(pair => pair.Value))
                {
                    LeaderBoardGridView.Rows.Add(pair.Key, pair.Value);
                    i++;
                }
            }
            
        }


        #region Кнопка выхода из игры
        private void ExitLabel_Click(object sender, EventArgs e)
        {
            Close();
            Owner.Show();
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
    }
}
