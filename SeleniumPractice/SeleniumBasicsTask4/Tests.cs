namespace SeleniumBasicsTask4
{
    using Newtonsoft.Json;
    using NUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using SeleniumBasicsTask4.Pages;
    using SeleniumBasicsTask4.Pages.RegPage;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using SeleniumBasicsTask4.Models;
    using OpenQA.Selenium;

    [TestFixture]
    public class Tests
    {
        private ChromeDriver driver;
        private WebDriverWait wait;
        private AutomationPracticeRegPage AutomationPracticeRegPage;
        private AutomationPracticeLoginPage AutomationPracticeLoginPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            AutomationPracticeRegPage = new AutomationPracticeRegPage(driver);
            AutomationPracticeLoginPage = new AutomationPracticeLoginPage(driver);
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");
            AutomationPracticeLoginPage.FillEmailToTestAccount();
            Thread.Sleep(2000);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void EmptyFirstName_RegAttemptShouldFail()
        {
            var firstNameMissingUserJson = FileReader.GetFileContent("FirstNameMissingUser.json", "Jsons");
            var RegUserwithMissingFirstName = JsonConvert.DeserializeObject<RegistrationUser>(firstNameMissingUserJson);
            AutomationPracticeRegPage.FillRegistrationForm(RegUserwithMissingFirstName);
            bool IsErrorDisplayed = AutomationPracticeRegPage.IsErrorMessageDisplayed();
            string ErrorText = AutomationPracticeRegPage.GetErrorText();

            Assert.That(IsErrorDisplayed.Equals(true));
            Assert.That(ErrorText, Is.EqualTo("<b>firstname</b> is required."));
        }

        [Test]
        public void EmptyLastName_RegAttemptShouldFail()
        {
            var lastNameMissingUserJson = FileReader.GetFileContent("LastNameMissingUser.json", "Jsons");
            var RegUserwithMissingLastName = JsonConvert.DeserializeObject<RegistrationUser>(lastNameMissingUserJson);
            AutomationPracticeRegPage.FillRegistrationForm(RegUserwithMissingLastName);
            bool IsErrorDisplayed = AutomationPracticeRegPage.IsErrorMessageDisplayed();
            string ErrorText = AutomationPracticeRegPage.GetErrorText();

            Assert.That(IsErrorDisplayed.Equals(true));
            Assert.That(ErrorText, Is.EqualTo("<b>lastname</b> is required."));
        }

        [Test]
        public void IncorrectZipCodeFormat_RegAttemptShouldFail()
        {
            var incorrectZipCodeUserJson = FileReader.GetFileContent("IncorrectZipCodeUser.json", "Jsons");
            var RegUserwithIncorrectZipcode = JsonConvert.DeserializeObject<RegistrationUser>(incorrectZipCodeUserJson);
            AutomationPracticeRegPage.FillRegistrationForm(RegUserwithIncorrectZipcode);

            bool IsErrorDisplayed = AutomationPracticeRegPage.IsErrorMessageDisplayed();
            string ErrorText = AutomationPracticeRegPage.GetErrorText();

            Assert.That(IsErrorDisplayed.Equals(true));
            Assert.That(ErrorText, Is.EqualTo("The Zip/Postal code you've entered is invalid. It must follow this format: 00000"));
        }

        [Test]
        public void EmptyMobilePhone_RegAttemptShouldFail()
        {
            var mobilePhoneMissingUserJson = FileReader.GetFileContent("MobilePhoneMissingUser.json", "Jsons");
            var RegUserwithMissingMobile = JsonConvert.DeserializeObject<RegistrationUser>(mobilePhoneMissingUserJson);
            AutomationPracticeRegPage.FillRegistrationForm(RegUserwithMissingMobile);

            bool IsErrorDisplayed = AutomationPracticeRegPage.IsErrorMessageDisplayed();
            string ErrorText = AutomationPracticeRegPage.GetErrorText();

            Assert.That(IsErrorDisplayed.Equals(true));
            Assert.That(ErrorText, Is.EqualTo("You must register at least one phone number."));
        }

        [Test]
        public void EmptyPassword_RegAttemptShouldFail()
        {
            var passwordMissingUserJson = FileReader.GetFileContent("PasswordMissingUser.json", "Jsons");
            var RegUserwithMissingPassword = JsonConvert.DeserializeObject<RegistrationUser>(passwordMissingUserJson);
            AutomationPracticeRegPage.FillRegistrationForm(RegUserwithMissingPassword);

            bool IsErrorDisplayed = AutomationPracticeRegPage.IsErrorMessageDisplayed();
            string ErrorText = AutomationPracticeRegPage.GetErrorText();

            Assert.That(IsErrorDisplayed.Equals(true));
            Assert.That(ErrorText, Is.EqualTo("<b>passwd</b> is required."));
        }
    }
}
