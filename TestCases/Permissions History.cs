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
    public class Permissions_Section_History : BaseClass
    {
        public void PermissionsSectionHistory(Xpath__Permissions Xpath, Values__Permissions Value)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                js.ExecuteScript("document.body.style.zoom = '0.30'");

                // Verify the presence of menu
                AssertElementIsEqualTo(Xpath.Menu, Value.Menu);

                //Click on Menu + Permissions section + Permission
                OpenSecondSectionMenu(Xpath.Menu, Xpath.Permissions, Value.Permissions, Xpath.Permissions2, Value.Permissions2, 1000);

                //Verify the presence of Account
                AssertElementIsEqualTo(Xpath.Account, Value.Account);

                //Click on Details
                JSClickDropdownChoice(Xpath.Details, Value.Details, 2000);

                //Verify the presence of Assign Permission
                AssertElementIsEqualTo(Xpath.AssignPermission, Value.AssignPermission);

                List<string> VehicleType = new List<string>(new string[] { });
                VehicleType = vehicleType();
                List<string> Trucks = new List<string>(new string[] { VehicleType[0], Xpath.HeavyTab, Value.HeavyTab });
                List<string> Daily = new List<string>(new string[] { VehicleType[1], Xpath.LightTab, Value.LightTab });
                List<string> HeavyBus = new List<string>(new string[] { VehicleType[2], Xpath.HeavyBusTab, Value.HeavyBusTab });
                List<string> Tway = new List<string>(new string[] { VehicleType[3], Xpath.TwayTab, Value.TwayTab });
                List<List<string>> Vehicles = new List<List<string>>(new List<string>[] { Trucks, Daily, HeavyBus, Tway });

                foreach (List<string> Data in Vehicles)
                {
                    //Click on History
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Data[1])));
                    Assert.That(driver.FindElement(By.XPath(Data[1])).Text, Is.EqualTo(Data[2]));
                    Console.WriteLine("Verified presence of " + Data[0] + " Tab");

                    //Click on History
                    JSClickDropdownChoice(Xpath.History, Value.History, 2000);

                    //Verify the presence of Assign Permission
                    AssertElementIsEqualTo(Xpath.PermissionHistory, Value.PermissionHistory);

                    //Verify the presence of VIN
                    AssertElementIsEqualTo(Xpath.VinHistory, Value.VIN);

                    //Verify the presence of Alias
                    AssertElementIsEqualTo(Xpath.AliasHistory, Value.AliasHistory);

                    //Verify the presence of Account
                    AssertElementIsEqualTo(Xpath.AccountHistory, Value.AccountHistory);

                    //Verify the presence of ServiceType
                    AssertElementIsEqualTo(Xpath.ServiceTypeHistory, Value.ServiceTypeHistory);

                    //Verify the presence of Status
                    AssertElementIsEqualTo(Xpath.StatusHistory, Value.StatusHistory);

                    //Verify the presence of StartDate
                    AssertElementIsEqualTo(Xpath.StartDateHistory, Value.StartDateHistory);

                    //Verify the presence of EndDate
                    AssertElementIsEqualTo(Xpath.EndDateHistory, Value.EndDateHistory);

                    //Verify the presence of Export Data
                    AssertElementIsEqualTo(Xpath.ExportData, Value.ExportData);

                    //Click on Details
                    JSClickDropdownChoice(Xpath.Back, Value.Back, 2000);

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