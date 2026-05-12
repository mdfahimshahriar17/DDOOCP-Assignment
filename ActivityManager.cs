using System;
using System.Data;
using System.Data.SqlClient;

namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    /// <summary>
    /// Handles activity persistence and total calorie calculations for the logged-in user.
    /// </summary>
    internal sealed class ActivityManager
    {
        public DataTable GetActivitiesForUser(int userId)
        {
            return DatabaseHelper.ExecuteDataTable(
                "SELECT * FROM tblActivities WHERE UserID = @UserID ORDER BY ActivityDate DESC, ActivityID DESC",
                p => p.Add("@UserID", SqlDbType.Int).Value = userId);
        }

        public DataTable SearchActivitiesForUser(int userId, string searchText)
        {
            return DatabaseHelper.ExecuteDataTable(
                "SELECT * FROM tblActivities WHERE UserID = @UserID AND (CAST(ActivityID AS VARCHAR(20)) LIKE @Search OR ActivityType LIKE @Search) ORDER BY ActivityDate DESC, ActivityID DESC",
                p =>
                {
                    p.Add("@UserID", SqlDbType.Int).Value = userId;
                    p.Add("@Search", SqlDbType.VarChar, 80).Value = "%" + searchText + "%";
                });
        }

        public DataRow GetActivityForUser(int userId, int activityId)
        {
            DataTable table = DatabaseHelper.ExecuteDataTable(
                "SELECT * FROM tblActivities WHERE ActivityID = @ActivityID AND UserID = @UserID",
                p =>
                {
                    p.Add("@ActivityID", SqlDbType.Int).Value = activityId;
                    p.Add("@UserID", SqlDbType.Int).Value = userId;
                });

            return table.Rows.Count == 0 ? null : table.Rows[0];
        }

        public int SaveActivity(int userId, string activityType, double metric1, double metric2, double metric3, double calories, DateTime activityDate)
        {
            using (SqlConnection connection = DatabaseHelper.CreateConnection())
            using (SqlCommand command = new SqlCommand(@"
INSERT INTO tblActivities (UserID, ActivityType, Duration, Distance, Calories, Sets, Repetitions, PosesCompleted, ElevationGain, ActivityDate)
VALUES (@UserID, @ActivityType, @Duration, @Distance, @Calories, @Sets, @Repetitions, @PosesCompleted, @ElevationGain, @ActivityDate)", connection))
            {
                AddActivityParameters(command, userId, activityType, metric1, metric2, metric3, calories, activityDate);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public int UpdateActivity(int userId, int activityId, string activityType, double metric1, double metric2, double metric3, double calories, DateTime activityDate)
        {
            using (SqlConnection connection = DatabaseHelper.CreateConnection())
            using (SqlCommand command = new SqlCommand(@"
UPDATE tblActivities
SET ActivityType = @ActivityType,
    Duration = @Duration,
    Distance = @Distance,
    Calories = @Calories,
    Sets = @Sets,
    Repetitions = @Repetitions,
    PosesCompleted = @PosesCompleted,
    ElevationGain = @ElevationGain,
    ActivityDate = @ActivityDate
WHERE ActivityID = @ActivityID AND UserID = @UserID", connection))
            {
                command.Parameters.Add("@ActivityID", SqlDbType.Int).Value = activityId;
                AddActivityParameters(command, userId, activityType, metric1, metric2, metric3, calories, activityDate);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public int DeleteActivity(int userId, int activityId)
        {
            using (SqlConnection connection = DatabaseHelper.CreateConnection())
            using (SqlCommand command = new SqlCommand("DELETE FROM tblActivities WHERE ActivityID = @ActivityID AND UserID = @UserID", connection))
            {
                command.Parameters.Add("@ActivityID", SqlDbType.Int).Value = activityId;
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public double GetTotalCaloriesBurned(int userId)
        {
            using (SqlConnection connection = DatabaseHelper.CreateConnection())
            using (SqlCommand command = new SqlCommand("SELECT ISNULL(SUM(Calories), 0) FROM tblActivities WHERE UserID = @UserID", connection))
            {
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
                connection.Open();
                return Math.Round(Convert.ToDouble(command.ExecuteScalar()), 2);
            }
        }

        private static void AddActivityParameters(SqlCommand command, int userId, string activityType, double metric1, double metric2, double metric3, double calories, DateTime activityDate)
        {
            command.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
            command.Parameters.Add("@ActivityType", SqlDbType.VarChar, 50).Value = activityType;
            command.Parameters.Add("@Duration", SqlDbType.Float).Value = metric1;
            command.Parameters.Add("@Distance", SqlDbType.Float).Value = metric2;
            command.Parameters.Add("@Calories", SqlDbType.Float).Value = calories;
            command.Parameters.Add("@Sets", SqlDbType.Float).Value = metric3;
            command.Parameters.Add("@Repetitions", SqlDbType.Int).Value = 0;
            command.Parameters.Add("@PosesCompleted", SqlDbType.Int).Value = 0;
            command.Parameters.Add("@ElevationGain", SqlDbType.Float).Value = 0;
            command.Parameters.Add("@ActivityDate", SqlDbType.DateTime).Value = activityDate;
        }
    }
}
