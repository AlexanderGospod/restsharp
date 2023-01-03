using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.dto.request
{
    public class UserDataForCreationUserModel
    {
        public string name { get; set; }
        public string job { get; set; }

        public UserDataForCreationUserModel(string name, string job)
        {
            this.name = name;
            this.job = job;
        }
    }
}
