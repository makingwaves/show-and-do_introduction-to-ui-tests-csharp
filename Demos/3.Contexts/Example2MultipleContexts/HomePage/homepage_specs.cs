using FluentAssertions;
using Machine.Specifications;
using OpenQA.Selenium;

namespace _3.Contexts.Example2MultipleContexts.HomePage
{
    public class when_user_enters_on_home_page: HomePageContext
    {
        Because of = () => Browser.Navigate().GoToUrl("http://localhost:62710");

        It should_see_home_page = () =>
        {
            var element = Browser.FindElement(By.CssSelector(".jumbotron > h1"));
            element.Displayed.Should().BeTrue();
            element.Text.Should().BeEquivalentTo("ASP.NET");
        };

        It should_see_three_buttons = () =>
        {
            var elements = Browser.FindElements(By.ClassName("btn-default"));
            elements.Count.Should().Be(3);

            foreach (var element in elements)
            {
                element.Displayed.Should().BeTrue();
            }
        };
    }

    [Subject("Homepage")]
    public class HomePageContext : BaseContext
    {
    }
}
