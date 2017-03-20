using Machine.Specifications;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _3.Contexts.Example2MultipleContexts
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