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

    public class Driver_Download_Test : BaseClassNoHead
    {
      
        public void DriverDownloadFlow(Xpath__Drivers Xpath, Values__Drivers Value)

        {
            
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                // Verify the presence of menu
                AssertElementIsEqualTo(Xpath.Menu, Value.Menu);

                //Open Menu + Click on Drivers Section
                OpenSectionMenu(Xpath.Menu, Xpath.Drivers, Value.Drivers, 1000);

                DownloadExport(Xpath.ExportDataGreyButton, Xpath.ExportData);
                System.Threading.Thread.Sleep(20000);

                // Check presence of export file and delete it
                Console.WriteLine("Check if file is availbale in /Download section");
                bool exportFileExist = CheckFileDownloaded(Value.ExportName);
                Assert.That(exportFileExist == true);
                Console.WriteLine("Check completed");
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }

            driver.Close();
        }
    }
}
