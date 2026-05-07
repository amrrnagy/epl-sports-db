using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
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

            // Placeholders
            Placeholder(txtname, "Name");
            Placeholder(txtnationality, "Nationality");
            Placeholder(txtformation, "Formation");
            Placeholder(txtexperienceyear, "Experience Years");
            Placeholder(txtteamid, "Team ID");

            txtid.ForeColor = System.Drawing.Color.Black;
            dataGridViewManagers.CellClick += DataGridViewManagers_CellClick;
            dataGridViewManagers.CellDoubleClick += DataGridViewManagers_CellDoubleClick;
        }

        private void LoadManagers()
        {
            try
            {
                var managers = ManagerRepository.GetAllManagers();
                dataGridViewManagers.DataSource = managers;
                dataGridViewManagers.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading managers: " + ex.Message);
            }
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtid.Text, out int id))
                return;

            var manager = ManagerRepository.GetById(id);

            if (manager == null) return;

            txtname.Text = manager.ManagerName;
            txtformation.Text = manager.PreferredFormation;
            txtnationality.Text = manager.Nationality;
            txtexperienceyear.Text = manager.ExperienceYears.ToString();
            txtteamid.Text = manager.TeamId.ToString();

            txtname.ForeColor = System.Drawing.Color.Black;
            txtformation.ForeColor = System.Drawing.Color.Black;
            txtexperienceyear.ForeColor = System.Drawing.Color.Black;
            txtnationality.ForeColor = System.Drawing.Color.Black;
            txtteamid.ForeColor = System.Drawing.Color.Black;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {


            if (!int.TryParse(txtteamid.Text, out int teamId) ||
                !int.TryParse(txtexperienceyear.Text, out int experienceYears))
            {
                MessageBox.Show("Enter valid numeric values!");
                return;
            }
            var m = new Manager
            {

                ManagerName = txtname.Text,
                PreferredFormation = txtformation.Text,
                Nationality = txtnationality.Text,
                ExperienceYears = experienceYears,
                TeamId = teamId



            };

            ManagerRepository.Add(m);

            MessageBox.Show("Manager Added!");
            LoadManagers();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtid.Text, out int id))
                {
                    MessageBox.Show("Invalid ID");
                    return;
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

                var m = new Manager
                {
                    ManagerId = id,
                    ManagerName = txtname.Text,
                    Nationality = txtnationality.Text,
                    PreferredFormation = txtformation.Text,
                    ExperienceYears = int.Parse(txtexperienceyear.Text),
                    TeamId = int.Parse(txtteamid.Text)
                };

                ManagerRepository.Update(m);

                LoadManagers();
                ClearFields();

                MessageBox.Show("Manager updated successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating manager: " + ex.Message);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtid.Text, out int id))
                {
                    MessageBox.Show("Select a valid manager first");
                    return;
                }

                ManagerRepository.Delete(id);

                LoadManagers();
                ClearFields();

                MessageBox.Show("Manager deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting manager: " + ex.Message);
            }
        }

        private void dataGridViewManagers_CellClick(object sender, DataGridViewCellEventArgs E)
        {
            if (E.RowIndex < 0) return;

            var row = dataGridViewManagers.CurrentRow;

            txtid.Text = row.Cells["ManagerId"].Value.ToString();
            txtname.Text = row.Cells["ManagerName"].Value.ToString();
            txtformation.Text = row.Cells["PreferredFormation"].Value.ToString();
            txtnationality.Text = row.Cells["Nationality"].Value.ToString();
            txtexperienceyear.Text = row.Cells["ExperienceYears"].Value.ToString();
            txtteamid.Text = row.Cells["TeamId"].Value.ToString();

            txtid.ForeColor = System.Drawing.Color.Black;
        }

        private bool ValidateInputs()
        {
            if (txtname.Text == "Name" ||
                txtnationality.Text == "Nationality" ||
                txtformation.Text == "Formation" ||
                txtexperienceyear.Text == "Experience Years" ||
                txtteamid.Text == "Team ID")
            {
                MessageBox.Show("Please fill all fields");
                return false;
            }

            if (!int.TryParse(txtexperienceyear.Text, out _) ||
                !int.TryParse(txtteamid.Text, out _))
            {
                MessageBox.Show("Experience Years and Team ID must be numbers");
                return false;
            }

            return true;
        }

        private void Placeholder(TextBox txt, string placeholder)
        {
            txt.Text = placeholder;
            txt.ForeColor = System.Drawing.Color.Gray;

            txt.GotFocus += (s, e) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Text = "";
                    txt.ForeColor = System.Drawing.Color.Black;
                }
            };

            txt.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = System.Drawing.Color.Gray;
                }
            };
        }

        private void ClearFields()
        {
            txtname.Clear();
            txtformation.Clear();
            txtnationality.Clear();
            txtexperienceyear.Clear();
            txtteamid.Clear();
            txtid.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManagersForm_Load(object sender, EventArgs e)
        {
            LoadManagers();
        }
    }
}