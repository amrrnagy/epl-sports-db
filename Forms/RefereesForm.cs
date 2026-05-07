using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EPL_DBMS.Forms
{
    public partial class RefereesForm : Form
    {

        public RefereesForm()
        {
            InitializeComponent();
            txtid.TextChanged += txtid_TextChanged;
            LoadReferees();
            Placeholder(txtname, "Referee Name");
            Placeholder(txtnationality, "Nationality");
            Placeholder(txtid, "ENTER Referee ID");
            txtid.ForeColor = System.Drawing.Color.Black;
        }

        private void LoadReferees()
        {
            try
            {
                var referees = RefereeRepository.GetAllReferees();
                dataGridViewReferees.DataSource = referees;

                // Clean up the auto-generated column headers


                dataGridViewReferees.AutoResizeColumns();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error loading referees: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtid_TextChanged(object sender, EventArgs e)
        {

            if (int.TryParse(txtid.Text, out int id))
            {
                var referee = RefereeRepository.GetById(id); //get referee info from db

                if (referee != null)
                {
                    txtname.Text = referee.RefereeName;
                    txtnationality.Text = referee.Nationality;

                    // make txt black
                    txtname.ForeColor = System.Drawing.Color.Black;
                    txtnationality.ForeColor = System.Drawing.Color.Black;

                }

            }
        }





        //  ADD 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var r = new Referee
                {
                    RefereeId = int.Parse(txtid.Text),
                    RefereeName = txtname.Text,
                    Nationality = txtnationality.Text
                };

                RefereeRepository.Add(r);
                LoadReferees();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding referee: " + ex.Message);
            }
        }

        //   UPDATE 
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewReferees.CurrentRow == null) return;

                int id = int.Parse(txtid.Text);

                var r = new Referee
                {
                    RefereeId = id,
                    RefereeName = txtname.Text,
                    Nationality = txtnationality.Text
                };

                RefereeRepository.Update(r);
                LoadReferees();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Referee: " + ex.Message);
            }
        }

        //     DELETE 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewReferees.CurrentRow == null) return;

                int id = int.Parse(txtid.Text);

                RefereeRepository.Delete(id);
                LoadReferees();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting Referee: " + ex.Message);
            }
        }

        private void dataGridViewReferees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewReferees.CurrentRow;
            txtid.Text = row.Cells["RefereeId"].Value.ToString();
            txtid.ForeColor = System.Drawing.Color.Black;

            txtname.Text = row.Cells["RefereeName"].Value.ToString();
            txtname.ForeColor = System.Drawing.Color.Black;

            txtnationality.Text = row.Cells["Nationality"].Value.ToString();
            txtnationality.ForeColor = System.Drawing.Color.Black;
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

        private void RefereesForm_Load(object sender, EventArgs e)
        {
            LoadReferees();
        }
        private void ClearFields()
        {
            txtname.Clear();
            txtnationality.Clear();
            txtid.Clear();
        }

        private void txtid_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}