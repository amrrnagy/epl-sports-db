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
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtnationality = new System.Windows.Forms.TextBox();
            this.txtformation = new System.Windows.Forms.TextBox();
            this.txtteamid = new System.Windows.Forms.TextBox();
            this.txtexperienceyear = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.dataGridViewManagers = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManagers)).BeginInit();
            this.SuspendLayout();
            // 
            // txtname
            // 
            this.txtname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtname.Location = new System.Drawing.Point(30, 70);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(120, 22);
            this.txtname.TabIndex = 17;
            // 
            // txtnationality
            // 
            this.txtnationality.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtnationality.Location = new System.Drawing.Point(170, 70);
            this.txtnationality.Name = "txtnationality";
            this.txtnationality.Size = new System.Drawing.Size(120, 22);
            this.txtnationality.TabIndex = 18;
            // 
            // txtformation
            // 
            this.txtformation.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtformation.Location = new System.Drawing.Point(310, 70);
            this.txtformation.Name = "txtformation";
            this.txtformation.Size = new System.Drawing.Size(120, 22);
            this.txtformation.TabIndex = 19;
            // 
            // txtteamid
            // 
            this.txtteamid.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtteamid.Location = new System.Drawing.Point(590, 70);
            this.txtteamid.Name = "txtteamid";
            this.txtteamid.Size = new System.Drawing.Size(93, 22);
            this.txtteamid.TabIndex = 22;
            // 
            // txtexperienceyear
            // 
            this.txtexperienceyear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtexperienceyear.Location = new System.Drawing.Point(450, 70);
            this.txtexperienceyear.Name = "txtexperienceyear";
            this.txtexperienceyear.Size = new System.Drawing.Size(120, 22);
            this.txtexperienceyear.TabIndex = 20;
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.SystemColors.Info;
            this.txtid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtid.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(249, 26);
            this.txtid.Multiline = true;
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(195, 28);
            this.txtid.TabIndex = 14;
            this.txtid.Text = "ENTER MANAGER ID";
            this.txtid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.TabIndex = 23;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.Location = new System.Drawing.Point(214, 108);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 37);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpdate.Location = new System.Drawing.Point(351, 108);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 37);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.Location = new System.Drawing.Point(492, 108);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 37);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // search
            // 
            this.search.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.search.Location = new System.Drawing.Point(450, 25);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(68, 29);
            this.search.TabIndex = 15;
            this.search.Text = "Search";
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // dataGridViewManagers
            // 
            this.dataGridViewManagers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewManagers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewManagers.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewManagers.ColumnHeadersHeight = 29;
            this.dataGridViewManagers.Location = new System.Drawing.Point(12, 162);
            this.dataGridViewManagers.Name = "dataGridViewManagers";
            this.dataGridViewManagers.ReadOnly = true;
            this.dataGridViewManagers.RowHeadersWidth = 51;
            this.dataGridViewManagers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewManagers.Size = new System.Drawing.Size(746, 346);
            this.dataGridViewManagers.TabIndex = 28;
            // 
            // ManagersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 520);
            this.Controls.Add(this.dataGridViewManagers);
            this.Controls.Add(this.search);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.txtformation);
            this.Controls.Add(this.txtexperienceyear);
            this.Controls.Add(this.txtnationality);
            this.Controls.Add(this.txtteamid);
            this.Name = "ManagersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Managers Management";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManagers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtnationality;
        private System.Windows.Forms.TextBox txtteamid;
        private System.Windows.Forms.TextBox txtexperienceyear;
        private System.Windows.Forms.TextBox txtformation;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridViewManagers;
        private System.Windows.Forms.Button search;
    }
}