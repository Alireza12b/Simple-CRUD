using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_For_Users.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Phone { get; set; }
        DateTime DateOfBirth { get; set; }
        DateTime UserCreationDate { get; set; }
    }
}
