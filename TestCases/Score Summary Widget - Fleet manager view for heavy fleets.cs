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
    public class Score_Summary_Widget : BaseClass
    {

        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void FleetManagerViewForHeavyFleets(Xpath__Score_Summary Xpath, Values__Score_Summary Value, Filter_Query_Params Filters)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                // Wait until dashboard is visible
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DashboardView)));

                //Click two times on Menu
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

                // Navigate to filtered data
                FilterData(weburl_runsettings, Filters.Dashboard, Filters.Frequency, Filters.Vehicle_list, Filters.From_date, Filters.To_date, Filters.Vehicle_type, Filters.Fuel_type);

                // Verify Fuel saving score (driver related)
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.FuelSavingScore)));
                //Assert.That(driver.FindElement(By.CssSelector(Xpath.FuelSavingScore)).Text.Replace("\r\n", " "), Is.EqualTo("Fuel saving score (driver related)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: Fuel saving score (driver related)");

                Assert.That(driver.FindElement(By.CssSelector(Xpath.FuelSavingScoreValue)).Text, Is.EqualTo(Value.FuelSavingScore));
                Console.WriteLine("Fuel saving score (driver related) value = " + driver.FindElement(By.CssSelector(Xpath.FuelSavingScoreValue)).Text);


                // Verify Fuel consumption (l/100km or kg/100km)
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.FuelConsuption)));
                //Assert.That(driver.FindElement(By.CssSelector(Xpath.FuelConsuption)).Text.Replace("\r\n", " "), Is.EqualTo("Fuel consumption (l/100km)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: Fuel consumption (l/100km) or Fuel consumption (kg/100km)");

                Assert.That(driver.FindElement(By.CssSelector(Xpath.FuelConsuptionValue)).Text, Is.EqualTo(Value.FuelConsuption));
                Console.WriteLine("\r\n" + driver.FindElement(By.CssSelector(Xpath.FuelConsuption)).Text.Replace("\r\n", " ") + ": " + driver.FindElement(By.CssSelector(Xpath.FuelConsuptionValue)).Text);


                // Verify Grado di difficoltà
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.DegreeOfDifficulty)));
                Assert.That(driver.FindElement(By.CssSelector(Xpath.DegreeOfDifficulty)).Text.Replace("\r\n", " "), Is.EqualTo("Degree of difficulty"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: Degree of difficulty");

                Assert.That(driver.FindElement(By.CssSelector(Xpath.DegreeOfDifficultyValue)).Text, Is.EqualTo(Value.DegreeOfDifficulty));
                Console.WriteLine("Degree of difficulty value = " + driver.FindElement(By.CssSelector(Xpath.DegreeOfDifficultyValue)).Text);


                // Verify Average gross combination weight (t)
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.AverageGrossCombinationWeight)));
                Assert.That(driver.FindElement(By.CssSelector(Xpath.AverageGrossCombinationWeight)).Text.Replace("\r\n", " "), Is.EqualTo("Average gross combination weight (t)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: Average gross combination weight (t)");

                Assert.That(driver.FindElement(By.CssSelector(Xpath.AverageGrossCombinationWeightValue)).Text, Is.EqualTo(Value.AverageGrossCombinationWeight));
                Console.WriteLine("Average gross combination weight (t) value = " + driver.FindElement(By.CssSelector(Xpath.AverageGrossCombinationWeightValue)).Text);


                // Verify Average distance per unit (km)
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.AverageDistancePerUnit)));
                Assert.That(driver.FindElement(By.CssSelector(Xpath.AverageDistancePerUnit)).Text.Replace("\r\n", " "), Is.EqualTo("Average distance per unit (km)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: Average distance per unit (km)");

                Assert.That(driver.FindElement(By.CssSelector(Xpath.AverageDistancePerUnitValue)).Text, Is.EqualTo(Value.AverageDistancePerUnit));
                Console.WriteLine("Average distance per unit (km) value = " + driver.FindElement(By.CssSelector(Xpath.AverageDistancePerUnitValue)).Text);


                // Verify CO2 emissions (t)
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.CO2Emissions)));
                Assert.That(driver.FindElement(By.CssSelector(Xpath.CO2Emissions)).Text.Replace("\r\n", " "), Is.EqualTo("CO2 emissions (t)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: CO2 emissions (t)");

                Assert.That(driver.FindElement(By.CssSelector(Xpath.CO2EmissionsValue)).Text, Is.EqualTo(Value.CO2Emissions));
                Console.WriteLine("CO2 emissions (t) value = " + driver.FindElement(By.CssSelector(Xpath.CO2EmissionsValue)).Text);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }

        public void FleetManagerViewForLightFleets(Xpath__Score_Summary_Light Xpath, Values__Score_Summary_Light Value, Filter_Query_Params Filters)
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

                // Verify Eco score
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.EcoScore)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.EcoScore)).Text.Replace("\r\n", " "), Is.EqualTo("Eco score"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: Eco score");


                Assert.That(driver.FindElement(By.XPath(Xpath.EcoScoreValue)).Text, Is.EqualTo(Value.EcoScore));
                Console.WriteLine("Eco score value = " + driver.FindElement(By.XPath(Xpath.EcoScoreValue)).Text);

                // Verify Fuel consumption (l/100km or kg/100km)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FuelConsumption)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.FuelConsumption)).Text.Replace("\r\n", " "), Is.EqualTo("Fuel consumption (l/100km)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: " + driver.FindElement(By.XPath(Xpath.FuelConsumption)).Text.Replace("\r\n", " "));

                Assert.That(driver.FindElement(By.XPath(Xpath.FuelConsumptionValue)).Text, Is.EqualTo(Value.FuelConsuption));
                Console.WriteLine(driver.FindElement(By.XPath(Xpath.FuelConsumption)).Text.Replace("\r\n", " ") + ": " + driver.FindElement(By.XPath(Xpath.FuelConsumptionValue)).Text);


                // Verify Total distance (km)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.TotalDistance)));
                Assert.That(driver.FindElement(By.XPath(Xpath.TotalDistance)).Text.Replace("\r\n", " "), Is.EqualTo("Total distance (km)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: Total Distance (km)");

                Assert.That(driver.FindElement(By.XPath(Xpath.TotalDistanceValue)).Text, Is.EqualTo(Value.TotalDistance));
                Console.WriteLine("Total Distance value = " + driver.FindElement(By.XPath(Xpath.TotalDistanceValue)).Text);

                // Verify Total trip Time (hh:mm:ss)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.TotalTripTime)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.TotalTripTime)).Text.Replace("\r\n", " "), Is.EqualTo("Total trip time (hh:mm:ss)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: " + driver.FindElement(By.XPath(Xpath.TotalTripTime)).Text.Replace("\r\n", " "));

                Assert.That(driver.FindElement(By.XPath(Xpath.TotalTripTimeValue)).Text, Is.EqualTo(Value.TotalTripTime));
                Console.WriteLine(driver.FindElement(By.XPath(Xpath.TotalTripTime)).Text.Replace("\r\n", " ") + ": " + driver.FindElement(By.XPath(Xpath.TotalTripTimeValue)).Text);

                // Verify Trips
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Trips)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Trips)).Text.Replace("\r\n", " "), Is.EqualTo("Trips"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: Trips");

                Assert.That(driver.FindElement(By.XPath(Xpath.TripsValue)).Text, Is.EqualTo(Value.Trips));
                Console.WriteLine("Trips value = " + driver.FindElement(By.XPath(Xpath.TripsValue)).Text);

                // Verify Average speed (km/h)"
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.AverageSpeed)));
                Assert.That(driver.FindElement(By.XPath(Xpath.AverageSpeed)).Text.Replace("\r\n", " "), Is.EqualTo("Average speed (km/h)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: Average speed (km/h)");

                Assert.That(driver.FindElement(By.XPath(Xpath.AverageSpeedValue)).Text, Is.EqualTo(Value.AverageSpeed));
                Console.WriteLine("Average speed (km/h) value = " + driver.FindElement(By.XPath(Xpath.AverageSpeedValue)).Text);

                // Verify CO2 emissions (t)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CO2Emissions)));
                Assert.That(driver.FindElement(By.XPath(Xpath.CO2Emissions)).Text.Replace("\r\n", " "), Is.EqualTo("CO2 emissions (kg)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: CO2 emissions (kg)");

                Assert.That(driver.FindElement(By.XPath(Xpath.CO2EmissionsValue)).Text, Is.EqualTo(Value.CO2Emissions));
                Console.WriteLine("CO2 emissions (t) value = " + driver.FindElement(By.XPath(Xpath.CO2EmissionsValue)).Text);

            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }

        public void FleetManagerViewForLightElectricFleets(Xpath__Score_Summary_Light Xpath, Values__Score_Summary_Light_Electric Value, Filter_Query_Params Filters)
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

                // Verify Driving efficiency score (index)
                AssertElementIsEqualTo(Xpath.EnergyEfficiencyScoreValueeDailyElectric, Value.EnergyEfficiencyScoreLightElectric);

                // Verify Driving efficiency score
                AssertElementIsEqualTo(Xpath.EnergyConsumptionValueeDailyElectric, Value.EnergyConsumptionLightElectric);

                // Verify Energy regenerated vs. used (%)
                AssertElementIsEqualTo(Xpath.EnergyRegeneratedValueeDailyElectric, Value.EnergyRegeneratedDailyElectric);

                // Verify Energy for climatization vs. used (%) 
                AssertElementIsEqualTo(Xpath.EnergyForClimatizationValueeDailyElectric, Value.EnergyForClimatizationDailyElectric);

                // Verify Average recharge time (hh:mm) 
                AssertElementIsEqualTo(Xpath.AverageRechargeTimeValueeDailyElectric, Value.AverageRechargeTimeDailyElectric);

                // Verify Average recharged energy (kWh) 
                AssertElementIsEqualTo(Xpath.AverageRechargeEnergyValueDailyElectric, Value.AverageRechargeEnergyDailyElectric);


                //Click on Mission
                JSFindElementAndClick(Xpath.MissionTab, "Mission", 2000);

                // Verify Average distance per unit (km)
                AssertElementIsEqualTo(Xpath.AverageDistancePerUnitValueeDailyElectric, Value.AverageDistancePerUnitDailyElectric);

                // Verify Average trip time (dd:hh:mm) or (hh:mm)
                AssertElementIsEqualTo(Xpath.AverageTripTimeValueeDailyElectric, Value.AverageTripTimeValueeDailyElectric);

                // Verify Average speed (km/h)
                AssertElementIsEqualTo(Xpath.AverageSpeedValueeDailyElectric, Value.AverageSpeedValueeDailyElectric);

                // Verify Average gross combination weight (t)
                AssertElementIsEqualTo(Xpath.AverageGrossCombinationWeightValueeDailyElectric, Value.AverageGrossCombinationWeightValueeDailyElectric);

                // Verify Traction battery state of health (%)
                AssertElementIsEqualTo(Xpath.TractionBatteryStateOfHealthValueeDailyElectric, Value.TractionBatteryStateOfHealthValueeDailyElectric);

                // Verify Energy throughput (kWh)
                AssertElementIsEqualTo(Xpath.EnergyThroughputValueeDailyElectric, Value.EnergyThroughputValueeDailyElectric);

            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }



        public void FleetManagerViewForHeavyBusFleets(Xpath__Score_Summary Xpath, Values__Score_Summary_HeavyBus Value, Filter_Query_Params Filters)
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

                // Verify Fuel saving score (driver related)
                AssertElementIsEqualTo(Xpath.FuelSavingScoreValueHeavyBus, Value.FuelSavingScore);

                // Verify Fuel consumption (l/100km or kg/100km)
                AssertElementIsEqualTo(Xpath.FuelConsumptionValueHeavyBus, Value.FuelConsuption);

                // Verify Average distance per unit (km)
                AssertElementIsEqualTo(Xpath.AverageDistancePerUnitValueHeavyBus, Value.AverageDistancePerUnit);

                // Verify CO2 emissions (t)
                AssertElementIsEqualTo(Xpath.CO2EmissionsValueHeavyBus, Value.CO2Emissions);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }


        public void FleetManagerViewForHeavyBusElectricFleets(Xpath__Score_Summary Xpath, Values__Score_Summary_HeavyBusElectric Value, Filter_Query_Params Filters)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                // Wait until dashboard is visible
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DashboardView)));

                // Navigate to filtered data
                FilterData(weburl_runsettings, Filters.Dashboard, Filters.Frequency, Filters.Vehicle_list, Filters.From_date, Filters.To_date, Filters.Vehicle_type, Filters.Fuel_type);

                // Verify Driving efficiency score
                AssertElementIsEqualTo(Xpath.DrivingEfficiencyScoreHeavyBusElectricValue, Value.DrivingEfficiencyScore);

                // Verify Energy Consumption 
                AssertElementIsEqualTo(Xpath.EnergyConsumptionHeavyBusElectricValue, Value.EnergyConsumption);

                // Verify Average distance per unit (km)
                AssertElementIsEqualTo(Xpath.AverageDistanceHeavyBusElectricValue, Value.AverageDistancePerUnit);

                // Verify CO2 emissions (t)
                AssertElementIsEqualTo(Xpath.AverageOctHeavyBusElectricValue, Value.AvgOCT);

                // Verify CO2 emissions (t)
                AssertElementIsEqualTo(Xpath.AverageTripTimeHeavyBusElectricValue, Value.AvgTripTime);

                // Verify CO2 emissions (t)
                AssertElementIsEqualTo(Xpath.AverageSpeedHeavyBusElectricValue, Value.AverageSpeed);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
        public void FleetManagerViewForTwayFleets(Xpath__Score_Summary Xpath, Values__Score_Summary_Tway Value, Filter_Query_Params Filters)
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

                // Verify Fuel consumption (l/100km)
                AssertElementIsEqualTo(Xpath.FuelConsuptionValueTway, Value.FuelConsuption);

                // Verify Average gross combination weight (t)
                AssertElementIsEqualTo(Xpath.AverageGrossCombinationWeightValueTway, Value.AverageGrossCombinationWeight);

                // Verify Average distance per unit (km)
                AssertElementIsEqualTo(Xpath.AverageDistancePerUnitValueTway, Value.AverageDistancePerUnit);

                // Verify Average speed (km/h)
                AssertElementIsEqualTo(Xpath.AverageSpeedValue, Value.AvgSpeed);

                // Verify CO2 emissions (t)
                AssertElementIsEqualTo(Xpath.CO2EmissionsValueTway, Value.CO2Emissions);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
    }
}