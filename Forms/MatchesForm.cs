using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EPL_DBMS.Forms
{
    public partial class MatchesForm : Form
    {
      
        private List<Team> teams;
        public MatchesForm()
        {
            InitializeComponent();
            LoadMatches();
            LoadTeams();


            matchid.BackColor = Color.LightGray;
            matchid.ForeColor = Color.Gray;
            SetPlaceholder(matchid, "ENTER MATCH ID");
            SetPlaceholder(stadium, "Stadium ID");
            SetPlaceholder(referee, "Referee ID");
            SetPlaceholder(attend, "Attendance");
            SetPlaceholder(Hgoals, "Home Goals");
            SetPlaceholder(Agoals, "Away Goals");
        }

        private void LoadMatches()
        {
            try
            {
                var data = MatchRepository.GetAllMatches();
                var dgv  = dataGridViewMatches;
                dgv.DataSource = data;
                dgv.Columns["MatchId"].HeaderText = "ID";
                dgv.Columns["MatchDate"].HeaderText = "Date";
                dgv.Columns["HomeTeamId"].HeaderText = "Home Team";
                dgv.Columns["AwayTeamId"].HeaderText = "Away Team";
                dgv.Columns["StadiumId"].HeaderText = "Stadium";
                dgv.Columns["RefereeId"].HeaderText = "Referee";
                dgv.Columns["HomeGoals"].HeaderText = "Home Goals";
                dgv.Columns["AwayGoals"].HeaderText = "Away Goals";
                dgv.Columns["Attendance"].HeaderText = "Attendance";
                dataGridViewMatches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Matches: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // load them in comboBox
        private void LoadTeams()
        {
           
            teams = TeamRepository.GetAllTeams();
            cmbHomeTeam.DataSource = teams;
            cmbHomeTeam.DisplayMember = "DisplayText";
            cmbHomeTeam.ValueMember = "TeamId";

            cmbAwayTeam.DataSource = teams.ToList();
            cmbAwayTeam.DisplayMember = "DisplayText";
            cmbAwayTeam.ValueMember = "TeamId";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(matchid.Text, out int id))
            {
                MessageBox.Show("Enter valid Match ID");
                return;
            }

            var match = MatchRepository.GetById(id);

            if (match == null)
            {
                MessageBox.Show("Match not found");
                return;
            }

            // fill fields
            matchid.Text = match.MatchId.ToString();
            dateTime.Value = match.MatchDate;

            cmbHomeTeam.SelectedValue = match.HomeTeamId;
            cmbAwayTeam.SelectedValue = match.AwayTeamId;

            stadium.Text = match.StadiumId.ToString();
            referee.Text = match.RefereeId.ToString();
            Hgoals.Text = match.HomeGoals.ToString();
            Agoals.Text = match.AwayGoals.ToString();
            attend.Text = match.Attendance.ToString();
        }


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
                MatchDate = dateTime.Value,
                HomeTeamId = (int)cmbHomeTeam.SelectedValue,
                AwayTeamId = (int)cmbAwayTeam.SelectedValue,
                StadiumId = int.Parse(stadium.Text),
                RefereeId = int.Parse(referee.Text),
                HomeGoals = int.Parse(Hgoals.Text),
                AwayGoals = int.Parse(Agoals.Text),
                Attendance = int.Parse(attend.Text)
            };

            MatchRepository.Add(m);

            MessageBox.Show("Match Added!");
            LoadMatches();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (matchid.Text == "" || matchid.Text == "ENTER MATCH ID")
            {
                MessageBox.Show("Select match first");
                return;
            }

            var m = new Match
            {
                MatchId = int.Parse(matchid.Text),
                MatchDate = dateTime.Value,
                HomeTeamId = (int)cmbHomeTeam.SelectedValue,
                AwayTeamId = (int)cmbAwayTeam.SelectedValue,
                StadiumId = int.Parse(stadium.Text),
                RefereeId = int.Parse(referee.Text),
                HomeGoals = int.Parse(Hgoals.Text),
                AwayGoals = int.Parse(Agoals.Text),
                Attendance = int.Parse(attend.Text)
            };

            MatchRepository.Update(m);

            MessageBox.Show("Updated!");
            LoadMatches();
            ClearFields();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (matchid.Text == "") return;

            int id = int.Parse(matchid.Text);

            MatchRepository.Delete(id);

            MessageBox.Show("Deleted!");
            LoadMatches();
        }

        private void dataGridViewMatches_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewMatches.CurrentRow;

            matchid.Text = row.Cells["MatchId"].Value.ToString();
            dateTime.Value = (DateTime)row.Cells["MatchDate"].Value;

            cmbHomeTeam.SelectedValue = row.Cells["HomeTeamId"].Value;
            cmbAwayTeam.SelectedValue = row.Cells["AwayTeamId"].Value;

            stadium.Text = row.Cells["StadiumId"].Value.ToString();
            referee.Text = row.Cells["RefereeId"].Value.ToString();
            Hgoals.Text = row.Cells["HomeGoals"].Value.ToString();
            Agoals.Text = row.Cells["AwayGoals"].Value.ToString();
            attend.Text = row.Cells["Attendance"].Value.ToString();
            SetAllTextBlack();
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // just close current form
        }

        private void SetPlaceholder(TextBox txt, string placeholder)
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
            SetPlaceholder(matchid, "ENTER MATCH ID");
            SetPlaceholder(stadium, "Stadium ID");
            SetPlaceholder(referee, "Referee ID");
            SetPlaceholder(attend, "Attendance");
            SetPlaceholder(Hgoals, "Home Goals");
            SetPlaceholder(Agoals, "Away Goals");
        }


        // function to set color text to black
        private void SetAllTextBlack()
        {
            TextBox[] boxes = { matchid, stadium,referee, attend, Hgoals,Agoals};

            foreach (var txt in boxes)
            {
                txt.ForeColor = Color.Black;
            }
        }

        // when id is chosen the home team name appears
       
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void referee_TextChanged(object sender, EventArgs e)
        {

        }

        private void date_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
