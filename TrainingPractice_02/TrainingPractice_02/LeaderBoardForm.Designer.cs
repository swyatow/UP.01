namespace TrainingPractice_02
{
    partial class LeaderBoardForm
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
            this.LeaderBoardGridView = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GameNamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeaderBoardGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitLabel
            // 
            this.ExitLabel.AutoSize = true;
            this.ExitLabel.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExitLabel.ForeColor = System.Drawing.Color.Red;
            this.ExitLabel.Location = new System.Drawing.Point(403, 0);
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
            this.GameLabel.Location = new System.Drawing.Point(68, 30);
            this.GameLabel.Name = "GameLabel";
            this.GameLabel.Size = new System.Drawing.Size(302, 45);
            this.GameLabel.TabIndex = 0;
            this.GameLabel.Text = "Таблица лидеров";
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
            this.GameNamePanel.Size = new System.Drawing.Size(437, 111);
            this.GameNamePanel.TabIndex = 2;
            this.GameNamePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameNamePanel_MouseDown);
            this.GameNamePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameNamePanel_MouseMove);
            // 
            // LeaderBoardGridView
            // 
            this.LeaderBoardGridView.AllowUserToAddRows = false;
            this.LeaderBoardGridView.AllowUserToDeleteRows = false;
            this.LeaderBoardGridView.AllowUserToOrderColumns = true;
            this.LeaderBoardGridView.AllowUserToResizeRows = false;
            this.LeaderBoardGridView.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.LeaderBoardGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LeaderBoardGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.TimerColumn});
            this.LeaderBoardGridView.Location = new System.Drawing.Point(12, 117);
            this.LeaderBoardGridView.MultiSelect = false;
            this.LeaderBoardGridView.Name = "LeaderBoardGridView";
            this.LeaderBoardGridView.ReadOnly = true;
            this.LeaderBoardGridView.RowHeadersWidth = 51;
            this.LeaderBoardGridView.RowTemplate.Height = 29;
            this.LeaderBoardGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LeaderBoardGridView.Size = new System.Drawing.Size(413, 520);
            this.LeaderBoardGridView.TabIndex = 3;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Имя игрока";
            this.NameColumn.MinimumWidth = 6;
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 200;
            // 
            // TimerColumn
            // 
            this.TimerColumn.HeaderText = "Потраченное время";
            this.TimerColumn.MinimumWidth = 6;
            this.TimerColumn.Name = "TimerColumn";
            this.TimerColumn.ReadOnly = true;
            this.TimerColumn.Width = 160;
            // 
            // LeaderBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(437, 649);
            this.Controls.Add(this.LeaderBoardGridView);
            this.Controls.Add(this.GameNamePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LeaderBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LeaderBoardForm";
            this.GameNamePanel.ResumeLayout(false);
            this.GameNamePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeaderBoardGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ExitLabel;
        private System.Windows.Forms.Label GameLabel;
        private System.Windows.Forms.Panel GameNamePanel;
        private System.Windows.Forms.DataGridView LeaderBoardGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimerColumn;
    }
}