using System.Windows.Forms;

namespace EPL_DBMS.Forms
{
    partial class PlayersForm
    {
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtage;
        private System.Windows.Forms.TextBox txtnationality;
        private System.Windows.Forms.ComboBox cmbTeam;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;

        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dataGridViewPlayers;
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.btnBack = new System.Windows.Forms.Button();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtage = new System.Windows.Forms.TextBox();
            this.txtnationality = new System.Windows.Forms.TextBox();
            this.cmbTeam = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridViewPlayers = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPlayerInjuries = new System.Windows.Forms.Button();
            this.btnPlayerStats = new System.Windows.Forms.Button();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(263, 17);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(180, 22);
            this.txtid.TabIndex = 4;
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(58, 78);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(139, 22);
            this.txtname.TabIndex = 5;
            // 
            // txtage
            // 
            this.txtage.Location = new System.Drawing.Point(379, 78);
            this.txtage.Name = "txtage";
            this.txtage.Size = new System.Drawing.Size(80, 22);
            this.txtage.TabIndex = 7;
            // 
            // txtnationality
            // 
            this.txtnationality.Location = new System.Drawing.Point(481, 78);
            this.txtnationality.Name = "txtnationality";
            this.txtnationality.Size = new System.Drawing.Size(109, 22);
            this.txtnationality.TabIndex = 8;
            // 
            // cmbTeam
            // 
            this.cmbTeam.FormattingEnabled = true;
            this.cmbTeam.Location = new System.Drawing.Point(621, 78);
            this.cmbTeam.Name = "cmbTeam";
            this.cmbTeam.Size = new System.Drawing.Size(145, 24);
            this.cmbTeam.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(203, 114);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 37);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(340, 114);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 37);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(481, 114);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 37);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridViewPlayers
            // 
            this.dataGridViewPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPlayers.Location = new System.Drawing.Point(20, 179);
            this.dataGridViewPlayers.Name = "dataGridViewPlayers";
            this.dataGridViewPlayers.RowHeadersWidth = 51;
            this.dataGridViewPlayers.Size = new System.Drawing.Size(579, 310);
            this.dataGridViewPlayers.TabIndex = 13;
            this.dataGridViewPlayers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPlayers_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(473, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 29);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPlayerInjuries
            // 
            this.btnPlayerInjuries.Location = new System.Drawing.Point(646, 338);
            this.btnPlayerInjuries.Name = "btnPlayerInjuries";
            this.btnPlayerInjuries.Size = new System.Drawing.Size(93, 62);
            this.btnPlayerInjuries.TabIndex = 1;
            this.btnPlayerInjuries.Text = "Injuries";
            this.btnPlayerInjuries.Click += new System.EventHandler(this.btnPlayerInjuries_Click);
            // 
            // btnPlayerStats
            // 
            this.btnPlayerStats.Location = new System.Drawing.Point(646, 269);
            this.btnPlayerStats.Name = "btnPlayerStats";
            this.btnPlayerStats.Size = new System.Drawing.Size(93, 62);
            this.btnPlayerStats.TabIndex = 0;
            this.btnPlayerStats.Text = "Stats";
            this.btnPlayerStats.Click += new System.EventHandler(this.btnPlayerStats_Click);
            // 
            // cmbPosition
            // 
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(230, 76);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(120, 24);
            this.cmbPosition.TabIndex = 14;
            // 
            // PlayersForm
            // 
            this.ClientSize = new System.Drawing.Size(775, 510);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.btnPlayerStats);
            this.Controls.Add(this.btnPlayerInjuries);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.txtage);
            this.Controls.Add(this.txtnationality);
            this.Controls.Add(this.cmbTeam);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridViewPlayers);
            this.Name = "PlayersForm";
            this.Text = "Players";
            this.Load += new System.EventHandler(this.PlayersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnPlayerInjuries;
        private Button btnPlayerStats;
        private ComboBox cmbPosition;
    }
}