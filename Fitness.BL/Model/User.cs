using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    class User
    {
        public string Name { get; }
        public Gender Gender { get; }
        public DateTime BirthDate { get; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Проверка параметров
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Пол пользователя не может быть пустым", nameof(gender));
            }
            if ((birthDate < DateTime.Parse("01.01.1900")) || (birthDate > DateTime.Now))
            {
                throw new ArgumentException("Возраст пользователя не может быть больше 120 лет или отрицательным", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Недопустимый вес пользователя", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Недопустимый рост пользователя", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
