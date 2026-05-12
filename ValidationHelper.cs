using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    /// <summary>
    /// Validation rules from the assignment brief and safe checks for numeric activity metrics.
    /// </summary>
    internal static class ValidationHelper
    {
        public static bool IsValidUsername(string username)
        {
            return !string.IsNullOrWhiteSpace(username) && Regex.IsMatch(username.Trim(), "^[A-Za-z0-9]+$");
        }

        public static bool IsValidPassword(string password)
        {
            return !string.IsNullOrEmpty(password)
                   && password.Length == 12
                   && password.Any(char.IsLower)
                   && password.Any(char.IsUpper);
        }

        public static string ValidateActivityMetrics(string activityType, double metric1, double metric2, double metric3)
        {
            StringBuilder message = new StringBuilder();

            if (metric1 <= 0)
            {
                message.AppendLine("Metric 1 must be greater than zero.");
            }

            if (metric2 <= 0)
            {
                message.AppendLine("Metric 2 must be greater than zero.");
            }

            if (metric3 <= 0)
            {
                message.AppendLine("Metric 3 must be greater than zero.");
            }

            switch (activityType)
            {
                case "Walking":
                    RequireWholeNumber(metric1, "Steps", message);
                    break;
                case "Swimming":
                    RequireWholeNumber(metric1, "Number of laps", message);
                    ValidateHeartRate(metric3, message);
                    break;
                case "Running":
                    ValidateHeartRate(metric3, message);
                    break;
                case "Cycling":
                    if (metric3 > 80)
                    {
                        message.AppendLine("Average speed looks too high. Please enter a realistic km/h value.");
                    }
                    break;
                case "Jump Rope":
                    RequireWholeNumber(metric1, "Number of jumps", message);
                    if (metric3 < 1 || metric3 > 10)
                    {
                        message.AppendLine("Intensity level must be between 1 and 10.");
                    }
                    break;
                case "Yoga":
                    RequireWholeNumber(metric2, "Poses completed", message);
                    ValidateHeartRate(metric3, message);
                    break;
            }

            return message.ToString();
        }

        private static void ValidateHeartRate(double heartRate, StringBuilder message)
        {
            if (heartRate < 40 || heartRate > 220)
            {
                message.AppendLine("Average heart rate must be between 40 and 220 bpm.");
            }
        }

        private static void RequireWholeNumber(double value, string label, StringBuilder message)
        {
            if (Math.Abs(value - Math.Round(value)) > 0.0001)
            {
                message.AppendLine(label + " must be a whole number.");
            }
        }
    }
}
