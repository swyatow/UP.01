namespace TrainingPractice_02
{
    partial class GameForm
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
            this.components = new System.ComponentModel.Container();
            this.GameNamePanel = new System.Windows.Forms.Panel();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.ExitLabel = new System.Windows.Forms.Label();
            this.GameTable = new System.Windows.Forms.TableLayoutPanel();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.GameNamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameNamePanel
            // 
            this.GameNamePanel.BackColor = System.Drawing.Color.DarkCyan;
            this.GameNamePanel.Controls.Add(this.TimerLabel);
            this.GameNamePanel.Controls.Add(this.ExitLabel);
            this.GameNamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.GameNamePanel.Location = new System.Drawing.Point(0, 0);
            this.GameNamePanel.Name = "GameNamePanel";
            this.GameNamePanel.Size = new System.Drawing.Size(831, 90);
            this.GameNamePanel.TabIndex = 1;
            this.GameNamePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameNamePanel_MouseDown);
            this.GameNamePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameNamePanel_MouseMove);
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TimerLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.TimerLabel.Location = new System.Drawing.Point(363, 22);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(113, 38);
            this.TimerLabel.TabIndex = 4;
            this.TimerLabel.Text = "0.00:00";
            // 
            // ExitLabel
            // 
            this.ExitLabel.AutoSize = true;
            this.ExitLabel.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExitLabel.ForeColor = System.Drawing.Color.Red;
            this.ExitLabel.Location = new System.Drawing.Point(793, 0);
            this.ExitLabel.Name = "ExitLabel";
            this.ExitLabel.Size = new System.Drawing.Size(39, 41);
            this.ExitLabel.TabIndex = 2;
            this.ExitLabel.Text = "X";
            this.ExitLabel.Click += new System.EventHandler(this.ExitLabel_Click);
            this.ExitLabel.MouseEnter += new System.EventHandler(this.ExitLabel_MouseEnter);
            this.ExitLabel.MouseLeave += new System.EventHandler(this.ExitLabel_MouseLeave);
            // 
            // GameTable
            // 
            this.GameTable.ColumnCount = 3;
            this.GameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.GameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.GameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.GameTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameTable.Location = new System.Drawing.Point(0, 90);
            this.GameTable.Name = "GameTable";
            this.GameTable.RowCount = 3;
            this.GameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.GameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.GameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.GameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GameTable.Size = new System.Drawing.Size(831, 682);
            this.GameTable.TabIndex = 2;
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(831, 772);
            this.Controls.Add(this.GameTable);
            this.Controls.Add(this.GameNamePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameForm";
            this.GameNamePanel.ResumeLayout(false);
            this.GameNamePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel GameNamePanel;
        private System.Windows.Forms.Label ExitLabel;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.TableLayoutPanel GameTable;
        private System.Windows.Forms.Timer GameTimer;
    }
}