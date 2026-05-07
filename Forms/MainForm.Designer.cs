namespace EPL_DBMS.Forms
{
    partial class MainForm
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
            this.btnStadiums = new System.Windows.Forms.Button();
            this.btnReferees = new System.Windows.Forms.Button();
            this.btnManagers = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelPlayers = new System.Windows.Forms.Panel();
            this.lblPlayersCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelTeams = new System.Windows.Forms.Panel();
            this.lblTeamsCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelMatches = new System.Windows.Forms.Panel();
            this.lblMatchesCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnInjuryReport = new System.Windows.Forms.Button();
            this.btnStandings = new System.Windows.Forms.Button();
            this.btnTopPerformers = new System.Windows.Forms.Button();
            this.panelPlayers.SuspendLayout();
            this.panelTeams.SuspendLayout();
            this.panelMatches.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStadiums
            // 
            this.btnStadiums.Location = new System.Drawing.Point(285, 213);
            this.btnStadiums.Name = "btnStadiums";
            this.btnStadiums.Size = new System.Drawing.Size(181, 46);
            this.btnStadiums.TabIndex = 2;
            this.btnStadiums.Text = "Stadiums";
            this.btnStadiums.UseVisualStyleBackColor = true;
            this.btnStadiums.Click += new System.EventHandler(this.btnStadiums_Click);
            // 
            // btnReferees
            // 
            this.btnReferees.Location = new System.Drawing.Point(506, 213);
            this.btnReferees.Name = "btnReferees";
            this.btnReferees.Size = new System.Drawing.Size(181, 46);
            this.btnReferees.TabIndex = 3;
            this.btnReferees.Text = "Referees";
            this.btnReferees.UseVisualStyleBackColor = true;
            this.btnReferees.Click += new System.EventHandler(this.btnReferees_Click);
            // 
            // btnManagers
            // 
            this.btnManagers.Location = new System.Drawing.Point(66, 213);
            this.btnManagers.Name = "btnManagers";
            this.btnManagers.Size = new System.Drawing.Size(181, 46);
            this.btnManagers.TabIndex = 4;
            this.btnManagers.Text = "Managers";
            this.btnManagers.UseVisualStyleBackColor = true;
            this.btnManagers.Click += new System.EventHandler(this.btnManagers_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label2.Location = new System.Drawing.Point(5, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(723, 46);
            this.label2.TabIndex = 12;
            this.label2.Text = "Statistics";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Location = new System.Drawing.Point(5, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(723, 46);
            this.label1.TabIndex = 13;
            this.label1.Text = "Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPlayers
            // 
            this.panelPlayers.BackColor = System.Drawing.SystemColors.Info;
            this.panelPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlayers.Controls.Add(this.lblPlayersCount);
            this.panelPlayers.Controls.Add(this.label4);
            this.panelPlayers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelPlayers.Location = new System.Drawing.Point(59, 23);
            this.panelPlayers.Name = "panelPlayers";
            this.panelPlayers.Size = new System.Drawing.Size(180, 100);
            this.panelPlayers.TabIndex = 15;
            this.panelPlayers.Click += new System.EventHandler(this.panelPlayers_Click);
            // 
            // lblPlayersCount
            // 
            this.lblPlayersCount.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayersCount.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPlayersCount.Location = new System.Drawing.Point(-21, 21);
            this.lblPlayersCount.Name = "lblPlayersCount";
            this.lblPlayersCount.Size = new System.Drawing.Size(218, 36);
            this.lblPlayersCount.TabIndex = 1;
            this.lblPlayersCount.Text = "0";
            this.lblPlayersCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlayersCount.Click += new System.EventHandler(this.panelPlayers_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label4.Location = new System.Drawing.Point(60, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "PLAYERS";
            this.label4.Click += new System.EventHandler(this.panelPlayers_Click);
            // 
            // panelTeams
            // 
            this.panelTeams.BackColor = System.Drawing.SystemColors.Info;
            this.panelTeams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTeams.Controls.Add(this.lblTeamsCount);
            this.panelTeams.Controls.Add(this.label5);
            this.panelTeams.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelTeams.Location = new System.Drawing.Point(278, 23);
            this.panelTeams.Name = "panelTeams";
            this.panelTeams.Size = new System.Drawing.Size(180, 100);
            this.panelTeams.TabIndex = 16;
            this.panelTeams.Click += new System.EventHandler(this.panelTeams_Click);
            // 
            // lblTeamsCount
            // 
            this.lblTeamsCount.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamsCount.Location = new System.Drawing.Point(-31, 21);
            this.lblTeamsCount.Name = "lblTeamsCount";
            this.lblTeamsCount.Size = new System.Drawing.Size(250, 36);
            this.lblTeamsCount.TabIndex = 2;
            this.lblTeamsCount.Text = "0";
            this.lblTeamsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTeamsCount.Click += new System.EventHandler(this.panelTeams_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "TEAMS";
            this.label5.Click += new System.EventHandler(this.panelTeams_Click);
            // 
            // panelMatches
            // 
            this.panelMatches.BackColor = System.Drawing.SystemColors.Info;
            this.panelMatches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMatches.Controls.Add(this.lblMatchesCount);
            this.panelMatches.Controls.Add(this.label6);
            this.panelMatches.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelMatches.Location = new System.Drawing.Point(499, 23);
            this.panelMatches.Name = "panelMatches";
            this.panelMatches.Size = new System.Drawing.Size(180, 100);
            this.panelMatches.TabIndex = 17;
            this.panelMatches.Click += new System.EventHandler(this.panelMatches_Click);
            // 
            // lblMatchesCount
            // 
            this.lblMatchesCount.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatchesCount.Location = new System.Drawing.Point(-46, 21);
            this.lblMatchesCount.Name = "lblMatchesCount";
            this.lblMatchesCount.Size = new System.Drawing.Size(274, 36);
            this.lblMatchesCount.TabIndex = 2;
            this.lblMatchesCount.Text = "0";
            this.lblMatchesCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMatchesCount.Click += new System.EventHandler(this.panelMatches_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "MATCHES";
            this.label6.Click += new System.EventHandler(this.panelMatches_Click);
            // 
            // btnInjuryReport
            // 
            this.btnInjuryReport.Location = new System.Drawing.Point(285, 347);
            this.btnInjuryReport.Name = "btnInjuryReport";
            this.btnInjuryReport.Size = new System.Drawing.Size(181, 46);
            this.btnInjuryReport.TabIndex = 18;
            this.btnInjuryReport.Text = "League Injury Report";
            this.btnInjuryReport.UseVisualStyleBackColor = true;
            this.btnInjuryReport.Click += new System.EventHandler(this.btnInjuryReport_Click);
            // 
            // btnStandings
            // 
            this.btnStandings.Location = new System.Drawing.Point(506, 347);
            this.btnStandings.Name = "btnStandings";
            this.btnStandings.Size = new System.Drawing.Size(181, 46);
            this.btnStandings.TabIndex = 19;
            this.btnStandings.Text = "Standings";
            this.btnStandings.UseVisualStyleBackColor = true;
            this.btnStandings.Click += new System.EventHandler(this.btnStandings_Click);
            // 
            // btnTopPerformers
            // 
            this.btnTopPerformers.Location = new System.Drawing.Point(66, 347);
            this.btnTopPerformers.Name = "btnTopPerformers";
            this.btnTopPerformers.Size = new System.Drawing.Size(181, 46);
            this.btnTopPerformers.TabIndex = 20;
            this.btnTopPerformers.Text = "Top Performers";
            this.btnTopPerformers.UseVisualStyleBackColor = true;
            this.btnTopPerformers.Click += new System.EventHandler(this.btnTopPerformers_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 407);
            this.Controls.Add(this.btnTopPerformers);
            this.Controls.Add(this.btnStandings);
            this.Controls.Add(this.btnInjuryReport);
            this.Controls.Add(this.panelMatches);
            this.Controls.Add(this.panelTeams);
            this.Controls.Add(this.panelPlayers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStadiums);
            this.Controls.Add(this.btnReferees);
            this.Controls.Add(this.btnManagers);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EPL Database Management System";
            this.panelPlayers.ResumeLayout(false);
            this.panelPlayers.PerformLayout();
            this.panelTeams.ResumeLayout(false);
            this.panelTeams.PerformLayout();
            this.panelMatches.ResumeLayout(false);
            this.panelMatches.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Button btnStadiums;
        private System.Windows.Forms.Button btnReferees;
        private System.Windows.Forms.Button btnManagers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelPlayers;
        private System.Windows.Forms.Panel panelTeams;
        private System.Windows.Forms.Panel panelMatches;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPlayersCount;
        private System.Windows.Forms.Label lblTeamsCount;
        private System.Windows.Forms.Label lblMatchesCount;
        private System.Windows.Forms.Button btnInjuryReport;
        private System.Windows.Forms.Button btnStandings;
        private System.Windows.Forms.Button btnTopPerformers;
    }
}