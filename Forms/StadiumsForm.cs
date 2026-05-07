using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EPL_DBMS.Forms
{
    public partial class StadiumsForm : Form
    {
        public StadiumsForm()
        {
            InitializeComponent();
            txtid.TextChanged += txtid_TextChanged;
            LoadStadiums();
            Placeholder(txtname, "Name");
            Placeholder(txtcapacity, "Capacity");
            Placeholder(txtcity, "City");
            Placeholder(txtid, "ENTER Stadium ID");
            txtid.ForeColor = System.Drawing.Color.Black;
        }

        private void LoadStadiums()
        {
            try
            {
                var stadiums = StadiumRepository.GetAllStadiums();
                dataGridViewStadiums.DataSource = stadiums;

                // Clean up the auto-generated column headers


                dataGridViewStadiums.AutoResizeColumns();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error loading stadiums: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtid_TextChanged(object sender, EventArgs e)
        {

            if (int.TryParse(txtid.Text, out int id))
            {
                var stadium = StadiumRepository.GetById(id);
                if (stadium != null)
                {
                    txtname.Text = stadium.StadiumName;
                    txtcapacity.Text = stadium.Capacity.ToString();
                    txtcity.Text = stadium.City;

                    // make txt black
                    txtname.ForeColor = System.Drawing.Color.Black;
                    txtcapacity.ForeColor = System.Drawing.Color.Black;
                    txtcity.ForeColor = System.Drawing.Color.Black;
                    txtid.ForeColor = System.Drawing.Color.Black;

                }

            }
        }





        //  ADD 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var s = new Stadium
                {
                    StadiumId = int.Parse(txtid.Text),
                    StadiumName = txtname.Text,
                    Capacity = int.Parse(txtcapacity.Text),
                    City = txtcity.Text
                };

                StadiumRepository.Add(s);
                LoadStadiums();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding stadium: " + ex.Message);
            }
        }

        //   UPDATE 
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewStadiums.CurrentRow == null) return;

                int id = int.Parse(txtid.Text);

                var s = new Stadium
                {
                    StadiumId = id,
                    StadiumName = txtname.Text,
                    Capacity = int.Parse(txtcapacity.Text),
                    City = txtcity.Text
                };

                StadiumRepository.Update(s);
                LoadStadiums();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Stadium: " + ex.Message);
            }
        }

        //     DELETE 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewStadiums.CurrentRow == null) return;
                int id = int.Parse(txtid.Text);

                StadiumRepository.Delete(id);
                LoadStadiums();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting Stadium: " + ex.Message);
            }
        }

        private void dataGridViewStadiums_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewStadiums.CurrentRow;
            txtid.Text = row.Cells["StadiumId"].Value.ToString();
            txtid.ForeColor = System.Drawing.Color.Black;

            txtname.Text = row.Cells["StadiumName"].Value.ToString();
            txtname.ForeColor = System.Drawing.Color.Black;

            txtcapacity.Text = row.Cells["Capacity"].Value.ToString();
            txtcapacity.ForeColor = System.Drawing.Color.Black;

            txtcity.Text = row.Cells["City"].Value.ToString();
            txtcity.ForeColor = System.Drawing.Color.Black;

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
        private void StadiumsForm_Load(object sender, EventArgs e)
        {
            LoadStadiums();
        }
        private void ClearFields()
        {
            txtname.Clear();
            txtcapacity.Clear();
            txtcity.Clear();
            txtid.Clear();
        }
    }
}