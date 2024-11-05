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

    public class Download_Download_Test : BaseClassNoHead
    {
        public void DownloadDownloadFlow(Xpath__Download Xpath, Values__Download Value)

        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                driver.Manage().Window.Maximize();
                js.ExecuteScript("document.body.style.zoom = '0.67'");
                System.Threading.Thread.Sleep(3000);

                //Open Menu + Click on Download
                OpenSectionMenu(Xpath.Menu, Xpath.Download, "Download section", 1000);

                //Verify the presence of Filter 
                AssertElementIsEqualTo(Xpath.Filters, Value.Filters);
                Console.WriteLine("Download section opened");

                //Download export file Heavy
                JSClickDropdownChoice(Xpath.ExportDataHeavy, "Export excel for Heavy", 5000);

                //Check presence of export file and delete it
                Console.WriteLine("Check if file is available in /Download section");
                bool exportFileExistHeavy = CheckFileDownloaded(Value.ExportName);
                Assert.That(exportFileExistHeavy == true);
                Console.WriteLine("Check completed");

                //Click on Light tab
                JSClickDropdownChoice(Xpath.LightTab, "Light tab", 1000);

                //Download export file Light
                JSClickDropdownChoice(Xpath.ExportDataLight, "Export excel for Light", 5000);

                //Check presence of export file and delete it
                Console.WriteLine("Check if file is available in /Download section");
                bool exportFileExistLight = CheckFileDownloaded(Value.ExportName);
                Assert.That(exportFileExistLight == true);
                Console.WriteLine("Check completed");

                //Click on HeavyBus tab
                JSClickDropdownChoice(Xpath.HeavyBusTab, "HeavyBus tab", 1000);

                //Download export file HeavyBus
                JSClickDropdownChoice(Xpath.ExportDataHeavyBus, "Export excel for HeavyBus", 5000);

                //Check presence of export file and delete it
                Console.WriteLine("Check if file is available in /Download section");
                bool exportFileExistHeavyBus = CheckFileDownloaded(Value.ExportName);
                Assert.That(exportFileExistHeavyBus == true);
                Console.WriteLine("Check completed");

                //Click on Tway tab
                JSClickDropdownChoice(Xpath.TwayTab, "Tway tab", 1000);

                //Download export file Light
                JSClickDropdownChoice(Xpath.ExportDataTway, "Export excel for Tway", 5000);

                //Check presence of export file and delete it
                Console.WriteLine("Check if file is available in /Download section");
                bool exportFileExistTway = CheckFileDownloaded(Value.ExportName);
                Assert.That(exportFileExistTway == true);
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
