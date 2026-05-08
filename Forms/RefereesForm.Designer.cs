namespace EPL_DBMS.Forms
{
    partial class RefereesForm
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
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtnationality = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridViewReferees = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReferees)).BeginInit();
            this.SuspendLayout();

            // txtname
            this.txtname.Location = new System.Drawing.Point(256, 70);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(120, 22);

            // txtnationality
            this.txtnationality.Location = new System.Drawing.Point(411, 70);
            this.txtnationality.Name = "txtnationality";
            this.txtnationality.Size = new System.Drawing.Size(120, 22);

            // txtid
            this.txtid.Location = new System.Drawing.Point(283, 15);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(194, 24);
            // Notice: Event handler removed here!

            // btnBack
            this.btnBack.Location = new System.Drawing.Point(10, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(547, 119);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 40);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(334, 119);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 40);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(121, 119);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 40);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // dataGridViewReferees
            this.dataGridViewReferees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReferees.Location = new System.Drawing.Point(11, 201);
            this.dataGridViewReferees.Name = "dataGridViewReferees";
            this.dataGridViewReferees.Size = new System.Drawing.Size(738, 259);
            this.dataGridViewReferees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewReferees_CellClick);

            // RefereesForm
            this.ClientSize = new System.Drawing.Size(760, 472);
            this.Controls.Add(this.txtnationality);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.dataGridViewReferees);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtid);
            this.Name = "RefereesForm";
            this.Text = "Referees";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReferees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtnationality;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridViewReferees;
    }
}