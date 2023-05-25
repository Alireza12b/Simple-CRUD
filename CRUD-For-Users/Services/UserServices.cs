using CRUD_For_Users.Exceptions;
using CRUD_For_Users.Models;
using System.Globalization;
using CsvHelper;
using System.IO;
using System.Linq;

namespace CRUD_For_Users.Services
{
    public class UserServices : IUserServices
    {
        private string mainPath;
        private List<User> user;

        public UserServices()
        {
            string? solutionFolderPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
            string dataStorageFolderPath = Path.Combine(solutionFolderPath, "DataStorage");
            mainPath = Path.Combine(dataStorageFolderPath, "FileDataStorage.csv");

            //mainPath = @"normal path";

            user = ReadUsersFromCsv();
        }

        public void CreateUser(string fullName, long phone, DateTime dateOfBirth)
        {
            int lastUserId;
            if (user.Count > 0)
            {
                lastUserId = user.Max(u => u.Id);
            }
            else
            {
                lastUserId = 0;
            }

            var newUser = new User()
            {
                Id = lastUserId + 1,
                FullName = fullName,
                Phone = phone,
                DateOfBirth = dateOfBirth,
                UserCreationDate = DateTime.Now
            };
            user.Add(newUser);

            WriteUsersToCsv(user);
        }

        public List<User> ReadUser()
        {
            return user.ToList();
        }

        public void UpdateUser(int id, string newName, long newPhone, DateTime newDateOfBirth)
        {
            var validUser = user.Find(u => u.Id == id);

            if (validUser != null)
            {
                validUser.FullName = newName;
                validUser.Phone = newPhone;
                validUser.DateOfBirth = newDateOfBirth;
                WriteUsersToCsv(user);
            }
            else
            {
                throw new UserNotFoundException("User Not Found !");
            }
        }

        public void DeleteUser(int id)
        {
            var validUser = user.Find(u => u.Id == id);

            if (validUser != null)
            {
                user.Remove(validUser);
                WriteUsersToCsv(user);
            }
            else
            {
                throw new UserNotFoundException("User Not Found !");
            }
        }



        private List<User> ReadUsersFromCsv()
        {
            var users = new List<User>();

            using (var reader = new StreamReader(mainPath))
            {
                string line;
                bool isFirstLine = true;

                while ((line = reader.ReadLine()) != null)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }

                    var index = line.Split(',');
                    var user = new User
                    {
                        Id = int.Parse(index[0]),
                        FullName = index[1],
                        Phone = long.Parse(index[2]),
                        DateOfBirth = DateTime.Parse(index[3]),
                        UserCreationDate = DateTime.Parse(index[4]),
                    };

                    users.Add(user);
                }
            }

            return users;
        }

        private void WriteUsersToCsv(List<User> users)
        {
            using (var writer = new StreamWriter(mainPath))
            {
                writer.WriteLine("Id,FullName,Phone,DateOfBirth,UserCreationDate");

                foreach (var user in users)
                {
                    var line = $"{user.Id},{user.FullName},{user.Phone},{user.DateOfBirth},{user.UserCreationDate}"; 
                    writer.WriteLine(line);
                }
            }
        }


    }
}
