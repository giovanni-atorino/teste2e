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
    public class RemoteCommandsMY24_Session_Section : BaseClass
    {
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void RemoteCommandsSectionMY24(Xpath__RemoteCommands XpathRC, Values__RemoteCommands ValueRC)

        {
            try
            {
                // Verify the presence of menu
                AssertElementIsEqualTo(XpathRC.Menu, ValueRC.Menu);
                System.Threading.Thread.Sleep(1000);

                GoToUrl(weburl_runsettings + "/control-panel?vehicleName=Test1&vehicleVIN=WJMM0000000000787");

                //Verify label Control Panel Truck
                AssertElementIsEqualTo(XpathRC.ControlPanelTruck, ValueRC.ControlPanel);

                //Click on Doors Tab
                //JSClickDropdownChoice(XpathRC.DOORS, ValueRC.DOORS, 1000);

                //Verify BOX of Current Status
                //AssertElementIsEqualTo(XpathRC.CurrentStatus, ValueRC.CurrentStatus);

                //Verify BOX of Next Status
                //AssertElementIsEqualTo(XpathRC.NextStatus, ValueRC.NextStatus);

                //Verify button of Change Doors
                //AssertElementIsEqualTo(XpathRC.DoorsButton, ValueRC.DoorsButton);

                //Click on Windows Tab
                //JSClickDropdownChoice(XpathRC.WINDOWS, ValueRC.WINDOWS, 1000);

                //Verify BOX of Current Status
                //AssertElementIsEqualTo(XpathRC.CurrentStatus, ValueRC.CurrentStatus);

                //Verify BOX of Next Status
                //AssertElementIsEqualTo(XpathRC.NextStatus, ValueRC.NextStatus);

                //Verify button of Change WINDOWS
                //AssertElementIsEqualTo(XpathRC.WindowsButton, ValueRC.WindowsButton);

                //Click on CRANKING Tab
                JSClickDropdownChoice(XpathRC.CRANKING, ValueRC.CRANKING, 1000);

                //Verify BOX of Current Status
                AssertElementIsEqualTo(XpathRC.CurrentStatus, ValueRC.CurrentStatus);

                //Verify BOX of Next Status
                AssertElementIsEqualTo(XpathRC.NextStatus, ValueRC.NextStatus);

                //Verify button of Change Cranking
                AssertElementIsEqualTo(XpathRC.CrankingButton, ValueRC.CrankingButton);

                //Click on Adas Settings Tab
                JSClickDropdownChoice(XpathRC.ADASSETTINGS, ValueRC.ADASSETTINGS, 1000);

                //Verify BOX of Current Status
                AssertElementIsEqualTo(XpathRC.CurrentStatus, ValueRC.CurrentStatus);

                //Verify BOX of Next Status
                AssertElementIsEqualTo(XpathRC.NextStatus, ValueRC.NextStatus);

                //Verify button of Change Cranking
                AssertElementIsEqualTo(XpathRC.AdassettingsButton, ValueRC.AdassettingsButton);
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
    }
}