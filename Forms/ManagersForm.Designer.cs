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
            this.delete = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
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
            // txtname
            // 
            this.txtname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtname.Location = new System.Drawing.Point(30, 70);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(93, 20);
            this.txtname.TabIndex = 17;
            // 
            // txtnationality
            // 
            this.txtnationality.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtnationality.Location = new System.Drawing.Point(182, 70);
            this.txtnationality.Name = "txtnationality";
            this.txtnationality.Size = new System.Drawing.Size(93, 20);
            this.txtnationality.TabIndex = 18;
            // 
            // txtformation
            // 
            this.txtformation.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtformation.Location = new System.Drawing.Point(334, 70);
            this.txtformation.Name = "txtformation";
            this.txtformation.Size = new System.Drawing.Size(93, 20);
            this.txtformation.TabIndex = 19;
            // 
            // txtteamid
            // 
            this.txtteamid.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtteamid.Location = new System.Drawing.Point(486, 70);
            this.txtteamid.Name = "txtteamid";
            this.txtteamid.Size = new System.Drawing.Size(93, 20);
            this.txtteamid.TabIndex = 22;
            // 
            // txtexperienceyear
            // 
            this.txtexperienceyear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtexperienceyear.Location = new System.Drawing.Point(638, 70);
            this.txtexperienceyear.Name = "txtexperienceyear";
            this.txtexperienceyear.Size = new System.Drawing.Size(93, 20);
            this.txtexperienceyear.TabIndex = 20;
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtid.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(290, 15);
            this.txtid.Multiline = true;
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(180, 28);
            this.txtid.TabIndex = 21;
            this.txtid.Text = "ENTER TEAM ID";
            this.txtid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtid.TextChanged += new System.EventHandler(this.txtid_TextChanged);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(10, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.TabIndex = 23;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // delete
            // 
            this.delete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.delete.Location = new System.Drawing.Point(550, 119);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(93, 63);
            this.delete.TabIndex = 27;
            this.delete.Text = "Delete";
            this.delete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // update
            // 
            this.update.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.update.Location = new System.Drawing.Point(334, 119);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(93, 63);
            this.update.TabIndex = 26;
            this.update.Text = "Update";
            this.update.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(118, 119);
            this.add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(93, 63);
            this.add.TabIndex = 19;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridViewManagers
            // 
            this.dataGridViewManagers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewManagers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewManagers.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewManagers.ColumnHeadersHeight = 29;
            this.dataGridViewManagers.Location = new System.Drawing.Point(11, 201);
            this.dataGridViewManagers.Name = "dataGridViewManagers";
            this.dataGridViewManagers.ReadOnly = true;
            this.dataGridViewManagers.RowHeadersWidth = 51;
            this.dataGridViewManagers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewManagers.Size = new System.Drawing.Size(738, 404);
            this.dataGridViewManagers.TabIndex = 28;
            this.dataGridViewManagers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewManagers_CellClick);
            // 
            // ManagersForm
            // 
            this.ClientSize = new System.Drawing.Size(760, 617);
            this.Controls.Add(this.txtnationality);
            this.Controls.Add(this.txtname);
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
            this.Controls.Add(this.add);
            this.Controls.Add(this.update);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.txtteamid);
            this.Controls.Add(this.txtexperienceyear);
            this.Controls.Add(this.txtformation);
            this.Name = "ManagersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManagersForm";
            this.Load += new System.EventHandler(this.ManagersForm_Load);
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
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button add;
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
