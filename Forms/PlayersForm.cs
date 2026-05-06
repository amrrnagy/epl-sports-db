using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;
using System;
using System.Windows.Forms;


namespace EPL_DBMS.Forms
{
    public partial class PlayersForm : Form
    {
        public PlayersForm()
        {
            InitializeComponent();

            txtid.TextChanged += txtid_TextChanged;

            LoadPlayers();

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

        //  ADD 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var p = new Player
                {
                    PlayerName = txtname.Text,
                    Position = txtposition.Text,
                    Age = int.Parse(txtage.Text),
                    Nationality = txtnationality.Text,
                    TeamId = int.Parse(txtteamid.Text)
                };

                PlayerRepository.Add(p);
                LoadPlayers();
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
                if (dataGridViewPlayers.CurrentRow == null) return;

                int id = int.Parse(txtid.Text);

                var p = new Player
                {
                    PlayerId = id,
                    PlayerName = txtname.Text,
                    Position = txtposition.Text,
                    Age = int.Parse(txtage.Text),
                    Nationality = txtnationality.Text,
                    TeamId = int.Parse(txtteamid.Text)
                };

                PlayerRepository.Update(p);
                LoadPlayers();
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
            txtid.ForeColor = System.Drawing.Color.Black;

            txtname.Text = row.Cells["PlayerName"].Value.ToString();
            txtname.ForeColor = System.Drawing.Color.Black;

            txtposition.Text = row.Cells["Position"].Value.ToString();
            txtposition.ForeColor = System.Drawing.Color.Black;

            txtage.Text = row.Cells["Age"].Value.ToString();
            txtage.ForeColor = System.Drawing.Color.Black;

            txtnationality.Text = row.Cells["Nationality"].Value.ToString();
            txtnationality.ForeColor = System.Drawing.Color.Black;

            txtteamid.Text = row.Cells["TeamId"].Value.ToString();
            txtteamid.ForeColor = System.Drawing.Color.Black;
        }

        // clear
        private void ClearFields()
        {
            txtname.Clear();
            txtposition.Clear();
            txtage.Clear();
            txtnationality.Clear();
            txtteamid.Clear();
            txtid.Clear();
        }

        // when enter a player id its info appears in txt fields
        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtid.Text, out int id)) 
            {
                var player = PlayerRepository.GetById(id); //get player info from db

                if (player != null)
                {
                    txtname.Text = player.PlayerName;
                    txtposition.Text = player.Position;
                    txtage.Text = player.Age.ToString();
                    txtnationality.Text = player.Nationality;
                    txtteamid.Text = player.TeamId.ToString();

                    // make txt black
                    txtname.ForeColor = System.Drawing.Color.Black;
                    txtposition.ForeColor = System.Drawing.Color.Black;
                    txtage.ForeColor = System.Drawing.Color.Black;
                    txtnationality.ForeColor = System.Drawing.Color.Black;
                    txtteamid.ForeColor = System.Drawing.Color.Black;
                }
            }
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
            LoadPlayers();
        }


    }
}