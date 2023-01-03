using APITests.dto.request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpApi.helper
{
    public class FileReader
    {
        private static UserDataForCreationUserModel userDataForCreatingUser;
        private static UserDataForCreationUserModel userDataForUpdatingUser;
        private static UserDataForRegistrationModel userDataForRegisterinUser;

        private static string PathToTestData()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            return projectDirectory + "\\RestSharpApi\\testdata";
        }

        public static UserDataForCreationUserModel ReadUserData()
        {
            if(userDataForCreatingUser == null)
            {
                using (StreamReader r = new StreamReader(PathToTestData() + "\\CreateUser.json"))
                {
                    string json = r.ReadToEnd();
                    userDataForCreatingUser = JsonConvert.DeserializeObject<UserDataForCreationUserModel>(json);
                }
            }
            return userDataForCreatingUser;
        }
        public static UserDataForCreationUserModel UpdateUserData()
        {
            if (userDataForUpdatingUser == null)
            {
                using (StreamReader r = new StreamReader(PathToTestData() + "\\UpdateUser.json"))
                {
                    string json = r.ReadToEnd();
                    userDataForUpdatingUser = JsonConvert.DeserializeObject<UserDataForCreationUserModel>(json);
                }
            }
            return userDataForUpdatingUser;
        }
        public static UserDataForRegistrationModel RegisteringUser()
        {
            if (userDataForRegisterinUser == null)
            {
                using (StreamReader r = new StreamReader(PathToTestData() + "\\RegisterinUser.json"))
                {
                    string json = r.ReadToEnd();
                    userDataForRegisterinUser = JsonConvert.DeserializeObject<UserDataForRegistrationModel>(json);
                }
            }
            return userDataForRegisterinUser;
        }
    }
}
