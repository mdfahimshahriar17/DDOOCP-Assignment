using System;
using System.Drawing;
using System.Windows.Forms;

namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    public partial class frmUserGoals : Form
    {
        private readonly GoalManager goalManager = new GoalManager();

        public frmUserGoals()
        {
            InitializeComponent();
            // Apply the same theme immediately so Design View and runtime are consistent.
            AppTheme.Apply(this);
            PositionGoalCard();
        }

        private void frmUserGoals_Load(object sender, EventArgs e)
        {
            this.Text = "Calorie Goal";
            lblUser.Text = "User: " + UserSession.Instance.UserName;
            PositionGoalCard();
            LoadCurrentGoal();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            PositionGoalCard();
        }

        private void PositionGoalCard()
        {
            // Keep the goal card centred when hosted inside the dashboard panel.
            if (pnlGoalCard != null)
            {
                int left = Math.Max(20, (this.ClientSize.Width - pnlGoalCard.Width) / 2);
                pnlGoalCard.Location = new Point(left, 130);
            }
        }

        private void LoadCurrentGoal()
        {
            double currentGoal = goalManager.GetLatestGoalCalories(UserSession.Instance.ID);
            if (currentGoal > 0)
            {
                lblCurrentGoal.Text = "Current goal: " + currentGoal.ToString("0") + " calories";
                txtCurrentGoalInput.Text = currentGoal.ToString("0");
            }
            else
            {
                lblCurrentGoal.Text = "Current goal: not set";
                txtCurrentGoalInput.Clear();
            }
        }

        private void btnSaveGoal_Click(object sender, EventArgs e)
        {
            int goalCalories;
            if (!int.TryParse(txtCurrentGoalInput.Text.Trim(), out goalCalories) || goalCalories <= 0)
            {
                MessageBox.Show("Please enter a valid positive whole-number calorie goal.",
                    "Goal Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrentGoalInput.Focus();
                return;
            }

            try
            {
                // Save one current calorie target for the logged-in user.
                int result = goalManager.SaveCurrentGoal(UserSession.Instance.ID, goalCalories);
                if (result > 0)
                {
                    lblCurrentGoal.Text = "Current goal: " + goalCalories + " calories";
                    lblPreview.Text = "Goal saved for " + UserSession.Instance.UserName + ". Open Progress to compare it with your total calories.";
                    MessageBox.Show("Goal saved successfully.", "Goal Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The goal could not be saved. Please try again.",
                        "Goal Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Goal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetInput_Click(object sender, EventArgs e)
        {
            txtCurrentGoalInput.Clear();
            txtCurrentGoalInput.Focus();
        }
    }
}
