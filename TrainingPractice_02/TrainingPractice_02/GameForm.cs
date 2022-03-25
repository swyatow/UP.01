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
    public partial class GameForm : Form
    {
        List<Button> buttonList = new List<Button> { };
        List<Control> neighbors = new List<Control> { };
        int[,] neighborsPositions = new int[4,4];
        Random rnd = new Random();
        int minutes, seconds, miliseconds;
        bool win = false;

        public GameForm()
        {
            InitializeComponent();
            for (int i = 1; i < 9; i++)
            {
                Button button = new Button();
                button.BackColor = Color.LightYellow;
                button.Dock = DockStyle.Fill;
                button.ForeColor = Color.CornflowerBlue;
                button.Font = new Font("Segoe UI Black", 70, FontStyle.Bold);
                button.Click += Button_Click;
                button.Text = (i).ToString();

                buttonList.Add(button);
            }
            foreach(Button button in buttonList)
            {
                int x = 0;
                int y = 0;
                while (true)
                {
                    x = rnd.Next(3);
                    y = rnd.Next(3);
                    if(GameTable.GetControlFromPosition(x, y) == null)
                    {
                        break;
                    }
                }
                GameTable.Controls.Add(button,x,y);
            }
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            neighbors.Clear();
            Array.Clear(neighborsPositions, 0, neighborsPositions.Length);
            TableLayoutPanelCellPosition cellPosition = GameTable.GetCellPosition((Button)sender);
            int x = cellPosition.Column, y = cellPosition.Row, arrayPosition = 0;

            AddNeighbor(x + 1, y, ref arrayPosition);
            AddNeighbor(x - 1, y, ref arrayPosition);
            AddNeighbor(x, y + 1, ref arrayPosition);
            AddNeighbor(x, y - 1, ref arrayPosition);

            for(int i = 0; i < neighbors.Count; i++)
            {
                if (neighbors[i] == null)
                {
                    MoveCell(x,y,neighborsPositions[i, 0], neighborsPositions[i, 1]);
                }
            }
            CheckButtons();
            CheckWin();
            if (win)
            {
                GameTimer.Stop();
                WinForm winForm = new WinForm(TimerLabel.Text);
                this.Close();
                winForm.Show();
            }
        }

        private void AddNeighbor(int x, int y, ref int i)
        {
            if(x < 3 && y < 3 && x >= 0 && y >= 0)
            {
                neighbors.Add(GameTable.GetControlFromPosition(x, y));
                neighborsPositions[i, 0] = x;
                neighborsPositions[i, 1] = y;
                i++;
            }
        }

        private void MoveCell(int currentPositionX, int currentPositionY, int movePositionX, int movePositionY)
        {
            Control currentControl = GameTable.GetControlFromPosition(currentPositionX, currentPositionY);
            GameTable.SetCellPosition(currentControl, new TableLayoutPanelCellPosition(movePositionX, movePositionY));
        }

        private void CheckButtons()
        {
            int currentButton = 0;
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Control currentControl = GameTable.GetControlFromPosition(j, i);
                    if(currentControl != null && currentButton <= 7)
                    {
                        if (currentControl.Text == buttonList[currentButton].Text)
                        {
                            currentControl.ForeColor = Color.Green;
                        } 
                        else
                        {
                            currentControl.ForeColor = Color.CornflowerBlue;
                        }
                        //Баг с цветом 8 при переходе из 2,1 в 2,2
                    } 
                    
                    currentButton++;
                }
            }
        }

        private void CheckWin()
        {
            int currentButton = 0;
            int correctButtonsCount = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Control currentControl = GameTable.GetControlFromPosition(j, i);
                    if (currentControl != null && currentButton <= 7)
                    {
                        if (currentControl.ForeColor == Color.Green)
                            correctButtonsCount++;
                        currentButton++;
                    }
                }
            }
            if(correctButtonsCount == 8)
                win = true;
        }

        #region Кнопка выхода из игры
        private void ExitLabel_Click(object sender, EventArgs e)
        {
            GameTimer.Stop();
            if (MessageBox.Show("Вы действительно хотите закончить попытку?\nВаши достижения не будут сохранены!", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
                Owner.Show();
            }
            else
            {
                GameTimer.Start();
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

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            miliseconds++;
            seconds = miliseconds / 10;
            minutes = seconds / 60;
            TimerLabel.Text = minutes + ":" + seconds % 60 + "." + miliseconds % 10;
        }
    }
}
