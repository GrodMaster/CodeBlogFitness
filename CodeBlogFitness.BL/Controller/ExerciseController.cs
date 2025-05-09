using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private readonly User User;

        private const string EXERCISES_FILE_NAME = "exercises.dat";

        private const string ACTIVITIES_FILE_NAME = "activityes.dat";

        public List<Exercise> Exercises { get; }

        public List<Activity> Activities { get; }

        public ExerciseController(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Activities = GetAllActivities();
            Exercises = GetAllExercises();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        public void Add(Activity activiti, DateTime begin, DateTime endBegin)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activiti.Name);
            if (act == null) 
            {
                Activities.Add(activiti);

                var execise = new Exercise(begin, endBegin, activiti, User);
                Exercises.Add(execise);
            }
            else
            {
                var execise = new Exercise(begin, endBegin, act, User);
                Exercises.Add(execise);
            }

            Save();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }
    }
}
