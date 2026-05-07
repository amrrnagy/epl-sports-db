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
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtnationality = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.dataGridViewReferees = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReferees)).BeginInit();
            this.SuspendLayout();
            // 
            // txtname
            // 
            this.txtname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtname.Location = new System.Drawing.Point(256, 70);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(93, 20);
            this.txtname.TabIndex = 17;
            // 
            // txtnationality
            // 
            this.txtnationality.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtnationality.Location = new System.Drawing.Point(411, 70);
            this.txtnationality.Name = "txtnationality";
            this.txtnationality.Size = new System.Drawing.Size(93, 20);
            this.txtnationality.TabIndex = 18;
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtid.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(283, 15);
            this.txtid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtid.Multiline = true;
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(194, 24);
            this.txtid.TabIndex = 23;
            this.txtid.Text = "ENTER REFEREE ID";
            this.txtid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtid.TextChanged += new System.EventHandler(this.txtid_TextChanged_1);
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
            this.delete.Location = new System.Drawing.Point(547, 119);
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
            this.add.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.add.Location = new System.Drawing.Point(121, 119);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(93, 63);
            this.add.TabIndex = 25;
            this.add.Text = "Add";
            this.add.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridViewReferees
            // 
            this.dataGridViewReferees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewReferees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReferees.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewReferees.ColumnHeadersHeight = 29;
            this.dataGridViewReferees.Location = new System.Drawing.Point(11, 201);
            this.dataGridViewReferees.Name = "dataGridViewReferees";
            this.dataGridViewReferees.ReadOnly = true;
            this.dataGridViewReferees.RowHeadersWidth = 51;
            this.dataGridViewReferees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReferees.Size = new System.Drawing.Size(738, 404);
            this.dataGridViewReferees.TabIndex = 28;
            this.dataGridViewReferees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewReferees_CellClick);
            // 
            // RefereesForm
            // 
            this.ClientSize = new System.Drawing.Size(760, 617);
            this.Controls.Add(this.txtnationality);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.dataGridViewReferees);
            this.Controls.Add(this.add);
            this.Controls.Add(this.update);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtid);
            this.Name = "RefereesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RefereesForm";
            this.Load += new System.EventHandler(this.RefereesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReferees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtnationality;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.DataGridView dataGridViewReferees;
    }
}
