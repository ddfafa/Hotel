using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    internal class User
    {
       
        public string Login { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is User otherUser)
            {
                return Login == otherUser.Login &&
                       Password == otherUser.Password;
            }

            return false;
        }
    }
}
