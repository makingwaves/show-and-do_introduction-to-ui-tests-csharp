using FluentAssertions;
using Machine.Specifications;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _3.Contexts.Example1WithComments
{
    // This example bases on ExampleWithAdditionalChecks from 2.BDD demo.

    // Contexts help to group logically connected tests.
    // These groups usually contain the common code for mentioned tests
    // what helps to make UI tests more clearer and easier to understand.

    // The Subject attribute has been moved to the Context level.
    // Unfortunately R# support for MSpec stops working when there are more Subjects in the test hierarchy.
    // However MSpec always use the the last defined subject.
    public class when_user_enters_on_home_page: HomePageContext
    {
        // Establish context section has been moved to the lower layer.
        // For the real life scenarios, on the test level we specify the unique behaviour for specific test like:
        // logging in to the system as a specific user or applying different types of discount coupons in the payment process.

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

        // Cleanup section also has been moved to the lower layer.
        // Usually there is no need to define custom behaviour for this section unless
        // the test changes something in the browser settings or opens new browser windows.
    }

    [Subject("Homepage")]
    public class HomePageContext : BaseContext
    {
        // For this example HomePageContext doesn't have a lot of things to do,
        // nevertheless it is good to keep consistency through the files. In the real life scenarios,
        // on this level there will be defined the common code parts shared between all tests.
        // Usually it will describe all required user actions needed to achieve required page.
        // e.g. context for changing password popup:
        // Establish context = () =>
        // {
        //      Sign in as user X
        //      Go to My Account page
        //      Open Settings tab
        //      Click on change password button
        // }
    }

    // BaseContext is responsible for managing the infrastructure fundamentals.
    // In our example it controls the web browser and thanks to this
    // the higher layers are free from the technical noises and are able to focus only on the bussiness value.
    // Moreover, as it was mentioned before, BaseContext doesn't have the Subject attribute because of R# issue.
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
