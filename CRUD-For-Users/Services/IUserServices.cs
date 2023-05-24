using CRUD_For_Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_For_Users.Services
{
    public interface IUserServices
    {
        void CreateUser(string fullName, int phone, DateTime dateOfBirth);
        List<User> ReadUser();
    }
}
