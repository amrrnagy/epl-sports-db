namespace EPL_DBMS.Forms
{
    partial class PlayerStatsForm
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
            this.dataGridViewPlayerStats = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayerStats)).BeginInit();
            this.SuspendLayout();
            // dataGridViewPlayerStats
            this.dataGridViewPlayerStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPlayerStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPlayerStats.Name = "dataGridViewPlayerStats";
            this.dataGridViewPlayerStats.ReadOnly = true;
            this.dataGridViewPlayerStats.RowHeadersWidth = 51;
            this.dataGridViewPlayerStats.RowTemplate.Height = 24;
            this.dataGridViewPlayerStats.TabIndex = 0;
            // PlayerStatsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 520);
            this.Controls.Add(this.dataGridViewPlayerStats);
            this.Name = "PlayerStatsForm";
            this.Text = "Player Stats";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayerStats)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPlayerStats;
    }
}
