using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EPL_DBMS.Forms
{
    public partial class ManagersForm : Form
    {
        public ManagersForm()
        {
            InitializeComponent();

            // Set up UI and Data
            LoadManagers();
            InitializePlaceholders();

            // Wire up Events
            dataGridViewManagers.CellClick += dataGridViewManagers_CellClick;
            dataGridViewManagers.CellDoubleClick += DataGridViewManagers_CellDoubleClick;
        }

        private void LoadManagers()
        {
            try
            {
                // PRIORITY: Use the ViewModel method to see Team Names instead of IDs 
                var data = ManagerRepository.GetAllManagersForGrid();
                dataGridViewManagers.DataSource = data;

                if (dataGridViewManagers.Columns["ManagerId"] != null)
                    dataGridViewManagers.Columns["ManagerId"].Visible = false;

                if (dataGridViewManagers.Columns["TeamId"] != null)
                    dataGridViewManagers.Columns["TeamId"].Visible = false;

                if (dataGridViewManagers.Columns["TeamName"] != null)
                    dataGridViewManagers.Columns["TeamName"].HeaderText = "Current Club";

                dataGridViewManagers.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading managers: " + ex.Message);
            }
        }

        private void InitializePlaceholders()
        {
            SetPlaceholder(txtname, "Name");
            SetPlaceholder(txtnationality, "Nationality");
            SetPlaceholder(txtformation, "Formation");
            SetPlaceholder(txtexperienceyear, "Experience Years");
            SetPlaceholder(txtteamid, "Team ID");
            SetPlaceholder(txtid, "ID"); // txtid is used for searching/updating
        }

        // ── CRUD OPERATIONS ──────────────────────────────────────────────────

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                var m = new Manager
                {
                    ManagerName = txtname.Text,
                    Nationality = txtnationality.Text,
                    PreferredFormation = txtformation.Text,
                    ExperienceYears = int.Parse(txtexperienceyear.Text),
                    TeamId = int.Parse(txtteamid.Text)
                };

                ManagerRepository.Add(m);
                MessageBox.Show("Manager added successfully!");
                RefreshUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Rule Violation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // AMBIGUITY FIX: We use 'this.txtid' to ensure we mean the TextBox control 
            if (!int.TryParse(this.txtid.Text, out int managerIdSearch))
            {
                MessageBox.Show("Please select or search for a manager first.");
                return;
            }

            if (!ValidateInputs()) return;

            try
            {
                var m = new Manager
                {
                    ManagerId = managerIdSearch,
                    ManagerName = txtname.Text,
                    Nationality = txtnationality.Text,
                    PreferredFormation = txtformation.Text,
                    ExperienceYears = int.Parse(txtexperienceyear.Text),
                    TeamId = int.Parse(txtteamid.Text)
                };

                ManagerRepository.Update(m);
                MessageBox.Show("Manager updated successfully");
                RefreshUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating manager: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(this.txtid.Text, out int managerIdSearch))
            {
                MessageBox.Show("Select a valid manager first");
                return;
            }

            if (MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    ManagerRepository.Delete(managerIdSearch);
                    RefreshUI();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting: " + ex.Message);
                }
            }
        }

        // ── SEARCH & NAVIGATION ──────────────────────────────────────────────

        private void search_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(this.txtid.Text, out int searchId))
            {
                MessageBox.Show("Enter a valid Manager ID");
                return;
            }

            var manager = ManagerRepository.GetById(searchId);
            if (manager == null)
            {
                MessageBox.Show("Manager not found");
                return;
            }

            PopulateFields(manager);

            // Highlight in Grid
            foreach (DataGridViewRow row in dataGridViewManagers.Rows)
            {
                if (row.Cells["ManagerId"].Value != null && (int)row.Cells["ManagerId"].Value == searchId)
                {
                    dataGridViewManagers.ClearSelection();
                    row.Selected = true;
                    dataGridViewManagers.CurrentCell = row.Cells[0];
                    dataGridViewManagers.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void DataGridViewManagers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int mId = (int)dataGridViewManagers.Rows[e.RowIndex].Cells["ManagerId"].Value;
            string mName = dataGridViewManagers.Rows[e.RowIndex].Cells["ManagerName"].Value.ToString();

            var history = ManagerPreviousTeamRepository.GetViewByManagerId(mId);
            if (history.Count == 0)
            {
                MessageBox.Show($"{mName} has no previous team history.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var historyForm = new ManagerPreviousTeamsForm(mId, mName);
            historyForm.ShowDialog();
        }

        private void dataGridViewManagers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewManagers.CurrentRow;
            this.txtid.Text = row.Cells["ManagerId"].Value.ToString();
            txtname.Text = row.Cells["ManagerName"].Value.ToString();
            txtformation.Text = row.Cells["PreferredFormation"].Value.ToString();
            txtnationality.Text = row.Cells["Nationality"].Value.ToString();
            txtexperienceyear.Text = row.Cells["ExperienceYears"].Value.ToString();
            txtteamid.Text = row.Cells["TeamId"].Value.ToString();

            SetAllTextBlack();
        }

        // ── HELPERS ──────────────────────────────────────────────────────────

        private void PopulateFields(Manager m)
        {
            txtname.Text = m.ManagerName;
            txtformation.Text = m.PreferredFormation;
            txtnationality.Text = m.Nationality;
            txtexperienceyear.Text = m.ExperienceYears.ToString();
            txtteamid.Text = m.TeamId.ToString();
            SetAllTextBlack();
        }

        private void RefreshUI()
        {
            LoadManagers();
            ClearFields();
        }

        private bool ValidateInputs()
        {
            if (txtname.Text == "Name" || txtnationality.Text == "Nationality" ||
                txtformation.Text == "Formation" || txtteamid.Text == "Team ID")
            {
                MessageBox.Show("Please fill all required fields");
                return false;
            }
            return true;
        }

        private void SetAllTextBlack()
        {
            TextBox[] boxes = { txtname, txtnationality, txtformation, txtexperienceyear, txtteamid, txtid };
            foreach (var t in boxes) t.ForeColor = Color.Black;
        }

        private void SetPlaceholder(TextBox txt, string placeholder)
        {
            txt.Text = placeholder;
            txt.ForeColor = Color.Gray;

            txt.GotFocus += (s, e) => {
                if (txt.Text == placeholder) { txt.Text = ""; txt.ForeColor = Color.Black; }
            };
            txt.LostFocus += (s, e) => {
                if (string.IsNullOrWhiteSpace(txt.Text)) { txt.Text = placeholder; txt.ForeColor = Color.Gray; }
            };
        }

        private void ClearFields()
        {
            InitializePlaceholders();
        }

        private void btnBack_Click(object sender, EventArgs e) => this.Close();
    }
}