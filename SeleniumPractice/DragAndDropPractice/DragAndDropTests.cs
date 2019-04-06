namespace DragAndDropPractice
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    [TestFixture]
    public class DragAndDropTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private GuruPage GuruPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            GuruPage = new GuruPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void DragAndDrop()
        {
            GuruPage.Navigate();
            GuruPage.builder.DragAndDrop(GuruPage.FiveThousandBox, GuruPage.DebitRightSide).Perform();
            GuruPage.builder.DragAndDrop(GuruPage.FiveThousandBox, GuruPage.CreditRightSide).Perform();
            Thread.Sleep(5000);
        }
    }
}
