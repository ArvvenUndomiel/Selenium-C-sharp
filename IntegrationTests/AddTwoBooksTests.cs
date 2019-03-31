using AutomationCourseMockingHomework.Helpers;
using AutomationCourseMockingHomework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using System.Net.Http;
using System.Text;

namespace AutomationCourseMockingHomework
{
    [TestFixture]
    public class AddTwoBooksTests
    {
        private const string ApiBaseAddress = "http://localhost:3000";
        private ApiClient apiClient;

        [SetUp]
        public void SetUp()
        {
            this.apiClient = new ApiClient(ApiBaseAddress);
        }

        /*This class sends a Post Request to the API to add two books to each of the users.
        Books are taken from the ones already populated in the database.
        The test asserts that the books are properly added to the users's wishlists*/

        [Test]
        public void AddBooks_ShoouldAddBookstoUsersWishlists()
        {   
            /*Arrange
            First we need to ensure that we have our users, so that we can take their wishlists*/

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

            /*Act
            The first user receives books with id 1 and 2.
            The second user receives books with id 1 and 3.*/

            var addFirstBooktoUser1 = this.apiClient.PostRequest<Wishlist>($@"\wishlists\{firstUserWishlist}\books\1", null);
            var addSecondBooktoUser1 = this.apiClient.PostRequest<Wishlist>($@"\wishlists\{firstUserWishlist}\books\2", null);

            var addFirstBooktoUser2 = this.apiClient.PostRequest<Wishlist>($@"\wishlists\{secondUserWishlist}\books\1", null);
            var addSecondBooktoUser2 = this.apiClient.PostRequest<Wishlist>($@"\wishlists\{secondUserWishlist}\books\3", null);

            //Assert
            var firstUserAddedBooks = this.apiClient.GetRequest<Wishlist>($@"\wishlists\{firstUserWishlist}\books");
            var secondUserAddedBooks = this.apiClient.GetRequest<Wishlist>($@"\wishlists\{secondUserWishlist}\books");

            Assert.That(firstUserAddedBooks.Books.Count == 2);
            Assert.That(secondUserAddedBooks.Books.Count == 2);
        }
    }
}
