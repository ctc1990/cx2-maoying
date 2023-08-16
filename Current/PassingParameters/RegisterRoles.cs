using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLEANXCEL2._2.PassingParameters
{
    class RegisterRoles
    {
        public struct user_info
        {
            public string name;
            public string email;
            public string password;
        }

        public user_info ToRoles(string s_name, string s_email, string s_password)
        {
            return new user_info
            {
                name = s_name,
                email = s_email,
                password = s_password
            };
        }
    }
}
