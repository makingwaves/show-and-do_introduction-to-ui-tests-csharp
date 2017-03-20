using FluentAssertions;
using Machine.Specifications;
using OpenQA.Selenium;

namespace _3.Contexts.Example2MultipleContexts.AboutPage
{
    public class when_user_goes_to_about_page: AboutPageContext
    {
        Because of = () =>
        {
            var menuLink = Browser.FindElement(By.LinkText("About"));
            menuLink.Click();
        };

        It should_see_about_page = () =>
        {
            var element = Browser.FindElement(By.TagName("h2"));
            element.Displayed.Should().BeTrue();
            element.Text.Should().BeEquivalentTo("About.");
        };

        It should_see_page_description = () =>
        {
            var element = Browser.FindElement(By.TagName("h3"));
            element.Displayed.Should().BeTrue();
            element.Text.Should().BeEquivalentTo("Your application description page.");
        };
    }


    [Subject("AboutPage")]
    public class AboutPageContext : BaseContext
    {
        Establish context = () => Browser.Navigate().GoToUrl("http://localhost:62710");
    }
}
