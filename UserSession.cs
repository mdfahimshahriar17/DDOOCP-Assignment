using System;

namespace _219934_MD_Fahim_Shahriar_FitnessTracker
{
    internal sealed class UserSession
    {
        private static readonly UserSession _instance = new UserSession();

        private UserSession()
        {
        }

        public static UserSession Instance => _instance;

        public int ID { get; set; }

        public string UserName { get; set; }

        public void Clear()
        {
            ID = 0;
            UserName = string.Empty;
        }
    }
}
