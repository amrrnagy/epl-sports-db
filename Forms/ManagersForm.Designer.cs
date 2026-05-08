// FIX: Replaced txtteamid (TextBox) with cmbTeam (ComboBox).
// NEW: Added lblTeam label above the ComboBox.
// NEW: All controls updated to Segoe UI font and FlatStyle.Flat where applicable.

namespace EPL_DBMS.Forms
{
    partial class ManagersForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.txtname            = new System.Windows.Forms.TextBox();
            this.txtnationality     = new System.Windows.Forms.TextBox();
            this.txtformation       = new System.Windows.Forms.TextBox();
            this.cmbTeam            = new System.Windows.Forms.ComboBox();  // NEW: was txtteamid
            this.txtexperienceyear  = new System.Windows.Forms.TextBox();
            this.txtid              = new System.Windows.Forms.TextBox();
            this.btnBack            = new System.Windows.Forms.Button();
            this.dataGridViewManagers = new System.Windows.Forms.DataGridView();
            this.btnAdd             = new System.Windows.Forms.Button();
            this.btnUpdate          = new System.Windows.Forms.Button();
            this.btnDelete          = new System.Windows.Forms.Button();
            this.search             = new System.Windows.Forms.Button();
            // NEW: Labels for input fields
            this.lblName            = new System.Windows.Forms.Label();
            this.lblNationality     = new System.Windows.Forms.Label();
            this.lblFormation       = new System.Windows.Forms.Label();
            this.lblExperience      = new System.Windows.Forms.Label();
            this.lblTeam            = new System.Windows.Forms.Label();
            this.lblSearchId        = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManagers)).BeginInit();
            this.SuspendLayout();

            // ── Labels ────────────────────────────────────────────────────────
            // NEW: Labels sit 2px above each input so context isn't lost on focus
            this.lblName.AutoSize  = true;
            this.lblName.Font      = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.lblName.Location  = new System.Drawing.Point(30, 78);
            this.lblName.Text      = "Manager Name";

            this.lblNationality.AutoSize  = true;
            this.lblNationality.Font      = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblNationality.ForeColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.lblNationality.Location  = new System.Drawing.Point(170, 78);
            this.lblNationality.Text      = "Nationality";

            this.lblFormation.AutoSize  = true;
            this.lblFormation.Font      = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblFormation.ForeColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.lblFormation.Location  = new System.Drawing.Point(310, 78);
            this.lblFormation.Text      = "Preferred Formation";

            this.lblExperience.AutoSize  = true;
            this.lblExperience.Font      = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblExperience.ForeColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.lblExperience.Location  = new System.Drawing.Point(450, 78);
            this.lblExperience.Text      = "Experience (yrs)";

            this.lblTeam.AutoSize  = true;
            this.lblTeam.Font      = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblTeam.ForeColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.lblTeam.Location  = new System.Drawing.Point(590, 78);
            this.lblTeam.Text      = "Club";  // NEW: replaced "Team ID" label

            this.lblSearchId.AutoSize  = true;
            this.lblSearchId.Font      = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblSearchId.ForeColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.lblSearchId.Location  = new System.Drawing.Point(249, 14);
            this.lblSearchId.Text      = "Search by Manager ID";

            // ── Input Fields ──────────────────────────────────────────────────
            this.txtname.Anchor    = System.Windows.Forms.AnchorStyles.Top;
            this.txtname.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtname.Location  = new System.Drawing.Point(30, 96);
            this.txtname.Name      = "txtname";
            this.txtname.Size      = new System.Drawing.Size(120, 24);
            this.txtname.TabIndex  = 1;

            this.txtnationality.Anchor   = System.Windows.Forms.AnchorStyles.Top;
            this.txtnationality.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtnationality.Location = new System.Drawing.Point(170, 96);
            this.txtnationality.Name     = "txtnationality";
            this.txtnationality.Size     = new System.Drawing.Size(120, 24);
            this.txtnationality.TabIndex = 2;

            this.txtformation.Anchor   = System.Windows.Forms.AnchorStyles.Top;
            this.txtformation.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtformation.Location = new System.Drawing.Point(310, 96);
            this.txtformation.Name     = "txtformation";
            this.txtformation.Size     = new System.Drawing.Size(120, 24);
            this.txtformation.TabIndex = 3;

            this.txtexperienceyear.Anchor   = System.Windows.Forms.AnchorStyles.Top;
            this.txtexperienceyear.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtexperienceyear.Location = new System.Drawing.Point(450, 96);
            this.txtexperienceyear.Name     = "txtexperienceyear";
            this.txtexperienceyear.Size     = new System.Drawing.Size(120, 24);
            this.txtexperienceyear.TabIndex = 4;

            // NEW: ComboBox replaces txtteamid — users select a team by name
            this.cmbTeam.Anchor        = System.Windows.Forms.AnchorStyles.Top;
            this.cmbTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeam.Font          = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbTeam.Location      = new System.Drawing.Point(590, 96);
            this.cmbTeam.Name          = "cmbTeam";
            this.cmbTeam.Size          = new System.Drawing.Size(155, 24);
            this.cmbTeam.TabIndex      = 5;

            this.txtid.BackColor        = System.Drawing.Color.FromArgb(255, 255, 225);
            this.txtid.Font             = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtid.Location         = new System.Drawing.Point(249, 30);
            this.txtid.Multiline        = true;
            this.txtid.Name             = "txtid";
            this.txtid.Size             = new System.Drawing.Size(175, 28);
            this.txtid.TabIndex         = 0;
            this.txtid.TextAlign        = System.Windows.Forms.HorizontalAlignment.Center;

            // ── Buttons ───────────────────────────────────────────────────────
            // NOTE: Flat style, colors, fonts applied at runtime in ApplyModernStyling()
            this.btnBack.Location  = new System.Drawing.Point(12, 12);
            this.btnBack.Name      = "btnBack";
            this.btnBack.Size      = new System.Drawing.Size(80, 30);
            this.btnBack.TabIndex  = 10;
            this.btnBack.Text      = "← Back";
            this.btnBack.Click    += new System.EventHandler(this.btnBack_Click);

            this.search.Anchor    = System.Windows.Forms.AnchorStyles.Top;
            this.search.Location  = new System.Drawing.Point(434, 30);
            this.search.Name      = "search";
            this.search.Size      = new System.Drawing.Size(75, 28);
            this.search.TabIndex  = 11;
            this.search.Text      = "Search";
            this.search.Click    += new System.EventHandler(this.search_Click);

            this.btnAdd.Anchor   = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.Location = new System.Drawing.Point(214, 135);
            this.btnAdd.Name     = "btnAdd";
            this.btnAdd.Size     = new System.Drawing.Size(100, 36);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text     = "+ Add";
            this.btnAdd.Click   += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Anchor   = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpdate.Location = new System.Drawing.Point(324, 135);
            this.btnUpdate.Name     = "btnUpdate";
            this.btnUpdate.Size     = new System.Drawing.Size(100, 36);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text     = "✎ Update";
            this.btnUpdate.Click   += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Anchor   = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.Location = new System.Drawing.Point(434, 135);
            this.btnDelete.Name     = "btnDelete";
            this.btnDelete.Size     = new System.Drawing.Size(100, 36);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text     = "✕ Delete";
            this.btnDelete.Click   += new System.EventHandler(this.btnDelete_Click);

            // ── DataGridView ──────────────────────────────────────────────────
            this.dataGridViewManagers.Anchor =
                System.Windows.Forms.AnchorStyles.Top    |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left   |
                System.Windows.Forms.AnchorStyles.Right;
            this.dataGridViewManagers.AutoSizeColumnsMode  = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // FIX: was SystemColors.ActiveBorder (ugly gray). Now white.
            this.dataGridViewManagers.BackgroundColor      = System.Drawing.Color.White;
            this.dataGridViewManagers.ColumnHeadersHeight  = 36;
            this.dataGridViewManagers.Location             = new System.Drawing.Point(12, 187);
            this.dataGridViewManagers.Name                 = "dataGridViewManagers";
            this.dataGridViewManagers.ReadOnly             = true;
            this.dataGridViewManagers.RowHeadersVisible    = false; // NEW: removes row arrow column
            this.dataGridViewManagers.SelectionMode        = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewManagers.Size                 = new System.Drawing.Size(776, 341);
            this.dataGridViewManagers.TabIndex             = 9;

            // ── Form ──────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(800, 540);
            this.Font                = new System.Drawing.Font("Segoe UI", 9F); // NEW
            this.Controls.Add(this.dataGridViewManagers);
            this.Controls.Add(this.search);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.txtformation);
            this.Controls.Add(this.txtexperienceyear);
            this.Controls.Add(this.txtnationality);
            this.Controls.Add(this.cmbTeam);           // NEW: ComboBox instead of txtteamid
            this.Controls.Add(this.lblName);            // NEW
            this.Controls.Add(this.lblNationality);     // NEW
            this.Controls.Add(this.lblFormation);       // NEW
            this.Controls.Add(this.lblExperience);      // NEW
            this.Controls.Add(this.lblTeam);            // NEW
            this.Controls.Add(this.lblSearchId);        // NEW
            this.Name            = "ManagersForm";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Managers Management";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManagers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.TextBox  txtname;
        private System.Windows.Forms.TextBox  txtnationality;
        private System.Windows.Forms.ComboBox cmbTeam;           // NEW: was TextBox txtteamid
        private System.Windows.Forms.TextBox  txtexperienceyear;
        private System.Windows.Forms.TextBox  txtformation;
        private System.Windows.Forms.TextBox  txtid;
        private System.Windows.Forms.Button   btnBack;
        private System.Windows.Forms.Button   btnAdd;
        private System.Windows.Forms.Button   btnUpdate;
        private System.Windows.Forms.Button   btnDelete;
        private System.Windows.Forms.DataGridView dataGridViewManagers;
        private System.Windows.Forms.Button   search;
        // NEW: Label declarations
        private System.Windows.Forms.Label    lblName;
        private System.Windows.Forms.Label    lblNationality;
        private System.Windows.Forms.Label    lblFormation;
        private System.Windows.Forms.Label    lblExperience;
        private System.Windows.Forms.Label    lblTeam;
        private System.Windows.Forms.Label    lblSearchId;
    }
}
