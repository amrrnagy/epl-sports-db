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
    }
}
