using CodeBlogFitness.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFintess.CMD.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; } 

        /// <summary>
        /// Создание нового контроллера.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName, 
                              string genderName, 
                              DateTime birdthDate, 
                              double wight, 
                              double height)
        {
            //TODO: проверка входных данных.

            var gender = new Gender(genderName);

            User = new User(userName, gender, birdthDate, wight, height);
            
        }

        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns>Пользователь приложения.</returns>
        /// <exception cref="FileLoadException"></exception>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var file = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(file) is User user)
                {
                    User = user;
                }
                //TODO: Что делать если нет файла или не прочитали пользователя?
            }

        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            //try
            //{
                using(var file = new FileStream("users.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(file, User);
                }
            //}
            //catch (Exception error)
            //{
            //    throw new Exception($"Ошибка записи. {error}");
            //}
        }

      
    }
}
