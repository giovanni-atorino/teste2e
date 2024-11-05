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
    public class Demo_Test_Drive_Section_Report: BaseClass
    {
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public Demo_Test_Drive_Section_Report(Account Account) : base(Account) {}
        public void DemoTestDriveSectionReport(Xpath__DemoTestDrive Xpath, Values__DemoTestDrive Value)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                js.ExecuteScript("document.body.style.zoom = '0.30'");

                //Open Menu + Click on Demo Test Drive + Click on Recaller
                OpenSecondSectionMenu(Xpath.Menu, Xpath.DemoTestDrive, Value.DemoTestDrive, Xpath.Report, Value.Report, 1000);

                RefreshCheck(Xpath.DemoDieselCardHeavy);
                js.ExecuteScript("document.body.style.zoom = '0.30'");

                List<string> VehicleType = new List<string>(new string[] { });
                VehicleType = vehicleType();
                List<string> Trucks = new List<string>(new string[] { VehicleType[0], Xpath.HeavyTab, Value.HeavyTab , Xpath.DemoDieselCardHeavy, Value.DemoDieselCard, Xpath.DemoTestDriveDieselHeavy, Value.DemoTestDriveDiesel, Xpath.AverageDistanceTestDriveDieselHeavy, Value.AverageDistanceTestDriveDiesel, Xpath.AverageTimeTestDriveDieselHeavy, Value.AverageTimeTestDriveDiesel , Xpath.DemosGasHeavy , Value.DemosGas , Xpath.DemoTestDriveGasHeavy  , Value.DemoTestDriveGas, Xpath.AverageDistanceTestDriveGasHeavy , Value.AverageDistanceTestDriveGas, Xpath.AverageTimeDriveGasHeavy, Value.AverageTimeDriveGas });
                List<string> Daily = new List<string>(new string[] { VehicleType[1], Xpath.LightTab, Value.LightTab , Xpath.DemoDieselCardLight, Value.DemoDieselCard, Xpath.DemoTestDriveDieselLight, Value.DemoTestDriveDiesel, Xpath.AverageDistanceTestDriveDieselLight, Value.AverageDistanceTestDriveDiesel, Xpath.AverageTimeTestDriveDieselLight, Value.AverageTimeTestDriveDiesel, Xpath.DemosGasLight, Value.DemosGas, Xpath.DemoTestDriveGasLight, Value.DemoTestDriveGas, Xpath.AverageDistanceTestDriveGasLight, Value.AverageDistanceTestDriveGas, Xpath.AverageTimeDriveGasLight, Value.AverageTimeDriveGas });
                List<string> HeavyBus = new List<string>(new string[] { VehicleType[2], Xpath.HeavyBusTab, Value.HeavyBusTab, Xpath.DemoDieselCardHeavyBus, Value.DemoDieselCard, Xpath.DemoTestDriveDieselHeavyBus, Value.DemoTestDriveDiesel, Xpath.AverageDistanceTestDriveDieselHeavyBus, Value.AverageDistanceTestDriveDiesel, Xpath.AverageTimeTestDriveDieselHeavyBus, Value.AverageTimeTestDriveDiesel, Xpath.DemosGasHeavyBus, Value.DemosGas, Xpath.DemoTestDriveGasHeavyBus, Value.DemoTestDriveGas, Xpath.AverageDistanceTestDriveGasHeavyBus, Value.AverageDistanceTestDriveGas, Xpath.AverageTimeDriveGasHeavyBus, Value.AverageTimeDriveGas });
                List<string> Tway = new List<string>(new string[] { VehicleType[3], Xpath.TwayTab, Value.TwayTab, Xpath.DemoDieselCardTway, Value.DemoDieselCard, Xpath.DemoTestDriveDieselTway, Value.DemoTestDriveDiesel, Xpath.AverageDistanceTestDriveDieselTway, Value.AverageDistanceTestDriveDiesel, Xpath.AverageTimeTestDriveDieselTway, Value.AverageTimeTestDriveDiesel, Xpath.DemosGasTway, Value.DemosGas, Xpath.DemoTestDriveGasTway, Value.DemoTestDriveGas, Xpath.AverageDistanceTestDriveGasTway, Value.AverageDistanceTestDriveGas, Xpath.AverageTimeDriveGasTway, Value.AverageTimeDriveGas });
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

                //Verify Card
                //Verify the presence of DemoDieselCard 
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[3])));
                Assert.That(driver.FindElement(By.XPath(Data[3])).Text, Is.EqualTo(Data[4]));
                Console.WriteLine("Verify the presence of Demo Diesel Card for "+Data[0]);

                //Verify the presence of Demo Test Drive Diesel 
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[5])));
                Assert.That(driver.FindElement(By.XPath(Data[5])).Text, Is.EqualTo(Data[6]));
                Console.WriteLine("Verify the presence of Demo Test Drive Diesel for " + Data[0]);

                //Verify the presence of Average distance test drive Card
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[7])));
                Assert.That(driver.FindElement(By.XPath(Data[7])).Text, Is.EqualTo(Data[8]));
                Console.WriteLine("Verify the presence of Average distance test drive Card for " + Data[0]);

                //Verify the presence of Average distance test drive  Card
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[9])));
                Assert.That(driver.FindElement(By.XPath(Data[9])).Text, Is.EqualTo(Data[10]));
                Console.WriteLine("Verify the presence of Average distance test drive Card  for " + Data[0]);

                //Verify the presence of Demos gas Card
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[11])));
                Assert.That(driver.FindElement(By.XPath(Data[11])).Text, Is.EqualTo(Data[12]));
                Console.WriteLine("Verify the presence of Demos gas Card for " + Data[0]);

                //Verify the presence of Demos gas Card
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[13])));
                Assert.That(driver.FindElement(By.XPath(Data[13])).Text, Is.EqualTo(Data[14]));
                Console.WriteLine("Verify the presence of Demos  test driver gas card for " + Data[0]);

                //Verify the presence of Average distance drive gas card
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[15])));
                Assert.That(driver.FindElement(By.XPath(Data[15])).Text, Is.EqualTo(Data[16]));
                Console.WriteLine("Verify the presence of Average distance test drive gas card for " + Data[0]);

                //Verify the presence of Average time drive gas Card
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[17])));
                Assert.That(driver.FindElement(By.XPath(Data[17])).Text, Is.EqualTo(Data[18]));
                Console.WriteLine("Verify the presence of Average time  drive gas Card for " + Data[0]);

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
