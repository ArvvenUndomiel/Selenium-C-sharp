namespace DragAndDropPractice
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium.Interactions;
    using System;

    public class GuruPage : BasePage
    {
        public GuruPage(IWebDriver driver) : base(driver)
        { }

        private readonly string _url = "http://demo.guru99.com/test/drag_drop.html";

        public void Navigate() => Driver.Navigate().GoToUrl(_url);

        public Actions builder => new Actions(Driver);

        public IWebElement FiveThousandBox => Wait.
            Until(d => { return d.FindElement(By.XPath("//*[@id='fourth']/a")); });

        public IWebElement BankBox => Wait.
            Until(d => { return d.FindElement(By.XPath("//*[@id='credit2']/a")); });

        public IWebElement SalesBox => Wait.
            Until(d => { return d.FindElement(By.XPath("//*[@id='credit1']/a")); });

        public IWebElement DebitLeftSide => Wait.
            Until(d => { return d.FindElement(By.Id("bank")); });

        public IWebElement DebitRightSide => Wait.
            Until(d => { return d.FindElement(By.Id("amt7")); });

        public IWebElement CreditLeftSide => Wait.
            Until(d => { return d.FindElement(By.Id("loan")); });

        public IWebElement CreditRightSide => Wait.
            Until(d => { return d.FindElement(By.Id("amt8")); });
    }
}
