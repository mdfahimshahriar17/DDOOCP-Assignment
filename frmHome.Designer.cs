namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    partial class frmHome
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
            this.pbxHome = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHome)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxHome
            // 
            this.pbxHome.BackColor = System.Drawing.Color.White;
            this.pbxHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxHome.Image = global::_219934_MD_Fahim_Shahriar_FitnessTracker.Properties.Resources.HomeImage;
            this.pbxHome.Location = new System.Drawing.Point(0, 0);
            this.pbxHome.Name = "pbxHome";
            this.pbxHome.Size = new System.Drawing.Size(848, 511);
            this.pbxHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxHome.TabIndex = 0;
            this.pbxHome.TabStop = false;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(848, 511);
            this.Controls.Add(this.pbxHome);
            this.Name = "frmHome";
            this.Text = "Fitness Tracker Home";
            ((System.ComponentModel.ISupportInitialize)(this.pbxHome)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pbxHome;
    }
}
