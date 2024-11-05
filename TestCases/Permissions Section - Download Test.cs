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

    public class Permissions_Download_Test : BaseClassNoHead
    {
        public void PermissionsDownloadFlow(Xpath__Permissions Xpath, Values__Permissions Value)

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

                List<string> VehicleType = new List<string>(new string[] { });
                VehicleType = vehicleType();
                List<string> Trucks = new List<string>(new string[] { VehicleType[0], Xpath.HeavyTab, Value.HeavyTab });
                List<string> Daily = new List<string>(new string[] { VehicleType[1], Xpath.LightTab, Value.LightTab });
                List<string> HeavyBus = new List<string>(new string[] { VehicleType[2], Xpath.HeavyBusTab, Value.HeavyBusTab });
                List<string> Tway = new List<string>(new string[] { VehicleType[3], Xpath.TwayTab, Value.TwayTab });
                List<List<string>> Vehicles = new List<List<string>>(new List<string>[] { Trucks, Daily, HeavyBus, Tway });

                foreach (List<string> Data in Vehicles)
                {
                //Click on  tab
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[1])));
                IWebElement TabButton = driver.FindElement(By.XPath(Data[1]));
                js.ExecuteScript("arguments[0].click();", TabButton);
                Console.WriteLine("Click on "+ Data[0] + " tab");
                System.Threading.Thread.Sleep(1000);

                //Download export file 
                JSClickDropdownChoice(Xpath.ExportData ,"", 10000 );
                Console.WriteLine("Export excel for "+ Data[0]);

                // Check presence of export file and delete it
                Console.WriteLine("Check if file is availbale in /Download section");
                bool exportFileExistHeavy = CheckFileDownloaded(Value.ExportName);
                Assert.That(exportFileExistHeavy == true);
                Console.WriteLine("Check completed");

                }
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }

            driver.Close();
        }
    }
}
