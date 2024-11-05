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
    public class Demo_Test_Drive_Section_Cards : BaseClass
    {
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public Demo_Test_Drive_Section_Cards(Account Account) : base(Account) { }
        public void DemoTestDriveSectionCards(Xpath__DemoTestDrive Xpath, Values__DemoTestDrive Value)
        {
            try
            {
                //Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                js.ExecuteScript("document.body.style.zoom = '0.30'");

                //Open Menu + Clicl on Demo Test Drive + Click on Vehicle fleet
                OpenSecondSectionMenu(Xpath.Menu, Xpath.DemoTestDrive, Value.DemoTestDrive, Xpath.VehicleFleet, Value.VehicleFleet, 1000);

                RefreshCheck(Xpath.VehicleDataTabOPENED);
                js.ExecuteScript("document.body.style.zoom = '0.30'");

                List<string> VehicleType = new List<string>(new string[] { });
                VehicleType = vehicleType();
                List<string> Trucks = new List<string>(new string[] { VehicleType[0], Xpath.HeavyTab, Value.HeavyTab });
                List<string> Daily = new List<string>(new string[] { VehicleType[1], Xpath.LightTab, Value.LightTab });
                List<string> HeavyBus = new List<string>(new string[] { VehicleType[2], Xpath.HeavyBusTab, Value.HeavyBusTab });
                List<string> Tway = new List<string>(new string[] { VehicleType[3], Xpath.TwayTab, Value.TwayTab });

                List<List<string>> Vehicles = new List<List<string>>(new List<string>[] { Trucks, Daily, HeavyBus, Tway });

                List<string> TotalCountFromVehicleFleet = new List<string>(new string[] { });
                List<string> TotalCountFromReport = new List<string>(new string[] { });

                int j = 0;

                foreach (List<string> Data in Vehicles)
                {
                    //Verify the presence of Tab
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[1])));
                    Assert.That(driver.FindElement(By.XPath(Data[1])).Text, Is.EqualTo(Data[2]));
                    Console.WriteLine("Verified presence of " + Data[0] + " Tab");

                    //Click on Tab
                    IWebElement TabButton = driver.FindElement(By.XPath(Data[1]));
                    js.ExecuteScript("arguments[0].click();", TabButton);
                    Console.WriteLine("Open " + Data[0] + " Tab");
                    if (weburl_runsettings == "https://www.iveco-on.com/")
                    {
                        System.Threading.Thread.Sleep(22000);
                        Console.WriteLine("Adding and en extra time in production where there are a lot of vins");
                    }

                    else
                    {
                        System.Threading.Thread.Sleep(3000);
                    }
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.TotalCountDemoON)));
                    String TotalCountBeforeFilter = driver.FindElement(By.XPath(Xpath.TotalCountDemoON)).Text;
                    Console.WriteLine("There are " + TotalCountBeforeFilter + " vehicles in total");

                    if (TotalCountBeforeFilter != "0")
                    {
                        //Click on Status Filter icon
                        JSClickDropdownChoice(Xpath.FilterStatusIcon, "Filter Status Icon", 2000);

                        //Click on Demo On Selection
                        JSClickDropdownChoice(Xpath.DemoONSelection, "Filter for Demo ON", 2000);

                        //Get count of demo on vehicles from table
                        //string TotalCountFromVehicleFleet = RetrieveAttribute(Xpath.TotalCountDemoON);
                        wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.TotalCountDemoON)));
                        String TotalCount = driver.FindElement(By.XPath(Xpath.TotalCountDemoON)).Text;
                        Console.WriteLine("Attribute = " + TotalCount);
                        TotalCountFromVehicleFleet.Add(TotalCount);
                        System.Threading.Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.WriteLine("There are no rows to show in " + Data[0] + " Tab");
                        TotalCountFromVehicleFleet.Add("0");
                    }
                    Console.WriteLine("Total count from Vehicle Fleet for " + Data[0] + " = " + TotalCountFromVehicleFleet[j]);
                    j++;
                }

                //Open Menu + Click on Demo Test Drive + Click on Report
                OpenSecondSectionMenu(Xpath.Menu, Xpath.DemoTestDrive, Value.DemoTestDrive, Xpath.Report, Value.Report, 1000);

                int i = 0;

                foreach (List<string> Data in Vehicles)
                {
                    //Verify the presence of Tab and click on it
                    JSFindElementAndClick(Data[1], Data[2],1000);

                        //Get value from demo diesel card
                        wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DemosDieselCount)));
                        String DieselCount = driver.FindElement(By.XPath(Xpath.DemosDieselCount)).Text;
                        int DieselCountInt = Int32.Parse(DieselCount);
                        System.Threading.Thread.Sleep(1000);

                        //Get value from demo gas card
                        wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DemosGasCount)));
                        String NPCount = driver.FindElement(By.XPath(Xpath.DemosGasCount)).Text;
                        int NPCountInt = Int32.Parse(NPCount);
                        System.Threading.Thread.Sleep(1000);
                        
                        int totalCountFromReport;

                        if (Data[0].Equals(VehicleType[1]) || Data[0].Equals(VehicleType[2]))  //case light and heavybus with electric card
                        {
                        //Get value from demo electric card
                        wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DemoElectricCount)));
                        String ElectricCount = driver.FindElement(By.XPath(Xpath.DemoElectricCount)).Text;
                        int ElectricCountInt = Int32.Parse(ElectricCount);
                        System.Threading.Thread.Sleep(1000);

                        //Add the sum total to TotalCountFromReport
                        totalCountFromReport = DieselCountInt + NPCountInt + ElectricCountInt;
                        Console.WriteLine("Total count from Report for " + Data[0] + " = " + totalCountFromReport);
                        }
                        else //case truck and tway 
                        {
                        totalCountFromReport = DieselCountInt + NPCountInt;
                        Console.WriteLine("Total count from Report for " + Data[0] + " = " + totalCountFromReport);
                    }
                    {


                        if (Int32.Parse(TotalCountFromVehicleFleet[i]) <= totalCountFromReport)
                        {
                            Console.WriteLine("Verified numbers on Report cards: the total number of vin in report section (" + totalCountFromReport + ") are at least equal or higer than the vin in demo on status  (" + TotalCountFromVehicleFleet[i] + ")");
                        }
                        else
                        {
                            Console.WriteLine("The totals from Vehicle Fleet and Report are not correct");
                            Assert.Fail("Test failed. See test output and attachment for analysis");
                        }

                        i++;
                    }

            
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
