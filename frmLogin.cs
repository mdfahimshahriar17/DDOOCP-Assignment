using System;
using System.Text;
using System.Windows.Forms;

namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    public partial class frmLogin : Form
    {
        private readonly UserManager userManager = new UserManager();
        private int failedLoginAttempts = 0;
        private const int MaxFailedLoginAttempts = 3;

        public frmLogin()
        {
            InitializeComponent();
            // Apply the same theme immediately so Design View and runtime are consistent.
            AppTheme.Apply(this);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Keep user-facing text centralised in the Load event.
            this.Text = "Fitness Tracker - Login";
            groupBox1.Text = "Login to Fitness Tracker";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            StringBuilder message = new StringBuilder();
            string username = txtLoginUserName.Text.Trim();
            string password = txtLoginPassword.Text.Trim();

            // Validate input before querying the database.
            if (username.Length == 0)
            {
                message.AppendLine("Please enter your username.");
            }
            else if (!ValidationHelper.IsValidUsername(username))
            {
                message.AppendLine("Username can only contain letters and numbers.");
            }

            if (password.Length == 0)
            {
                message.AppendLine("Please enter your password.");
            }

            if (message.Length > 0)
            {
                MessageBox.Show(message.ToString(), "Login Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId;
            string storedUsername;
            if (userManager.TryLogin(username, password, out userId, out storedUsername))
            {
                // Store the logged-in user's identity for goals, activities and progress pages.
                failedLoginAttempts = 0;
                UserSession.Instance.ID = userId;
                UserSession.Instance.UserName = storedUsername;

                this.Hide();
                using (frmDashboard dashboard = new frmDashboard())
                {
                    dashboard.ShowDialog();
                }
                this.Show();
                txtLoginPassword.Clear();
                txtLoginPassword.Focus();
                return;
            }

            // Assignment requirement: handle a reasonable number of failed login attempts.
            failedLoginAttempts++;
            int remainingAttempts = MaxFailedLoginAttempts - failedLoginAttempts;

            if (failedLoginAttempts >= MaxFailedLoginAttempts)
            {
                btnLogin.Enabled = false;
                MessageBox.Show("Too many failed login attempts. Login is disabled for this session.",
                    "Login Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Invalid username or password. Attempts remaining: " + remainingAttempts,
                    "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linklbl_Register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open registration as a modal form, then return to login.
            this.Hide();
            using (frmRegister registerForm = new frmRegister())
            {
                registerForm.ShowDialog();
            }
            this.Show();
        }
    }
}
