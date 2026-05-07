using System.Windows.Forms;

namespace EPL_DBMS.Forms
{
    partial class PlayersForm
    {
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtposition;
        private System.Windows.Forms.TextBox txtage;
        private System.Windows.Forms.TextBox txtnationality;
        private System.Windows.Forms.TextBox txtteamid;

        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button search;

        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dataGridViewPlayers;
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.btnBack = new System.Windows.Forms.Button();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtposition = new System.Windows.Forms.TextBox();
            this.txtage = new System.Windows.Forms.TextBox();
            this.txtnationality = new System.Windows.Forms.TextBox();
            this.txtteamid = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.dataGridViewPlayers = new System.Windows.Forms.DataGridView();
            this.search = new System.Windows.Forms.Button();
            this.btnPlayerInjuries = new System.Windows.Forms.Button();
            this.btnPlayerStats = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.SystemColors.Info;
            this.txtid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtid.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(263, 17);
            this.txtid.Multiline = true;
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(180, 28);
            this.txtid.TabIndex = 0;
            this.txtid.Text = "ENTER PLAYER ID";
            this.txtid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtname
            // 
            this.txtname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtname.Location = new System.Drawing.Point(58, 78);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(139, 22);
            this.txtname.TabIndex = 0;
            // 
            // txtposition
            // 
            this.txtposition.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtposition.Location = new System.Drawing.Point(230, 78);
            this.txtposition.Name = "txtposition";
            this.txtposition.Size = new System.Drawing.Size(120, 22);
            this.txtposition.TabIndex = 1;
            // 
            // txtage
            // 
            this.txtage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtage.Location = new System.Drawing.Point(379, 78);
            this.txtage.Name = "txtage";
            this.txtage.Size = new System.Drawing.Size(80, 22);
            this.txtage.TabIndex = 2;
            // 
            // txtnationality
            // 
            this.txtnationality.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtnationality.Location = new System.Drawing.Point(490, 78);
            this.txtnationality.Name = "txtnationality";
            this.txtnationality.Size = new System.Drawing.Size(120, 22);
            this.txtnationality.TabIndex = 3;
            // 
            // txtteamid
            // 
            this.txtteamid.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtteamid.Location = new System.Drawing.Point(646, 78);
            this.txtteamid.Name = "txtteamid";
            this.txtteamid.Size = new System.Drawing.Size(80, 22);
            this.txtteamid.TabIndex = 4;
            // 
            // add
            // 
            this.add.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.add.Location = new System.Drawing.Point(203, 114);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(93, 37);
            this.add.TabIndex = 5;
            this.add.Text = "Add";
            this.add.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // update
            // 
            this.update.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.update.Location = new System.Drawing.Point(340, 114);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(93, 37);
            this.update.TabIndex = 6;
            this.update.Text = "Update";
            this.update.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // delete
            // 
            this.delete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.delete.Location = new System.Drawing.Point(481, 114);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(93, 37);
            this.delete.TabIndex = 7;
            this.delete.Text = "Delete";
            this.delete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridViewPlayers
            // 
            this.dataGridViewPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPlayers.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewPlayers.ColumnHeadersHeight = 29;
            this.dataGridViewPlayers.Location = new System.Drawing.Point(20, 179);
            this.dataGridViewPlayers.Name = "dataGridViewPlayers";
            this.dataGridViewPlayers.ReadOnly = true;
            this.dataGridViewPlayers.RowHeadersWidth = 51;
            this.dataGridViewPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPlayers.Size = new System.Drawing.Size(579, 310);
            this.dataGridViewPlayers.TabIndex = 8;
            this.dataGridViewPlayers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPlayers_CellClick);
            // 
            // search
            // 
            this.search.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.search.Location = new System.Drawing.Point(473, 16);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(68, 29);
            this.search.TabIndex = 9;
            this.search.Text = "Search";
            this.search.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPlayerInjuries
            // 
            this.btnPlayerInjuries.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPlayerInjuries.Location = new System.Drawing.Point(646, 338);
            this.btnPlayerInjuries.Name = "btnPlayerInjuries";
            this.btnPlayerInjuries.Size = new System.Drawing.Size(93, 62);
            this.btnPlayerInjuries.TabIndex = 10;
            this.btnPlayerInjuries.Text = "Injuries";
            this.btnPlayerInjuries.Click += new System.EventHandler(this.btnPlayerInjuries_Click);
            // 
            // btnPlayerStats
            // 
            this.btnPlayerStats.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPlayerStats.Location = new System.Drawing.Point(646, 269);
            this.btnPlayerStats.Name = "btnPlayerStats";
            this.btnPlayerStats.Size = new System.Drawing.Size(93, 62);
            this.btnPlayerStats.TabIndex = 11;
            this.btnPlayerStats.Text = "Stats";
            this.btnPlayerStats.Click += new System.EventHandler(this.btnPlayerStats_Click);
            // 
            // PlayersForm
            // 
            this.ClientSize = new System.Drawing.Size(775, 510);
            this.Controls.Add(this.btnPlayerStats);
            this.Controls.Add(this.btnPlayerInjuries);
            this.Controls.Add(this.search);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.txtposition);
            this.Controls.Add(this.txtage);
            this.Controls.Add(this.txtnationality);
            this.Controls.Add(this.txtteamid);
            this.Controls.Add(this.add);
            this.Controls.Add(this.update);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.dataGridViewPlayers);
            this.Name = "PlayersForm";
            this.Text = "Players";
            this.Load += new System.EventHandler(this.PlayersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private Button btnPlayerInjuries;
        private Button btnPlayerStats;
    }
}
