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
            this.referee = new System.Windows.Forms.TextBox();
            this.stadium = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.matchid = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
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
            // 
            // dataGridViewMatches
            // 
            this.dataGridViewMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatches.Location = new System.Drawing.Point(18, 247);
            this.dataGridViewMatches.MultiSelect = false;
            this.dataGridViewMatches.Name = "dataGridViewMatches";
            this.dataGridViewMatches.ReadOnly = true;
            this.dataGridViewMatches.RowHeadersWidth = 51;
            this.dataGridViewMatches.RowTemplate.Height = 24;
            this.dataGridViewMatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMatches.Size = new System.Drawing.Size(1091, 340);
            this.dataGridViewMatches.TabIndex = 0;
            this.dataGridViewMatches.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMatches_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblattend);
            this.panel1.Controls.Add(this.lblHomeGoals);
            this.panel1.Controls.Add(this.lblAwayGoals);
            this.panel1.Controls.Add(this.attend);
            this.panel1.Controls.Add(this.Hgoals);
            this.panel1.Controls.Add(this.Agoals);
            this.panel1.Controls.Add(this.referee);
            this.panel1.Controls.Add(this.stadium);
            this.panel1.Controls.Add(this.search);
            this.panel1.Controls.Add(this.matchid);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.Delete);
            this.panel1.Controls.Add(this.update);
            this.panel1.Controls.Add(this.add);
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
            // 
            // lblattend
            // 
            this.lblattend.AutoSize = true;
            this.lblattend.Location = new System.Drawing.Point(967, 119);
            this.lblattend.Name = "lblattend";
            this.lblattend.Size = new System.Drawing.Size(78, 17);
            this.lblattend.TabIndex = 33;
            this.lblattend.Text = "Attendance";
            // 
            // lblHomeGoals
            // 
            this.lblHomeGoals.AutoSize = true;
            this.lblHomeGoals.Location = new System.Drawing.Point(713, 119);
            this.lblHomeGoals.Name = "lblHomeGoals";
            this.lblHomeGoals.Size = new System.Drawing.Size(80, 17);
            this.lblHomeGoals.TabIndex = 32;
            this.lblHomeGoals.Text = "Home Goals";
            // 
            // lblAwayGoals
            // 
            this.lblAwayGoals.AutoSize = true;
            this.lblAwayGoals.Location = new System.Drawing.Point(529, 119);
            this.lblAwayGoals.Name = "lblAwayGoals";
            this.lblAwayGoals.Size = new System.Drawing.Size(77, 17);
            this.lblAwayGoals.TabIndex = 31;
            this.lblAwayGoals.Text = "Away Goals";
            // 
            // attend
            // 
            this.attend.Location = new System.Drawing.Point(948, 139);
            this.attend.Name = "attend";
            this.attend.Size = new System.Drawing.Size(115, 24);
            this.attend.TabIndex = 34;
            // 
            // Hgoals
            // 
            this.Hgoals.Location = new System.Drawing.Point(681, 139);
            this.Hgoals.Name = "Hgoals";
            this.Hgoals.Size = new System.Drawing.Size(141, 24);
            this.Hgoals.TabIndex = 29;
            // 
            // Agoals
            // 
            this.Agoals.Location = new System.Drawing.Point(495, 139);
            this.Agoals.Name = "Agoals";
            this.Agoals.Size = new System.Drawing.Size(141, 24);
            this.Agoals.TabIndex = 28;
            this.Agoals.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // referee
            // 
            this.referee.Location = new System.Drawing.Point(258, 139);
            this.referee.Name = "referee";
            this.referee.Size = new System.Drawing.Size(141, 24);
            this.referee.TabIndex = 26;
            this.referee.TextChanged += new System.EventHandler(this.referee_TextChanged);
            // 
            // stadium
            // 
            this.stadium.Location = new System.Drawing.Point(69, 139);
            this.stadium.Name = "stadium";
            this.stadium.Size = new System.Drawing.Size(129, 24);
            this.stadium.TabIndex = 25;
            // 
            // search
            // 
            this.search.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.search.Location = new System.Drawing.Point(707, 18);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(76, 29);
            this.search.TabIndex = 24;
            this.search.Text = "Search";
            this.search.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // matchid
            // 
            this.matchid.BackColor = System.Drawing.SystemColors.Info;
            this.matchid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.matchid.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchid.Location = new System.Drawing.Point(437, 18);
            this.matchid.Multiline = true;
            this.matchid.Name = "matchid";
            this.matchid.Size = new System.Drawing.Size(226, 28);
            this.matchid.TabIndex = 23;
            this.matchid.Text = "ENTER MATCH ID";
            this.matchid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(21, 14);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.TabIndex = 22;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(707, 182);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(115, 56);
            this.Delete.TabIndex = 21;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(495, 182);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(137, 56);
            this.update.TabIndex = 20;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(291, 182);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(139, 56);
            this.add.TabIndex = 19;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // VS
            // 
            this.VS.AutoSize = true;
            this.VS.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VS.Location = new System.Drawing.Point(294, 77);
            this.VS.Name = "VS";
            this.VS.Size = new System.Drawing.Size(48, 34);
            this.VS.TabIndex = 18;
            this.VS.Text = "Vs";
            this.VS.Click += new System.EventHandler(this.label1_Click);
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Location = new System.Drawing.Point(890, 59);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(46, 21);
            this.date.TabIndex = 17;
            this.date.Text = "Date";
            this.date.Click += new System.EventHandler(this.date_Click);
            // 
            // stadiumid
            // 
            this.stadiumid.AutoSize = true;
            this.stadiumid.Location = new System.Drawing.Point(99, 119);
            this.stadiumid.Name = "stadiumid";
            this.stadiumid.Size = new System.Drawing.Size(76, 17);
            this.stadiumid.TabIndex = 16;
            this.stadiumid.Text = "Stadium ID";
            // 
            // RefereeId
            // 
            this.RefereeId.AutoSize = true;
            this.RefereeId.Location = new System.Drawing.Point(297, 119);
            this.RefereeId.Name = "RefereeId";
            this.RefereeId.Size = new System.Drawing.Size(70, 17);
            this.RefereeId.TabIndex = 15;
            this.RefereeId.Text = "Referee Id";
            // 
            // AwayID
            // 
            this.AwayID.AutoSize = true;
            this.AwayID.Location = new System.Drawing.Point(444, 63);
            this.AwayID.Name = "AwayID";
            this.AwayID.Size = new System.Drawing.Size(97, 17);
            this.AwayID.TabIndex = 4;
            this.AwayID.Text = "Away Team ID";
            // 
            // HomeID
            // 
            this.HomeID.AutoSize = true;
            this.HomeID.Location = new System.Drawing.Point(125, 62);
            this.HomeID.Name = "HomeID";
            this.HomeID.Size = new System.Drawing.Size(100, 17);
            this.HomeID.TabIndex = 3;
            this.HomeID.Text = "Home Team ID";
            // 
            // dateTime
            // 
            this.dateTime.Location = new System.Drawing.Point(789, 85);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(241, 24);
            this.dateTime.TabIndex = 2;
            this.dateTime.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // cmbAwayTeam
            // 
            this.cmbAwayTeam.FormattingEnabled = true;
            this.cmbAwayTeam.Location = new System.Drawing.Point(428, 82);
            this.cmbAwayTeam.Name = "cmbAwayTeam";
            this.cmbAwayTeam.Size = new System.Drawing.Size(143, 24);
            this.cmbAwayTeam.TabIndex = 1;
            // 
            // cmbHomeTeam
            // 
            this.cmbHomeTeam.FormattingEnabled = true;
            this.cmbHomeTeam.Location = new System.Drawing.Point(113, 82);
            this.cmbHomeTeam.Name = "cmbHomeTeam";
            this.cmbHomeTeam.Size = new System.Drawing.Size(129, 24);
            this.cmbHomeTeam.TabIndex = 0;
            // 
            // MatchesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox matchid;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox referee;
        private System.Windows.Forms.TextBox stadium;
        private System.Windows.Forms.TextBox attend;
        private System.Windows.Forms.TextBox Hgoals;
        private System.Windows.Forms.TextBox Agoals;
        private System.Windows.Forms.Label lblattend;
        private System.Windows.Forms.Label lblHomeGoals;
        private System.Windows.Forms.Label lblAwayGoals;
    }
}
