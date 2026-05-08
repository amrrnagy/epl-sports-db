using System;
using System.Windows.Forms;
using EPL_DBMS.DataAccess;

namespace EPL_DBMS.Forms
{
    public partial class PlayerStatsForm : Form
    {
        private readonly int? _playerId;

        // Global dashboard constructor
        public PlayerStatsForm()
        {
            InitializeComponent();
            _playerId = null;
            this.Text = "League Top Performers";
            this.Load += Form_Load;
        }

        // Specific player constructor
        public PlayerStatsForm(int playerId, string playerName)
        {
            InitializeComponent();
            _playerId = playerId;
            this.Text = $"{playerName} - Match Statistics";
            this.Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                var dgv = dataGridViewPlayerStats;

                if (_playerId.HasValue)
                {
                    dgv.DataSource = PlayerStatRepository.GetStatsByPlayerId(_playerId.Value);

                    dgv.Columns["PlayerStatId"].Visible = false;
                    dgv.Columns["PlayerId"].Visible = false;
                    dgv.Columns["MatchId"].Visible = false;
                    dgv.Columns["PlayerName"].Visible = false;

                    if (dgv.Columns["MatchDisplay"] != null)
                    {
                        dgv.Columns["MatchDisplay"].Visible = true;
                        dgv.Columns["MatchDisplay"].HeaderText = "Match Date & Opponent";
                        dgv.Columns["MatchDisplay"].DisplayIndex = 0;
                    }

                    dgv.Columns["GoalsScored"].HeaderText = "Goals";
                    dgv.Columns["Assists"].HeaderText = "Assists";
                    dgv.Columns["YellowCards"].HeaderText = "Yellow Cards";
                    dgv.Columns["RedCards"].HeaderText = "Red Cards";
                    dgv.Columns["MinutesPlayed"].HeaderText = "Minutes Played";
                }
                else
                {
                    dgv.DataSource = PlayerStatRepository.GetLeagueTopPerformers();

                    dgv.Columns["PlayerName"].HeaderText = "Player";
                    dgv.Columns["PlayerName"].DisplayIndex = 0;

                    dgv.Columns["TotalGoals"].HeaderText = "Total Goals";
                    dgv.Columns["TotalAssists"].HeaderText = "Total Assists";
                    dgv.Columns["TotalYellowCards"].HeaderText = "Total Yellow Cards";
                    dgv.Columns["TotalRedCards"].HeaderText = "Total Red Cards";
                    dgv.Columns["TotalMinutes"].HeaderText = "Total Minutes";
                }

                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Player Stats: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}