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
    public class Driver_Section_Archived_Drivers: BaseClass
    {
        public void DriversSectionArchivedDrivers(Xpath__Drivers Xpath, Values__Drivers Value)
        {
            try
            { 
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                js.ExecuteScript("document.body.style.zoom = '0.30'");

                //Open Menu + Click on Driver Section
                OpenSectionMenu(Xpath.Menu, Xpath.Drivers, Value.Drivers, 1000);

                //Verify presence of two tabs: Active Drivers and Archive Drivers
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ActiveDrivers)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ActiveDrivers)).Text, Is.EqualTo(Value.ActiveDrivers));
                Console.WriteLine("Verified presence of Active Drivers tab");

                //Verify presence of two tabs: Active Drivers and Archive Drivers
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ArchivedDrivers)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ArchivedDrivers)).Text, Is.EqualTo(Value.ArchivedDrivers));
                Console.WriteLine("Verified presence of Archived Drivers tab");

                //Click on Archived Drivers 
                IWebElement ArchivedDriversButton = driver.FindElement(By.XPath(Xpath.ArchivedDrivers));
                js.ExecuteScript("arguments[0].click();", ArchivedDriversButton);
                Console.WriteLine("Open Archived Drivers section: archived driver are shown");
                System.Threading.Thread.Sleep(2000);

                // Verify the presence of Your Drivers Column 
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ArchivedYourDrivers)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ArchivedYourDrivers)).Text, Is.EqualTo(Value.YourDrivers));
                Console.WriteLine("Verified presence of Your Drivers Column");
                
                // Verify the presence of ID driver Column
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ArchivedIDdriver)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ArchivedIDdriver)).Text, Is.EqualTo(Value.IDdriver));
                Console.WriteLine("Verified presence of ID driver Column");


                // Verify the presence of Email Column
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ArchivedEmail)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ArchivedEmail)).Text, Is.EqualTo(Value.Email));
                Console.WriteLine("Verified presence of Email Column");

                // Verify the presence of Driver First Name  Column
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ArchivedDriverFirstName)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ArchivedDriverFirstName)).Text, Is.EqualTo(Value.DriverFirstName));
                Console.WriteLine("Verified presence of Drive First Name Column");

                // Verify the presence of Driver Last Name Column
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ArchivedDriverLastName)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ArchivedDriverLastName)).Text, Is.EqualTo(Value.DriverLastName));
                Console.WriteLine("Verified presence of Driver Last Name Column");

                //ExpandTable
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ArchivedExpandTable)));
                IWebElement ExpandTableButton = driver.FindElement(By.XPath(Xpath.ArchivedExpandTable));
                js.ExecuteScript("arguments[0].click();", ExpandTableButton);
                Console.WriteLine("Expand Table");
                System.Threading.Thread.Sleep(1000);

                // Verify the presence of Phone Column
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ArchivedPhone)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ArchivedPhone)).Text, Is.EqualTo(Value.Phone));
                Console.WriteLine("Verified presence of Phone Column");

                // Verify the presence of Country Column
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ArchivedCountry)));
                System.Threading.Thread.Sleep(1000);
                Assert.That(driver.FindElement(By.XPath(Xpath.ArchivedCountry)).Text, Is.EqualTo(Value.Country));
                Console.WriteLine("Verified presence of Country Column");

                // Verify the presence of Language Column
                //wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ArchivedLanguage)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.ArchivedLanguage)).Text, Is.EqualTo(Value.Language));
                Console.WriteLine("Verified presence of Language Column");

                // Verify the presence of Action Column
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ArchivedAction)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ArchivedAction)).Text, Is.EqualTo(Value.Action));
                Console.WriteLine("Verified presence of Action Column");
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        driver.Close();
        }
    }
}