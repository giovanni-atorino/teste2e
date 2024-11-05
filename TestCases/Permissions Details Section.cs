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
    public class Permissions_Details_Section: BaseClass
    {
        public void PermissionsDetailsSection(Xpath__Permissions Xpath, Values__Permissions Value)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            
                js.ExecuteScript("document.body.style.zoom = '0.30'");

                // Verify the presence of menu
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Menu)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.Menu)).Text, Is.EqualTo(Value.Menu));
                Console.WriteLine("Verified presence of Menu");

                //Open Menu + click on Permission + click on Permission
                OpenSecondSectionMenu(Xpath.Menu, Xpath.Permissions, Value.Permissions, Xpath.Permissions2, Value.Permissions2, 1000);

                //Click on details section
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Details)));
                IWebElement DetailsButton = driver.FindElement(By.XPath(Xpath.Details));
                js.ExecuteScript("arguments[0].click();", DetailsButton);
                Console.WriteLine("Opened Detail section");
                System.Threading.Thread.Sleep(2000);
                js.ExecuteScript("document.body.style.zoom = '0.35'");

                List<string> VehicleType = new List<string>(new string[] { });
                VehicleType = vehicleType();
                List<string> Trucks = new List<string>(new string[] { VehicleType[0], Xpath.HeavyTab, Value.HeavyTab , Xpath.VINHeavy, Xpath.AliasHeavy, Xpath.ContractReferenceHeavy, Xpath.OverTheAirUpdateHeavyOPENED,Xpath.TypeHeavy, Xpath.GivenByHeavy, Xpath.WhenHeavy , Xpath.OverTheAirUpdateHeavyCLOSED ,Xpath.EWAHeavyOPENED , Xpath.EWAHeavyCLOSED, Xpath.SFMHeavyOPENED , Xpath.ActionsHeavy });
                List<string> Daily = new List<string>(new string[] { VehicleType[1], Xpath.LightTab, Value.LightTab, Xpath.VINLight, Xpath.AliasLight, Xpath.ContractReferenceLight, Xpath.OverTheAirUpdateLightOPENED, Xpath.TypeLight, Xpath.GivenByLight, Xpath.WhenLight, Xpath.OverTheAirUpdateLightCLOSED, "", "", Xpath.SFMLightOPENED, Xpath.ActionsLight });
                List<string> HeavyBus = new List<string>(new string[] { VehicleType[2], Xpath.HeavyBusTab, Value.HeavyBusTab, Xpath.VINHeavyBus, Xpath.AliasHeavyBus, Xpath.ContractReferenceHeavyBus, Xpath.OverTheAirUpdateHeavyBusOPENED, Xpath.TypeHeavyBus, Xpath.GivenByHeavyBus, Xpath.WhenHeavyBus, Xpath.OverTheAirUpdateHeavyBusCLOSED, "", "", Xpath.SFMHeavyBusOPENED, Xpath.ActionsHeavyBus });
                List<string> Tway = new List<string>(new string[] { VehicleType[3], Xpath.TwayTab, Value.TwayTab,    Xpath.VINTway, Xpath.AliasTway, Xpath.ContractReferenceTway, Xpath.OverTheAirUpdateTwayOPENED, Xpath.TypeTway, Xpath.GivenByTway, Xpath.WhenTway, Xpath.OverTheAirUpdateTwayCLOSED, Xpath.EWATwayOPENED, Xpath.EWATwayCLOSED, Xpath.SFMTwayOPENED, Xpath.ActionsTway });
                List<List<string>> Vehicles = new List<List<string>>(new List<string>[] { Trucks, Daily, HeavyBus, Tway });

                foreach (List<string> Data in Vehicles)
                {
                //Click on  tab
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[1])));
                IWebElement TabButton = driver.FindElement(By.XPath(Data[1]));
                js.ExecuteScript("arguments[0].click();", TabButton);
                Console.WriteLine("Click on "+ Data[0] + " tab");
                System.Threading.Thread.Sleep(3000);

                //Verify the presence of VIN
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[3])));
                Assert.That(driver.FindElement(By.XPath(Data[3])).Text, Is.EqualTo(Value.VIN));
                Console.WriteLine("Verified presence of VIN");

                //Verify the presence of Alias
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[4])));
                Assert.That(driver.FindElement(By.XPath(Data[4])).Text, Is.EqualTo(Value.Alias));
                Console.WriteLine("Verified presence of Alias");

                //Verify the presence of Contract Reference
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[5])));
                Assert.That(driver.FindElement(By.XPath(Data[5])).Text, Is.EqualTo(Value.ContractReference));
                Console.WriteLine("Verified presence of Contract Reference");

                //Open Over the Air update column
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[6])));
                IWebElement OverTheAirUpdateButtonOPENED = driver.FindElement(By.XPath(Data[6]));
                js.ExecuteScript("arguments[0].click();", OverTheAirUpdateButtonOPENED);
                Console.WriteLine("Over the Air update column opened for "+ Data[0]);
                System.Threading.Thread.Sleep(1000);

                //Verify the presence of Type in Over the air update section
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[7])));
                Assert.That(driver.FindElement(By.XPath(Data[7])).Text, Is.EqualTo(Value.Type));
                Console.WriteLine("Verified presence of Type in Over The Air Update for "+ Data[0]);
                
                //Verify the presence of Given by in Over the air update section
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[8])));
                Assert.That(driver.FindElement(By.XPath(Data[8])).Text, Is.EqualTo(Value.GivenBy));
                Console.WriteLine("Verified presence of Given by in Over The Air Update for " + Data[0]);

                //Verify the presence of When in Over the air update section
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[9])));
                Assert.That(driver.FindElement(By.XPath(Data[9])).Text, Is.EqualTo(Value.When));
                Console.WriteLine("Verified presence of Type in Over The Air Update for " + Data[0]);

                //Close over the air update column
                IWebElement OverTheAirUpdateButtonCLOSED = driver.FindElement(By.XPath(Data[10]));
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[10])));
                js.ExecuteScript("arguments[0].click();", OverTheAirUpdateButtonCLOSED);
                Console.WriteLine("Over the Air update column closed  for " + Data[0]);
                System.Threading.Thread.Sleep(1000);

                if (Data[0]=="Trucks" || Data[0] == "T-Way")
                {

                //Open EasyWayApp column
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[11])));
                IWebElement EWAButton = driver.FindElement(By.XPath(Data[11]));
                js.ExecuteScript("arguments[0].click();", EWAButton);
                Console.WriteLine("EWA column opened for " + Data[0]);
                System.Threading.Thread.Sleep(1000);
                

                //Verify the presence of Type in EasyWayApp section
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[7])));
                Assert.That(driver.FindElement(By.XPath(Data[7])).Text, Is.EqualTo(Value.Type));
                Console.WriteLine("Verified presence of Type in EasyWayApp section");

                //Verify the presence of Given by in EasyWayApp section
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[8])));
                //Assert.That(driver.FindElement(By.XPath(Xpath.GivenByHeavy)).Text, Is.EqualTo(Value.GivenBy));
                Console.WriteLine("Verified presence of Given by in EasyWayApp section");

               
                //Verify the presence of When in EasyWayApp section
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[9])));
                Assert.That(driver.FindElement(By.XPath(Data[9])).Text, Is.EqualTo(Value.When));
                Console.WriteLine("Verified presence of Type in EasyWayApp section");

                //Close EWA column
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[12])));
                IWebElement EWAButtonCLOSED = driver.FindElement(By.XPath(Data[12]));
                js.ExecuteScript("arguments[0].click();", EWAButtonCLOSED);
                Console.WriteLine("EWA column closed for "+ Data[0]);
                System.Threading.Thread.Sleep(1000);
                }
                else
                {
                   Console.WriteLine("For Daily and HeavyBus tabs EWA columns are not present");
                }
            

                //Open SFM column
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[13])));
                IWebElement SFMOPENEDButton = driver.FindElement(By.XPath(Data[13]));
                js.ExecuteScript("arguments[0].click();", SFMOPENEDButton);
                Console.WriteLine("SFM column opened for "+Data[0]);
                System.Threading.Thread.Sleep(1000);

                //Verify the presence of SFM section
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[7])));
                Assert.That(driver.FindElement(By.XPath(Data[7])).Text, Is.EqualTo(Value.Type));
                Console.WriteLine("Verified presence of Type in Secondary Fleet Manager section for " + Data[0]);

                //Verify the presence of SFM section
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[8])));
                Assert.That(driver.FindElement(By.XPath(Data[8])).Text, Is.EqualTo(Value.GivenBy));
                Console.WriteLine("Verified presence of Given by in Secondary Fleet Manager sectionfor " + Data[0]);

                //Verify the presence of When in SFM section
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[9])));
                Assert.That(driver.FindElement(By.XPath(Data[9])).Text, Is.EqualTo(Value.When));
                Console.WriteLine("Verified presence of Type in Secondary Fleet Manager section for " + Data[0]);

                //Verify the presence of Actions
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[14])));
                Assert.That(driver.FindElement(By.XPath(Data[14])).Text, Is.EqualTo(Value.Actions));
                Console.WriteLine("Verified presence of Actions for " + Data[0]);
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