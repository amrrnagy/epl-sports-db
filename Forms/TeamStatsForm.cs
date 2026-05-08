using System;
using System.Windows.Forms;
using EPL_DBMS.DataAccess;

namespace EPL_DBMS.Forms
{
    public partial class TeamStatsForm : Form
    {
        private readonly int? _teamId;

        // Global dashboard constructor
        public TeamStatsForm()
        {
            InitializeComponent();
            _teamId = null;
            this.Text = "League Team Statistics";
            this.Load += Form_Load;
        }

        // Specific team history constructor
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
                    dgv.DataSource = TeamStatRepository.GetStatsByTeamId(_teamId.Value);

                    if (dgv.Columns["TeamStatId"] != null) dgv.Columns["TeamStatId"].Visible = false;
                    if (dgv.Columns["TeamId"] != null) dgv.Columns["TeamId"].Visible = false;
                    if (dgv.Columns["MatchId"] != null) dgv.Columns["MatchId"].Visible = false;
                    if (dgv.Columns["TeamName"] != null) dgv.Columns["TeamName"].Visible = false;

                    if (dgv.Columns["MatchDisplay"] != null)
                    {
                        dgv.Columns["MatchDisplay"].Visible = true;
                        dgv.Columns["MatchDisplay"].HeaderText = "Match Date & Opponent";
                        dgv.Columns["MatchDisplay"].DisplayIndex = 0;
                    }

                    dgv.Columns["PossessionPercentage"].HeaderText = "Possession %";
                    dgv.Columns["ShotsOnTarget"].HeaderText = "Shots on Target";
                    dgv.Columns["Corners"].HeaderText = "Corners";
                    dgv.Columns["Fouls"].HeaderText = "Fouls";
                }
                else
                {
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