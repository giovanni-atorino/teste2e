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

    public class Demo_Test_Drive_Section_Download : BaseClassNoHead
    {
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public Demo_Test_Drive_Section_Download(Account Account) : base(Account) {}
        public void DemoTestDriveSectionDownload(Xpath__DemoTestDrive Xpath, Values__DemoTestDrive Value)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //Open Menu + Click on Vehicle Management + Click on Recaller
                OpenSecondSectionMenu(Xpath.Menu, Xpath.DemoTestDrive, Value.DemoTestDrive, Xpath.Report, Value.Report, 1000);

                RefreshCheck(Xpath.DemoDieselCardHeavy);
                js.ExecuteScript("document.body.style.zoom = '0.30'");

                List<string> VehicleType = new List<string>(new string[] {});
                VehicleType = vehicleType();
                List<string> Trucks = new List<string>(new string[] { VehicleType[0], Xpath.HeavyTab , Value.HeavyTab });
                List<string> Daily = new List<string>(new string[]  { VehicleType[1], Xpath.LightTab, Value.LightTab });
                List<string> HeavyBus = new List<string>(new string[] { VehicleType[2], Xpath.HeavyBusTab, Value.HeavyBusTab });
                List<string> Tway = new List<string>(new string[]  { VehicleType[3], Xpath.TwayTab, Value.TwayTab });
                List<List<string>> Vehicles = new List<List<string>>(new List<string>[] { Trucks, Daily, HeavyBus, Tway });

                Export(Vehicles, Xpath, Value, Value.ExportName);


                //Open Menu

                //Open Menu + Click on Demo Test Drive + Click on Vehicle Fleet
                OpenSecondSectionMenu(Xpath.Menu, Xpath.DemoTestDrive, Value.DemoTestDrive, Xpath.VehicleFleet, Value.VehicleFleet, 1000);

                RefreshCheck(Xpath.AddVehicles);
                js.ExecuteScript("document.body.style.zoom = '0.30'");

                //Verify the presence of Add vehicle button
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.AddVehicles)));
                Console.WriteLine("Verified presence of Add vehicle button");

                Export(Vehicles, Xpath, Value,Value.ExportNameFleet);
       
                
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }

            driver.Close();
        }
        public void Export (List<List<string>> Vehicles ,Xpath__DemoTestDrive Xpath, Values__DemoTestDrive Value,String ExportNameFile) { 
            foreach (List<string> Data in Vehicles)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                //Verify the presence of Tab
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[1])));
                Assert.That(driver.FindElement(By.XPath(Data[1])).Text, Is.EqualTo(Data[2]));
                Console.WriteLine("Verified presence of "+ Data[0]+ " Tab");

                //Click on Tab
                IWebElement TabButton = driver.FindElement(By.XPath(Data[1]));
                js.ExecuteScript("arguments[0].click();", TabButton);
                Console.WriteLine("Open "+ Data[0] + " Tab");
                System.Threading.Thread.Sleep(2000);

                //Verify the presence of market column
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Market)));
                Console.WriteLine("Demo test drive section opened");

                //Download export file 
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ExportData)));
                IWebElement ExportData = driver.FindElement(By.XPath(Xpath.ExportData));
                js.ExecuteScript("arguments[0].click();", ExportData);
                Console.WriteLine("Export excel for "+ Data[0]);
                //System.Threading.Thread.Sleep(10000);

                //Waiting until the spinner is not visible anymore
                WaitingSpinner(Xpath.DownloadMask, 5000);

                // Check presence of export file and delete it
                Console.WriteLine("Check if file is availbale in /Download section");
                bool exportFileExist = CheckFileDownloaded(ExportNameFile);
                Assert.That(exportFileExist == true);
                Console.WriteLine("Check completed");
              }
        }
    }
}
