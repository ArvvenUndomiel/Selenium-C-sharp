namespace SeleniumBasicsTask4.Pages
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AutomationPracticeLoginPage : BasePage
    {
        public AutomationPracticeLoginPage(IWebDriver driver) : base(driver)
        { }

        public IWebElement EmailInputField => Wait.Until(d => {return d.FindElement(By.Id("email_create"));});
        public IWebElement CreateAccountButton => Wait.Until(d => {return d.FindElement(By.Id("SubmitCreate"));});

        public void FillEmailToTestAccount()
        {
            EmailInputField.SendKeys("frank.jackson@abv.bg");
            CreateAccountButton.Click();
        }
    }
}
