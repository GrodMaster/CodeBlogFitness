using System;
using System.Collections.Generic;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Exercise> Exercise { get; set; }

        public double CalloriesPerMinute { get; set; }

        public Activity() { }

        public Activity(string name, double calloriesPerMinute)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название не может быть мустым.", nameof(name));
            }
            if (calloriesPerMinute <= 0)
            {
                throw new ArgumentNullException("Неверное число.", nameof(calloriesPerMinute));
            }

            Name = name;
            CalloriesPerMinute = calloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
