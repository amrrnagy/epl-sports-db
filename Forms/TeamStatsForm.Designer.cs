namespace EPL_DBMS.Forms
{
    partial class TeamStatsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.dataGridViewTeamStats = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeamStats)).BeginInit();
            this.SuspendLayout();
            // dataGridViewTeamStats
            this.dataGridViewTeamStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTeamStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTeamStats.Name = "dataGridViewTeamStats";
            this.dataGridViewTeamStats.ReadOnly = true;
            this.dataGridViewTeamStats.RowHeadersWidth = 51;
            this.dataGridViewTeamStats.RowTemplate.Height = 24;
            this.dataGridViewTeamStats.TabIndex = 0;
            // TeamStatsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 520);
            this.Controls.Add(this.dataGridViewTeamStats);
            this.Name = "TeamStatsForm";
            this.Text = "Team Stats";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeamStats)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTeamStats;
    }
}
