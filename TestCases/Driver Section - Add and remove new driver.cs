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
    public class Driver_AddRemoveNewDriver: BaseClass
    {
        public void DriversAddRemoveNewDriver(Xpath__Drivers Xpath, Values__Drivers Value)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                // Verify the presence of menu
                AssertElementIsEqualTo(Xpath.Menu, Value.Menu);
                Console.WriteLine("Verified presence of Menu");

                //Open Menu + Click on Drivers
                OpenSectionMenu(Xpath.Menu, Xpath.Drivers, Value.Drivers, 1000);

                // Verify the presence of Active drivers Tab
                AssertElementIsEqualTo(Xpath.ActiveDrivers, Value.ActiveDrivers);
                Console.WriteLine("Verified presence of Active Drivers Tab");

                //Open Archived drivers
                JSClickDropdownChoice(Xpath.ArchivedDrivers, Value.ActiveDrivers, 2000);
                Console.WriteLine("Open Archived drivers Tab");

                // Verify the presence of Active drivers Tab
                AssertElementIsEqualTo(Xpath.YourDriversArchived, Value.YourDriversArchived);
                Console.WriteLine("Verified presence of Drivers section");
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
    }
 }