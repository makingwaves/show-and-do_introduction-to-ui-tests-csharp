using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _1.SeleniumSetup
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var browser = new ChromeDriver();

            // Act
            browser.Navigate().GoToUrl("http://localhost:62710");

            // Assert
            var element = browser.FindElement(By.CssSelector(".jumbotron > h1"));
            Assert.AreEqual(true, element.Displayed);
            Assert.AreEqual("ASP.NET", element.Text);

            //Cleanup
            browser.Close();
            browser.Quit();
        }
    }
}
