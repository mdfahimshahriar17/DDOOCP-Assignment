using System;
using System.Data;
using System.Data.SqlClient;

namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    /// <summary>
    /// Stores and retrieves calorie goals per logged-in user.
    /// </summary>
    internal sealed class GoalManager
    {
        public DataTable GetGoalsForUser(int userId)
        {
            return DatabaseHelper.ExecuteDataTable(
                "SELECT GoalID, UserID, GoalCalories FROM tblUserGoals WHERE UserID = @UserID ORDER BY GoalID DESC",
                p => p.Add("@UserID", SqlDbType.Int).Value = userId);
        }

        public DataTable SearchGoalsForUser(int userId, string searchText)
        {
            return DatabaseHelper.ExecuteDataTable(
                "SELECT GoalID, UserID, GoalCalories FROM tblUserGoals WHERE UserID = @UserID AND CAST(GoalID AS VARCHAR(20)) LIKE @Search ORDER BY GoalID DESC",
                p =>
                {
                    p.Add("@UserID", SqlDbType.Int).Value = userId;
                    p.Add("@Search", SqlDbType.VarChar, 50).Value = "%" + searchText + "%";
                });
        }

        public int SaveCurrentGoal(int userId, int goalCalories)
        {
            int latestGoalId = GetLatestGoalId(userId);
            if (latestGoalId > 0)
            {
                return UpdateGoal(userId, latestGoalId, goalCalories);
            }

            using (SqlConnection connection = DatabaseHelper.CreateConnection())
            using (SqlCommand command = new SqlCommand("INSERT INTO tblUserGoals (UserID, GoalCalories) VALUES (@UserID, @GoalCalories)", connection))
            {
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
                command.Parameters.Add("@GoalCalories", SqlDbType.Int).Value = goalCalories;
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public int UpdateGoal(int userId, int goalId, int goalCalories)
        {
            using (SqlConnection connection = DatabaseHelper.CreateConnection())
            using (SqlCommand command = new SqlCommand("UPDATE tblUserGoals SET GoalCalories = @GoalCalories WHERE GoalID = @GoalID AND UserID = @UserID", connection))
            {
                command.Parameters.Add("@GoalID", SqlDbType.Int).Value = goalId;
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
                command.Parameters.Add("@GoalCalories", SqlDbType.Int).Value = goalCalories;
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public int DeleteGoal(int userId, int goalId)
        {
            using (SqlConnection connection = DatabaseHelper.CreateConnection())
            using (SqlCommand command = new SqlCommand("DELETE FROM tblUserGoals WHERE GoalID = @GoalID AND UserID = @UserID", connection))
            {
                command.Parameters.Add("@GoalID", SqlDbType.Int).Value = goalId;
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public int GetLatestGoalId(int userId)
        {
            using (SqlConnection connection = DatabaseHelper.CreateConnection())
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 GoalID FROM tblUserGoals WHERE UserID = @UserID ORDER BY GoalID DESC", connection))
            {
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
                connection.Open();
                object value = command.ExecuteScalar();
                return value == null || value == DBNull.Value ? 0 : Convert.ToInt32(value);
            }
        }

        public double GetLatestGoalCalories(int userId)
        {
            using (SqlConnection connection = DatabaseHelper.CreateConnection())
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 GoalCalories FROM tblUserGoals WHERE UserID = @UserID ORDER BY GoalID DESC", connection))
            {
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
                connection.Open();
                object value = command.ExecuteScalar();
                return value == null || value == DBNull.Value ? 0 : Convert.ToDouble(value);
            }
        }
    }
}
