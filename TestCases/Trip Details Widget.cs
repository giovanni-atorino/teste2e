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
    public class Trip_Details_Widget: BaseClass
    {
        
        static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
        public void TripDetailsWidget(Xpath__Trip_Details Xpath, Values__Trip_details Value, Filter_Query_Params Filters)
        {

            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                // Wait until dashboard is visible
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.DashboardView)));

                // Navigate to filtered data
                FilterData(weburl_runsettings, Filters.Dashboard, Filters.Frequency, Filters.Vehicle_list, Filters.From_date, Filters.To_date, Filters.Vehicle_type, Filters.Fuel_type);

                js.ExecuteScript("document.body.style.zoom = '0.67'");
                driver.Manage().Window.Maximize();

                //Scroll website
                Scroll(Xpath.TripDetailsTab);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.TripDetailsTab)));
                var widgetPosition = driver.FindElement(By.XPath(Xpath.TripDetailsTab));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", widgetPosition);

                // Zoom out to see all data
                js.ExecuteScript("document.body.style.zoom = '0.10'");

                // Define flag to fail the test if at least one data of ranking fails
                int failureFlag = 0;

                // Open Ranking columns: Vehicle, Mission, Fuel Consumption
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleButton)));
                System.Threading.Thread.Sleep(2000);
                IWebElement VehicleContractedButton = driver.FindElement(By.XPath(Xpath.VehicleButton));
                js.ExecuteScript("arguments[0].click();", VehicleContractedButton);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.VehicleButtonExpanded)));
                Console.WriteLine("Opened VEHICLE column ");

                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.MissionButton)));
                System.Threading.Thread.Sleep(2000);
                IWebElement MissionContractedButton = driver.FindElement(By.XPath(Xpath.MissionButton));
                js.ExecuteScript("arguments[0].click();", MissionContractedButton);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.MissionButtonExpanded)));
                Console.WriteLine("Opened MISSION column");

                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FuelConsumptionButton)));
                System.Threading.Thread.Sleep(2000);
                IWebElement FuelConsumptionContractedButton = driver.FindElement(By.XPath(Xpath.FuelConsumptionButton));
                js.ExecuteScript("arguments[0].click();", FuelConsumptionContractedButton);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FuelConsumptionButtonExpanded)));
                Console.WriteLine("Opened FUEL CONSUMPTION column \r\n\r\n");


                // Verify Eco Score
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.EcoScore)));
                Assert.That(driver.FindElement(By.XPath(Xpath.EcoScore)).Text.Replace("\r\n", " "), Is.EqualTo("Eco score"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: Eco score");

                Assert.That(driver.FindElement(By.XPath(Xpath.EcoScoreValue)).Text, Is.EqualTo(Value.ecoScore));
                Console.WriteLine("Eco score value = " + driver.FindElement(By.XPath(Xpath.EcoScoreValue)).Text);


                // Verify Fuel consumption (l/100km or kg/100km)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.FuelConsumption)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.FuelConsumption)).Text.Replace("\r\n", " "), Is.EqualTo("Fuel consumption (l/100km)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: " + driver.FindElement(By.XPath(Xpath.FuelConsumption)).Text.Replace("\r\n", " "));

                Assert.That(driver.FindElement(By.XPath(Xpath.FuelConsumptionValue)).Text, Is.EqualTo(Value.fuelConsumption));
                Console.WriteLine("\r\n" + driver.FindElement(By.XPath(Xpath.FuelConsumption)).Text.Replace("\r\n", " ") + ": " + driver.FindElement(By.XPath(Xpath.FuelConsumptionValue)).Text);

                // Verify Total trip time (hh:mm:ss) or (dd:hh:mm)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.TotalTripTime)));
                //Assert.That(driver.FindElement(By.XPath(Xpath.TotalTripTime)).Text.Replace("\r\n", " "), Is.EqualTo("Total trip time (hh:mm:ss)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text:" + driver.FindElement(By.XPath(Xpath.TotalTripTime)).Text.Replace("\r\n", " "));

                Assert.That(driver.FindElement(By.XPath(Xpath.TotalTripTimeValue)).Text, Is.EqualTo(Value.totalTripTime));
                Console.WriteLine("\r\n" + driver.FindElement(By.XPath(Xpath.TotalTripTime)).Text.Replace("\r\n", " ") + ": " + driver.FindElement(By.XPath(Xpath.TotalTripTimeValue)).Text);

                // Verify Average speed (km/h)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.AverageSpeed)));
                Assert.That(driver.FindElement(By.XPath(Xpath.AverageSpeed)).Text.Replace("\r\n", " "), Is.EqualTo("Average speed (km/h)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: Average speed (km/h)");

                Assert.That(driver.FindElement(By.XPath(Xpath.AverageSpeedValue)).Text, Is.EqualTo(Value.averageSpeed));
                Console.WriteLine("Average speed (km/h) value = " + driver.FindElement(By.XPath(Xpath.AverageSpeedValue)).Text);


                // Verify CO2 emissions (kg)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.Co2Emissions)));
                Assert.That(driver.FindElement(By.XPath(Xpath.Co2Emissions)).Text.Replace("\r\n", " "), Is.EqualTo("CO2 emissions (kg)"));
                Console.WriteLine("\r\n" + "Verified presence of correct text: CO2 emissions (kg)");

                Assert.That(driver.FindElement(By.XPath(Xpath.Co2EmissionsValue)).Text, Is.EqualTo(Value.co2Emissions));
                Console.WriteLine("CO2 emissions (kg) value = " + driver.FindElement(By.XPath(Xpath.Co2EmissionsValue)).Text + "\r\n\r\n");




                // Collect all Trip Details information
                System.Threading.Thread.Sleep(2000);
                wait.Until(ExpectedConditions.ElementExists(By.Id(Xpath.GridTrips)));
                System.Threading.Thread.Sleep(2000);
                string valueStringOriginal = driver.FindElement(By.Id(Xpath.GridTrips)).Text;
                Console.WriteLine("valueStringOriginal: " + valueStringOriginal);

                //The value change if Fuel consumption is in kg/100 km or l/100km
                // Removing titles and labels from Tri details data
                int characters = 308;

                if (Filters.Dashboard == "22")
                {
                    characters = 310;
                }
                else
                {
                }

                string valueString = valueStringOriginal.Remove(0, characters);

                // Splitting values separating by \r\n
                string[] valueRanking = valueString.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                // Removing last elements: lines and pages number
                Array.Resize(ref valueRanking, valueRanking.Length - 5);

                //Initializing matrix of 15 lines and 15 columns
                int numColumn = 0;
                int numRow = 0;
                string[,] tripDetailsMatrix = new string[15, 15];


                Console.WriteLine("Data comparison with dataset starting: \r\n");

                // Cycling over matrix
                foreach (var parameter in valueRanking)
                {
                    tripDetailsMatrix[numRow, numColumn] = parameter;

                    // Comparison of trip details REAL DATA with DATASET
                    if (tripDetailsMatrix[numRow, numColumn] == Value.datasetTripDetailsMatrix[numRow, numColumn])
                    {

                        Console.WriteLine("Value coherent with dataset > " + "Row: " + numRow + " & Column: " + numColumn + " = " + tripDetailsMatrix[numRow, numColumn] + " found / " + Value.datasetTripDetailsMatrix[numRow, numColumn] + " expected");
                    }
                    else
                    {
                        Console.WriteLine("WRONG value has been found  > " + "Row: " + numRow + " & Column: " + numColumn + " = " + tripDetailsMatrix[numRow, numColumn] + " found / " + Value.datasetTripDetailsMatrix[numRow, numColumn] + " expected");
                        failureFlag = 1;
                    }

                    numColumn += 1;
                    if (numColumn == 15)
                    {
                        numRow += 1;
                        numColumn = 0;
                    }
                    else
                    { }
                }

                Console.WriteLine("Close for cycle");

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