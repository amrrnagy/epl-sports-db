using System;
using System.Windows.Forms;
using EPL_DBMS.DataAccess;

namespace EPL_DBMS.Forms
{
    public partial class PlayerInjuriesForm : Form
    {
        private readonly int? _playerId;

        // 1. GLOBAL CONSTRUCTOR (Called from Main Form)
        public PlayerInjuriesForm()
        {
            InitializeComponent();
            _playerId = null;
            this.Text = "League Injury Report";
            this.Load += Form_Load;
        }

        // 2. SPECIFIC CONSTRUCTOR (Called from Players Form)
        public PlayerInjuriesForm(int playerId, string playerName)
        {
            InitializeComponent();
            _playerId = playerId;
            this.Text = $"{playerName} - Injury History";
            this.Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                var dgv = dataGridViewPlayerInjuries;

                // ── PURE ADO.NET ROUTING ─────────────────────────────────────
                if (_playerId.HasValue)
                {
                    // SPECIFIC PLAYER (Shows the raw individual injury log)
                    dgv.DataSource = PlayerInjuryRepository.GetViewByPlayerId(_playerId.Value);

                    dgv.Columns["PlayerId"].Visible = false;
                    dgv.Columns["PlayerName"].Visible = false; // Redundant with window title

                    dgv.Columns["InjuryDate"].HeaderText = "Injury Date";
                    dgv.Columns["InjuryType"].HeaderText = "Injury Type";
                    dgv.Columns["DaysOut"].HeaderText = "Days Out";
                }
                else
                {
                    // GLOBAL DASHBOARD (Uses the new Statistical Aggregation!)
                    dgv.DataSource = PlayerInjuryRepository.GetLeagueInjuryStatistics();

                    dgv.Columns["PlayerName"].HeaderText = "Player";
                    dgv.Columns["PlayerName"].DisplayIndex = 0;

                    dgv.Columns["TotalInjuries"].HeaderText = "Total Injuries";
                    dgv.Columns["TotalDaysOut"].HeaderText = "Total Days Out";
                    dgv.Columns["LastInjuryDate"].HeaderText = "Last Injury Date";
                }

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