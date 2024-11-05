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
    public class Demo_Test_Drive_Section_Planning: BaseClass
    {
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public Demo_Test_Drive_Section_Planning(Account Account) : base(Account)
        {

        }
        public void DemoTestDriveSectionPlanning(Xpath__DemoTestDrive Xpath, Values__DemoTestDrive Value)

        {


            try
            {

                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
           
                js.ExecuteScript("document.body.style.zoom = '0.30'");

                //Open Menu + Click on Demo Test Drive + Click on Planning
                OpenSecondSectionMenu(Xpath.Menu, Xpath.DemoTestDrive, Value.DemoTestDrive, Xpath.Planning, Value.Planning, 1000);

                /*driver.Navigate().GoToUrl(weburl_runsettings + "demo-test-drive/planning");
                Console.WriteLine("Navigating to: Planning of Demo test drive");
                System.Threading.Thread.Sleep(4000);
                js.ExecuteScript("document.body.style.zoom = '0.30'");*/

                RefreshCheck(Xpath.VIN);
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
                Console.WriteLine("Verified presence of "+Data[0]+" Tab");

                //Click on Tab
                IWebElement TabButton = driver.FindElement(By.XPath(Data[1]));
                js.ExecuteScript("arguments[0].click();", TabButton);
                Console.WriteLine("Open "+Data[0]+" Tab");
                System.Threading.Thread.Sleep(1000);

                //Verify On-going table
                OnGoingTable(Xpath, Value);

                //Verify List table
                ListTable(Xpath, Value);

                }
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);

            }

        driver.Close();
        }

        public void OnGoingTable(Xpath__DemoTestDrive Xpath, Values__DemoTestDrive Value)

        {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                //Verify the presence of VIN
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VIN)));
                Assert.That(driver.FindElement(By.XPath(Xpath.VIN)).Text, Is.EqualTo(Value.VIN));
                Console.WriteLine("Verify the presence of VIN");

                //Verify the presence of Vehicle name
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleName)));
                Assert.That(driver.FindElement(By.XPath(Xpath.VehicleName)).Text, Is.EqualTo(Value.VehicleName));
                Console.WriteLine("Verify the presence of Vehicle Name");

                //Verify the presence of Plate
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Plate)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Plate)).Text, Is.EqualTo(Value.Plate));
                Console.WriteLine("Verify the presence of Plate");

                //Verify the presence of Company
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Company)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Company)).Text, Is.EqualTo(Value.Company));
                Console.WriteLine("Verify the presence of Company");

                //Verify the presence of StartDate
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.StartDate)));
                Assert.That(driver.FindElement(By.XPath(Xpath.StartDate)).Text, Is.EqualTo(Value.StartDate));
                Console.WriteLine("Verify the presence of Start Date");
                
                //Verify the presence of EndDate
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.EndDate)));
                Assert.That(driver.FindElement(By.XPath(Xpath.EndDate)).Text, Is.EqualTo(Value.EndDate));
                Console.WriteLine("Verify the presence of End Date");

                //Verify the presence of Id
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Id)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Id)).Text, Is.EqualTo(Value.Id));
                Console.WriteLine("Verify the presence of Id");

                //Verify the presence of Status 
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Status)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Status)).Text, Is.EqualTo(Value.Status));
                Console.WriteLine("Verify the presence of Status");

                //Verify the presence of Duration
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Duration)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Duration)).Text, Is.EqualTo(Value.Duration));
                Console.WriteLine("Verify the presence of Duration");

                //Verify the presence of Action 
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Action)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Action)).Text, Is.EqualTo(Value.Action));
                Console.WriteLine("Verify the presence of Action");
        }
        public void ListTable(Xpath__DemoTestDrive Xpath, Values__DemoTestDrive Value)

        {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                //Verify the presence of Demo test drive List 
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.List)));
                Assert.That(driver.FindElement(By.XPath(Xpath.List)).Text, Is.EqualTo(Value.List));
                Console.WriteLine("Verify the presence Demo test drive List");

                //Click on List visualization for calendar
                IWebElement listButton1 = driver.FindElement(By.XPath(Xpath.List));
                js.ExecuteScript("arguments[0].click();", listButton1);
                Console.WriteLine("Open List Tab");
                System.Threading.Thread.Sleep(1000);

                //Open dealer Data tab
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DealerDataOPENED)));
                IWebElement DealerDataOPENEDButton = driver.FindElement(By.XPath(Xpath.DealerDataOPENED));
                js.ExecuteScript("arguments[0].click();", DealerDataOPENEDButton);
                Console.WriteLine("Open dealer Data tab");
                System.Threading.Thread.Sleep(1000);

                //Open customer Data tab
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CustomerDataOPENED)));
                IWebElement CustomerDataOPENEDButton = driver.FindElement(By.XPath(Xpath.CustomerDataOPENED));
                js.ExecuteScript("arguments[0].click();", CustomerDataOPENEDButton);
                Console.WriteLine("Open customer Data tab");
                System.Threading.Thread.Sleep(1000);

                //Open Vehicle Data tab
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleDataOPENED)));
                IWebElement VehicleDataOPENEDButton = driver.FindElement(By.XPath(Xpath.VehicleDataOPENED));
                js.ExecuteScript("arguments[0].click();", VehicleDataOPENEDButton);
                Console.WriteLine("Open Vehicle Data tab");
                System.Threading.Thread.Sleep(1000);

                //Open Data Creation tab
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DataCreationOPENED)));
                IWebElement DataCreationOPENEDButton = driver.FindElement(By.XPath(Xpath.DataCreationOPENED));
                js.ExecuteScript("arguments[0].click();", DataCreationOPENEDButton);
                Console.WriteLine("Open Vehicle Data tab");
                System.Threading.Thread.Sleep(1000);

                //Verify the presence of Id
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Id)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Id)).Text, Is.EqualTo(Value.Id));
                Console.WriteLine("Verified presence of Id");

                //Verify the presence of Name
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Name)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Name)).Text, Is.EqualTo(Value.Name));
                Console.WriteLine("Verified presence of Name");

                //Verify the presence of Surname
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Surname)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Surname)).Text, Is.EqualTo(Value.Surname));
                Console.WriteLine("Verified presence of Surname");

                //Verify the presence of company
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Company)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Company)).Text, Is.EqualTo(Value.Company));
                Console.WriteLine("Verified presence of Company");

                //Verify the presence of Email
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Email)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Email)).Text, Is.EqualTo(Value.Email));
                Console.WriteLine("Verified presence of Email");


                //Verify the presence of StartDate
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.StartDate)));
                Assert.That(driver.FindElement(By.XPath(Xpath.StartDate)).Text, Is.EqualTo(Value.StartDate));
                Console.WriteLine("Verified presence of StartDate");

                //Verify the presence of EndDate
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.EndDate)));
                Assert.That(driver.FindElement(By.XPath(Xpath.EndDate)).Text, Is.EqualTo(Value.EndDate));
                Console.WriteLine("Verified presence of EndDate");

                //Verify the presence of Status
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Status)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Status)).Text, Is.EqualTo(Value.Status));
                Console.WriteLine("Verified presence of Status");

                //Verify the presence of Vin
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VIN)));
                Assert.That(driver.FindElement(By.XPath(Xpath.VIN)).Text, Is.EqualTo(Value.VIN));
                Console.WriteLine("Verified presence of VIN");

                //Verify the presence of VehicleName
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleName)));
                Assert.That(driver.FindElement(By.XPath(Xpath.VehicleName)).Text, Is.EqualTo(Value.VehicleName));
                Console.WriteLine("Verified presence of VehicleName");

                //Verify the presence of Plate
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Plate)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Plate)).Text, Is.EqualTo(Value.Plate));
                Console.WriteLine("Verified presence of Plate");

                //Verify the presence of Model
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Model)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Model)).Text, Is.EqualTo(Value.Model));
                Console.WriteLine("Verified presence of Model");

                //Verify the presence of Fuel
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Fuel)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Fuel)).Text, Is.EqualTo(Value.Fuel));
                Console.WriteLine("Verified presence of Fuel");

                //Verify the presence of CreationDate
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CreationDate)));
                Assert.That(driver.FindElement(By.XPath(Xpath.CreationDate)).Text, Is.EqualTo(Value.CreationDate));
                Console.WriteLine("Verified presence of CreationDate");

                //Verify the presence of AccountUser
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.AccountUser)));
                Assert.That(driver.FindElement(By.XPath(Xpath.AccountUser)).Text, Is.EqualTo(Value.AccountUser));
                Console.WriteLine("Verified presence of AccountUser");
               
                //Verify the presence of AccountName
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.AccountName)));
                Assert.That(driver.FindElement(By.XPath(Xpath.AccountName)).Text, Is.EqualTo(Value.AccountName));
                Console.WriteLine("Verified presence of AccountName");
                
                //Verify the presence of Action
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Action)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Action)).Text, Is.EqualTo(Value.Action));
                Console.WriteLine("Verified presence of Action");
        }
    }
}