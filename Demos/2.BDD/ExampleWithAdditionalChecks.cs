using FluentAssertions;
using Machine.Specifications;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _2.BDD
{
    [Subject("HomePage")]
    public class when_user_enters_on_home_page_and_checks_it_more_carefully
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

        // This is additional check which will be run in the same scenario launch.
        // The main benefitial thing about this approach is that each check will be shown as separate
        // "point" in the tests runner, so it is a lot of easier and quicker to identify occured problem.
        It should_see_three_buttons = () =>
        {
            var elements = _browser.FindElements(By.ClassName("btn-default"));
            elements.Count.Should().Be(3);

            foreach (var element in elements)
            {
                element.Displayed.Should().BeTrue();
            }
        };

        Cleanup cleanup = () =>
        {
            _browser.Close();
            _browser.Quit();
        };
    }
}
