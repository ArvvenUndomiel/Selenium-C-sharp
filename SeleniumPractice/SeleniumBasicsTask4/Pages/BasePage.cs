namespace SeleniumBasicsTask4.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }
        public WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        public string BaseUrl => "http://automationpractice.com/index.php?controller=authentication&back=my-account";
    }
}
