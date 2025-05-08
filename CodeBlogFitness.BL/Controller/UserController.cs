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

        private const string FILE_NAME = "users.dat";

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
                Save();
            }
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double wight = 1, double height = 1)
        {
            // TODO: проверка
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = wight;
            CurrentUser.Height = height;

            Save();
        }

        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns>Список пользователей приложения.</returns>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(FILE_NAME) ?? new List<User>();
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        private void Save()
        {
            Save(FILE_NAME, Users);
        }

      
    }
}
