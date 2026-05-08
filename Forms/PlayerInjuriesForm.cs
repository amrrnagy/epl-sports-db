using System;
using System.Windows.Forms;
using EPL_DBMS.DataAccess;

namespace EPL_DBMS.Forms
{
    public partial class PlayerInjuriesForm : Form
    {
        private readonly int? _playerId;

        // Global dashboard constructor
        public PlayerInjuriesForm()
        {
            InitializeComponent();
            _playerId = null;
            this.Text = "League Injury Report";
            this.Load += Form_Load;
        }

        // Specific player constructor
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

                if (_playerId.HasValue)
                {
                    dgv.DataSource = PlayerInjuryRepository.GetViewByPlayerId(_playerId.Value);

                    dgv.Columns["PlayerId"].Visible = false;
                    dgv.Columns["PlayerName"].Visible = false;

                    dgv.Columns["InjuryDate"].HeaderText = "Injury Date";
                    dgv.Columns["InjuryType"].HeaderText = "Injury Type";
                    dgv.Columns["DaysOut"].HeaderText = "Days Out";
                }
                else
                {
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