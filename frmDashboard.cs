using System;
using System.Drawing;
using System.Windows.Forms;

namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    public partial class frmDashboard : Form
    {
        private Form activeForm = null;

        public frmDashboard()
        {
            InitializeComponent();
            // Apply the same theme immediately so Design View and runtime are consistent.
            AppTheme.Apply(this);
            ApplyDashboardColours();
        }

        private void openChildForm(Form childForm)
        {
            // Show only one child screen at a time inside the dashboard container.
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(childForm);
            pnlContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            ApplyDashboardColours();
            btnActivity.Text = "Activities";
            btnUserGoals.Text = "Goals";
            btnAbout.Text = "Progress";
            toolStripStatusLabelClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
            timer1.Start();
            toolStripStatusLabelMSG.Text = "Welcome " + UserSession.Instance.UserName;
            openChildForm(new frmHome());
        }

        private void ApplyDashboardColours()
        {
            pnlLeft.BackColor = Color.FromArgb(0, 77, 64);
            pnlTop.BackColor = Color.FromArgb(0, 121, 107);
            pnlContainer.BackColor = Color.FromArgb(241, 248, 246);
            statusStrip1.BackColor = Color.FromArgb(0, 77, 64);
            statusStrip1.ForeColor = Color.White;
            label1.BackColor = Color.FromArgb(0, 121, 107);
            label1.ForeColor = Color.White;
            pnlLogo.BackColor = Color.FromArgb(0, 77, 64);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openChildForm(new frmHome());
        }

        private void btnActivity_Click(object sender, EventArgs e)
        {
            openChildForm(new frmActivities());
        }

        private void btnUserGoals_Click(object sender, EventArgs e)
        {
            openChildForm(new frmUserGoals());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserSession.Instance.Clear();
            this.Close();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            openChildForm(new frmMonitoring_Progress());
        }
    }
}
