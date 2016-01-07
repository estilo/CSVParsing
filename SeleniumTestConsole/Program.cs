using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumTestConsole.Concretes;
using SeleniumTestConsole.Interfaces;

namespace SeleniumTestConsole
{
    public class Program
    {
        private static void Main(string[] args)
        {

            var credentials = new GmailCredentialCSVParser().Parse("gmailcredential.csv");
            foreach (var credential in credentials)
            {
                IWebDriver driver = new FirefoxDriver();
                //IWebDriver driver = new ChromeDriver();
                driver.Navigate();
                driver.Manage().Window.Maximize();

                ILogin g = new GmailLogin(driver);
                g.openDefaultURL();
                g.doLogin(credential.Username, credential.Password);
                
                if (g.IsSuccessful())
                {
                    //log into another file to save into 
                    Console.WriteLine( "Login successful for {0}, {1}", credential.Username,credential.Password);
                }
                else
                {
                    Console.WriteLine("Login failed for {0}, {1}", credential.Username, credential.Password);
                }
                driver.Close();
            }

            Console.ReadLine();
        }
    }
}