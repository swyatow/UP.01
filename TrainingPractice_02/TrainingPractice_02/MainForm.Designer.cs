namespace TrainingPractice_02
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GameNamePanel = new System.Windows.Forms.Panel();
            this.ExitLabel = new System.Windows.Forms.Label();
            this.GameLabel = new System.Windows.Forms.Label();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.LeaderBoardButton = new System.Windows.Forms.Button();
            this.GameNamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameNamePanel
            // 
            this.GameNamePanel.BackColor = System.Drawing.Color.DarkCyan;
            this.GameNamePanel.Controls.Add(this.ExitLabel);
            this.GameNamePanel.Controls.Add(this.GameLabel);
            this.GameNamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.GameNamePanel.Location = new System.Drawing.Point(0, 0);
            this.GameNamePanel.Name = "GameNamePanel";
            this.GameNamePanel.Size = new System.Drawing.Size(533, 125);
            this.GameNamePanel.TabIndex = 0;
            this.GameNamePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameNamePanel_MouseDown);
            this.GameNamePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameNamePanel_MouseMove);
            // 
            // ExitLabel
            // 
            this.ExitLabel.AutoSize = true;
            this.ExitLabel.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExitLabel.ForeColor = System.Drawing.Color.Red;
            this.ExitLabel.Location = new System.Drawing.Point(491, 0);
            this.ExitLabel.Name = "ExitLabel";
            this.ExitLabel.Size = new System.Drawing.Size(39, 41);
            this.ExitLabel.TabIndex = 2;
            this.ExitLabel.Text = "X";
            this.ExitLabel.Click += new System.EventHandler(this.ExitLabel_Click);
            this.ExitLabel.MouseEnter += new System.EventHandler(this.ExitLabel_MouseEnter);
            this.ExitLabel.MouseLeave += new System.EventHandler(this.ExitLabel_MouseLeave);
            // 
            // GameLabel
            // 
            this.GameLabel.AutoSize = true;
            this.GameLabel.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GameLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.GameLabel.Location = new System.Drawing.Point(102, 18);
            this.GameLabel.Name = "GameLabel";
            this.GameLabel.Size = new System.Drawing.Size(335, 81);
            this.GameLabel.TabIndex = 0;
            this.GameLabel.Text = "Пятнашки";
            this.GameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartGameButton
            // 
            this.StartGameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(195)))), ((int)(((byte)(228)))));
            this.StartGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartGameButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StartGameButton.Location = new System.Drawing.Point(102, 150);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartGameButton.Size = new System.Drawing.Size(335, 78);
            this.StartGameButton.TabIndex = 1;
            this.StartGameButton.Text = "Начать игру";
            this.StartGameButton.UseVisualStyleBackColor = false;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // LeaderBoardButton
            // 
            this.LeaderBoardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(195)))), ((int)(((byte)(228)))));
            this.LeaderBoardButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LeaderBoardButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LeaderBoardButton.Location = new System.Drawing.Point(102, 254);
            this.LeaderBoardButton.Name = "LeaderBoardButton";
            this.LeaderBoardButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LeaderBoardButton.Size = new System.Drawing.Size(335, 78);
            this.LeaderBoardButton.TabIndex = 2;
            this.LeaderBoardButton.Text = "Таблица лидеров";
            this.LeaderBoardButton.UseVisualStyleBackColor = false;
            this.LeaderBoardButton.Click += new System.EventHandler(this.LeaderBoardButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(533, 364);
            this.Controls.Add(this.LeaderBoardButton);
            this.Controls.Add(this.StartGameButton);
            this.Controls.Add(this.GameNamePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.GameNamePanel.ResumeLayout(false);
            this.GameNamePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel GameNamePanel;
        private System.Windows.Forms.Label GameLabel;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Label ExitLabel;
        private System.Windows.Forms.Button LeaderBoardButton;
    }
}
