namespace EPL_DBMS.Forms
{
    partial class MatchesForm
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
            this.dataGridViewMatches = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatches)).BeginInit();
            this.SuspendLayout();
            // dataGridViewMatches
            this.dataGridViewMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMatches.Name = "dataGridViewMatches";
            this.dataGridViewMatches.ReadOnly = true;
            this.dataGridViewMatches.RowHeadersWidth = 51;
            this.dataGridViewMatches.RowTemplate.Height = 24;
            this.dataGridViewMatches.TabIndex = 0;
            // MatchesForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 520);
            this.Controls.Add(this.dataGridViewMatches);
            this.Name = "MatchesForm";
            this.Text = "Matches";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatches)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMatches;
    }
}
