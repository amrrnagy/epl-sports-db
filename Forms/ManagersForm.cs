using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;   // NEW: For UIHelper
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EPL_DBMS.Forms
{
    public partial class ManagersForm : Form
    {
        // NEW: Store the loaded teams list so we can resolve cmbTeam.SelectedValue -> TeamId.
        private List<Team> _teams;

        public ManagersForm()
        {
            InitializeComponent();

            // NEW: Apply modern styling via UIHelper
            ApplyModernStyling();

            // NEW: Populate the Team ComboBox BEFORE loading the grid
            LoadTeamComboBox();

            LoadManagers();
            InitializePlaceholders();

            dataGridViewManagers.CellClick       += dataGridViewManagers_CellClick;
            dataGridViewManagers.CellDoubleClick += DataGridViewManagers_CellDoubleClick;
        }

        // ── NEW: Apply modern look to all controls ──────────────────────────────
        private void ApplyModernStyling()
        {
            this.BackColor = UIHelper.SurfaceColor;
            this.Font      = new Font("Segoe UI", 9f);

            UIHelper.StyleGrid(dataGridViewManagers);

            UIHelper.StyleButton(btnAdd,    UIHelper.SuccessColor);
            UIHelper.StyleButton(btnUpdate, UIHelper.PrimaryAccent);
            UIHelper.StyleButton(btnDelete, UIHelper.DangerColor);
            UIHelper.StyleButton(search,    UIHelper.PrimaryAccent);
            UIHelper.StyleButton(btnBack,   Color.FromArgb(108, 117, 125));
        }

        // ── NEW: Replace txtteamid with a ComboBox populated from the database ──
        // FIX: Previously users had to guess raw Team IDs. Now they pick a name.
        private void LoadTeamComboBox()
        {
            _teams = TeamRepository.GetAllTeams();
            cmbTeam.DataSource    = _teams;
            cmbTeam.DisplayMember = "TeamName";
            cmbTeam.ValueMember   = "TeamId";
            cmbTeam.SelectedIndex = -1;  // Start with nothing selected
        }

        private void LoadManagers()
        {
            try
            {
                var data = ManagerRepository.GetAllManagersForGrid();
                dataGridViewManagers.DataSource = data;

                if (dataGridViewManagers.Columns["ManagerId"] != null)
                    dataGridViewManagers.Columns["ManagerId"].Visible = false;

                if (dataGridViewManagers.Columns["TeamId"] != null)
                    dataGridViewManagers.Columns["TeamId"].Visible = false;

                if (dataGridViewManagers.Columns["TeamName"] != null)
                    dataGridViewManagers.Columns["TeamName"].HeaderText = "Current Club";

                dataGridViewManagers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                // FIX: Added MessageBoxIcon.Error for proper visual feedback
                MessageBox.Show("Error loading managers: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializePlaceholders()
        {
            // FIX: Now calls UIHelper.SetPlaceholder — no duplicate code
            UIHelper.SetPlaceholder(txtname,           "Full Name");
            UIHelper.SetPlaceholder(txtnationality,    "Nationality");
            UIHelper.SetPlaceholder(txtformation,      "e.g. 4-3-3");
            UIHelper.SetPlaceholder(txtexperienceyear, "Experience Years");
            UIHelper.SetPlaceholder(txtid,             "ENTER MANAGER ID");

            // NEW: Reset the ComboBox as well when clearing
            cmbTeam.SelectedIndex = -1;
        }

        // ── CRUD ─────────────────────────────────────────────────────────────────

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                var m = new Manager
                {
                    ManagerName        = txtname.Text.Trim(),
                    Nationality        = txtnationality.Text.Trim(),
                    PreferredFormation = txtformation.Text.Trim(),
                    ExperienceYears    = int.Parse(txtexperienceyear.Text),
                    // FIX: Read TeamId from cmbTeam.SelectedValue, not a TextBox
                    TeamId             = (int)cmbTeam.SelectedValue
                };

                ManagerRepository.Add(m);

                // FIX: Added MessageBoxIcon.Information for success feedback
                MessageBox.Show("Manager added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Rule Violation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(this.txtid.Text, out int managerIdSearch))
            {
                MessageBox.Show("Please select or search for a manager first.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs()) return;

            try
            {
                var m = new Manager
                {
                    ManagerId          = managerIdSearch,
                    ManagerName        = txtname.Text.Trim(),
                    Nationality        = txtnationality.Text.Trim(),
                    PreferredFormation = txtformation.Text.Trim(),
                    ExperienceYears    = int.Parse(txtexperienceyear.Text),
                    // FIX: Read TeamId from cmbTeam.SelectedValue
                    TeamId             = (int)cmbTeam.SelectedValue
                };

                ManagerRepository.Update(m);

                // FIX: Added proper icon
                MessageBox.Show("Manager updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating manager: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(this.txtid.Text, out int managerIdSearch))
            {
                MessageBox.Show("Select a valid manager first.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // FIX: Added icon to confirmation dialog
            var confirm = MessageBox.Show(
                "Are you sure you want to permanently delete this manager?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    ManagerRepository.Delete(managerIdSearch);
                    MessageBox.Show("Manager deleted.", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshUI();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting manager: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ── Search ────────────────────────────────────────────────────────────

        private void search_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(this.txtid.Text, out int searchId))
            {
                MessageBox.Show("Enter a valid Manager ID.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var manager = ManagerRepository.GetById(searchId);
            if (manager == null)
            {
                MessageBox.Show("Manager not found.", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PopulateFields(manager);

            foreach (DataGridViewRow row in dataGridViewManagers.Rows)
            {
                if (row.Cells["ManagerId"].Value != null &&
                    (int)row.Cells["ManagerId"].Value == searchId)
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

            int    mId   = (int)dataGridViewManagers.Rows[e.RowIndex].Cells["ManagerId"].Value;
            string mName = dataGridViewManagers.Rows[e.RowIndex].Cells["ManagerName"].Value.ToString();

            var history = ManagerPreviousTeamRepository.GetViewByManagerId(mId);
            if (history.Count == 0)
            {
                MessageBox.Show($"{mName} has no previous team history.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var historyForm = new ManagerPreviousTeamsForm(mId, mName))
            {
                // FIX: Wrapped in using block to ensure proper disposal
                historyForm.ShowDialog();
            }
        }

        private void dataGridViewManagers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewManagers.CurrentRow;

            this.txtid.Text         = row.Cells["ManagerId"].Value.ToString();
            txtname.Text            = row.Cells["ManagerName"].Value.ToString();
            txtformation.Text       = row.Cells["PreferredFormation"].Value.ToString();
            txtnationality.Text     = row.Cells["Nationality"].Value.ToString();
            txtexperienceyear.Text  = row.Cells["ExperienceYears"].Value.ToString();

            // FIX: Set cmbTeam by TeamId (hidden column), not by a TextBox
            cmbTeam.SelectedValue = row.Cells["TeamId"].Value;

            SetAllTextBlack();
        }

        // ── Helpers ──────────────────────────────────────────────────────────

        private void PopulateFields(Manager m)
        {
            txtname.Text            = m.ManagerName;
            txtformation.Text       = m.PreferredFormation;
            txtnationality.Text     = m.Nationality;
            txtexperienceyear.Text  = m.ExperienceYears.ToString();

            // FIX: Set ComboBox by value instead of putting a raw ID in a TextBox
            cmbTeam.SelectedValue = m.TeamId;

            SetAllTextBlack();
        }

        private void RefreshUI()
        {
            LoadManagers();
            InitializePlaceholders();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtname.Text)           || txtname.Text == "Full Name" ||
                string.IsNullOrWhiteSpace(txtnationality.Text)    || txtnationality.Text == "Nationality" ||
                string.IsNullOrWhiteSpace(txtformation.Text)      || txtformation.Text == "e.g. 4-3-3" ||
                string.IsNullOrWhiteSpace(txtexperienceyear.Text) || txtexperienceyear.Text == "Experience Years")
            {
                MessageBox.Show("Please fill all required fields.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtexperienceyear.Text, out _))
            {
                MessageBox.Show("Experience Years must be a valid number.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // NEW: Validate that a team is actually selected in the ComboBox
            if (cmbTeam.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a team from the dropdown.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void SetAllTextBlack()
        {
            TextBox[] boxes = { txtname, txtnationality, txtformation, txtexperienceyear, txtid };
            foreach (var t in boxes) t.ForeColor = Color.Black;
        }

        private void btnBack_Click(object sender, EventArgs e) => this.Close();
    }
}
