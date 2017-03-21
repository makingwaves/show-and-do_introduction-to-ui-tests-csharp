using FluentAssertions;
using Machine.Specifications;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _4.Drivers.Example1WithComments
{
    // This example bases on the Example from 3.Contexts demo.

    // Drivers help to pull out commonly repeated actions used through the tests.
    // They could group actions connected with particular page (like in our example)
    // or focus on page parts (like main menu, comments section or dashboard widget).
    // As a benefit of introducing DRY rule in the tests we get tests which are:
    // * business oriented - so non-technical person is able to read them and understand what is happenning there
    // * more clearer and shorter where their business value is highlighted
    // * easier to maintain

    // All delegates implementations are moved HomePageDriver which aggregate all behaviours.
    // We achieved our goal - tests are now soo simple that we can read them as a sentences.
    public class when_user_enters_on_home_page : HomePageContext
    {
        Because of = () => HomePageDriver.NavigateTo();

        It should_see_home_page = () => HomePageDriver.VerifyThisIsHomePage();

        It should_see_three_buttons = () => HomePageDriver.VerifyButtonsAreDisplayed(3);
    }

    // HomePageContext is now responsible for creating HomePageDriver.
    // Thanks to that tests are focused only on mentioned business value, what we can notice above.
    // The general idea behind such UI tests says that they should be understandable by non-technical people.
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

    // HomePageDriver contains all actions related to this specific page.
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
