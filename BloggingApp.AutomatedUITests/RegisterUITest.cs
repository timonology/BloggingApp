using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BloggingApp.AutomatedUITests
{
    public class RegisterUITest : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly RegisterPage _page;
        public RegisterUITest()
        {
            _driver = new ChromeDriver();
            _page = new RegisterPage(_driver);
            _page.Navigate();
        }

        [Fact]
        public void RegisterUser_UserAlreadyExist()
        {
            _page.PopulateFullName("Timothy Babalola");
            _page.PopulateEmail("testn@gmail.com");
            _page.PopulatePassword("password");
            _page.PopulateConfirmPassword("password");
            _page.RegisterButton();
            Assert.Equal("User Already Exist", _page.errorMessageElement);
        }

        [Fact]
        public void RegisterUser_PasswordDoesNotMatch()
        {
            _page.PopulateFullName("Joyce Sean");
            _page.PopulateEmail("joyce@gmail.com");
            _page.PopulatePassword("password123");
            _page.PopulateConfirmPassword("password");
            _page.RegisterButton();
            Assert.Equal("The password and confirmation password do not match.", _page.errorConfirmPasswordElement);
        }

        [Fact]
        public void RegisterUser_PasswordFormatCheckAlphaNumberic()
        {
            _page.PopulateFullName("Joyce Sean");
            _page.PopulateEmail("joyce@gmail.com");
            _page.PopulatePassword("password");
            _page.PopulateConfirmPassword("password");
            _page.RegisterButton();
            Assert.Equal("Passwords must have at least one non alphanumeric character.", _page.errorMessageElement);
        }
        [Fact]
        public void RegisterUser_Successful()
        {
            _page.PopulateFullName("Joyce Sean");
            _page.PopulateEmail("joyce@gmail.com");
            _page.PopulatePassword("Password12@");
            _page.PopulateConfirmPassword("Password12@");
            _page.RegisterButton();
            Assert.Equal("All Post", _page.indexPageElement);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
