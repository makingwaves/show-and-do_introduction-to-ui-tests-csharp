using Machine.Specifications;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _4.Drivers.Example2MultipleContexts
{
    public abstract class BaseContext
    {
        protected static IWebDriver Browser { get; private set; }

        Establish context = () => Browser = new ChromeDriver();

        Cleanup cleanup = () =>
        {
            Browser.Close();
            Browser.Quit();
        };
    }
}