using OpenQA.Selenium;
using SeleniumTestConsole.Interfaces;
using System;

namespace SeleniumTestConsole.Concretes
{
    public class GmailLogin : ILogin
    {
        private readonly IWebDriver _driver;
        private readonly string _loginURL = "http://www.gmail.com";
        private bool _successful = false;
        private bool _validEmailAccount = true;

        public GmailLogin(IWebDriver driver)
        {
            _driver = driver;
        }

        public void openDefaultURL()
        {
            _driver.Navigate().GoToUrl(_loginURL);
        }

        public void doLogin(string username, string password)
        {
            IWebElement accountChooser = _driver.FindElementSafe(By.Id("account-chooser-add-account"));

            if (accountChooser.Exists())
            {
                accountChooser.Click();
                _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            }

            IWebElement emaiId = _driver.FindElement(By.Id("Email"));
            emaiId.SendKeys(username);

            IWebElement nextButton = _driver.FindElement(By.Id("next"));
            nextButton.Click();

            IWebElement invalidEmailMgmElement = _driver.FindElementSafe(By.Id("errormsg_0_Email"));
            //wait for the page to load up
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));

            if (invalidEmailMgmElement != null && invalidEmailMgmElement.Exists() && !string.IsNullOrWhiteSpace(invalidEmailMgmElement.Text))
            {
                //if invalid email do not proceed and exit
                return;
            }
            _validEmailAccount = true;

            IWebElement passwordBox = _driver.FindElement(By.Id("Passwd"));
            passwordBox.SendKeys(password);

            IWebElement checkBox = _driver.FindElement(By.Id("PersistentCookie"));
            if (checkBox.Selected)
                checkBox.Click();

            IWebElement signInButton = _driver.FindElement(By.Id("signIn"));
            signInButton.Click();

            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            IWebElement passwordError = _driver.FindElementSafe(By.Id("errormsg_0_Passwd"));

            if (passwordError == null || (!passwordError.Exists() && !string.IsNullOrWhiteSpace(passwordError.Text)))
            {
                _successful = true;
            }
        }

        public bool IsSuccessful()
        {
            return _successful;
        }
        public bool IsValidAccount()
        {
            return _validEmailAccount;
        }
    }
}