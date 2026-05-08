// FIX: 'stadium' and 'referee' TextBoxes replaced with cmbStadium and cmbReferee ComboBoxes.
// FIX: All MessageBox success/error calls now have appropriate icons.
// FIX: btnDelete_Click now requires confirmation before deleting.
// NEW: Calls UIHelper for styling and SetPlaceholder.

using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EPL_DBMS.Forms
{
    public partial class MatchesForm : Form
    {
        private List<Team>    _teams;
        private List<Stadium> _stadiums;   // NEW
        private List<Referee> _referees;   // NEW

        public MatchesForm()
        {
            InitializeComponent();

            ApplyModernStyling();

            LoadMatchesGrid();
            LoadTeams();
            LoadStadiumComboBox();    // NEW
            LoadRefereeComboBox();    // NEW

            UIHelper.SetPlaceholder(matchid, "ENTER MATCH ID");
            UIHelper.SetPlaceholder(attend,  "Attendance");
            UIHelper.SetPlaceholder(Hgoals,  "Home Goals");
            UIHelper.SetPlaceholder(Agoals,  "Away Goals");
        }

        private void ApplyModernStyling()
        {
            this.BackColor = UIHelper.SurfaceColor;
            this.Font      = new Font("Segoe UI", 9f);

            UIHelper.StyleGrid(dataGridViewMatches);

            UIHelper.StyleButton(btnAdd,    UIHelper.SuccessColor);
            UIHelper.StyleButton(btnUpdate, UIHelper.PrimaryAccent);
            UIHelper.StyleButton(btnDelete, UIHelper.DangerColor);
            UIHelper.StyleButton(btnSearch, UIHelper.PrimaryAccent);
            UIHelper.StyleButton(btnBack,   Color.FromArgb(108, 117, 125));
        }

        private void LoadMatchesGrid()
        {
            try
            {
                var data = MatchRepository.GetAllMatchesForGrid();
                var dgv  = dataGridViewMatches;
                dgv.DataSource = data;

                dgv.Columns["HomeTeamId"].Visible = false;
                dgv.Columns["AwayTeamId"].Visible = false;
                dgv.Columns["StadiumId"].Visible  = false;
                dgv.Columns["RefereeId"].Visible  = false;

                dgv.Columns["HomeTeamName"].HeaderText   = "Home Team";
                dgv.Columns["HomeTeamName"].DisplayIndex = 1;
                dgv.Columns["AwayTeamName"].HeaderText   = "Away Team";
                dgv.Columns["AwayTeamName"].DisplayIndex = 2;
                dgv.Columns["StadiumName"].HeaderText    = "Stadium";
                dgv.Columns["RefereeName"].HeaderText    = "Referee";
                dgv.Columns["MatchId"].HeaderText        = "ID";
                dgv.Columns["MatchId"].DisplayIndex      = 0;
                dgv.Columns["MatchDate"].HeaderText      = "Date";
                dgv.Columns["HomeGoals"].HeaderText      = "Home Goals";
                dgv.Columns["AwayGoals"].HeaderText      = "Away Goals";
                dgv.Columns["Attendance"].HeaderText     = "Attendance";

                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Matches: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTeams()
        {
            _teams = TeamRepository.GetAllTeams();
            cmbHomeTeam.DataSource    = _teams;
            cmbHomeTeam.DisplayMember = "DisplayText";
            cmbHomeTeam.ValueMember   = "TeamId";

            cmbAwayTeam.DataSource    = new List<Team>(_teams);
            cmbAwayTeam.DisplayMember = "DisplayText";
            cmbAwayTeam.ValueMember   = "TeamId";
        }

        // NEW: Load stadiums into ComboBox — replaces raw 'stadium' TextBox
        private void LoadStadiumComboBox()
        {
            _stadiums = StadiumRepository.GetAllStadiums();
            cmbStadium.DataSource    = _stadiums;
            cmbStadium.DisplayMember = "StadiumName";
            cmbStadium.ValueMember   = "StadiumId";
            cmbStadium.SelectedIndex = -1;
        }

        // NEW: Load referees into ComboBox — replaces raw 'referee' TextBox
        private void LoadRefereeComboBox()
        {
            _referees = RefereeRepository.GetAllReferees();
            cmbReferee.DataSource    = _referees;
            cmbReferee.DisplayMember = "RefereeName";
            cmbReferee.ValueMember   = "RefereeId";
            cmbReferee.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(matchid.Text, out int id))
            {
                MessageBox.Show("Enter a valid Match ID.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var match = MatchRepository.GetById(id);
            if (match == null)
            {
                MessageBox.Show("Match not found.", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            matchid.Text          = match.MatchId.ToString();
            dateTime.Value        = match.MatchDate;
            cmbHomeTeam.SelectedValue = match.HomeTeamId;
            cmbAwayTeam.SelectedValue = match.AwayTeamId;
            // FIX: Set ComboBox by value instead of putting raw ID in a TextBox
            cmbStadium.SelectedValue  = match.StadiumId;
            cmbReferee.SelectedValue  = match.RefereeId;
            Hgoals.Text           = match.HomeGoals.ToString();
            Agoals.Text           = match.AwayGoals.ToString();
            attend.Text           = match.Attendance.ToString();
            matchid.ForeColor     = Color.Black;
            Hgoals.ForeColor      = Color.Black;
            Agoals.ForeColor      = Color.Black;
            attend.ForeColor      = Color.Black;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Hgoals.Text, out int homeGoals) ||
                !int.TryParse(Agoals.Text, out int awayGoals) ||
                !int.TryParse(attend.Text, out int attendance))
            {
                MessageBox.Show("Goals and Attendance must be valid numbers.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbHomeTeam.SelectedIndex < 0 || cmbAwayTeam.SelectedIndex < 0)
            {
                MessageBox.Show("Please select both Home and Away teams.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbHomeTeam.SelectedValue.Equals(cmbAwayTeam.SelectedValue))
            {
                MessageBox.Show("Home and Away teams cannot be the same!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // NEW: Validate ComboBox selections
            if (cmbStadium.SelectedIndex < 0 || cmbReferee.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a Stadium and a Referee.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var m = new Match
                {
                    MatchDate  = dateTime.Value,
                    HomeTeamId = (int)cmbHomeTeam.SelectedValue,
                    AwayTeamId = (int)cmbAwayTeam.SelectedValue,
                    // FIX: Read StadiumId and RefereeId from ComboBoxes, not TextBoxes
                    StadiumId  = (int)cmbStadium.SelectedValue,
                    RefereeId  = (int)cmbReferee.SelectedValue,
                    HomeGoals  = homeGoals,
                    AwayGoals  = awayGoals,
                    Attendance = attendance
                };

                MatchRepository.Add(m);

                MessageBox.Show("Match added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMatchesGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding match: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (matchid.Text == "" || matchid.Text == "ENTER MATCH ID")
            {
                MessageBox.Show("Select a match first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(Hgoals.Text, out int homeGoals) ||
                !int.TryParse(Agoals.Text, out int awayGoals) ||
                !int.TryParse(attend.Text, out int attendance))
            {
                MessageBox.Show("Goals and Attendance must be valid numbers.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var m = new Match
                {
                    MatchId    = int.Parse(matchid.Text),
                    MatchDate  = dateTime.Value,
                    HomeTeamId = (int)cmbHomeTeam.SelectedValue,
                    AwayTeamId = (int)cmbAwayTeam.SelectedValue,
                    // FIX: Read from ComboBoxes
                    StadiumId  = (int)cmbStadium.SelectedValue,
                    RefereeId  = (int)cmbReferee.SelectedValue,
                    HomeGoals  = homeGoals,
                    AwayGoals  = awayGoals,
                    Attendance = attendance
                };

                MatchRepository.Update(m);

                MessageBox.Show("Match updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMatchesGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating match: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(matchid.Text) || matchid.Text == "ENTER MATCH ID") return;

            if (!int.TryParse(matchid.Text, out int id)) return;

            // FIX: Added confirmation dialog — was deleting immediately before
            var confirm = MessageBox.Show(
                "Are you sure you want to delete this match?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                MatchRepository.Delete(id);
                MessageBox.Show("Match deleted.", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMatchesGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting match: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewMatches_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewMatches.CurrentRow;

            matchid.Text          = row.Cells["MatchId"].Value.ToString();
            dateTime.Value        = (DateTime)row.Cells["MatchDate"].Value;
            cmbHomeTeam.SelectedValue = row.Cells["HomeTeamId"].Value;
            cmbAwayTeam.SelectedValue = row.Cells["AwayTeamId"].Value;
            // FIX: Set ComboBox by value from hidden column
            cmbStadium.SelectedValue  = row.Cells["StadiumId"].Value;
            cmbReferee.SelectedValue  = row.Cells["RefereeId"].Value;
            Hgoals.Text           = row.Cells["HomeGoals"].Value.ToString();
            Agoals.Text           = row.Cells["AwayGoals"].Value.ToString();
            attend.Text           = row.Cells["Attendance"].Value.ToString();
            matchid.ForeColor     = Color.Black;
            Hgoals.ForeColor      = Color.Black;
            Agoals.ForeColor      = Color.Black;
            attend.ForeColor      = Color.Black;
        }

        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        private void ClearFields()
        {
            UIHelper.SetPlaceholder(matchid, "ENTER MATCH ID");
            UIHelper.SetPlaceholder(attend,  "Attendance");
            UIHelper.SetPlaceholder(Hgoals,  "Home Goals");
            UIHelper.SetPlaceholder(Agoals,  "Away Goals");
            cmbStadium.SelectedIndex = -1;  // NEW
            cmbReferee.SelectedIndex = -1;  // NEW
        }

        // FIX: Removed empty stubs that were cluttering the file
        // private void dateTimePicker1_ValueChanged ... (deleted)
        // private void label1_Click ... (deleted)
        // private void referee_TextChanged ... (deleted — control no longer exists)
        // private void date_Click ... (deleted)
        // private void textBox1_TextChanged ... (deleted)
    }
}
