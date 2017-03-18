using FluentAssertions;
using Machine.Specifications;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _2.BDD
{
    [Subject("My First BDD Context")]
    public class when_i_wrote_my_first_test
    {
        Establish context = () => { };

        Because of = () => { };

        It should_work = () => { };

        Cleanup cleanup = () => { };
    }
}
