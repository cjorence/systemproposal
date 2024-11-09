using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__project_proposal
{
    public abstract class UserAccount
    {
        protected string username;
        protected string password;

        public UserAccount(string inputUsername, string inputPassword)
        {
            username = inputUsername;
            password = inputPassword;
        }

        public bool ValidateCredentials(string inputUsername, string inputPassword)
        {
            return username == inputUsername && password == inputPassword;
        }
    }
}
