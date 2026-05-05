namespace EPL_DBMS.Forms
{
    partial class ManagersForm
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
            this.dataGridViewManagers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManagers)).BeginInit();
            this.SuspendLayout();
            // dataGridViewManagers
            this.dataGridViewManagers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManagers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewManagers.Name = "dataGridViewManagers";
            this.dataGridViewManagers.ReadOnly = true;
            this.dataGridViewManagers.RowHeadersWidth = 51;
            this.dataGridViewManagers.RowTemplate.Height = 24;
            this.dataGridViewManagers.TabIndex = 0;
            // ManagersForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 520);
            this.Controls.Add(this.dataGridViewManagers);
            this.Name = "ManagersForm";
            this.Text = "Managers";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManagers)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.DataGridView dataGridViewManagers;
    }
}
