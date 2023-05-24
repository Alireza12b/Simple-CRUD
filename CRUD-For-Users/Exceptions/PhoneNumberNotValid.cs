using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_For_Users.Exceptions
{
    public class PhoneNumberNotValid : Exception
    {
        public PhoneNumberNotValid(string message) : base(message)
        {

        }
    }
}
