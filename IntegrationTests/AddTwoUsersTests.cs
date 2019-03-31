using AutomationCourseMockingHomework.Helpers;
using AutomationCourseMockingHomework.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AutomationCourseMockingHomework
{
    [TestFixture]
    public class AddTwoUsersTests
    {
        private const string ApiBaseAddress = "http://localhost:3000";
        private ApiClient apiClient;

        [SetUp]
        public void Setup()
        {
            this.apiClient = new ApiClient(ApiBaseAddress);
        }

        /*This class sends a Post Request to the API to create two different users.
        Users data is taken from the two JSON files: user1 and user2
        First we create each user and test that it is properly added to the database
        Then we test that both users exist in the database*/

        [Test]
        public void AddTwoUsers_ShouldAddTwoDifferentUsersToTheDatabase()
        {
            //Create first user
            //Arrange
            var user1Json = FileHelper.GetFileContent("user1.json", "data");
            var user1Model = JsonConvert.DeserializeObject<User>(user1Json);
            var content = new StringContent(user1Json, Encoding.UTF8, "application/json");

            //Act
            var firstUser = this.apiClient.PostRequest<User>(@"\users", content);

            //Assert
            Assert.NotNull(firstUser);
            Assert.True(firstUser.Id > 0);
            Assert.AreEqual(user1Model.FirstName, firstUser.FirstName);

            //Create second user
            //Arrange
            var user2Json = FileHelper.GetFileContent("user2.json", "data");
            var user2Model = JsonConvert.DeserializeObject<User>(user2Json);
            var content2 = new StringContent(user2Json, Encoding.UTF8, "application/json");

            //Act
            var secondUser = this.apiClient.PostRequest<User>(@"\users", content2);

            //Assert
            Assert.NotNull(secondUser);
            Assert.True(secondUser.Id > 0);
            Assert.AreEqual(user2Model.FirstName, secondUser.FirstName);

            //Test that the two users exist in the database
            var allUsers = this.apiClient.GetRequest<List<User>>(@"\users");
            var userIds = new List<int>();
            foreach (var user in allUsers)
            {
                userIds.Add(user.Id);
            }
            Assert.True(userIds.Contains(firstUser.Id));
            Assert.True(userIds.Contains(secondUser.Id));
        }
    }
}