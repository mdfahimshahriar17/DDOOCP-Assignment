using System;
using System.Data;
using System.Data.SqlClient;

namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    /// <summary>
    /// Handles registration, duplicate username checks and login authentication.
    /// </summary>
    internal sealed class UserManager
    {
        public bool UsernameExists(string username)
        {
            using (SqlConnection connection = DatabaseHelper.CreateConnection())
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM tblUser WHERE Username = @Username", connection))
            {
                command.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        public int Register(string username, string password)
        {
            // The assignment brief asks for username and password only.
            using (SqlConnection connection = DatabaseHelper.CreateConnection())
            using (SqlCommand command = new SqlCommand("INSERT INTO tblUser (Username, Password) VALUES (@Username, @Password)", connection))
            {
                command.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;
                command.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = password;

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public bool TryLogin(string username, string password, out int userId, out string storedUsername)
        {
            userId = 0;
            storedUsername = string.Empty;

            using (SqlConnection connection = DatabaseHelper.CreateConnection())
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 Id, Username FROM tblUser WHERE Username = @Username AND Password = @Password", connection))
            {
                command.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;
                command.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = password;

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return false;
                    }

                    userId = Convert.ToInt32(reader["Id"]);
                    storedUsername = reader["Username"].ToString();
                    return true;
                }
            }
        }
    }
}
