using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Пол
    /// </summary>
    [Serializable]
    public class Gender
    {
        public string Name { get; }

        public Gender(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Пол не может быть пустым", nameof(name));

            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
