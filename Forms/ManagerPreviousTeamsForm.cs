using System;
using System.Windows.Forms;
using EPL_DBMS.DataAccess;

namespace EPL_DBMS.Forms
{
    public partial class ManagerPreviousTeamsForm : Form
    {
        private readonly int _managerId;

        public ManagerPreviousTeamsForm()
        {
            InitializeComponent();
        }

        public ManagerPreviousTeamsForm(int managerId, string managerName)
        {
            InitializeComponent();

            _managerId = managerId;
            this.Text = $"{managerName} - Career History";
            this.Load += ManagerHistoryForm_Load;
        }

        private void ManagerHistoryForm_Load(object sender, EventArgs e)
        {
            LoadHistory();
        }

        private void LoadHistory()
        {
            try
            {
                var history = ManagerPreviousTeamRepository.GetViewByManagerId(_managerId);

                if (history.Count == 0)
                {
                    MessageBox.Show("No previous team history found for this manager.",
                                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                dataGridViewManagerHistory.DataSource = history;

                dataGridViewManagerHistory.Columns["ManagerId"].Visible = false;
                dataGridViewManagerHistory.Columns["PreviousTeamId"].Visible = false;
                dataGridViewManagerHistory.Columns["PreviousTeamName"].HeaderText = "Previous Club";

                // Dynamic form sizing based on grid content
                dataGridViewManagerHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                int gridWidth = dataGridViewManagerHistory.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) +
                                dataGridViewManagerHistory.RowHeadersWidth + 500;

                int gridHeight = dataGridViewManagerHistory.Rows.GetRowsHeight(DataGridViewElementStates.Visible) +
                                 dataGridViewManagerHistory.ColumnHeadersHeight + 5;

                int finalWidth = Math.Min(gridWidth, 800);
                int finalHeight = Math.Min(gridHeight, 500);

                this.ClientSize = new System.Drawing.Size(finalWidth, finalHeight);
                dataGridViewManagerHistory.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading history: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}