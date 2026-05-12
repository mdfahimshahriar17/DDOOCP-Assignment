using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    internal static class Program
    {
        /// <summary>
        /// Main entry point for the Fitness Tracker application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;

            try
            {
                DatabaseHelper.EnsureDatabaseReady();
                Application.Run(new frmLogin());
            }
            catch (SqlException ex)
            {
                MessageBox.Show("The application could not connect to the Fitness Tracker database.\n\n" +
                                "Please open the project in Visual Studio and make sure SQL Server LocalDB is installed.\n\n" +
                                "Details: " + ex.Message,
                                "Fitness Tracker Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The application could not start.\n\n" +
                                "Details: " + ex.Message,
                                "Fitness Tracker Startup Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("An unexpected error occurred. Please try again or restart the application.\n\n" +
                            "Details: " + e.Exception.Message,
                            "Fitness Tracker Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }
}
