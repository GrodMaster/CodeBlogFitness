using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]

    public class Food
    {

        #region Свойства

        public int Id { get; set; }

        /// <summary>
        /// Имя продукта.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Белки в продукте.
        /// </summary>
        public double Proteins { get; set; }

        /// <summary>
        /// Жиры в продукте.
        /// </summary>
        public double Fats { get; set; }

        /// <summary>
        /// Углеводы в продукте.
        /// </summary>
        public double Carbohydrates { get; set; }
    
        /// <summary>
        /// Каллорий в продукте.
        /// </summary>
        public double Calories { get; set; }
        #endregion
        public virtual ICollection<Eating> Eatings { get; set; }

        public Food() { }
        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, 
                    double proteins, 
                    double fats, 
                    double carbohydrates,
                    double calories)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название не может быть пустым.", nameof(name));
            }
            if (proteins <= 0)
            {
                throw new ArgumentNullException("Не корректное число.", nameof(proteins));
            }
            if (fats <= 0)
            {
                throw new ArgumentNullException("Не корректное число.", nameof(fats));
            }
            if (carbohydrates <= 0)
            {
                throw new ArgumentNullException("Не корректное число.", nameof(carbohydrates));
            }
            if (calories <= 0)
            {
                throw new ArgumentNullException("Не корректное число.", nameof(calories));
            }

            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}