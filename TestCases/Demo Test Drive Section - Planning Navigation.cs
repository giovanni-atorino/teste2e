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
    public class Demo_Test_Drive_Section_Planning_Navigation : BaseClass
    {
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public Demo_Test_Drive_Section_Planning_Navigation(Account Account) : base(Account)
        {

        }
        public void DemoTestDriveSectionPlanningNavigation(Xpath__DemoTestDrive Xpath, Values__DemoTestDrive Value)

        {
            try
            { 
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            
                js.ExecuteScript("document.body.style.zoom = '0.30'");


                //Open Menu + Click on Demo Test Drive + Click on Planning
                OpenSecondSectionMenu(Xpath.Menu, Xpath.DemoTestDrive, Value.DemoTestDrive, Xpath.Planning, Value.Planning, 1000);

                RefreshCheck(Xpath.month);
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
                //Verify the presence of  Tab
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[1])));
                Assert.That(driver.FindElement(By.XPath(Data[1])).Text, Is.EqualTo(Data[2]));
                Console.WriteLine("Verified presence of "+ Data[0] + " Tab");

                //Click on Tab
                IWebElement TabButton = driver.FindElement(By.XPath(Data[1]));
                js.ExecuteScript("arguments[0].click();", TabButton);
                Console.WriteLine("Open "+ Data[0] + " Tab");
                System.Threading.Thread.Sleep(1000);

                Calendar(Xpath, Value);
                }
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);

            }


         driver.Close();
        }

        public void Calendar(Xpath__DemoTestDrive Xpath, Values__DemoTestDrive Value)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //Verify the presence of monthly visualization for calendar
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.month)));
            Assert.That(driver.FindElement(By.XPath(Xpath.month)).Text, Is.EqualTo(Value.month));
            Console.WriteLine("Verify the presence of monthly visualization for calendar");

            //Verify the presence of weekly visualization for calendar
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.week)));
            Assert.That(driver.FindElement(By.XPath(Xpath.week)).Text, Is.EqualTo(Value.week));
            Console.WriteLine("Verify the presence of weekly visualization for calendar");

            //Click on weekly visualization for calendar
            IWebElement WeeklyButton1 = driver.FindElement(By.XPath(Xpath.week));
            js.ExecuteScript("arguments[0].click();", WeeklyButton1);
            Console.WriteLine("Open weekly Tab");
            System.Threading.Thread.Sleep(1000);

            //Verify the presence of dayly visualization for calendar
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.day)));
            Assert.That(driver.FindElement(By.XPath(Xpath.day)).Text, Is.EqualTo(Value.day));
            Console.WriteLine("Verify the presence of dayly visualization for calendar");

            //Click on dayly visualization for calendar
            IWebElement daylyButton1 = driver.FindElement(By.XPath(Xpath.day));
            js.ExecuteScript("arguments[0].click();", daylyButton1);
            Console.WriteLine("Open dayly Tab");
            System.Threading.Thread.Sleep(1000);

            //Verify the presence of Demo test drive List 
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.List)));
            Assert.That(driver.FindElement(By.XPath(Xpath.List)).Text, Is.EqualTo(Value.List));
            Console.WriteLine("Verify the presence Demo test drive List");

            //Click on List visualization for calendar
            IWebElement listButton1 = driver.FindElement(By.XPath(Xpath.List));
            js.ExecuteScript("arguments[0].click();", listButton1);
            Console.WriteLine("Open List Tab");
            System.Threading.Thread.Sleep(1000);

        }

    }
}