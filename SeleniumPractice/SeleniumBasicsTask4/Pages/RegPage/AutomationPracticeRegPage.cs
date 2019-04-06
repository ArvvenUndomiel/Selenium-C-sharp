namespace SeleniumBasicsTask4.Pages.RegPage
{
    using OpenQA.Selenium;
    using SeleniumBasicsTask4.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;

    public partial class AutomationPracticeRegPage : BasePage
    {
        public AutomationPracticeRegPage(IWebDriver driver) : base(driver)
        {

        }

        public void FillRegistrationForm(RegistrationUser user)
        {
            FirstName.SendKeys(user.FirstName);
            LastName.SendKeys(user.LastName);
            Mail.Clear();
            Mail.SendKeys(user.Mail);
            Password.SendKeys(user.Password);
            AddressFirstName.SendKeys(user.AddressFirstName);
            AddressLastName.Clear();
            AddressLastName.SendKeys(user.AddressLastName);
            Address.SendKeys(user.Address);
            City.SendKeys(user.City);
            selectState.SelectByText(user.State);
            ZipCode.SendKeys(user.Zipcode);
            selectCountry.SelectByText(user.Country);
            MobilePhone.SendKeys(user.MobilePhone);
            AddressAlias.Clear();
            AddressAlias.SendKeys(user.Alias);
            RegisterButton.Click();
        }

        public bool IsErrorMessageDisplayed()
        {
            try
            {
                IWebElement ErrorPopup = Wait.Until(d => { return d.FindElement(By.XPath(@"//*[@id='center_column']/div")); });
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public string GetErrorText()
        {
            IWebElement ErrorText = Wait.Until(d => { return d.FindElement(By.XPath(@"//*[@id='center_column']/div/ol/li")); });
            string text = ErrorText.GetAttribute("innerHTML");
            return text;
        }

    }
}
