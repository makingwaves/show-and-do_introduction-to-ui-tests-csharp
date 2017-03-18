using FluentAssertions;
using Machine.Specifications;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _2.BDD
{
    // This test is analogous to the test from Selenium Setup but it is written in the BDD way.

    // The Subject attribute helps to group UI tests into contexts, like "My Account", "Payments", etc.
    [Subject("Home Page")]
    public class when_user_enters_on_home_page
    {
        static ChromeDriver _browser;

        Establish context = () => _browser = new ChromeDriver();

        Because of = () => _browser.Navigate().GoToUrl("http://localhost:62710");

        It should_see_home_page = () =>
        {
            var element = _browser.FindElement(By.CssSelector(".jumbotron > h1"));
            element.Displayed.Should().BeTrue();
            element.Text.Should().BeEquivalentTo("ASP.NET");
        };

        Cleanup cleanup = () =>
        {
            _browser.Close();
            _browser.Quit();
        };
    }
}
