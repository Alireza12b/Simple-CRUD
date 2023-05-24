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
            /*string jsonPath = @"DataStorage\Users.csv";
            string currentDirectory = Directory.GetCurrentDirectory();
            mainPath = Path.Combine(currentDirectory, jsonPath);*/
            mainPath = @"C:\Users\Alireza\Desktop\Users.csv";

            user = ReadUsersFromCsv();
        }

        public void CreateUser(string fullName, int phone, DateTime dateOfBirth)
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

            WriteUsersToCsv();
        }

        public List<User> ReadUser()
        {
            return user.ToList();
        }

        public void UpdateUser(int id, string newName, int newPhone, DateTime newDateOfBirth)
        {
            var validUser = user.Find(u => u.Id == id);

            if (validUser != null)
            {
                validUser.FullName = newName;
                validUser.Phone = newPhone;
                validUser.DateOfBirth = newDateOfBirth;
                WriteUsersToCsv();
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
                this.user.Remove(validUser);
                WriteUsersToCsv();
            }
            else
            {
                throw new UserNotFoundException("User Not Found !");
            }
        }

        public List<User> ReadUsersFromCsv()
        {
            var users = new List<User>();

            using (var reader = new StreamReader(mainPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                users = csv.GetRecords<User>().ToList();
            }

            return users;
        }

        public void WriteUsersToCsv()
        {
            using (var writer = new StreamWriter(mainPath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(user);
            }
        }
    }
}
