using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BloggingApp.AutomatedUITests.Account
{
    public class LoginUITest : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _page;
        public LoginUITest()
        {
            _driver = new ChromeDriver();
            _page = new LoginPage(_driver);
            _page.Navigate();
        }
        [Fact]
        public void LoginUser_Invalid()
        {
            _page.PopulateEmail("testn@gmail.com");
            _page.PopulatePassword("wrongpassword");
            _page.LoginButton();
            Assert.Equal("Incorrect User Credentials", _page.errorMessageElement);
        }
        [Fact]
        public void LoginUser_Successful()
        {
            _page.PopulateEmail("testn@gmail.com");
            _page.PopulatePassword("Test12@");
            _page.LoginButton();
            Assert.Equal("All Post", _page.indexPageElement);
        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
