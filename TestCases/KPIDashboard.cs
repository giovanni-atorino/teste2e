using myiveco_selenium.Functions;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Chrome;
using System.Windows;
using myiveco_selenium.Filters;
using System.Collections.Generic;


namespace myiveco_selenium
{
	public class KPI_Dashboard : BaseClass
	{

		static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
		public KPI_Dashboard(Account Account) : base(Account) { }
		public KPI_Dashboard()
		{
		}

		public void KPIDashboardHeavy(Xpath__Score_Summary XpathSS, Xpath__Ranking XpathRanking, Xpath__CO2_Emissions XpathCE, Xpath__DSE XpathDSEH, Xpath__Fuel_Consumption XpathFC, String Dashboard)
		{
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
				System.Threading.Thread.Sleep(5000);

				//Verify that the dashboard has data in the widget: 
				int NoDataFlag = VerifyData();

				if (NoDataFlag == 0)
				{

					String ScoreSummaryWidget = "Score Summary";
					Console.WriteLine("Starting to verify KPI in " + ScoreSummaryWidget + " widget");
					System.Threading.Thread.Sleep(5000);
					// Verify Fuel saving score (driver related)
					wait.Until(ExpectedConditions.ElementExists(By.CssSelector(XpathSS.FuelSavingScore)));
					Console.WriteLine("Verified presence of Score Summary");

					List<string> FuelSavingScore = new List<string>(new string[] { XpathSS.FuelSavingScoreValue, "Fuel Saving Score" });
					List<string> FuelConsumption = new List<string>(new string[] { XpathSS.FuelConsuptionValue, "Fuel Consumption" });
					List<string> DegreeOfDifficulty = new List<string>(new string[] { XpathSS.DegreeOfDifficultyValue, "Degree Of Difficulty" });
					List<string> AverageGrossCombination = new List<string>(new string[] { XpathSS.AverageGrossCombinationWeightValue, "Average Gross Combination Weight" });
					List<string> AverageDistancePerUnit = new List<string>(new string[] { XpathSS.AverageDistancePerUnitValue, "Average Distance Per Unit" });
					List<string> CO2Emissions = new List<string>(new string[] { XpathSS.CO2EmissionsValue, "CO2 Emissions" });

					List<List<string>> ScoreSummaryMatrix = new List<List<string>>(new List<string>[] { FuelConsumption, AverageGrossCombination, AverageDistancePerUnit, CO2Emissions });
					int flagNegativeValue = NegativeValuesCheckCssSelector(ScoreSummaryWidget, ScoreSummaryMatrix);

					//Verify that the Fuel saving score is a valid integer
					Console.WriteLine("Verification that all index on Score Summary widget are a base-100 index");

					List<List<string>> ScoreSummaryIndex = new List<List<string>>(new List<string>[1]);
					if (driver.FindElement(By.CssSelector(FuelSavingScore[0])).Text == "-")
					{
						Console.WriteLine(FuelSavingScore[1] + " KPI of Score Summary is -");
						ScoreSummaryIndex = new List<List<string>>(new List<string>[] { DegreeOfDifficulty });

					}

					else
					{
						ScoreSummaryIndex = new List<List<string>>(new List<string>[] { FuelSavingScore, DegreeOfDifficulty });
					}

					//Verify that all index on Score Summary are a base-100 index
					int flagNotIndexValue = IndexValuesCheckCssSelector(ScoreSummaryWidget, ScoreSummaryIndex);

					System.Threading.Thread.Sleep(1000);


					//Scroll website
					ScrollFunction();

					Console.WriteLine("\r\n CO2 Emissions widget");
					Scroll(XpathCE.CO2Emissions);
					var CO2widgetPosition = driver.FindElement(By.XPath(XpathCE.CO2Emissions));
					js.ExecuteScript("arguments[0].scrollIntoView(true);", CO2widgetPosition);

					// Verified widget presence: CO2 Emissions
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathCE.CO2Emissions)));
					Console.WriteLine("Verified presence of CO2 Emissions widget");

