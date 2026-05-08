// FIX: RefereeId column is now hidden in the grid (was visible raw FK).
// FIX: RefereeId is NOT passed to Add() — it is an IDENTITY column.
// FIX: Success MessageBoxes added with icons.
// FIX: Removed dead empty handler 'txtid_TextChanged_1'.
// FIX: Removed unused 'using System.Xml.Linq' import.
// FIX: Removed duplicate LoadReferees() call from Load event.
// NEW: Calls UIHelper for styling and SetPlaceholder.

using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using System;
using System.Windows.Forms;

namespace EPL_DBMS.Forms
{
    public partial class RefereesForm : Form
    {
        public RefereesForm()
        {
            InitializeComponent();

            ApplyModernStyling();

            txtid.TextChanged += txtid_TextChanged;
            LoadReferees();

            UIHelper.SetPlaceholder(txtname,        "Referee Name");
            UIHelper.SetPlaceholder(txtnationality, "Nationality");
            UIHelper.SetPlaceholder(txtid,          "ENTER REFEREE ID");
            txtid.ForeColor = System.Drawing.Color.Black;
        }

        private void ApplyModernStyling()
        {
            this.BackColor = UIHelper.SurfaceColor;
            this.Font      = new System.Drawing.Font("Segoe UI", 9f);

            UIHelper.StyleGrid(dataGridViewReferees);

            UIHelper.StyleButton(btnAdd,    UIHelper.SuccessColor);
            UIHelper.StyleButton(btnUpdate, UIHelper.PrimaryAccent);
            UIHelper.StyleButton(btnDelete, UIHelper.DangerColor);
            UIHelper.StyleButton(btnBack,   System.Drawing.Color.FromArgb(108, 117, 125));
        }

        private void LoadReferees()
        {
            try
            {
                var referees = RefereeRepository.GetAllReferees();
                dataGridViewReferees.DataSource = referees;

                // FIX: RefereeId was visible as a raw FK — now hidden
                if (dataGridViewReferees.Columns["RefereeId"] != null)
                    dataGridViewReferees.Columns["RefereeId"].Visible = false;

                // NEW: Friendly headers
                if (dataGridViewReferees.Columns["RefereeName"] != null)
                    dataGridViewReferees.Columns["RefereeName"].HeaderText = "Referee";
                if (dataGridViewReferees.Columns["Nationality"] != null)
                    dataGridViewReferees.Columns["Nationality"].HeaderText = "Nationality";

                dataGridViewReferees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading referees: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtid.Text, out int id)) return;

            var referee = RefereeRepository.GetById(id);
            if (referee != null)
            {
                txtname.Text        = referee.RefereeName;
                txtnationality.Text = referee.Nationality;

                txtname.ForeColor        = System.Drawing.Color.Black;
                txtnationality.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // FIX: Validation before any parsing
            if (string.IsNullOrWhiteSpace(txtname.Text) || txtname.Text == "Referee Name")
            {
                MessageBox.Show("Please enter a referee name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var r = new Referee
                {
                    // FIX: Do NOT set RefereeId — it is an IDENTITY column.
                    // Old code passed int.Parse(txtid.Text) which is wrong.
                    RefereeName = txtname.Text.Trim(),
                    Nationality = txtnationality.Text.Trim()
                };

                RefereeRepository.Add(r);

                // FIX: Added success message (was silent)
                MessageBox.Show("Referee added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReferees();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding referee: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewReferees.CurrentRow == null) return;

            if (!int.TryParse(txtid.Text, out int id))
            {
                MessageBox.Show("Please select a valid referee first.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var r = new Referee
                {
                    RefereeId   = id,
                    RefereeName = txtname.Text.Trim(),
                    Nationality = txtnationality.Text.Trim()
                };

                RefereeRepository.Update(r);

                // FIX: Added success message + icon
                MessageBox.Show("Referee updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReferees();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating referee: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewReferees.CurrentRow == null) return;

            if (!int.TryParse(txtid.Text, out int id))
            {
                MessageBox.Show("Please select a valid referee first.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this referee?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                RefereeRepository.Delete(id);

                // FIX: Added success message + icon
                MessageBox.Show("Referee deleted.", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReferees();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting referee: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewReferees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewReferees.CurrentRow;
            txtid.Text          = row.Cells["RefereeId"].Value.ToString();
            txtname.Text        = row.Cells["RefereeName"].Value.ToString();
            txtnationality.Text = row.Cells["Nationality"].Value.ToString();

            txtid.ForeColor          = System.Drawing.Color.Black;
            txtname.ForeColor        = System.Drawing.Color.Black;
            txtnationality.ForeColor = System.Drawing.Color.Black;
        }

        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        // FIX: Removed duplicate LoadReferees() call — constructor already calls it
        private void RefereesForm_Load(object sender, EventArgs e) { }

        // FIX: Removed dead empty handler txtid_TextChanged_1 — was a Designer artifact

        private void ClearFields()
        {
            txtname.Clear();
            txtnationality.Clear();
            txtid.Clear();
        }
    }
}
