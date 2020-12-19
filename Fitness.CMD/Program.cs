using System;
using Fitness.BL.Model;
using Fitness.BL.Controller;


namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол пользователя");
                var gender = Console.ReadLine();

                var birthDate = InputBirthDate();

                var weight = InputDouble("вес");
                
                var height = InputDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }


            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }


        static DateTime InputBirthDate()
        {
            DateTime birthDate; // date of birth
            string input;

            do
            {
                Console.WriteLine("Введите дату рождения в формате дд.ММ.гггг (день.месяц.год):");
                input = Console.ReadLine();
            }
            while (!DateTime.TryParse(input, out birthDate));

            return birthDate;
        }

        static double InputDouble(string name)
        {
            double value; // date of birth
            string input;

            do
            {
                Console.WriteLine($"Введите {name} пользователя");
                input = Console.ReadLine();
            }
            while (!Double.TryParse(input, out value));

            return value;
        }





    }
}
