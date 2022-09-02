using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace BloggingApp.AutomatedUITests
{
    public class AppTesting : IDisposable
    {
        private readonly IWebDriver _driver;
        public AppTesting()
        {

            _driver = new ChromeDriver();
        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void CheckEmailField()
        {
            _driver.Navigate().GoToUrl($"{Constant.BASEURL}/Account/Login");
            var emailField = _driver.FindElement(By.Id("Email"));
            Assert.NotNull(emailField);
        }

        [Fact]
        public void CheckPasswordField()
        {
            _driver.Navigate().GoToUrl($"{Constant.BASEURL}/Account/Login");
            var passwordField = _driver.FindElement(By.Id("Password"));
            Assert.NotNull(passwordField);
        }

        [Fact]
        public void CheckButton()
        {
            _driver.Navigate().GoToUrl($"{Constant.BASEURL}/Account/Login");
            var submitButton = _driver.FindElement(By.Id("Submit"));
            Assert.NotNull(submitButton);
        }
    }
}
