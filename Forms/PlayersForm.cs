using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EPL_DBMS.Forms
{
    public partial class PlayersForm : Form
    {
        private List<Team> _teams;
        private List<string> _positions;

        private void NavigateTo(Form childForm)
        {
            this.Hide();
            using (childForm)
            {
                childForm.ShowDialog();
            }
            this.Show();
        }

        public PlayersForm()
        {
            InitializeComponent();

            ApplyModernStyling();

            LoadTeamComboBox();
            LoadPositionComboBox();
            LoadPlayersGrid();

            UIHelper.SetPlaceholder(txtname, "Full Name");
            UIHelper.SetPlaceholder(txtage, "Age");
            UIHelper.SetPlaceholder(txtnationality, "Nationality");
            UIHelper.SetPlaceholder(txtid, "ENTER PLAYER ID");
        }

        private void ApplyModernStyling()
        {
            this.BackColor = UIHelper.SurfaceColor;
            this.Font = new Font("Segoe UI", 9f);

            UIHelper.StyleGrid(dataGridViewPlayers);

            UIHelper.StyleButton(btnAdd, UIHelper.SuccessColor);
            UIHelper.StyleButton(btnUpdate, UIHelper.PrimaryAccent);
            UIHelper.StyleButton(btnDelete, UIHelper.DangerColor);
            UIHelper.StyleButton(btnSearch, UIHelper.PrimaryAccent);
            UIHelper.StyleButton(btnBack, Color.FromArgb(108, 117, 125));
            UIHelper.StyleButton(btnPlayerStats, UIHelper.PrimaryAccent);
            UIHelper.StyleButton(btnPlayerInjuries, UIHelper.DangerColor);
        }

        private void LoadTeamComboBox()
        {
            _teams = TeamRepository.GetAllTeams();
            cmbTeam.DataSource = _teams;
            cmbTeam.DisplayMember = "TeamName";
            cmbTeam.ValueMember = "TeamId";
            cmbTeam.SelectedIndex = -1;
        }

        private void LoadPositionComboBox()
        {
            _positions = PlayerRepository.GetAllPositions();
            cmbPosition.DataSource = _positions;
            cmbPosition.SelectedIndex = -1;
        }

        private void LoadPlayersGrid()
        {
            try
            {
                var playersWithTeams = PlayerRepository.GetAllPlayersForGrid();
                dataGridViewPlayers.DataSource = playersWithTeams;

                if (dataGridViewPlayers.Columns["PlayerId"] != null)
                    dataGridViewPlayers.Columns["PlayerId"].Visible = false;

                if (dataGridViewPlayers.Columns["TeamId"] != null)
                    dataGridViewPlayers.Columns["TeamId"].Visible = false;

                if (dataGridViewPlayers.Columns["TeamName"] != null)
                    dataGridViewPlayers.Columns["TeamName"].HeaderText = "Current Club";

                dataGridViewPlayers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading players: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtid.Text, out int id))
            {
                MessageBox.Show("Enter a valid Player ID.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var player = PlayerRepository.GetById(id);
            if (player == null)
            {
                MessageBox.Show("Player not found.",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PopulateFields(player);

            foreach (DataGridViewRow row in dataGridViewPlayers.Rows)
            {
                if (row.Cells["PlayerId"].Value != null &&
                   (int)row.Cells["PlayerId"].Value == id)
                {
                    dataGridViewPlayers.ClearSelection();
                    row.Selected = true;
                    dataGridViewPlayers.CurrentCell = row.Cells["PlayerName"];
                    dataGridViewPlayers.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                var p = new Player
                {
                    PlayerName = txtname.Text.Trim(),
                    Position = (string)cmbPosition.SelectedValue,
                    Age = int.Parse(txtage.Text),
                    Nationality = txtnationality.Text.Trim(),
                    TeamId = (int)cmbTeam.SelectedValue
                };

                PlayerRepository.Add(p);

                MessageBox.Show("Player added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPlayersGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding player: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid.Text) || txtid.Text == "ENTER PLAYER ID")
            {
                MessageBox.Show("Select a player from the table first.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs()) return;

            try
            {
                var p = new Player
                {
                    PlayerId = int.Parse(txtid.Text),
                    PlayerName = txtname.Text.Trim(),
                    Age = int.Parse(txtage.Text),
                    Nationality = txtnationality.Text.Trim(),
                    TeamId = (int)cmbTeam.SelectedValue,
                    Position = (string)cmbPosition.SelectedValue
                };

                PlayerRepository.Update(p);

                MessageBox.Show("Player updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPlayersGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating player: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewPlayers.CurrentRow == null || !int.TryParse(txtid.Text, out int id))
            {
                MessageBox.Show("Please select a player from the table first.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to permanently delete this player?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                PlayerRepository.Delete(id);
                MessageBox.Show("Player deleted.", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadPlayersGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting player: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewPlayers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewPlayers.CurrentRow;

            txtid.Text = row.Cells["PlayerId"].Value.ToString();
            txtname.Text = row.Cells["PlayerName"].Value.ToString();
            txtage.Text = row.Cells["Age"].Value.ToString();
            txtnationality.Text = row.Cells["Nationality"].Value.ToString();
            cmbPosition.SelectedItem = row.Cells["Position"].Value?.ToString();
            cmbTeam.SelectedValue = row.Cells["TeamId"].Value;

            SetAllTextBlack();

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void PopulateFields(Player p)
        {
            txtname.Text = p.PlayerName;
            txtage.Text = p.Age.ToString();
            txtnationality.Text = p.Nationality;
            cmbTeam.SelectedValue = p.TeamId;
            cmbPosition.SelectedItem = p.Position;

            SetAllTextBlack();

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) || txtname.Text == "Full Name" ||
                string.IsNullOrWhiteSpace(txtnationality.Text) || txtnationality.Text == "Nationality")
            {
                MessageBox.Show("Please fill all required fields.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtage.Text, out int age) || age < 14 || age > 50)
            {
                MessageBox.Show("Please enter a valid player age (14–50).",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbTeam.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a team from the dropdown.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbPosition.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a position from the dropdown.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void SetAllTextBlack()
        {
            foreach (var txt in new TextBox[] { txtname, txtage, txtnationality, txtid })
                txt.ForeColor = Color.Black;
        }

        private void ClearFields()
        {
            UIHelper.SetPlaceholder(txtname, "Full Name");
            UIHelper.SetPlaceholder(txtage, "Age");
            UIHelper.SetPlaceholder(txtnationality, "Nationality");
            UIHelper.SetPlaceholder(txtid, "ENTER PLAYER ID");
            cmbTeam.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
        }

        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        private void PlayersForm_Load(object sender, EventArgs e) => LoadPlayersGrid();

        private void btnPlayerStats_Click(object sender, EventArgs e)
        {
            if (dataGridViewPlayers.CurrentRow == null)
            {
                MessageBox.Show("Please select a player from the table first.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int playerId = (int)dataGridViewPlayers.CurrentRow.Cells["PlayerId"].Value;
            string playerName = dataGridViewPlayers.CurrentRow.Cells["PlayerName"].Value.ToString();

            var stats = PlayerStatRepository.GetStatsByPlayerId(playerId);
            if (stats == null || stats.Count == 0)
            {
                MessageBox.Show($"{playerName} has no match statistics recorded.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            NavigateTo(new PlayerStatsForm(playerId, playerName));
        }

        private void btnPlayerInjuries_Click(object sender, EventArgs e)
        {
            if (dataGridViewPlayers.CurrentRow == null)
            {
                MessageBox.Show("Please select a player from the table first.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int playerId = (int)dataGridViewPlayers.CurrentRow.Cells["PlayerId"].Value;
            string playerName = dataGridViewPlayers.CurrentRow.Cells["PlayerName"].Value.ToString();

            var injuries = PlayerInjuryRepository.GetByPlayerId(playerId);
            if (injuries.Count == 0)
            {
                MessageBox.Show($"{playerName} has no injury history recorded.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            NavigateTo(new PlayerInjuriesForm(playerId, playerName));
        }
    }
}