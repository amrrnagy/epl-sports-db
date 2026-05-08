using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EPL_DBMS.Forms
{
    public partial class MatchesForm : Form
    {
        private List<Team> _teams;

        public MatchesForm()
        {
            InitializeComponent();
            LoadMatchesGrid();
            LoadTeams();

            matchid.BackColor = Color.LightGray;
            matchid.ForeColor = Color.Gray;
            SetPlaceholder(matchid, "ENTER MATCH ID");
            SetPlaceholder(stadium,  "Stadium ID");
            SetPlaceholder(referee,  "Referee ID");
            SetPlaceholder(attend,   "Attendance");
            SetPlaceholder(Hgoals,   "Home Goals");
            SetPlaceholder(Agoals,   "Away Goals");
        }

        // ── Grid loading ────────────────────────────────────────────────────────

        private void LoadMatchesGrid()
        {
            try
            {
                // ── CHANGED: call the ViewModel method (four INNER JOINs in SQL) ──
                var data = MatchRepository.GetAllMatchesForGrid();
                var dgv  = dataGridViewMatches;
                dgv.DataSource = data;

                // ── Hide ALL raw FK ID columns ───────────────────────────────
                dgv.Columns["HomeTeamId"].Visible = false;
                dgv.Columns["AwayTeamId"].Visible = false;
                dgv.Columns["StadiumId"].Visible  = false;
                dgv.Columns["RefereeId"].Visible  = false;

                // ── Format the ViewModel name columns ────────────────────────
                dgv.Columns["HomeTeamName"].HeaderText   = "Home Team";
                dgv.Columns["HomeTeamName"].DisplayIndex = 1;   // After Match ID
                dgv.Columns["AwayTeamName"].HeaderText   = "Away Team";
                dgv.Columns["AwayTeamName"].DisplayIndex = 2;
                dgv.Columns["StadiumName"].HeaderText    = "Stadium";
                dgv.Columns["RefereeName"].HeaderText    = "Referee";

                // ── Format the base columns ──────────────────────────────────
                dgv.Columns["MatchId"].HeaderText    = "ID";
                dgv.Columns["MatchId"].DisplayIndex  = 0;
                dgv.Columns["MatchDate"].HeaderText  = "Date";
                dgv.Columns["HomeGoals"].HeaderText  = "Home Goals";
                dgv.Columns["AwayGoals"].HeaderText  = "Away Goals";
                dgv.Columns["Attendance"].HeaderText = "Attendance";

                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Matches: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── ComboBox population (unchanged — uses raw Team list) ────────────────

        private void LoadTeams()
        {
            _teams = TeamRepository.GetAllTeams();

            cmbHomeTeam.DataSource     = _teams;
            cmbHomeTeam.DisplayMember  = "DisplayText";
            cmbHomeTeam.ValueMember    = "TeamId";

            // Use a separate list instance so both combos are independent
            cmbAwayTeam.DataSource     = new List<Team>(_teams);
            cmbAwayTeam.DisplayMember  = "DisplayText";
            cmbAwayTeam.ValueMember    = "TeamId";
        }

        // ── Search ──────────────────────────────────────────────────────────────

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(matchid.Text, out int id))
            {
                MessageBox.Show("Enter a valid Match ID.");
                return;
            }

            // ── CHANGED: use GetMatchViewById so the comboboxes can be set ──
            var match = MatchRepository.GetById(id);

            if (match == null)
            {
                MessageBox.Show("Match not found.");
                return;
            }

            matchid.Text  = match.MatchId.ToString();
            dateTime.Value = match.MatchDate;

            cmbHomeTeam.SelectedValue = match.HomeTeamId;
            cmbAwayTeam.SelectedValue = match.AwayTeamId;

            stadium.Text = match.StadiumId.ToString();
            referee.Text = match.RefereeId.ToString();
            Hgoals.Text  = match.HomeGoals.ToString();
            Agoals.Text  = match.AwayGoals.ToString();
            attend.Text  = match.Attendance.ToString();
            SetAllTextBlack();
        }

        // ── CRUD operations (unchanged — work with Match model) ─────────────────

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Hgoals.Text, out int homeGoals) ||
                !int.TryParse(Agoals.Text, out int awayGoals))
            {
                MessageBox.Show("Enter valid goals!");
                return;
            }

            if (cmbHomeTeam.SelectedValue.Equals(cmbAwayTeam.SelectedValue))
            {
                MessageBox.Show("Teams cannot be the same!");
                return;
            }

            var m = new Match
            {
                MatchDate  = dateTime.Value,
                HomeTeamId = (int)cmbHomeTeam.SelectedValue,
                AwayTeamId = (int)cmbAwayTeam.SelectedValue,
                StadiumId  = int.Parse(stadium.Text),
                RefereeId  = int.Parse(referee.Text),
                HomeGoals  = int.Parse(Hgoals.Text),
                AwayGoals  = int.Parse(Agoals.Text),
                Attendance = int.Parse(attend.Text)
            };

            MatchRepository.Add(m);
            MessageBox.Show("Match Added!");
            LoadMatchesGrid();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (matchid.Text == "" || matchid.Text == "ENTER MATCH ID")
            {
                MessageBox.Show("Select a match first.");
                return;
            }

            var m = new Match
            {
                MatchId    = int.Parse(matchid.Text),
                MatchDate  = dateTime.Value,
                HomeTeamId = (int)cmbHomeTeam.SelectedValue,
                AwayTeamId = (int)cmbAwayTeam.SelectedValue,
                StadiumId  = int.Parse(stadium.Text),
                RefereeId  = int.Parse(referee.Text),
                HomeGoals  = int.Parse(Hgoals.Text),
                AwayGoals  = int.Parse(Agoals.Text),
                Attendance = int.Parse(attend.Text)
            };

            MatchRepository.Update(m);
            MessageBox.Show("Updated!");
            LoadMatchesGrid();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(matchid.Text)) return;

            MatchRepository.Delete(int.Parse(matchid.Text));
            MessageBox.Show("Deleted!");
            LoadMatchesGrid();
        }

        // ── Row click — populate input fields from the ViewModel row ────────────
        // Hidden columns (HomeTeamId, AwayTeamId etc.) are still accessible in code.

        private void dataGridViewMatches_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewMatches.CurrentRow;

            matchid.Text   = row.Cells["MatchId"].Value.ToString();
            dateTime.Value = (DateTime)row.Cells["MatchDate"].Value;

            // These are hidden but still readable — set the comboboxes correctly
            cmbHomeTeam.SelectedValue = row.Cells["HomeTeamId"].Value;
            cmbAwayTeam.SelectedValue = row.Cells["AwayTeamId"].Value;

            stadium.Text = row.Cells["StadiumId"].Value.ToString();
            referee.Text = row.Cells["RefereeId"].Value.ToString();
            Hgoals.Text  = row.Cells["HomeGoals"].Value.ToString();
            Agoals.Text  = row.Cells["AwayGoals"].Value.ToString();
            attend.Text  = row.Cells["Attendance"].Value.ToString();
            SetAllTextBlack();
        }

        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        // ── Placeholder helpers (unchanged) ─────────────────────────────────────

        private void SetPlaceholder(TextBox txt, string placeholder)
        {
            txt.Text      = placeholder;
            txt.ForeColor = Color.Gray;

            txt.GotFocus += (s, ev) =>
            {
                if (txt.Text == placeholder) { txt.Text = ""; txt.ForeColor = Color.Black; }
            };
            txt.LostFocus += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text)) { txt.Text = placeholder; txt.ForeColor = Color.Gray; }
            };
        }

        private void ClearFields()
        {
            SetPlaceholder(matchid,  "ENTER MATCH ID");
            SetPlaceholder(stadium,  "Stadium ID");
            SetPlaceholder(referee,  "Referee ID");
            SetPlaceholder(attend,   "Attendance");
            SetPlaceholder(Hgoals,   "Home Goals");
            SetPlaceholder(Agoals,   "Away Goals");
        }

        private void SetAllTextBlack()
        {
            foreach (var txt in new[] { matchid, stadium, referee, attend, Hgoals, Agoals })
                txt.ForeColor = Color.Black;
        }

        // ── Empty designer event stubs (required by Designer.cs) ────────────────
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void referee_TextChanged(object sender, EventArgs e) { }
        private void date_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}
