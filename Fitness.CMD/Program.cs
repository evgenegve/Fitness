using System;
using Fitness.BL.Model;
using Fitness.BL.Controller;
using System.Resources;
using System.Globalization;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Collections.Generic;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {

            var culture = CultureInfo.CreateSpecificCulture("ru_ru");
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);

            
            Console.WriteLine("Введите имя");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол пользователя");
                var gender = Console.ReadLine();

                var birthDate = InputDateTime("дату рождения");

                var weight = InputDouble("вес");
                
                var height = InputDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - ввести прием пищи");
            Console.WriteLine("A - ввести упражнение");
            Console.WriteLine("Q - выход");

            var key = Console.ReadKey();
            Console.WriteLine();

            switch (key.Key)
            {
                case ConsoleKey.E:
                    var foods = EnterEating();
                    eatingController.Add(foods.Item1, foods.Item2);

                    foreach (var item in eatingController.Eating.Foods)
                    {
                        Console.WriteLine(item.Key.Name);
                    }
                    break;
                case ConsoleKey.A:
                    var exercise = EnterExercise();
                    exerciseController.Add(exercise.Item3, exercise.Item1, exercise.Item2);

                    foreach (var item in exerciseController.Exercises)
                    {
                        Console.WriteLine(item.Activity.Name);
                    }
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
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
            var weight = InputDouble("вес порции");

            var product = new Food(foodName, proteins, fats, carbo, calories);
            return (product, weight);

        }

        private static (DateTime, DateTime, Activity) EnterExercise()
        {
            Console.WriteLine("Введите имя активности:");
            var activityName = Console.ReadLine();
            var calories = InputDouble("калорийность");
            var start = InputDateTime("начало");
            var end = InputDateTime("конец");

            return (start, end, new Activity(activityName,calories));

        }

        static DateTime InputDateTime(string name)
        {
            DateTime date; 
            string input;
            do
            {
                Console.WriteLine($"Введите {name}");
                input = Console.ReadLine();
            }
            while (!DateTime.TryParse(input, out date));
            return date;
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
