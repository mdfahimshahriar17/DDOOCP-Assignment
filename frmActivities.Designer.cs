namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    partial class frmActivities
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.gv = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCalories = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivities = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlDataActivitiesInfo = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbActivityType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSets = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCalories = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtActivityDate = new System.Windows.Forms.DateTimePicker();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.pnlDataActivitiesInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(33, 45, 49);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1096, 70);
            this.label1.TabIndex = 0;
            this.label1.Text = "Activities Information";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.FromArgb(0, 121, 107);
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.FlatAppearance.BorderSize = 0;
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.Location = new System.Drawing.Point(35, 80);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(110, 32);
            this.btnAddNew.TabIndex = 1;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.BackColor = System.Drawing.Color.FromArgb(0, 77, 64);
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(155, 80);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(100, 32);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(265, 82);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(520, 27);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // gv
            // 
            this.gv.AllowUserToAddRows = false;
            this.gv.AllowUserToDeleteRows = false;
            this.gv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.gv.BackgroundColor = System.Drawing.Color.White;
            this.gv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colUser,
            this.coltype,
            this.colDuration,
            this.colDistance,
            this.colSets,
            this.colCalories,
            this.colActivities,
            this.btnEdit,
            this.btnDelete});
            this.gv.Location = new System.Drawing.Point(35, 125);
            this.gv.Name = "gv";
            this.gv.ReadOnly = true;
            this.gv.RowHeadersVisible = false;
            this.gv.RowHeadersWidth = 51;
            this.gv.RowTemplate.Height = 24;
            this.gv.Size = new System.Drawing.Size(1025, 160);
            this.gv.TabIndex = 4;
            this.gv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_CellContentClick);
            // 
            // colID
            // 
            this.colID.HeaderText = "Activity ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 90;
            // 
            // colUser
            // 
            this.colUser.HeaderText = "User ID";
            this.colUser.Name = "colUser";
            this.colUser.ReadOnly = true;
            this.colUser.Width = 90;
            // 
            // coltype
            // 
            this.coltype.HeaderText = "Activity Type";
            this.coltype.Name = "coltype";
            this.coltype.ReadOnly = true;
            this.coltype.Width = 130;
            // 
            // colDuration
            // 
            this.colDuration.HeaderText = "Metric 1";
            this.colDuration.Name = "colDuration";
            this.colDuration.ReadOnly = true;
            this.colDuration.Width = 125;
            // 
            // colDistance
            // 
            this.colDistance.HeaderText = "Metric 2";
            this.colDistance.Name = "colDistance";
            this.colDistance.ReadOnly = true;
            this.colDistance.Width = 125;
            // 
            // colSets
            // 
            this.colSets.HeaderText = "Metric 3";
            this.colSets.Name = "colSets";
            this.colSets.ReadOnly = true;
            this.colSets.Width = 125;
            // 
            // colCalories
            // 
            this.colCalories.HeaderText = "Calculated Calories";
            this.colCalories.Name = "colCalories";
            this.colCalories.ReadOnly = true;
            this.colCalories.Width = 140;
            // 
            // colActivities
            // 
            this.colActivities.HeaderText = "Activity Date";
            this.colActivities.Name = "colActivities";
            this.colActivities.ReadOnly = true;
            this.colActivities.Width = 130;
            // 
            // btnEdit
            // 
            this.btnEdit.HeaderText = "Edit";
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ReadOnly = true;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseColumnTextForButtonValue = true;
            this.btnEdit.Width = 70;
            // 
            // btnDelete
            // 
            this.btnDelete.HeaderText = "Delete";
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ReadOnly = true;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseColumnTextForButtonValue = true;
            this.btnDelete.Width = 70;
            // 
            // pnlDataActivitiesInfo
            // 
            this.pnlDataActivitiesInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlDataActivitiesInfo.BackColor = System.Drawing.Color.White;
            this.pnlDataActivitiesInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDataActivitiesInfo.Controls.Add(this.label4);
            this.pnlDataActivitiesInfo.Controls.Add(this.cmbActivityType);
            this.pnlDataActivitiesInfo.Controls.Add(this.label5);
            this.pnlDataActivitiesInfo.Controls.Add(this.txtDuration);
            this.pnlDataActivitiesInfo.Controls.Add(this.label6);
            this.pnlDataActivitiesInfo.Controls.Add(this.txtDistance);
            this.pnlDataActivitiesInfo.Controls.Add(this.label8);
            this.pnlDataActivitiesInfo.Controls.Add(this.txtSets);
            this.pnlDataActivitiesInfo.Controls.Add(this.label7);
            this.pnlDataActivitiesInfo.Controls.Add(this.txtCalories);
            this.pnlDataActivitiesInfo.Controls.Add(this.label11);
            this.pnlDataActivitiesInfo.Controls.Add(this.dtActivityDate);
            this.pnlDataActivitiesInfo.Controls.Add(this.btnInsert);
            this.pnlDataActivitiesInfo.Controls.Add(this.btnClear);
            this.pnlDataActivitiesInfo.Controls.Add(this.btnClose);
            this.pnlDataActivitiesInfo.Location = new System.Drawing.Point(190, 310);
            this.pnlDataActivitiesInfo.Name = "pnlDataActivitiesInfo";
            this.pnlDataActivitiesInfo.Size = new System.Drawing.Size(720, 235);
            this.pnlDataActivitiesInfo.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(0, 77, 64);
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(35, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "Activity Type:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbActivityType
            // 
            this.cmbActivityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActivityType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbActivityType.FormattingEnabled = true;
            this.cmbActivityType.Location = new System.Drawing.Point(205, 25);
            this.cmbActivityType.Name = "cmbActivityType";
            this.cmbActivityType.Size = new System.Drawing.Size(170, 28);
            this.cmbActivityType.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(0, 77, 64);
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(35, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 26);
            this.label5.TabIndex = 2;
            this.label5.Text = "Metric 1:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDuration
            // 
            this.txtDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDuration.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDuration.Location = new System.Drawing.Point(205, 65);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(125, 27);
            this.txtDuration.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(0, 77, 64);
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(35, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 26);
            this.label6.TabIndex = 3;
            this.label6.Text = "Metric 2:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDistance
            // 
            this.txtDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDistance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDistance.Location = new System.Drawing.Point(205, 105);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(125, 27);
            this.txtDistance.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(0, 77, 64);
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(390, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 26);
            this.label8.TabIndex = 4;
            this.label8.Text = "Metric 3:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSets
            // 
            this.txtSets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSets.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSets.Location = new System.Drawing.Point(575, 25);
            this.txtSets.Name = "txtSets";
            this.txtSets.Size = new System.Drawing.Size(125, 27);
            this.txtSets.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(0, 77, 64);
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(35, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 26);
            this.label7.TabIndex = 5;
            this.label7.Text = "Calories:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCalories
            // 
            this.txtCalories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCalories.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCalories.Location = new System.Drawing.Point(205, 145);
            this.txtCalories.Name = "txtCalories";
            this.txtCalories.ReadOnly = true;
            this.txtCalories.Size = new System.Drawing.Size(125, 27);
            this.txtCalories.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(0, 77, 64);
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(390, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(175, 26);
            this.label11.TabIndex = 6;
            this.label11.Text = "Activity Date:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtActivityDate
            // 
            this.dtActivityDate.CustomFormat = "yyyy/MM/dd";
            this.dtActivityDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtActivityDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtActivityDate.Location = new System.Drawing.Point(575, 65);
            this.dtActivityDate.Name = "dtActivityDate";
            this.dtActivityDate.Size = new System.Drawing.Size(125, 27);
            this.dtActivityDate.TabIndex = 6;
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.FromArgb(0, 121, 107);
            this.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsert.FlatAppearance.BorderSize = 0;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.Location = new System.Drawing.Point(225, 190);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(95, 32);
            this.btnInsert.TabIndex = 7;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(0, 121, 107);
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(335, 190);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(95, 32);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(198, 40, 40);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(445, 190);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 32);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmActivities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 248, 246);
            this.ClientSize = new System.Drawing.Size(1096, 575);
            this.Controls.Add(this.pnlDataActivitiesInfo);
            this.Controls.Add(this.gv);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.label1);
            this.Name = "frmActivities";
            this.Text = "Activities";
            this.Load += new System.EventHandler(this.frmActivities_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.pnlDataActivitiesInfo.ResumeLayout(false);
            this.pnlDataActivitiesInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gv;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlDataActivitiesInfo;
        private System.Windows.Forms.ComboBox cmbActivityType;
        private System.Windows.Forms.DateTimePicker dtActivityDate;
        private System.Windows.Forms.TextBox txtSets;
        private System.Windows.Forms.TextBox txtCalories;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltype;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSets;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCalories;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivities;
        private System.Windows.Forms.DataGridViewButtonColumn btnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn btnDelete;
    }
}
