namespace EPL_DBMS.Forms
{
    partial class StadiumsForm
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
            this.dataGridViewStadiums = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStadiums)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewStadiums
            // 
            this.dataGridViewStadiums.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStadiums.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStadiums.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewStadiums.Name = "dataGridViewStadiums";
            this.dataGridViewStadiums.ReadOnly = true;
            this.dataGridViewStadiums.RowHeadersWidth = 51;
            this.dataGridViewStadiums.RowTemplate.Height = 24;
            this.dataGridViewStadiums.Size = new System.Drawing.Size(960, 520);
            this.dataGridViewStadiums.TabIndex = 0;
            // 
            // StadiumsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 520);
            this.Controls.Add(this.dataGridViewStadiums);
            this.Name = "StadiumsForm";
            this.Text = "Stadiums";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStadiums)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DataGridView dataGridViewStadiums;
    }
}
