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
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtcapacity = new System.Windows.Forms.TextBox();
            this.txtcity = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.dataGridViewStadiums = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStadiums)).BeginInit();
            this.SuspendLayout();
            // 
            // txtname
            // 
            this.txtname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtname.Location = new System.Drawing.Point(179, 70);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(93, 20);
            this.txtname.TabIndex = 17;
            // 
            // txtcapacity
            // 
            this.txtcapacity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtcapacity.Location = new System.Drawing.Point(333, 70);
            this.txtcapacity.Name = "txtcapacity";
            this.txtcapacity.Size = new System.Drawing.Size(93, 20);
            this.txtcapacity.TabIndex = 18;
            // 
            // txtcity
            // 
            this.txtcity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtcity.Location = new System.Drawing.Point(487, 70);
            this.txtcity.Name = "txtcity";
            this.txtcity.Size = new System.Drawing.Size(93, 20);
            this.txtcity.TabIndex = 19;
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
            this.txtid.Text = "ENTER STADIUM ID";
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
            // dataGridViewStadiums
            // 
            this.dataGridViewStadiums.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStadiums.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStadiums.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewStadiums.ColumnHeadersHeight = 29;
            this.dataGridViewStadiums.Location = new System.Drawing.Point(11, 201);
            this.dataGridViewStadiums.Name = "dataGridViewStadiums";
            this.dataGridViewStadiums.ReadOnly = true;
            this.dataGridViewStadiums.RowHeadersWidth = 51;
            this.dataGridViewStadiums.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStadiums.Size = new System.Drawing.Size(738, 404);
            this.dataGridViewStadiums.TabIndex = 28;
            this.dataGridViewStadiums.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStadiums_CellClick);
            // 
            // StadiumsForm
            // 
            this.ClientSize = new System.Drawing.Size(760, 617);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.dataGridViewStadiums);
            this.Controls.Add(this.add);
            this.Controls.Add(this.update);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.txtcapacity);
            this.Controls.Add(this.txtcity);
            this.Name = "StadiumsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StadiumsForm";
            this.Load += new System.EventHandler(this.StadiumsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStadiums)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtfounded;
        private System.Windows.Forms.TextBox txtcapacity;
        private System.Windows.Forms.TextBox txtcity;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.DataGridView dataGridViewStadiums;
    }
}