using AutomationCourseMockingHomework.Helpers;
using AutomationCourseMockingHomework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace AutomationCourseMockingHomework
{
    [TestFixture]
    public class CheckHouseholdWishlistTests
    {
        private const string ApiBaseAddress = "http://localhost:3000";
        private ApiClient apiClient;

        [SetUp]
        public void SetUp()
        {
            this.apiClient = new ApiClient(ApiBaseAddress);
        }

        /*This class sends a Get Request to the API to check if the household contains a unique list of books.
        First we need to create our users to get their wishlists.
        Data for users is provided directly.
        Second we add the books to the users.
        The first user receives books with id 1 and 2.
        The second user receives books with id 1 and 3.
        The test should assert that the household wishlist includes only one copy of books 1, 2 and 3*/

        [Test]
        public void HouseholdWishlist_ShouldContainUniqueBookList()
        {
            //Arrange
            //First step: create the users
            var user1 = new User { Email = "JohnSimpson@atr.bg", HouseholdId = 1, FirstName = "John", LastName = "Simpson" };
            var jsonUser1 = JsonConvert.SerializeObject(user1, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            var content = new StringContent(jsonUser1, Encoding.UTF8, "application/json");

            var firstUser = this.apiClient.PostRequest<User>(@"\users", content);

            var user2 = new User { Email = "DaisyLindon@atr.bg", HouseholdId = 1, FirstName = "Daisy", LastName = "Lindon" };
            var jsonUser2 = JsonConvert.SerializeObject(user2, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            var content2 = new StringContent(jsonUser2, Encoding.UTF8, "application/json");

            var secondUser = this.apiClient.PostRequest<User>(@"\users", content2);

            var firstUserWishlist = firstUser.WishlistId;
            var secondUserWishlist = secondUser.WishlistId;

            //Second step: add the books to the users' wishlists and assert they are added properly
            var addFirstBooktoUser1 = this.apiClient.PostRequest<Wishlist>($@"\wishlists\{firstUserWishlist}\books\1", null);
            var addSecondBooktoUser1 = this.apiClient.PostRequest<Wishlist>($@"\wishlists\{firstUserWishlist}\books\2", null);

            var addFirstBooktoUser2 = this.apiClient.PostRequest<Wishlist>($@"\wishlists\{secondUserWishlist}\books\1", null);
            var addSecondBooktoUser2 = this.apiClient.PostRequest<Wishlist>($@"\wishlists\{secondUserWishlist}\books\3", null);

            var firstUserAddedBooks = this.apiClient.GetRequest<Wishlist>($@"\wishlists\{firstUserWishlist}\books");
            var secondUserAddedBooks = this.apiClient.GetRequest<Wishlist>($@"\wishlists\{secondUserWishlist}\books");

            Assert.That(firstUserAddedBooks.Books.Count == 2);
            Assert.That(secondUserAddedBooks.Books.Count == 2);

            //Act
            var householdWishlist = this.apiClient.GetRequest<List<Book>>(@"\households\1\wishlistBooks");

            //Assert
            Assert.That(householdWishlist.Count == 3);
            
        }
    }
}
