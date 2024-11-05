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
    public class Marketplace_Section: BaseClass
    {
        public void MarketplaceSection(Xpath__Marketplace Xpath, Values__Marketplace Value)
        {
           
            try
            {
                //Wait definition for element
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

                //Verify the presence of eDiesel Dashboard
                AssertElementIsEqualTo(Xpath.DashboardDailyElectric, Value.DashboardDailyElectric);

                //Verify the presence of HeavyBus Diesel Dashboard
                AssertElementIsEqualTo(Xpath.DashboardHeavyBusDiesel, Value.DashboardHeavyBusDiesel);    

                //Verify the presence of HeavyBus NP Dashboard
                AssertElementIsEqualTo(Xpath.DashboardHeavyBusNP, Value.DashboardHeavyBusNP);

                //Verify the presence of eBus Dashboard
                AssertElementIsEqualTo(Xpath.DashboardBusElectric, Value.DashboardBusElectric);

                //Verify the presence of Tway Diesel Dashboard
                AssertElementIsEqualTo(Xpath.DashboardTwayDiesel, Value.DashboardTwayDiesel);

                //Verify the presence of Overview
                AssertElementIsEqualTo(Xpath.Overview, Value.Overview);

                //Verify the presence of News Feed
                AssertElementIsEqualTo(Xpath.NewsFeed, Value.NewsFeed);

                //Verify the presence of Fuel Consumption
                AssertElementIsEqualTo(Xpath.FuelConsumption, Value.FuelConsumption);

                //Verify the presence of CO2 Emissions
                AssertElementIsEqualTo(Xpath.CO2Emissions, Value.CO2Emissions);

                //Verify the presence of DrivingStyleEvaluation
                AssertElementIsEqualTo(Xpath.DrivingStyleEvaluation, Value.DrivingStyleEvaluation);

                //Verify the presence of Monitored Drivers
                AssertElementIsEqualTo(Xpath.MonitoredDrivers, Value.MonitoredDrivers);

                //Verify the presence of Monitored Vehicle
                AssertElementIsEqualTo(Xpath.MonitoredVehicle, Value.MonitoredVehicle);

                //Verify the presence of Ranking
                AssertElementIsEqualTo(Xpath.Ranking, Value.Ranking);

                //Verify the presence of Vehicle Route
                AssertElementIsEqualTo(Xpath.VehicleRoute, Value.VehicleRoute);

                //Verify the presence of Tips
                AssertElementIsEqualTo(Xpath.Tips, Value.Tips);

                // SERVICE BOOKING REMOVED FROM REQUIREMENTS PER HEAVY DASHBOARDS
                //Verify the presence of Service Booking
                //wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ServiceBooking)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.ServiceBooking)).Text, Is.EqualTo(Value.ServiceBooking));
                //Console.WriteLine("Verified presence of Service Booking");
            }
            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        driver.Close();
        }
    }
}