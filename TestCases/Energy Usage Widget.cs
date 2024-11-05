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
    public class Energy_usage_Widget: BaseClass
    {
       
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void TotalEnergyUsageInformation(Xpath__Fuel_Consumption Xpath, Values__Energy_Usage Value, Filter_Query_Params Filters)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                //Click two times on Menu
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

                // Wait until dashboard is visible
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DashboardView)));

                // Navigate to filtered data
                FilterData(weburl_runsettings, Filters.Dashboard, Filters.Frequency, Filters.Vehicle_list, Filters.From_date, Filters.To_date, Filters.Vehicle_type, Filters.Fuel_type);

                //Click two times on Menu
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                
                js.ExecuteScript("document.body.style.zoom = '0.67'");

                //Scroll website
                Scroll(Xpath.EnergyUsage);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.EnergyUsage)));
                var EnergyUsagenWidgetPosition = driver.FindElement(By.XPath(Xpath.EnergyUsage));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", EnergyUsagenWidgetPosition);

                // Verify Fuel consumption label
                AssertElementIsEqualTo(Xpath.EnergyUsage, "Energy usage");

                // Fleet KPI
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.AverageLabelFleet)));
                AssertElementIsEqualTo(Xpath.EnergyUsageVallue, Value.AverageFleet);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
        driver.Close();
        }
    }
}