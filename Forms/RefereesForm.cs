using System;
using System.Windows.Forms;
using EPL_DBMS.DataAccess;

namespace EPL_DBMS.Forms
{
    public partial class RefereesForm : Form
    {
        public RefereesForm()
        {
            InitializeComponent();
            LoadReferees();
        }

        private void LoadReferees()
        {
            try
            {
                var data = RefereeRepository.GetAllReferees();
                var dgv  = dataGridViewReferees;
                dgv.DataSource = data;
                dgv.Columns["RefereeId"].HeaderText = "ID";
                dgv.Columns["RefereeName"].HeaderText = "Referee Name";
                dgv.Columns["Nationality"].HeaderText = "Nationality";
                dgv.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Referees: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
