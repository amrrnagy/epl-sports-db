using System.Windows.Forms;

namespace EPL_DBMS.Forms
{
    partial class MatchesForm
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
            this.dataGridViewMatches = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblattend = new System.Windows.Forms.Label();
            this.lblHomeGoals = new System.Windows.Forms.Label();
            this.lblAwayGoals = new System.Windows.Forms.Label();
            this.attend = new System.Windows.Forms.TextBox();
            this.Hgoals = new System.Windows.Forms.TextBox();
            this.Agoals = new System.Windows.Forms.TextBox();
            this.cmbReferee = new System.Windows.Forms.ComboBox();
            this.cmbStadium = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.matchid = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.VS = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.stadiumid = new System.Windows.Forms.Label();
            this.RefereeId = new System.Windows.Forms.Label();
            this.AwayID = new System.Windows.Forms.Label();
            this.HomeID = new System.Windows.Forms.Label();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.cmbAwayTeam = new System.Windows.Forms.ComboBox();
            this.cmbHomeTeam = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatches)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            // dataGridViewMatches
            this.dataGridViewMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatches.Location = new System.Drawing.Point(18, 247);
            this.dataGridViewMatches.MultiSelect = false;
            this.dataGridViewMatches.Name = "dataGridViewMatches";
            this.dataGridViewMatches.ReadOnly = true;
            this.dataGridViewMatches.RowHeadersWidth = 51;
            this.dataGridViewMatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMatches.Size = new System.Drawing.Size(1091, 340);
            this.dataGridViewMatches.TabIndex = 0;
            this.dataGridViewMatches.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMatches_CellClick);

            // panel1
            this.panel1.Controls.Add(this.lblattend);
            this.panel1.Controls.Add(this.lblHomeGoals);
            this.panel1.Controls.Add(this.lblAwayGoals);
            this.panel1.Controls.Add(this.attend);
            this.panel1.Controls.Add(this.Hgoals);
            this.panel1.Controls.Add(this.Agoals);
            this.panel1.Controls.Add(this.cmbReferee);
            this.panel1.Controls.Add(this.cmbStadium);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.matchid);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.VS);
            this.panel1.Controls.Add(this.date);
            this.panel1.Controls.Add(this.stadiumid);
            this.panel1.Controls.Add(this.RefereeId);
            this.panel1.Controls.Add(this.AwayID);
            this.panel1.Controls.Add(this.HomeID);
            this.panel1.Controls.Add(this.dateTime);
            this.panel1.Controls.Add(this.cmbAwayTeam);
            this.panel1.Controls.Add(this.cmbHomeTeam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1121, 241);
            this.panel1.TabIndex = 1;

            // lblattend
            this.lblattend.AutoSize = true;
            this.lblattend.Location = new System.Drawing.Point(967, 119);
            this.lblattend.Name = "lblattend";
            this.lblattend.Size = new System.Drawing.Size(78, 17);
            this.lblattend.Text = "Attendance";

            // lblHomeGoals
            this.lblHomeGoals.AutoSize = true;
            this.lblHomeGoals.Location = new System.Drawing.Point(713, 119);
            this.lblHomeGoals.Name = "lblHomeGoals";
            this.lblHomeGoals.Size = new System.Drawing.Size(80, 17);
            this.lblHomeGoals.Text = "Home Goals";

            // lblAwayGoals
            this.lblAwayGoals.AutoSize = true;
            this.lblAwayGoals.Location = new System.Drawing.Point(529, 119);
            this.lblAwayGoals.Name = "lblAwayGoals";
            this.lblAwayGoals.Size = new System.Drawing.Size(77, 17);
            this.lblAwayGoals.Text = "Away Goals";

            // attend
            this.attend.Location = new System.Drawing.Point(948, 139);
            this.attend.Name = "attend";
            this.attend.Size = new System.Drawing.Size(115, 24);

            // Hgoals
            this.Hgoals.Location = new System.Drawing.Point(681, 139);
            this.Hgoals.Name = "Hgoals";
            this.Hgoals.Size = new System.Drawing.Size(141, 24);

            // Agoals
            this.Agoals.Location = new System.Drawing.Point(495, 139);
            this.Agoals.Name = "Agoals";
            this.Agoals.Size = new System.Drawing.Size(141, 24);

            // cmbReferee
            this.cmbReferee.FormattingEnabled = true;
            this.cmbReferee.Location = new System.Drawing.Point(258, 139);
            this.cmbReferee.Name = "cmbReferee";
            this.cmbReferee.Size = new System.Drawing.Size(141, 24);

            // cmbStadium
            this.cmbStadium.FormattingEnabled = true;
            this.cmbStadium.Location = new System.Drawing.Point(69, 139);
            this.cmbStadium.Name = "cmbStadium";
            this.cmbStadium.Size = new System.Drawing.Size(129, 24);

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(707, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 29);
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // matchid
            this.matchid.Location = new System.Drawing.Point(437, 18);
            this.matchid.Name = "matchid";
            this.matchid.Size = new System.Drawing.Size(226, 28);

            // btnBack
            this.btnBack.Location = new System.Drawing.Point(21, 14);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(707, 182);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(115, 56);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(495, 182);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(137, 56);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(291, 182);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(139, 56);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // VS
            this.VS.AutoSize = true;
            this.VS.Location = new System.Drawing.Point(294, 77);
            this.VS.Name = "VS";
            this.VS.Size = new System.Drawing.Size(48, 34);
            this.VS.Text = "Vs";

            // date
            this.date.AutoSize = true;
            this.date.Location = new System.Drawing.Point(890, 59);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(46, 21);
            this.date.Text = "Date";

            // stadiumid
            this.stadiumid.AutoSize = true;
            this.stadiumid.Location = new System.Drawing.Point(99, 119);
            this.stadiumid.Name = "stadiumid";
            this.stadiumid.Size = new System.Drawing.Size(76, 17);
            this.stadiumid.Text = "Stadium";

            // RefereeId
            this.RefereeId.AutoSize = true;
            this.RefereeId.Location = new System.Drawing.Point(297, 119);
            this.RefereeId.Name = "RefereeId";
            this.RefereeId.Size = new System.Drawing.Size(70, 17);
            this.RefereeId.Text = "Referee";

            // AwayID
            this.AwayID.AutoSize = true;
            this.AwayID.Location = new System.Drawing.Point(444, 63);
            this.AwayID.Name = "AwayID";
            this.AwayID.Size = new System.Drawing.Size(97, 17);
            this.AwayID.Text = "Away Team";

            // HomeID
            this.HomeID.AutoSize = true;
            this.HomeID.Location = new System.Drawing.Point(125, 62);
            this.HomeID.Name = "HomeID";
            this.HomeID.Size = new System.Drawing.Size(100, 17);
            this.HomeID.Text = "Home Team";

            // dateTime
            this.dateTime.Location = new System.Drawing.Point(789, 85);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(241, 24);

            // cmbAwayTeam
            this.cmbAwayTeam.FormattingEnabled = true;
            this.cmbAwayTeam.Location = new System.Drawing.Point(428, 82);
            this.cmbAwayTeam.Name = "cmbAwayTeam";
            this.cmbAwayTeam.Size = new System.Drawing.Size(143, 24);

            // cmbHomeTeam
            this.cmbHomeTeam.FormattingEnabled = true;
            this.cmbHomeTeam.Location = new System.Drawing.Point(113, 82);
            this.cmbHomeTeam.Name = "cmbHomeTeam";
            this.cmbHomeTeam.Size = new System.Drawing.Size(129, 24);

            // MatchesForm
            this.ClientSize = new System.Drawing.Size(1121, 599);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewMatches);
            this.Name = "MatchesForm";
            this.Text = "Matches";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatches)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMatches;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.ComboBox cmbAwayTeam;
        private System.Windows.Forms.ComboBox cmbHomeTeam;
        private System.Windows.Forms.Label AwayID;
        private System.Windows.Forms.Label HomeID;
        private System.Windows.Forms.Label stadiumid;
        private System.Windows.Forms.Label RefereeId;
        private System.Windows.Forms.Label VS;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox matchid;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbReferee;
        private System.Windows.Forms.ComboBox cmbStadium;
        private System.Windows.Forms.TextBox attend;
        private System.Windows.Forms.TextBox Hgoals;
        private System.Windows.Forms.TextBox Agoals;
        private System.Windows.Forms.Label lblattend;
        private System.Windows.Forms.Label lblHomeGoals;
        private System.Windows.Forms.Label lblAwayGoals;
    }
}