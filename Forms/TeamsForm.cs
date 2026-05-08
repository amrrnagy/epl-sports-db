// FIX: btnTeamStats_Click was opening PlayerStatsForm — now opens TeamStatsForm.
// FIX: Duplicate block in txtid_TextChanged removed.
// FIX: Success MessageBoxes added to Add/Update/Delete with correct icons.
// FIX: Validation added before int.Parse calls in btnAdd_Click.
// NEW: Calls UIHelper for styling and SetPlaceholder.
// FIX: Wrong "player" text in btnTeamStats_Click message corrected.

using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using System;
using System.Windows.Forms;

namespace EPL_DBMS.Forms
{
    public partial class TeamsForm : Form
    {
        public TeamsForm()
        {
            InitializeComponent();

            // NEW: Modern styling
            ApplyModernStyling();

            txtid.TextChanged += txtid_TextChanged;
            LoadTeamsGrid();

            // FIX: Now calls UIHelper — no duplicate Placeholder method needed
            UIHelper.SetPlaceholder(txtname,      "Club Name");
            UIHelper.SetPlaceholder(txtfounded,   "Year Founded");
            UIHelper.SetPlaceholder(txtkitcolor,  "Kit Color");
            UIHelper.SetPlaceholder(txtstadiumid, "Stadium ID");
            UIHelper.SetPlaceholder(txtid,        "ENTER TEAM ID");
            txtid.ForeColor = System.Drawing.Color.Black;
        }

        private void ApplyModernStyling()
        {
            this.BackColor = UIHelper.SurfaceColor;
            this.Font      = new System.Drawing.Font("Segoe UI", 9f);

            UIHelper.StyleGrid(dataGridViewTeams);

            UIHelper.StyleButton(btnAdd,      UIHelper.SuccessColor);
            UIHelper.StyleButton(btnUpdate,   UIHelper.PrimaryAccent);
            UIHelper.StyleButton(btnDelete,   UIHelper.DangerColor);
            UIHelper.StyleButton(btnBack,     System.Drawing.Color.FromArgb(108, 117, 125));
            UIHelper.StyleButton(btnTeamStats, UIHelper.PrimaryAccent);
        }

        private void LoadTeamsGrid()
        {
            try
            {
                var teams = TeamRepository.GetAllTeamsForGrid();
                dataGridViewTeams.DataSource = teams;

                dataGridViewTeams.Columns["TeamId"].Visible    = false;
                dataGridViewTeams.Columns["StadiumId"].Visible = false;

                dataGridViewTeams.Columns["StadiumName"].HeaderText   = "Stadium";
                dataGridViewTeams.Columns["StadiumName"].DisplayIndex = 3;
                dataGridViewTeams.Columns["TeamName"].HeaderText      = "Club";
                dataGridViewTeams.Columns["YearFounded"].HeaderText   = "Founded";
                dataGridViewTeams.Columns["HomeKitColor"].HeaderText  = "Kit Color";

                if (dataGridViewTeams.Columns.Contains("DisplayText"))
                    dataGridViewTeams.Columns["DisplayText"].Visible = false;

                dataGridViewTeams.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading teams: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtid.Text, out int id)) return;

            var team = TeamRepository.GetById(id);

