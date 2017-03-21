using Machine.Specifications;
using _4.Drivers.Example2MultipleContexts.HomePage;

namespace _4.Drivers.Example2MultipleContexts.AboutPage
{
    public class when_user_goes_to_about_page: AboutPageContext
    {
        Because of = () => AboutPageDriver.GoTo();

        It should_see_about_page = () => AboutPageDriver.VerifyThisIsAboutPage();

        It should_see_page_description = () => AboutPageDriver.VerifyPageDescriptionIsDisplayed();
    }

    [Subject("AboutPage")]
    public class AboutPageContext : BaseContext
    {
        protected static AboutPageDriver AboutPageDriver { get; private set; }
        protected static HomePageDriver HomePageDriver { get; private set; }

        Establish context = () =>
        {
            AboutPageDriver = new AboutPageDriver(Browser);
            HomePageDriver = new HomePageDriver(Browser);

            HomePageDriver.NavigateTo();
        };
    }
}
