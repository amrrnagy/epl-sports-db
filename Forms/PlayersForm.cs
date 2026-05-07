using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace EPL_DBMS.Forms
{
    public partial class PlayersForm : Form
    {
        public PlayersForm()
        {
            InitializeComponent();
            LoadPlayers();

         
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
        }

        //  ADD 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
             
                if (txtname.Text == "" || txtposition.Text == "" ||
                    txtage.Text == "" || txtnationality.Text == "" || txtteamid.Text == "")
                {
                    MessageBox.Show("Please fill all fields");
                    return;
                }

                var p = new Player
                {
                    PlayerName = txtname.Text,
                    Position = txtposition.Text,
                    Age = int.Parse(txtage.Text),
                    Nationality = txtnationality.Text,
                    TeamId = int.Parse(txtteamid.Text)
                };

                PlayerRepository.Add(p);

                MessageBox.Show("Player Added Successfully!");

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
                if (txtid.Text == "" || txtid.Text == "Auto Generated")
                {
                    MessageBox.Show("Select a player first");
                    return;
                }

                var p = new Player
                {
           
                    PlayerName = txtname.Text,
                    Position = txtposition.Text,
                    Age = int.Parse(txtage.Text),
                    Nationality = txtnationality.Text,
                    TeamId = int.Parse(txtteamid.Text)
                };

                PlayerRepository.Update(p);

                MessageBox.Show("Player Updated!");

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
            LoadPlayers();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}