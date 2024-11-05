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
    public class Demo_Test_Drive_Section_Vehicle_Fleet: BaseClass
    {
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public Demo_Test_Drive_Section_Vehicle_Fleet(Account Account) : base(Account)
        {

        }
        public void DemoTestDriveSectionVehicleFleet(Xpath__DemoTestDrive Xpath, Values__DemoTestDrive Value)

        {
            try
            { 
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //Open Menu + Click on Demo Test Drive + Click on Vehicle Fleet
                OpenSecondSectionMenu(Xpath.Menu, Xpath.DemoTestDrive, Value.DemoTestDrive, Xpath.VehicleFleet, Value.VehicleFleet, 1000);

                RefreshCheck(Xpath.VehicleDataTabOPENED);
                js.ExecuteScript("document.body.style.zoom = '0.30'");

                List<string> VehicleType = new List<string>(new string[] { });
                VehicleType = vehicleType();
                List<string> Trucks = new List<string>(new string[] { VehicleType[0], Xpath.HeavyTab, Value.HeavyTab});
                List<string> Daily = new List<string>(new string[]  { VehicleType[1], Xpath.LightTab, Value.LightTab });
                List<string> HeavyBus = new List<string>(new string[] { VehicleType[2], Xpath.HeavyBusTab, Value.HeavyBusTab });
                List<string> Tway = new List<string>(new string[]   { VehicleType[3], Xpath.TwayTab, Value.TwayTab });

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

                //Verify the presence of Vehicle Data Tab
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleDataTabOPENED)));
                Console.WriteLine("Verified presence of Vehicle Data Tab contracted");

                //Click on Vehicle Data Tab
                IWebElement VehicleDataTabOPENEDButton = driver.FindElement(By.XPath(Xpath.VehicleDataTabOPENED));
                js.ExecuteScript("arguments[0].click();", VehicleDataTabOPENEDButton);
                Console.WriteLine("Open Vehicle Data Tab");
                System.Threading.Thread.Sleep(1000);

                //Verify the presence of VIN code
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VINCode)));
                System.Threading.Thread.Sleep(1000);
                Assert.That(driver.FindElement(By.XPath(Xpath.VINCode)).Text, Is.EqualTo(Value.VINCode));
                Console.WriteLine("Verified presence of VIN Code");

                //Verify the presence of VehicleName
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleName)));
                System.Threading.Thread.Sleep(1000);
                Assert.That(driver.FindElement(By.XPath(Xpath.VehicleName)).Text, Is.EqualTo(Value.VehicleName));
                Console.WriteLine("Verified presence of Vehicle Name");

                //Verify the presence of Model
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Model)));
                System.Threading.Thread.Sleep(1000);
                Assert.That(driver.FindElement(By.XPath(Xpath.Model)).Text, Is.EqualTo(Value.Model));
                Console.WriteLine("Verified presence of Model");

                //Verify the presence of Fuel
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Fuel)));
                System.Threading.Thread.Sleep(1000);
                Assert.That(driver.FindElement(By.XPath(Xpath.Fuel)).Text, Is.EqualTo(Value.Fuel));
                Console.WriteLine("Verified presence of Fuel");

                //Verify the presence of DemoOnDate
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DemoOnDate)));
                System.Threading.Thread.Sleep(1000);
                Assert.That(driver.FindElement(By.XPath(Xpath.DemoOnDate)).Text, Is.EqualTo(Value.DemoOnDate));
                Console.WriteLine("Verified presence of DemoOnDate");

                //Verify the presence of DemoOffDate
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DemoOffDate)));
                System.Threading.Thread.Sleep(1000);
                Assert.That(driver.FindElement(By.XPath(Xpath.DemoOffDate)).Text, Is.EqualTo(Value.DemoOffDate));
                Console.WriteLine("Verified presence of DemoOffDate");

                //Verify the presence of WarrantyStartDate
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.WarrantyStartDate)));
                System.Threading.Thread.Sleep(1000);
                Assert.That(driver.FindElement(By.XPath(Xpath.WarrantyStartDate)).Text, Is.EqualTo(Value.WarrantyStartDate));
                Console.WriteLine("Verified presence of WarrantyStartDate");

                //Verify the presence of Demo Expire (dd)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DemoExpire)));
                System.Threading.Thread.Sleep(1000);
                Assert.That(driver.FindElement(By.XPath(Xpath.DemoExpire)).Text, Is.EqualTo(Value.Deadline));
                Console.WriteLine("Verified presence of  Demo Expire (dd)");

                //Verify the presence of Vehicle Data Tab
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleDataTabCLOSED)));
                Console.WriteLine("Verified presence of Vehicle Data Tab expanded");

                //Click on Vehicle Data Tab
                IWebElement VehicleDataTabCLOSEDButton = driver.FindElement(By.XPath(Xpath.VehicleDataTabCLOSED));
                js.ExecuteScript("arguments[0].click();", VehicleDataTabCLOSEDButton);
                Console.WriteLine("Open Vehicle Data Tab");
                System.Threading.Thread.Sleep(1000);

                //Verify the presence of Company Data Tab
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CompanyDataTabOPENED)));
                Console.WriteLine("Verified presence of Company Data Tab contracted");

                //Click on Company Data Tab
                IWebElement CompanyDataTabOPENEDButton = driver.FindElement(By.XPath(Xpath.CompanyDataTabOPENED));
                js.ExecuteScript("arguments[0].click();", CompanyDataTabOPENEDButton);
                Console.WriteLine("Open Company Data Tab");
                System.Threading.Thread.Sleep(2000);

                //Verify the presence of Market
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Market)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.Market)).Text, Is.EqualTo(Value.Market));
                Console.WriteLine("Verified presence of Market");

                //Verify the presence of Market/Dealer
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.MarketNetwork)));
                Assert.That(driver.FindElement(By.XPath(Xpath.MarketNetwork)).Text, Is.EqualTo(Value.MarketNetwork));
                Console.WriteLine("Verified presence of Market/Network");

                //Verify the presence of CompanyName
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CompanyName)));
                Assert.That(driver.FindElement(By.XPath(Xpath.CompanyName)).Text, Is.EqualTo(Value.CompanyName));
                Console.WriteLine("Verified presence of CompanyName");

                //Verify the presence of SapCode
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.SapCode)));
                Assert.That(driver.FindElement(By.XPath(Xpath.SapCode)).Text, Is.EqualTo(Value.SapCode));
                Console.WriteLine("Verified presence of SapCode");

                //Verify the presence of Status
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Status)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Status)).Text, Is.EqualTo(Value.Status));
                Console.WriteLine("Verified presence of Status");
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