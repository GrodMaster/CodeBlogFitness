using System;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public Exercise() { }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user) 
        {

            if (start <= DateTime.Parse("01.01.1900") || start > DateTime.Now)
            {
                throw new ArgumentNullException("Неверная дата.", nameof(start));
            }
            if (finish <= DateTime.Parse("01.01.1900") || finish > DateTime.Now)
            {
                throw new ArgumentNullException("Неверная дата.", nameof(finish));
            }
            if (activity == null)
            {
                throw new ArgumentNullException("Не может быть пустым." , nameof(activity));
            }
            if (user == null)
            {
                throw new ArgumentNullException("Не может быть пустым.", nameof(user));
            }

            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}
