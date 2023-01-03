using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpApi.endpoints
{
    public class ApiEndPoints
    {
        public const string BaseUrl = "https://reqres.in/";
        public const string EndpointForUserRegister = "api/register";
        public const string EndpointForGetListOfUsers = "api/users?page=2";
        public const string EndpointForGetListOfColors = "api/unknown";
        public const string EndpointForUpdateUserInformation = "api/users/2";
        public const string EndpointForDeleteUserInformation = "api/users/2";     
        public const string EndpointForCreateNewUser = "api/users";
    }
}
