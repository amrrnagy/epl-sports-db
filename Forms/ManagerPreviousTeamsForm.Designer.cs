namespace EPL_DBMS.Forms
{
    partial class ManagerPreviousTeamsForm
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
            this.dataGridViewManagerHistory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManagerHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewManagerHistory
            // 
            this.dataGridViewManagerHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManagerHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewManagerHistory.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewManagerHistory.Name = "dataGridViewManagerHistory";
            this.dataGridViewManagerHistory.ReadOnly = true;
            this.dataGridViewManagerHistory.RowHeadersWidth = 51;
            this.dataGridViewManagerHistory.RowTemplate.Height = 24;
            this.dataGridViewManagerHistory.Size = new System.Drawing.Size(960, 520);
            this.dataGridViewManagerHistory.TabIndex = 0;
            // 
            // ManagerHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 520);
            this.Controls.Add(this.dataGridViewManagerHistory);
            this.Name = "ManagerHistoryForm";
            this.Text = "Manager History";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManagerHistory)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DataGridView dataGridViewManagerHistory;
    }
}
