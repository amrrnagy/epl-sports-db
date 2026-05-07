using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;

namespace EPL_DBMS.Forms
{
    public partial class ManagersForm : Form
    {
        public ManagersForm()
        {
            InitializeComponent();
            LoadManagers();
            dataGridViewManagers.CellClick += DataGridViewManagers_CellClick;
            dataGridViewManagers.CellDoubleClick += DataGridViewManagers_CellDoubleClick;
        }

        private void LoadManagers()
        {
            try
            {
                dataGridViewManagers.DataSource = ManagerRepository.GetAllManagersForGrid();
                dataGridViewManagers.Columns["ManagerId"].Visible = false;
                dataGridViewManagers.Columns["TeamId"].Visible = false;
                dataGridViewManagers.Columns["TeamName"].HeaderText = "Current Club";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var m = new Manager
                {
                    ManagerName = txtName.Text,
                    Nationality = txtNationality.Text,
                    PreferredFormation = txtFormation.Text,
                    ExperienceYears = int.Parse(txtExperience.Text),
                    TeamId = int.Parse(txtTeamId.Text)
                };
                ManagerRepository.Add(m);
                LoadManagers();
                MessageBox.Show("Manager added successfully!");
            }
            catch (Exception ex)
            {
                // This will now catch your custom "This team already has a manager" message!
                MessageBox.Show(ex.Message, "Database Rule Violation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewManagers.CurrentRow == null) return;
            var m = new Manager
            {
                ManagerId = (int)dataGridViewManagers.CurrentRow.Cells["ManagerId"].Value,
                ManagerName = txtName.Text,
                Nationality = txtNationality.Text,
                PreferredFormation = txtFormation.Text,
                ExperienceYears = int.Parse(txtExperience.Text),
                TeamId = int.Parse(txtTeamId.Text)
            };
            ManagerRepository.Update(m);
            LoadManagers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewManagers.CurrentRow == null) return;
            int id = (int)dataGridViewManagers.CurrentRow.Cells["ManagerId"].Value;
            ManagerRepository.Delete(id);
            LoadManagers();
        }

        private void DataGridViewManagers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dataGridViewManagers.Rows[e.RowIndex];
            txtName.Text = row.Cells["ManagerName"].Value.ToString();
            txtNationality.Text = row.Cells["Nationality"].Value.ToString();
            txtFormation.Text = row.Cells["PreferredFormation"].Value.ToString();
            txtExperience.Text = row.Cells["ExperienceYears"].Value.ToString();
            txtTeamId.Text = row.Cells["TeamId"].Value.ToString();
        }

        private void search_Click(object sender, EventArgs e)
        {
            // 1. Validate ID input (using txtid as the search box)
            if (!int.TryParse(txtid.Text, out int id))
            {
                MessageBox.Show("Enter a valid Manager ID");
                return;
            }

            // 2. Fetch the Manager from the database
            var manager = ManagerRepository.GetById(id);

            if (manager == null)
            {
                MessageBox.Show("Manager not found");
                return;
            }

            // 3. Fill the Manager-specific text fields
            txtName.Text = manager.ManagerName;
            txtNationality.Text = manager.Nationality;
            txtFormation.Text = manager.PreferredFormation;
            txtExperience.Text = manager.ExperienceYears.ToString();
            txtTeamId.Text = manager.TeamId.ToString();

            // Helper to reset text colors if you use placeholders
            SetAllTextBlack();

            // 4. Enable the action buttons
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            // 5. Highlight and scroll to the Manager in the DataGridView
            foreach (DataGridViewRow row in dataGridViewManagers.Rows)
            {
                // Check "ManagerId" column for the match
                if (row.Cells["ManagerId"].Value != null && (int)row.Cells["ManagerId"].Value == id)
                {
                    // Focus the grid
                    dataGridViewManagers.ClearSelection();
                    row.Selected = true;

                    // Set as current cell so the Grid logic knows which row is active
                    dataGridViewManagers.CurrentCell = row.Cells[0];

                    // Scroll the grid to this row
                    dataGridViewManagers.FirstDisplayedScrollingRowIndex = row.Index;

                    break;
                }
            }
        }

        // Helper method to ensure text is visible after placeholder logic
        private void SetAllTextBlack()
        {
            TextBox[] boxes = { txtName, txtNationality, txtFormation, txtExperience, txtTeamId, txtid };
            foreach (var txt in boxes)
            {
                txt.ForeColor = Color.Black;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DataGridViewManagers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks on header rows
            if (e.RowIndex < 0) return;

            // 1. Extract manager data from the double-clicked row
            // Note: ManagerId is hidden but accessible in the row data
            int managerId = (int)dataGridViewManagers.Rows[e.RowIndex].Cells["ManagerId"].Value;
            string managerName = dataGridViewManagers.Rows[e.RowIndex].Cells["ManagerName"].Value.ToString();

            // 2. Check if the manager has any history before opening the window
            var history = ManagerPreviousTeamRepository.GetViewByManagerId(managerId);

            if (history.Count == 0)
            {
                MessageBox.Show($"{managerName} has no previous team history recorded.",
                                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 3. Open the popup form as a dialog
            var historyForm = new ManagerPreviousTeamsForm(managerId, managerName);
            historyForm.ShowDialog();
        }
    }
}