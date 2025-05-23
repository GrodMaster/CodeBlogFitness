﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFintess.CMD.Controller;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.BL.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(10, 200));

            //Act
            exerciseController.Add(activity, DateTime.Now.AddHours(-2), DateTime.Now.AddHours(-1));

            //Assert
            Assert.AreEqual(activity.Name, exerciseController.Activities.Last().Name);
        }
    }
}