namespace EPL_DBMS.Forms
{
    partial class TeamsForm
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
            this.txtfounded = new System.Windows.Forms.TextBox();
            this.txtkitcolor = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridViewTeams = new System.Windows.Forms.DataGridView();
            this.btnTeamStats = new System.Windows.Forms.Button();
            this.cmbStadium = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeams)).BeginInit();
            this.SuspendLayout();
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(102, 70);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(120, 22);
            this.txtname.TabIndex = 2;
            // 
            // txtfounded
            // 
            this.txtfounded.Location = new System.Drawing.Point(257, 70);
            this.txtfounded.Name = "txtfounded";
            this.txtfounded.Size = new System.Drawing.Size(120, 22);
            this.txtfounded.TabIndex = 1;
            // 
            // txtkitcolor
            // 
            this.txtkitcolor.Location = new System.Drawing.Point(411, 70);
            this.txtkitcolor.Name = "txtkitcolor";
            this.txtkitcolor.Size = new System.Drawing.Size(120, 22);
            this.txtkitcolor.TabIndex = 9;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(290, 15);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(180, 22);
            this.txtid.TabIndex = 8;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(10, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(547, 119);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 37);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(334, 119);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 37);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(121, 119);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 37);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridViewTeams
            // 
            this.dataGridViewTeams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTeams.Location = new System.Drawing.Point(11, 181);
            this.dataGridViewTeams.Name = "dataGridViewTeams";
            this.dataGridViewTeams.RowHeadersWidth = 51;
            this.dataGridViewTeams.Size = new System.Drawing.Size(629, 303);
            this.dataGridViewTeams.TabIndex = 3;
            this.dataGridViewTeams.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTeams_CellClick);
            // 
            // btnTeamStats
            // 
            this.btnTeamStats.Location = new System.Drawing.Point(655, 290);
            this.btnTeamStats.Name = "btnTeamStats";
            this.btnTeamStats.Size = new System.Drawing.Size(93, 62);
            this.btnTeamStats.TabIndex = 0;
            this.btnTeamStats.Text = "Stats";
            this.btnTeamStats.Click += new System.EventHandler(this.btnTeamStats_Click);
            // 
            // cmbStadium
            // 
            this.cmbStadium.FormattingEnabled = true;
            this.cmbStadium.Location = new System.Drawing.Point(565, 68);
            this.cmbStadium.Name = "cmbStadium";
            this.cmbStadium.Size = new System.Drawing.Size(120, 24);
            this.cmbStadium.TabIndex = 11;
            // 
            // TeamsForm
            // 
            this.ClientSize = new System.Drawing.Size(760, 496);
            this.Controls.Add(this.cmbStadium);
            this.Controls.Add(this.btnTeamStats);
            this.Controls.Add(this.txtfounded);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.dataGridViewTeams);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.txtkitcolor);
            this.Name = "TeamsForm";
            this.Text = "Teams";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtfounded;
        private System.Windows.Forms.TextBox txtkitcolor;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridViewTeams;
        private System.Windows.Forms.Button btnTeamStats;
        private System.Windows.Forms.ComboBox cmbStadium;
    }
}