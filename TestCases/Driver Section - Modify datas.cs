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
    public class Driver_Section_Modify_Datas : Driver_Section_Add_Data
    {
        public void DriversSectionModifyDatas(Xpath__Drivers Xpath, Values__Drivers Value)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                // Verify the presence of menu
                AssertElementIsEqualTo(Xpath.Menu, "Menu");

                //Open Menu + click on Driver Section
                OpenSectionMenu(Xpath.Menu, Xpath.Drivers, Value.Drivers, 1000);

                // Verify the presence of Active drivers Tab
                AssertElementIsEqualTo(Xpath.ActiveDrivers, Value.ActiveDrivers);

                //Open Archived drivers
                JSFindElementAndClick(Xpath.ArchivedDrivers, Value.ArchivedDrivers, 2000);

                // Verify the presence of Active drivers Tab
                AssertElementIsEqualTo(Xpath.YourDriversArchived, Value.YourDriversArchived);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
    }
}