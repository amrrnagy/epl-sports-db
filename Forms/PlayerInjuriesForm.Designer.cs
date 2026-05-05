namespace EPL_DBMS.Forms
{
    partial class PlayerInjuriesForm
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
            this.dataGridViewPlayerInjuries = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayerInjuries)).BeginInit();
            this.SuspendLayout();
            // dataGridViewPlayerInjuries
            this.dataGridViewPlayerInjuries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPlayerInjuries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPlayerInjuries.Name = "dataGridViewPlayerInjuries";
            this.dataGridViewPlayerInjuries.ReadOnly = true;
            this.dataGridViewPlayerInjuries.RowHeadersWidth = 51;
            this.dataGridViewPlayerInjuries.RowTemplate.Height = 24;
            this.dataGridViewPlayerInjuries.TabIndex = 0;
            // PlayerInjuriesForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 520);
            this.Controls.Add(this.dataGridViewPlayerInjuries);
            this.Name = "PlayerInjuriesForm";
            this.Text = "Player Injuries";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayerInjuries)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPlayerInjuries;
    }
}
