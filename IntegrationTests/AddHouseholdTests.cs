using AutomationCourseMockingHomework.Helpers;
using AutomationCourseMockingHomework.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Text;

namespace AutomationCourseMockingHomework
{
    [TestFixture]
    public class AddHouseholdTests
    {
        private const string ApiBaseAddress = "http://localhost:3000";
        private ApiClient apiClient;

        [SetUp]
        public void SetUp()
        {
            this.apiClient = new ApiClient(ApiBaseAddress);
        }

        /*This class sends a Post Request to the API to create a new household (data is taken from the JSON file)
        The test asserts that the new household is properly added to the database*/

        [Test]
        public void AddHousehold_ShouldAddNewHousehold()
        {
            //Arrange
            var householdJson = FileHelper.GetFileContent("household.json", "data");
            var householdModel = JsonConvert.DeserializeObject<Household>(householdJson);
            var content = new StringContent(householdJson, Encoding.UTF8, "application/json");

            //Act
            var household = this.apiClient.PostRequest<Household>(@"\households", content);

            //Assert
            Assert.NotNull(household);
            Assert.AreEqual(householdModel.Name, household.Name);
            Assert.True(household.Id > 0);
        }
    }
}
