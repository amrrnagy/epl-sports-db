using System;
using System.Windows.Forms;
using EPL_DBMS.DataAccess;

namespace EPL_DBMS.Forms
{
    public partial class TeamStatsForm : Form
    {
        private readonly int? _teamId;

        // 1. GLOBAL CONSTRUCTOR (Called from Main Form)
        public TeamStatsForm()
        {
            InitializeComponent();
            _teamId = null;
            this.Text = "League Team Statistics";
            this.Load += Form_Load;
        }

        // 2. SPECIFIC CONSTRUCTOR (Called from Teams Form)
        public TeamStatsForm(int teamId, string teamName)
        {
            InitializeComponent();
            _teamId = teamId;
            this.Text = $"{teamName} - Season Statistics";
            this.Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                var dgv = dataGridViewTeamStats;

                if (_teamId.HasValue)
                {
                    // SPECIFIC TEAM (Shows the individual match logs)
                    dgv.DataSource = TeamStatRepository.GetStatsByTeamId(_teamId.Value);

                    // 1. Hide unwanted raw IDs
                    if (dgv.Columns["TeamStatId"] != null) dgv.Columns["TeamStatId"].Visible = false;
                    if (dgv.Columns["TeamId"] != null) dgv.Columns["TeamId"].Visible = false;
                    if (dgv.Columns["MatchId"] != null) dgv.Columns["MatchId"].Visible = false;
                    if (dgv.Columns["TeamName"] != null) dgv.Columns["TeamName"].Visible = false; // Hidden because it's in the Form Title!

                    // 2. Ensure MatchDisplay is visible and formatted nicely
                    if (dgv.Columns["MatchDisplay"] != null)
                    {
                        dgv.Columns["MatchDisplay"].Visible = true; // Make sure it isn't hidden!
                        dgv.Columns["MatchDisplay"].HeaderText = "Match Date & Opponent";
                        dgv.Columns["MatchDisplay"].DisplayIndex = 0;    // Put it on the far left
                    }

                    // 3. Format the remaining statistical columns
                    dgv.Columns["PossessionPercentage"].HeaderText = "Possession %";
                    dgv.Columns["ShotsOnTarget"].HeaderText = "Shots on Target";
                    dgv.Columns["Corners"].HeaderText = "Corners";
                    dgv.Columns["Fouls"].HeaderText = "Fouls";
                }
                else
                {
                    // GLOBAL DASHBOARD (Shows the Statistical Standings)
                    dgv.DataSource = TeamStatRepository.GetLeagueStatisticalStandings();

                    dgv.Columns["TeamName"].HeaderText = "Team";
                    dgv.Columns["TeamName"].DisplayIndex = 0;
                    dgv.Columns["MatchesPlayed"].HeaderText = "Matches Played";
                    dgv.Columns["AvgPossession"].HeaderText = "Avg Possession %";
                    dgv.Columns["TotalShotsOnTarget"].HeaderText = "Total Shots on Target";
                    dgv.Columns["TotalCorners"].HeaderText = "Total Corners";
                    dgv.Columns["TotalFouls"].HeaderText = "Total Fouls";
                }

                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Team Stats: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}