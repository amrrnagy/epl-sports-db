namespace EPL_DBMS.Forms
{
    partial class TeamsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtfounded = new System.Windows.Forms.TextBox();
            this.txtkitcolor = new System.Windows.Forms.TextBox();
            this.txtstadiumid = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.dataGridViewTeams = new System.Windows.Forms.DataGridView();
            this.btnTeamStats = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeams)).BeginInit();
            this.SuspendLayout();
            // 
            // txtname
            // 
            this.txtname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtname.Location = new System.Drawing.Point(102, 70);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(93, 22);
            this.txtname.TabIndex = 17;
            // 
            // txtfounded
            // 
            this.txtfounded.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtfounded.Location = new System.Drawing.Point(257, 70);
            this.txtfounded.Name = "txtfounded";
            this.txtfounded.Size = new System.Drawing.Size(93, 22);
            this.txtfounded.TabIndex = 18;
            // 
            // txtkitcolor
            // 
            this.txtkitcolor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtkitcolor.Location = new System.Drawing.Point(411, 70);
            this.txtkitcolor.Name = "txtkitcolor";
            this.txtkitcolor.Size = new System.Drawing.Size(93, 22);
            this.txtkitcolor.TabIndex = 19;
            // 
            // txtstadiumid
            // 
            this.txtstadiumid.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtstadiumid.Location = new System.Drawing.Point(565, 70);
            this.txtstadiumid.Name = "txtstadiumid";
            this.txtstadiumid.Size = new System.Drawing.Size(93, 22);
            this.txtstadiumid.TabIndex = 20;
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.SystemColors.Info;
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
            this.delete.Location = new System.Drawing.Point(547, 119);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(93, 37);
            this.delete.TabIndex = 27;
            this.delete.Text = "Delete";
            this.delete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // update
            // 
            this.update.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.update.Location = new System.Drawing.Point(334, 119);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(93, 37);
            this.update.TabIndex = 26;
            this.update.Text = "Update";
            this.update.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // add
            // 
            this.add.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.add.Location = new System.Drawing.Point(121, 119);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(93, 37);
            this.add.TabIndex = 25;
            this.add.Text = "Add";
            this.add.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridViewTeams
            // 
            this.dataGridViewTeams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTeams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTeams.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewTeams.ColumnHeadersHeight = 29;
            this.dataGridViewTeams.Location = new System.Drawing.Point(11, 181);
            this.dataGridViewTeams.Name = "dataGridViewTeams";
            this.dataGridViewTeams.ReadOnly = true;
            this.dataGridViewTeams.RowHeadersWidth = 51;
            this.dataGridViewTeams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTeams.Size = new System.Drawing.Size(629, 303);
            this.dataGridViewTeams.TabIndex = 28;
            this.dataGridViewTeams.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTeams_CellClick);
            // 
            // btnTeamStats
            // 
            this.btnTeamStats.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTeamStats.Location = new System.Drawing.Point(655, 290);
            this.btnTeamStats.Name = "btnTeamStats";
            this.btnTeamStats.Size = new System.Drawing.Size(93, 62);
            this.btnTeamStats.TabIndex = 29;
            this.btnTeamStats.Text = "Stats";
            this.btnTeamStats.Click += new System.EventHandler(this.btnTeamStats_Click);
            // 
            // TeamsForm
            // 
            this.ClientSize = new System.Drawing.Size(760, 496);
            this.Controls.Add(this.btnTeamStats);
            this.Controls.Add(this.txtfounded);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.dataGridViewTeams);
            this.Controls.Add(this.add);
            this.Controls.Add(this.update);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.txtkitcolor);
            this.Controls.Add(this.txtstadiumid);
            this.Name = "TeamsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeamsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtfounded;
        private System.Windows.Forms.TextBox txtkitcolor;
        private System.Windows.Forms.TextBox txtstadiumid;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.DataGridView dataGridViewTeams;
        private System.Windows.Forms.Button btnTeamStats;
    }
}