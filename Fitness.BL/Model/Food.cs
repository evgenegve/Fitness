using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Еда
    /// </summary>
    [Serializable]
    public class Food
    {
        public string Name { get; }
        public double Proteins { get; } 
        public double Fats { get; }
        public double Carbohydrates { get; }
        public double Calories { get; }

        public Food(string name) : this(name, 0, 0, 0, 0) {}
        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
            }
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }


    }
}
