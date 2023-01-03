using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.dto.request
{
    public class UserDataForRegistrationModel
    {
        public string email { get; set; }
        public string password { get; set; }

        public UserDataForRegistrationModel(string email, string password)
        {
            this.email = email;
            this.password = password;   
        }
      


    }
}
