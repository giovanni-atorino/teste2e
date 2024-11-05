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
    public class Download_Section: BaseClass
    {

        public void DownloadSection(Xpath__Download Xpath, Values__Download Value)

        {   
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                driver.Manage().Window.Maximize();
                js.ExecuteScript("document.body.style.zoom = '0.67'");
                System.Threading.Thread.Sleep(3000);

                //Open Menu + Click on Download
                OpenSectionMenu(Xpath.Menu, Xpath.Download, Value.Download, 1000);

                //Verify the presence of Filter 
                AssertElementIsEqualTo(Xpath.Filters, Value.Filters);

                //Verify the presence of Heavy tab
                AssertElementIsEqualTo(Xpath.HeavyTab, Value.Trucks);

                //Verify the presence of Light tab
                AssertElementIsEqualTo(Xpath.LightTab, Value.Daily);

                //Verify the presence of HeavyBus tab
                AssertElementIsEqualTo(Xpath.HeavyBusTab, Value.HeavyBus);

                //Verify the presence of Tway tab
                AssertElementIsEqualTo(Xpath.TwayTab, Value.Tway);

                //Verify the presence of Start period tab
                AssertElementIsEqualTo(Xpath.StartPeriodHeavy, Value.StartPeriod);

                //Verify the presence of End period tab
                AssertElementIsEqualTo(Xpath.EndPeriodHeavy, Value.EndPeriod);

                //Verify the presence of Report type tab
                AssertElementIsEqualTo(Xpath.ReportTypeHeavy, Value.ReportType);

                //Verify the presence of frequency tab
                AssertElementIsEqualTo(Xpath.FrequencyHeavy, Value.Frequency);

                //Verify the presence of File Format tab
                AssertElementIsEqualTo(Xpath.FileFormatHeavy, Value.FileFormat);

                //Verify the presence of Action tab
                AssertElementIsEqualTo(Xpath.ActionHeavy, Value.Action);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }    
    }
}