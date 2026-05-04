using System.Windows.Forms;
using EPL_DBMS.DataAccess;

namespace EPL_DBMS.Forms
{
    public partial class TeamsForm : Form
    {
        public TeamsForm()
        {
            InitializeComponent();
            LoadTeams();
        }

        private void LoadTeams()
        {
            try
            {
                var teams = TeamRepository.GetAllTeams();
                dataGridViewTeams.DataSource = teams;

                // Clean up the auto-generated column headers
                dataGridViewTeams.Columns["TeamId"].HeaderText = "ID";
                dataGridViewTeams.Columns["TeamName"].HeaderText = "Team Name";
                dataGridViewTeams.Columns["YearFounded"].HeaderText = "Founded";
                dataGridViewTeams.Columns["HomeKitColor"].HeaderText = "Kit Color";
                dataGridViewTeams.Columns["StadiumId"].HeaderText = "Stadium ID";

                dataGridViewTeams.AutoResizeColumns();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error loading teams: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}