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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtExperience = new System.Windows.Forms.TextBox();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.txtTeamId = new System.Windows.Forms.TextBox();
            this.txtFormation = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            this.txtid = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManagers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewManagers
            // 
            this.dataGridViewManagers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManagers.Location = new System.Drawing.Point(12, 162);
            this.dataGridViewManagers.Name = "dataGridViewManagers";
            this.dataGridViewManagers.ReadOnly = true;
            this.dataGridViewManagers.RowHeadersWidth = 51;
            this.dataGridViewManagers.RowTemplate.Height = 24;
            this.dataGridViewManagers.Size = new System.Drawing.Size(864, 346);
            this.dataGridViewManagers.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtName.Location = new System.Drawing.Point(53, 74);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(139, 22);
            this.txtName.TabIndex = 5;
            // 
            // txtExperience
            // 
            this.txtExperience.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtExperience.Location = new System.Drawing.Point(374, 74);
            this.txtExperience.Name = "txtExperience";
            this.txtExperience.Size = new System.Drawing.Size(80, 22);
            this.txtExperience.TabIndex = 7;
            // 
            // txtNationality
            // 
            this.txtNationality.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNationality.Location = new System.Drawing.Point(485, 74);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(120, 22);
            this.txtNationality.TabIndex = 8;
            // 
            // txtTeamId
            // 
            this.txtTeamId.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTeamId.Location = new System.Drawing.Point(641, 74);
            this.txtTeamId.Name = "txtTeamId";
            this.txtTeamId.Size = new System.Drawing.Size(80, 22);
            this.txtTeamId.TabIndex = 9;
            // 
            // txtFormation
            // 
            this.txtFormation.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFormation.Location = new System.Drawing.Point(225, 74);
            this.txtFormation.Name = "txtFormation";
            this.txtFormation.Size = new System.Drawing.Size(120, 22);
            this.txtFormation.TabIndex = 6;
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
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 28);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // search
            // 
            this.search.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.search.Location = new System.Drawing.Point(471, 25);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(68, 29);
            this.search.TabIndex = 15;
            this.search.Text = "Search";
            this.search.Click += new System.EventHandler(this.search_Click);
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
            // ManagersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 520);
            this.Controls.Add(this.search);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtFormation);
            this.Controls.Add(this.txtExperience);
            this.Controls.Add(this.txtNationality);
            this.Controls.Add(this.txtTeamId);
            this.Controls.Add(this.dataGridViewManagers);
            this.Name = "ManagersForm";
            this.Text = "Managers";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManagers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.DataGridView dataGridViewManagers;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtExperience;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.TextBox txtTeamId;
        private System.Windows.Forms.TextBox txtFormation;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox txtid;
    }
}
