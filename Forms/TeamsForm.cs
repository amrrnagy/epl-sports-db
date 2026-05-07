using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;
using System;
using System.Windows.Forms;

namespace EPL_DBMS.Forms
{
    public partial class TeamsForm : Form
    {
        public TeamsForm()
        {
            InitializeComponent();
            txtid.TextChanged += txtid_TextChanged;
            LoadTeamsGrid();
            Placeholder(txtname,      "Name");
            Placeholder(txtfounded,   "Founded");
            Placeholder(txtkitcolor,  "Kit Color");
            Placeholder(txtstadiumid, "Stadium ID");
            Placeholder(txtid,        "ENTER Team ID");
            txtid.ForeColor = System.Drawing.Color.Black;
        }

        // ── Grid loading ─────────────────────────────────────────────────────────

        private void LoadTeamsGrid()
        {
            try
            {
                // ── CHANGED: call the ViewModel method (INNER JOIN in SQL) ──
                var teams = TeamRepository.GetAllTeamsForGrid();
                dataGridViewTeams.DataSource = teams;

                // ── Hide raw FK ID column ─────────────────────────────────────
                dataGridViewTeams.Columns["TeamId"].Visible    = false;
                dataGridViewTeams.Columns["StadiumId"].Visible = false;

                // ── Format the ViewModel name column ─────────────────────────
                dataGridViewTeams.Columns["StadiumName"].HeaderText   = "Stadium";
                dataGridViewTeams.Columns["StadiumName"].DisplayIndex = 3; // After kit color

                // ── Format the base columns ───────────────────────────────────
                dataGridViewTeams.Columns["TeamName"].HeaderText    = "Club";
                dataGridViewTeams.Columns["YearFounded"].HeaderText = "Founded";
                dataGridViewTeams.Columns["HomeKitColor"].HeaderText = "Kit Color";

                // Hide the computed helper property — users don't need to see it
                if (dataGridViewTeams.Columns.Contains("DisplayText"))
                    dataGridViewTeams.Columns["DisplayText"].Visible = false;

                dataGridViewTeams.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading teams: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Auto-fill fields when a Team ID is typed ─────────────────────────────

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtid.Text, out int id)) return;

            var team = TeamRepository.GetById(id);

                if (team != null)
                {
                    txtname.Text = team.TeamName;
                    txtfounded.Text = team.YearFounded.ToString();
                    txtkitcolor.Text = team.HomeKitColor;
                    txtstadiumid.Text = team.StadiumId.ToString();

                    // make txt black
                    txtname.ForeColor = System.Drawing.Color.Black;
                    txtfounded.ForeColor = System.Drawing.Color.Black;
                    txtkitcolor.ForeColor = System.Drawing.Color.Black;
                    txtstadiumid.ForeColor = System.Drawing.Color.Black;

                }

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

        // ── Row click — populate input fields (hidden IDs still readable) ─────────

        private void dataGridViewTeams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewTeams.CurrentRow;

            // TeamId and StadiumId are hidden (Visible=false) but still accessible
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

        // ── Double-click — open Team Stats for this team ─────────────────────────

        private void dataGridViewTeams_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int    teamId   = (int)dataGridViewTeams.Rows[e.RowIndex].Cells["TeamId"].Value;
            string teamName = dataGridViewTeams.Rows[e.RowIndex].Cells["TeamName"].Value.ToString();

            // Pass the teamId so TeamStatsForm uses its contextual SQL WHERE constructor
            var statsForm = new TeamStatsForm(teamId, teamName);
            statsForm.ShowDialog();
        }

        // ── CRUD operations (unchanged — work with base Team model) ───────────────

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var t = new Team
                {
                    TeamName     = txtname.Text,
                    YearFounded  = int.Parse(txtfounded.Text),
                    HomeKitColor = txtkitcolor.Text,
                    StadiumId    = int.Parse(txtstadiumid.Text)
                };
                TeamRepository.Add(t);
                LoadTeamsGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding team: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTeams.CurrentRow == null) return;

                var t = new Team
                {
                    TeamId       = int.Parse(txtid.Text),
                    TeamName     = txtname.Text,
                    YearFounded  = int.Parse(txtfounded.Text),
                    HomeKitColor = txtkitcolor.Text,
                    StadiumId    = int.Parse(txtstadiumid.Text)
                };
                TeamRepository.Update(t);
                LoadTeamsGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Team: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTeams.CurrentRow == null) return;
                TeamRepository.Delete(int.Parse(txtid.Text));
                LoadTeamsGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting Team: " + ex.Message);
            }
        }

        // ── Helpers ──────────────────────────────────────────────────────────────

        private void Placeholder(TextBox txt, string placeholder)
        {
            txt.Text      = placeholder;
            txt.ForeColor = System.Drawing.Color.Gray;

            txt.GotFocus += (s, e) =>
            {
                if (txt.Text == placeholder) { txt.Text = ""; txt.ForeColor = System.Drawing.Color.Black; }
            };
            txt.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text)) { txt.Text = placeholder; txt.ForeColor = System.Drawing.Color.Gray; }
            };
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
                MessageBox.Show("Please select a player from the table first.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int TeamId = (int)dataGridViewTeams.CurrentRow.Cells["TeamId"].Value;
            string TeamName = dataGridViewTeams.CurrentRow.Cells["TeamName"].Value.ToString();

            // 1. Ask the database FIRST
            var stats = TeamStatRepository.GetStatsByTeamId(TeamId);

            // 2. If it's empty, show the message and STOP. The form never opens!
            if (stats == null || stats.Count == 0)
            {
                MessageBox.Show($"{TeamName} has no match statistics recorded.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 3. If we made it here, they have stats. Open the form!
            NavigateTo(new PlayerStatsForm(TeamId, TeamName));
        }

        private void NavigateTo(Form childForm)
        {
            txtname.Clear();
            txtkitcolor.Clear();
            txtfounded.Clear();
            txtstadiumid.Clear();
            txtid.Clear();
            this.Hide();

            using (childForm)
            {
                childForm.ShowDialog();
            }

            this.Show();
        }
    }
}