					// Verified KPI emissions 
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathCE.EmissionsValue)));

					String CO2EmissionsString = driver.FindElement(By.XPath(XpathCE.EmissionsValue)).Text;
					double CO2EmissionsValue = 0;
					if (Double.TryParse(CO2EmissionsString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out CO2EmissionsValue))
					{
						if (CO2EmissionsValue >= 0)
						{
							Console.WriteLine("CO2 Emissions KPI is a positive value: " + CO2EmissionsValue);
						}
						else
						{
							flagNegativeValue++;

							Console.WriteLine("CO2 Emissions KPI of Score Summary is a negative value: " + CO2EmissionsValue);
						}
					}

					else
					{
						Console.WriteLine("Error parsing for " + CO2EmissionsValue);
					}

					Console.WriteLine("\r\n Fuel Consumption widget");

                    // Fuel Consumption
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathFC.FuelConsumption)));

                    // Verified KPI Fue Consumption 
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathFC.AverageFleetValueKPI)));

					String FuelConsumptionString = driver.FindElement(By.XPath(XpathFC.AverageFleetValueKPI)).Text;

					//Remove unit of measure
					//if (Dashboard == "11")
					//{
						//Remove unit of Measure: l/100km
						//FuelConsumptionString = driver.FindElement(By.XPath(XpathFC.AverageFleetValue)).Text.Replace(" l/100km", "");
					//}
					//else
					//{
						//Remove unit of Measure: kg/100km
						//FuelConsumptionString = driver.FindElement(By.XPath(XpathFC.AverageFleetValue)).Text.Replace(" kg/100km", "");
					//}

					double FuelConsumptionValue = 0;
					if (Double.TryParse(FuelConsumptionString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out FuelConsumptionValue))
					{

						if (FuelConsumptionValue >= 0)
						{
							Console.WriteLine("Fuel consumption KPI is a positive value: " + FuelConsumptionValue);
						}
						else
						{
							flagNegativeValue++;

							Console.WriteLine("Fuel consumption KPI is a negative value: " + FuelConsumptionValue);

						}
					}

					else
					{
						Console.WriteLine("Error parsing for " + FuelConsumptionValue);
					}

					// DSE KPI
					Console.WriteLine("\r\n DSE widget");
					Scroll(XpathDSEH.DSEDriverRelatedLabelPath);
					// Driving Style Evaluation (driver related)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathDSEH.DSEDriverRelatedLabelPath)));
					Console.WriteLine("Verified presence of widget Driving Style Evaluation (driver related)");

					List<string> FuelSavingScoreDSE = new List<string>(new string[] { XpathDSEH.FuelSavingScoreValuePath, "Fuel Saving Score" });
					List<string> Acceleration = new List<string>(new string[] { XpathDSEH.AccelerationValuePath, "Acceleration" });
					List<string> Deceleration = new List<string>(new string[] { XpathDSEH.DecelerationValuePath, "Deceleration" });
					List<string> EngineUse = new List<string>(new string[] { XpathDSEH.EngineUseValuePath, "Engine Use" });
					List<string> VehicleCareScore = new List<string>(new string[] { XpathDSEH.VehicleCareScoreValuePath, "Vehicle Care Score" });
					List<string> BrakeUse = new List<string>(new string[] { XpathDSEH.BrakeUseValuePath, "Brake Use" });
					List<string> Tyres = new List<string>(new string[] { XpathDSEH.TyresValuePath, "Tyres" });
					List<string> SafeDrivingScore = new List<string>(new string[] { XpathDSEH.SafeDrivingScoreValuePath, "Safe Driving Score" });

					List<List<string>> DSEMatrix = new List<List<string>>(new List<string>[] { FuelSavingScoreDSE, Acceleration, Deceleration, EngineUse, VehicleCareScore, BrakeUse, Tyres, SafeDrivingScore });


					System.Threading.Thread.Sleep(1000);
					String DSEWidget = "DSE";

					int DSEtrattino = 0;
					foreach (List<string> DSEData in DSEMatrix)
					{
						String DSEString = driver.FindElement(By.XPath(DSEData[0])).Text;


						if (DSEString == "-")
						{
							Console.WriteLine(DSEData[1] + " KPI of DSE is -");

						}

						else
						{
							DSEtrattino++;
						}

					}

					if (DSEtrattino != 0)
					{
						Console.WriteLine("Verification that all index on " + DSEWidget + " are a base-100 index");

						int flagNotIndexValue1 = IndexValuesCheckXPath(DSEWidget, DSEMatrix);
						flagNotIndexValue += flagNotIndexValue1;
					}
					// Ranking Drivers
					Console.WriteLine("\r\n" + "Drivers Ranking");
					Scroll(XpathRanking.FuelSavingScoreDrivers);
					// Verify Fuel saving score (driver related)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.FuelSavingScoreDrivers)));
					Console.WriteLine("Verified the presence of Driver Ranking");

					List<string> FuelSavingScoreDR = new List<string>(new string[] { XpathRanking.FuelSavingScoreValueDrivers, "Fuel Saving Score(driver related)" });
					List<string> AverageTotalFuelDR = new List<string>(new string[] { XpathRanking.AverageTotalFuelValueDrivers, "Average Total Fuel" });
					List<string> DegreeOfDifficultyDR = new List<string>(new string[] { XpathRanking.DegreeOfDifficultyValueDrivers, "Deceleration" });
					List<string> CO2EmissionsDR = new List<string>(new string[] { XpathRanking.CO2EmissionsValueDrivers, "CO2 Emissions" });
					List<string> VehicleCareScoreDR = new List<string>(new string[] { XpathRanking.VehicleCareValueDrivers, "Vehicle Care Score" });

					List<List<string>> DriverRankingMatrix = new List<List<string>>(new List<string>[] { AverageTotalFuelDR, CO2EmissionsDR });

					Console.WriteLine("Verification that all Ranking Driver values are positive");
					foreach (List<string> DriverRankingData in DriverRankingMatrix)
					{
						String DriverRankingString = driver.FindElement(By.XPath(DriverRankingData[0])).Text;
						if (DriverRankingString == "-")
						{
							Console.WriteLine(DriverRankingData[1] + " KPI of Driver Ranking is -");

						}

						else
						{
							double DriverRankingValue = 0;
							if (Double.TryParse(DriverRankingString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out DriverRankingValue))
							{
								if (DriverRankingValue >= 0)
								{
									Console.WriteLine(DriverRankingData[1] + " KPI of Driver Ranking is a positive value: " + DriverRankingValue);
								}
								else
								{
									flagNegativeValue++;

									Console.WriteLine(DriverRankingData[1] + " KPI of Driver Ranking is a negative value: " + DriverRankingValue);
								}
							}

							else
							{
								Console.WriteLine("Error parsing for " + DriverRankingData[1]);
							}
						}

					}

					Console.WriteLine("Verification that all index on Driver Ranking widget are a base-100 index");
					List<List<string>> DriverRankingIndex = new List<List<string>>(new List<string>[] { FuelSavingScoreDR, DegreeOfDifficultyDR, VehicleCareScoreDR });

					foreach (List<string> DriverRankingData in DriverRankingIndex)
					{
						String DriverRankingString = driver.FindElement(By.XPath(DriverRankingData[0])).Text;
						if (DriverRankingString == "-")
						{
							Console.WriteLine(DriverRankingData[1] + " KPI of Driver Ranking is -");

						}

						else
						{
							double DriverRankingValue = 0;
							if (Double.TryParse(DriverRankingString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out DriverRankingValue))
							{
								if (DriverRankingValue >= 0 && DriverRankingValue <= 100)
								{
									Console.WriteLine(DriverRankingData[1] + " KPI of Ranking Drivers is a base-100 index: " + DriverRankingValue);
								}
								else
								{
									flagNotIndexValue++;

									Console.WriteLine(DriverRankingData[1] + " KPI of Ranking Drivers is NOT a base-100 index: " + DriverRankingValue);

								}
							}


							else
							{
								Console.WriteLine("Error parsing for " + DriverRankingData[1]);
							}
						}
					}
					//js.ExecuteScript("document.body.style.zoom = '0.10'");
					System.Threading.Thread.Sleep(1000);

					// Vehicles Ranking
					Console.WriteLine("\r\n" + "Vehicles Ranking");
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.VehiclesRankingTab)));
					IWebElement VehiclesRankingTabButton = driver.FindElement(By.XPath(XpathRanking.VehiclesRankingTab));
					js.ExecuteScript("arguments[0].click();", VehiclesRankingTabButton);
					Console.WriteLine("Verified the presence of Vehicles Ranking");

					List<string> FuelSavingScoreVR = new List<string>(new string[] { XpathRanking.FuelSavingScoreValueVehicles, "Fuel Saving Score(driver related)" });
					List<string> AverageTotalFuelVR = new List<string>(new string[] { XpathRanking.AverageTotalFuelValueVehicles, "Average Total Fuel" });
					List<string> DegreeOfDifficultyVR = new List<string>(new string[] { XpathRanking.DegreeOfDifficultyValueVehicles, "Deceleration" });
					List<string> CO2EmissionsVR = new List<string>(new string[] { XpathRanking.CO2EmissionsValueVehicles, "CO2 Emissions" });
					List<string> VehicleCareScoreVR = new List<string>(new string[] { XpathRanking.VehicleCareValueVehicles, "Vehicle Care Score" });
					List<List<string>> VehicleRankingMatrix = new List<List<string>>(new List<string>[] { AverageTotalFuelVR, CO2EmissionsVR });

					Console.WriteLine("Verification that all Ranking Vehicles values are positive");
					foreach (List<string> VehicleRankingData in VehicleRankingMatrix)
					{
						String VehicleRankingString = driver.FindElement(By.XPath(VehicleRankingData[0])).Text;
						double VehicleRankingValue = 0;
						if (Double.TryParse(VehicleRankingString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out VehicleRankingValue))
						{
							if (VehicleRankingValue >= 0)
							{
								Console.WriteLine(VehicleRankingData[1] + " KPI of Vehicles Ranking is a positive value: " + VehicleRankingValue);
							}
							else
							{
								flagNegativeValue++;
								Console.WriteLine(VehicleRankingData[1] + " KPI of Vehicles Ranking is a negative value: " + VehicleRankingValue);

							}
						}


						else
						{
							Console.WriteLine("Error parsing for " + VehicleRankingData[1]);
						}
					}


					Console.WriteLine("Verification that all index on Vehicles Ranking widget are a base-100 index");
					List<List<string>> VehicleRankingIndex = new List<List<string>>(new List<string>[] { FuelSavingScoreVR, DegreeOfDifficultyVR, VehicleCareScoreVR });

					foreach (List<string> VehicleRankingData in VehicleRankingIndex)
					{
						String VehicleRankingString = driver.FindElement(By.XPath(VehicleRankingData[0])).Text;
						double VehicleRankingValue = 0;
						if (Double.TryParse(VehicleRankingString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out VehicleRankingValue))
						{
							if (VehicleRankingValue >= 0 && VehicleRankingValue <= 100)
							{
								Console.WriteLine(VehicleRankingData[1] + " KPI of Vehicles Ranking is a base-100 index: " + VehicleRankingValue);
							}
							else
							{
								flagNotIndexValue++;
								Console.WriteLine(VehicleRankingData[1] + " KPI of Vehicles Ranking is NOT a base-100 index: " + VehicleRankingValue);
							}
						}


						else
						{
							Console.WriteLine("Error parsing for " + VehicleRankingData[1]);
						}

					}

					if (flagNegativeValue != 0)
					{

						Assert.Fail("Test failed. One values is negative");
					}

					if (flagNotIndexValue != 0)
					{

						Assert.Fail("Test failed. One index is not a base-100 index ");
					}
				}
				else
				{
					Console.WriteLine("No check can be perfomed - Data is not available in the dashboard");
				}
			}

			catch (Exception e)
			{
				Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
				String ScreenShotName = "ErrorScreenshot_" + DateTime.Now.ToString("HHmmss") + ".png";
				ss.SaveAsFile(ScreenShotName, ScreenshotImageFormat.Png);
				TestContext.AddTestAttachment(ScreenShotName, "Screenshot for failure analysis");
				Console.WriteLine("Test failed");
				Console.WriteLine(e.StackTrace);
				Assert.Fail("Test failed. See test output and attachment for analysis");
			}

		}

		public void KPIDashboardTway(Xpath__Score_Summary XpathSS, Xpath__Ranking XpathRanking, Xpath__CO2_Emissions XpathCE, Xpath__Fuel_Consumption XpathFC, String Dashboard)
		{
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
				System.Threading.Thread.Sleep(5000);

				//Verify that the dashboard has data in the widget: 
				int NoDataFlag = VerifyData();

				if (NoDataFlag == 0)
				{
					String ScoreSummaryWidget = "Score Summary";
					Console.WriteLine("Starting to verify KPI in " + ScoreSummaryWidget + " widget");
					// Verify Fuel saving score (driver related)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathSS.FuelConsuptionTway)));
					Console.WriteLine("Verified presence of Score Summary");

					List<string> FuelConsumption = new List<string>(new string[] { XpathSS.FuelConsuptionValueTway, "Fuel Consumption" });
					List<string> AverageDistancePerUnit = new List<string>(new string[] { XpathSS.AverageDistancePerUnitValueTway, "Average Distance Per Unit" });
					List<string> AverageGrossCombination = new List<string>(new string[] { XpathSS.AverageGrossCombinationWeightValueTway, "Average Gross Combination Weight" });
					List<string> AverageSpeed = new List<string>(new string[] { XpathSS.AverageSpeedValue, "Average Speed" });
					List<string> CO2Emissions = new List<string>(new string[] { XpathSS.CO2EmissionsValueTway, "CO2 Emissions" });
					List<List<string>> ScoreSummaryMatrix = new List<List<string>>(new List<string>[] { FuelConsumption, AverageDistancePerUnit, AverageGrossCombination, AverageSpeed, CO2Emissions });

					//Verify that all values in Score Summary are not negative
					int flagNegativeValue = NegativeValuesCheckXpath(ScoreSummaryWidget, ScoreSummaryMatrix);

					//Scroll website
					ScrollFunction();

					Console.WriteLine("\r\n CO2 Emissions widget");
					Scroll(XpathCE.CO2Emissions);
					var CO2widgetPosition = driver.FindElement(By.XPath(XpathCE.CO2Emissions));
					js.ExecuteScript("arguments[0].scrollIntoView(true);", CO2widgetPosition);

					// Verified widget presence: CO2 Emissions
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathCE.CO2Emissions)));
					Console.WriteLine("Verified presence of CO2 Emissions widget");

					// Verified KPI emissions 
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathCE.EmissionsValue)));

					String CO2EmissionsString = driver.FindElement(By.XPath(XpathCE.EmissionsValue)).Text;
					double CO2EmissionsValue = 0;
					if (Double.TryParse(CO2EmissionsString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out CO2EmissionsValue))
					{
						if (CO2EmissionsValue >= 0)
						{
							Console.WriteLine("CO2 Emissions KPI is a positive value: " + CO2EmissionsValue);
						}
						else
						{
							flagNegativeValue++;

							Console.WriteLine("CO2 Emissions KPI of Score Summary is a negative value: " + CO2EmissionsValue);
						}
					}

					else
					{
						Console.WriteLine("Error parsing for " + CO2EmissionsValue);
					}

					Console.WriteLine("\r\n Fuel Consumption widget");
					// Fuel Consumption
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathFC.FuelConsumption)));
					Console.WriteLine("Verified presence of Fuel Consumption widget");

					// Verified Fuel Consumption KPI
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathFC.AverageFleetValue)));

					String FuelConsumptionString = "";
					//Remove unit of measure: l/100km
					FuelConsumptionString = driver.FindElement(By.XPath(XpathFC.AverageFleetValue)).Text.Replace(" l/100km", "");


					double FuelConsumptionValue = 0;
					if (Double.TryParse(FuelConsumptionString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out FuelConsumptionValue))
					{

						if (FuelConsumptionValue >= 0)
						{
							Console.WriteLine("Fuel consumption KPI is a positive value: " + FuelConsumptionValue);
						}
						else
						{
							flagNegativeValue++;

							Console.WriteLine("Fuel consumption KPI is a negative value: " + FuelConsumptionValue);

						}
					}

					else
					{
						Console.WriteLine("Error parsing for " + FuelConsumptionValue);
					}


					// Vehicles Ranking
					Console.WriteLine("\r\n" + "Vehicles Ranking");
					Scroll(XpathRanking.AverageTotalFuelValueVehiclesTway);
					Console.WriteLine("Verified the presence of Vehicles Ranking");

					List<string> AverageTotalFuelVR = new List<string>(new string[] { XpathRanking.AverageTotalFuelValueVehiclesTway, "Fuel Saving Score(driver related)" });
					List<string> PTOVR = new List<string>(new string[] { XpathRanking.PTOValueVehicles, "PTO" });
					List<string> IdlingVR = new List<string>(new string[] { XpathRanking.IdlingValueVehicles, "Idling" });
					List<string> NOfStopsVR = new List<string>(new string[] { XpathRanking.NOfStopsValueVehicles, "Numeb of stops" });
					List<string> CO2EmissionsVR = new List<string>(new string[] { XpathRanking.CO2EmissionsValueVehicles, "CO2 Emissions" });
					List<List<string>> VehicleRankingMatrix = new List<List<string>>(new List<string>[] { AverageTotalFuelVR, NOfStopsVR, CO2EmissionsVR });

					Console.WriteLine("Verification that all Ranking Vehicles values are positive");
					foreach (List<string> VehicleRankingData in VehicleRankingMatrix)
					{
						String VehicleRankingString = driver.FindElement(By.XPath(VehicleRankingData[0])).Text;
						double VehicleRankingValue = 0;
						if (Double.TryParse(VehicleRankingString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out VehicleRankingValue))
						{
							if (VehicleRankingValue >= 0)
							{
								Console.WriteLine(VehicleRankingData[1] + " KPI of Vehicles Ranking is a positive value: " + VehicleRankingValue);
							}
							else
							{
								flagNegativeValue++;
								Console.WriteLine(VehicleRankingData[1] + " KPI of Vehicles Ranking is a negative value: " + VehicleRankingValue);

							}
						}


						else
						{
							Console.WriteLine("Error parsing for " + VehicleRankingData[1]);
						}
					}


					Console.WriteLine("Verification that all index on Vehicles Ranking widget are a base-100");
					List<List<string>> VehicleRankingIndex = new List<List<string>>(new List<string>[] { PTOVR, IdlingVR });
					int flagNotIndexValue = 0;
					foreach (List<string> VehicleRankingData in VehicleRankingIndex)
					{
						String VehicleRankingString = driver.FindElement(By.XPath(VehicleRankingData[0])).Text;
						double VehicleRankingValue = 0;

						if (Double.TryParse(VehicleRankingString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out VehicleRankingValue))
						{
							if (VehicleRankingValue >= 0 && VehicleRankingValue <= 100)
							{
								Console.WriteLine(VehicleRankingData[1] + " KPI of Vehicles Ranking is a base-100 index: " + VehicleRankingValue);
							}
							else
							{
								flagNotIndexValue++;
								Console.WriteLine(VehicleRankingData[1] + " KPI of Vehicles Ranking is NOT a base-100 index: " + VehicleRankingValue);
							}
						}


						else
						{
							Console.WriteLine("Error parsing for " + VehicleRankingData[1]);
						}

					}

					if (flagNegativeValue != 0)
					{

						Assert.Fail("Test failed. One values is negative");
					}

					if (flagNotIndexValue != 0)
					{

						Assert.Fail("Test failed. One index is not a base-100 index ");
					}
				}
				else
				{
					Console.WriteLine("No check can be perfomed - Data is not available in the dashboard");
				}

			}

			catch (Exception e)
			{
				Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
				String ScreenShotName = "ErrorScreenshot_" + DateTime.Now.ToString("HHmmss") + ".png";
				ss.SaveAsFile(ScreenShotName, ScreenshotImageFormat.Png);
				TestContext.AddTestAttachment(ScreenShotName, "Screenshot for failure analysis");
				Console.WriteLine("Test failed");
				Console.WriteLine(e.StackTrace);
				Assert.Fail("Test failed. See test output and attachment for analysis");
			}

		}

		public void KPIDashboardHeavyBus(Xpath__Score_Summary XpathSS, Xpath__Ranking XpathRanking, Xpath__CO2_Emissions XpathCE, Xpath__DSE XpathDSEH, Xpath__Fuel_Consumption XpathFC, String Dashboard)
		{
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
				System.Threading.Thread.Sleep(5000);

				//Verify that the dashboard has data in the widget: 
				int NoDataFlag = VerifyData();

				if (NoDataFlag == 0)
				{
					String ScoreSummaryWidget = "Score Summary";
					Console.WriteLine("Starting to verify KPI in " + ScoreSummaryWidget + " widget");
					// Verify Fuel saving score (vehicle related)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathSS.FuelSavingScoreHeavyBus)));
					Console.WriteLine("Verified presence of Fuel Saving Score");

					List<string> FuelSavingScore = new List<string>(new string[] { XpathSS.FuelSavingScoreValueHeavyBus, "Fuel Saving Score" });
					List<string> FuelConsumption = new List<string>(new string[] { XpathSS.FuelConsumptionValueHeavyBus, "Fuel Consumption" });
					List<string> AverageDistancePerUnit = new List<string>(new string[] { XpathSS.AverageDistancePerUnitValueHeavyBus, "Average Distance Per Unit" });
					List<string> CO2Emissions = new List<string>(new string[] { XpathSS.CO2EmissionsValueHeavyBus, "CO2 Emissions" });
					List<List<string>> ScoreSummaryMatrix = new List<List<string>>(new List<string>[] { FuelSavingScore, FuelConsumption, AverageDistancePerUnit, CO2Emissions });

					//Verify that all values in Score Summary are not negative
					int flagNegativeValue = NegativeValuesCheckXpath(ScoreSummaryWidget, ScoreSummaryMatrix);

					//Scroll website
					ScrollFunction();

					Console.WriteLine("\r\n CO2 Emissions widget");
					Scroll(XpathCE.CO2Emissions);
					var CO2widgetPosition = driver.FindElement(By.XPath(XpathCE.CO2Emissions));
					js.ExecuteScript("arguments[0].scrollIntoView(true);", CO2widgetPosition);

					// Verified widget presence: CO2 Emissions
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathCE.CO2Emissions)));
					Console.WriteLine("Verified presence of CO2 Emissions widget");

					// Verified KPI emissions 
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathCE.EmissionsValue)));

					String CO2EmissionsString = driver.FindElement(By.XPath(XpathCE.EmissionsValue)).Text;
					double CO2EmissionsValue = 0;
					if (Double.TryParse(CO2EmissionsString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out CO2EmissionsValue))
					{
						if (CO2EmissionsValue >= 0)
						{
							Console.WriteLine("CO2 Emissions KPI is a positive value: " + CO2EmissionsValue);
						}
						else
						{
							flagNegativeValue++;
							Console.WriteLine("CO2 Emissions KPI of Score Summary is a negative value: " + CO2EmissionsValue);
						}
					}
					else
					{
						Console.WriteLine("Error parsing for " + CO2EmissionsValue);
					}

					Console.WriteLine("\r\n Fuel Consumption widget");

					// Fuel Consumption
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathFC.FuelConsumption)));

                    // Verified KPI Fue Consumption 
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathFC.AverageFleetValueKPI)));

                    String FuelConsumptionString = driver.FindElement(By.XPath(XpathFC.AverageFleetValueKPI)).Text;

					//Remove unit of measure: Kg/100km
					//FuelConsumptionString = driver.FindElement(By.XPath(XpathFC.AverageFleetValue)).Text.Replace(" Kg/100km", "");

					double FuelConsumptionValue = 0;
					if (Double.TryParse(FuelConsumptionString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out FuelConsumptionValue))
					{
						if (FuelConsumptionValue >= 0)
						{
							Console.WriteLine("Fuel consumption KPI is a positive value: " + FuelConsumptionValue);
						}
						else
						{
							flagNegativeValue++;
							Console.WriteLine("Fuel consumption KPI is a negative value: " + FuelConsumptionValue);
						}
					}
					else
					{
						Console.WriteLine("Error parsing for " + FuelConsumptionValue);
					}

					// DSE KPI
					Console.WriteLine("\r\n DSE widget");
					Scroll(XpathDSEH.DSEDriverRelatedLabelPath);
					// Driving Style Evaluation (vehicle related)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathDSEH.DSEDriverRelatedLabelPath)));
					Console.WriteLine("Verified presence of widget Driving Style Evaluation (vehicle related)");

					List<string> FuelSavingScoreDSE = new List<string>(new string[] { XpathDSEH.FuelSavingScoreValuePath, "Fuel Saving Score" });
					List<string> Acceleration = new List<string>(new string[] { XpathDSEH.AccelerationValuePath, "Acceleration" });
                    List<string> Inertia = new List<string>(new string[] { XpathDSEH.InertiaValuePath, "Inertia" });
                    List<string> Stop = new List<string>(new string[] { XpathDSEH.StopValuePath, "Stop" });
                    List<string> ComfortScore = new List<string>(new string[] { XpathDSEH.ComfortScoreValuePath, "Comfort Score" });
					List<string> LateralComfort = new List<string>(new string[] { XpathDSEH.LateralComfortValuePath, "Lateral Comfort Score" });
					List<string> LongitudinalComfort = new List<string>(new string[] { XpathDSEH.LongitudinalComfortValuePath, "Longitudinal Comfort Score" });
					List<string> VerticalComfort = new List<string>(new string[] { XpathDSEH.VerticalComfortValuePath, "Vertical Comfort Score" });

					List<List<string>> DSEMatrix = new List<List<string>>(new List<string>[] { FuelSavingScoreDSE, Acceleration, Inertia, Stop, ComfortScore, LateralComfort, LongitudinalComfort, VerticalComfort });

					System.Threading.Thread.Sleep(1000);
					String DSEWidget = "DSE";
					int flagNotIndexValue = 0;
					int DSEtrattino = 0;
					foreach (List<string> DSEData in DSEMatrix)
					{
						String DSEString = driver.FindElement(By.XPath(DSEData[0])).Text;

						if (DSEString == "-")
						{
							Console.WriteLine(DSEData[1] + " KPI of DSE is -");
						}
						else
						{
							DSEtrattino++;
						}
					}
					if (DSEtrattino != 0)
					{
						Console.WriteLine("Verification that all index on " + DSEWidget + " are a base-100 index");

						int flagNotIndexValue1 = IndexValuesCheckXPath(DSEWidget, DSEMatrix);
						flagNotIndexValue += flagNotIndexValue1;
					}

					// Vehicles Ranking
					Console.WriteLine("\r\n" + "Vehicles Ranking");
					Scroll(XpathRanking.FuelSavingScoreVehiclesHeavyBus);
					Console.WriteLine("Verified the presence of Vehicles Ranking");

					List<string> FuelSavingScoreVR = new List<string>(new string[] { XpathRanking.FuelSavingScoreValueVehiclesHeavyBus, "Fuel Saving Score(vehicle related)" });
					List<string> AverageTotalFuelVR = new List<string>(new string[] { XpathRanking.AverageTotalFuelValueVehiclesHeavyBus, "Average Total Fuel" });
					List<string> AverageSpeedVR = new List<string>(new string[] { XpathRanking.AverageSpeedValueVehiclesHeavyBus, "Average Speed" });
					List<string> CO2EmissionsVR = new List<string>(new string[] { XpathRanking.CO2EmissionsValueVehiclesHeavyBus, "CO2 Emissions" });
					List<List<string>> VehicleRankingMatrix = new List<List<string>>(new List<string>[] { FuelSavingScoreVR, AverageTotalFuelVR, AverageSpeedVR, CO2EmissionsVR });

					Console.WriteLine("Verification that all Ranking Vehicles values are positive");
					foreach (List<string> VehicleRankingData in VehicleRankingMatrix)
					{
						String VehicleRankingString = driver.FindElement(By.XPath(VehicleRankingData[0])).Text;
						double VehicleRankingValue = 0;
						if (Double.TryParse(VehicleRankingString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out VehicleRankingValue))
						{
							if (VehicleRankingValue >= 0)
							{
								Console.WriteLine(VehicleRankingData[1] + " KPI of Vehicles Ranking is a positive value: " + VehicleRankingValue);
							}
							else
							{
								flagNegativeValue++;
								Console.WriteLine(VehicleRankingData[1] + " KPI of Vehicles Ranking is a negative value: " + VehicleRankingValue);
							}
						}
						else
						{
							Console.WriteLine("Error parsing for " + VehicleRankingData[1]);
						}
					}
					Console.WriteLine("Verification that all index on Vehicles Ranking widget are a base-100");
					List<List<string>> VehicleRankingIndex = new List<List<string>>(new List<string>[] { FuelSavingScoreVR });
					//int flagNotIndexValue = 0;
					foreach (List<string> VehicleRankingData in VehicleRankingIndex)
					{
						String VehicleRankingString = driver.FindElement(By.XPath(VehicleRankingData[0])).Text;
						double VehicleRankingValue = 0;

						if (Double.TryParse(VehicleRankingString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out VehicleRankingValue))
						{
							if (VehicleRankingValue >= 0 && VehicleRankingValue <= 100)
							{
								Console.WriteLine(VehicleRankingData[1] + " KPI of Vehicles Ranking is a base-100 index: " + VehicleRankingValue);
							}
							else
							{
								flagNotIndexValue++;
								Console.WriteLine(VehicleRankingData[1] + " KPI of Vehicles Ranking is NOT a base-100 index: " + VehicleRankingValue);
							}
						}
						else
						{
							Console.WriteLine("Error parsing for " + VehicleRankingData[1]);
						}
					}
					if (flagNegativeValue != 0)
					{
						Assert.Fail("Test failed. One values is negative");
					}
					if (flagNotIndexValue != 0)
					{
						Assert.Fail("Test failed. One index is not a base-100 index ");
					}
				}
				else
				{
					Console.WriteLine("No check can be perfomed - Data is not available in the dashboard");
				}
			}
			catch (Exception e)
			{
				Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
				String ScreenShotName = "ErrorScreenshot_" + DateTime.Now.ToString("HHmmss") + ".png";
				ss.SaveAsFile(ScreenShotName, ScreenshotImageFormat.Png);
				TestContext.AddTestAttachment(ScreenShotName, "Screenshot for failure analysis");
				Console.WriteLine("Test failed");
				Console.WriteLine(e.StackTrace);
				Assert.Fail("Test failed. See test output and attachment for analysis");
			}
		}

        public void KPIDashboardDailyElectric(Xpath__Score_Summary_Light XpathSS, Xpath__Fuel_Consumption XpathFC, Xpath__DSE_Light XpathDSE, Xpath__CO2_Emissions XpathCE, String Dashboard)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                System.Threading.Thread.Sleep(5000);

                //Verify that the dashboard has data in the widget: 
                int NoDataFlag = VerifyData();
                if (NoDataFlag == 0)
                {
                    String ScoreSummaryEnergyWidget = "Score Summary Energy Tab";
                    Console.WriteLine("Starting to verify KPI in " + ScoreSummaryEnergyWidget + " widget");
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathSS.EnergyEfficiencyScoreDailyElectric)));
                    Console.WriteLine("Verified presence of Energy Efficiency Score");

                    List<string> EnergyEfficiencyScore = new List<string>(new string[] { XpathSS.EnergyEfficiencyScoreValueeDailyElectric, "Energy efficiency score" });
                    List<string> EnergyConsumption = new List<string>(new string[] { XpathSS.EnergyConsumptionValueeDailyElectric, "Energy consumption" });
                    List<string> EnergyRegenerated = new List<string>(new string[] { XpathSS.EnergyRegeneratedValueeDailyElectric, "Energy regenerated vs. used" });
                    List<string> EnergyHVCA = new List<string>(new string[] { XpathSS.EnergyForClimatizationValueeDailyElectric, "Energy for climatization vs. used" });
                    //List<string> AverageRechargeTime = new List<string>(new string[] { XpathSS.AverageRechargeTimeValueeDailyElectric, "Average recharge time" });
                    List<string> AverageRechargeEnergy = new List<string>(new string[] { XpathSS.AverageRechargeEnergyValueDailyElectric, "Average recharged energy" });

                    List<List<string>> ScoreSummaryEnergyMatrix = new List<List<string>>(new List<string>[] { EnergyEfficiencyScore, EnergyConsumption, EnergyRegenerated, EnergyHVCA, AverageRechargeEnergy });
                    //Verify that all values in Score Summary Energy are not negative
                    int flagNegativeValue = NegativeValuesCheckXpath(ScoreSummaryEnergyWidget, ScoreSummaryEnergyMatrix);

                    //js.ExecuteScript("document.body.style.zoom = '0.10'");
                    System.Threading.Thread.Sleep(1000);

                    // Mission Tab
                    Console.WriteLine("\r\n" + "Mission");
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathSS.MissionTab)));
                    IWebElement MissionTabButton = driver.FindElement(By.XPath(XpathSS.MissionTab));
                    js.ExecuteScript("arguments[0].click();", MissionTabButton);
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Verified the presence of Mission Tab");
                    String ScoreSummaryMissionWidget = "Score Summary Mission Tab";

                    List<string> AverageDistancePerUnit = new List<string>(new string[] { XpathSS.AverageDistancePerUnitValueeDailyElectric, "Average distance per unit" });
                    List<string> AverageTripTimeValue = new List<string>(new string[] { XpathSS.AverageTripTimeValueeDailyElectric, "Average trip time" });
                    List<string> AverageSpeedValue = new List<string>(new string[] { XpathSS.AverageSpeedValueeDailyElectric, "Average speed" });
                    List<string> AverageGrossCombinationWeight = new List<string>(new string[] { XpathSS.AverageGrossCombinationWeightValueeDailyElectric, "Average gross combination weight" });
                    List<string> TractionBatteryStateOfHealth = new List<string>(new string[] { XpathSS.TractionBatteryStateOfHealthValueeDailyElectric, "Traction battery state of health" });
                    List<string> EnergyThroughput = new List<string>(new string[] { XpathSS.EnergyThroughputValueeDailyElectric, "Energy throughput" });

                    List<List<string>> ScoreSummaryMissionMatrix = new List<List<string>>(new List<string>[] { AverageDistancePerUnit, AverageTripTimeValue, AverageSpeedValue, AverageGrossCombinationWeight, TractionBatteryStateOfHealth, EnergyThroughput });
                    //Verify that all values in Score Summary Mission are not negative
                    int flagNegativeValue2 = NegativeValuesCheckXpath(ScoreSummaryMissionWidget, ScoreSummaryMissionMatrix);

                    //Scroll website
                    ScrollFunction();

                    Console.WriteLine("\r\n Energy Usage widget");
                    // Energy Usage
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathFC.EnergyUsage)));
                    Console.WriteLine("Verified presence of Energy Usage widget");

                    // Verified Energy Usage Consumption KPI
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathFC.EnergyUsageVallue)));

                    String EnergyUsageString = "";
                    //Remove unit of Measure: kWh/100km
                    EnergyUsageString = driver.FindElement(By.XPath(XpathFC.EnergyUsageVallue)).Text.Replace(" kWh/100km", "");

                    double EnergyUsageValue = 0;
                    if (Double.TryParse(EnergyUsageString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out EnergyUsageValue))
                    {

                        if (EnergyUsageValue >= 0)
                        {
                            Console.WriteLine("Energy Usage KPI is a positive value: " + EnergyUsageValue);
                        }
                        else
                        {
                            flagNegativeValue++;

                            Console.WriteLine("Energy Usage KPI is a negative value: " + EnergyUsageValue);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error parsing for Energy Usage KPI: " + EnergyUsageValue);
				    }

                    // DSE KPI
                    Console.WriteLine("\r\n DSE widget");
                    Scroll(XpathDSE.DSEDriverRelatedLabelPath);

                    // Driving Style Evaluation (vehicle related)
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathDSE.DSEDriverRelatedLabelPath)));
                    Console.WriteLine("Verified presence of widget Driving Style Evaluation");

                    List<string> EnergyEfficiency = new List<string>(new string[] { XpathDSE.EnergyEfficiencyScoreValuePath, "Energy efficiency score" });
                    List<string> Acceleration = new List<string>(new string[] { XpathDSE.AccelerationValuePath, "Acceleration" });
                    List<string> Deceleration = new List<string>(new string[] { XpathDSE.DecelerationValuePath, "Deceleration" });
                    List<string> EnergyManagement = new List<string>(new string[] { XpathDSE.EnergyManagementValuePath, "Energy management" });
                    List<string> VehicleCare = new List<string>(new string[] { XpathDSE.VehicleCareScoreValuePath, "Vehicle care score" });
                    List<string> BrakeUse = new List<string>(new string[] { XpathDSE.BrakeUseValuePath, "Brake Use" });
                    List<string> Tyres = new List<string>(new string[] { XpathDSE.TyresValuePath, "Tyres" });
                    List<string> SafeDriving = new List<string>(new string[] { XpathDSE.SafeDrivingScoreValuePath, "Safe driving score" });

                    List<List<string>> DSEMatrix = new List<List<string>>(new List<string>[] { EnergyEfficiency, Acceleration, Deceleration, EnergyManagement, VehicleCare, BrakeUse, Tyres, SafeDriving });

                    System.Threading.Thread.Sleep(1000);
                    String DSEWidget = "DSE";
                    int flagNotIndexValue = 0;
                    int DSEtrattino = 0;
                    foreach (List<string> DSEData in DSEMatrix)
                    {
                        String DSEString = driver.FindElement(By.XPath(DSEData[0])).Text;

                        if (DSEString == "-")
                        {
                            Console.WriteLine(DSEData[1] + " KPI of DSE is -");
                        }
                        else
                        {
                            DSEtrattino++;
                        }
                    }
                    if (DSEtrattino != 0)
                    {
                        Console.WriteLine("Verification that all index on " + DSEWidget + " are a base-100 index");

                        int flagNotIndexValue1 = IndexValuesCheckXPath(DSEWidget, DSEMatrix);
                        flagNotIndexValue += flagNotIndexValue1;
                    }

                    //Scroll website
                    ScrollFunction();

                    Console.WriteLine("\r\n CO2 Saved widget");
                    Scroll(XpathCE.CO2Saved);
                    var CO2widgetPosition = driver.FindElement(By.XPath(XpathCE.CO2Saved));
                    js.ExecuteScript("arguments[0].scrollIntoView(true);", CO2widgetPosition);

                    // Verified widget presence: CO2 Saved
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathCE.CO2Saved)));
                    Console.WriteLine("Verified presence of CO2 Saved widget");

                    // Verified KPI saved 
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathCE.SavedValue)));

                    String CO2ESavedString = driver.FindElement(By.XPath(XpathCE.SavedValue)).Text;
                    double CO2SavedValue = 0;
                    if (Double.TryParse(CO2ESavedString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out CO2SavedValue))
                    {
                        if (CO2SavedValue >= 0)
                        {
                            Console.WriteLine("CO2 Saved KPI is a positive value: " + CO2SavedValue);
                        }
                        else
                        {
                            flagNegativeValue++;
                            Console.WriteLine("CO2 Saved KPI of Score Summary is a negative value: " + CO2SavedValue);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error parsing for " + CO2SavedValue);
                    }
                }
                else
                {
                    Console.WriteLine("No check can be perfomed - Data is not available in the dashboard");
                }
            }

            catch (Exception e)
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                String ScreenShotName = "ErrorScreenshot_" + DateTime.Now.ToString("HHmmss") + ".png";
                ss.SaveAsFile(ScreenShotName, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(ScreenShotName, "Screenshot for failure analysis");
                Console.WriteLine("Test failed");
                Console.WriteLine(e.StackTrace);
                Assert.Fail("Test failed. See test output and attachment for analysis");
            }
        }


        public void KPIDashboardLight(Xpath__Score_Summary_Light XpathSS, Xpath__Fuel_Consumption XpathFC, Xpath__Trip_Details XpathTD, Xpath__DSE_Light XpathDSEL, Xpath__CO2_Emissions XpathCE, String Dashboard)
		{
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
				System.Threading.Thread.Sleep(5000);

				//Verify that the dashboard has data in the widget: 
				int NoDataFlag = VerifyData();

				if (NoDataFlag == 0)
				{
					Console.WriteLine("Starting to verify KPI in Score Summary widget");
					// Verify Fuel saving score (driver related)
					System.Threading.Thread.Sleep(5000);
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathSS.EcoScore)));
					Console.WriteLine("Verified presence of Eco Summary");

					List<string> EcoScore = new List<string>(new string[] { XpathSS.EcoScoreValue, "Eco Score" });
					List<string> FuelConsumption = new List<string>(new string[] { XpathSS.FuelConsumptionValue, "Fuel Consumption" });
					List<string> TotalDistance = new List<string>(new string[] { XpathSS.TotalDistanceValue, "Total Distance" });
					//List<string> TotalTripTime = new List<string>(new string[] { XpathSS.TotalTripTimeValue, "Total Trip Time" });
					List<string> Trips = new List<string>(new string[] { XpathSS.TripsValue, "Trips" });
					List<string> AverageSpeed = new List<string>(new string[] { XpathSS.AverageSpeedValue, "Average Speed" });
					List<string> CO2Emissions = new List<string>(new string[] { XpathSS.CO2EmissionsValue, "CO2 Emissions" });

					List<List<string>> ScoreSummaryMatrix = new List<List<string>>(new List<string>[] { FuelConsumption, TotalDistance, Trips, AverageSpeed, CO2Emissions });
					System.Threading.Thread.Sleep(1000);
					String ScoreSummarryWidget = "Score Summary";
					int flagNegativeValue = NegativeValuesCheckXpath(ScoreSummarryWidget, ScoreSummaryMatrix);


					Console.WriteLine("Verification that all index on Score Summary widget are a base-100 index");
					List<List<string>> ScoreSummaryIndex = new List<List<string>>(new List<string>[] { EcoScore });
					int flagNotIndexValue = IndexValuesCheckXPath(ScoreSummarryWidget, ScoreSummaryIndex);


					//Scroll website
					ScrollFunction();

					Console.WriteLine("\r\n CO2 Emissions widget");
					Scroll(XpathCE.CO2Emissions);
					var CO2widgetPosition = driver.FindElement(By.XPath(XpathCE.CO2Emissions));
					js.ExecuteScript("arguments[0].scrollIntoView(true);", CO2widgetPosition);

					// Verified widget presence: CO2 Emissions
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathCE.CO2Emissions)));
					Console.WriteLine("Verified presence of CO2 Emissions widget");

					// Verified KPI emissions 
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathCE.EmissionsValue)));

					String CO2EmissionsString = driver.FindElement(By.XPath(XpathCE.EmissionsValue)).Text;
					double CO2EmissionsValue = 0;
					if (Double.TryParse(CO2EmissionsString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out CO2EmissionsValue))
					{
						if (CO2EmissionsValue >= 0)
						{
							Console.WriteLine("CO2 Emissions KPI is a positive value: " + CO2EmissionsValue);
						}
						else
						{
							flagNegativeValue++;
							Console.WriteLine("CO2 Emissions KPI of Score Summary is a negative value: " + CO2EmissionsValue);
						}
					}


					else
					{
						Console.WriteLine("Error parsing for CO2 Emissions KPI: " + CO2EmissionsValue);
					}

					Console.WriteLine("\r\n Fuel Consumption widget");
					// Fuel Consumption
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathFC.FuelConsumption)));
					Console.WriteLine("Verified presence of Fuel Consumption widget");

					// Verified Fuel Consumption KPI
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathFC.AverageFleetValue)));

					String FuelConsumptionString = "";


					//Remove unit of measure
					if (Dashboard == "21")
					{
						//Remove unit of Measure: l/100km
						FuelConsumptionString = driver.FindElement(By.XPath(XpathFC.AverageFleetValue)).Text.Replace(" l/100km", "");
					}
					else
					{
						//Remove unit of Measure: kg/100km
						FuelConsumptionString = driver.FindElement(By.XPath(XpathFC.AverageFleetValue)).Text.Replace(" kg/100km", "");
					}
					double FuelConsumptionValue = 0;
					if (Double.TryParse(FuelConsumptionString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out FuelConsumptionValue))
					{

						if (FuelConsumptionValue >= 0)
						{
							Console.WriteLine("Fuel consumption KPI is a positive value: " + FuelConsumptionValue);
						}
						else
						{
							flagNegativeValue++;

							Console.WriteLine("Fuel consumption KPI is a negative value: " + FuelConsumptionValue);
						}
					}

					else
					{
						Console.WriteLine("Error parsing for Fuel consumption KPI: " + FuelConsumptionValue);
					}
					// DSE KPI
					Console.WriteLine("\r\n DSE widget");
					Scroll(XpathDSEL.EcoScoreLabelPath);
                    // Driving Style Evaluation (vehicle related)
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathDSEL.EcoScoreLabelPath)));
					Console.WriteLine("Verified presence of widget Driving Style Evaluation");

					List<string> EcoScoreDSE = new List<string>(new string[] { XpathDSEL.EcoScoreValuePath, "Eco Score" });
					List<string> Acceleration = new List<string>(new string[] { XpathDSEL.AccelerationValuePath, "Acceleration" });
					List<string> Deceleration = new List<string>(new string[] { XpathDSEL.DecelerationValuePath, "Deceleration" });
					List<string> EngineUse = new List<string>(new string[] { XpathDSEL.EngineUseValuePath, "Engine Use" });


					List<List<string>> DSEMatrix = new List<List<string>>(new List<string>[] { EcoScoreDSE, Acceleration, Deceleration, EngineUse });

					System.Threading.Thread.Sleep(1000);
					String DSEWidget = "DSE";
					flagNotIndexValue += IndexValuesCheckXPath(DSEWidget, DSEMatrix);

					// Trip Drivers
					Console.WriteLine("\r\n" + "Trip Details");
					Scroll(XpathTD.EcoScoreValue);
					// Verify Fuel saving score (driver related)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathTD.EcoScoreValue)));
					Console.WriteLine("Verified the presence of Trip Details widget");

					List<string> EcoScoreTD = new List<string>(new string[] { XpathTD.EcoScoreValue, "Eco Score" });
					//List<string> TotalTripTimeTD = new List<string>(new string[] { XpathTD.TotalTripTimeValue, "Total Trip Time" });
					List<string> AverageSpeedTD = new List<string>(new string[] { XpathTD.AverageSpeedValue, "Average Speed" });
					List<string> FuelConsumptionTD = new List<string>(new string[] { XpathTD.FuelConsumptionValue, "Fuel Consumption" });
					List<string> Co2EmissionsTD = new List<string>(new string[] { XpathTD.Co2EmissionsValue, "CO2 Emissions" });

					List<List<string>> TripDetailsMatrix = new List<List<string>>(new List<string>[] { AverageSpeedTD, FuelConsumptionTD, Co2EmissionsTD });

					Console.WriteLine("Verification that all Trip Details values are positive");
					foreach (List<string> TripDetailsData in TripDetailsMatrix)
					{
						String TripDetailsString = driver.FindElement(By.XPath(TripDetailsData[0])).Text;
						double TripDetailsValue = 0;
						if (Double.TryParse(TripDetailsString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out TripDetailsValue))
						{
							if (TripDetailsValue >= 0)
							{
								Console.WriteLine(TripDetailsData[1] + " KPI of Trips Detail is a positive value: " + TripDetailsValue);
							}
							else
							{
								flagNegativeValue++;

								Console.WriteLine(TripDetailsData[1] + " KPI of Trips Detail is a negative value: " + TripDetailsValue);
								//Assert fails:
							}
						}

						else
						{
							Console.WriteLine("Error parsing for KPI of Trips Detail, " + TripDetailsData[1] + ":" + TripDetailsValue);
						}
					}

					Console.WriteLine("Verification that all index on Trips Details widget are a base-100 index");
					List<List<string>> TripsDetailIndex = new List<List<string>>(new List<string>[] { EcoScoreTD });

					foreach (List<string> TripsDetailData in TripsDetailIndex)
					{
						String TripsDetailString = driver.FindElement(By.XPath(TripsDetailData[0])).Text;
						double TripsDetailValue = Double.Parse(TripsDetailString);
						if (Double.TryParse(TripsDetailString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out TripsDetailValue))
						{
							if (TripsDetailValue >= 0 && TripsDetailValue <= 100)
							{
								Console.WriteLine(TripsDetailData[1] + " KPI of Trip Details is a base-100 index: " + TripsDetailValue);
							}
							else
							{
								flagNotIndexValue++;
								Console.WriteLine(TripsDetailData[1] + " KPI of Trip Details is NOT a base-100 index: " + TripsDetailValue);

							}

						}
						else
						{
							Console.WriteLine("Error parsing for KPI of Trips Detail, " + TripsDetailData[1] + ":" + TripsDetailValue);
						}
					}

					if (flagNegativeValue != 0)
					{

						Assert.Fail("Test failed. One values is negative");
					}

					if (flagNotIndexValue != 0)
					{

						Assert.Fail("Test failed. One index is not a base-100 index ");
					}
				}
				else
				{
					Console.WriteLine("No check can be perfomed - Data is not available in the dashboard");
				}
			}

			catch (Exception e)
			{
				Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
				String ScreenShotName = "ErrorScreenshot_" + DateTime.Now.ToString("HHmmss") + ".png";
				ss.SaveAsFile(ScreenShotName, ScreenshotImageFormat.Png);
				TestContext.AddTestAttachment(ScreenShotName, "Screenshot for failure analysis");
				Console.WriteLine("Test failed");
				Console.WriteLine(e.StackTrace);
				Assert.Fail("Test failed. See test output and attachment for analysis");
			}

		}

        public void KPIDashboardBusElectric(Xpath__Score_Summary XpathSS, Xpath__Fuel_Consumption XpathFC, Xpath__Ranking XpathRanking, Xpath__DSE XpathDSE, Xpath__CO2_Emissions XpathCE, String Dashboard)
        {
            try
            {
                // Wait definition for element
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                System.Threading.Thread.Sleep(5000);

                //Verify that the dashboard has data in the widget: 
                int NoDataFlag = VerifyData();
                if (NoDataFlag == 0)
                {
                    String ScoreSummaryEnergyWidget = "Score Summary Energy Tab";
                    Console.WriteLine("Starting to verify KPI in " + ScoreSummaryEnergyWidget + " widget");
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathSS.DrivingEfficiencyScoreHeavyBusElectric)));
                    Console.WriteLine("Verified presence of Energy Efficiency Score");

					List<string> DrivingEfficiencyScore = new List<string>(new string[] { XpathSS.DrivingEfficiencyScoreHeavyBusElectricValue, "Driving efficiency score" });
                    List<string> EnergyConsumption = new List<string>(new string[] { XpathSS.EnergyConsumptionHeavyBusElectricValue, "Energy consumption" });
                    List<string> AverageDistance = new List<string>(new string[] { XpathSS.AverageDistanceHeavyBusElectricValue, "Average distance per unit" });
                    List<string> AverageOCT = new List<string>(new string[] { XpathSS.AverageOctHeavyBusElectricValue, "Average overnight charging time per unit" });
                    List<string> AverageTripTime= new List<string>(new string[] { XpathSS.AverageTripTimeHeavyBusElectricValue, "Average trip time" });
                    List<string> AverageSpeed= new List<string>(new string[] { XpathSS.AverageSpeedHeavyBusElectricValue, "Average speed" });

                    List<List<string>> ScoreSummaryEnergyMatrix = new List<List<string>>(new List<string>[] { EnergyConsumption, AverageDistance, AverageOCT, AverageTripTime, AverageSpeed, DrivingEfficiencyScore });
                    //Verify that all values in Score Summary Energy are not negative
                    int flagNegativeValue = NegativeValuesCheckXpath(ScoreSummaryEnergyWidget, ScoreSummaryEnergyMatrix);

                    //js.ExecuteScript("document.body.style.zoom = '0.10'");
                    System.Threading.Thread.Sleep(1000);

                    // Mission Tab
                    //Console.WriteLine("\r\n Score Summary widget:Mission ");
                    //wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathSS.MissionTab)));
                    //IWebElement MissionTabButton = driver.FindElement(By.XPath(XpathSS.MissionTab));
                    //js.ExecuteScript("arguments[0].click();", MissionTabButton);
                    //System.Threading.Thread.Sleep(1000);
                    //Console.WriteLine("Verified the presence of Mission Tab");
                    //String ScoreSummaryMissionWidget2 = "Score Summary Mission Tab";

                    //List<string> AverageDistancePerUnit = new List<string>(new string[] { XpathSS.AverageDistanceForUnitValue, "Average distance per unit" });
                    //List<string> AverageTripTime = new List<string>(new string[] { XpathSS.AverageTripTimeValue, "Average trip time" });
                    //List<string> AverageSpeed = new List<string>(new string[] { XpathSS.AverageSpeedHeavyBusElectricValue, "Average speed" });

                    //List<List<string>> ScoreSummaryMissionMatrix = new List<List<string>>(new List<string>[] { AverageDistancePerUnit, AverageSpeed });
                    //Verify that all values in Score Summary Energy are not negative
                    //int flagNegativeValue2 = NegativeValuesCheckXpath(ScoreSummaryMissionWidget2, ScoreSummaryMissionMatrix);

                    //Scroll website
                    ScrollFunction();

                    Console.WriteLine("\r\n Energy Consumption widget");
                    // Energy Consumption
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathFC.EnergyConsumption)));
                    Console.WriteLine("Verified presence of Energy Consumption widget");

                    // Verified Energy Consumption Consumption KPI
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathFC.EnergyConsumptionValue)));

                    String EnergyConsumptionString = "";
                    //Remove unit of Measure: kWh/100km
                    EnergyConsumptionString = driver.FindElement(By.XPath(XpathFC.EnergyConsumptionValue)).Text.Replace(" kWh/100km", "");

                    double EnergyConsumptionValue = 0;
                    if (Double.TryParse(EnergyConsumptionString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out EnergyConsumptionValue))
                    {

                        if (EnergyConsumptionValue >= 0)
                        {
                            Console.WriteLine("Energy Consumption KPI is a positive value: " + EnergyConsumptionValue);
                        }
                        else
                        {
                            flagNegativeValue++;

                            Console.WriteLine("Energy Consumption KPI is a negative value: " + EnergyConsumptionValue);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error parsing for Energy Consumption KPI: " + EnergyConsumptionValue);
                    }

                    // DSE KPI
                    Console.WriteLine("\r\n DSE widget");
                    Scroll(XpathDSE.DSEDriverRelatedLabelPath);

                    // Driving Style Evaluation (vehicle related)
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathDSE.DSEDriverRelatedLabelPath)));
                    Console.WriteLine("Verified presence of widget Driving Style Evaluation");

                    List<string> DrivingEfficiency = new List<string>(new string[] { XpathDSE.DrivingEfficiencyScoreElectricValuePath, "Driving efficiency score" });
					List<string> Acceleration = new List<string>(new string[] { XpathDSE.AccelerationElectricValuePath, "Acceleration" });
                    List<string> Inertia = new List<string>(new string[] { XpathDSE.InertiaElectricValuePath, "Inertia" });
                    List<string> Stop = new List<string>(new string[] { XpathDSE.StopElectricValuePath, "Stop" });
                    //List<string> Deceleration = new List<string>(new string[] { XpathDSE.DecelerationValuePath, "Deceleration" });
                    //List<string> EnergyManagement = new List<string>(new string[] { XpathDSE.EnergyManagementValuePath, "Energy management" });
                    List<string> ComfortScore = new List<string>(new string[] { XpathDSE.ComfortScoreElectricValuePath, "Comfort score" });
                    List<string> LateralComfortScore = new List<string>(new string[] { XpathDSE.LateralComfortElectricValuePath, "Lateral comfort score" });
                    List<string> LongitudinalComfortScore = new List<string>(new string[] { XpathDSE.LongitudinalComfortElectricValuePath, "Longitudinal comfort score" });
                    List<string> VerticalComfortScore = new List<string>(new string[] { XpathDSE.VerticalComfortElectricValuePath, "Vertical comfort score" });

                    List<List<string>> DSEMatrix = new List<List<string>>(new List<string>[] {  Acceleration, Inertia, Stop, ComfortScore, LateralComfortScore, LongitudinalComfortScore, VerticalComfortScore });

                    System.Threading.Thread.Sleep(1000);
                    String DSEWidget = "DSE";
                    int flagNotIndexValue = 0;
                    int DSEscore = 0;
                    foreach (List<string> DSEData in DSEMatrix)
                    {
                        String DSEString = driver.FindElement(By.XPath(DSEData[0])).Text;

                        if (DSEString == "-")
                        {
                            Console.WriteLine(DSEData[1] + " KPI of DSE is -");
                        }
                        else
                        {
                            DSEscore++;
                        }
                    }
                    if (DSEscore != 0)
                    {
                        Console.WriteLine("Verification that all index on " + DSEWidget + " are a base-100 index");

                        int flagNotIndexValue3 = IndexValuesCheckXPath(DSEWidget, DSEMatrix);
                        flagNotIndexValue += flagNotIndexValue3;
                    }

                    //Scroll website
                    //ScrollFunction();

                    //Vehicles Ranking
                    //Console.WriteLine("\r\n" + "Vehicles Ranking");
                    //Scroll(XpathRanking.EnergyConsumption);
                    // Verify Energy Consumption
                    //wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.EnergyConsumption)));
                    //Console.WriteLine("Verified the presence of Energy Consumption");

                    //List<string> EnergyConsumptionVR = new List<string>(new string[] { XpathRanking.EnergyConsumptionValue, "Energy Consumption" });
                    // List<string> EnergyRegeneratedVR = new List<string>(new string[] { XpathRanking.RecoveredEnergyUsedEnergyValue, "Energy regenerated vs. used" });
                    //  List<string> EnergyHVCAVR = new List<string>(new string[] { XpathRanking.AirConditioningEnergyUsedEnergyValue, "Air conditioning energy/Used energy" });
                    //  List<string> EnergyEfficiencyScoreVR = new List<string>(new string[] { XpathRanking.EnergyEfficiencyScoreValue, "Energy efficiency score" });

                    //  List<List<string>> DriverRankingMatrix = new List<List<string>>(new List<string>[] { EnergyConsumptionVR, EnergyRegeneratedVR, EnergyHVCAVR, EnergyEfficiencyScoreVR });

                    //  Console.WriteLine("Verification that all Ranking Driver values are positive");
                    //  foreach (List<string> DriverRankingData in DriverRankingMatrix)
                    // {
                    //  String DriverRankingString = driver.FindElement(By.XPath(DriverRankingData[0])).Text;
                    //     if (DriverRankingString == "-")
                    //   {
                    //  Console.WriteLine(DriverRankingData[1] + " KPI of Driver Ranking is -");

                    //  }

                    //  else
                    //  {
                    //   double DriverRankingValue = 0;
                    //   if (Double.TryParse(DriverRankingString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out DriverRankingValue))
                    //   {
                    //   if (DriverRankingValue >= 0)
                    //    {
                    //    Console.WriteLine(DriverRankingData[1] + " KPI of Driver Ranking is a positive value: " + DriverRankingValue);
                    //  }
                    // else
                    //  {
                    //  flagNegativeValue++;

                    //  Console.WriteLine(DriverRankingData[1] + " KPI of Driver Ranking is a negative value: " + DriverRankingValue);
                    // }
                    // }

                    // else
                    //  {
                    // Console.WriteLine("Error parsing for " + DriverRankingData[1]);
                    // }
                    // }

                    //  }
                    //   }
                    //  else
                    //{
                    // Console.WriteLine("No check can be perfomed - Data is not available in the dashboard");
                     }
                    }

            catch (Exception e)
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                String ScreenShotName = "ErrorScreenshot_" + DateTime.Now.ToString("HHmmss") + ".png";
                ss.SaveAsFile(ScreenShotName, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(ScreenShotName, "Screenshot for failure analysis");
                Console.WriteLine("Test failed");
                Console.WriteLine(e.StackTrace);
                Assert.Fail("Test failed. See test output and attachment for analysis");
            }
        }



        public int IndexValuesCheckXPath(String Widget, List<List<string>> ListData)
		{
			int flagNotIndexValue = 0;
			Console.WriteLine("Verification that all index in " + Widget + " widget are a base-100 index");
			foreach (List<string> WidgetData in ListData)
			{
				Double WidgetValue = 0;
				String WidgetString = driver.FindElement(By.XPath(WidgetData[0])).Text;
				if (Double.TryParse(WidgetString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out WidgetValue))
				{


					if (WidgetValue >= 0 && WidgetValue <= 100)
					{
						Console.WriteLine(WidgetData[1] + " KPI of " + Widget + " is a base-100 index: " + WidgetValue);
					}
					else
					{
						flagNotIndexValue++;
						Console.WriteLine(WidgetData[1] + " KPI of" + Widget + " is NOT a base-100 index: " + WidgetValue);
					}

				}
				else
				{
					Console.WriteLine("Error parsing for " + WidgetData[1]);
				}


			}
			return flagNotIndexValue;
		}

		public int IndexValuesCheckCssSelector(String Widget, List<List<string>> ListData)
		{
			int flagNotIndexValue = 0;
			Console.WriteLine("Verification that all index in " + Widget + " widget are a base-100 index");
			foreach (List<string> WidgetData in ListData)
			{
				Double WidgetValue = 0;
				String WidgetString = driver.FindElement(By.CssSelector(WidgetData[0])).Text;
				if (Double.TryParse(WidgetString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out WidgetValue))
				{


					if (WidgetValue >= 0 && WidgetValue <= 100)
					{
						Console.WriteLine(WidgetData[1] + " KPI of " + Widget + " is a base-100 index: " + WidgetValue);
					}
					else
					{
						flagNotIndexValue++;
						Console.WriteLine(WidgetData[1] + " KPI of" + Widget + " is NOT a base-100 index: " + WidgetValue);
					}

				}
				else
				{
					Console.WriteLine("Error parsing for " + WidgetData[1]);
				}


			}
			return flagNotIndexValue;
		}


		public int NegativeValuesCheckXpath(String Widget, List<List<string>> ListData)
		{
			int flagNegativeValue = 0;

			Console.WriteLine("Verification that all " + Widget + " are positive");
			foreach (List<string> WidgetData in ListData)
			{
				Double WidgetValue = 0;
				String WidgetString = driver.FindElement(By.XPath(WidgetData[0])).Text;
				if (Double.TryParse(WidgetString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out WidgetValue))
				{

					if (WidgetValue >= 0)
					{
						Console.WriteLine(WidgetData[1] + " KPI of " + Widget + " is a positive value: " + WidgetValue);
					}
					else
					{
						flagNegativeValue++;
						Console.WriteLine(WidgetData[1] + " KPI of " + Widget + " is a negative value: " + WidgetValue);

					}
				}

				else
				{
					Console.WriteLine("Error parsing for " + WidgetData[1]);
				}
			}
			return flagNegativeValue;
		}

		public int NegativeValuesCheckCssSelector(String Widget, List<List<string>> ListData)
		{
			int flagNegativeValue = 0;

			Console.WriteLine("Verification that all " + Widget + " are positive");
			foreach (List<string> WidgetData in ListData)
			{
				Double WidgetValue = 0;
				String WidgetString = driver.FindElement(By.CssSelector(WidgetData[0])).Text;
				if (Double.TryParse(WidgetString, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign, new System.Globalization.CultureInfo("it", false), out WidgetValue))
				{

					if (WidgetValue >= 0)
					{
						Console.WriteLine(WidgetData[1] + " KPI of " + Widget + " is a positive value: " + WidgetValue);
					}
					else
					{
						flagNegativeValue++;
						Console.WriteLine(WidgetData[1] + " KPI of " + Widget + " is a negative value: " + WidgetValue);

					}
				}

				else
				{
					Console.WriteLine("Error parsing for " + WidgetData[1]);
				}
			}
			return flagNegativeValue;
		}
	}
}