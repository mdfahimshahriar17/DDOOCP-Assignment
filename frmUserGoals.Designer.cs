namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    partial class frmUserGoals
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlGoalCard = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblCurrentGoal = new System.Windows.Forms.Label();
            this.lblGoalInput = new System.Windows.Forms.Label();
            this.txtCurrentGoalInput = new System.Windows.Forms.TextBox();
            this.btnSaveGoal = new System.Windows.Forms.Button();
            this.btnResetInput = new System.Windows.Forms.Button();
            this.lblPreview = new System.Windows.Forms.Label();
            this.pnlGoalCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(849, 80);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Calorie Goal";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlGoalCard
            // 
            this.pnlGoalCard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlGoalCard.BackColor = System.Drawing.Color.White;
            this.pnlGoalCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGoalCard.Controls.Add(this.lblUser);
            this.pnlGoalCard.Controls.Add(this.lblCurrentGoal);
            this.pnlGoalCard.Controls.Add(this.lblGoalInput);
            this.pnlGoalCard.Controls.Add(this.txtCurrentGoalInput);
            this.pnlGoalCard.Controls.Add(this.btnSaveGoal);
            this.pnlGoalCard.Controls.Add(this.btnResetInput);
            this.pnlGoalCard.Controls.Add(this.lblPreview);
            this.pnlGoalCard.Location = new System.Drawing.Point(145, 130);
            this.pnlGoalCard.Name = "pnlGoalCard";
            this.pnlGoalCard.Size = new System.Drawing.Size(560, 300);
            this.pnlGoalCard.TabIndex = 1;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(64)))));
            this.lblUser.Location = new System.Drawing.Point(40, 30);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(480, 28);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "User:";
            // 
            // lblCurrentGoal
            // 
            this.lblCurrentGoal.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblCurrentGoal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.lblCurrentGoal.Location = new System.Drawing.Point(40, 70);
            this.lblCurrentGoal.Name = "lblCurrentGoal";
            this.lblCurrentGoal.Size = new System.Drawing.Size(480, 28);
            this.lblCurrentGoal.TabIndex = 1;
            this.lblCurrentGoal.Text = "Current goal: not set";
            // 
            // lblGoalInput
            // 
            this.lblGoalInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(64)))));
            this.lblGoalInput.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblGoalInput.ForeColor = System.Drawing.Color.White;
            this.lblGoalInput.Location = new System.Drawing.Point(40, 125);
            this.lblGoalInput.Name = "lblGoalInput";
            this.lblGoalInput.Size = new System.Drawing.Size(160, 30);
            this.lblGoalInput.TabIndex = 2;
            this.lblGoalInput.Text = "Goal Calories:";
            this.lblGoalInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCurrentGoalInput
            // 
            this.txtCurrentGoalInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentGoalInput.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCurrentGoalInput.Location = new System.Drawing.Point(215, 128);
            this.txtCurrentGoalInput.Name = "txtCurrentGoalInput";
            this.txtCurrentGoalInput.Size = new System.Drawing.Size(170, 30);
            this.txtCurrentGoalInput.TabIndex = 3;
            // 
            // btnSaveGoal
            // 
            this.btnSaveGoal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.btnSaveGoal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveGoal.FlatAppearance.BorderSize = 0;
            this.btnSaveGoal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveGoal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveGoal.ForeColor = System.Drawing.Color.White;
            this.btnSaveGoal.Location = new System.Drawing.Point(120, 190);
            this.btnSaveGoal.Name = "btnSaveGoal";
            this.btnSaveGoal.Size = new System.Drawing.Size(130, 38);
            this.btnSaveGoal.TabIndex = 4;
            this.btnSaveGoal.Text = "Save Goal";
            this.btnSaveGoal.UseVisualStyleBackColor = false;
            this.btnSaveGoal.Click += new System.EventHandler(this.btnSaveGoal_Click);
            // 
            // btnResetInput
            // 
            this.btnResetInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.btnResetInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetInput.FlatAppearance.BorderSize = 0;
            this.btnResetInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetInput.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnResetInput.ForeColor = System.Drawing.Color.White;
            this.btnResetInput.Location = new System.Drawing.Point(275, 190);
            this.btnResetInput.Name = "btnResetInput";
            this.btnResetInput.Size = new System.Drawing.Size(130, 38);
            this.btnResetInput.TabIndex = 5;
            this.btnResetInput.Text = "Clear";
            this.btnResetInput.UseVisualStyleBackColor = false;
            this.btnResetInput.Click += new System.EventHandler(this.btnResetInput_Click);
            // 
            // lblPreview
            // 
            this.lblPreview.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.lblPreview.Location = new System.Drawing.Point(40, 245);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(480, 35);
            this.lblPreview.TabIndex = 6;
            this.lblPreview.Text = "Enter a positive whole-number calorie target, for example 300.";
            this.lblPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmUserGoals
            // 
            this.AcceptButton = this.btnSaveGoal;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(849, 569);
            this.Controls.Add(this.pnlGoalCard);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmUserGoals";
            this.Text = "Calorie Goal";
            this.Load += new System.EventHandler(this.frmUserGoals_Load);
            this.pnlGoalCard.ResumeLayout(false);
            this.pnlGoalCard.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlGoalCard;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblCurrentGoal;
        private System.Windows.Forms.Label lblGoalInput;
        private System.Windows.Forms.TextBox txtCurrentGoalInput;
        private System.Windows.Forms.Button btnSaveGoal;
        private System.Windows.Forms.Button btnResetInput;
        private System.Windows.Forms.Label lblPreview;
    }
}
