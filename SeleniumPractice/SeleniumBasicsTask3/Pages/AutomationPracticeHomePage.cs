namespace SeleniumBasicsTask3.Pages
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AutomationPracticeHomePage : BasePage
    {
        public AutomationPracticeHomePage(IWebDriver driver) : base(driver)
        { }

        public IWebElement SignInButton => Wait.Until(d => {return d.FindElement(By.ClassName("login")) ;});
    }
}
