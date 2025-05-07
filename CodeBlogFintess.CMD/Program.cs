using CodeBlogFintess.CMD.Controller;
using System;

namespace CodeBlogFintess.CMD
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Вас приветствует приложение CodeBlogFitness.");
            
            Console.WriteLine("Введите имя пользователя.");
            var name = Console.ReadLine();

            Console.WriteLine("Введите пол.");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения.");
            var birthdate = DateTime.Parse(Console.ReadLine()); //TODO: переписать TryParse

            Console.WriteLine("Введите свой вес.");
            var wight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите свой рост.");
            var height= double.Parse(Console.ReadLine());


            var userController = new UserController(name, gender, birthdate, wight, height);

            userController.Save();
        }
    }
}
