using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_For_Users.Exceptions
{
    public class BirthDateNotValid : Exception
    {
        public BirthDateNotValid(string message) : base(message)
        {

        }
    }
}
