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
    public class Permissions_Navigation: BaseClass
    {
        public void PermissionsNavigation(Xpath__Permissions Xpath, Values__Permissions Value)
        {
            try
            { 
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            
                js.ExecuteScript("document.body.style.zoom = '0.30'");

                // Verify the presence of menu
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.Menu)).Text, Is.EqualTo(Value.Menu));
                Console.WriteLine("Verified presence of Menu");

                //Open Menu
                IWebElement MenuButton = driver.FindElement(By.XPath(Xpath.Menu));
                js.ExecuteScript("arguments[0].click();", MenuButton);
                Console.WriteLine("Open Menu");

                //Verify the presence of Permissions section
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Permissions)));
                System.Threading.Thread.Sleep(1000);
                //Assert.That(driver.FindElement(By.XPath(Xpath.Permissions)).Text, Is.EqualTo(Value.Permissions));
                Console.WriteLine("Verified presence of Permissions section");

                //Click on Permissions section
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Permissions)));
                IWebElement PermissionsButton = driver.FindElement(By.XPath(Xpath.Permissions));
                js.ExecuteScript("arguments[0].click();", PermissionsButton);
                Console.WriteLine("Click on Permissions section");

                //Click on Permissions section
                System.Threading.Thread.Sleep(1000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Permissions2)));
                IWebElement Permissions2Button = driver.FindElement(By.XPath(Xpath.Permissions2));
                js.ExecuteScript("arguments[0].click();", Permissions2Button);
                Console.WriteLine("Open Permissions section");
                System.Threading.Thread.Sleep(1000);

                //Click on Show Vehicle Detail section
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ShowVehicleDetail)));
                IWebElement ShowVehicleDetailButton = driver.FindElement(By.XPath(Xpath.ShowVehicleDetail));
                js.ExecuteScript("arguments[0].click();", ShowVehicleDetailButton);
                Console.WriteLine("Opened Show Vehicle Detail section");
                System.Threading.Thread.Sleep(1000);
                js.ExecuteScript("document.body.style.zoom = '0.50'");

                //Click on Heavy tab
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.HeavyTab)));
                IWebElement HeavyTabButton = driver.FindElement(By.XPath(Xpath.HeavyTab));
                js.ExecuteScript("arguments[0].click();", HeavyTabButton);
                Console.WriteLine("Click on Heavy tab");
                System.Threading.Thread.Sleep(1000);

                //Click on Light tab
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.LightTab)));
                IWebElement LightTabButton = driver.FindElement(By.XPath(Xpath.LightTab));
                js.ExecuteScript("arguments[0].click();", LightTabButton);
                Console.WriteLine("Click on Light tab");
                System.Threading.Thread.Sleep(1000);

                //Click on HeavyBus tab
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.HeavyBusTab)));
                IWebElement HeavyBusTabButton = driver.FindElement(By.XPath(Xpath.HeavyBusTab));
                js.ExecuteScript("arguments[0].click();", HeavyBusTabButton);
                Console.WriteLine("Click on HeavyBus tab");
                System.Threading.Thread.Sleep(1000);

                //Click on Tway tab
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.TwayTab)));
                IWebElement TwayTabButton = driver.FindElement(By.XPath(Xpath.TwayTab));
                js.ExecuteScript("arguments[0].click();", TwayTabButton);
                Console.WriteLine("Click on Tway tab");
                System.Threading.Thread.Sleep(1000);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
         driver.Close();
        }
    }
}