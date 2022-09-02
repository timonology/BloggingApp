using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingApp.AutomatedUITests
{
    public class RegisterPage
    {
        private readonly IWebDriver _driver;
        private const string URI = "https://localhost:44300/Register";

        private IWebElement FullNameElement => _driver.FindElement(By.Id("FullName"));
        private IWebElement EmailElement => _driver.FindElement(By.Id("Email"));
        private IWebElement PasswordElement => _driver.FindElement(By.Id("Password"));
        private IWebElement ConfirmPasswordElement => _driver.FindElement(By.Id("ConfirmPassword"));
        private IWebElement SubmitElement => _driver.FindElement(By.Id("Submit"));

        public string errorMessageElement => _driver.FindElement(By.Id("errorMessage")).Text;
        public string errorConfirmPasswordElement => _driver.FindElement(By.Id("ConfirmPasswordMsg")).Text;
        public string indexPageElement => _driver.FindElement(By.Id("index_page")).Text;

        public RegisterPage(IWebDriver driver) => _driver = driver;
        public void Navigate() => _driver.Navigate()
                .GoToUrl(URI);

        public void PopulateFullName(string fullname) => FullNameElement.SendKeys(fullname);
        public void PopulateEmail(string email) => EmailElement.SendKeys(email);
        public void PopulatePassword(string password) => PasswordElement.SendKeys(password);
        public void PopulateConfirmPassword(string confirmPassword) => ConfirmPasswordElement.SendKeys(confirmPassword);
        public void RegisterButton() => SubmitElement.Click();
    }
}
