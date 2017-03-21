using FluentAssertions;
using OpenQA.Selenium;

namespace _4.Drivers.Example2MultipleContexts.HomePage
{
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
