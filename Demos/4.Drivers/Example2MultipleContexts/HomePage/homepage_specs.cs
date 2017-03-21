using Machine.Specifications;

namespace _4.Drivers.Example2MultipleContexts.HomePage
{
    public class when_user_enters_on_home_page : HomePageContext
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
}
