using System;
using System.Windows.Forms;
using EPL_DBMS.DataAccess;

namespace EPL_DBMS.Forms
{
    public partial class ManagersForm : Form
    {
        public ManagersForm()
        {
            InitializeComponent();
            LoadManagers();

            // Wire up the double-click event automatically
            dataGridViewManagers.CellDoubleClick += DataGridViewManagers_CellDoubleClick;
        }

        private void LoadManagers()
        {
            try
            {
                var data = ManagerRepository.GetAllManagers();
                var dgv = dataGridViewManagers;
                dgv.DataSource = data;

                dgv.Columns["ManagerId"].HeaderText = "ID";
                dgv.Columns["ManagerName"].HeaderText = "Manager Name";
                dgv.Columns["Nationality"].HeaderText = "Nationality";
                dgv.Columns["PreferredFormation"].HeaderText = "Formation";
                dgv.Columns["TeamId"].HeaderText = "Team ID";
                dgv.Columns["ExperienceYears"].HeaderText = "Experience (yrs)";
                dgv.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Managers: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // This method fires whenever a row is double-clicked
        private void DataGridViewManagers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks on the column header row (Index -1)
            if (e.RowIndex >= 0)
            {
                // Grab the ID and Name from the clicked row
                int managerId = (int)dataGridViewManagers.Rows[e.RowIndex].Cells["ManagerId"].Value;
                string managerName = dataGridViewManagers.Rows[e.RowIndex].Cells["ManagerName"].Value.ToString();

                // --- THE FIX: Ask the database for the history BEFORE opening the new form ---
                var history = ManagerHistoryRepository.GetHistoryWithNamesByManager(managerId);

                // If there is no history, show the message safely on this screen and stop here
                if (history.Count == 0)
                {
                    MessageBox.Show($"{managerName} has no previous team history recorded.",
                                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // If the code makes it here, they DO have history. Open the popup!
                var historyForm = new ManagerHistoryForm(managerId, managerName);
                historyForm.ShowDialog();
            }
        }
    }
}