using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using myiveco_selenium.Xpath;
using myiveco_selenium.Filters;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;

namespace myiveco_selenium.Functions
{
    public class BaseClass: CollectionMethods
    {
        public IDictionary<string, object> Vars { get; private set; }

        // Import variable from .runsettings
        public TestContext TestContext { get; set; }
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        static string fm_account_runsettings = NUnit.Framework.TestContext.Parameters["fm_account"].ToString();
        static string fm_pwd_runsettings = NUnit.Framework.TestContext.Parameters["fm_pwd"].ToString();

        //Define standard fleet manager username and password, parametrized on each environment
        private String Email = fm_account_runsettings;
        private String Password = fm_pwd_runsettings;

        public BaseClass(Account Account)
        {
            this.Password = Account.Password;
            this.Email = Account.Email;
        }


        public BaseClass()
        {
        }

        [OneTimeSetUp]
        public void Open()

        {
            ChromeOptions option = new ChromeOptions();
            //option.AddArgument("--disable-web-security");
            option.AddArgument("--no-sandbox");
            //option.AddArgument("--headless");
            option.AddArgument("--lang=en-GB");
            option.AddArgument("--window-size=1920,1080");

            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), option);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            js = (IJavaScriptExecutor)driver;
            Vars = new Dictionary<string, object>();

            // Navigate to DEV, BETA, CERT or PROD url defined in .runsettings file
            driver.Navigate().GoToUrl(weburl_runsettings);
            Console.WriteLine("Navigating to: " + weburl_runsettings);
            driver.Manage().Window.Maximize();

            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Waited 5 s");

            // FIND AND CLICK LOGIN BUTTON
            ExpandShadowElementClickNew("//pfe-navigation-item[@id='mainMenuLoginButton']", "[class=pfe-navigation-item__trigger]", "Login button");
            //ExpandShadowElementAndClick("pfe-navigation-item", 3, "[class=pfe-navigation-item__trigger]");
            System.Threading.Thread.Sleep(3000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            wait.Until(ExpectedConditions.ElementExists(By.Id("signInName")));
            driver.FindElement(By.Id("signInName")).Click();
            driver.FindElement(By.Id("signInName")).SendKeys(Email);

            wait.Until(ExpectedConditions.ElementExists(By.Id("next")));
            driver.FindElement(By.Id("next")).Click();

            wait.Until(ExpectedConditions.ElementExists(By.Id("password")));
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).SendKeys(Password);

            wait.Until(ExpectedConditions.ElementExists(By.Id("continue")));
            driver.FindElement(By.Id("continue")).Click();

            Console.WriteLine("Clicked on LOGIN");
            js.ExecuteScript("document.body.style.zoom = '0.50'");
            System.Threading.Thread.Sleep(4000);
            Console.WriteLine("Waited 4 s");

            //Random problem that force the user to click again on login button 
            try
            {
                Console.WriteLine("Start to verify presence of element with xpath: " + "//*[@id='mainMenuLoginButton']");
                WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait1.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='mainMenuLoginButton']")));
                IWebElement DropdownChoice = driver.FindElement(By.XPath("//*[@id='mainMenuLoginButton']"));
                js.ExecuteScript("arguments[0].click();", DropdownChoice);
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Verify the presence and click on: " + "Login");


            }
            catch
            {
                Console.WriteLine("Login already performed");
            }



            //Command to accept cookies
            try
            {
                Console.WriteLine("Start to verify presence of element with xpath: " + "//*[@id='CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll' and contains(text(), 'Acc')]");
                WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait1.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll' and contains(text(), 'Acc')]")));
                IWebElement DropdownChoice = driver.FindElement(By.XPath("//*[@id='CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll' and contains(text(), 'Acc')]"));
                js.ExecuteScript("arguments[0].click();", DropdownChoice);
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Verify the presence and click on: " + "Accept cookies");

            }
            catch
            {
                Console.WriteLine("Cookies not presence");
            }

            //Command to close recaller pop-up campaign if present
            try
            {

                WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait1.Until(ExpectedConditions.ElementExists(By.XPath("//*[contains (@style,'overflow: hidden')]//h2[contains(@class, 'pfe-modal__title') and contains (text(),'IVECO Recall Campaigns')]")));
                driver.FindElement(By.XPath("//*[contains (@style,'overflow: hidden')]//h2[contains(@class, 'pfe-modal__title') and contains (text(),'IVECO Recall Campaigns')]"));
                Console.WriteLine("Recaller campaigns present at login");
                ExpandShadowElementAndClick("pfe-modal", 3, "[class=pfe-modal__close]");

            }
            catch
            {
                Console.WriteLine("Recaller campaigns not present");
            }

            //command to close pop-up in PROD if present
            try
            {
                WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait1.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='popupMaintenance']//*[contains(text(), 'CLOSE')]")));
                IWebElement DropdownChoice = driver.FindElement(By.XPath("//*[@id='popupMaintenance']//*[contains(text(), 'CLOSE')]"));
                js.ExecuteScript("arguments[0].click();", DropdownChoice);
                Console.WriteLine("Pop-up present at login");
            }
            catch
            {
                Console.WriteLine("Pop-up not present");
            }

        }

        [OneTimeTearDown]
        public void Close()
        {
            driver.Quit();
        }

    }
}
