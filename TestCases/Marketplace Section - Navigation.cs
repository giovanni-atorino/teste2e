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
    public class Marketplace_Section_Navigation: BaseClass
    {
        public Marketplace_Section_Navigation(Account Account) : base(Account) { }
        public void MarketplaceSectionNavigation(Xpath__Marketplace Xpath, Values__Marketplace Value)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //Open Menu + click on MarketPlace
                OpenSectionMenu(Xpath.Menu, Xpath.Marketplace, Value.Marketplace, 1000);

                //Verify the presence of Trucks Diesel Dashboard
                AssertElementIsEqualTo(Xpath.DashboardHeavyDiesel, Value.DashboardHeavyDiesel);

                //Verify the presence of Trucks NP Dashboard
                AssertElementIsEqualTo(Xpath.DashboardHeavyNP, Value.DashboardHeavyNP);

                //Verify the presence of Daily Diesel Dashboard
                AssertElementIsEqualTo(Xpath.DashboardLightDiesel, Value.DashboardLightDiesel);

                //Verify the presence of Daily NP Dashboard
                AssertElementIsEqualTo(Xpath.DashboardLightNP, Value.DashboardLightNP);

                //Verify the presence of HeavyBus Diesel Dashboard
                AssertElementIsEqualTo(Xpath.DashboardHeavyBusDiesel, Value.DashboardHeavyBusDiesel);

                //Verify the presence of HeavyBus NP Dashboard
                AssertElementIsEqualTo(Xpath.DashboardHeavyBusNP, Value.DashboardHeavyBusNP);

                //Verify the presence of Tway Diesel Dashboard
                AssertElementIsEqualTo(Xpath.DashboardTwayDiesel, Value.DashboardTwayDiesel);

                //Click on Trucks NP Dashboard
                JSClickDropdownChoice(Xpath.DashboardHeavyNP, "Trucks NP", 1000);

                //Click on Daily Diesel Dashboard
                JSClickDropdownChoice(Xpath.DashboardLightDiesel, "Daily Diesel", 1000);

                //Click on Daily NP Dashboard
                JSClickDropdownChoice(Xpath.DashboardLightNP, "Daily NP", 1000);

                //Click on eDiesel Dashboard
                JSClickDropdownChoice(Xpath.DashboardDailyElectric, "Daily Electric", 1000);

                //Click on HeavyBus Diesel Dashboard
                JSClickDropdownChoice(Xpath.DashboardHeavyBusDiesel, "HeavyBus Diesel", 1000);

                //Click on HeavyBus NP Dashboard
                JSClickDropdownChoice(Xpath.DashboardHeavyBusNP, "HeavyBus NP", 1000);

                //Click on eBus Dashboard
                JSClickDropdownChoice(Xpath.DashboardBusElectric, "Bus Electric", 1000);

                //Click on Tway Diesel Dashboard
                JSClickDropdownChoice(Xpath.DashboardTwayDiesel, "Tway Diesel", 1000);
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        driver.Close();
        }
    }
}
