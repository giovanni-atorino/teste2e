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
    public class Monitored_Vehicles_Test : BaseClass
    {

        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void AddVerifyRemoveANewVehicle(Xpath__Monitored_Vehicles Xpath, Values__Monitored_Vehicles Value, Filter_Query_Params Filters)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //Click two times on Menu
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

                // Wait until dashboard is visible
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DashboardView)));

                // Navigate to filtered data
                FilterData(weburl_runsettings, Filters.Dashboard, Filters.Frequency, Filters.Vehicle_list, Filters.From_date, Filters.To_date, Filters.Vehicle_type, Filters.Fuel_type);

                js.ExecuteScript("document.body.style.zoom = '0.67'");

                //Scroll website
                Scroll(Xpath.AddVehicleButton);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.AddVehicleButton)));
                var widgetPosition = driver.FindElement(By.XPath(Xpath.AddVehicleButton));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", widgetPosition);


                // Remove all the possible vin inserted in the widget
                int n = 0;
                while (n == 0)
                {
                    try
                    {
                        // Find and click on circle fill button
                        wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ActionButton)));
                        IWebElement ActionButton = driver.FindElement(By.XPath(Xpath.ActionButton));
                        js.ExecuteScript("arguments[0].click();", ActionButton);
                        Console.WriteLine("Click on circle fill button, for a vin already added");

                        // Find and click on YES button
                        wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='monitoredVehiclesContent']//button[@class='button confirm padding-lr text-body']")));
                        IWebElement ConfirmRemoval = driver.FindElement(By.XPath("//div[@id='monitoredVehiclesContent']//button[@class='button confirm padding-lr text-body']"));
                        js.ExecuteScript("arguments[0].click();", ConfirmRemoval);
                        Console.WriteLine("Confirm vehicle removal");

                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("Waited 2 s");

                    }
                    catch
                    { n++; }
                }
                // To iterate over it.
                foreach (List<string> vinData in Value.GetvinList())
                {
                    ///// ADD A NEW VEHICLE /////

                    // Find and click on AGGIUNGI button
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.AddVehicleButton)));
                    IWebElement AddVehicle = driver.FindElement(By.XPath(Xpath.AddVehicleButton));
                    js.ExecuteScript("arguments[0].click();", AddVehicle);
                    Console.WriteLine("Click on ADD vehicle");

                    // Click on ADD NEW VEHICLE
                    Console.WriteLine("Start to add on monitored widget: " + vinData[0]);
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='monitored-vehicles-dropdown']/div[2]/pfe-dropdown-item//p[contains(text(),'" + vinData[0] + "')]")));
                    IWebElement AddVehiclePlusButton = driver.FindElement(By.XPath("//*[@id='monitored-vehicles-dropdown']/div[2]/pfe-dropdown-item//p[contains(text(),'" + vinData[0] + "')]"));
                    js.ExecuteScript("arguments[0].click();", AddVehiclePlusButton);
                    Console.WriteLine("Confirm vehicle addition");



                    ///// CHECK NEW VEHICLE INFORMATION /////

                    // Verify User ID
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='id padding-r'][contains(text(),'" + vinData[0] + "')]")));
                    Console.WriteLine("\r\n" + "Vehicle ID verified: " + driver.FindElement(By.XPath("//span[@class='id padding-r'][contains(text(),'" + vinData[0] + "')]")).Text);


                    // Verify Fuel saving score
                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.FuelSavingScore1)));
                    Assert.That(driver.FindElement(By.CssSelector(Xpath.FuelSavingScore1)).Text, Is.EqualTo("Fuel saving score"));
                    Console.WriteLine("\r\n" + "Verified presence of correct text: Fuel saving score");

                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.FuelSavingScoreValue1)));
                    Assert.That(driver.FindElement(By.CssSelector(Xpath.FuelSavingScoreValue1)).Text, Is.EqualTo(vinData[1]));
                    Console.WriteLine("Fuel saving score value = " + driver.FindElement(By.CssSelector(Xpath.FuelSavingScoreValue1)).Text);


                    // Verify Vehicle care score
                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.VehicleCareScore1)));
                    Assert.That(driver.FindElement(By.CssSelector(Xpath.VehicleCareScore1)).Text, Is.EqualTo("Vehicle care score"));
                    Console.WriteLine("\r\n" + "Verified presence of correct text: Vehicle care score");

                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.VehicleCareScoreValue1)));
                    Assert.That(driver.FindElement(By.CssSelector(Xpath.VehicleCareScoreValue1)).Text, Is.EqualTo(vinData[2]));
                    Console.WriteLine("Vehicle care score value = " + driver.FindElement(By.CssSelector(Xpath.VehicleCareScoreValue1)).Text);


                    //  Verify Average total fuel consumption (l/100km or kg/100km)
                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.TotalAverageFuelConsuption1)));
                    //Assert.That(driver.FindElement(By.CssSelector(Xpath.TotalAverageFuelConsuption1)).Text, Is.EqualTo("Average total fuel consumption (l/100km)"));
                    Console.WriteLine("\r\n" + "Verified presence of correct text:" + driver.FindElement(By.CssSelector(Xpath.TotalAverageFuelConsuption1)).Text);

                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.TotalAverageFuelConsuptionValue1)));
                    Assert.That(driver.FindElement(By.CssSelector(Xpath.TotalAverageFuelConsuptionValue1)).Text, Is.EqualTo(vinData[3]));
                    Console.WriteLine("Average total fuel consumption value = " + driver.FindElement(By.CssSelector(Xpath.TotalAverageFuelConsuptionValue1)).Text);


                    //  Verify CO2 emissions (t)
                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.CO2Emissions1)));
                    Assert.That(driver.FindElement(By.CssSelector(Xpath.CO2Emissions1)).Text, Is.EqualTo("CO2 emissions (t)"));
                    Console.WriteLine("\r\n" + "Verified presence of correct text: CO2 emissions (t)");

                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.CO2EmissionsValue1)));
                    Assert.That(driver.FindElement(By.CssSelector(Xpath.CO2EmissionsValue1)).Text, Is.EqualTo(vinData[4]));
                    Console.WriteLine("CO2 emissions (t) value = " + driver.FindElement(By.CssSelector(Xpath.CO2EmissionsValue1)).Text);


                    //  Verify Safe driving score
                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.SafeGuideScore1)));
                    Assert.That(driver.FindElement(By.CssSelector(Xpath.SafeGuideScore1)).Text, Is.EqualTo("Safe driving score"));
                    Console.WriteLine("\r\n" + "Verified presence of correct text: Safe driving score");

                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector(Xpath.SafeGuideScoreValue1)));
                    Assert.That(driver.FindElement(By.CssSelector(Xpath.SafeGuideScoreValue1)).Text, Is.EqualTo(vinData[5]));
                    Console.WriteLine("Safe driving score value = " + driver.FindElement(By.CssSelector(Xpath.SafeGuideScoreValue1)).Text + "\r\n");



                    ///// REMORE INSERTED VEHICLE /////


                    // Find and click on circle fill button
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class, 'row monitored-vehicles-content margin-b ng-star-inserted')]//span[contains(@id,'" + vinData[0] + "')]")));
                    IWebElement CircleFill = driver.FindElement(By.XPath("//div[contains(@class, 'row monitored-vehicles-content margin-b ng-star-inserted')]//span[contains(@id,'" + vinData[0] + "')]"));
                    js.ExecuteScript("arguments[0].click();", CircleFill);
                    Console.WriteLine("Click su circle fill button");


                    // Find and click on YES button
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='monitoredVehiclesContent']//button[@class='button confirm padding-lr text-body']")));
                    IWebElement ConfirmRemoval = driver.FindElement(By.XPath("//div[@id='monitoredVehiclesContent']//button[@class='button confirm padding-lr text-body']"));
                    js.ExecuteScript("arguments[0].click();", ConfirmRemoval);
                    Console.WriteLine("Confirm vehicle removal");


                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Waited 2 s");


                }
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }

        public void AddVerifyRemoveANewVehicleHeavyBus(Xpath__Monitored_Vehicles Xpath, Values__Monitored_Vehicles Value, Filter_Query_Params Filters)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //Click two times on Menu
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                
                // Wait until dashboard is visible
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DashboardView)));

                // Navigate to filtered data
                FilterData(weburl_runsettings, Filters.Dashboard, Filters.Frequency, Filters.Vehicle_list, Filters.From_date, Filters.To_date, Filters.Vehicle_type, Filters.Fuel_type);

                js.ExecuteScript("document.body.style.zoom = '0.67'");

                //Scroll website
                Scroll(Xpath.AddVehicleButton);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.AddVehicleButton)));
                var widgetPosition = driver.FindElement(By.XPath(Xpath.AddVehicleButton));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", widgetPosition);


                // Remove all the possible vin inserted in the widget
                int n = 0;
                while (n == 0)
                {
                    try
                    {
                        // Find and click on circle fill button

                        wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ActionButton)));
                        IWebElement ActionButton = driver.FindElement(By.XPath(Xpath.ActionButton));
                        js.ExecuteScript("arguments[0].click();", ActionButton);
                        Console.WriteLine("Click on circle fill button, for a vin already added");

                        // Find and click on YES button
                        JSClickDropdownChoice(Xpath.YesButton, "", 1000);
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("Waited 2 s");

                    }
                    catch
                    { n++; }
                }
                // To iterate over it.
                foreach (List<string> vinData in Value.GetvinList())
                {
                    ///// ADD A NEW VEHICLE /////

                    // Find and click on AGGIUNGI button
                    JSClickDropdownChoice(Xpath.AddVehicleButton, "ADD", 2000);

                    // Click on ADD NEW VEHICLE
                    Console.WriteLine("Start to add on monitored widget: " + vinData[0]);
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='monitored-vehicles-dropdown']/div[2]/pfe-dropdown-item//p[contains(text(),'" + vinData[0] + "')]")));
                    IWebElement AddVehiclePlusButton = driver.FindElement(By.XPath("//*[@id='monitored-vehicles-dropdown']/div[2]/pfe-dropdown-item//p[contains(text(),'" + vinData[0] + "')]"));
                    js.ExecuteScript("arguments[0].click();", AddVehiclePlusButton);
                    Console.WriteLine("Confirm vehicle addition");

                    ///// CHECK NEW VEHICLE INFORMATION /////

                    // Verify User ID
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='id padding-r'][contains(text(),'" + vinData[0] + "')]")));
                    Console.WriteLine("\r\n" + "Vehicle ID verified: " + driver.FindElement(By.XPath("//span[@class='id padding-r'][contains(text(),'" + vinData[0] + "')]")).Text);

                    // Verify Average total fuel score
                    AssertElementIsEqualTo(Xpath.FuelSavingScoreValue, vinData[1]);

                    // Verify Average total fuel consumption (l/100km)
                    AssertElementIsEqualTo(Xpath.AvgTotalFuelConsumptionValue, vinData[2]);

                    //  Verify CO2 emissions (t)
                    AssertElementIsEqualTo(Xpath.CO2EmissionValue, vinData[3]);

                    //  Verify Comfort Score
                    AssertElementIsEqualTo(Xpath.ComfortScoreValue, vinData[4]);

                    ///// REMORE INSERTED VEHICLE /////

                    // Find and click on circle fill button
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class, 'row monitored-vehicles-content margin-b ng-star-inserted')]//span[contains(@id,'" + vinData[0] + "')]")));
                    IWebElement CircleFill = driver.FindElement(By.XPath("//div[contains(@class, 'row monitored-vehicles-content margin-b ng-star-inserted')]//span[contains(@id,'" + vinData[0] + "')]"));
                    js.ExecuteScript("arguments[0].click();", CircleFill);
                    Console.WriteLine("Click su circle fill button");


                    // Find and click on YES button
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='monitoredVehiclesContent']//button[@class='button confirm padding-lr text-body']")));
                    IWebElement ConfirmRemoval = driver.FindElement(By.XPath("//div[@id='monitoredVehiclesContent']//button[@class='button confirm padding-lr text-body']"));
                    js.ExecuteScript("arguments[0].click();", ConfirmRemoval);
                    Console.WriteLine("Confirm vehicle removal");


                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Waited 2 s");


                }
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }

        public void AddVerifyRemoveANewVehicleElectric(Xpath__Monitored_Vehicles_Light Xpath, Values__Monitored_Vehicles Value, Filter_Query_Params Filters)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //Click two times on Menu
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

                // Wait until dashboard is visible
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DashboardView)));

                // Navigate to filtered data
                FilterData(weburl_runsettings, Filters.Dashboard, Filters.Frequency, Filters.Vehicle_list, Filters.From_date, Filters.To_date, Filters.Vehicle_type, Filters.Fuel_type);
                
                js.ExecuteScript("document.body.style.zoom = '0.67'");

                //Scroll website
                Scroll(Xpath.AddVehicleButton);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.AddVehicleButton)));
                var widgetPosition = driver.FindElement(By.XPath(Xpath.AddVehicleButton));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", widgetPosition);


                // Remove all the possible vin inserted in the widget
                int n = 0;
                while (n == 0)
                {
                    try
                    {
                        // Find and click on circle fill button

                        wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ActionButton)));
                        IWebElement ActionButton = driver.FindElement(By.XPath(Xpath.ActionButton));
                        js.ExecuteScript("arguments[0].click();", ActionButton);
                        Console.WriteLine("Click on circle fill button, for a vin already added");

                        // Find and click on YES button
                        JSClickDropdownChoice(Xpath.YesButton, "", 1000);
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("Waited 2 s");

                    }
                    catch
                    { n++; }
                }
                // To iterate over it.
                foreach (List<string> vinData in Value.GetvinList())
                {
                    ///// ADD A NEW VEHICLE /////

                    // Find and click on AGGIUNGI button
                    JSClickDropdownChoice(Xpath.AddVehicleButton, "ADD", 2000);

                    // Click on ADD NEW VEHICLE
                    Console.WriteLine("Start to add on monitored widget: " + vinData[0]);
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='monitored-vehicles-dropdown']/div[2]/pfe-dropdown-item//p[contains(text(),'" + vinData[0] + "')]")));
                    IWebElement AddVehiclePlusButton = driver.FindElement(By.XPath("//*[@id='monitored-vehicles-dropdown']/div[2]/pfe-dropdown-item//p[contains(text(),'" + vinData[0] + "')]"));
                    js.ExecuteScript("arguments[0].click();", AddVehiclePlusButton);
                    Console.WriteLine("Confirm vehicle addition");

                    ///// CHECK NEW VEHICLE INFORMATION /////

                    // Verify User ID
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='id padding-r'][contains(text(),'" + vinData[0] + "')]")));
                    Console.WriteLine("\r\n" + "Vehicle ID verified: " + driver.FindElement(By.XPath("//span[@class='id padding-r'][contains(text(),'" + vinData[0] + "')]")).Text);

                    // Verify Energy Usage Score
                    AssertElementIsEqualTo(Xpath.EnergyUsageScoreValue, vinData[1]);

                    // Verify Energy Used
                    AssertElementIsEqualTo(Xpath.EnergyUsedValue, vinData[2]);

                    //  Verify Energy Regenerated
                    AssertElementIsEqualTo(Xpath.EnergyRegeneratedValue, vinData[3]);

                    //  Verify Energy Cliatization
                    AssertElementIsEqualTo(Xpath.EnergyCliatizationValue, vinData[4]);

                    //  Verify Energy Cliatization
                    AssertElementIsEqualTo(Xpath.AverageTimeRechargeValue, vinData[5]);

                    ///// REMORE INSERTED VEHICLE /////

                    // Find and click on circle fill button
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class, 'row monitored-vehicles-content margin-b ng-star-inserted')]//span[contains(@id,'" + vinData[0] + "')]")));
                    IWebElement CircleFill = driver.FindElement(By.XPath("//div[contains(@class, 'row monitored-vehicles-content margin-b ng-star-inserted')]//span[contains(@id,'" + vinData[0] + "')]"));
                    js.ExecuteScript("arguments[0].click();", CircleFill);
                    Console.WriteLine("Click su circle fill button");


                    // Find and click on YES button
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='monitoredVehiclesContent']//button[@class='button confirm padding-lr text-body']")));
                    IWebElement ConfirmRemoval = driver.FindElement(By.XPath("//div[@id='monitoredVehiclesContent']//button[@class='button confirm padding-lr text-body']"));
                    js.ExecuteScript("arguments[0].click();", ConfirmRemoval);
                    Console.WriteLine("Confirm vehicle removal");


                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Waited 2 s");

                }
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }

        public void AddVerifyRemoveANewVehicleHeavyBusElectric(Xpath__Monitored_Vehicles_Light Xpath, Values__Monitored_Vehicles Value, Filter_Query_Params Filters)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //Click two times on Menu
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

                // Wait until dashboard is visible
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DashboardView)));

                // Navigate to filtered data
                FilterData(weburl_runsettings, Filters.Dashboard, Filters.Frequency, Filters.Vehicle_list, Filters.From_date, Filters.To_date, Filters.Vehicle_type, Filters.Fuel_type);

                js.ExecuteScript("document.body.style.zoom = '0.67'");

                //Scroll website
                Scroll(Xpath.AddVehicleButton);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.AddVehicleButton)));
                var widgetPosition = driver.FindElement(By.XPath(Xpath.AddVehicleButton));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", widgetPosition);


                // Remove all the possible vin inserted in the widget
                int n = 0;
                while (n == 0)
                {
                    try
                    {
                        // Find and click on circle fill button

                        wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.ActionButton)));
                        IWebElement ActionButton = driver.FindElement(By.XPath(Xpath.ActionButton));
                        js.ExecuteScript("arguments[0].click();", ActionButton);
                        Console.WriteLine("Click on circle fill button, for a vin already added");

                        // Find and click on YES button
                        JSClickDropdownChoice(Xpath.YesButton, "", 1000);
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("Waited 2 s");

                    }
                    catch
                    { n++; }
                }
                // To iterate over it.
                foreach (List<string> vinData in Value.GetvinList())
                {
                    ///// ADD A NEW VEHICLE /////

                    // Find and click on AGGIUNGI button
                    JSClickDropdownChoice(Xpath.AddVehicleButton, "ADD", 2000);

                    // Click on ADD NEW VEHICLE
                    Console.WriteLine("Start to add on monitored widget: " + vinData[0]);
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='monitored-vehicles-dropdown']/div[2]/pfe-dropdown-item//p[contains(text(),'" + vinData[0] + "')]")));
                    IWebElement AddVehiclePlusButton = driver.FindElement(By.XPath("//*[@id='monitored-vehicles-dropdown']/div[2]/pfe-dropdown-item//p[contains(text(),'" + vinData[0] + "')]"));
                    js.ExecuteScript("arguments[0].click();", AddVehiclePlusButton);
                    Console.WriteLine("Confirm vehicle addition");

                    ///// CHECK NEW VEHICLE INFORMATION /////

                    // Verify User ID
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='id padding-r'][contains(text(),'" + vinData[0] + "')]")));
                    Console.WriteLine("\r\n" + "Vehicle ID verified: " + driver.FindElement(By.XPath("//span[@class='id padding-r'][contains(text(),'" + vinData[0] + "')]")).Text);

                    // Verify Energy Consumption
                    AssertElementIsEqualTo(Xpath.EnergyConsumptionValue, vinData[1]);

                    // Verify Energy Score
                    AssertElementIsEqualTo(Xpath.EnergyScoreValue, vinData[2]);

                    //  Verify Comfort Score
                    AssertElementIsEqualTo(Xpath.ComfortScoreValue, vinData[3]);

                    //  Verify SOC
                    AssertElementIsEqualTo(Xpath.SOCValue, vinData[4]);


                    ///// REMORE INSERTED VEHICLE /////

                    // Find and click on circle fill button
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class, 'row monitored-vehicles-content margin-b ng-star-inserted')]//span[contains(@id,'" + vinData[0] + "')]")));
                    IWebElement CircleFill = driver.FindElement(By.XPath("//div[contains(@class, 'row monitored-vehicles-content margin-b ng-star-inserted')]//span[contains(@id,'" + vinData[0] + "')]"));
                    js.ExecuteScript("arguments[0].click();", CircleFill);
                    Console.WriteLine("Click su circle fill button");


                    // Find and click on YES button
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='monitoredVehiclesContent']//button[@class='button confirm padding-lr text-body']")));
                    IWebElement ConfirmRemoval = driver.FindElement(By.XPath("//div[@id='monitoredVehiclesContent']//button[@class='button confirm padding-lr text-body']"));
                    js.ExecuteScript("arguments[0].click();", ConfirmRemoval);
                    Console.WriteLine("Confirm vehicle removal");


                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Waited 2 s");

                }
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
        public void AddVerifyRemoveANewVehicleTway(Xpath__Monitored_Vehicles Xpath, Values__Monitored_Vehicles Value, Filter_Query_Params Filters)
        {
            try
            {
                //Click two times on Menu
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

                // Wait until dashboard is visible
                VerifyElement(Xpath.DashboardView); 

                // Navigate to filtered data
                FilterData(weburl_runsettings, Filters.Dashboard, Filters.Frequency, Filters.Vehicle_list, Filters.From_date, Filters.To_date, Filters.Vehicle_type, Filters.Fuel_type);

                js.ExecuteScript("document.body.style.zoom = '0.67'");

                //Scroll website
                Scroll(Xpath.AddVehicleButton);
                VerifyElement(Xpath.AddVehicleButton);
                var widgetPosition = driver.FindElement(By.XPath(Xpath.AddVehicleButton));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", widgetPosition);


                // Remove all the possible vin inserted in the widget
                int n = 0;
                while (n == 0)
                {
                    try
                    {
                        // Find and click on circle fill button
                        JSClickDropdownChoice(Xpath.ActionButton, "", 2000);
                        Console.WriteLine("Click on circle fill button, for a vin already added");

                        // Find and click on YES button
                        JSClickDropdownChoice("//div[@id='monitoredVehiclesContent']//button[@class='button confirm padding-lr text-body']", "", 2000);
                        JSClickDropdownChoice("//div[@id='monitoredVehiclesContent']//button[@class='button confirm padding-lr text-body']", "", 2000);
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("Waited 2 s");
                    }
                    catch
                    { n++; }
                }
                // To iterate over it.
                foreach (List<string> vinData in Value.GetvinList())
                {
                    ///// ADD A NEW VEHICLE /////
                    // Find and click on AGGIUNGI button
                    JSClickDropdownChoice(Xpath.AddVehicleButton, "", 2000);

                    // Click on ADD NEW VEHICLE
                    JSClickDropdownChoice("//*[@id='monitored-vehicles-dropdown']/div[2]/pfe-dropdown-item//p[contains(text(),'" + vinData[0] + "')]", "", 2000);

                    ///// CHECK NEW VEHICLE INFORMATION 
                    // Verify User ID
                    VerifyElement("//span[@class='id padding-r'][contains(text(),'" + vinData[0] + "')]");

                    // Verify Avg Total Fuel Consumption
                    AssertElementIsEqualTo(Xpath.AvgTotalFuelConsumptionValue, vinData[1]);

                    // Verify PTO
                    AssertElementIsEqualTo(Xpath.PTOvalue, vinData[2]);

                    //  Verify Idling
                    AssertElementIsEqualTo(Xpath.IdlingValue, vinData[3]);

                    //  Verify CO2Emission
                    AssertElementIsEqualTo(Xpath.CO2EmissionValue, vinData[4]);

                    ///// REMORE INSERTED VEHICLE /////
                    // Find and click on circle fill button
                    JSClickDropdownChoice("//div[contains(@class, 'row monitored-vehicles-content margin-b ng-star-inserted')]//span[contains(@id,'" + vinData[0] + "')]", "", 2000);

                    // Find and click on YES button
                    JSClickDropdownChoice("//div[@id='monitoredVehiclesContent']//button[@class='button confirm padding-lr text-body']", "", 2000);

                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Waited 2 s");
                }
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
    }
}

