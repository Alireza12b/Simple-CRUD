﻿using CRUD_For_Users.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CRUD_For_Users.Services
{
    public class UserServices : IUserServices
    {
        private string mainPath;
        private List<User> user;

        public UserServices()
        {
            string jsonPath = Path.Combine("DataStorage", "Users.json");
            string currentDirectory = Directory.GetCurrentDirectory();
            mainPath = Path.Combine(currentDirectory, jsonPath);

            string allText = File.ReadAllText(mainPath);
            user = JsonConvert.DeserializeObject<List<User>>(allText);
        }
        

    }
}
