using System;
using System.Drawing;
using System.Windows.Forms;

namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    public partial class frmMonitoring_Progress : Form
    {
        private readonly ActivityManager activityManager = new ActivityManager();
        private readonly GoalManager goalManager = new GoalManager();

        public frmMonitoring_Progress()
        {
            InitializeComponent();
            AppTheme.Apply(this);
            this.Load += frmMonitoring_Progress_Load;
            btnInsert.Click += btnInsert_Click;
            PositionProgressCard();
        }

        private void frmMonitoring_Progress_Load(object sender, EventArgs e)
        {
            SetupDisplay();
            PositionProgressCard();
            LoadProgress();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            PositionProgressCard();
        }

        private void PositionProgressCard()
        {
            // Keep the monitoring card centred inside the dashboard content panel.
            if (groupBox1 != null)
            {
                int left = Math.Max(20, (this.ClientSize.Width - groupBox1.Width) / 2);
                groupBox1.Location = new Point(left, 45);
            }
        }

        private void SetupDisplay()
        {
            groupBox1.Text = "Monitoring Progress";
            label4.Text = "User:";
            label3.Text = "Total Calories:";
            label1.Text = "Goal Calories:";
            label2.Text = "Progress Status:";
            btnInsert.Text = "Refresh";

            cmbActivityType.Items.Clear();
            cmbActivityType.Items.Add(UserSession.Instance.UserName);
            cmbActivityType.SelectedIndex = 0;
            cmbActivityType.Enabled = false;

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            LoadProgress();
        }

        private void LoadProgress()
        {
            try
            {
                double totalCalories = activityManager.GetTotalCaloriesBurned(UserSession.Instance.ID);
                double goalCalories = goalManager.GetLatestGoalCalories(UserSession.Instance.ID);

                textBox1.Text = totalCalories.ToString("0.00") + " kcal";
                textBox2.Text = goalCalories > 0 ? goalCalories.ToString("0.00") + " kcal" : "No goal set";

                // Compare the user's total calories with the latest saved calorie goal.
                if (goalCalories <= 0)
                {
                    lblProgressStatus.Text = "Please set a calorie goal first.";
                }
                else if (totalCalories >= goalCalories)
                {
                    lblProgressStatus.Text = "Goal achieved. Well done!";
                }
                else
                {
                    double remaining = goalCalories - totalCalories;
                    lblProgressStatus.Text = "Goal not achieved. Remaining: " + remaining.ToString("0.00") + " kcal.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Progress Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
