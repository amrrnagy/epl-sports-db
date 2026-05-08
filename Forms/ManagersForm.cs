using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EPL_DBMS.Forms
{
    public partial class ManagersForm : Form
    {
        private List<Team> _teams;

        public ManagersForm()
        {
            InitializeComponent();

            ApplyModernStyling();
            LoadTeamComboBox();
            LoadManagers();
            InitializePlaceholders();

            dataGridViewManagers.CellClick += dataGridViewManagers_CellClick;
            dataGridViewManagers.CellDoubleClick += DataGridViewManagers_CellDoubleClick;
        }

        private void ApplyModernStyling()
        {
            this.BackColor = UIHelper.SurfaceColor;
            this.Font = new Font("Segoe UI", 9f);

            UIHelper.StyleGrid(dataGridViewManagers);

            UIHelper.StyleButton(btnAdd, UIHelper.SuccessColor);
            UIHelper.StyleButton(btnUpdate, UIHelper.PrimaryAccent);
            UIHelper.StyleButton(btnDelete, UIHelper.DangerColor);
            UIHelper.StyleButton(search, UIHelper.PrimaryAccent);
            UIHelper.StyleButton(btnBack, Color.FromArgb(108, 117, 125));
        }

        private void LoadTeamComboBox()
        {
            _teams = TeamRepository.GetAllTeams();
            cmbTeam.DataSource = _teams;
            cmbTeam.DisplayMember = "TeamName";
            cmbTeam.ValueMember = "TeamId";
            cmbTeam.SelectedIndex = -1;
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
                MessageBox.Show("Error loading managers: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializePlaceholders()
        {
            UIHelper.SetPlaceholder(txtname, "Full Name");
            UIHelper.SetPlaceholder(txtnationality, "Nationality");
            UIHelper.SetPlaceholder(txtformation, "e.g. 4-3-3");
            UIHelper.SetPlaceholder(txtexperienceyear, "Experience Years");
            UIHelper.SetPlaceholder(txtid, "ENTER MANAGER ID");

            cmbTeam.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                var m = new Manager
                {
                    ManagerName = txtname.Text.Trim(),
                    Nationality = txtnationality.Text.Trim(),
                    PreferredFormation = txtformation.Text.Trim(),
                    ExperienceYears = int.Parse(txtexperienceyear.Text),
                    TeamId = (int)cmbTeam.SelectedValue
                };

                ManagerRepository.Add(m);

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
                    ManagerId = managerIdSearch,
                    ManagerName = txtname.Text.Trim(),
                    Nationality = txtnationality.Text.Trim(),
                    PreferredFormation = txtformation.Text.Trim(),
                    ExperienceYears = int.Parse(txtexperienceyear.Text),
                    TeamId = (int)cmbTeam.SelectedValue
                };

                ManagerRepository.Update(m);

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

            int mId = (int)dataGridViewManagers.Rows[e.RowIndex].Cells["ManagerId"].Value;
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
                historyForm.ShowDialog();
            }
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

            cmbTeam.SelectedValue = row.Cells["TeamId"].Value;

            SetAllTextBlack();
        }

        private void PopulateFields(Manager m)
        {
            txtname.Text = m.ManagerName;
            txtformation.Text = m.PreferredFormation;
            txtnationality.Text = m.Nationality;
            txtexperienceyear.Text = m.ExperienceYears.ToString();
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
            if (string.IsNullOrWhiteSpace(txtname.Text) || txtname.Text == "Full Name" ||
                string.IsNullOrWhiteSpace(txtnationality.Text) || txtnationality.Text == "Nationality" ||
                string.IsNullOrWhiteSpace(txtformation.Text) || txtformation.Text == "e.g. 4-3-3" ||
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