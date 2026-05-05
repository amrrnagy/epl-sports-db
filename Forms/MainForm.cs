using System;
using System.Windows.Forms;

namespace EPL_DBMS.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnTeams_Click(object sender, EventArgs e)          => new TeamsForm().Show();
        private void btnPlayers_Click(object sender, EventArgs e)        => new PlayersForm().Show();
        private void btnStadiums_Click(object sender, EventArgs e)       => new StadiumsForm().Show();
        private void btnReferees_Click(object sender, EventArgs e)       => new RefereesForm().Show();
        private void btnManagers_Click(object sender, EventArgs e)       => new ManagersForm().Show();
        private void btnMatches_Click(object sender, EventArgs e)        => new MatchesForm().Show();

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
    }
}
