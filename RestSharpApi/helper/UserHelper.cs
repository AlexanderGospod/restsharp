using APITests.dto.request;
using APITests.dto.response;
using AventStack.ExtentReports;
using NUnit.Framework;
using RestSharp;
using RestSharpApi.dto.response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpApi.helper
{
    public class UserHelper 
    {
        public static APIHelper<UserDataForRegistrationModel> agent = new APIHelper<UserDataForRegistrationModel>();


        private static IRestResponse SendPostRequest(string email, string password, string endpoint, object newUser)
        {
            RestClient url = agent.SetUrl(endpoint);
            string jsonRequest = agent.SerializeObjToString(newUser);
            RestRequest request = agent.CreatePostRequest(jsonRequest);
            IRestResponse response = agent.GetResponse(url, request);
            return response;
        }
        private static IRestResponse SendPutRequest(string email, string password, string endpoint, object newUser)
        {
            RestClient url = agent.SetUrl(endpoint);
            string jsonRequest = agent.SerializeObjToString(newUser);
            RestRequest request = agent.CreatePutRequest(jsonRequest);
            IRestResponse response = agent.GetResponse(url, request);
            return response;
        }

        public static SuccessRegistrationDTO RegistrUser(string email, string password, string endpoint)
        {
            UserDataForRegistrationModel newUser = new UserDataForRegistrationModel(email, password);
            IRestResponse response = SendPostRequest(email, password, endpoint, newUser);
            Assert.AreEqual(200, (int)response.StatusCode);
            Reporter.LogToReport(Status.Pass, "200 response code is received");
            SuccessRegistrationDTO content = agent.GetContent<SuccessRegistrationDTO>((RestResponse)response);
            return content;
        }
        public static UnSuccessRegistrationDTO RegistrUserWithoutPassword(string email, string password, string endpoint)
        {
            UserDataForRegistrationModel newUser = new UserDataForRegistrationModel(email, password);
            IRestResponse response = SendPostRequest(email, password, endpoint, newUser);
            Assert.AreEqual(400, (int)response.StatusCode);
            Reporter.LogToReport(Status.Pass, "400 response code is received");
            UnSuccessRegistrationDTO content = agent.GetContent<UnSuccessRegistrationDTO>((RestResponse)response);
            return content;
        }
        public static CreatedUserDTO CreateUser(string name, string job, string endpoint)
        {
            UserDataForCreationUserModel newUser = new UserDataForCreationUserModel(name, job);
            IRestResponse response = SendPostRequest(name, job, endpoint, newUser);
            Assert.AreEqual(201, (int)response.StatusCode );
            Reporter.LogToReport(Status.Pass, "201 response code is received");
            CreatedUserDTO content = agent.GetContent<CreatedUserDTO>((RestResponse)response);
            return content;
        }
        public static UpdateUserDTO UpdateExistingUser(string name, string job, string endpoint)
        {
            UserDataForCreationUserModel newUser = new UserDataForCreationUserModel(name, job);
            IRestResponse response = SendPutRequest(name, job, endpoint, newUser);
            Assert.AreEqual(200, (int)response.StatusCode);
            UpdateUserDTO content = agent.GetContent<UpdateUserDTO>((RestResponse)response);
            return content;
        }
        public static ListOfUsersDTO GetListOfUsers(string endpoint)
        {
            RestClient url = agent.SetUrl(endpoint);
            RestRequest request = agent.CreateGetRequest();
            IRestResponse response = agent.GetResponse(url, request);
            Assert.AreEqual(200, (int)response.StatusCode);
            Reporter.LogToReport(Status.Pass, "200 response code is received");
            ListOfUsersDTO content = agent.GetContent<ListOfUsersDTO>((RestResponse)response);
            return content;
        }
        public static ListOfColorsDTO GetListOfColors(string endpoint)
        {
            RestClient url = agent.SetUrl(endpoint);
            RestRequest request = agent.CreateGetRequest();
            IRestResponse response = agent.GetResponse(url, request);
            Assert.AreEqual(200, (int)response.StatusCode);
            Reporter.LogToReport(Status.Pass, "200 response code is received");
            ListOfColorsDTO content = agent.GetContent<ListOfColorsDTO>((RestResponse)response);
            return content;
        }
        public static IRestResponse DeleteUserByEndpoint(string endpoint)
        {
            RestClient url = agent.SetUrl(endpoint);
            RestRequest request = agent.CreateDeleteRequest();
            IRestResponse response = agent.GetResponse(url, request);
            return response;
        }
        public static void CheckThatTheColorsAreSortedByYears(ListOfColorsDTO response)
        {
            for (int i = 0; i < response.Data.Count - 1; i++)
            {
                Assert.IsTrue(response.Data[i].year <= response.Data[i + 1].year);
            }

        }
    }
}
