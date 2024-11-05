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
    public class Permissions_Section: BaseClass
    {
        public void PermissionsSection(Xpath__Permissions Xpath, Values__Permissions Value)
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
                IWebElement PermissionsButton = driver.FindElement(By.XPath(Xpath.Permissions));
                js.ExecuteScript("arguments[0].click();", PermissionsButton);
                Console.WriteLine("Click on Permissions section");

                //Click on Permissions section
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Permissions2)));
                System.Threading.Thread.Sleep(1000);
                IWebElement Permissions2Button = driver.FindElement(By.XPath(Xpath.Permissions2));
                js.ExecuteScript("arguments[0].click();", Permissions2Button);
                Console.WriteLine("Open Permissions section");

                //Verify the presence of Account
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Account)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Account)).Text, Is.EqualTo(Value.Account));
                Console.WriteLine("Verified presence of Account");

                //Verify the presence of Registered
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Registered)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Registered)).Text, Is.EqualTo(Value.Registered));
                Console.WriteLine("Verified presence of Registered");

                //Verify the presence of Name
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Name)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Name)).Text, Is.EqualTo(Value.Name));
                Console.WriteLine("Verified presence of Name");

                //Verify the presence of Surname
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Surname)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Surname)).Text, Is.EqualTo(Value.Surname));
                Console.WriteLine("Verified presence of Surname");

                //Verify the presence of Vehicles Visibility
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehiclesVisibility)));
                Assert.That(driver.FindElement(By.XPath(Xpath.VehiclesVisibility)).Text, Is.EqualTo(Value.VehiclesVisibility));
                Console.WriteLine("Verified presence of Vehicles Visibility");

                //Verify the presence of Actions
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Actions)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Actions)).Text, Is.EqualTo(Value.Actions));
                Console.WriteLine("Verified presence of Actions");
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        driver.Close();
        }
    }
}