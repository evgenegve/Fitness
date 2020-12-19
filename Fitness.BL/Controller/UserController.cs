﻿using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    class UserController
    {
        public User User { get; set; }

        public UserController(User user)
        {

            User = user ?? throw new ArgumentNullException("Пользователь должен быть задан", nameof(user));
        }
        public void Save()
        {
            var formatter = new BinaryFormatter();
            
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }            
        }

        public User Load()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                return formatter.Deserialize(fs) as User;
            }
             
        }

    }
}