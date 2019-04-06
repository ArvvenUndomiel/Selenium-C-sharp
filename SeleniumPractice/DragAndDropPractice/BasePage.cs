namespace DragAndDropPractice
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public abstract class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }
        public WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        
    }
}
