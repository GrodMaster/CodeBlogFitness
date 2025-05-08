using CodeBlogFintess.CMD.Controller;
using System;

namespace CodeBlogFintess.CMD
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Вас приветствует приложение CodeBlogFitness.");
            
            Console.Write("Введите имя пользователя.");
            var name = Console.ReadLine();

            var userController = new UserController(name);
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
                    Console.WriteLine($"Неверный формат {name}а.");
                }
            }
        }
    }
}
