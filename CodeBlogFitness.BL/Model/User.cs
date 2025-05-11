using System;
using System.Collections.Generic;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Своества

        public int Id { get; set; }


        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        public virtual Gender Gender { get; set; }

        public int? GenderId { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion
        public virtual ICollection<Eating> Eatings { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="birthDate">Дата рождения.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>

        public User() { }

        public User(string name, 
                    Gender gender, 
                    DateTime birthDate, 
                    double weight, 
                    double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым.", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Гендер не может быть пустым.", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Неправильная дата рождения.", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Неправильный вес.", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Неправильный рост.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым.", nameof(name));
            }

            Name = name;
        }
        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
