using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public double Calories { get; set; }
        public Activity() { }
        public Activity(string name, double calories)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя активности не может быть пустым", nameof(name));
            }
            if (calories <= 0)
            {
                throw new ArgumentException("Недопустимое число калорий пользователя", nameof(calories));
            }

            Name = name;
            Calories = calories;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
