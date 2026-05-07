using System;
using System.Windows.Forms;
using EPL_DBMS.DataAccess;

namespace EPL_DBMS.Forms
{
    public partial class TeamStatsForm : Form
    {
        private readonly int? _teamId;

        public TeamStatsForm()
        {
            InitializeComponent();
            _teamId = null;
            this.Text = "League Team Statistics";
            this.Load += Form_Load;
        }

        public TeamStatsForm(int teamId, string teamName)
        {
            InitializeComponent();
            _teamId = teamId;
            this.Text = $"{teamName} - Season Statistics";
            this.Load += Form_Load;
        }

        // FIX 1: Added (object sender, EventArgs e)
        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                var dgv = dataGridViewTeamStats;

                // FIX 2: PURE ADO.NET ROUTING
                if (_teamId.HasValue)
                {
                    dgv.DataSource = TeamStatRepository.GetStatsByTeamId(_teamId.Value);
                }
                else
                {
                    dgv.DataSource = TeamStatRepository.GetAllTeamStatsWithNames();
                }

                // Hide the raw database IDs
                dgv.Columns["TeamStatId"].Visible = false;
                dgv.Columns["TeamId"].Visible = false;

                // Hide MatchDisplay since we haven't mapped it yet in SQL
                if (dgv.Columns.Contains("MatchDisplay"))
                    dgv.Columns["MatchDisplay"].Visible = false;

                // Format the ViewModel column
                dgv.Columns["TeamName"].HeaderText = "Team";
                dgv.Columns["TeamName"].DisplayIndex = 0; // Move to the far left

                // Format the rest
                dgv.Columns["MatchId"].HeaderText = "Match ID";
                dgv.Columns["PossessionPercentage"].HeaderText = "Possession %";
                dgv.Columns["ShotsOnTarget"].HeaderText = "Shots on Target";
                dgv.Columns["Corners"].HeaderText = "Corners";
                dgv.Columns["Fouls"].HeaderText = "Fouls";

                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Team Stats: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}