using System;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Exercise
    {

        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public Activity Activity { get; set; }

        public User User { get; }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user) 
        {
            //TODO: Проверка входных данных

            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}
