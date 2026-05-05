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
            this.SuspendLayout();
            // 
            // btnTeams
            // 
            this.btnTeams.Location = new System.Drawing.Point(60, 100);
            this.btnTeams.Name = "btnTeams";
            this.btnTeams.Size = new System.Drawing.Size(180, 46);
            this.btnTeams.TabIndex = 0;
            this.btnTeams.Text = "Teams";
            this.btnTeams.UseVisualStyleBackColor = true;
            this.btnTeams.Click += new System.EventHandler(this.btnTeams_Click);
            // 
            // btnPlayers
            // 
            this.btnPlayers.Location = new System.Drawing.Point(300, 100);
            this.btnPlayers.Name = "btnPlayers";
            this.btnPlayers.Size = new System.Drawing.Size(180, 46);
            this.btnPlayers.TabIndex = 1;
            this.btnPlayers.Text = "Players";
            this.btnPlayers.UseVisualStyleBackColor = true;
            this.btnPlayers.Click += new System.EventHandler(this.btnPlayers_Click);
            // 
            // btnStadiums
            // 
            this.btnStadiums.Location = new System.Drawing.Point(60, 350);
            this.btnStadiums.Name = "btnStadiums";
            this.btnStadiums.Size = new System.Drawing.Size(180, 46);
            this.btnStadiums.TabIndex = 2;
            this.btnStadiums.Text = "Stadiums";
            this.btnStadiums.UseVisualStyleBackColor = true;
            this.btnStadiums.Click += new System.EventHandler(this.btnStadiums_Click);
            // 
            // btnReferees
            // 
            this.btnReferees.Location = new System.Drawing.Point(300, 350);
            this.btnReferees.Name = "btnReferees";
            this.btnReferees.Size = new System.Drawing.Size(180, 46);
            this.btnReferees.TabIndex = 3;
            this.btnReferees.Text = "Referees";
            this.btnReferees.UseVisualStyleBackColor = true;
            this.btnReferees.Click += new System.EventHandler(this.btnReferees_Click);
            // 
            // btnManagers
            // 
            this.btnManagers.Location = new System.Drawing.Point(60, 162);
            this.btnManagers.Name = "btnManagers";
            this.btnManagers.Size = new System.Drawing.Size(180, 46);
            this.btnManagers.TabIndex = 4;
            this.btnManagers.Text = "Managers";
            this.btnManagers.UseVisualStyleBackColor = true;
            this.btnManagers.Click += new System.EventHandler(this.btnManagers_Click);
            // 
            // btnMatches
            // 
            this.btnMatches.Location = new System.Drawing.Point(60, 223);
            this.btnMatches.Name = "btnMatches";
            this.btnMatches.Size = new System.Drawing.Size(180, 46);
            this.btnMatches.TabIndex = 6;
            this.btnMatches.Text = "Matches";
            this.btnMatches.UseVisualStyleBackColor = true;
            this.btnMatches.Click += new System.EventHandler(this.btnMatches_Click);
            // 
            // btnPlayerInjuries
            // 
            this.btnPlayerInjuries.Location = new System.Drawing.Point(300, 285);
            this.btnPlayerInjuries.Name = "btnPlayerInjuries";
            this.btnPlayerInjuries.Size = new System.Drawing.Size(180, 46);
            this.btnPlayerInjuries.TabIndex = 9;
            this.btnPlayerInjuries.Text = "Player Injuries";
            this.btnPlayerInjuries.UseVisualStyleBackColor = true;
            this.btnPlayerInjuries.Click += new System.EventHandler(this.btnPlayerInjuries_Click);
            // 
            // btnTeamStats
            // 
            this.btnTeamStats.Location = new System.Drawing.Point(300, 223);
            this.btnTeamStats.Name = "btnTeamStats";
            this.btnTeamStats.Size = new System.Drawing.Size(180, 46);
            this.btnTeamStats.TabIndex = 7;
            this.btnTeamStats.Text = "Team Stats";
            this.btnTeamStats.UseVisualStyleBackColor = true;
            this.btnTeamStats.Click += new System.EventHandler(this.btnTeamStats_Click);
            // 
            // btnPlayerStats
            // 
            this.btnPlayerStats.Location = new System.Drawing.Point(60, 285);
            this.btnPlayerStats.Name = "btnPlayerStats";
            this.btnPlayerStats.Size = new System.Drawing.Size(180, 46);
            this.btnPlayerStats.TabIndex = 8;
            this.btnPlayerStats.Text = "Player Stats";
            this.btnPlayerStats.UseVisualStyleBackColor = true;
            this.btnPlayerStats.Click += new System.EventHandler(this.btnPlayerStats_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 442);
            this.Controls.Add(this.btnTeams);
            this.Controls.Add(this.btnPlayers);
            this.Controls.Add(this.btnStadiums);
            this.Controls.Add(this.btnReferees);
            this.Controls.Add(this.btnManagers);
            this.Controls.Add(this.btnMatches);
            this.Controls.Add(this.btnTeamStats);
            this.Controls.Add(this.btnPlayerStats);
            this.Controls.Add(this.btnPlayerInjuries);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EPL Database Management System";
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
    }
}
