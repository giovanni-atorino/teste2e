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

namespace myiveco_selenium.TestCases
{
    public class NextMaintenanceMonitoringWidget : BaseClass
    {
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void NextMaintenanceMonitoringTest(Xpath__NextMaintenanceMonitoring Xpath, Values__NextMaintenanceMonitoring Value)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));

                //Scroll to down and top the website
                ScrollDown();

                //Scroll website until title of widget is found
                Scroll(Xpath.TitleNextMaintenanceMonitoring);

                //Verify the label TitleNextMaintenanceMonitoring
                AssertElementIsEqualTo(Xpath.TitleNextMaintenanceMonitoring, Value.TitleNextMaintenanceMonitoring);

                //Verify the label Close to maintenance
                AssertElementIsEqualTo(Xpath.CloseToMaintenance, Value.CloseToMaintenance);

                //Verify the label To Expired
                AssertElementIsEqualTo(Xpath.Expired, Value.Expired);

                //Verify the label NoMaintenance
                AssertElementIsEqualTo(Xpath.NoMaintenance, Value.NoMaintenance);

                //Verify the label DataNotAvailable
                AssertElementIsEqualTo(Xpath.DataNotAvailable, Value.DataNotAvailable);

                //Verify presence of Discover more button
                VerifyElement(Xpath.DiscovereMoreButton);

                //Click on Discover More Button
                JSClickDropdownChoice(Xpath.DiscovereMoreButton, Value.DiscovereMoreButton, 2000);

                //Verify presence of Discover more button
                AssertElementIsEqualTo(Xpath.VehiclesMaintenance, Value.VehiclesMaintenance);

            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        }
    }
}
