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

    public class Vehicle_Download_Test : BaseClassNoHead
    {
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void VehicleDownloadFlow(Xpath__Vehicles Xpath, Values__Vehicles Value)

        {
            try
            {
                System.Threading.Thread.Sleep(3000);
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //Open Menu
                JSClickDropdownChoice(Xpath.Menu, "Menu", 1000);

                //Open Vehicle Management 
                JSClickDropdownChoice(Xpath.VehiclesManagement, "Vehicles Management", 2000);

                //Click on Recaller
                JSClickDropdownChoice(Xpath.Vehicles, "Vehicles", 2000);

                RefreshCheck(Xpath.YourVehicleHeavy);
                js.ExecuteScript("document.body.style.zoom = '0.40'");

                List<string> VehicleType = new List<string>(new string[] { });
                VehicleType = vehicleType();
                List<string> Trucks = new List<string>(new string[] { VehicleType[0], Xpath.HeavyTab, Value.HeavyTab , Xpath.ExportDataHeavyGreyButton ,Xpath.ExportDataHeavy ,Value.ExportNameHeavy });
                List<string> Daily = new List<string>(new string[] { VehicleType[1], Xpath.LightTab, Value.LightTab, Xpath.ExportDataLightGreyButton, Xpath.ExportDataLight, Value.ExportNameLight });
                List<string> HeavyBus = new List<string>(new string[] { VehicleType[2], Xpath.HeavyBusTab, Value.HeavyBusTab, Xpath.ExportDataHeavyBusGreyButton, Xpath.ExportDataHeavyBus, Value.ExportNameHeavyBus });
                List<string> Tway = new List<string>(new string[] { VehicleType[3], Xpath.TwayTab, Value.TwayTab, Xpath.ExportDataTwayGreyButton, Xpath.ExportDataTway, Value.ExportNameTway });
                List<List<string>> Vehicles = new List<List<string>>(new List<string>[] { Trucks, Daily, HeavyBus, Tway });

                foreach (List<string> Data in Vehicles)
                {
                //Verify the presence of tab
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[1])));
                Assert.That(driver.FindElement(By.XPath(Data[1])).Text, Is.EqualTo(Data[2]));
                Console.WriteLine("Verified presence of "+ Data[0] + " Tab");

                //Click on tab
                IWebElement TabButton = driver.FindElement(By.XPath(Data[1]));
                js.ExecuteScript("arguments[0].click();", TabButton);
                Console.WriteLine("Click on " + Data[0] + " Tab");
                System.Threading.Thread.Sleep(2000);
                
                Console.WriteLine("Export for " + Data[0] + " tab");
                DownloadExport(Data[3], Data[4]);

                    System.Threading.Thread.Sleep(2000);


                    //Check presence of export file and delete it
                    Console.WriteLine("Check if file is availbale in /Download section");
                bool exportFileExistHeavy = CheckFileDownloaded(Data[5]);
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
