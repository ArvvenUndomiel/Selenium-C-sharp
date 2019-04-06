namespace SeleniumBasicsTask1
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using SeleniumBasicsTask1.Pages;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading;

    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private GoogleHomePage GoogleHomePage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            GoogleHomePage = new GoogleHomePage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Search_Selenium_Google()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
            GoogleHomePage.SearchBar.SendKeys("Selenium" + "\n");
            IWebElement FirstLink = wait.Until((d) => { return d.FindElement(By.XPath("//div[@id='search']//div[@class='srg']//div[1]//a")); });
            FirstLink.Click();
            string currentURL = driver.Url;

            Assert.That(driver.Title.Equals("Selenium - Web Browser Automation"));
            Assert.That(currentURL.Equals("https://www.seleniumhq.org/"));
        }
    }
}
