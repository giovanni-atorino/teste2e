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
    public class Driver_Section_Archive_Reactive_One_Driver: BaseClass
    {
        public void DriversSectionArchiveReactiveOneDriver(Xpath__Drivers Xpath, Values__Drivers Value)
        {
            try
            { 
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                js.ExecuteScript("document.body.style.zoom = '0.30'");

                // Verify the presence of menu
                AssertElementIsEqualTo(Xpath.Menu, Value.Menu);

                //Open Menu + Click on Driver Section
                OpenSectionMenu(Xpath.Menu, Xpath.Drivers, Value.Drivers, 1000);

                RefreshCheck(Xpath.ActiveDrivers);

                //Verify presence of two tabs: Active Drivers and Archive Drivers
                AssertElementIsEqualTo(Xpath.ActiveDrivers, Value.ActiveDrivers);

                //Verify presence of two tabs: Active Drivers and Archive Drivers
                AssertElementIsEqualTo(Xpath.ArchivedDrivers, Value.ArchivedDrivers);

                //wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Xpath.ExportData)));
                WaitingSpinner(Xpath.ExportDataGreyButton, 1000);
                Console.WriteLine("Driver list visible");

                //First driver in Active Driver column
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FirstActiveDriverID)));
                String FirstActiveDriverID = driver.FindElement(By.XPath(Xpath.FirstActiveDriverID)).Text;
                Console.WriteLine("The first acive driver in the table is the driver with ID: " + FirstActiveDriverID);

                //Archive one driver
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ArchivedButton)));
                IWebElement ArchivedButton = driver.FindElement(By.XPath(Xpath.ArchivedButton));
                js.ExecuteScript("arguments[0].click();", ArchivedButton);
                Console.WriteLine("Click on Archive button for the driver in the first row of active drivers table");

                System.Threading.Thread.Sleep(500);
                WaitingSpinner(Xpath.ExportDataGreyButton, 1000);
                //wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Xpath.ExportData)));

                //Click on Archived Drivers 
                JSClickDropdownChoice(Xpath.ArchivedDrivers, Value.ArchivedDrivers, 2000);
                Console.WriteLine("Open Archived Drivers section: archived driver are shown");

                System.Threading.Thread.Sleep(500);
                WaitingSpinner(Xpath.ExportDataGreyButton, 1000);
                //wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Xpath.ExportData)));

                //Filter column for drivers ID in order to find the element
                IWebElement FilterIDDriverArchivedSection = driver.FindElement(By.XPath(Xpath.FilterIDDriverArchivedSection));
                js.ExecuteScript("arguments[0].click();", FilterIDDriverArchivedSection);
                Console.WriteLine("Open Filter for ID driver on archived section");
                System.Threading.Thread.Sleep(1000);

                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FieldIDDriverText)));
                driver.FindElement(By.XPath(Xpath.FieldIDDriverText)).SendKeys(FirstActiveDriverID);
                System.Threading.Thread.Sleep(1000);

                //Click on Apply
                IWebElement ApplyButton = driver.FindElement(By.XPath(Xpath.ApplyButton));
                js.ExecuteScript("arguments[0].click();", ApplyButton);
                Console.WriteLine("Click on Apply button");
                System.Threading.Thread.Sleep(5000);

                //Verify that the driver is now archived 
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FirstArchivedDriverID)));
                String FirstArchivedDriverID = driver.FindElement(By.XPath(Xpath.FirstArchivedDriverID)).Text;
                Assert.That(FirstArchivedDriverID, Is.EqualTo(FirstActiveDriverID));
                Console.WriteLine("The first active driver " + FirstActiveDriverID+  " is now archived");

                //Reactivate that driver 
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ReactivateButton)));
                IWebElement ReactivateButton = driver.FindElement(By.XPath(Xpath.ReactivateButton));
                js.ExecuteScript("arguments[0].click();", ReactivateButton);
                Console.WriteLine("Click on Reactivate button for the driver in the first row of archived drivers table");

                System.Threading.Thread.Sleep(500);
                WaitingSpinner(Xpath.ExportDataGreyButton, 1000);
                //wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Xpath.ExportData)));

                //Click on Active Drivers
                IWebElement ActiveDriversButton = driver.FindElement(By.XPath(Xpath.ActiveDrivers));
                js.ExecuteScript("arguments[0].click();", ActiveDriversButton);
                Console.WriteLine("Open Active Drivers section: active driver are shown");

                System.Threading.Thread.Sleep(500);
                WaitingSpinner(Xpath.ExportDataGreyButton, 1000);
                //wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Xpath.ExportData)));

                //Filter column for drivers ID in order to find the element
                IWebElement FilterIDDriverActiveSection = driver.FindElement(By.XPath(Xpath.FilterIDDriverActiveSection));
                js.ExecuteScript("arguments[0].click();", FilterIDDriverActiveSection);
                Console.WriteLine("Open Filter for ID driver in active section");
                System.Threading.Thread.Sleep(1000);

                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FieldIDDriverText)));
                driver.FindElement(By.XPath(Xpath.FieldIDDriverText)).SendKeys(FirstActiveDriverID);
                System.Threading.Thread.Sleep(1000);

                //Click on Apply
                IWebElement ApplyButton2 = driver.FindElement(By.XPath(Xpath.ApplyButton));
                js.ExecuteScript("arguments[0].click();", ApplyButton2);
                Console.WriteLine("Click on Apply button");
                System.Threading.Thread.Sleep(5000);

                //Verify that the driver is now re-activated 
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FirstActiveDriverID)));
                Console.WriteLine("The first active driver " + FirstActiveDriverID + " is now areactivated again");


            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        driver.Close();
        }
    }
}