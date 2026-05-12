using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    /// <summary>
    /// Centralises database access and repairs/creates the tables required for Task 1.
    /// </summary>
    internal static class DatabaseHelper
    {
        public const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Fitness.mdf;Integrated Security=True";

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static void EnsureDatabaseReady()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath);

            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();

                ExecuteNonQuery(connection, @"
IF OBJECT_ID('dbo.tblUser', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.tblUser
    (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Username VARCHAR(50) NOT NULL,
        Password VARCHAR(50) NOT NULL
    );
END;");

                ExecuteNonQuery(connection, @"
IF COL_LENGTH('dbo.tblUser', 'Email') IS NOT NULL
BEGIN
    ALTER TABLE dbo.tblUser ALTER COLUMN Email VARCHAR(100) NULL;
END;");

                ExecuteNonQuery(connection, @"
IF OBJECT_ID('dbo.tblActivities', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.tblActivities
    (
        ActivityID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        UserID INT NOT NULL,
        ActivityType VARCHAR(50) NOT NULL,
        Duration FLOAT NOT NULL,
        Distance FLOAT NOT NULL,
        Calories FLOAT NOT NULL,
        Sets FLOAT NOT NULL,
        Repetitions INT NULL,
        PosesCompleted INT NULL,
        ElevationGain FLOAT NULL,
        ActivityDate DATETIME NOT NULL,
        CONSTRAINT FK_tblActivities_tblUser FOREIGN KEY (UserID) REFERENCES dbo.tblUser(Id)
    );
END;");



                ExecuteNonQuery(connection, @"
IF OBJECT_ID('dbo.tblActivities', 'U') IS NOT NULL
BEGIN
    ALTER TABLE dbo.tblActivities ALTER COLUMN Duration FLOAT NOT NULL;
    ALTER TABLE dbo.tblActivities ALTER COLUMN Sets FLOAT NOT NULL;
END;");

                ExecuteNonQuery(connection, @"
IF OBJECT_ID('dbo.tblUserGoals', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.tblUserGoals
    (
        GoalID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        UserID INT NOT NULL,
        GoalCalories INT NOT NULL,
        CONSTRAINT FK_tblUserGoals_tblUser FOREIGN KEY (UserID) REFERENCES dbo.tblUser(Id)
    );
END;");

                ExecuteNonQuery(connection, @"
IF COL_LENGTH('dbo.tblUserGoals', 'GoalCalaries') IS NOT NULL
   AND COL_LENGTH('dbo.tblUserGoals', 'GoalCalories') IS NULL
BEGIN
    EXEC sp_rename 'dbo.tblUserGoals.GoalCalaries', 'GoalCalories', 'COLUMN';
END;");

                ExecuteNonQuery(connection, @"
IF OBJECT_ID('dbo.tblAppSettings', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.tblAppSettings
    (
        SettingKey VARCHAR(80) NOT NULL PRIMARY KEY,
        SettingValue VARCHAR(200) NULL
    );
END;");

                CleanPreviousSubmissionHistoryOnce(connection);
            }
        }

        private static void CleanPreviousSubmissionHistoryOnce(SqlConnection connection)
        {
            const string cleanupKey = "CleanedForFinalSubmissionV3";

            using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM dbo.tblAppSettings WHERE SettingKey = @SettingKey", connection))
            {
                checkCommand.Parameters.Add("@SettingKey", SqlDbType.VarChar, 80).Value = cleanupKey;
                int alreadyCleaned = Convert.ToInt32(checkCommand.ExecuteScalar());
                if (alreadyCleaned > 0)
                {
                    return;
                }
            }

            // Final submission should start clean, without old friend/test history.
            // The cleanup runs once only, then normal user data is kept on later runs.
            ExecuteNonQuery(connection, @"
IF OBJECT_ID('dbo.tblActivities', 'U') IS NOT NULL DELETE FROM dbo.tblActivities;
IF OBJECT_ID('dbo.tblUserGoals', 'U') IS NOT NULL DELETE FROM dbo.tblUserGoals;
IF OBJECT_ID('dbo.tblUser', 'U') IS NOT NULL DELETE FROM dbo.tblUser;
IF OBJECT_ID('dbo.tblActivities', 'U') IS NOT NULL DBCC CHECKIDENT ('dbo.tblActivities', RESEED, 0);
IF OBJECT_ID('dbo.tblUserGoals', 'U') IS NOT NULL DBCC CHECKIDENT ('dbo.tblUserGoals', RESEED, 0);
IF OBJECT_ID('dbo.tblUser', 'U') IS NOT NULL DBCC CHECKIDENT ('dbo.tblUser', RESEED, 0);");

            using (SqlCommand insertCommand = new SqlCommand("INSERT INTO dbo.tblAppSettings (SettingKey, SettingValue) VALUES (@SettingKey, @SettingValue)", connection))
            {
                insertCommand.Parameters.Add("@SettingKey", SqlDbType.VarChar, 80).Value = cleanupKey;
                insertCommand.Parameters.Add("@SettingValue", SqlDbType.VarChar, 200).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                insertCommand.ExecuteNonQuery();
            }
        }

        private static void ExecuteNonQuery(SqlConnection connection, string sql)
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public static DataTable ExecuteDataTable(string sql, Action<SqlParameterCollection> addParameters)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                if (addParameters != null)
                {
                    addParameters(command.Parameters);
                }

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
    }
}
