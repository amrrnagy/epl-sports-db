using System;
using System.Windows.Forms;
using EPL_DBMS.DataAccess;

namespace EPL_DBMS.Forms
{
    public partial class PlayersForm : Form
    {
        public PlayersForm()
        {
            InitializeComponent();
            LoadPlayers();
        }

        private void LoadPlayers()
        {
            try
            {
                var data = PlayerRepository.GetAllPlayers();
                var dgv  = dataGridViewPlayers;
                dgv.DataSource = data;
                dgv.Columns["PlayerId"].HeaderText = "ID";
                dgv.Columns["PlayerName"].HeaderText = "Player Name";
                dgv.Columns["Position"].HeaderText = "Position";
                dgv.Columns["Age"].HeaderText = "Age";
                dgv.Columns["Nationality"].HeaderText = "Nationality";
                dgv.Columns["TeamId"].HeaderText = "Team ID";
                dgv.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Players: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
