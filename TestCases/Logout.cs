using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using myiveco_selenium.Xpath;
using myiveco_selenium.Values;
using myiveco_selenium.Filters;
using myiveco_selenium.Functions;

namespace myiveco_selenium
{
    public class Logout_Section : BaseClass
    {
        public void LogoutSection(Xpath__Login Xpath, Values__Login Value)
        {
           try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                js.ExecuteScript("document.body.style.zoom = '0.40'");

                // Verify the presence of Account Section
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Account)));
                Console.WriteLine("Verified presence of Account");

                //Open Account
                IWebElement AccountButton = driver.FindElement(By.XPath(Xpath.Account));
                js.ExecuteScript("arguments[0].click();", AccountButton);
                Console.WriteLine("Open Account");

                // Verify the presence of Logout button
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.LogoutButton)));
                System.Threading.Thread.Sleep(1000);

                // Cliking Logout button
                IWebElement LogoutButtonButton = driver.FindElement(By.XPath(Xpath.LogoutButton));
                js.ExecuteScript("arguments[0].click();", LogoutButtonButton);
                Console.WriteLine("Cliking Logout button");

                System.Threading.Thread.Sleep(5000);
                Console.WriteLine("Waited 5 s for logging out");

                // FIND AND CLICK LOGIN BUTTON
                ExpandShadowElement("pfe-navigation-item",2, "[class=pfe-navigation-item__trigger]");
                Console.WriteLine("Verified presence of Login button in Homepage");
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
    }
}