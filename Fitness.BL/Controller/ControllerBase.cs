using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public abstract class ControllerBase
    {
        private readonly IDataSaver manager = new DatabaseDataSaver();
        protected List<T> Load<T>() where T:class
        {
            return manager.Load<T>();
        }

        protected void Save<T>(List<T> items) where T: class
        {
            manager.Save(items);
        }
    }
}
