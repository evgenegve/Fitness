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
    [Serializable]
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        public virtual ICollection<Eating> Eatings { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }


        public User() { }

        public User(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
            }
            Name = name;
        }
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
            if ((birthDate < DateTime.Parse("01.01.1900")) || (birthDate >= DateTime.Now))
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
            return Name + " " + Age;
        }
    }
}
