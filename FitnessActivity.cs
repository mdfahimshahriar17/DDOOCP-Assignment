using System;

namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    /// <summary>
    /// Base class for all fitness activities. Every activity has exactly three predefined metrics
    /// and a calorie calculation that uses those metrics.
    /// </summary>
    internal abstract class FitnessActivity
    {
        public string ActivityType { get; private set; }
        public string Metric1Label { get; private set; }
        public string Metric2Label { get; private set; }
        public string Metric3Label { get; private set; }

        protected FitnessActivity(string activityType, string metric1Label, string metric2Label, string metric3Label)
        {
            ActivityType = activityType;
            Metric1Label = metric1Label;
            Metric2Label = metric2Label;
            Metric3Label = metric3Label;
        }

        public abstract double CalculateCalories(double metric1, double metric2, double metric3);
    }

    internal sealed class WalkingActivity : FitnessActivity
    {
        public WalkingActivity() : base("Walking", "Steps", "Distance (km)", "Time Taken (minutes)") { }

        public override double CalculateCalories(double steps, double distanceKm, double minutes)
        {
            return (steps * 0.04) + (distanceKm * 30.0) + (minutes * 2.8);
        }
    }

    internal sealed class SwimmingActivity : FitnessActivity
    {
        public SwimmingActivity() : base("Swimming", "Number of Laps", "Time Taken (minutes)", "Average Heart Rate (bpm)") { }

        public override double CalculateCalories(double laps, double minutes, double heartRate)
        {
            return (laps * 2.0) + (minutes * 6.0) + (heartRate * 0.15);
        }
    }

    internal sealed class RunningActivity : FitnessActivity
    {
        public RunningActivity() : base("Running", "Distance (km)", "Time Taken (minutes)", "Average Heart Rate (bpm)") { }

        public override double CalculateCalories(double distanceKm, double minutes, double heartRate)
        {
            return (distanceKm * 65.0) + (minutes * 3.0) + (heartRate * 0.12);
        }
    }

    internal sealed class CyclingActivity : FitnessActivity
    {
        public CyclingActivity() : base("Cycling", "Distance (km)", "Time Taken (minutes)", "Average Speed (km/h)") { }

        public override double CalculateCalories(double distanceKm, double minutes, double speed)
        {
            return (distanceKm * 30.0) + (minutes * 2.5) + (speed * 3.0);
        }
    }

    internal sealed class JumpRopeActivity : FitnessActivity
    {
        public JumpRopeActivity() : base("Jump Rope", "Number of Jumps", "Time Taken (minutes)", "Intensity Level (1-10)") { }

        public override double CalculateCalories(double jumps, double minutes, double intensity)
        {
            return (jumps * 0.08) + (minutes * 7.5) + (intensity * 8.0);
        }
    }

    internal sealed class YogaActivity : FitnessActivity
    {
        public YogaActivity() : base("Yoga", "Time Taken (minutes)", "Poses Completed", "Average Heart Rate (bpm)") { }

        public override double CalculateCalories(double minutes, double poses, double heartRate)
        {
            return (minutes * 2.5) + (poses * 1.8) + (heartRate * 0.08);
        }
    }

    internal static class FitnessActivityFactory
    {
        public static readonly string[] ActivityTypes =
        {
            "Walking",
            "Swimming",
            "Running",
            "Cycling",
            "Jump Rope",
            "Yoga"
        };

        public static FitnessActivity Create(string activityType)
        {
            switch ((activityType ?? string.Empty).Trim())
            {
                case "Walking":
                    return new WalkingActivity();
                case "Swimming":
                    return new SwimmingActivity();
                case "Running":
                    return new RunningActivity();
                case "Cycling":
                    return new CyclingActivity();
                case "Jump Rope":
                    return new JumpRopeActivity();
                case "Yoga":
                    return new YogaActivity();
                default:
                    throw new ArgumentException("Please select a valid activity type.");
            }
        }
    }
}
