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
    public class DSE_Widget_Vehicles_Acceleration : BaseClass
    {
        
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void DSEkpiAnalysisHeavy(Xpath__DSE Xpath, Values__DSE Value, Filter_Query_Params Filters)
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
                System.Threading.Thread.Sleep(1000);

                //Scroll website
                Scroll(Xpath.DSEDriverRelatedLabelPath);
                var DSEwidgetPosition = driver.FindElement(By.XPath(Xpath.DSEDriverRelatedLabelPath));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", DSEwidgetPosition);

                // Driving Style Evaluation (driver related)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DSEDriverRelatedLabelPath)));
                Assert.That(driver.FindElement(By.XPath(Xpath.DSEDriverRelatedLabelPath)).Text, Is.EqualTo("Driving Style Evaluation (driver related)"));
                Console.WriteLine("Verified presence of correct text: Driving Style Evaluation (driver related)");

                // Verify Fuel Saving Score KPI
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FuelSavingScoreLabelPath)));
                Assert.That(driver.FindElement(By.XPath(Xpath.FuelSavingScoreLabelPath)).Text, Is.EqualTo("Fuel saving score"));
                Console.WriteLine("\r\n" + "Verified presence of KPI: Fuel saving score");

                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FuelSavingScoreValuePath)));
                Assert.That(driver.FindElement(By.XPath(Xpath.FuelSavingScoreValuePath)).Text, Is.EqualTo(Value.FuelSavingScoreValue));
                Console.WriteLine("Fuel saving score value = " + driver.FindElement(By.XPath(Xpath.FuelSavingScoreValuePath)).Text);
            

                // Verify acceleration KPI
                Assert.That(driver.FindElement(By.XPath(Xpath.AccelerationLabelPath)).Text, Is.EqualTo("Acceleration"));
                Console.WriteLine("\r\n" + "Verified presence of KPI: Acceleration");

                Assert.That(driver.FindElement(By.XPath(Xpath.AccelerationValuePath)).Text, Is.EqualTo(Value.AccelerationValue));
                Console.WriteLine("Acceleration value = " + driver.FindElement(By.XPath(Xpath.AccelerationValuePath)).Text);


                // Verify deceleration KPI
                Assert.That(driver.FindElement(By.XPath(Xpath.DecelerationLabelPath)).Text, Is.EqualTo("Deceleration"));
                Console.WriteLine("\r\n" + "Verified presence of KPI: Deceleration");

                Assert.That(driver.FindElement(By.XPath(Xpath.DecelerationValuePath)).Text, Is.EqualTo(Value.DecelerationValue));
                Console.WriteLine("Deceleration value = " + driver.FindElement(By.XPath(Xpath.DecelerationValuePath)).Text);


                // Verify engine use KPI
                Assert.That(driver.FindElement(By.XPath(Xpath.EngineUseLabelPath)).Text, Is.EqualTo("Engine use"));
                Console.WriteLine("\r\n" + "Verified presence of KPI: Engine Use");

                Assert.That(driver.FindElement(By.XPath(Xpath.EngineUseValuePath)).Text, Is.EqualTo(Value.EngineUseValue));
                Console.WriteLine("Engine Use value = " + driver.FindElement(By.XPath(Xpath.EngineUseValuePath)).Text);


                // Verify Vehicle Care Score KPI
                Assert.That(driver.FindElement(By.XPath(Xpath.VehicleCareScoreLabelPath)).Text, Is.EqualTo("Vehicle care score"));
                Console.WriteLine("\r\n" + "Verified presence of KPI: Vehicle Care Score");

                Assert.That(driver.FindElement(By.XPath(Xpath.VehicleCareScoreValuePath)).Text, Is.EqualTo(Value.VehicleCareScoreValue));
                Console.WriteLine("Vehicle Care Score value = " + driver.FindElement(By.XPath(Xpath.VehicleCareScoreValuePath)).Text);


                // Verify Brake Use KPI
                Assert.That(driver.FindElement(By.XPath(Xpath.BrakeUseLabelPath)).Text, Is.EqualTo("Brake use"));
                Console.WriteLine("\r\n" + "Verified presence of KPI: Brake Use");

                Assert.That(driver.FindElement(By.XPath(Xpath.BrakeUseValuePath)).Text, Is.EqualTo(Value.BrakeUseValue));
                Console.WriteLine("Brake Use value = " + driver.FindElement(By.XPath(Xpath.BrakeUseValuePath)).Text);


                // Verify Tyres KPI
                Assert.That(driver.FindElement(By.XPath(Xpath.TyresLabelPath)).Text, Is.EqualTo("Tyres"));
                Console.WriteLine("\r\n" + "Verified presence of KPI: Tyres");

                Assert.That(driver.FindElement(By.XPath(Xpath.TyresValuePath)).Text, Is.EqualTo(Value.TyresValue));
                Console.WriteLine("Tyres value = " + driver.FindElement(By.XPath(Xpath.TyresValuePath)).Text);


                // Verify Safe Driving Score KPI
                Assert.That(driver.FindElement(By.XPath(Xpath.SafeDrivingScoreLabelPath)).Text, Is.EqualTo("Safe driving score"));
                Console.WriteLine("\r\n"+"Verified presence of KPI: Safe Driving Score");

                Assert.That(driver.FindElement(By.XPath(Xpath.SafeDrivingScoreValuePath)).Text, Is.EqualTo(Value.SafeDrivingScoreValue));
                Console.WriteLine("Safe Driving Score value = " + driver.FindElement(By.XPath(Xpath.SafeDrivingScoreValuePath)).Text);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }

        public void DSEkpiAnalysisLight(Xpath__DSE_Light Xpath, Values__DSE_Light Value, Filter_Query_Params Filters)
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
                Scroll(Xpath.DSELabelPath);
                var DSEwidgetPosition = driver.FindElement(By.XPath(Xpath.DSELabelPath));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", DSEwidgetPosition);

                // Driving Style Evaluation (vehicle related)
                AssertElementIsEqualTo(Xpath.DSELabelPath, "Driving Style Evaluation (vehicle related)");

                // Verify Eco Score KPI
                AssertElementIsEqualTo(Xpath.EcoScoreLabelPath, "Eco score");

                Console.WriteLine("Verify that Fuel saving score value is eqaul to " + driver.FindElement(By.XPath(Xpath.EngineUseValuePath)).Text);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.EcoScoreValuePath)));
                Assert.That(driver.FindElement(By.XPath(Xpath.EcoScoreValuePath)).Text, Is.EqualTo(Value.EcoScoreValue));
                Console.WriteLine("Fuel saving score value = " + driver.FindElement(By.XPath(Xpath.EcoScoreValuePath)).Text);

                // Verify acceleration KPI
                AssertElementIsEqualTo(Xpath.AccelerationLabelPath, "Acceleration");

                Console.WriteLine("Verify that Acceleration value is equal to" + driver.FindElement(By.XPath(Xpath.AccelerationValuePath)).Text);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.AccelerationValuePath)));
                Assert.That(driver.FindElement(By.XPath(Xpath.AccelerationValuePath)).Text, Is.EqualTo(Value.AccelerationValue));
                Console.WriteLine("Acceleration value = " + driver.FindElement(By.XPath(Xpath.AccelerationValuePath)).Text);

                // Verify deceleration KPI
                AssertElementIsEqualTo(Xpath.DecelerationLabelPath, "Deceleration");

                Console.WriteLine("Verify that Deceleration value is equal to " + driver.FindElement(By.XPath(Xpath.DecelerationValuePath)).Text);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DecelerationValuePath)));
                Assert.That(driver.FindElement(By.XPath(Xpath.DecelerationValuePath)).Text, Is.EqualTo(Value.DecelerationValue));
                Console.WriteLine("Deceleration value = " + driver.FindElement(By.XPath(Xpath.DecelerationValuePath)).Text);

                // Verify engine use KPI
                AssertElementIsEqualTo(Xpath.EngineUseLabelPath, "Engine use");

                Console.WriteLine("Verify that Engine Use value is equal to " + driver.FindElement(By.XPath(Xpath.EngineUseValuePath)).Text);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.EngineUseValuePath)));
                Assert.That(driver.FindElement(By.XPath(Xpath.EngineUseValuePath)).Text, Is.EqualTo(Value.EngineUseValue));
                Console.WriteLine("Engine Use value = " + driver.FindElement(By.XPath(Xpath.EngineUseValuePath)).Text);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }


        public void DSEkpiAnalysisHeavyBus(Xpath__DSE Xpath, Values__DSE_HeavyBus Value, Filter_Query_Params Filters)
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
                Scroll(Xpath.DSEDriverRelatedLabelPath);
                var DSEwidgetPosition = driver.FindElement(By.XPath(Xpath.DSEDriverRelatedLabelPath));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", DSEwidgetPosition);

                // Driving Style Evaluation (vehicle related)
                AssertElementIsEqualTo(Xpath.DSEDriverRelatedLabelPath, "Driving Style Evaluation (vehicle related)");

                // Verify Fuel Saving Score Value
                AssertElementIsEqualTo(Xpath.FuelSavingScoreValuePath, Value.FuelSavingScoreValuePath);

                // Verify Acceleration Value
                AssertElementIsEqualTo(Xpath.AccelerationValuePath, Value.AccelerationValue);

                // Verify Inertia Value
                AssertElementIsEqualTo(Xpath.InertiaValuePath, Value.InertiaValue);

                // Verify Stop Value
                AssertElementIsEqualTo(Xpath.StopValuePath, Value.StopValue);

                // Verify Stop Value
                AssertElementIsEqualTo(Xpath.ComfortScoreValuePath, Value.ComfortScoreValue);

                // Verify Stop Value
                AssertElementIsEqualTo(Xpath.LateralComfortValuePath, Value.LateralComfortScoreValue);

                // Verify Stop Value
                AssertElementIsEqualTo(Xpath.LongitudinalComfortValuePath, Value.LongitudinalComfortScoreValue);

                // Verify Stop Value
                AssertElementIsEqualTo(Xpath.VerticalComfortValuePath, Value.VerticalComfortScoreValue);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
        public void DSEkpiAnalysisElectric(Xpath__DSE_Light Xpath, Values__DSE_Electric Value, Filter_Query_Params Filters)
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
                System.Threading.Thread.Sleep(1000);

                //Scroll website
                Scroll(Xpath.DSEDriverRelatedLabelPath);
                var DSEwidgetPosition = driver.FindElement(By.XPath(Xpath.DSEDriverRelatedLabelPath));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", DSEwidgetPosition);

                // Driving Style Evaluation (driver related)
                AssertElementIsEqualTo(Xpath.DSEDriverRelatedLabelPath, "Driving Style Evaluation (vehicle related)");

                // Verify Fuel Saving Score KPI
                AssertElementIsEqualTo(Xpath.EnergyEfficiencyScoreValuePath, Value.EnergyEfficiencyScoreValue);

                // Verify acceleration KPI
                AssertElementIsEqualTo(Xpath.AccelerationValuePath, Value.AccelerationValue);

                // Verify deceleration KPI
                AssertElementIsEqualTo(Xpath.DecelerationValuePath, Value.DecelerationValue);

                // Verify engine use KPI
                AssertElementIsEqualTo(Xpath.EnergyManagementValuePath, Value.EnergyManagementValue);

                // Verify Vehicle Care Score KPI
                AssertElementIsEqualTo(Xpath.VehicleCareScoreValuePath, Value.VehicleCareScoreValue);

                // Verify Brake Use KPI
                AssertElementIsEqualTo(Xpath.BrakeUseValuePath, Value.BrakeUseValue);

                // Verify Tyres KPI
                AssertElementIsEqualTo(Xpath.TyresValuePath, Value.TyresValue);

                // Verify Safe Driving Score KPI
                AssertElementIsEqualTo(Xpath.SafeDrivingScoreValuePath, Value.SafeDrivingScoreValue);
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
    }
}