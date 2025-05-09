using CodeBlogFintess.CMD.Controller;
using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace CodeBlogFintess.CMD
{
    class Program
    {
        static void Main(string[] args)
        {

            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resurceMeneger = new ResourceManager("CodeBlogFintess.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resurceMeneger.GetString("Hello", culture));
            
            Console.Write(resurceMeneger.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingContreller(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол.");
                var gender = Console.ReadLine();

                var birthDate = ParsDateTime();
                var weight = ParsDouble("Вес");
                var height = ParsDouble("Рост");


                userController.SetNewUserData(gender, birthDate, weight, height);

            }
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("Е - ввести прием пищи.");
            var key = Console.ReadKey();
            Console.WriteLine();
            if(key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();

            var calories = ParsDouble("Калорийность");

            var prot = ParsDouble("Белки");

            var fats = ParsDouble("Жиры");

            var carbs = ParsDouble("Углеводы");

            var weight = ParsDouble("Вес порции");
            var product = new Food(food, prot, fats, carbs, calories);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParsDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введите дату рождения: dd.MM.yyyy : ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты.");
                }
            }

            return birthDate;
        }

        private static double ParsDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name} : ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}.");
                }
            }
        }
    }
}
