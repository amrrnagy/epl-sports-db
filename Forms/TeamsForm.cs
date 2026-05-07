using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EPL_DBMS.Forms
{
    public partial class TeamsForm : Form
    {
        public TeamsForm()
        {
            InitializeComponent();
            txtid.TextChanged += txtid_TextChanged;
            LoadTeams();
            Placeholder(txtname, "Name");
            Placeholder(txtfounded, "Founded");
            Placeholder(txtkitcolor, "Kit Color");
            Placeholder(txtstadiumid, "Stadium ID");
            Placeholder(txtid, "ENTER Team ID");
            txtid.ForeColor = System.Drawing.Color.Black;
        }

        private void LoadTeams()
        {
            try
            {
                var teams = TeamRepository.GetAllTeams();
                dataGridViewTeams.DataSource = teams;

                // Clean up the auto-generated column headers


                dataGridViewTeams.AutoResizeColumns();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error loading teams: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtid_TextChanged(object sender, EventArgs e)
        {

            if (int.TryParse(txtid.Text, out int id))
            {
                var team = TeamRepository.GetById(id); //get team info from db

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
                else
                {
                    // Clear fields if no team found
                    txtname.Clear();
                    txtfounded.Clear();
                    txtkitcolor.Clear();
                    txtstadiumid.Clear();
                    MessageBox.Show("No team found with ID: " + id, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }





        //  ADD 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var t = new Team
                {
                    TeamId = int.Parse(txtid.Text),
                    TeamName = txtname.Text,
                    YearFounded = int.Parse(txtfounded.Text),
                    HomeKitColor = txtkitcolor.Text,
                    StadiumId = int.Parse(txtstadiumid.Text)
                };

                TeamRepository.Add(t);
                LoadTeams();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding team: " + ex.Message);
            }
        }

        //   UPDATE 
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTeams.CurrentRow == null) return;

                int id = int.Parse(txtid.Text);

                var t = new Team
                {
                    TeamId = id,
                    TeamName = txtname.Text,
                    YearFounded = int.Parse(txtfounded.Text),
                    HomeKitColor = txtkitcolor.Text,
                    StadiumId = int.Parse(txtstadiumid.Text)
                };

                TeamRepository.Update(t);
                LoadTeams();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Team: " + ex.Message);
            }
        }

        //     DELETE 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTeams.CurrentRow == null) return;

                int id = int.Parse(txtid.Text);

                TeamRepository.Delete(id);
                LoadTeams();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting Team: " + ex.Message);
            }
        }

        private void dataGridViewTeams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewTeams.CurrentRow;

            txtid.Text = row.Cells["TeamId"].Value.ToString();
            txtid.ForeColor = System.Drawing.Color.Black;

            txtname.Text = row.Cells["TeamName"].Value.ToString();
            txtname.ForeColor = System.Drawing.Color.Black;

            txtfounded.Text = row.Cells["YearFounded"].Value.ToString();
            txtfounded.ForeColor = System.Drawing.Color.Black;

            txtkitcolor.Text = row.Cells["HomeKitColor"].Value.ToString();
            txtkitcolor.ForeColor = System.Drawing.Color.Black;

            txtstadiumid.Text = row.Cells["StadiumId"].Value.ToString();
            txtstadiumid.ForeColor = System.Drawing.Color.Black;

        }


        private void Placeholder(TextBox txt, string placeholder)
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
            this.Close();
        }

        private void TeamsForm_Load(object sender, EventArgs e)
        {
            LoadTeams();
        }
        private void ClearFields()
        {
            txtname.Clear();
            txtkitcolor.Clear();
            txtfounded.Clear();
            txtstadiumid.Clear();
            txtid.Clear();
        }

    }
}