using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_For_Users.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Fname { get; set; }
        public int Phone { get; set; }
        DateTime DateOfBirth { get; set; }
    }
}
