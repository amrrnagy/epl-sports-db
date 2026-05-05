using System;
using System.Windows.Forms;
using EPL_DBMS.DataAccess;

namespace EPL_DBMS.Forms
{
    public partial class PlayerInjuriesForm : Form
    {
        public PlayerInjuriesForm()
        {
            InitializeComponent();
            LoadPlayerInjuries();
        }

        private void LoadPlayerInjuries()
        {
            try
            {
                var data = PlayerInjuryRepository.GetAllInjuries();
                var dgv  = dataGridViewPlayerInjuries;
                dgv.DataSource = data;
                dgv.Columns["PlayerId"].HeaderText = "Player ID";
                dgv.Columns["InjuryDate"].HeaderText = "Injury Date";
                dgv.Columns["InjuryType"].HeaderText = "Injury Type";
                dgv.Columns["DaysOut"].HeaderText = "Days Out";
                dgv.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Player Injuries: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
