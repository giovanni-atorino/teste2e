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
    public class Demo_Test_Drive_Section_Vehicle_Fleet_Add_Vehicle_Pop_up: BaseClass
    {
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public Demo_Test_Drive_Section_Vehicle_Fleet_Add_Vehicle_Pop_up(Account Account) : base(Account)
        {

        }
        public void DemoTestDriveSectionVehicleFleetAddVehiclePopup(Xpath__DemoTestDrive Xpath, Values__DemoTestDrive Value)

        {
            try
            { 
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            
                js.ExecuteScript("document.body.style.zoom = '0.30'");


                //Open Menu + Click on Demo Test Drive + Click on Planning
                OpenSecondSectionMenu(Xpath.Menu, Xpath.DemoTestDrive, Value.DemoTestDrive, Xpath.VehicleFleet, Value.VehicleFleet, 1000);

                RefreshCheck(Xpath.AddVehicles);
                js.ExecuteScript("document.body.style.zoom = '0.30'");


                List<string> VehicleType = new List<string>(new string[] { });
                VehicleType = vehicleType();
                List<string> Trucks = new List<string>(new string[] { VehicleType[0], Xpath.HeavyTab, Value.HeavyTab });
                List<string> Daily = new List<string>(new string[] { VehicleType[1], Xpath.LightTab, Value.LightTab });
                List<string> HeavyBus = new List<string>(new string[] { VehicleType[2], Xpath.HeavyBusTab, Value.HeavyBusTab });
                List<string> Tway = new List<string>(new string[] { VehicleType[3], Xpath.TwayTab, Value.TwayTab });

                List<List<string>> Vehicles = new List<List<string>>(new List<string>[] { Trucks, Daily, HeavyBus, Tway });
                foreach (List<string> Data in Vehicles)
                {
                //Verify the presence of Tab
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[1])));
                Assert.That(driver.FindElement(By.XPath(Data[1])).Text, Is.EqualTo(Data[2]));
                Console.WriteLine("Verified presence of "+ Data[0] + " Tab");

                //Click on Tab
                IWebElement TabButton = driver.FindElement(By.XPath(Data[1]));
                js.ExecuteScript("arguments[0].click();", TabButton);
                Console.WriteLine("Open "+ Data[0] + " Tab");
                System.Threading.Thread.Sleep(1000);
                //Verify the presence of Add vehicle button
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.AddVehicles)));
                Console.WriteLine("Verified presence of Add vehicle button");

                //Click on Add vehicle button
                IWebElement AddVehiclesButton = driver.FindElement(By.XPath(Xpath.AddVehicles));
                js.ExecuteScript("arguments[0].click();", AddVehiclesButton);
                Console.WriteLine("Click on Add vehicle button");
                System.Threading.Thread.Sleep(6000);

                //Verify the presence of Market
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Market)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.Market)).Text, Is.EqualTo(Value.Market));
                Console.WriteLine("Verified presence of Market");
                
                //Verify the presence of Company Name
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CompanyName)));
                Assert.That(driver.FindElement(By.XPath(Xpath.CompanyName)).Text, Is.EqualTo(Value.CompanyName));
                Console.WriteLine("Verified presence of Company Name");
               
                //Verify the presence of SAP code
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.SapCode)));
                Assert.That(driver.FindElement(By.XPath(Xpath.SapCode)).Text, Is.EqualTo(Value.SapCode));
                Console.WriteLine("Verified presence of SapCode");

                //Verify the presence of Vin code
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VINCode)));
                Assert.That(driver.FindElement(By.XPath(Xpath.VINCode)).Text, Is.EqualTo(Value.VINCode));
                Console.WriteLine("Verified presence of VIN Code");

                //Verify the presence of Vehicle Name
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleName)));
                Assert.That(driver.FindElement(By.XPath(Xpath.VehicleName)).Text, Is.EqualTo(Value.VehicleName));
                Console.WriteLine("Verified presence of Vehicle Name");
       
                //Verify the presence of Model
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Model)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Model)).Text, Is.EqualTo(Value.Model));
                Console.WriteLine("Verified presence of Model");
                
                //Verify the presence of Fuel
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Fuel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Fuel)).Text, Is.EqualTo(Value.Fuel));
                Console.WriteLine("Verified presence of Fuel");

                //Verify the presence of ServiceEndDate
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ServiceEndDate)));
                Assert.That(driver.FindElement(By.XPath(Xpath.ServiceEndDate)).Text, Is.EqualTo(Value.ServiceEndDate));
                Console.WriteLine("Verified presence of ServiceEndDate");
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