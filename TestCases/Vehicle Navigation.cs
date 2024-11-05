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
    public class Vehicles_Navigation: BaseClass
    {
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void VehiclesNavigation(Xpath__Vehicles Xpath, Values__Vehicles Value)

        { 
            try
            { 
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //Open Menu
                JSClickDropdownChoice(Xpath.Menu, "Menu", 1000);

                //Open Vehicle Management 
                JSClickDropdownChoice(Xpath.VehiclesManagement, "Vehicles Management", 2000);

                //Click on Recaller
                JSClickDropdownChoice(Xpath.Vehicles, "Vehicles", 2000);

                RefreshCheck(Xpath.YourVehicleHeavy);

                List<string> VehicleType = new List<string>(new string[] { });
                VehicleType = vehicleType();
                List<string> Trucks = new List<string>(new string[] { VehicleType[0], Xpath.HeavyTab, Value.HeavyTab });
                List<string> Daily = new List<string>(new string[] { VehicleType[1], Xpath.LightTab, Value.LightTab });
                List<string> HeavyBus = new List<string>(new string[] { VehicleType[2], Xpath.HeavyBusTab, Value.HeavyBusTab });
                List<string> Tway = new List<string>(new string[] { VehicleType[3], Xpath.TwayTab, Value.TwayTab });
                List<List<string>> Vehicles = new List<List<string>>(new List<string>[] { Trucks, Daily, HeavyBus, Tway });

                foreach (List<string> Data in Vehicles)
                {
                // Verify the presence of tab
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[1])));
                Assert.That(driver.FindElement(By.XPath(Data[1])).Text, Is.EqualTo(Data[2]));
                Console.WriteLine("Verified presence of "+ Data[0] + " Tab");

                //Click on tab
                IWebElement Button = driver.FindElement(By.XPath(Data[1]));
                js.ExecuteScript("arguments[0].click();", Button);
                Console.WriteLine("Click on " + Data[0] + " Tab");

             
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