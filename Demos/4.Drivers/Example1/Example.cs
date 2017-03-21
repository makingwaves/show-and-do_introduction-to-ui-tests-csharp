using FluentAssertions;
using Machine.Specifications;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _4.Drivers.Example1
{
    public class when_user_enters_on_home_page: HomePageContext
    {
        Because of = () => HomePageDriver.NavigateTo();

        It should_see_home_page = () => HomePageDriver.VerifyThisIsHomePage();

        It should_see_three_buttons = () => HomePageDriver.VerifyButtonsAreDisplayed(3);
    }

    [Subject("Homepage")]
    public class HomePageContext : BaseContext
    {
        protected static HomePageDriver HomePageDriver { get; private set; }

        Establish context = () =>
        {
            HomePageDriver = new HomePageDriver(Browser);
        };
    }

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
    public class HomePageDriver
    {
        readonly IWebDriver _browser;

        public HomePageDriver(IWebDriver browser)
        {
            _browser = browser;
        }

        public void NavigateTo()
        {
            _browser.Navigate().GoToUrl("http://localhost:62710");
        }

        public void VerifyThisIsHomePage()
        {
            var element = _browser.FindElement(By.CssSelector(".jumbotron > h1"));
            element.Displayed.Should().BeTrue();
            element.Text.Should().BeEquivalentTo("ASP.NET");
        }

        public void VerifyButtonsAreDisplayed(int buttonsCount)
        {
            var elements = _browser.FindElements(By.ClassName("btn-default"));
            elements.Count.Should().Be(buttonsCount);

            foreach (var element in elements)
            {
                element.Displayed.Should().BeTrue();
            }
        }
    }
}
