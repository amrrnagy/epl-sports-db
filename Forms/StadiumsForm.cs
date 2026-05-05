using System;
using System.Windows.Forms;
using EPL_DBMS.DataAccess;

namespace EPL_DBMS.Forms
{
    public partial class StadiumsForm : Form
    {
        public StadiumsForm()
        {
            InitializeComponent();
            LoadStadiums();
        }

        private void LoadStadiums()
        {
            try
            {
                var data = StadiumRepository.GetAllStadiums();
                var dgv  = dataGridViewStadiums;
                dgv.DataSource = data;
                dgv.Columns["StadiumId"].HeaderText = "ID";
                dgv.Columns["StadiumName"].HeaderText = "Stadium Name";
                dgv.Columns["City"].HeaderText = "City";
                dgv.Columns["Capacity"].HeaderText = "Capacity";
                dgv.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Stadiums: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
