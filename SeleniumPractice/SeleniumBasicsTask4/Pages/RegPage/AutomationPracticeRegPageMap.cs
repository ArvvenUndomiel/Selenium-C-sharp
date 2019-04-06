namespace SeleniumBasicsTask4.Pages.RegPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class AutomationPracticeRegPage
    {
        public IWebElement FirstName => Wait.Until(d => { return d.FindElement(By.Id("customer_firstname")); });

        public IWebElement LastName => Wait.Until(d => { return d.FindElement(By.Id("customer_lastname")); });

        public IWebElement Mail => Wait.Until(d => { return d.FindElement(By.Id("email")); });

        public IWebElement Password => Wait.Until(d => { return d.FindElement(By.Id("passwd")); });

        public IWebElement AddressFirstName => Wait.Until(d => { return d.FindElement(By.Id("firstname")); });

        public IWebElement AddressLastName => Wait.Until(d => { return d.FindElement(By.Id("lastname")); });

        public IWebElement Address => Wait.Until(d => { return d.FindElement(By.Id("address1")); });

        public IWebElement City => Wait.Until(d => { return d.FindElement(By.Id("city")); });

        public IWebElement State => Wait.Until(d => { return d.FindElement(By.Id("id_state")); });

        public SelectElement selectState => new SelectElement(State);

        public IWebElement ZipCode => Wait.Until(d => { return d.FindElement(By.Id("postcode")); });

        public IWebElement Country => Wait.Until(d => { return d.FindElement(By.Id("id_country")); });

        public SelectElement selectCountry => new SelectElement(Country);

        public IWebElement MobilePhone => Wait.Until(d => { return d.FindElement(By.Id("phone_mobile")); });

        public IWebElement AddressAlias => Wait.Until(d => { return d.FindElement(By.Id("alias")); });

        public IWebElement RegisterButton => Wait.Until(d => { return d.FindElement(By.Id("submitAccount")); });

    }
}
