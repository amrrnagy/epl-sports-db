
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
            lblTeamsCount.Text = TeamRepository.TeamCount().ToString();
            lblPlayersCount.Text = PlayerRepository.PlayerCount().ToString();
            lblMatchesCount.Text = MatchRepository.MatchCount().ToString();

        }

        private void btnTeams_Click(object sender, EventArgs e) => new TeamsForm().Show();
        private void btnStadiums_Click(object sender, EventArgs e) => new StadiumsForm().Show();
        private void btnReferees_Click(object sender, EventArgs e) => new RefereesForm().Show();
        private void btnManagers_Click(object sender, EventArgs e) => new ManagersForm().Show();
     

        private void btnPlayers_Click(object sender, EventArgs e)
        {
            PlayersForm form = new PlayersForm();
        
            form.FormClosed += (s, args) => this.Show(); // show main again
            form.Show();
            this.Hide(); // hide main
        }
        private void btnMatches_Click(object sender, EventArgs e)
        {
            MatchesForm form = new MatchesForm();
          
            form.FormClosed += (s, args) => this.Show(); // show main again
            form.Show();
            this.Hide(); // hide main
        }



        private void btnPlayerInjuries_Click(object sender, EventArgs e)
        {

        }

        private void btnTeamStats_Click(object sender, EventArgs e)
        {

        }

        private void btnPlayerStats_Click(object sender, EventArgs e)
        {

        }

        private void btnManagerHistory_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblTeamsCount_Click(object sender, EventArgs e)
        {

        }

        private void lblMatchesCount_Click(object sender, EventArgs e)
        {

        }
    }
}





    