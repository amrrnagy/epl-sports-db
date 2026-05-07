using EPL_DBMS.DataAccess;
using EPL_DBMS.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EPL_DBMS.Forms
{
    public partial class ManagersForm : Form
    {
        public ManagersForm()
        {
            InitializeComponent();

            LoadManagers();

            // Placeholders
            Placeholder(txtname, "Name");
            Placeholder(txtnationality, "Nationality");
            Placeholder(txtformation, "Formation");
            Placeholder(txtexperienceyear, "Experience Years");
            Placeholder(txtteamid, "Team ID");

            txtid.ForeColor = System.Drawing.Color.Black;
        }

        private void LoadManagers()
        {
            try
            {
                var managers = ManagerRepository.GetAllManagers();
                dataGridViewManagers.DataSource = managers;
                dataGridViewManagers.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading managers: " + ex.Message);
            }
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtid.Text, out int id))
                return;

            var manager = ManagerRepository.GetById(id);

            if (manager == null) return;

            txtname.Text = manager.ManagerName;
            txtformation.Text = manager.PreferredFormation;
            txtnationality.Text = manager.Nationality;
            txtexperienceyear.Text = manager.ExperienceYears.ToString();
            txtteamid.Text = manager.TeamId.ToString();

            txtname.ForeColor = System.Drawing.Color.Black;
            txtformation.ForeColor = System.Drawing.Color.Black;
            txtexperienceyear.ForeColor = System.Drawing.Color.Black;
            txtnationality.ForeColor = System.Drawing.Color.Black;
            txtteamid.ForeColor = System.Drawing.Color.Black;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {


            if (!int.TryParse(txtteamid.Text, out int teamId) ||
                !int.TryParse(txtexperienceyear.Text, out int experienceYears))
            {
                MessageBox.Show("Enter valid numeric values!");
                return;
            }
            var m = new Manager
            {

                ManagerName = txtname.Text,
                PreferredFormation = txtformation.Text,
                Nationality = txtnationality.Text,
                ExperienceYears = experienceYears,
                TeamId = teamId



            };

            ManagerRepository.Add(m);

            MessageBox.Show("Manager Added!");
            LoadManagers();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtid.Text, out int id))
                {
                    MessageBox.Show("Invalid ID");
                    return;
                }

                var m = new Manager
                {
                    ManagerId = id,
                    ManagerName = txtname.Text,
                    Nationality = txtnationality.Text,
                    PreferredFormation = txtformation.Text,
                    ExperienceYears = int.Parse(txtexperienceyear.Text),
                    TeamId = int.Parse(txtteamid.Text)
                };

                ManagerRepository.Update(m);

                LoadManagers();
                ClearFields();

                MessageBox.Show("Manager updated successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating manager: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtid.Text, out int id))
                {
                    MessageBox.Show("Select a valid manager first");
                    return;
                }

                ManagerRepository.Delete(id);

                LoadManagers();
                ClearFields();

                MessageBox.Show("Manager deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting manager: " + ex.Message);
            }
        }

        private void dataGridViewManagers_CellClick(object sender, DataGridViewCellEventArgs E)
        {
            if (E.RowIndex < 0) return;

            var row = dataGridViewManagers.CurrentRow;

            txtid.Text = row.Cells["ManagerId"].Value.ToString();
            txtname.Text = row.Cells["ManagerName"].Value.ToString();
            txtformation.Text = row.Cells["PreferredFormation"].Value.ToString();
            txtnationality.Text = row.Cells["Nationality"].Value.ToString();
            txtexperienceyear.Text = row.Cells["ExperienceYears"].Value.ToString();
            txtteamid.Text = row.Cells["TeamId"].Value.ToString();

            txtid.ForeColor = System.Drawing.Color.Black;
        }

        private bool ValidateInputs()
        {
            if (txtname.Text == "Name" ||
                txtnationality.Text == "Nationality" ||
                txtformation.Text == "Formation" ||
                txtexperienceyear.Text == "Experience Years" ||
                txtteamid.Text == "Team ID")
            {
                MessageBox.Show("Please fill all fields");
                return false;
            }

            if (!int.TryParse(txtexperienceyear.Text, out _) ||
                !int.TryParse(txtteamid.Text, out _))
            {
                MessageBox.Show("Experience Years and Team ID must be numbers");
                return false;
            }

            return true;
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

        private void ClearFields()
        {
            txtname.Clear();
            txtformation.Clear();
            txtnationality.Clear();
            txtexperienceyear.Clear();
            txtteamid.Clear();
            txtid.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManagersForm_Load(object sender, EventArgs e)
        {
            LoadManagers();
        }
    }
}