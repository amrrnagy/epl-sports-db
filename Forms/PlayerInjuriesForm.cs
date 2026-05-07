using System;
using System.Windows.Forms;
using EPL_DBMS.DataAccess;

namespace EPL_DBMS.Forms
{
    public partial class PlayerInjuriesForm : Form
    {
        private readonly int? _playerId;

        // ── Contextual Constructors ──────────────────────────────────────────────

        // Called from Main Menu — loads ALL injuries league-wide
        public PlayerInjuriesForm()
        {
            InitializeComponent();
            _playerId  = null;
            this.Text  = "League Injury Report";
            this.Load += Form_Load;
        }

        // Called from PlayersForm — loads injuries for one specific player
        public PlayerInjuriesForm(int playerId, string playerName)
        {
            InitializeComponent();
            _playerId  = playerId;
            this.Text  = $"{playerName} - Injury History";
            this.Load += Form_Load;
        }

        // ── Data Loading ─────────────────────────────────────────────────────────

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                var dgv = dataGridViewPlayerInjuries;

                // ── PURE ADO.NET ROUTING ─────────────────────────────────────
                if (_playerId.HasValue)
                {
                    // Contextual path: SQL WHERE clause filters by player ID
                    dgv.DataSource = PlayerInjuryRepository.GetViewByPlayerId(_playerId.Value);

                    // Hide raw ID — the form title already identifies the player
                    dgv.Columns["PlayerId"].Visible    = false;
                    dgv.Columns["PlayerName"].Visible  = false; // redundant with title
                }
                else
                {
                    // Global path: returns all injuries via INNER JOIN
                    dgv.DataSource = PlayerInjuryRepository.GetAllInjuriesWithNames();

                    // Hide raw FK ID; show the human-readable name instead
                    dgv.Columns["PlayerId"].Visible = false;

                    dgv.Columns["PlayerName"].HeaderText   = "Player";
                    dgv.Columns["PlayerName"].DisplayIndex = 0; // Move to the far left
                }

                // ── Common column formatting ─────────────────────────────────
                dgv.Columns["InjuryDate"].HeaderText = "Injury Date";
                dgv.Columns["InjuryType"].HeaderText = "Injury Type";
                dgv.Columns["DaysOut"].HeaderText    = "Days Out";

                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Player Injuries: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
