namespace SeleniumBasicsTask3
{
    using NUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using SeleniumBasicsTask3.Pages;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading;

    [TestFixture]
    public class Tests
    {
        private ChromeDriver driver;
        private WebDriverWait wait;
        private AutomationPracticeHomePage AutomationPracticeHomePage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            AutomationPracticeHomePage = new AutomationPracticeHomePage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void NavigateToRegistrationPage()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");

            AutomationPracticeHomePage.SignInButton.Click();
            string PageTitle = driver.Title;

            Assert.That(PageTitle.Equals("Login - My Store"));
        }
    }
}
