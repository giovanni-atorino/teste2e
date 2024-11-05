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
using myiveco_selenium.Values;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using myiveco_selenium.Functions;

namespace myiveco_selenium
{
   
    public class Registration_Test:CollectionMethods
    {
        public IDictionary<string, object> Vars { get; private set; }
        public TestContext TestContext { get; set; }
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        static string registration_weburl = NUnit.Framework.TestContext.Parameters["registration_weburl"].ToString();

        public void RegistrationTestForm(Xpath__Registration Xpath)

        {
            try
            {
                ChromeOptions option = new ChromeOptions();
                //option.AddArgument("--disable-web-security");
                option.AddArgument("--no-sandbox");
                option.AddArgument("--headless");
                option.AddArgument("--lang=en-GB");
                option.AddArgument("--window-size=1920,1080");
            
                driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), option);
          

                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
                js = (IJavaScriptExecutor)driver;
                Vars = new Dictionary<string, object>();


                driver.Navigate().GoToUrl(weburl_runsettings);
                driver.Manage().Window.Maximize();

                System.Threading.Thread.Sleep(5000);
                Console.WriteLine("Waited 5 s");

                // FIND AND CLICK LOGIN BUTTON
                ExpandShadowElementClickNew("//pfe-navigation-item[@id='mainMenuLoginButton']", "[class=pfe-navigation-item__trigger]", "Login button");
                System.Threading.Thread.Sleep(2000);

                //Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                Console.WriteLine("registration_weburl = " + registration_weburl);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(registration_weburl))).Click();
                Console.WriteLine("Clicked on Registration");

                System.Threading.Thread.Sleep(3000);

                //Command to accept cookies
                try
                {
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll' and contains(text(), 'Acc')]")));
                    driver.FindElement(By.XPath("//*[@id='CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll' and contains(text(), 'Acc')]"));
                    IWebElement AcceptCookies = driver.FindElement(By.XPath("//*[@id='CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll' and contains(text(), 'Acc')]"));
                    js.ExecuteScript("arguments[0].click();", AcceptCookies);
                    Console.WriteLine("Accept cookies clicked");
                }
                catch
                {
                    Console.WriteLine("Cookies not presence");
                }

                js.ExecuteScript("document.body.style.zoom = '0.50'");
            
                // FIND AND CLICK Registration BUTTON
                ExpandShadowElement("pfe-input",1,"[placeholder = 'Name']");
                Console.WriteLine("Field: Name Verified");

                ExpandShadowElement("pfe-input", 2, "[placeholder='Surname']");
                Console.WriteLine("Field: Surname Verified");

                ExpandShadowElement("pfe-input", 3, "[placeholder='Phone']");
                Console.WriteLine("Field:  Phone Verified");

                ExpandShadowElement("pfe-input", 4, "[placeholder='VAT Number']");
                Console.WriteLine("Field: VatNumber Verified");

                ExpandShadowElement("pfe-input", 5, "[placeholder='Company Name']");
                Console.WriteLine("Field: CompanyName Verified");

                ExpandShadowElement("pfe-input", 6, "[placeholder='Phone Company']");
                Console.WriteLine("Field:  Phone Company Verified");

                ExpandShadowElement("pfe-input", 7, "[placeholder='Address']");
                Console.WriteLine("Field:  Address Verified");

                ExpandShadowElement("pfe-input", 8, "[placeholder='City']");
                Console.WriteLine("Field:  City Verified");

                ExpandShadowElement("pfe-input", 9, "[placeholder='Zip Code']");
                Console.WriteLine("Field:  Zip Code Verified");



                ExpandShadowElement("pfe-input", 10, "[placeholder='Email']");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Field: Email Verified");

                ExpandShadowElement("pfe-input", 11, "[placeholder='Email']"); 
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Field:  Confirm Email Verified");

                ExpandShadowElement("pfe-input", 12, "[placeholder='Password']");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Field: Password Verified");

                ExpandShadowElement("pfe-input", 13, "[placeholder='Password']");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Field: Password Verified");

                //Verify UserCountry element
                VerifyElement(Xpath.UserCountry);
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Field: User Country Verified");
                //Verify CompanyCountry element
                VerifyElement(Xpath.CompanyCountry);
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Field: Company Country Verified");
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
      
    }
 }