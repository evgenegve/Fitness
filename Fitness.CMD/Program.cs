using System;
using Fitness.BL.Model;
using Fitness.BL.Controller;
using System.Resources;
using System.Globalization;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {

            var culture = CultureInfo.CreateSpecificCulture("en_us");
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture ));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

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

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - ввести прием пищи");
            
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Item1, foods.Item2);

                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine(item.Key.Name);
                }
                
            }

            Console.ReadLine();
        }

        private static (Food, double) EnterEating()
        {
            Console.WriteLine("Введите имя продукта:");
            var foodName = Console.ReadLine();


            var calories = InputDouble("калорийность");
            var carbo = InputDouble("углеводы");
            var fats = InputDouble("жиры");
            var proteins = InputDouble("белки");


            var product = new Food(foodName, proteins, fats, carbo, calories);
            var weight = InputDouble("вес порции");

            return (product, weight);

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
                Console.WriteLine($"Введите {name}");
                input = Console.ReadLine();
            }
            while (!Double.TryParse(input, out value));

            return value;
        }





    }
}
