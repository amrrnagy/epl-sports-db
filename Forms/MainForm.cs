using EPL_DBMS.DataAccess;
using System;
using System.Windows.Forms;

namespace EPL_DBMS.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                lblTeamsCount.Text = TeamRepository.TeamCount().ToString();
                lblPlayersCount.Text = PlayerRepository.PlayerCount().ToString();
                lblMatchesCount.Text = MatchRepository.MatchCount().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ==========================================
        // Safe Navigation Method (Prevents Memory Leaks)
        // ==========================================
        private void NavigateTo(Form childForm)
        {
            this.Hide();

            using (childForm)
            {
                childForm.ShowDialog();
            }

            MainForm_Load(null, null); // Refresh the counts!
            this.Show();
        }

        // ==========================================
        // Top Row: The Panels (Cards)
        // ==========================================
        private void panelPlayers_Click(object sender, EventArgs e) => NavigateTo(new PlayersForm());
        private void panelTeams_Click(object sender, EventArgs e) => NavigateTo(new TeamsForm());
        private void panelMatches_Click(object sender, EventArgs e) => NavigateTo(new MatchesForm());

        // ==========================================
        // Middle Row: Management Forms
        // ==========================================
        private void btnManagers_Click(object sender, EventArgs e) => NavigateTo(new ManagersForm());
        private void btnStadiums_Click(object sender, EventArgs e) => NavigateTo(new StadiumsForm());
        private void btnReferees_Click(object sender, EventArgs e) => NavigateTo(new RefereesForm());

        // ==========================================
        // Bottom Row: Global Statistics/Reports
        // ==========================================
        // Uses the empty constructors to load ALL data for the league
        private void btnTopPerformers_Click(object sender, EventArgs e) => NavigateTo(new PlayerStatsForm());
        private void btnInjuryReport_Click(object sender, EventArgs e) => NavigateTo(new PlayerInjuriesForm());
        private void btnStandings_Click(object sender, EventArgs e) => NavigateTo(new TeamStatsForm());
    }
}