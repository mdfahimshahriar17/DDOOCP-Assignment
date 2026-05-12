using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    public partial class frmActivities : Form
    {
        private readonly ActivityManager activityManager = new ActivityManager();
        private readonly GoalManager goalManager = new GoalManager();
        private int currentActivityId = 0;

        public frmActivities()
        {
            InitializeComponent();
            // Apply the same theme immediately so Design View and runtime are consistent.
            AppTheme.Apply(this);
        }

        private void frmActivities_Load(object sender, EventArgs e)
        {
            AppTheme.Apply(this);
            cmbActivityType.SelectedIndexChanged += cmbActivityType_SelectedIndexChanged;

            PrepareActivityForm();
            LoadActivityTypes();
            LoadActivityGrid();
            pnlDataActivitiesInfo.Visible = false;
        }

        private void PrepareActivityForm()
        {
            // Configure the activity grid and keep only the assignment-required fields visible.
            foreach (DataGridViewColumn column in gv.Columns)
            {
                column.Frozen = false;
            }

            txtCalories.ReadOnly = true;
            txtCalories.TabStop = false;

            colID.Visible = false;
            colUser.Visible = false;
            colDuration.HeaderText = "Metric 1";
            colDistance.HeaderText = "Metric 2";
            colSets.HeaderText = "Metric 3";
            colCalories.HeaderText = "Calculated Calories";
            colActivities.HeaderText = "Activity Date";
        }

        private void LoadActivityTypes()
        {
            // Populate the six assignment activities from the activity factory.
            cmbActivityType.Items.Clear();
            cmbActivityType.Items.Add("------Select------");
            foreach (string activityType in FitnessActivityFactory.ActivityTypes)
            {
                cmbActivityType.Items.Add(activityType);
            }
            cmbActivityType.SelectedIndex = 0;
        }

        private void cmbActivityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMetricLabels();
        }

        private void UpdateMetricLabels()
        {
            // Each activity has three different metric labels, so the input captions change dynamically.
            if (cmbActivityType.SelectedIndex <= 0)
            {
                label5.Text = "Metric 1:";
                label6.Text = "Metric 2:";
                label8.Text = "Metric 3:";
                return;
            }

            FitnessActivity activity = FitnessActivityFactory.Create(cmbActivityType.Text);
            label5.Text = activity.Metric1Label + ":";
            label6.Text = activity.Metric2Label + ":";
            label8.Text = activity.Metric3Label + ":";
        }

        private void LoadActivityGrid()
        {
            // Refresh only the current user's activity records.
            BindActivityGrid(activityManager.GetActivitiesForUser(UserSession.Instance.ID));
        }

        private void BindActivityGrid(DataTable table)
        {
            // Bind database columns to the grid while hiding internal IDs from the user.
            gv.AutoGenerateColumns = false;
            colID.DataPropertyName = "ActivityID";
            colUser.DataPropertyName = "UserID";
            coltype.DataPropertyName = "ActivityType";
            colDuration.DataPropertyName = "Duration";
            colDistance.DataPropertyName = "Distance";
            colSets.DataPropertyName = "Sets";
            colCalories.DataPropertyName = "Calories";
            colActivities.DataPropertyName = "ActivityDate";
            gv.DataSource = table;
            gv.AllowUserToAddRows = false;
        }

        private void gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            try
            {
                if (e.ColumnIndex == btnEdit.Index)
                {
                    EditSelectedActivity(e.RowIndex);
                }
                else if (e.ColumnIndex == btnDelete.Index)
                {
                    DeleteSelectedActivity(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Activity Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditSelectedActivity(int rowIndex)
        {
            int activityId = Convert.ToInt32(gv.Rows[rowIndex].Cells[colID.Index].Value);
            DataRow row = activityManager.GetActivityForUser(UserSession.Instance.ID, activityId);
            if (row == null)
            {
                MessageBox.Show("The selected activity could not be found.", "Activity Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadActivityGrid();
                return;
            }

            pnlDataActivitiesInfo.Visible = true;
            btnInsert.Text = "Update";
            currentActivityId = activityId;
            cmbActivityType.Text = row["ActivityType"].ToString();
            txtDuration.Text = Convert.ToDouble(row["Duration"]).ToString("0.##");
            txtDistance.Text = Convert.ToDouble(row["Distance"]).ToString("0.##");
            txtSets.Text = Convert.ToDouble(row["Sets"]).ToString("0.##");
            txtCalories.Text = Convert.ToDouble(row["Calories"]).ToString("0.00");
            dtActivityDate.Value = Convert.ToDateTime(row["ActivityDate"]);
            UpdateMetricLabels();
        }

        private void DeleteSelectedActivity(int rowIndex)
        {
            int activityId = Convert.ToInt32(gv.Rows[rowIndex].Cells[colID.Index].Value);
            DialogResult dialog = MessageBox.Show("Confirm deletion of this activity record?",
                "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog != DialogResult.Yes)
            {
                return;
            }

            int result = activityManager.DeleteActivity(UserSession.Instance.ID, activityId);
            if (result > 0)
            {
                LoadActivityGrid();
                MessageBox.Show("Activity deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Activity was not deleted. Please try again.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearForm()
        {
            currentActivityId = 0;
            txtDuration.Clear();
            txtDistance.Clear();
            txtSets.Clear();
            txtCalories.Clear();
            cmbActivityType.SelectedIndex = 0;
            dtActivityDate.Value = DateTime.Now;
            btnInsert.Text = "Insert";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            pnlDataActivitiesInfo.Visible = true;
            txtDuration.Focus();
        }

        private bool TryReadMetrics(out double metric1, out double metric2, out double metric3)
        {
            // Convert and validate the three metric values required by the selected activity.
            metric1 = 0;
            metric2 = 0;
            metric3 = 0;

            StringBuilder message = new StringBuilder();
            string activityType = cmbActivityType.Text;

            if (cmbActivityType.SelectedIndex <= 0)
            {
                message.AppendLine("Please select an activity type.");
            }

            if (!double.TryParse(txtDuration.Text.Trim(), out metric1))
            {
                message.AppendLine("Please enter a numeric value for Metric 1.");
            }

            if (!double.TryParse(txtDistance.Text.Trim(), out metric2))
            {
                message.AppendLine("Please enter a numeric value for Metric 2.");
            }

            if (!double.TryParse(txtSets.Text.Trim(), out metric3))
            {
                message.AppendLine("Please enter a numeric value for Metric 3.");
            }

            if (message.Length == 0)
            {
                message.Append(ValidationHelper.ValidateActivityMetrics(activityType, metric1, metric2, metric3));
            }

            if (message.Length > 0)
            {
                MessageBox.Show(message.ToString(), "Metric Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private double CalculateCaloriesFromSelectedActivity(double metric1, double metric2, double metric3)
        {
            // Polymorphism: the selected activity class supplies its own calorie formula.
            FitnessActivity activity = FitnessActivityFactory.Create(cmbActivityType.Text);
            return Math.Round(activity.CalculateCalories(metric1, metric2, metric3), 2);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            double metric1;
            double metric2;
            double metric3;

            if (!TryReadMetrics(out metric1, out metric2, out metric3))
            {
                return;
            }

            try
            {
                double calories = CalculateCaloriesFromSelectedActivity(metric1, metric2, metric3);
                txtCalories.Text = calories.ToString("0.00");

                int result;
                if (btnInsert.Text == "Insert")
                {
                    result = activityManager.SaveActivity(UserSession.Instance.ID, cmbActivityType.Text, metric1, metric2, metric3, calories, dtActivityDate.Value);
                }
                else
                {
                    result = activityManager.UpdateActivity(UserSession.Instance.ID, currentActivityId, cmbActivityType.Text, metric1, metric2, metric3, calories, dtActivityDate.Value);
                }

                if (result > 0)
                {
                    LoadActivityGrid();
                    pnlDataActivitiesInfo.Visible = false;
                    string action = btnInsert.Text == "Insert" ? "saved" : "updated";
                    MessageBox.Show("Activity " + action + ". Calories calculated automatically: " + calories.ToString("0.00") + " kcal.\n" + BuildProgressMessage(),
                        "Activity Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("The activity could not be saved. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Activity Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuildProgressMessage()
        {
            double totalCalories = activityManager.GetTotalCaloriesBurned(UserSession.Instance.ID);
            double goalCalories = goalManager.GetLatestGoalCalories(UserSession.Instance.ID);

            if (goalCalories <= 0)
            {
                return "Total calories burned: " + totalCalories.ToString("0.00") + " kcal. No goal has been set yet.";
            }

            if (totalCalories >= goalCalories)
            {
                return "Total calories burned: " + totalCalories.ToString("0.00") + " kcal. Goal achieved.";
            }

            double remaining = goalCalories - totalCalories;
            return "Total calories burned: " + totalCalories.ToString("0.00") + " kcal. Remaining to goal: " + remaining.ToString("0.00") + " kcal.";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindActivityGrid(activityManager.SearchActivitiesForUser(UserSession.Instance.ID, txtSearch.Text.Trim()));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlDataActivitiesInfo.Visible = false;
        }

    }
}
