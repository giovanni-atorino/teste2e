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
using myiveco_selenium.Xpath;
using System.Reflection;
using myiveco_selenium.Values;
using myiveco_selenium.Filters;
using myiveco_selenium.Functions;


namespace myiveco_selenium
{
    public class Vehicles_Maintenance : BaseClass
    {
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void VehiclesMaintenance(Xpath__Vehicles Xpath, Values__Vehicles Value)

        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //Open Menu
                JSClickDropdownChoice(Xpath.Menu, "Menu", 1000);

                //Open Vehicle Management 
                JSClickDropdownChoice(Xpath.VehiclesManagement, "Vehicles Management", 2000);

                //Click on Maintenance
                JSClickDropdownChoice(Xpath.VehiclesMaintenance, "Vehicles Maintenance", 2000);

                js.ExecuteScript("document.body.style.zoom = '0.40'");

                List<string> VehicleType = new List<string>(new string[] { });
                VehicleType = vehicleType();
                List<string> Trucks = new List<string>(new string[] { VehicleType[0], Xpath.HeavyTab, Value.HeavyTab, Xpath.YourVehicleHeavy, Xpath.VehicleNameHeavy, Xpath.VINHeavy, Xpath.PlateNumberHeavy, Xpath.OdemeterHeavy, Xpath.EngineHeavy, Xpath.NextMaintenanceHeavy, Xpath.SeverityHeavy });
                List<string> Daily = new List<string>(new string[] { VehicleType[1], Xpath.LightTab, Value.LightTab, Xpath.YourVehicleLight, Xpath.VehicleNameLight, Xpath.VINLight, Xpath.PlateNumberLight, Xpath.OdemeterLight, Xpath.EngineLight, Xpath.NextMaintenanceLight, Xpath.SeverityLight });
                List<string> Tway = new List<string>(new string[] { VehicleType[2], Xpath.TwayTab, Value.TwayTab, Xpath.YourVehicleTway, Xpath.VehicleNameTway, Xpath.VINTway, Xpath.PlateNumberTway, Xpath.OdemeterTway, Xpath.EngineTway, Xpath.NextMaintenanceTway, Xpath.SeverityTway });
                List<List<string>> Vehicles = new List<List<string>>(new List<string>[] { Trucks, Daily, Tway });

                foreach (List<string> Data in Vehicles)
                {
                    // Verify the presence of tab    
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[1])));
                    Assert.That(driver.FindElement(By.XPath(Data[1])).Text, Is.EqualTo(Data[2]));
                    Console.WriteLine("Verified presence of " + Data[0] + " Tab");

                    //Click on Light tab
                    IWebElement TabButton = driver.FindElement(By.XPath(Data[1]));
                    js.ExecuteScript("arguments[0].click();", TabButton);
                    Console.WriteLine("Click on " + Data[0] + " Tab");
                    System.Threading.Thread.Sleep(5000);

                    // Verify the presence of Your Vehicle Column
                    Assert.That(driver.FindElement(By.XPath(Data[3])).Text, Is.EqualTo(Value.YourVehicle));
                    Console.WriteLine("Verified presence of Your Vehicle Column for " + Data[0]);

                    // Verify the presence of Vehicle Name Column
                    Assert.That(driver.FindElement(By.XPath(Data[4])).Text, Is.EqualTo(Value.VehicleName));
                    Console.WriteLine("Verified presence of Vehicle Name Column for " + Data[0]);

                    // Verify the presence of VIN Column
                    Assert.That(driver.FindElement(By.XPath(Data[5])).Text, Is.EqualTo(Value.VIN));
                    Console.WriteLine("Verified presence of VIN Column for " + Data[0]);

                    // Verify the presence of Plate Number Column
                    Assert.That(driver.FindElement(By.XPath(Data[6])).Text, Is.EqualTo(Value.PlateNumber));
                    Console.WriteLine("Verified presence of Plate Number Column for " + Data[0]);

                    // Verify the presence of Odometer Column
                    Assert.That(driver.FindElement(By.XPath(Data[7])).Text, Is.EqualTo(Value.Odometer));
                    Console.WriteLine("Verified presence of Odometer Column for " + Data[0]);

                    // Verify the presence of Engine work hours Column
                    Assert.That(driver.FindElement(By.XPath(Data[8])).Text, Is.EqualTo(Value.EngineHeavy));
                    Console.WriteLine("Verified presence of Engine work hours Column for " + Data[0]);

                    // Verify the presence of Next Maintenance Column
                    Assert.That(driver.FindElement(By.XPath(Data[9])).Text, Is.EqualTo(Value.NextMaintenance));
                    Console.WriteLine("Verified presence of Next Maintenance Column for " + Data[0]);

                    // Verify the presence of Severity Column
                    Assert.That(driver.FindElement(By.XPath(Data[10])).Text, Is.EqualTo(Value.Severity));    
                    Console.WriteLine("Verified presence of Severity Column for " + Data[0]);

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
