using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Question_2
{
    internal class BasicAuthenticationService : IAuthenticationService
    {
        //Dummy Data
        private Dictionary<string, (string password, string role)> Users =
            new Dictionary<string, (string password, string role)>
            {
                { "admin", ("1234", "Administrator")},
                { "Ali", ("Pass123", "Manager")},
                {"Rahma", ("pass@223", "User") }
            };
        public bool AuthenticateUser(string username, string password)
        {
            if (Users.ContainsKey(username)) 
                if (Users[username].password == password)
                    return true;

            return false;
            
        }

        public bool AuthorizeUser(string username, string role)
        {
            if (Users.ContainsKey(username))
                if (Users[username].role == role) return true;
            return false;
        }
    }
}
