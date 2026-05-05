namespace EPL_DBMS.Forms
{
    partial class RefereesForm
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
            this.dataGridViewReferees = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReferees)).BeginInit();
            this.SuspendLayout();
            // dataGridViewReferees
            this.dataGridViewReferees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReferees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewReferees.Name = "dataGridViewReferees";
            this.dataGridViewReferees.ReadOnly = true;
            this.dataGridViewReferees.RowHeadersWidth = 51;
            this.dataGridViewReferees.RowTemplate.Height = 24;
            this.dataGridViewReferees.TabIndex = 0;
            // RefereesForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 520);
            this.Controls.Add(this.dataGridViewReferees);
            this.Name = "RefereesForm";
            this.Text = "Referees";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReferees)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.DataGridView dataGridViewReferees;
    }
}