            // FIX: Removed the duplicate inner block — was copy-pasted twice before
            if (team != null)
            {
                txtname.Text      = team.TeamName;
                txtfounded.Text   = team.YearFounded.ToString();
                txtkitcolor.Text  = team.HomeKitColor;
                txtstadiumid.Text = team.StadiumId.ToString();

                txtname.ForeColor      = System.Drawing.Color.Black;
                txtfounded.ForeColor   = System.Drawing.Color.Black;
                txtkitcolor.ForeColor  = System.Drawing.Color.Black;
                txtstadiumid.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtname.Clear(); txtfounded.Clear(); txtkitcolor.Clear(); txtstadiumid.Clear();
                MessageBox.Show("No team found with ID: " + id, "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewTeams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewTeams.CurrentRow;

            txtid.Text         = row.Cells["TeamId"].Value.ToString();
            txtname.Text       = row.Cells["TeamName"].Value.ToString();
            txtfounded.Text    = row.Cells["YearFounded"].Value.ToString();
            txtkitcolor.Text   = row.Cells["HomeKitColor"].Value.ToString();
            txtstadiumid.Text  = row.Cells["StadiumId"].Value.ToString();

            txtid.ForeColor        = System.Drawing.Color.Black;
            txtname.ForeColor      = System.Drawing.Color.Black;
            txtfounded.ForeColor   = System.Drawing.Color.Black;
            txtkitcolor.ForeColor  = System.Drawing.Color.Black;
            txtstadiumid.ForeColor = System.Drawing.Color.Black;
        }

        private void dataGridViewTeams_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int    teamId   = (int)dataGridViewTeams.Rows[e.RowIndex].Cells["TeamId"].Value;
            string teamName = dataGridViewTeams.Rows[e.RowIndex].Cells["TeamName"].Value.ToString();

            using (var statsForm = new TeamStatsForm(teamId, teamName))
                statsForm.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // FIX: Added validation before parsing — was raw int.Parse (crash risk)
            if (string.IsNullOrWhiteSpace(txtname.Text) || txtname.Text == "Club Name")
            {
                MessageBox.Show("Please enter a team name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtfounded.Text, out int founded) ||
                !int.TryParse(txtstadiumid.Text, out int stadiumId))
            {
                MessageBox.Show("Year Founded and Stadium ID must be valid numbers.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var t = new Team
                {
                    TeamName     = txtname.Text.Trim(),
                    YearFounded  = founded,
                    HomeKitColor = txtkitcolor.Text.Trim(),
                    StadiumId    = stadiumId
                };
                TeamRepository.Add(t);

                // FIX: Added success message (was silent before)
                MessageBox.Show("Team added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTeamsGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                // FIX: Added icon to error message
                MessageBox.Show("Error adding team: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewTeams.CurrentRow == null) return;

            if (!int.TryParse(txtfounded.Text, out int founded) ||
                !int.TryParse(txtstadiumid.Text, out int stadiumId))
            {
                MessageBox.Show("Year Founded and Stadium ID must be valid numbers.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var t = new Team
                {
                    TeamId       = int.Parse(txtid.Text),
                    TeamName     = txtname.Text.Trim(),
                    YearFounded  = founded,
                    HomeKitColor = txtkitcolor.Text.Trim(),
                    StadiumId    = stadiumId
                };
                TeamRepository.Update(t);

                // FIX: Added success message + icon
                MessageBox.Show("Team updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTeamsGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating team: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTeams.CurrentRow == null) return;

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this team? This may affect related players and matches.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                TeamRepository.Delete(int.Parse(txtid.Text));

                // FIX: Added success message + icon
                MessageBox.Show("Team deleted.", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTeamsGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting team: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtname.Clear(); txtkitcolor.Clear(); txtfounded.Clear();
            txtstadiumid.Clear(); txtid.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        private void TeamsForm_Load(object sender, EventArgs e) => LoadTeamsGrid();

        private void btnTeamStats_Click(object sender, EventArgs e)
        {
            if (dataGridViewTeams.CurrentRow == null)
            {
                // FIX: Message previously said "player" — corrected to "team"
                MessageBox.Show("Please select a team from the table first.",
                    "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int    teamId   = (int)dataGridViewTeams.CurrentRow.Cells["TeamId"].Value;
            string teamName = dataGridViewTeams.CurrentRow.Cells["TeamName"].Value.ToString();

            var stats = TeamStatRepository.GetStatsByTeamId(teamId);
            if (stats == null || stats.Count == 0)
            {
                MessageBox.Show($"{teamName} has no match statistics recorded.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // FIX: Was NavigateTo(new PlayerStatsForm(...)) — WRONG form!
            NavigateTo(new TeamStatsForm(teamId, teamName));
        }

        private void NavigateTo(Form childForm)
        {
            ClearFields();
            this.Hide();
            using (childForm)
            {
                childForm.ShowDialog();
            }
            this.Show();
        }
    }
}
