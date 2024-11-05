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
    public class Download_Navigation: BaseClass
    {
        public void DownloadNavigation(Xpath__Download Xpath, Values__Download Value)

        {
            try
            {
                //Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //Open menu + Click on Download Section
                OpenSectionMenu(Xpath.Menu, Xpath.Download, Value.Download, 1000);

                //Verify the presence of Heavy tab
                AssertElementIsEqualTo(Xpath.HeavyTab, Value.Trucks);

                //Verify the presence of Light tab
                AssertElementIsEqualTo(Xpath.LightTab, Value.Daily);

                //Verify the presence of HeavyBus tab
                AssertElementIsEqualTo(Xpath.HeavyBusTab, Value.HeavyBus);

                //Verify the presence of Tway tab
                AssertElementIsEqualTo(Xpath.TwayTab, Value.Tway);

                //Click on Light tab
                JSClickDropdownChoice(Xpath.LightTab, "Daily Tab", 3000);

                //Verify the presence of Start period tab
                AssertElementIsEqualTo(Xpath.StartPeriodLight, Value.StartPeriod);

                //Verify the presence of End period tab
                AssertElementIsEqualTo(Xpath.EndPeriodLight, Value.EndPeriod);

                //Verify the presence of Report type tab
                AssertElementIsEqualTo(Xpath.ReportTypeLight, Value.ReportType);

                //Verify the presence of frequency tab
                AssertElementIsEqualTo(Xpath.FrequencyLight, Value.Frequency);

                //Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                //ss.SaveAsFile("C://Download.png", ScreenshotImageFormat.Png);

                //Verify the presence of File Format tab
                AssertElementIsEqualTo(Xpath.FileFormatLight, Value.FileFormat);

                //Verify the presence of Action tab
                AssertElementIsEqualTo(Xpath.ActionLight, Value.Action);

                //Click on Heavy tab
                JSClickDropdownChoice(Xpath.HeavyTab, "Trucks Tab", 3000);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }    
    }
}