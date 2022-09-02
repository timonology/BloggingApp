using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingApp.AutomatedUITests.Account
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private const string URI = "https://localhost:44300/Account/Login";

        private IWebElement EmailElement => _driver.FindElement(By.Id("Email"));
        private IWebElement PasswordElement => _driver.FindElement(By.Id("Password"));
        private IWebElement SubmitElement => _driver.FindElement(By.Id("Submit"));

        public string errorMessageElement => _driver.FindElement(By.Id("errorMessage")).Text;
        public string indexPageElement => _driver.FindElement(By.Id("index_page")).Text;

        public LoginPage(IWebDriver driver) => _driver = driver;
        public void Navigate() => _driver.Navigate()
                .GoToUrl(URI);

        public void PopulateEmail(string email) => EmailElement.SendKeys(email);
        public void PopulatePassword(string password) => PasswordElement.SendKeys(password);
        public void LoginButton() => SubmitElement.Click();

    }
}
