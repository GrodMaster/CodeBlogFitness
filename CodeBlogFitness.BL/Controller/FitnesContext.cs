using CodeBlogFitness.BL.Model;
using System;
using System.Data.Entity;

namespace CodeBlogFitness.BL.Controller
{
    public class FitnesContext : DbContext
    {
        public FitnesContext() : base("DBConnection")
        {

        } 

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
