namespace TrainingPractice_02
{
    partial class WinForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ExitLabel = new System.Windows.Forms.Label();
            this.GameLabel = new System.Windows.Forms.Label();
            this.GameNamePanel = new System.Windows.Forms.Panel();
            this.SaveResultsButton = new System.Windows.Forms.Button();
            this.ExitWithoutSaveButton = new System.Windows.Forms.Button();
            this.InfoLabel1 = new System.Windows.Forms.Label();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.InfoLabel2 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.GameNamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitLabel
            // 
            this.ExitLabel.AutoSize = true;
            this.ExitLabel.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExitLabel.ForeColor = System.Drawing.Color.Red;
            this.ExitLabel.Location = new System.Drawing.Point(766, -5);
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
            this.GameLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GameLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.GameLabel.Location = new System.Drawing.Point(24, 32);
            this.GameLabel.Name = "GameLabel";
            this.GameLabel.Size = new System.Drawing.Size(732, 45);
            this.GameLabel.TabIndex = 0;
            this.GameLabel.Text = "Поздравляю! Вы смогли решить Пятнашки!";
            this.GameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameNamePanel
            // 
            this.GameNamePanel.BackColor = System.Drawing.Color.DarkCyan;
            this.GameNamePanel.Controls.Add(this.ExitLabel);
            this.GameNamePanel.Controls.Add(this.GameLabel);
            this.GameNamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.GameNamePanel.Location = new System.Drawing.Point(0, 0);
            this.GameNamePanel.Name = "GameNamePanel";
            this.GameNamePanel.Size = new System.Drawing.Size(800, 111);
            this.GameNamePanel.TabIndex = 1;
            this.GameNamePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameNamePanel_MouseDown);
            this.GameNamePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameNamePanel_MouseMove);
            // 
            // SaveResultsButton
            // 
            this.SaveResultsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(195)))), ((int)(((byte)(228)))));
            this.SaveResultsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveResultsButton.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SaveResultsButton.Location = new System.Drawing.Point(12, 391);
            this.SaveResultsButton.Name = "SaveResultsButton";
            this.SaveResultsButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SaveResultsButton.Size = new System.Drawing.Size(272, 47);
            this.SaveResultsButton.TabIndex = 2;
            this.SaveResultsButton.Text = "Сохранить результат";
            this.SaveResultsButton.UseVisualStyleBackColor = false;
            this.SaveResultsButton.Click += new System.EventHandler(this.SaveResultsButton_Click);
            // 
            // ExitWithoutSaveButton
            // 
            this.ExitWithoutSaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(195)))), ((int)(((byte)(228)))));
            this.ExitWithoutSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExitWithoutSaveButton.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExitWithoutSaveButton.Location = new System.Drawing.Point(516, 391);
            this.ExitWithoutSaveButton.Name = "ExitWithoutSaveButton";
            this.ExitWithoutSaveButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ExitWithoutSaveButton.Size = new System.Drawing.Size(272, 47);
            this.ExitWithoutSaveButton.TabIndex = 3;
            this.ExitWithoutSaveButton.Text = "Выйти без сохранения";
            this.ExitWithoutSaveButton.UseVisualStyleBackColor = false;
            this.ExitWithoutSaveButton.Click += new System.EventHandler(this.ExitLabel_Click);
            // 
            // InfoLabel1
            // 
            this.InfoLabel1.AutoSize = true;
            this.InfoLabel1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InfoLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.InfoLabel1.Location = new System.Drawing.Point(12, 132);
            this.InfoLabel1.Name = "InfoLabel1";
            this.InfoLabel1.Size = new System.Drawing.Size(310, 38);
            this.InfoLabel1.TabIndex = 4;
            this.InfoLabel1.Text = "Потрачено времени: ";
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TimerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TimerLabel.Location = new System.Drawing.Point(328, 132);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(0, 38);
            this.TimerLabel.TabIndex = 5;
            // 
            // InfoLabel2
            // 
            this.InfoLabel2.AutoSize = true;
            this.InfoLabel2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InfoLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.InfoLabel2.Location = new System.Drawing.Point(12, 223);
            this.InfoLabel2.Name = "InfoLabel2";
            this.InfoLabel2.Size = new System.Drawing.Size(270, 38);
            this.InfoLabel2.TabIndex = 6;
            this.InfoLabel2.Text = "Введите свое имя:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NameTextBox.Location = new System.Drawing.Point(328, 223);
            this.NameTextBox.MaxLength = 15;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(410, 43);
            this.NameTextBox.TabIndex = 7;
            // 
            // WinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.InfoLabel2);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.InfoLabel1);
            this.Controls.Add(this.ExitWithoutSaveButton);
            this.Controls.Add(this.SaveResultsButton);
            this.Controls.Add(this.GameNamePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinForm";
            this.GameNamePanel.ResumeLayout(false);
            this.GameNamePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ExitLabel;
        private System.Windows.Forms.Label GameLabel;
        private System.Windows.Forms.Panel GameNamePanel;
        private System.Windows.Forms.Button SaveResultsButton;
        private System.Windows.Forms.Button ExitWithoutSaveButton;
        private System.Windows.Forms.Label InfoLabel1;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Label InfoLabel2;
        private System.Windows.Forms.TextBox NameTextBox;
    }
}