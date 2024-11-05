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
    public class Rankings_Widget : BaseClass
    {

        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void RankingDriversWidget(Xpath__Ranking Xpath, Values__Ranking_Drivers Value, Filter_Query_Params Filters)
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

                driver.Manage().Window.Maximize();
                js.ExecuteScript("document.body.style.zoom = '0.67'");

                //Scroll website
                Scroll(Xpath.VehiclesRankingTab);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehiclesRankingTab)));
                var widgetPosition = driver.FindElement(By.XPath(Xpath.VehiclesRankingTab));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", widgetPosition);

                // Zoom-out to see all data
                js.ExecuteScript("document.body.style.zoom = '0.10'");

                //Define flag to fail the test if at least one data of ranking fails
                int failureFlag = 0;

                // Open Ranking columns: User, Driver , Mission, Behavior, Fuel Consumption, Vehicle
                JSClickDropdownChoice(Xpath.DriverUserButton, "USER column", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DriverUserButtonExpanded)));

                JSClickDropdownChoice(Xpath.DriverDriverButton, "DRIVER column", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DriverDriverButtonExpanded)));

                JSClickDropdownChoice(Xpath.DriverMissionButton, "MISSION  column", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DriverMissionButtonExpanded)));

                JSClickDropdownChoice(Xpath.DriverBehaviorButton, "BEHAVIOR  column", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DriverBehaviorButtonExpanded)));

                JSClickDropdownChoice(Xpath.DriverFuelConsumptionButton, "FUEL CONSUMPTION column", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DriverFuelConsumptionButtonExpanded)));

                JSClickDropdownChoice(Xpath.DriverVehicleButton, "VEHICLE column \r\n\r\n", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DriverVehicleButtonExpanded)));

                // Verify Fuel saving score (driver related)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FuelSavingScoreDrivers)));
                Assert.That(driver.FindElement(By.XPath(Xpath.FuelSavingScoreDrivers)).Text.Replace("\r\n", " "), Is.EqualTo("Fuel saving score (driver related)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: Fuel saving score (driver related)");

                Assert.That(driver.FindElement(By.XPath(Xpath.FuelSavingScoreValueDrivers)).Text, Is.EqualTo(Value.fuelSavingScore));
                Console.WriteLine("Fuel saving score (driver related) value = " + driver.FindElement(By.XPath(Xpath.FuelSavingScoreValueDrivers)).Text);


                // Verify Average total fuel (l/100km) or kg/100km
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.AverageTotalFuelDrivers)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.AverageTotalFuelDrivers)).Text.Replace("\r\n", " "), Is.EqualTo("Average total fuel (l/100km)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text:" + driver.FindElement(By.XPath(Xpath.AverageTotalFuelDrivers)).Text.Replace("\r\n", " "));

                Assert.That(driver.FindElement(By.XPath(Xpath.AverageTotalFuelValueDrivers)).Text, Is.EqualTo(Value.AverageTotalFuel));
                Console.WriteLine("Average total fuel (l/100km) value = " + driver.FindElement(By.XPath(Xpath.AverageTotalFuelValueDrivers)).Text);


                // Verify Degree of difficulty (index)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DegreeOfDifficultyDrivers)));
                Assert.That(driver.FindElement(By.XPath(Xpath.DegreeOfDifficultyDrivers)).Text.Replace("\r\n", " "), Is.EqualTo("Degree of difficulty"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: Degree of difficulty");

                Assert.That(driver.FindElement(By.XPath(Xpath.DegreeOfDifficultyValueDrivers)).Text, Is.EqualTo(Value.DegreeOfDifficulty));
                Console.WriteLine("Degree of difficulty (index) value = " + driver.FindElement(By.XPath(Xpath.DegreeOfDifficultyValueDrivers)).Text);


                // Verify CO2 emissions (g/km)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CO2EmissionsDrivers)));
                Assert.That(driver.FindElement(By.XPath(Xpath.CO2EmissionsDrivers)).Text.Replace("\r\n", " "), Is.EqualTo("CO2 emissions (g/km)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: CO2 emissions (g/km)");

                Assert.That(driver.FindElement(By.XPath(Xpath.CO2EmissionsValueDrivers)).Text, Is.EqualTo(Value.co2Emissions));
                Console.WriteLine("CO2 emissions (g/km) value = " + driver.FindElement(By.XPath(Xpath.CO2EmissionsValueDrivers)).Text);

                // Verify Vehicle care (index)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleCareDrivers)));
                Assert.That(driver.FindElement(By.XPath(Xpath.VehicleCareDrivers)).Text.Replace("\r\n", " "), Is.EqualTo("Vehicle care"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: Vehicle care");

                Assert.That(driver.FindElement(By.XPath(Xpath.VehicleCareValueDrivers)).Text, Is.EqualTo(Value.VehicleCare));
                Console.WriteLine("Vehicle care (index) value = " + driver.FindElement(By.XPath(Xpath.VehicleCareValueDrivers)).Text + "\r\n\r\n");

                // Collect all Drivers Ranking information
                System.Threading.Thread.Sleep(2000);
                wait.Until(ExpectedConditions.ElementExists(By.Id(Xpath.GridDrivers)));
                System.Threading.Thread.Sleep(2000);
                string valueStringOriginal = driver.FindElement(By.Id(Xpath.GridDrivers)).Text;
                Console.WriteLine("valueStringOriginal: " + valueStringOriginal);

                int characters = 702;
                if (Filters.Dashboard == "11")
                {
                    characters = 700;
                }
                else
                {
                }


                // Removing titles and labels from Ranking data
                string valueString = valueStringOriginal.Remove(0, characters);

                // Splitting values separating by \r\n
                string[] valueRanking = valueString.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                // Removing last two element: lines and pages number
                Array.Resize(ref valueRanking, valueRanking.Length - 5);

                //Initializing matrix of 15 lines and 35 columns
                int numColumn = 0;
                int numRow = 0;
                string[,] rankingMatrix = new string[15, 35];


                Console.WriteLine("Data comparison with dataset starting: \r\n");
                // Cycling over matrix
                foreach (var parameter in valueRanking)
                {
                    rankingMatrix[numRow, numColumn] = parameter;

                    // Comparison of ranking REAL DATA with DATASET
                    if (numColumn == 1 || numColumn == 25 || numColumn == 0 || numColumn == 24) // 24 e 25 name and surname of driver //0 e 1 nickaname and plate vehicle
                    {
                        if (rankingMatrix[numRow, numColumn] != null)
                        {
                            Console.WriteLine("The cell contains data > " + "Row: " + numRow + " & Column: " + numColumn + "= " + rankingMatrix[numRow, numColumn] + " not NULL");
                        }
                        else
                        {
                            Console.WriteLine("The cell is empty  > " + "Row: " + numRow + " & Column: " + numColumn + " = EMPTY");
                            failureFlag = 1;
                        }
                    }
                    else if (rankingMatrix[numRow, numColumn] == Value.datasetDriversMatrix[numRow, numColumn])
                    {
                        Console.WriteLine("Value coherent with dataset > " + "Row: " + numRow + " & Column: " + numColumn + " = " + rankingMatrix[numRow, numColumn] + " found / " + Value.datasetDriversMatrix[numRow, numColumn] + " expected");
                    }
                    else
                    {
                        Console.WriteLine("WRONG value has been found  > " + "Row: " + numRow + " & Column: " + numColumn + " = " + rankingMatrix[numRow, numColumn] + " found / " + Value.datasetDriversMatrix[numRow, numColumn] + " expected");
                        failureFlag = 1;
                    }

                    numColumn += 1;
                    if (numColumn == 35)
                    {
                        numRow += 1;
                        numColumn = 0;
                    }
                    else
                    { }
                }

                //Fail test if at least one value in the dataset comparison is wrong
                Assert.That(failureFlag == 0);
                Console.WriteLine("\r\nALL RANKING VALUES ARE COHERENT WITH DATASET");
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }

        public void RankingVehiclesWidget(Xpath__Ranking Xpath, Values__Ranking_Vehicles Value, Filter_Query_Params Filters)
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

                driver.Manage().Window.Maximize();
                js.ExecuteScript("document.body.style.zoom = '0.67'");

                //Scroll website
                Scroll(Xpath.VehiclesRankingTab);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehiclesRankingTab)));
                var widgetPosition = driver.FindElement(By.XPath(Xpath.VehiclesRankingTab));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", widgetPosition);

                // Zoom-out to see all data
                js.ExecuteScript("document.body.style.zoom = '0.10'");

                //Define flag to fail the test if at least one data of ranking fails
                int failureFlag = 0;

                // Open Vehicles Ranking
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehiclesRankingTab)));
                IWebElement VehiclesRankingTabButton = driver.FindElement(By.XPath(Xpath.VehiclesRankingTab));
                js.ExecuteScript("arguments[0].click();", VehiclesRankingTabButton);
                Console.WriteLine("Opened VEHICLES RANKING \r\n");


                // Open Ranking columns: Vehicle,Fuel Consumption,Driver, Mission, Behavior

                JSClickDropdownChoice(Xpath.VehicleVehicleButton, "VEHICLE column", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleVehicleButtonExpanded)));

                JSClickDropdownChoice(Xpath.VehicleFuelConsumptionButton, "FUEL CONSUMPTION column", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleFuelConsumptionButtonExpanded)));

                JSClickDropdownChoice(Xpath.VehicleDriverButton, "DRIVER column", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleDriverButtonExpanded)));

                JSClickDropdownChoice(Xpath.VehicleMissionButton, "MISSION column", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleMissionButtonExpanded)));

                JSClickDropdownChoice(Xpath.VehicleBehaviorButton, "BEHAVIOR column", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleBehaviorButtonExpanded)));



                // Verify Fuel saving score (driver related)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FuelSavingScoreVehicles)));
                Assert.That(driver.FindElement(By.XPath(Xpath.FuelSavingScoreVehicles)).Text.Replace("\r\n", " "), Is.EqualTo("Fuel saving score (driver related)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: Fuel saving score (driver related)");

                Assert.That(driver.FindElement(By.XPath(Xpath.FuelSavingScoreValueVehicles)).Text, Is.EqualTo(Value.fuelSavingScore));
                Console.WriteLine("Fuel saving score (driver related) value = " + driver.FindElement(By.XPath(Xpath.FuelSavingScoreValueVehicles)).Text);


                // Verify Average total fuel (l/100km)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.AverageTotalFuelVehicles)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.AverageTotalFuelVehicles)).Text.Replace("\r\n", " "), Is.EqualTo("Average total fuel (l/100km)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text:" + driver.FindElement(By.XPath(Xpath.AverageTotalFuelVehicles)).Text.Replace("\r\n", " "));

                Assert.That(driver.FindElement(By.XPath(Xpath.AverageTotalFuelValueVehicles)).Text, Is.EqualTo(Value.AverageTotalFuel));
                Console.WriteLine("Average total fuel (l/100km) value = " + driver.FindElement(By.XPath(Xpath.AverageTotalFuelValueVehicles)).Text);


                // Verify Degree of difficulty (index)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DegreeOfDifficultyVehicles)));
                Assert.That(driver.FindElement(By.XPath(Xpath.DegreeOfDifficultyVehicles)).Text.Replace("\r\n", " "), Is.EqualTo("Degree of difficulty"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: Degree of difficulty");

                Assert.That(driver.FindElement(By.XPath(Xpath.DegreeOfDifficultyValueVehicles)).Text, Is.EqualTo(Value.DegreeOfDifficulty));
                Console.WriteLine("Degree of difficulty (index) value = " + driver.FindElement(By.XPath(Xpath.DegreeOfDifficultyValueVehicles)).Text);


                // Verify CO2 emissions (g/km)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.CO2EmissionsVehicles)));
                Assert.That(driver.FindElement(By.XPath(Xpath.CO2EmissionsVehicles)).Text.Replace("\r\n", " "), Is.EqualTo("CO2 emissions (g/km)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: CO2 emissions (g/km)");

                Assert.That(driver.FindElement(By.XPath(Xpath.CO2EmissionsValueVehicles)).Text, Is.EqualTo(Value.co2Emissions));
                Console.WriteLine("CO2 emissions (g/km) value = " + driver.FindElement(By.XPath(Xpath.CO2EmissionsValueVehicles)).Text);

                // Verify Vehicle care (index)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleCareVehicles)));
                Assert.That(driver.FindElement(By.XPath(Xpath.VehicleCareVehicles)).Text.Replace("\r\n", " "), Is.EqualTo("Vehicle care"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: Vehicle care");

                Assert.That(driver.FindElement(By.XPath(Xpath.VehicleCareValueVehicles)).Text, Is.EqualTo(Value.VehicleCare));
                Console.WriteLine("Vehicle care (index) value = " + driver.FindElement(By.XPath(Xpath.VehicleCareValueVehicles)).Text + "\r\n\r\n");

                // Collect all Vehicle Ranking information
                System.Threading.Thread.Sleep(2000);
                wait.Until(ExpectedConditions.ElementExists(By.Id(Xpath.GridVehicles)));
                System.Threading.Thread.Sleep(2000);
                string valueStringOriginal = driver.FindElement(By.Id(Xpath.GridVehicles)).Text;

                Console.WriteLine("valueStringOriginal: " + valueStringOriginal);

                // Removing titles and labels from Ranking data
                int characters = 617;

                if (Filters.Dashboard == "11")
                {
                    characters = 615;
                }
                else
                {
                }

                string valueString = valueStringOriginal.Remove(0, characters);

                // Splitting values separating by \r\n
                string[] valueRanking = valueString.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                // Removing last two element: lines and pages number
                Array.Resize(ref valueRanking, valueRanking.Length - 5);

                //Initializing matrix of 15 lines and 32 columns
                int numColumn = 0;
                int numRow = 0;
                string[,] rankingMatrix = new string[15, 32];


                Console.WriteLine("Data comparison with dataset starting: \r\n");

                // Cycling over matrix
                foreach (var parameter in valueRanking)
                {
                    rankingMatrix[numRow, numColumn] = parameter;

                    // Comparison of ranking REAL DATA with DATASET
                    if (numColumn == 21 || numColumn == 20) //plate and nickname of vehicles
                    {
                        if (rankingMatrix[numRow, numColumn] != null)
                        {
                            Console.WriteLine("The cell contains data > " + "Row: " + numRow + " & Column: " + numColumn + " = " + rankingMatrix[numRow, numColumn] + " not NULL");
                        }
                        else
                        {
                            Console.WriteLine("The cell is empty  > " + "Row: " + numRow + " & Column: " + numColumn + " = EMPTY");
                            failureFlag = 1;
                        }
                    }
                    else if (rankingMatrix[numRow, numColumn] == Value.datasetVehiclesMatrix[numRow, numColumn])
                    {
                        Console.WriteLine("Value coherent with dataset > " + "Row: " + numRow + " & Column: " + numColumn + " = " + rankingMatrix[numRow, numColumn] + " found / " + Value.datasetVehiclesMatrix[numRow, numColumn] + " expected");
                    }
                    else
                    {
                        Console.WriteLine("WRONG value has been found  > " + "Row: " + numRow + " & Column: " + numColumn + " = " + rankingMatrix[numRow, numColumn] + " found / " + Value.datasetVehiclesMatrix[numRow, numColumn] + " expected");
                        failureFlag = 1;
                    }

                    numColumn += 1;
                    if (numColumn == 32)
                    {
                        numRow += 1;
                        numColumn = 0;
                    }
                    else
                    { }
                }

                //Fail test if at least one value in the dataset comparison is wrong
                Assert.That(failureFlag == 0);
                Console.WriteLine("\r\nALL RANKING VALUES ARE COHERENT WITH DATASET");
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }

        public void RankingVehiclesWidgetHeavyBus(Xpath__Ranking Xpath, Values__Ranking_Vehicles_HeavyBus Value, Filter_Query_Params Filters)
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

                driver.Manage().Window.Maximize();
                js.ExecuteScript("document.body.style.zoom = '0.67'");

                //Scroll website
                Scroll(Xpath.VehiclesRanking);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehiclesRanking)));
                var widgetPosition = driver.FindElement(By.XPath(Xpath.VehiclesRanking));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", widgetPosition);

                // Zoom-out to see all data
                js.ExecuteScript("document.body.style.zoom = '0.10'");

                // Verify 
                AssertElementIsEqualTo(Xpath.FuelSavingScoreValueVehiclesHeavyBus, Value.fuelSavingScore);

                // Verify 
                AssertElementIsEqualTo(Xpath.AverageTotalFuelValueVehiclesHeavyBus, Value.averageTotalFuel);

                // Verify 
                AssertElementIsEqualTo(Xpath.AverageSpeedValueVehiclesHeavyBus, Value.averageSpeed);

                // Verify 
                AssertElementIsEqualTo(Xpath.CO2EmissionsValueVehiclesHeavyBus, Value.co2Emissions);

                //Define flag to fail the test if at least one data of ranking fails
                int failureFlag = 0;

                // Open Vehicles Ranking
                Console.WriteLine("Opened VEHICLES RANKING \r\n");

                // Open Ranking columns: Vehicle,Fuel Consumption,Driver, Mission, Behavior

                JSClickDropdownChoice(Xpath.VehicleVehicleButton, "Vehicle column", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleVehicleButtonExpanded)));

                JSClickDropdownChoice(Xpath.VehicleDriverButton, "Mission column", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleDriverButtonExpanded)));

                JSClickDropdownChoice(Xpath.DrivingStyleEvaluation, "Driving style evaluation column", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DrivingStyleEvaluationButtonExpand)));

                // Collect all Vehicle Ranking information
                System.Threading.Thread.Sleep(2000);
                wait.Until(ExpectedConditions.ElementExists(By.Id(Xpath.GridVehicles)));
                System.Threading.Thread.Sleep(2000);
                string valueStringOriginal = driver.FindElement(By.Id(Xpath.GridVehicles)).Text;

                Console.WriteLine("valueStringOriginal: " + valueStringOriginal);

                // Removing titles and labels from Ranking data
                int characters = 440;

                if (Filters.Dashboard == "32")
                {
                    characters = 441;
                }
                else
                {
                }

                string valueString = valueStringOriginal.Remove(0, characters);

                // Splitting values separating by \r\n
                string[] valueRanking = valueString.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                // Removing last two element: lines and pages number
                Array.Resize(ref valueRanking, valueRanking.Length - 5);

                //Initializing matrix of 15 lines and 23 columns
                int numColumn = 0;
                int numRow = 0;
                string[,] rankingMatrix = new string[15, 22];


                Console.WriteLine("Data comparison with dataset starting: \r\n");

                // Cycling over matrix
                foreach (var parameter in valueRanking)
                {
                    rankingMatrix[numRow, numColumn] = parameter;

                    // Comparison of ranking REAL DATA with DATASET
                    if (numColumn == 14 || numColumn == 16) //plate and nickname of vehicles
                    {
                        if (rankingMatrix[numRow, numColumn] != null)
                        {
                            Console.WriteLine("The cell contains data > " + "Row: " + numRow + " & Column: " + numColumn + " = " + rankingMatrix[numRow, numColumn] + " not NULL");
                        }
                        else
                        {
                            Console.WriteLine("The cell is empty  > " + "Row: " + numRow + " & Column: " + numColumn + " = EMPTY");
                            failureFlag = 1;
                        }
                    }
                    else if (rankingMatrix[numRow, numColumn] == Value.datasetVehiclesMatrix[numRow, numColumn])
                    {
                        Console.WriteLine("Value coherent with dataset > " + "Row: " + numRow + " & Column: " + numColumn + " = " + rankingMatrix[numRow, numColumn] + " found / " + Value.datasetVehiclesMatrix[numRow, numColumn] + " expected");
                    }
                    else
                    {
                        Console.WriteLine("WRONG value has been found  > " + "Row: " + numRow + " & Column: " + numColumn + " = " + rankingMatrix[numRow, numColumn] + " found / " + Value.datasetVehiclesMatrix[numRow, numColumn] + " expected");
                        failureFlag = 1;
                    }

                    numColumn += 1;
                    if (numColumn == 22)
                    {
                        numRow += 1;
                        numColumn = 0;
                    }
                    else
                    { }
                }

                //Fail test if at least one value in the dataset comparison is wrong
                Assert.That(failureFlag == 0);
                Console.WriteLine("\r\nALL RANKING VALUES ARE COHERENT WITH DATASET");
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
        public void RankingVehiclesTwayWidget(Xpath__Ranking Xpath, Values__Ranking_Vehicles_Tway Value, Filter_Query_Params Filters)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                //Click two times on Menu
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);
                JSClickDropdownChoice("//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a", "Menu", 1000);

                // Wait until dashboard is visible
                VerifyElement(Xpath.DashboardView);

                // Navigate to filtered data
                FilterData(weburl_runsettings, Filters.Dashboard, Filters.Frequency, Filters.Vehicle_list, Filters.From_date, Filters.To_date, Filters.Vehicle_type, Filters.Fuel_type);

                driver.Manage().Window.Maximize();
                js.ExecuteScript("document.body.style.zoom = '0.67'");

                //verify presence of KPI Average Total Fuel Vehicles
                VerifyElement(Xpath.AverageTotalFuelVehiclesTway);

                // Zoom-out to see all data
                js.ExecuteScript("document.body.style.zoom = '0.10'");

                //Define flag to fail the test if at least one data of ranking fails
                int failureFlag = 0;

                // Open Ranking columns: Vehicle,Fuel Consumption,Driver, Mission, Behavior

                JSClickDropdownChoice(Xpath.VehicleVehicleButton, "VEHICLE column", 2000);
                VerifyElement(Xpath.VehicleVehicleButtonExpanded);

                JSClickDropdownChoice(Xpath.VehicleFuelConsumptionButton, "FUEL CONSUMPTION column", 2000);
                VerifyElement(Xpath.VehicleFuelConsumptionButtonExpanded);

                JSClickDropdownChoice(Xpath.VehicleDriverButton, "DRIVER column", 2000);
                VerifyElement(Xpath.VehicleDriverButtonExpanded);

                JSClickDropdownChoice(Xpath.VehicleMissionButton, "MISSION column", 2000);
                VerifyElement(Xpath.VehicleMissionButtonExpanded);

                JSClickDropdownChoice(Xpath.VehicleBehaviorButton, "BEHAVIOR column", 2000);
                VerifyElement(Xpath.VehicleBehaviorButtonExpanded);
                
                // Verify the presence of Associated Fleets Column
                AssertElementIsEqualTo(Xpath.AverageTotalFuelValueVehiclesTway, Value.AverageTotalFuel);

                // Verify Average total fuel (l/100km)
                AssertElementIsEqualTo(Xpath.PTOValueVehicles, Value.Pto);

                // Verify Degree of difficulty (index)
                AssertElementIsEqualTo(Xpath.IdlingValueVehicles, Value.Idiling);

                // Verify CO2 emissions (g/km)
                AssertElementIsEqualTo(Xpath.NOfStopsValueVehicles, Value.NumberOfStop);

                // Verify Vehicle care (index)
                AssertElementIsEqualTo(Xpath.CO2EmissionsValueVehiclesTway, Value.Co2Emissions);

                // Collect all Vehicle Ranking information
                System.Threading.Thread.Sleep(2000);
                wait.Until(ExpectedConditions.ElementExists(By.Id(Xpath.GridVehicles)));
                System.Threading.Thread.Sleep(2000);
                string valueStringOriginal = driver.FindElement(By.Id(Xpath.GridVehicles)).Text;

                Console.WriteLine("valueStringOriginal: " + valueStringOriginal);

                // Removing titles and labels from Ranking data
                int characters = 438;

                if (Filters.Dashboard == "11")
                {
                    characters = 615;
                }
                else
                {
                }
                System.Threading.Thread.Sleep(2000);

                string valueString = valueStringOriginal.Remove(0, characters);

                // Splitting values separating by \r\n
                string[] valueRanking = valueString.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                // Removing last two element: lines and pages number
                Array.Resize(ref valueRanking, valueRanking.Length - 5);

                //Initializing matrix of 15 lines and 32 columns
                int numColumn = 0;
                int numRow = 0;
                string[,] rankingMatrix = new string[15, 23];


                Console.WriteLine("Data comparison with dataset starting: \r\n");
                
                // Cycling over matrix
                foreach (var parameter in valueRanking)
                {
                    rankingMatrix[numRow, numColumn] = parameter;

                    // Comparison of ranking REAL DATA with DATASET
                    if (numColumn == 14 || numColumn == 16) //plate and nickname of vehicles
                    {
                        if (rankingMatrix[numRow, numColumn] != null)
                        {
                            Console.WriteLine("The cell contains data > " + "Row: " + numRow + " & Column: " + numColumn + " = " + rankingMatrix[numRow, numColumn] + " not NULL");
                        }
                        else
                        {
                            Console.WriteLine("The cell is empty  > " + "Row: " + numRow + " & Column: " + numColumn + " = EMPTY");
                            failureFlag = 1;
                        }
                    }
                    else if (rankingMatrix[numRow, numColumn] == Value.datasetVehiclesMatrix[numRow, numColumn])
                    {
                        Console.WriteLine("Value coherent with dataset > " + "Row: " + numRow + " & Column: " + numColumn + " = " + rankingMatrix[numRow, numColumn] + " found / " + Value.datasetVehiclesMatrix[numRow, numColumn] + " expected");
                    }
                    else
                    {
                        Console.WriteLine("WRONG value has been found  > " + "Row: " + numRow + " & Column: " + numColumn + " = " + rankingMatrix[numRow, numColumn] + " found / " + Value.datasetVehiclesMatrix[numRow, numColumn] + " expected");
                        failureFlag = 1;
                    }

                    numColumn += 1;
                    if (numColumn == 23)
                    {
                        numRow += 1;
                        numColumn = 0;
                    }
                    else
                    { }
                }

                //Fail test if at least one value in the dataset comparison is wrong
                Assert.That(failureFlag == 0);
                Console.WriteLine("\r\nALL RANKING VALUES ARE COHERENT WITH DATASET");
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
        public void RankingVehiclesWidgetLightElectric(Xpath__Ranking_Light Xpath, Values__Ranking_Vehicles_Light_Electric Value, Filter_Query_Params Filters)
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

                driver.Manage().Window.Maximize();
                js.ExecuteScript("document.body.style.zoom = '0.47'");

                //Scroll website
                Scroll(Xpath.VehiclesRanking);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehiclesRanking)));
                var widgetPosition = driver.FindElement(By.XPath(Xpath.VehiclesRanking));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", widgetPosition);

                // Zoom-out to see all data
                js.ExecuteScript("document.body.style.zoom = '0.05'");

   

                //Define flag to fail the test if at least one data of ranking fails
                int failureFlag = 0;

                // Open Vehicles Ranking
                Console.WriteLine("Opened VEHICLES RANKING \r\n");

                // Open Ranking columns: Vehicle, Mission, Behavior, Energy, Driver

                JSClickDropdownChoice(Xpath.VehicleVehicleButton, "Vehicle column", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleVehicleButtonExpanded)));

                JSClickDropdownChoice(Xpath.VehicleFuelConsumptionButton, "Energy", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleFuelConsumptionButtonExpanded)));

                JSClickDropdownChoice(Xpath.VehicleDriverButton, "Driver column", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleDriverButtonExpanded)));

                JSClickDropdownChoice(Xpath.VehicleBehaviorButton, "Behaviour", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleBehaviorButtonExpanded)));

                JSClickDropdownChoice(Xpath.VehicleMissionButton, "Mission", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleMissionButtonExpanded)));            
              

                // Collect all Vehicle Ranking information
                System.Threading.Thread.Sleep(3000);
                wait.Until(ExpectedConditions.ElementExists(By.Id(Xpath.GridVehicles)));
                System.Threading.Thread.Sleep(3000);
                string valueStringOriginal = driver.FindElement(By.Id(Xpath.GridVehicles)).Text;

                Console.WriteLine("valueStringOriginal: " + valueStringOriginal);

                // Removing titles and labels from Ranking data
                int characters = 1001;

                string valueString = valueStringOriginal.Remove(0, characters);

                // Splitting values separating by \r\n
                string[] valueRanking = valueString.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                // Removing last two element: lines and pages number
                Array.Resize(ref valueRanking, valueRanking.Length - 5);

                //Initializing matrix of 15 lines and 42 columns
                int numColumn = 0;
                int numRow = 0;
                string[,] rankingMatrix = new string[15, 43];


                Console.WriteLine("Data comparison with dataset starting: \r\n");

                // Cycling over matrix
                foreach (var parameter in valueRanking)
                {
                    rankingMatrix[numRow, numColumn] = parameter;

                    // Comparison of ranking REAL DATA with DATASET
                    if (numColumn == 31 || numColumn == 33) //plate and nickname of vehicles
                    {
                        if (rankingMatrix[numRow, numColumn] != null)
                        {
                            Console.WriteLine("The cell contains data > " + "Row: " + numRow + " & Column: " + numColumn + " = " + rankingMatrix[numRow, numColumn] + " not NULL");
                        }
                        else
                        {
                            Console.WriteLine("The cell is empty  > " + "Row: " + numRow + " & Column: " + numColumn + " = EMPTY");
                            failureFlag = 1;
                        }
                    }
                    else if (rankingMatrix[numRow, numColumn] == Value.datasetVehiclesMatrix[numRow, numColumn])
                    {
                        Console.WriteLine("Value coherent with dataset > " + "Row: " + numRow + " & Column: " + numColumn + " = " + rankingMatrix[numRow, numColumn] + " found / " + Value.datasetVehiclesMatrix[numRow, numColumn] + " expected");
                    }
                    else
                    {
                        Console.WriteLine("WRONG value has been found  > " + "Row: " + numRow + " & Column: " + numColumn + " = " + rankingMatrix[numRow, numColumn] + " found / " + Value.datasetVehiclesMatrix[numRow, numColumn] + " expected");
                        failureFlag = 1;
                    }

                    numColumn += 1;
                    if (numColumn == 43)
                    {
                        numRow += 1;
                        numColumn = 0;
                    }
                    else
                    { }
                }

                //Fail test if at least one value in the dataset comparison is wrong
                Assert.That(failureFlag == 0);
                Console.WriteLine("\r\nALL RANKING VALUES ARE COHERENT WITH DATASET");
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
        public void RankingVehiclesWidgetHeavyBusElectric(Xpath__Ranking Xpath, Values__Ranking_Vehicles_Light_Electric Value, Filter_Query_Params Filters)
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

                driver.Manage().Window.Maximize();
                js.ExecuteScript("document.body.style.zoom = '0.67'");

                //Scroll website
                Scroll(Xpath.VehiclesRanking);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehiclesRanking)));
                var widgetPosition = driver.FindElement(By.XPath(Xpath.VehiclesRanking));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", widgetPosition);

                // Zoom-out to see all data
                js.ExecuteScript("document.body.style.zoom = '0.10'");

                //Define flag to fail the test if at least one data of ranking fails
                int failureFlag = 0;

                // Open Ranking columns: Vehicle, Mission, Driving Style evaluation

                JSClickDropdownChoice(Xpath.VehicleVehicleButton, "Vehicle column", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleVehicleButtonExpanded)));

                JSClickDropdownChoice(Xpath.VehicleFuelConsumptionButton, "Mission column", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleFuelConsumptionButtonExpanded)));

                JSClickDropdownChoice(Xpath.VehicleDriverButton, "Driving style evaluation column", 2000);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleDriverButtonExpanded)));

                // Collect all Vehicle Ranking information
                System.Threading.Thread.Sleep(2000);
                wait.Until(ExpectedConditions.ElementExists(By.Id(Xpath.GridVehicles)));
                System.Threading.Thread.Sleep(2000);
                string valueStringOriginal = driver.FindElement(By.Id(Xpath.GridVehicles)).Text;

                Console.WriteLine("valueStringOriginal: " + valueStringOriginal);

                // Removing titles and labels from Ranking data
                int characters = 445;

                string valueString = valueStringOriginal.Remove(0, characters);

                // Splitting values separating by \r\n
                string[] valueRanking = valueString.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                // Removing last two element: lines and pages number
                Array.Resize(ref valueRanking, valueRanking.Length - 5);

                //Initializing matrix of 15 lines and 23 columns
                int numColumn = 0;
                int numRow = 0;
                string[,] rankingMatrix = new string[15, 22];


                Console.WriteLine("Data comparison with dataset starting: \r\n");

                // Cycling over matrix
                foreach (var parameter in valueRanking)
                {
                    rankingMatrix[numRow, numColumn] = parameter;

                    // Comparison of ranking REAL DATA with DATASET
                    if (numColumn == 11 || numColumn == 13) //plate and nickname of vehicles
                    {
                        if (rankingMatrix[numRow, numColumn] != null)
                        {
                            Console.WriteLine("The cell contains data > " + "Row: " + numRow + " & Column: " + numColumn + " = " + rankingMatrix[numRow, numColumn] + " not NULL");
                        }
                        else
                        {
                            Console.WriteLine("The cell is empty  > " + "Row: " + numRow + " & Column: " + numColumn + " = EMPTY");
                            failureFlag = 1;
                        }
                    }
                    else if (rankingMatrix[numRow, numColumn] == Value.datasetVehiclesMatrix[numRow, numColumn])
                    {
                        Console.WriteLine("Value coherent with dataset > " + "Row: " + numRow + " & Column: " + numColumn + " = " + rankingMatrix[numRow, numColumn] + " found / " + Value.datasetVehiclesMatrix[numRow, numColumn] + " expected");
                    }
                    else
                    {
                        Console.WriteLine("WRONG value has been found  > " + "Row: " + numRow + " & Column: " + numColumn + " = " + rankingMatrix[numRow, numColumn] + " found / " + Value.datasetVehiclesMatrix[numRow, numColumn] + " expected");
                        failureFlag = 1;
                    }

                    numColumn += 1;
                    if (numColumn == 22)
                    {
                        numRow += 1;
                        numColumn = 0;
                    }
                    else
                    { }
                }

                //Fail test if at least one value in the dataset comparison is wrong
                Assert.That(failureFlag == 0);
                Console.WriteLine("\r\nALL RANKING VALUES ARE COHERENT WITH DATASET");
            }

            catch (Exception e)
            {
                GetScreenshotAndPrintError(e);
            }
            driver.Close();
        }
    }
}