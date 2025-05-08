using System;
using System.ComponentModel;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]

    public class Food
    {

        #region Свойства
        /// <summary>
        /// Имя продукта.
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Белки в продукте.
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры в продукте.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы в продукте.
        /// </summary>
        public double Carbohydrates { get; }
    
        /// <summary>
        /// Каллорий в продукте.
        /// </summary>
        public double Calories { get; }
        #endregion



        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, 
                    double proteins, 
                    double fats, 
                    double carbohydrates,
                    double calories)
        {

            //TODO: Проверка входных данных.
            
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