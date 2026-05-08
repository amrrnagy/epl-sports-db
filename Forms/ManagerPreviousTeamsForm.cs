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

            // FIX: Wait for the form to actually be created before loading data
            this.Load += ManagerHistoryForm_Load;
        }

        // This event fires exactly when the window handle is finally created
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

                    // Now that the handle exists, we can just call Close() directly!
                    this.Close();
                    return;
                }

                dataGridViewManagerHistory.DataSource = history;

                dataGridViewManagerHistory.Columns["ManagerId"].Visible = false;
                dataGridViewManagerHistory.Columns["PreviousTeamId"].Visible = false;

                dataGridViewManagerHistory.Columns["PreviousTeamName"].HeaderText = "Previous Club";

                // --- NEW DYNAMIC FORM SIZING ---
                // 1. Tell columns to size themselves to fit their text content
                dataGridViewManagerHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                // 2. Calculate the exact width and height needed for the rows and columns
                int gridWidth = dataGridViewManagerHistory.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) +
                                dataGridViewManagerHistory.RowHeadersWidth + 500; // +5px buffer for borders

                int gridHeight = dataGridViewManagerHistory.Rows.GetRowsHeight(DataGridViewElementStates.Visible) +
                                 dataGridViewManagerHistory.ColumnHeadersHeight + 5;

                // 3. Cap the size so it doesn't accidentally grow off the screen
                int finalWidth = Math.Min(gridWidth, 800);  // Max width of 800px
                int finalHeight = Math.Min(gridHeight, 500); // Max height of 500px

                // 4. Snap the Form's ClientArea (the inner window size) to match the grid
                this.ClientSize = new System.Drawing.Size(finalWidth, finalHeight);

                // 5. Dock the grid so it locks into this perfectly tailored window
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