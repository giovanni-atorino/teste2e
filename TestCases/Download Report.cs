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
    public class Download_Report: BaseClass
    {
        public void DownloadReport(Xpath__Download Xpath, Values__Download Value)

        {
            try
            {
            // Wait definition for element
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Verify the presence of menu
            AssertElementIsEqualTo(Xpath.Menu, Value.Menu);

            //Open Menu + Click on Download
            OpenSectionMenu(Xpath.Menu, Xpath.Download, "Download", 1000);

            // Verify the presence of Heavy tab
            AssertElementIsEqualTo(Xpath.HeavyTab, Value.Trucks);

            //Download one report for heavy vehicle

            // Verify the presence of Light tab
            AssertElementIsEqualTo(Xpath.LightTab, Value.Daily);

            //Click on Light tab
            JSClickDropdownChoice(Xpath.LightTab, Value.Daily, 2000);

            //Download one report for light vehicle
             }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }

             driver.Close();
        }

        
    }
}