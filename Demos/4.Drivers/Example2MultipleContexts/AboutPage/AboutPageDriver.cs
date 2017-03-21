using FluentAssertions;
using OpenQA.Selenium;

namespace _4.Drivers.Example2MultipleContexts.AboutPage
{
    public class AboutPageDriver
    {
        readonly IWebDriver _browser;

        public AboutPageDriver(IWebDriver browser)
        {
            _browser = browser;
        }

        public void GoTo()
        {
            var menuLink = _browser.FindElement(By.LinkText("About"));
            menuLink.Click();
        }

        public void VerifyThisIsAboutPage()
        {
            var element = _browser.FindElement(By.TagName("h2"));
            element.Displayed.Should().BeTrue();
            element.Text.Should().BeEquivalentTo("About.");
        }

        public void VerifyPageDescriptionIsDisplayed()
        {
            var element = _browser.FindElement(By.TagName("h3"));
            element.Displayed.Should().BeTrue();
            element.Text.Should().BeEquivalentTo("Your application description page.");
        }
    }
}
