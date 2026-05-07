using System;
using System.Windows.Forms;
using EPL_DBMS.DataAccess;

namespace EPL_DBMS.Forms
{
    public partial class PlayerStatsForm : Form
    {
        private readonly int? _playerId;

        // ── Contextual Constructors ──────────────────────────────────────────────

        // Called from Main Menu — loads ALL player stats league-wide
        public PlayerStatsForm()
        {
            InitializeComponent();
            _playerId  = null;
            this.Text  = "League Top Performers";
            this.Load += Form_Load;
        }

        // Called from PlayersForm — loads stats for one specific player
        public PlayerStatsForm(int playerId, string playerName)
        {
            InitializeComponent();
            _playerId  = playerId;
            this.Text  = $"{playerName} - Match Statistics";
            this.Load += Form_Load;
        }

        // ── Data Loading ─────────────────────────────────────────────────────────

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                var dgv = dataGridViewPlayerStats;

                // ── PURE ADO.NET ROUTING ─────────────────────────────────────
                if (_playerId.HasValue)
                {
                    // Contextual path: SQL WHERE clause filters by player ID
                    dgv.DataSource = PlayerStatRepository.GetStatsByPlayerId(_playerId.Value);

                    // Hide raw IDs — the form title already identifies the player
                    dgv.Columns["PlayerId"].Visible   = false;
                    dgv.Columns["PlayerName"].Visible = false; // redundant with title
                }
                else
                {
                    // Global path: returns all stats via INNER JOIN
                    dgv.DataSource = PlayerStatRepository.GetAllPlayerStatsForGrid();

                    // Hide raw FK ID; show the human-readable name instead
                    dgv.Columns["PlayerId"].Visible = false;

                    dgv.Columns["PlayerName"].HeaderText   = "Player";
                    dgv.Columns["PlayerName"].DisplayIndex = 0; // Move to the far left
                }

                // ── Common column formatting ─────────────────────────────────
                dgv.Columns["PlayerStatId"].Visible      = false; // internal PK, not useful to display
                dgv.Columns["MatchId"].HeaderText        = "Match ID";
                dgv.Columns["GoalsScored"].HeaderText    = "Goals";
                dgv.Columns["Assists"].HeaderText        = "Assists";
                dgv.Columns["YellowCards"].HeaderText    = "Yellow Cards";
                dgv.Columns["RedCards"].HeaderText       = "Red Cards";
                dgv.Columns["MinutesPlayed"].HeaderText  = "Minutes Played";

                // Hide MatchDisplay if it was ever populated (not set in this ViewModel)
                if (dgv.Columns.Contains("MatchDisplay"))
                    dgv.Columns["MatchDisplay"].Visible = false;

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
