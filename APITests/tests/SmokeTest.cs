using APITests.dto.request;
using APITests.dto.response;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharpApi.dto.response;
using RestSharpApi.helper;
using System;
using System.Net;
using static RestSharpApi.endpoints.ApiEndPoints;
using static RestSharpApi.helper.UserHelper;
using static RestSharpApi.testdata.SomeDatabase;


namespace APITests
{
    [TestClass]
    public class SmokeTests
    {
        public TestContext TestContext { get; set; }
        public HttpStatusCode statusCode;

        [ClassInitialize]
        public static void SetUpReport(TestContext testContext)
        {
            var dir = testContext.TestRunDirectory;
            Reporter.SetUpReport(dir, "SmokeTest", "Smoke test result");
        }

        [TestInitialize]
        public void SetUpTest()
        {
            Reporter.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void TearDownTest()
        {
            var testStatus = TestContext.CurrentTestOutcome;
            Status status;
            switch (testStatus)
            {
                case UnitTestOutcome.Failed:
                    status = Status.Fail;
                    Reporter.TestStatus(status.ToString());
                    break;
                case UnitTestOutcome.Inconclusive:
                    break;
                case UnitTestOutcome.Passed:
                    status = Status.Pass;
                    break;
                case UnitTestOutcome.InProgress:
                    break;
                case UnitTestOutcome.Error:
                    break;
                case UnitTestOutcome.Timeout:
                    break;
                case UnitTestOutcome.Aborted:
                    break;
                case UnitTestOutcome.Unknown:
                    break;
                case UnitTestOutcome.NotRunnable:
                    break;
                default:
                    break;
            }
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            Reporter.FlushReport();
        }




        [TestMethod]
        public void CheckExistenceUserData()
        {
            ListOfUsersDTO response = GetListOfUsers(EndpointForGetListOfUsers);
            Assert.AreEqual(numberOfPagesWithUsers, response.page);
            Assert.AreEqual(totalNumberOfUsers, response.total);
        }
        [TestMethod]
        public void CheckThatTheColorsAreSortedInAscendingOrderByYears()
        {
            ListOfColorsDTO response = GetListOfColors(EndpointForGetListOfColors);
            CheckThatTheColorsAreSortedByYears(response);
        }


        [TestMethod]
        public void CreateNewUser()
        {
            CreatedUserDTO response = CreateUser(FileReader.ReadUserData().name
                , FileReader.ReadUserData().job, EndpointForCreateNewUser);
            Assert.AreEqual(FileReader.ReadUserData().name, response.name);
            Assert.AreEqual(FileReader.ReadUserData().job, response.job);
        }
        [TestMethod]
        public void UpdateUser()
        {
            UpdateUserDTO response = UpdateExistingUser(FileReader.UpdateUserData().name
                , FileReader.UpdateUserData().job, EndpointForUpdateUserInformation);
            Assert.AreEqual(FileReader.UpdateUserData().name, response.name);
            Assert.AreEqual(FileReader.UpdateUserData().job, response.job);
            DateTimeOffset currentTime = DateTimeOffset.Now;
            TimeSpan differenceBetweenTheCurrentTimeAndTheDataUpdateTime = response.updatedAt - currentTime;
            Assert.IsTrue(differenceBetweenTheCurrentTimeAndTheDataUpdateTime.Seconds < 2);
        }

        [TestMethod]
        public void SuccessRegistration()
        {
            SuccessRegistrationDTO response = RegistrUser(FileReader.RegisteringUser().email
                , FileReader.RegisteringUser().password, EndpointForUserRegister);
            Assert.AreEqual(tokenOfNewlyRegisteredUser, response.token);
            Assert.AreEqual(idOfNewlyRegisteredUser, response.id);
        }

        [TestMethod]
        public void UnSuccessRegistration()
        {
            UnSuccessRegistrationDTO response = RegistrUserWithoutPassword(FileReader.RegisteringUser().email
                , "", EndpointForUserRegister);
            Assert.AreEqual("Missing password", response.error);

        }

        [TestMethod]
        public void DeleteUser()
        {
            IRestResponse response = DeleteUserByEndpoint(EndpointForDeleteUserInformation);
            Assert.AreEqual(204, (int)response.StatusCode);
        }
    }
}
