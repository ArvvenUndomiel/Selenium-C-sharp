namespace SeleniumBasicsTask2.Pages
{
    using OpenQA.Selenium;

    public class SoftUniPage : BasePage
    {
        public SoftUniPage(IWebDriver driver) : base(driver)
        { }

        public IWebElement CoursesButton => Wait.Until(d => { return d.FindElement(By.XPath("//*[@id='header-nav']/div[1]/ul/li[2]/a")); });

        public IWebElement QA_AutomationLink => Wait.Until(d => { return d.FindElement(By.PartialLinkText("QA Automation - януари 2019")); });

        public IWebElement QA_AutomationHeader => Wait.Until(d => {return d.FindElement(By.XPath("/html/body/div[2]/header/h1")); });
    }
}
