namespace SeleniumBasicsTask1.Pages
{
    using OpenQA.Selenium;

    public class GoogleHomePage : BasePage
    {
        public GoogleHomePage(IWebDriver driver) : base(driver)
        { }

        public IWebElement SearchBar => Wait.Until(d => { return d.FindElement(By.CssSelector("input.gLFyf.gsfi")); });
    }
}
