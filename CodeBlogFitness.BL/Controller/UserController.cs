using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFintess.CMD.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public List<User>  Users { get; }
        
        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание нового контроллера.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не можеть быть пустым", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(user => user.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }

        //public void SetNewUserData(string genderName, DateTime birthDate, double wight = 1, double height = 1)
        //{
        //    if (string.IsNullOrWhiteSpace(genderName))
        //    {
        //        throw new ArgumentNullException("Пол не может быть пустым.", nameof(genderName));
        //    }
        //    if (birthDate <= DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
        //    {
        //        throw new ArgumentNullException("Некорректная дата.", nameof(birthDate));
        //    }
        //    if (wight <= 0)
        //    {
        //        throw new ArgumentNullException("Некорректное число.", nameof(wight));
        //    }
        //    if (height <= 0)
        //    {
        //        throw new ArgumentNullException("Неккоредтное число.", nameof(height));
        //    }

        //    CurrentUser.Gender = new Gender(genderName);
        //    CurrentUser.BirthDate = birthDate;
        //    CurrentUser.Weight = wight;
        //    CurrentUser.Height = height;

        //    Save();
        //}

        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns>Список пользователей приложения.</returns>
        private List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>();
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void SetNewUserData(string genderName, DateTime birthDate, double weight, double height)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();

        }

        public void Save()
        {
            Save(Users);
        }
      
    }
}
