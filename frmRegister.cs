using System;
using System.Text;
using System.Windows.Forms;

namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    public partial class frmRegister : Form
    {
        private readonly UserManager userManager = new UserManager();

        public frmRegister()
        {
            InitializeComponent();
            // Apply the same theme immediately so Design View and runtime are consistent.
            AppTheme.Apply(this);
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            this.Text = "Fitness Tracker - Register";
            groupBox1.Text = "Create New Account";
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            StringBuilder message = new StringBuilder();
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            // Enforce the assignment rules before creating the user account.
            if (!ValidationHelper.IsValidUsername(username))
            {
                message.AppendLine("Username is required and can only contain letters and numbers.");
            }

            if (!ValidationHelper.IsValidPassword(password))
            {
                message.AppendLine("Password must be exactly 12 characters and include at least one lowercase and one uppercase letter.");
            }

            if (password != confirmPassword)
            {
                message.AppendLine("Password and confirm password do not match.");
            }

            if (message.Length > 0)
            {
                MessageBox.Show(message.ToString(), "Registration Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Duplicate username check keeps the login identity unique.
                if (userManager.UsernameExists(username))
                {
                    MessageBox.Show("This username already exists. Please choose another username.",
                        "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int result = userManager.Register(username, password);
                if (result > 0)
                {
                    MessageBox.Show("Registration completed successfully. You can now log in.",
                        "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.",
                        "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Prevent invalid username characters while the user is typing.
            if ((!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar)) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void linklbl_AlreadyRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
