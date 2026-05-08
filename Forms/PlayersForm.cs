using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace EPL_DBMS.Forms
{
    public partial class PlayersForm : Form
    {
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
            LoadPlayersGrid();


            txtid.BackColor = Color.LightGray;
 
            txtid.ForeColor = Color.Gray;

            // PlaceHolders for the Text Fields

            SetPlaceholder(txtname, "Name");
            SetPlaceholder(txtposition, "Position");
            SetPlaceholder(txtage, "Age");
            SetPlaceholder(txtnationality, "Nationality");
            SetPlaceholder(txtteamid, "Team ID");
            SetPlaceholder(txtid, "ENTER PLAYER ID");
            txtid.ForeColor = System.Drawing.Color.Black;
        }

        //LOAD
        private void LoadPlayers()
        {
            try
            {
                var data = PlayerRepository.GetAllPlayers();
                dataGridViewPlayers.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Players: " + ex.Message);
            }
        }

        private void LoadPlayersGrid()
        {
            // Fetch the ViewModel list instead of the pure Player list
            var playersWithTeams = PlayerRepository.GetAllPlayersForGrid();

            // Bind it to the grid
            dataGridViewPlayers.DataSource = playersWithTeams;

            // Optional: Hide the raw IDs from the user to make it completely clean
            if (dataGridViewPlayers.Columns["PlayerId"] != null)
                dataGridViewPlayers.Columns["PlayerId"].Visible = false;

            if (dataGridViewPlayers.Columns["TeamId"] != null)
                dataGridViewPlayers.Columns["TeamId"].Visible = false;

            // Optional: Rename the header so it looks nice
            if (dataGridViewPlayers.Columns["TeamName"] != null)
                dataGridViewPlayers.Columns["TeamName"].HeaderText = "Current Club";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtid.Text, out int id))
            {
                MessageBox.Show("Enter valid ID");
                return;
            }

            var player = PlayerRepository.GetById(id);

            if (player == null)
            {
                MessageBox.Show("Player not found");
                return;
            }

            txtname.Text = player.PlayerName;
            txtposition.Text = player.Position;
            txtage.Text = player.Age.ToString();
            txtnationality.Text = player.Nationality;
            txtteamid.Text = player.TeamId.ToString();
            SetAllTextBlack();

            // Enable editing
            update.Enabled = true;
            delete.Enabled = true;

            foreach (DataGridViewRow row in dataGridViewPlayers.Rows)
            {
                // Make sure the row isn't empty and check if the ID matches
                if (row.Cells["PlayerId"].Value != null && (int)row.Cells["PlayerId"].Value == id)
                {
                    // Clear any previously selected rows
                    dataGridViewPlayers.ClearSelection();

                    // Highlight this specific row
                    row.Selected = true;

                    // Set it as the "Current" row (so your Stats button can find it)
                    dataGridViewPlayers.CurrentCell = row.Cells[0];

                    // Automatically scroll down to the row so the user doesn't have to search for it!
                    dataGridViewPlayers.FirstDisplayedScrollingRowIndex = row.Index;

                    break; // We found the player, no need to keep looping
                }
            }
        }

        //  ADD 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Prevent adding placeholder text to the database!
                if (txtname.Text == "Name" || txtposition.Text == "Position" ||
                    txtage.Text == "Age" || txtnationality.Text == "Nationality" || txtteamid.Text == "Team ID")
                {
                    MessageBox.Show("Please fill all fields.");
                    return;
                }

                if (!int.TryParse(txtage.Text, out int age) || !int.TryParse(txtteamid.Text, out int teamId))
                {
                    MessageBox.Show("Please ensure Age and Team ID are valid numbers.");
                    return;
                }

                var p = new Player
                {
                    PlayerName = txtname.Text,
                    Position = txtposition.Text,
                    Age = age,
                    Nationality = txtnationality.Text,
                    TeamId = teamId
                };

                PlayerRepository.Add(p);

                MessageBox.Show("Player Added Successfully!");

                // Reload the GRID
                LoadPlayersGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding player: " + ex.Message);
            }
        }

        //   UPDATE 
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtid.Text == "" || txtid.Text == "ENTER PLAYER ID")
                {
                    MessageBox.Show("Select a player first from the table.");
                    return;
                }

                if (!int.TryParse(txtage.Text, out int age) || !int.TryParse(txtteamid.Text, out int teamId))
                {
                    MessageBox.Show("Please ensure Age and Team ID are valid numbers.");
                    return;
                }

                var p = new Player
                {
                    PlayerId = int.Parse(txtid.Text),
                    PlayerName = txtname.Text,
                    Position = txtposition.Text,
                    Age = int.Parse(txtage.Text),
                    Nationality = txtnationality.Text,
                    TeamId = int.Parse(txtteamid.Text)
                };

                PlayerRepository.Update(p);

                MessageBox.Show("Player Updated!");

                LoadPlayersGrid();
                ClearFields();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating player: " + ex.Message);
            }
        }

        //     DELETE 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPlayers.CurrentRow == null) return;

                int id = int.Parse(txtid.Text);

                PlayerRepository.Delete(id);
                LoadPlayers();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting player: " + ex.Message);
            }
        }

        //  when click row info appears in txt fields
        private void dataGridViewPlayers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewPlayers.CurrentRow;

            txtid.Text = row.Cells["PlayerId"].Value.ToString();
            txtname.Text = row.Cells["PlayerName"].Value.ToString();
            txtposition.Text = row.Cells["Position"].Value.ToString();
            txtage.Text = row.Cells["Age"].Value.ToString();
           txtnationality.Text = row.Cells["Nationality"].Value.ToString();
           txtteamid.Text = row.Cells["TeamId"].Value.ToString();
            SetAllTextBlack();

        }

        // function to set color text to black
        private void SetAllTextBlack()
        {
            TextBox[] boxes = { txtname, txtposition, txtage, txtnationality, txtteamid, txtid };

            foreach (var txt in boxes)
            {
                txt.ForeColor = Color.Black;
            }
        }
        // clear
        private void ClearFields()
        {
            SetPlaceholder(txtname, "Name");
            SetPlaceholder(txtposition, "Position");
            SetPlaceholder(txtage, "Age");
            SetPlaceholder(txtnationality, "Nationality");
            SetPlaceholder(txtteamid, "Team ID");

            SetPlaceholder(txtid, "ENTER PLAYER ID");
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // just close current form
        }

        private void PlayersForm_Load(object sender, EventArgs e)
        {
            LoadPlayersGrid();
        }

        private void btnPlayerStats_Click(object sender, EventArgs e)
        {
            if (dataGridViewPlayers.CurrentRow == null)
            {
                MessageBox.Show("Please select a player from the table first.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int playerId = (int)dataGridViewPlayers.CurrentRow.Cells["PlayerId"].Value;
            string playerName = dataGridViewPlayers.CurrentRow.Cells["PlayerName"].Value.ToString();

            // 1. Ask the database FIRST
            var stats = PlayerStatRepository.GetStatsByPlayerId(playerId);

            // 2. If it's empty, show the message and STOP. The form never opens!
            if (stats == null || stats.Count == 0)
            {
                MessageBox.Show($"{playerName} has no match statistics recorded.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 3. If we made it here, they have stats. Open the form!
            NavigateTo(new PlayerStatsForm(playerId, playerName));
        }

        private void btnPlayerInjuries_Click(object sender, EventArgs e)
        {
            if (dataGridViewPlayers.CurrentRow == null)
            {
                MessageBox.Show("Please select a player from the table first.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int playerId = (int)dataGridViewPlayers.CurrentRow.Cells["PlayerId"].Value;
            string playerName = dataGridViewPlayers.CurrentRow.Cells["PlayerName"].Value.ToString();

            // 1. Ask the database FIRST
            var injuries = PlayerInjuryRepository.GetByPlayerId(playerId);

            // 2. If it's empty, show the message and STOP.
            if (injuries.Count == 0)
            {
                MessageBox.Show($"{playerName} has no injury history recorded.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 3. Open the form safely!
            NavigateTo(new PlayerInjuriesForm(playerId, playerName));
        }
    }
}