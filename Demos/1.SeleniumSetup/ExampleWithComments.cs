using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _1.SeleniumSetup
{
    [TestClass]
    public class HomeControllerTestsWithComments
    {
        [TestMethod]
        public void Index()
        {
            // Arrange: Create new browser instance.
            var browser = new ChromeDriver();

            // Act: Navigate to the test site.
            browser.Navigate().GoToUrl("http://localhost:62710");

            // Assert: Ensure that user is on the correct page.
            // To achieve this we will need to find element (or set of elements)
            // which will be unique in the context of whole site.
            // In this scenario - the unique element is the main header.

            // Firstly we need to find this element in the HTML structure...
            var element = browser.FindElement(By.CssSelector(".jumbotron > h1"));
            // ...check if it is displayed...
            Assert.AreEqual(true, element.Displayed);
            // ...and check if it contains expected text.
            Assert.AreEqual("ASP.NET", element.Text);

            // Cleanup
            // Close the browser window which has been used during tests.
            browser.Close();
            // Close the browser process.
            browser.Quit();
        }
    }
}
