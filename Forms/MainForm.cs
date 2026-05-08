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

        // Hides the main form, opens the child dialog, and refreshes data upon return
        private void NavigateTo(Form childForm)
        {
            this.Hide();

            using (childForm)
            {
                childForm.ShowDialog();
            }

            MainForm_Load(null, null);
            this.Show();
        }

        private void panelPlayers_Click(object sender, EventArgs e) => NavigateTo(new PlayersForm());
        private void panelTeams_Click(object sender, EventArgs e) => NavigateTo(new TeamsForm());
        private void panelMatches_Click(object sender, EventArgs e) => NavigateTo(new MatchesForm());

        private void btnManagers_Click(object sender, EventArgs e) => NavigateTo(new ManagersForm());
        private void btnStadiums_Click(object sender, EventArgs e) => NavigateTo(new StadiumsForm());
        private void btnReferees_Click(object sender, EventArgs e) => NavigateTo(new RefereesForm());

        private void btnTopPerformers_Click(object sender, EventArgs e) => NavigateTo(new PlayerStatsForm());
        private void btnInjuryReport_Click(object sender, EventArgs e) => NavigateTo(new PlayerInjuriesForm());
        private void btnStandings_Click(object sender, EventArgs e) => NavigateTo(new TeamStatsForm());
    }
}