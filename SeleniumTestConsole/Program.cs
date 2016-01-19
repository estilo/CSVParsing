using System;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumTestConsole.Concretes;
using SeleniumTestConsole.Interfaces;
using SeleniumTestConsole.Models;
using System.Collections.Generic;
using System.IO;

namespace SeleniumTestConsole
{
    public class Program
    {
        private static void Main(string[] args)
        {

            var listofAgent = JsonConvert.DeserializeObject<List<UserAgent>>(File.ReadAllText(@"UserAgentMaster.json"));
            foreach (var userAgent in listofAgent)
            {
                //FirefoxProfile profile = new FirefoxProfile();
                //profile.SetPreference("general.useragent.override", "Mozilla/5.0 (iPad; CPU OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5355d Safari/8536.25");
                //profile.set_preference("network.proxy.type", 1)
                //profile.set_preference("network.proxy.http", "46.102.106.59")
                //profile.set_preference("network.proxy.http_port", "13228")
                //profile.set_preference("network.proxy.ssl", "46.102.106.59")
                //profile.set_preference("network.proxy.ssl_port", "13228")

                //IWebDriver driver = new FirefoxDriver(profile);

                ChromeOptions options = new ChromeOptions();
                //http://scraping.pro/change-webdrivers-ip-address/

                //options.AddArgument("--proxy-server=152.179.158.66:3128");
                //options.AddArgument("--proxy-server=37.46.129.238:8080");
                //
                //
                //browser = webdriver.Chrome(executable_path = 'ChromeDriverPath', chrome_options = options)
                //options.AddArgument("--user-agent=Mozilla/5.0 (iPad; CPU OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5355d Safari/8536.25");

                //options.AddArgument("--user-agent=Mozilla/5.0 (iPad; CPU OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5355d Safari/8536.25");
                //options.AddArgument("Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; AS; rv:11.0) like Gecko");
                options.AddArgument(string.Format("--user-agent={0}", userAgent.ua));

                IWebDriver driver = new ChromeDriver(options);
                driver.Navigate();
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("http://www.whatsmyip.org/");
                //driver.Navigate().GoToUrl("https://google.com");

                //driver.Close();
            }

            Console.ReadLine();
            var credentials = new GmailCredentialCSVParser().Parse("gmailcredential.csv");
            foreach (var credential in credentials)
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate();
                driver.Manage().Window.Maximize();
                
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                ILogin g = new GmailLogin(driver);
                g.openDefaultURL();
                g.doLogin(credential.Username, credential.Password);

                if (g.IsSuccessful())
                {
                    //log into another file to save into 
                    Console.WriteLine("Login successful for {0}, {1}", credential.Username, credential.Password);
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