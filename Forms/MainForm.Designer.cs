using EPL_DBMS.DataAccess;

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
            this.btnTeams = new System.Windows.Forms.Button();
            this.btnPlayers = new System.Windows.Forms.Button();
            this.btnStadiums = new System.Windows.Forms.Button();
            this.btnReferees = new System.Windows.Forms.Button();
            this.btnManagers = new System.Windows.Forms.Button();
            this.btnMatches = new System.Windows.Forms.Button();
            this.btnPlayerInjuries = new System.Windows.Forms.Button();
            this.btnTeamStats = new System.Windows.Forms.Button();
            this.btnPlayerStats = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPlayersCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTeamsCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblMatchesCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTeams
            // 
            this.btnTeams.Location = new System.Drawing.Point(243, 208);
            this.btnTeams.Name = "btnTeams";
            this.btnTeams.Size = new System.Drawing.Size(158, 46);
            this.btnTeams.TabIndex = 0;
            this.btnTeams.Text = "Teams";
            this.btnTeams.UseVisualStyleBackColor = true;
            this.btnTeams.Click += new System.EventHandler(this.btnTeams_Click);
            // 
            // btnPlayers
            // 
            this.btnPlayers.Location = new System.Drawing.Point(52, 208);
            this.btnPlayers.Name = "btnPlayers";
            this.btnPlayers.Size = new System.Drawing.Size(158, 46);
            this.btnPlayers.TabIndex = 1;
            this.btnPlayers.Text = "Players";
            this.btnPlayers.UseVisualStyleBackColor = true;
            this.btnPlayers.Click += new System.EventHandler(this.btnPlayers_Click);
            // 
            // btnStadiums
            // 
            this.btnStadiums.Location = new System.Drawing.Point(243, 342);
            this.btnStadiums.Name = "btnStadiums";
            this.btnStadiums.Size = new System.Drawing.Size(158, 46);
            this.btnStadiums.TabIndex = 2;
            this.btnStadiums.Text = "Stadiums";
            this.btnStadiums.UseVisualStyleBackColor = true;
            this.btnStadiums.Click += new System.EventHandler(this.btnStadiums_Click);
            // 
            // btnReferees
            // 
            this.btnReferees.Location = new System.Drawing.Point(437, 342);
            this.btnReferees.Name = "btnReferees";
            this.btnReferees.Size = new System.Drawing.Size(158, 46);
            this.btnReferees.TabIndex = 3;
            this.btnReferees.Text = "Referees";
            this.btnReferees.UseVisualStyleBackColor = true;
            this.btnReferees.Click += new System.EventHandler(this.btnReferees_Click);
            // 
            // btnManagers
            // 
            this.btnManagers.Location = new System.Drawing.Point(52, 342);
            this.btnManagers.Name = "btnManagers";
            this.btnManagers.Size = new System.Drawing.Size(158, 46);
            this.btnManagers.TabIndex = 4;
            this.btnManagers.Text = "Managers";
            this.btnManagers.UseVisualStyleBackColor = true;
            this.btnManagers.Click += new System.EventHandler(this.btnManagers_Click);
            // 
            // btnMatches
            // 
            this.btnMatches.Location = new System.Drawing.Point(437, 208);
            this.btnMatches.Name = "btnMatches";
            this.btnMatches.Size = new System.Drawing.Size(158, 46);
            this.btnMatches.TabIndex = 6;
            this.btnMatches.Text = "Matches";
            this.btnMatches.UseVisualStyleBackColor = true;
            this.btnMatches.Click += new System.EventHandler(this.btnMatches_Click);
            // 
            // btnPlayerInjuries
            // 
            this.btnPlayerInjuries.Location = new System.Drawing.Point(52, 474);
            this.btnPlayerInjuries.Name = "btnPlayerInjuries";
            this.btnPlayerInjuries.Size = new System.Drawing.Size(158, 46);
            this.btnPlayerInjuries.TabIndex = 9;
            this.btnPlayerInjuries.Text = "Player Injuries";
            this.btnPlayerInjuries.UseVisualStyleBackColor = true;
            this.btnPlayerInjuries.Click += new System.EventHandler(this.btnPlayerInjuries_Click);
            // 
            // btnTeamStats
            // 
            this.btnTeamStats.Location = new System.Drawing.Point(437, 474);
            this.btnTeamStats.Name = "btnTeamStats";
            this.btnTeamStats.Size = new System.Drawing.Size(158, 46);
            this.btnTeamStats.TabIndex = 7;
            this.btnTeamStats.Text = "Team Stats";
            this.btnTeamStats.UseVisualStyleBackColor = true;
            this.btnTeamStats.Click += new System.EventHandler(this.btnTeamStats_Click);
            // 
            // btnPlayerStats
            // 
            this.btnPlayerStats.Location = new System.Drawing.Point(243, 474);
            this.btnPlayerStats.Name = "btnPlayerStats";
            this.btnPlayerStats.Size = new System.Drawing.Size(158, 46);
            this.btnPlayerStats.TabIndex = 8;
            this.btnPlayerStats.Text = "Player Stats";
            this.btnPlayerStats.UseVisualStyleBackColor = true;
            this.btnPlayerStats.Click += new System.EventHandler(this.btnPlayerStats_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label2.Location = new System.Drawing.Point(-2, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(633, 46);
            this.label2.TabIndex = 12;
            this.label2.Text = "Statistics";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Location = new System.Drawing.Point(-2, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(633, 46);
            this.label1.TabIndex = 13;
            this.label1.Text = "Managment";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label3.Location = new System.Drawing.Point(-2, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(633, 46);
            this.label3.TabIndex = 14;
            this.label3.Text = "Main Entities";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblPlayersCount);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(52, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 100);
            this.panel1.TabIndex = 15;
            // 
            // lblPlayersCount
            // 
            this.lblPlayersCount.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayersCount.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPlayersCount.Location = new System.Drawing.Point(-18, 21);
            this.lblPlayersCount.Name = "lblPlayersCount";
            this.lblPlayersCount.Size = new System.Drawing.Size(191, 36);
            this.lblPlayersCount.TabIndex = 1;
            this.lblPlayersCount.Text = "0";
            this.lblPlayersCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label4.Location = new System.Drawing.Point(45, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "PLAYERS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblTeamsCount);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(243, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(158, 100);
            this.panel2.TabIndex = 16;
            // 
            // lblTeamsCount
            // 
            this.lblTeamsCount.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamsCount.Location = new System.Drawing.Point(-27, 21);
            this.lblTeamsCount.Name = "lblTeamsCount";
            this.lblTeamsCount.Size = new System.Drawing.Size(219, 36);
            this.lblTeamsCount.TabIndex = 2;
            this.lblTeamsCount.Text = "0";
            this.lblTeamsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTeamsCount.Click += new System.EventHandler(this.lblTeamsCount_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "TEAMS";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Info;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblMatchesCount);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(437, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(158, 100);
            this.panel3.TabIndex = 17;
            // 
            // lblMatchesCount
            // 
            this.lblMatchesCount.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatchesCount.Location = new System.Drawing.Point(-40, 21);
            this.lblMatchesCount.Name = "lblMatchesCount";
            this.lblMatchesCount.Size = new System.Drawing.Size(240, 36);
            this.lblMatchesCount.TabIndex = 2;
            this.lblMatchesCount.Text = "0";
            this.lblMatchesCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMatchesCount.Click += new System.EventHandler(this.lblMatchesCount_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "MATCHES";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(243, 476);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 46);
            this.button1.TabIndex = 18;
            this.button1.Text = "Player Injuries";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(437, 476);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 46);
            this.button2.TabIndex = 19;
            this.button2.Text = "Team Stats";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(52, 476);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 46);
            this.button3.TabIndex = 20;
            this.button3.Text = "Player Stats";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 545);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTeams);
            this.Controls.Add(this.btnPlayers);
            this.Controls.Add(this.btnStadiums);
            this.Controls.Add(this.btnReferees);
            this.Controls.Add(this.btnManagers);
            this.Controls.Add(this.btnMatches);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EPL Database Management System";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btnTeams;
        private System.Windows.Forms.Button btnPlayers;
        private System.Windows.Forms.Button btnStadiums;
        private System.Windows.Forms.Button btnReferees;
        private System.Windows.Forms.Button btnManagers;
        private System.Windows.Forms.Button btnMatches;
        private System.Windows.Forms.Button btnPlayerInjuries;
        private System.Windows.Forms.Button btnTeamStats;
        private System.Windows.Forms.Button btnPlayerStats;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPlayersCount;
        private System.Windows.Forms.Label lblTeamsCount;
        private System.Windows.Forms.Label lblMatchesCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
