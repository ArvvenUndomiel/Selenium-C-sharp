namespace SeleniumBasicsTask2
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using SeleniumBasicsTask2.Pages;

    [TestFixture]
    public class Tests
    {
        private ChromeDriver driver;
        private WebDriverWait wait;
        private SoftUniPage SoftUniPage;

        [SetUp]

        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            SoftUniPage = new SoftUniPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Open_QAautomationCourse_fromNavBar()
        {
            driver.Navigate().GoToUrl("https://softuni.bg/");
            SoftUniPage.CoursesButton.Click();
            SoftUniPage.QA_AutomationLink.Click();

            string attribute = SoftUniPage.QA_AutomationHeader.GetAttribute("innerHTML");

            Assert.That(attribute.Equals("QA Automation - януари 2019"));
        }
    }
}
