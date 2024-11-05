using myiveco_selenium.Functions;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Chrome;
using System.Windows;
using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using System.Reflection;

namespace myiveco_selenium
{
    public class Basic_Test: BaseClass
	{
		
		static string weburl_runsettings = TestContext.Parameters["weburl"].ToString();
		public Basic_Test(Account Account) : base(Account) { }
		public Basic_Test()
		{
		}

		public void BasicTestHeavy(Xpath__Score_Summary XpathSS, Xpath__Ranking XpathRanking, Xpath__Tips XpathTH, Xpath__CO2_Emissions XpathCE, Xpath__Monitored_Vehicles XpathMV, Xpath__Monitored_Drivers XpathMD, Xpath__News_Feed XpathNF, Xpath__DSE XpathDSEH, Xpath__Fuel_Consumption XpathFC)
		{         
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

				//Verify that the dashboard has data in the widget: 
				int NoDataFlag = VerifyData();

				if (NoDataFlag == 0)
				{
				Console.WriteLine("\r\n Score Summary widget");
				
				// Verify Fuel saving score (driver related)
				wait.Until(ExpectedConditions.ElementExists(By.CssSelector(XpathSS.FuelSavingScore)));
				Assert.That(driver.FindElement(By.CssSelector(XpathSS.FuelSavingScore)).Text.Replace("\r\n", " "), Is.EqualTo("Fuel saving score (driver related)"));
				Console.WriteLine("\r\n" + "Verified presence of correct text: Fuel saving score (driver related)");


				// Verify Fuel consumption (l/100km or kg/100km)
				wait.Until(ExpectedConditions.ElementExists(By.CssSelector(XpathSS.FuelConsuption)));
				//Assert.That(driver.FindElement(By.CssSelector(Xpath.FuelConsuption)).Text.Replace("\r\n", " "), Is.EqualTo("Fuel consumption (l/100km)"));
				Console.WriteLine("\r\n" + "Verified presence of correct text:" + driver.FindElement(By.CssSelector(XpathSS.FuelConsuption)).Text.Replace("\r\n", " "));


				// Verify Grado di difficoltà
				wait.Until(ExpectedConditions.ElementExists(By.CssSelector(XpathSS.DegreeOfDifficulty)));
				Assert.That(driver.FindElement(By.CssSelector(XpathSS.DegreeOfDifficulty)).Text.Replace("\r\n", " "), Is.EqualTo("Degree of difficulty"));
				Console.WriteLine("\r\n" + "Verified presence of correct text: Degree of difficulty");

				// Verify Average gross combination weight (t)
				wait.Until(ExpectedConditions.ElementExists(By.CssSelector(XpathSS.AverageGrossCombinationWeight)));
				Assert.That(driver.FindElement(By.CssSelector(XpathSS.AverageGrossCombinationWeight)).Text.Replace("\r\n", " "), Is.EqualTo("Average gross combination weight (t)"));
				Console.WriteLine("\r\n" + "Verified presence of correct text: Average gross combination weight (t)");


				// Verify Average distance per unit (km)
				wait.Until(ExpectedConditions.ElementExists(By.CssSelector(XpathSS.AverageDistancePerUnit)));
				Assert.That(driver.FindElement(By.CssSelector(XpathSS.AverageDistancePerUnit)).Text.Replace("\r\n", " "), Is.EqualTo("Average distance per unit (km)"));
				Console.WriteLine("\r\n" + "Verified presence of correct text: Average distance per unit (km)");

				// Verify CO2 emissions (t)
				wait.Until(ExpectedConditions.ElementExists(By.CssSelector(XpathSS.CO2Emissions)));
				Assert.That(driver.FindElement(By.CssSelector(XpathSS.CO2Emissions)).Text.Replace("\r\n", " "), Is.EqualTo("CO2 emissions (t)"));
				Console.WriteLine("\r\n" + "Verified presence of correct text: CO2 emissions (t)");

				Console.WriteLine("\r\nNews Feed widget");

				// Verified presence of News Feed 
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathNF.NewsFeedContent)));
				Console.WriteLine("Verified presence of News Feed");


				//Scroll website
				ScrollFunction();

				Console.WriteLine("\r\n CO2 Emissions widget");
				// Verified widget presence: CO2 Emissions
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathCE.CO2Emissions)));
				Assert.That(driver.FindElement(By.XPath(XpathCE.CO2Emissions)).Text, Is.EqualTo("CO2 emissions"));
				Console.WriteLine("Verified presence of text: CO2 emissions");

				// Verified KPI emissions presence
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathCE.Emissions)));
				//Assert.That(driver.FindElement(By.XPath(Xpath.Emissions)).Text, Is.EqualTo("Weekly emissions"));
				Console.WriteLine("Verified presence of text:" + driver.FindElement(By.XPath(XpathCE.Emissions)).Text);

				Console.WriteLine("\r\n Fuel Consumption widget");

				// Fuel Consuption
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathFC.FuelConsumption)));
				//Assert.That(driver.FindElement(By.XPath(Xpath.FuelConsumption)).Text, Is.EqualTo("Fuel consumption"));
				Console.WriteLine("Verified presence of correct text: Fuel consumption");


				// Fleet KPI
				wait.Until(ExpectedConditions.ElementExists(By.CssSelector(XpathFC.AverageLabelFleet)));
				//Assert.That(driver.FindElement(By.XPath(Xpath.AverageFleetValue)).Text, Is.EqualTo("Weekly emissions"));
				Console.WriteLine("Verified presence of text:" + driver.FindElement(By.XPath(XpathFC.AverageFleetValue)).Text);

				Console.WriteLine("\r\n DSE widget");

				// Driving Style Evaluation (driver related)
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathDSEH.DSEDriverRelatedLabelPath)));
				Assert.That(driver.FindElement(By.XPath(XpathDSEH.DSEDriverRelatedLabelPath)).Text, Is.EqualTo("Driving Style Evaluation (driver related)"));
				Console.WriteLine("Verified presence of correct text: Driving Style Evaluation (driver related)");

				// Verify Fuel Saving Score KPI
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathDSEH.FuelSavingScoreLabelPath)));
				Assert.That(driver.FindElement(By.XPath(XpathDSEH.FuelSavingScoreLabelPath)).Text, Is.EqualTo("Fuel saving score"));
				Console.WriteLine("\r\n" + "Verified presence of KPI: Fuel saving score");

				// Verify acceleration KPI
				Assert.That(driver.FindElement(By.XPath(XpathDSEH.AccelerationLabelPath)).Text, Is.EqualTo("Acceleration"));
				Console.WriteLine("\r\n" + "Verified presence of KPI: Acceleration");

				// Verify deceleration KPI
				Assert.That(driver.FindElement(By.XPath(XpathDSEH.DecelerationLabelPath)).Text, Is.EqualTo("Deceleration"));
				Console.WriteLine("\r\n" + "Verified presence of KPI: Deceleration");

				// Verify engine use KPI
				Assert.That(driver.FindElement(By.XPath(XpathDSEH.EngineUseLabelPath)).Text, Is.EqualTo("Engine use"));
				Console.WriteLine("\r\n" + "Verified presence of KPI: Engine Use");

				// Verify Vehicle Care Score KPI
				Assert.That(driver.FindElement(By.XPath(XpathDSEH.VehicleCareScoreLabelPath)).Text, Is.EqualTo("Vehicle care score"));
				Console.WriteLine("\r\n" + "Verified presence of KPI: Vehicle Care Score");

				// Verify Brake Use KPI
				Assert.That(driver.FindElement(By.XPath(XpathDSEH.BrakeUseLabelPath)).Text, Is.EqualTo("Brake use"));
				Console.WriteLine("\r\n" + "Verified presence of KPI: Brake Use");

				// Verify Tyres KPI
				Assert.That(driver.FindElement(By.XPath(XpathDSEH.TyresLabelPath)).Text, Is.EqualTo("Tyres"));
				Console.WriteLine("\r\n" + "Verified presence of KPI: Tyres");

				// Verify Safe Driving Score KPI
				Assert.That(driver.FindElement(By.XPath(XpathDSEH.SafeDrivingScoreLabelPath)).Text, Is.EqualTo("Safe driving score"));
				Console.WriteLine("\r\n" + "Verified presence of KPI: Safe Driving Score");

				System.Threading.Thread.Sleep(30);

				Console.WriteLine("\r\n Monitored Vehicles widget");

				// Monitored Vehicles
				wait.Until(ExpectedConditions.ElementExists(By.CssSelector(XpathMV.MonitoredVehicles)));
				Assert.That(driver.FindElement(By.CssSelector(XpathMV.MonitoredVehicles)).Text, Is.EqualTo("Monitored vehicles"));
				Console.WriteLine("Verified presence of widget title: Monitored Vehicles");

				// Verify the presence of Add Vehicle button
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathMV.AddVehicleButton)));
				Console.WriteLine("Verify the presence of Add Vehicle button");

				Console.WriteLine("\r\n Monitored Drivers widget");
				// Monitored Vehicles
				wait.Until(ExpectedConditions.ElementExists(By.CssSelector(XpathMD.MonitoredDrivers)));
				Assert.That(driver.FindElement(By.CssSelector(XpathMD.MonitoredDrivers)).Text, Is.EqualTo("Monitored drivers"));
				Console.WriteLine("Verified presence of widget title: Monitored Drivers");

				// Verify the presence of Add Drivers button
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathMD.AddDriverButton)));
				Console.WriteLine("Verify the presence of Add Drivers button");

				Console.WriteLine("\r\n Ranking Drivers widget");
				js.ExecuteScript("document.body.style.zoom = '0.10'");

				// Verify Ranking columns: User, Mission, Behavior, Fuel Consumption, Driver
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.DriverUserButton)));
				Console.WriteLine("USER column verified");

				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.DriverMissionButton)));
				Console.WriteLine("MISSION column verified");

				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.DriverBehaviorButton)));
				Console.WriteLine("BEHAVIOR column verified");

				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.DriverFuelConsumptionButton)));
				Console.WriteLine("FUEL CONSUMPTION column verified");

				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.DriverDriverButton)));
				Console.WriteLine("DRIVER column \r\n\r\n verified");


				// Verify Fuel saving score (driver related)
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.FuelSavingScoreDrivers)));
				//Rimuovere dal commento quando sarà su la fix sulle label Assert.That(driver.FindElement(By.XPath(Xpath.FuelSavingScoreDrivers)).Text.Replace("\r\n", " "), Is.EqualTo("Fuel saving score (driver related)"));
				Console.WriteLine("\r\n" + "Verified presence of correct text: Fuel saving score (driver related)");

				// Verify Average total fuel (l/100km)
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.AverageTotalFuelDrivers)));
				//Assert.That(driver.FindElement(By.XPath(Xpath.AverageTotalFuelDrivers)).Text.Replace("\r\n", " "), Is.EqualTo("Average total fuel (l/100km)"));
				Console.WriteLine("\r\n" + "Verified presence of correct text: " + driver.FindElement(By.XPath(XpathRanking.AverageTotalFuelDrivers)).Text.Replace("\r\n", " "));

				// Verify Degree of difficulty (index)
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.DegreeOfDifficultyDrivers)));
				//Rimuovere dal commento quando sarà su la fix sulle label  Assert.That(driver.FindElement(By.XPath(Xpath.DegreeOfDifficultyDrivers)).Text.Replace("\r\n", " "), Is.EqualTo("Degree of difficulty"));
				Console.WriteLine("\r\n" + "Verified presence of correct text: Degree of difficulty");


				// Verify CO2 emissions (g/km)
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.CO2EmissionsDrivers)));
				Assert.That(driver.FindElement(By.XPath(XpathRanking.CO2EmissionsDrivers)).Text.Replace("\r\n", " "), Is.EqualTo("CO2 emissions (g/km)"));
				Console.WriteLine("\r\n" + "Verified presence of correct text: CO2 emissions (g/km)");


				// Verify Vehicle care (index)
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.VehicleCareDrivers)));
				//Rimuovere dal commento quando sarà su la fix sulle label Assert.That(driver.FindElement(By.XPath(Xpath.VehicleCareDrivers)).Text.Replace("\r\n", " "), Is.EqualTo("Vehicle care"));
				Console.WriteLine("\r\n" + "Verified presence of correct text: Vehicle care");

				Console.WriteLine("\r\n Ranking Vehicles widget");

				js.ExecuteScript("document.body.style.zoom = '0.10'");
				System.Threading.Thread.Sleep(1000);
				// Verified Vehicles Ranking
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.VehiclesRankingTab)));
				IWebElement VehiclesRankingTabButton = driver.FindElement(By.XPath(XpathRanking.VehiclesRankingTab));
				js.ExecuteScript("arguments[0].click();", VehiclesRankingTabButton);
				Console.WriteLine("VEHICLES RANKING verified");


				// Verify Ranking columns: Vehicle, Mission, Behavior, Fuel Consumption, Driver
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.VehicleVehicleButton)));
				Console.WriteLine("VEHICLE column verified");

				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.VehicleMissionButton)));
				Console.WriteLine("MISSION column verified");

				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.VehicleBehaviorButton)));
				Console.WriteLine("BEHAVIOR column verified");

				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.VehicleFuelConsumptionButton)));
				Console.WriteLine("FUEL CONSUMPTION column verified");

				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.VehicleDriverButton)));
				Console.WriteLine("DRIVER column verified \r\n\r\n");


				// Verify Fuel saving score (driver related)
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.FuelSavingScoreVehicles)));
				//Rimuovere dal commento quando sarà su la fix sulle label  Assert.That(driver.FindElement(By.XPath(Xpath.FuelSavingScoreVehicles)).Text.Replace("\r\n", " "), Is.EqualTo("Fuel saving score (driver related)"));
				Console.WriteLine("\r\n" + "Verified presence of correct text: Fuel saving score (driver related)");

				// Verify Average total fuel (l/100km)
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.AverageTotalFuelVehicles)));
				//Assert.That(driver.FindElement(By.XPath(Xpath.AverageTotalFuelVehicles)).Text.Replace("\r\n", " "), Is.EqualTo("Average total fuel (l/100km)"));
				Console.WriteLine("\r\n" + "Verified presence of correct text:" + driver.FindElement(By.XPath(XpathRanking.AverageTotalFuelVehicles)).Text.Replace("\r\n", " "));


				// Verify Degree of difficulty (index)
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.DegreeOfDifficultyVehicles)));
				//Rimuovere dal commento quando sarà su la fix sulle label  Assert.That(driver.FindElement(By.XPath(Xpath.DegreeOfDifficultyVehicles)).Text.Replace("\r\n", " "), Is.EqualTo("Degree of difficulty"));
				Console.WriteLine("\r\n" + "Verified presence of correct text: Degree of difficulty ");

				// Verify CO2 emissions (g/km)
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.CO2EmissionsVehicles)));
				Assert.That(driver.FindElement(By.XPath(XpathRanking.CO2EmissionsVehicles)).Text.Replace("\r\n", " "), Is.EqualTo("CO2 emissions (g/km)"));
				Console.WriteLine("\r\n" + "Verified presence of correct text: CO2 emissions (g/km)");


				// Verify Vehicle care (index)
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.VehicleCareVehicles)));
				//Rimuovere dal commento quando sarà su la fix sulle label  Assert.That(driver.FindElement(By.XPath(Xpath.VehicleCareVehicles)).Text.Replace("\r\n", " "), Is.EqualTo("Vehicle care"));
				Console.WriteLine("\r\n" + "Verified presence of correct text: Vehicle care");

				Console.WriteLine("\r\n Tips widget");
				// Verified Tips is present

				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathTH.Tips)));
				Console.WriteLine("Verified presence of title:Tips");

				// Verified presence of the card: Best Improvement Opportunity
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathTH.BestImprovementOpportunityCard)));
				Console.WriteLine("Verified presence of the card: Best Improvement Opportunity");

				// Verified presence of the card: Key Fuel Saving Factor
				wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathTH.KeyFuelSavingFactorCard)));
				Console.WriteLine("Verified presence of the card: Key Fuel Saving Factor");
				}
				else
				{
					Console.WriteLine("No check can be perfomed - Data is not available in the dashboard");
				}
			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
			}

    }

		public void BasicTestTway(Xpath__Score_Summary XpathSS, Xpath__Ranking XpathRanking, Xpath__CO2_Emissions XpathCE, Xpath__Monitored_Vehicles XpathMV, Xpath__News_Feed XpathNF, Xpath__Fuel_Consumption XpathFC)
		{
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

				//Verify that the dashboard has data in the widget: 
				int NoDataFlag = VerifyData();

				if (NoDataFlag == 0)
				{
					Console.WriteLine("\r\n Score Summary widget");

					// Verify Fuel consumption (l/100km or kg/100km)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathSS.FuelConsuptionTway)));
					//Assert.That(driver.FindElement(By.XPath(Xpath.FuelConsuption)).Text.Replace("\r\n", " "), Is.EqualTo("Fuel consumption (l/100km)"));
					Console.WriteLine("\r\n" + "Verified presence of correct text:" + driver.FindElement(By.XPath(XpathSS.FuelConsuptionTway)).Text.Replace("\r\n", " "));

					// Verify Average gross combination weight (t)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathSS.AverageGrossCombinationWeightTway)));
					Assert.That(driver.FindElement(By.XPath(XpathSS.AverageGrossCombinationWeightTway)).Text.Replace("\r\n", " "), Is.EqualTo("Average gross combination weight (t)"));
					Console.WriteLine("\r\n" + "Verified presence of correct text: Average gross combination weight (t)");

					// Verify Average distance per unit (km)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathSS.AverageDistancePerUnitTway)));
					Assert.That(driver.FindElement(By.XPath(XpathSS.AverageDistancePerUnitTway)).Text.Replace("\r\n", " "), Is.EqualTo("Average distance per unit (km)"));
					Console.WriteLine("\r\n" + "Verified presence of correct text: Average distance per unit (km)");

					// Verify average speed 
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathSS.AverageSpeed)));
					Assert.That(driver.FindElement(By.XPath(XpathSS.AverageSpeed)).Text.Replace("\r\n", " "), Is.EqualTo("Average speed (km/h)"));
					Console.WriteLine("\r\n" + "Verified presence of correct text: Average speed (km/h)");

					// Verify CO2 emissions (t)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathSS.CO2EmissionsTway)));
					Assert.That(driver.FindElement(By.XPath(XpathSS.CO2EmissionsTway)).Text.Replace("\r\n", " "), Is.EqualTo("CO2 emissions (t)"));
					Console.WriteLine("\r\n" + "Verified presence of correct text: CO2 emissions (t)");

					Console.WriteLine("\r\nNews Feed widget");

					// Verified presence of News Feed 
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathNF.NewsFeedContent)));
					Console.WriteLine("Verified presence of News Feed");


					//Scroll website
					ScrollFunction();

					Console.WriteLine("\r\n CO2 Emissions widget");
					// Verified widget presence: CO2 Emissions
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathCE.CO2Emissions)));
					Assert.That(driver.FindElement(By.XPath(XpathCE.CO2Emissions)).Text, Is.EqualTo("CO2 emissions"));
					Console.WriteLine("Verified presence of text: CO2 emissions");

					// Verified KPI emissions presence
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathCE.Emissions)));
					//Assert.That(driver.FindElement(By.XPath(Xpath.Emissions)).Text, Is.EqualTo("Weekly emissions"));
					Console.WriteLine("Verified presence of text:" + driver.FindElement(By.XPath(XpathCE.Emissions)).Text);

					Console.WriteLine("\r\n Fuel Consumption widget");

					// Fuel Consuption
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathFC.FuelConsumption)));
					//Assert.That(driver.FindElement(By.XPath(Xpath.FuelConsumption)).Text, Is.EqualTo("Fuel consumption"));
					Console.WriteLine("Verified presence of correct text: Fuel consumption");


					// Fleet KPI
					wait.Until(ExpectedConditions.ElementExists(By.CssSelector(XpathFC.AverageLabelFleet)));
					//Assert.That(driver.FindElement(By.XPath(Xpath.AverageFleetValue)).Text, Is.EqualTo("Weekly emissions"));
					Console.WriteLine("Verified presence of text:" + driver.FindElement(By.XPath(XpathFC.AverageFleetValue)).Text);


					// Monitored Vehicles
					wait.Until(ExpectedConditions.ElementExists(By.CssSelector(XpathMV.MonitoredVehicles)));
					Assert.That(driver.FindElement(By.CssSelector(XpathMV.MonitoredVehicles)).Text, Is.EqualTo("Monitored vehicles"));
					Console.WriteLine("Verified presence of widget title: Monitored Vehicles");

					// Verify the presence of Add Vehicle button
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathMV.AddVehicleButton)));
					Console.WriteLine("Verify the presence of Add Vehicle button");



					Console.WriteLine("\r\n Ranking Vehicles widget");

					js.ExecuteScript("document.body.style.zoom = '0.10'");
					System.Threading.Thread.Sleep(1000);


					// Verify Ranking columns: Vehicle, Mission, Behavior, Fuel Consumption, Driver
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.VehicleVehicleButton)));
					Console.WriteLine("VEHICLE column verified");

					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.VehicleMissionButton)));
					Console.WriteLine("MISSION column verified");

					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.VehicleBehaviorButton)));
					Console.WriteLine("BEHAVIOR column verified");

					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.VehicleFuelConsumptionButton)));
					Console.WriteLine("FUEL CONSUMPTION column verified");

					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.VehicleDriverButton)));
					Console.WriteLine("DRIVER column verified \r\n\r\n");

					// Verify Average total fuel (l/100km)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.AverageTotalFuelVehiclesTway)));
					//Assert.That(driver.FindElement(By.XPath(Xpath.AverageTotalFuelVehicles)).Text.Replace("\r\n", " "), Is.EqualTo("Average total fuel (l/100km)"));
					Console.WriteLine("\r\n" + "Verified presence of correct text:" + driver.FindElement(By.XPath(XpathRanking.AverageTotalFuelVehicles)).Text.Replace("\r\n", " "));

					// Verify PTO
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.PTOVehicles)));
					Assert.That(driver.FindElement(By.XPath(XpathRanking.PTOVehicles)).Text.Replace("\r\n", " "), Is.EqualTo("PTO (%)"));
					Console.WriteLine("\r\n" + "Verified presence of correct text: PTO(%)");

					// Verify Idling
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.IdlingVehicles)));
					Assert.That(driver.FindElement(By.XPath(XpathRanking.IdlingVehicles)).Text.Replace("\r\n", " "), Is.EqualTo("Idling (%)"));
					Console.WriteLine("\r\n" + "Verified presence of correct text: Idling(%)");

					// Verify number of stops
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.NOfStopsVehicles)));
					Assert.That(driver.FindElement(By.XPath(XpathRanking.NOfStopsVehicles)).Text.Replace("\r\n", " "), Is.EqualTo("Number of stops (n/100km)"));
					Console.WriteLine("\r\n" + "Verified presence of correct text: Number of stops(n/100km)");

					// Verify CO2 emissions (g/km)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathRanking.CO2EmissionsVehiclesTway)));
					Assert.That(driver.FindElement(By.XPath(XpathRanking.CO2EmissionsVehiclesTway)).Text.Replace("\r\n", " "), Is.EqualTo("CO2 emissions (g/km)"));
					Console.WriteLine("\r\n" + "Verified presence of correct text: CO2 emissions (g/km)");
				}
				else
                {
					Console.WriteLine("No check can be perfomed - Data is not available in the dashboard");
				}
			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
			}

		}

		public void BasicTestLight(Xpath__Score_Summary_Light XpathSS, Xpath__News_Feed XpathNF, Xpath__Fuel_Consumption XpathFC, Xpath__Trip_Details XpathTD, Xpath__DSE_Light XpathDSEL, Xpath__CO2_Emissions XpathCE, Xpath__Tips XpathTL)
		{
			try
			{
                Console.WriteLine("\r\nScore Summary widget");

				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));

				//Verify that the dashboard has data in the widget: 
				int NoDataFlag = VerifyData();

				if (NoDataFlag == 0)
				{
					ScrollDown();
					// Verify Eco score
					//wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.EcoScore)));
					//Assert.That(driver.FindElement(By.XPath(Xpath.EcoScore)), Is.EqualTo("Eco score"));
					Console.WriteLine("Verified presence of correct text: Eco score");


					// Verify Fuel consumption (l/100km or kg/100km)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathSS.FuelConsumption)));
					//Assert.That(driver.FindElement(By.XPath(Xpath.FuelConsuption)).Text.Replace("\r\n", " "), Is.EqualTo("Fuel consumption (l/100km)"));
					Console.WriteLine("Verified presence of correct text: " + driver.FindElement(By.XPath(XpathSS.FuelConsumption)).Text.Replace("\r\n", " "));


					// Verify Total distance (km)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathSS.TotalDistance)));
					Assert.That(driver.FindElement(By.XPath(XpathSS.TotalDistance)).Text.Replace("\r\n", " "), Is.EqualTo("Total distance (km)"));
					Console.WriteLine("Verified presence of correct text: Total Distance (km)");


					// Verify Total trip Time (hh:mm:ss)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathSS.TotalTripTime)));
					//Assert.That(driver.FindElement(By.XPath(Xpath.TotalTripTime)).Text.Replace("\r\n", " "), Is.EqualTo("Total trip time (hh:mm:ss)"));
					Console.WriteLine("Verified presence of correct text:" + driver.FindElement(By.XPath(XpathSS.TotalTripTime)).Text.Replace("\r\n", " "));

					// Verify Trips
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathSS.Trips)));
					Assert.That(driver.FindElement(By.XPath(XpathSS.Trips)).Text.Replace("\r\n", " "), Is.EqualTo("Trips"));
					Console.WriteLine("Verified presence of correct text: Trips");

					// Verify Average speed (km/h)"
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathSS.AverageSpeed)));
					Assert.That(driver.FindElement(By.XPath(XpathSS.AverageSpeed)).Text.Replace("\r\n", " "), Is.EqualTo("Average speed (km/h)"));
					Console.WriteLine("Verified presence of correct text: Average speed (km/h)");


					// Verify CO2 emissions (t)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathSS.CO2Emissions)));
					Assert.That(driver.FindElement(By.XPath(XpathSS.CO2Emissions)).Text.Replace("\r\n", " "), Is.EqualTo("CO2 emissions (kg)"));
					Console.WriteLine("Verified presence of correct text: CO2 emissions (kg)");


					//NEWS FEED widget
					Console.WriteLine("\r\nNews Feed widget");

					// Verified presence of News Feed 
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathNF.NewsFeedContent)));
					Console.WriteLine("Verified presence of News Feed");

					ScrollFunction();
					Console.WriteLine("\r\nCO2 Emissions widget");
					// Wait definition for element

					// Verified widget presence: CO2 Emissions
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathCE.CO2Emissions)));
					Assert.That(driver.FindElement(By.XPath(XpathCE.CO2Emissions)).Text, Is.EqualTo("CO2 emissions"));
					Console.WriteLine("Verified presence of text: CO2 emissions");

					// Verified KPI emissions presence
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathCE.Emissions)));
					//Assert.That(driver.FindElement(By.XPath(Xpath.Emissions)).Text, Is.EqualTo("Weekly emissions"));
					Console.WriteLine("Verified presence of text:" + driver.FindElement(By.XPath(XpathCE.Emissions)).Text);

					System.Threading.Thread.Sleep(30);

					Console.WriteLine("\r\nFuel Consumption widget");

					// Fuel Consuption
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathFC.FuelConsumption)));
					//Assert.That(driver.FindElement(By.XPath(Xpath.FuelConsumption)).Text, Is.EqualTo("Fuel consumption"));
					Console.WriteLine("Verified presence of correct text: Fuel consumption");


					// Fleet KPI
					wait.Until(ExpectedConditions.ElementExists(By.CssSelector(XpathFC.AverageLabelFleet)));
					//Assert.That(driver.FindElement(By.XPath(Xpath.AverageFleetValue)).Text, Is.EqualTo("Weekly emissions"));
					Console.WriteLine("Verified presence of text:" + driver.FindElement(By.XPath(XpathFC.AverageFleetValue)).Text);


					Console.WriteLine("\r\nDSE widget");

                    // Driving Style Evaluation (vehicle related)
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathDSEL.DSELabelPath)));
					Assert.That(driver.FindElement(By.XPath(XpathDSEL.DSELabelPath)).Text, Is.EqualTo("Driving Style Evaluation (vehicle related)"));
					Console.WriteLine("Verified presence of correct text: Driving Style Evaluation (vehicle related)");

					System.Threading.Thread.Sleep(5000);

					// Verify Fuel Saving Score KPI
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathDSEL.EcoScoreLabelPath)));
					Assert.That(driver.FindElement(By.XPath(XpathDSEL.EcoScoreLabelPath)).Text, Is.EqualTo("Eco score"));
					Console.WriteLine("Verified presence of KPI: Eco score");

					// Verify acceleration KPI
					Assert.That(driver.FindElement(By.XPath(XpathDSEL.AccelerationLabelPath)).Text, Is.EqualTo("Acceleration"));
					Console.WriteLine("Verified presence of KPI: Acceleration");

					// Verify deceleration KPI
					Assert.That(driver.FindElement(By.XPath(XpathDSEL.DecelerationLabelPath)).Text, Is.EqualTo("Deceleration"));
					Console.WriteLine("Verified presence of KPI: Deceleration");


					// Verify engine use KPI
					Assert.That(driver.FindElement(By.XPath(XpathDSEL.EngineUseLabelPath)).Text, Is.EqualTo("Engine use"));
					Console.WriteLine("Verified presence of KPI: Engine Use");

					Console.WriteLine("\r\nTrip Details widget");

					// Zoom out to see all data
					js.ExecuteScript("document.body.style.zoom = '0.10'");



					// Verify Trip details columns: Vehicle, Mission, Fuel Consumption
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathTD.VehicleButton)));
					Console.WriteLine("VEHICLE column verified ");

					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathTD.MissionButton)));
					Console.WriteLine("MISSION column verified");

					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathTD.FuelConsumptionButton)));
					Console.WriteLine("FUEL CONSUMPTION column verified \r\n\r\n");


					// Verify Eco Score
					//wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath.EcoScore)));
					//Assert.That(driver.FindElement(By.XPath(Xpath.EcoScore)).Text.Replace("\r\n", " "), Is.EqualTo("Eco score"));
					Console.WriteLine("Verified presence of correct text: Eco score");

					// Verify Fuel consumption (l/100km or kg/100km)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathTD.FuelConsumption)));
					//Assert.That(driver.FindElement(By.XPath(Xpath.FuelConsumption)).Text.Replace("\r\n", " "), Is.EqualTo("Fuel consumption (l/100km)"));
					Console.WriteLine("Verified presence of correct text: " + driver.FindElement(By.XPath(XpathTD.FuelConsumption)).Text.Replace("\r\n", " "));


					// Verify Total trip time (hh:mm:ss) or (dd:hh:mm)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathTD.TotalTripTime)));
					//Assert.That(driver.FindElement(By.XPath(Xpath.TotalTripTime)).Text.Replace("\r\n", " "), Is.EqualTo("Total trip time (hh:mm:ss)"));
					Console.WriteLine("Verified presence of correct text:" + driver.FindElement(By.XPath(XpathTD.TotalTripTime)).Text.Replace("\r\n", " "));

					// Verify Average speed (km/h)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathTD.AverageSpeed)));
					Assert.That(driver.FindElement(By.XPath(XpathTD.AverageSpeed)).Text.Replace("\r\n", " "), Is.EqualTo("Average speed (km/h)"));
					Console.WriteLine("Verified presence of correct text: Average speed (km/h)");

					// Verify CO2 emissions (kg)
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathTD.Co2Emissions)));
					Assert.That(driver.FindElement(By.XPath(XpathTD.Co2Emissions)).Text.Replace("\r\n", " "), Is.EqualTo("CO2 emissions (kg)"));
					Console.WriteLine("Verified presence of correct text: CO2 emissions (kg)");


					Console.WriteLine("\r\nTips widget");

					// Verified Tips is present
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathTL.Tips)));
					Console.WriteLine("Verified presence of title:Tips");

					// Verified presence of the card: Acceleration 
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathTL.AccelerationCard)));
					Console.WriteLine("Verified presence of the card: Acceleration ");

					// Verified presence of the card: Deceleration
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathTL.DecelerationCard)));
					Console.WriteLine("Verified presence of the card: Deceleration");

					// Verified presence of the card: Engine Use
					wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathTL.EngineUseCard)));
					Console.WriteLine("Verified presence of the card: Engine Use");
				}
				else
				{
					Console.WriteLine("No check can be perfomed - Data is not available in the dashboard");
				}
			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
			}
		}

		public void BasicTestHeavyBus(Xpath__Score_Summary XpathSS, Xpath__Ranking XpathRanking, Xpath__Tips XpathTH, Xpath__CO2_Emissions XpathCE, Xpath__Monitored_Vehicles XpathMV, Xpath__News_Feed XpathNF, Xpath__DSE XpathDSEH, Xpath__Fuel_Consumption XpathFC)
		{
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

				//Verify that the dashboard has data in the widget: 
				int NoDataFlag = VerifyData();

				if (NoDataFlag == 0)
				{
					Console.WriteLine("\r\n Score Summary widget");

					// Verify Fuel saving score (vehicle related)
					AssertElementIsEqualTo(XpathSS.FuelSavingScoreHeavyBus, "Fuel saving score (vehicle related)");

					// Verify Fuel consumption (l/100km or kg/100km)
					VerifyElement(XpathSS.FuelConsumptionHeavyBus);
					//Assert.That(driver.FindElement(By.XPath(XpathSS.FuelConsumptionHeavyBus)).Text.Replace("\r\n", " "), Is.EqualTo("Fuel consumption (l/100km)"));
					Console.WriteLine("Verified presence of correct text: " + driver.FindElement(By.XPath(XpathSS.FuelConsumptionHeavyBus)).Text.Replace("\r\n", " "));

					// Verify Average distance per unit (km)
					VerifyElement(XpathSS.AverageDistancePerUnitHeavyBus);
					Assert.That(driver.FindElement(By.XPath(XpathSS.AverageDistancePerUnitHeavyBus)).Text.Replace("\r\n", " "), Is.EqualTo("Average distance per unit (km)"));
					Console.WriteLine("Verified presence of correct text: Average distance per unit (km)");

					// Verify CO2 emissions (t)
					VerifyElement(XpathSS.CO2EmissionsHeavyBus);
					Assert.That(driver.FindElement(By.XPath(XpathSS.CO2EmissionsHeavyBus)).Text.Replace("\r\n", " "), Is.EqualTo("CO2 emissions (t)"));
					Console.WriteLine("Verified presence of correct text: CO2 emissions (t)");

					Console.WriteLine("\r\nNews Feed widget");

					// Verified presence of News Feed 
					VerifyElement(XpathNF.NewsFeedContent);

					//Scroll website
					ScrollFunction();

					Console.WriteLine("\r\n CO2 Emissions widget");
					// Verified widget presence: CO2 Emissions
					AssertElementIsEqualTo(XpathCE.CO2Emissions, "CO2 emissions");

					// Verified KPI emissions presence
					VerifyElement(XpathCE.Emissions);

					Console.WriteLine("\r\n Fuel Consumption widget");

					// Fuel Consumption
					VerifyElement(XpathFC.FuelConsumption);

					// Fleet KPI
					wait.Until(ExpectedConditions.ElementExists(By.CssSelector(XpathFC.AverageLabelFleet)));
					Console.WriteLine("Verified presence of text:" + driver.FindElement(By.XPath(XpathFC.AverageFleetValue)).Text);

					Console.WriteLine("\r\n DSE widget");

					// Driving Style Evaluation (vehicle related)
					AssertElementIsEqualTo(XpathDSEH.DSEDriverRelatedLabelPath, "Driving Style Evaluation (vehicle related)");
					// Verify Fuel Saving Score KPI
					AssertElementIsEqualTo(XpathDSEH.FuelSavingScoreLabelPath, "Fuel saving score");
					// Verify acceleration KPI
					AssertElementIsEqualTo(XpathDSEH.AccelerationLabelPath, "Acceleration");
					// Verify inertia KPI
					AssertElementIsEqualTo(XpathDSEH.InertiaLabelPath, "Inertia");
					// Verify stop KPI
					AssertElementIsEqualTo(XpathDSEH.StopLabelPath, "Stop");
					// Verify Comfort Score KPI
					AssertElementIsEqualTo(XpathDSEH.ComfortScoreLabelPath, "Comfort score");
					// Verify Lateral Comfort Score KPI
					AssertElementIsEqualTo(XpathDSEH.LateralComfortLabelPath, "Lateral comfort score");
					// Verify Longitudinal Comfort Score KPI
					AssertElementIsEqualTo(XpathDSEH.LongitudinalComfortLabelPath, "Longitudinal comfort score");
					// Verify Vertical Comfort Score KPI
					AssertElementIsEqualTo(XpathDSEH.VerticalComfortLabelPath, "Vertical comfort score");

					System.Threading.Thread.Sleep(30);

					Console.WriteLine("\r\n Monitored Vehicles widget");

					// Monitored Vehicles
					wait.Until(ExpectedConditions.ElementExists(By.CssSelector(XpathMV.MonitoredVehicles)));
					Assert.That(driver.FindElement(By.CssSelector(XpathMV.MonitoredVehicles)).Text, Is.EqualTo("Monitored vehicles"));
					Console.WriteLine("Verified presence of widget title: Monitored Vehicles");

					// Verify the presence of Add Vehicle button
					VerifyElement(XpathMV.AddVehicleButton);

					Console.WriteLine("\r\n Ranking Vehicles widget");
					js.ExecuteScript("document.body.style.zoom = '0.10'");
					System.Threading.Thread.Sleep(1000);

					// Verify Vehicles Ranking title

					// Verify Ranking columns: Vehicle, Driving Style Evaluation, Mission
					VerifyElement(XpathRanking.VehicleVehicleButtonHeavyBus);
					VerifyElement(XpathRanking.VehicleDrivingStyleButtonHeavyBus);
					VerifyElement(XpathRanking.VehicleMissionButtonHeavyBus);

					// Verify Fuel saving score (vehicle related)
					VerifyElement(XpathRanking.FuelSavingScoreVehiclesHeavyBus);
					// Verify Average total fuel (l/100km)
					VerifyElement(XpathRanking.AverageTotalFuelVehiclesHeavyBus);
					// Verify Average Speed (km/h)
					VerifyElement(XpathRanking.AverageSpeedVehiclesHeavyBus);
					// Verify CO2 emissions (g/km)
					VerifyElement(XpathRanking.CO2EmissionsVehiclesHeavyBus);

					Console.WriteLine("\r\n Tips widget");

					// Verify Tips is present
					//VerifyElement(XpathTH.Tips);
					// Verify presence of the card: Best Improvement Opportunity
					//VerifyElement(XpathTH.BestImprovementOpportunityCard);
					// Verify presence of the card: Key Fuel Saving Factor
					//VerifyElement(XpathTH.KeyFuelSavingFactorCard);
				}
				else
				{
					Console.WriteLine("No check can be perfomed - Data is not available in the dashboard");
				}
			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
			}
		}


		public void BasicTestHeavyBusElectric(Xpath__Score_Summary XpathSS, Xpath__Ranking XpathRanking, Xpath__Tips XpathT, Xpath__CO2_Emissions XpathCE, Xpath__Monitored_Vehicles XpathMV, Xpath__News_Feed XpathNF, Xpath__DSE XpathDSE, Xpath__Fuel_Consumption XpathFC, Values__Score_Summary_Label ValueSS, Values__Ranking_Label ValueRanking, Values__Tips_Label ValueT, Values__CO2_Emissions_Label ValueCE, Values__Monitored_Vehicles_Label ValueMV, Values__DSE_Label ValueDSE, Values__Fuel_Consumption_Label ValueFC)
		{
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

				//Verify that the dashboard has data in the widget: 
				int NoDataFlag = VerifyData();

				if (NoDataFlag == 0)
				{
					Console.WriteLine("\r\n Score Summary widget:Energy ");

                    // Verify Energy Efficiency Score
                    AssertElementIsEqualTo(XpathSS.DrivingEfficiencyScoreHeavyBusElectric, ValueSS.DrivingEfficiencyScoreHeavyBusElectric);

                    // Verify Energy consumption (kWh/km)
                    AssertElementIsEqualTo(XpathSS.EnergyConsumptionScoreHeavyBusElectric, ValueSS.EnergyConsumptionScoreHeavyBusElectric);

                    // Verify Average distance per unit (km)
                    AssertElementIsEqualTo(XpathSS.AverageDistanceHeavyBusElectric, ValueSS.AverageDistanceHeavyBusElectric);

                    // Verify Average Average overnight charging time per unit (hh:mm:ss) or (dd:hh:mm)
                    VerifyElement(XpathSS.AverageOctHeavyBusElectric);

                    // Verify Average trip time (dd:hh:mm) or (hh:mm:ss)
                    VerifyElement(XpathSS.AverageTripTimeHeavyBusElectric);

                    // Verify Average Speed 
                    AssertElementIsEqualTo(XpathSS.AverageSpeedHeavyBusElectric, ValueSS.AverageSpeedHeavyBusElectric);

					//Console.WriteLine("\r\n Score Summary widget:Mission ");

					//Click on Missions
					//JSFindElementAndClick(XpathSS.MissionTab, ValueSS.MissionTab, 2000);

					// Verify Average Distance Per Unit
					//AssertElementIsEqualTo(XpathSS.AverageDistancePerUnitHeavyBus, ValueSS.AverageDistancePerUnitHeavyBus);

					//Verify Total trip time
					//AssertElementIsEqualTo(XpathSS.TotalTripTime, ValueSS.TotalTripTime);

					// Verify Average Speed 
					//AssertElementIsEqualTo(XpathSS.AverageSpeedHeavyBusElectric, ValueSS.AverageSpeedHeavyBusElectric);

					Console.WriteLine("\r\nNews Feed widget");

					// Verified presence of News Feed 
					VerifyElement(XpathNF.NewsFeedContent);

					//Scroll website
					ScrollFunction();

					Console.WriteLine("\r\n Energy Consumption widget");

					// Fleet KPI

					Console.WriteLine("\r\n DSE widget");

					// Driving Style Evaluation (vehicle related)
					//AssertElementIsEqualTo(XpathDSE.EnergyManagement, ValueDSE.EnergyManagement);
					// Verify Energy Management KPI
					AssertElementIsEqualTo(XpathDSE.DrivingEfficiencyScoreLabelPath, ValueDSE.DrivingEfficiencyScoreLabelPath);
					// Verify acceleration KPI
					AssertElementIsEqualTo(XpathDSE.AccelerationLabelPath, ValueDSE.Acceleration);
                    // Verify inertia KPI
                    AssertElementIsEqualTo(XpathDSE.InertiaElectricLabelPath, ValueDSE.Inertia);
                    // Verify stop KPI
                    AssertElementIsEqualTo(XpathDSE.StopElectricLabelPath, ValueDSE.Stop);
                    // Verify Comfort Score KPI
                    AssertElementIsEqualTo(XpathDSE.ComfortScoreLabelPath, ValueDSE.ComfortScore);
					// Verify Lateral Comfort Score KPI
					AssertElementIsEqualTo(XpathDSE.LateralComfortLabelPath, ValueDSE.LateralComfortScore);
					// Verify Longitudinal Comfort Score KPI
					AssertElementIsEqualTo(XpathDSE.LongitudinalComfortLabelPath, ValueDSE.LongitudinalComfortScore);
					// Verify Vertical Comfort Score KPI
					AssertElementIsEqualTo(XpathDSE.VerticalComfortLabelPath, ValueDSE.VerticalComfortScore);

					System.Threading.Thread.Sleep(30);

					Console.WriteLine("\r\n Monitored Vehicles widget");

					// Monitored Vehicles
					wait.Until(ExpectedConditions.ElementExists(By.CssSelector(XpathMV.MonitoredVehicles)));
					Assert.That(driver.FindElement(By.CssSelector(XpathMV.MonitoredVehicles)).Text, Is.EqualTo("Monitored vehicles"));
					Console.WriteLine("Verified presence of widget title: Monitored Vehicles");

					// Verify the presence of Add Vehicle button
					VerifyElement(XpathMV.AddVehicleButton);

					Console.WriteLine("\r\n Ranking Vehicles widget");
					js.ExecuteScript("document.body.style.zoom = '0.10'");
					System.Threading.Thread.Sleep(1000);

					// Verify Vehicles Ranking title

					// Verify Ranking columns: Vehicle, Driving Style Evaluation, Mission
					VerifyElement(XpathRanking.VehicleVehicleButtonHeavyBus);
					VerifyElement(XpathRanking.VehicleDrivingStyleButtonHeavyBus);
					VerifyElement(XpathRanking.VehicleMissionButtonHeavyBus);
                    //VerifyElement(XpathRanking.VehicleEnergyUsageButtonHeavyBus);

                    // Verify Energy Consumption
                    //AssertElementIsEqualTo(XpathRanking.EnergyConsumption, ValueRanking.EnergyConsumption);
                    // Verify Recovered Energy Used Energy
                    //AssertElementIsEqualTo(XpathRanking.RecoveredEnergyUsedEnergy, ValueRanking.RecoveredEnergyUsedEnergy);
                    // Verify Average Speed (km/h)
                    //AssertElementIsEqualTo(XpathRanking.AirConditioningEnergyUsedEnergy, ValueRanking.AirConditioningEnergyUsedEnergy);
                    // Verify CO2 emissions (g/km)
                    //AssertElementIsEqualTo(XpathRanking.EnergyEfficiencyScore, ValueRanking.EnergyEfficiencyScore);

                    Console.WriteLine("\r\n Tips widget");

					// Verify Tips is present
					VerifyElement(XpathT.Tips);
					//Verify presence of the card: Best Improvement Opportunity
					VerifyElement(XpathT.BestImprovementOpportunityCard);
					//Verify presence of the card: Key Fuel Saving Factor
					VerifyElement(XpathT.KeyFuelSavingFactorCard); 
				}
				else
				{
					Console.WriteLine("No check can be perfomed - Data is not available in the dashboard");
				}
			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
			}
		}


		public void BasicTestDailyElectric(Xpath__Score_Summary_Light XpathSS, Xpath__Ranking_Light XpathRanking, Xpath__Tips XpathT, Xpath__CO2_Emissions XpathCE, Xpath__Monitored_Vehicles_Light XpathMVL, Xpath__News_Feed XpathNF, Xpath__DSE_Light XpathDSE, Xpath__Fuel_Consumption XpathFC, Xpath__MyDaily_Light XpathMD, Values__Score_Summary_Label ValueSS, Values__Ranking_Label ValueRanking, Values__Tips_Label ValueT, Values__CO2_Emissions_Label ValueCE, Values__Monitored_Vehicles_Label ValueMVL, Values__DSE_Label ValueDSE, Values__Fuel_Consumption_Label ValueFC, Values__MyDaily ValueMD)
        {
			try
			{
				// Wait definition for element
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

				//Verify that the dashboard has data in the widget: 
				int NoDataFlag = VerifyData();

				if (NoDataFlag == 0)
				{
					Console.WriteLine("\r\n Score Summary widget");

					// Verify Energy efficiency score (index)
                    AssertElementIsEqualTo(XpathSS.EnergyEfficiencyScoreDailyElectric, ValueSS.EnergyEfficiencyScoreDailyElectric);

					// Verify EnergyConsumption
					VerifyElement(XpathSS.EnergyConsumptionDailyElectric);
                    //AssertElementIsEqualTo(XpathSS.EnergyConsumptionDailyElectric, ValueSS.EnergyConsumptionDailyElectric);

					// Verify Energy regenerated vs. used (%)
					AssertElementIsEqualTo(XpathSS.EnergyRegeneratedDailyElectric, ValueSS.EnergyRegeneratedDailyElectric);

                    // Verify Energy for climatization vs. used (%) 
                    AssertElementIsEqualTo(XpathSS.EnergyForClimatizationDailyElectric, ValueSS.EnergyForClimatizationDailyElectric);

                    // Verify Average recharge time (hh:mm) 
                    AssertElementIsEqualTo(XpathSS.AverageRechargeTimeDailyElectric, ValueSS.AverageRechargeTimeDailyElectric);

                    // Verify Average recharged energy (kWh) 
                    AssertElementIsEqualTo(XpathSS.AverageRechargeEnergyDailyElectric, ValueSS.AverageRechargeEnergyDailyElectric);

					Console.WriteLine("\r\nScore Summary widget:Mission ");

					//Click on Mission
					JSFindElementAndClick(XpathSS.MissionTab, ValueSS.MissionTab, 2000);

                    // Verify Average distance per unit (km)
                    AssertElementIsEqualTo(XpathSS.AverageDistancePerUnitDailyElectric, ValueSS.AverageDistancePerUnitDailyElectric);

					// Verify Average trip time (dd:hh:mm) or (hh:mm)
					VerifyElement(XpathSS.AverageTripTimeDailyElectric);

                    // Verify Average speed (km/h)
                    AssertElementIsEqualTo(XpathSS.AverageSpeedDailyElectric, ValueSS.AverageSpeedDailyElectric);

                    // Verify Average gross combination weight (t)
                    AssertElementIsEqualTo(XpathSS.AverageGrossCombinationWeightDailyElectric, ValueSS.AverageGrossCombinationWeightDailyElectric);

                    // Verify Traction battery state of health (%)
                    AssertElementIsEqualTo(XpathSS.TractionBatteryStateOfHealthDailyElectric, ValueSS.TractionBatteryStateOfHealthDailyElectric);

                    // Verify Energy throughput (kWh)
                    AssertElementIsEqualTo(XpathSS.EnergyThroughputDailyElectric, ValueSS.EnergyThroughputDailyElectric);

                    Console.WriteLine("\r\nNews Feed widget");

					// Verified presence of News Feed 
					VerifyElement(XpathNF.NewsFeedContent);

					//Scroll website
					ScrollFunction();

					Console.WriteLine("\r\n Energy Usage widget");
					AssertElementIsEqualTo(XpathFC.EnergyUsage, ValueFC.EnergyUsage);

                    System.Threading.Thread.Sleep(30);

                    Console.WriteLine("\r\n Monitored Vehicles widget");
					AssertElementIsEqualTo(XpathMVL.MonitoredVehicles, ValueMVL.MonitoredVehicles); 

  

                    // Verify the presence of Add Vehicle button
                    VerifyElement(XpathMVL.AddVehicleButton);

                    // Verified KPI emissions presence
                    VerifyElement(XpathCE.Emissions);

					Console.WriteLine("\r\n DSE widget");

					// Driving Style Evaluation (vehicle related)
					AssertElementIsEqualTo(XpathDSE.DSEDriverRelatedLabelPath, ValueDSE.DSEDriverRelatedLabelPath);

                    // Verify Energy efficiency score KPI
                    AssertElementIsEqualTo(XpathDSE.EnergyEfficiencyScoreLabelPath, ValueDSE.EnergyEfficiencyScoreLabelPath);

					// Verify Acceleration KPI
					AssertElementIsEqualTo(XpathDSE.AccelerationLabelPath, ValueDSE.AccelerationLabelPath);

					// Verify Deceleration KPI
					AssertElementIsEqualTo(XpathDSE.DecelerationLabelPath, ValueDSE.DecelerationLabelPath);

					// Verify Energy Management KPI
					AssertElementIsEqualTo(XpathDSE.EnergyManagementLabelPath, ValueDSE.EnergyManagementLabelPath);

                    // Verify Vehicle care score KPI
                    AssertElementIsEqualTo(XpathDSE.VehicleCareScoreLabelPath, ValueDSE.VehicleCareScoreLabelPath);

                    // Verify Brake Use KPI
                    AssertElementIsEqualTo(XpathDSE.BrakeUseLabelPath, ValueDSE.BrakeUseLabelPath);

                    // Verify Tyres Label KPI
                    AssertElementIsEqualTo(XpathDSE.TyresLabelPath, ValueDSE.TyresLabelPath);

                    // Verify Safe Driving score KPI
                    AssertElementIsEqualTo(XpathDSE.SafeDrivingScoreLabelPath, ValueDSE.SafeDrivingScoreLabelPath);

                    Console.WriteLine("\r\n CO2 saved widget");
                    // Verified widget presence: CO2 Saved
                    AssertElementIsEqualTo(XpathCE.CO2Saved, "CO2 saved");

                    Console.WriteLine("\r\n Vehicles ranking widget");
					js.ExecuteScript("document.body.style.zoom = '0.10'");
					System.Threading.Thread.Sleep(1000);

                    // Verify Vehicles Ranking widget
                    Console.WriteLine("\r\n Vehicles ranking");
                    VerifyElement(XpathRanking.VehiclesRanking);


                    Console.WriteLine("\r\n Tips widget");

					// Verify Tips is present
					VerifyElement(XpathT.Tips);
					//Verify presence of the card: Acceleration
					VerifyElement(XpathT.AccelerationCard);
                    //Verify presence of the card: Deceleration
                    VerifyElement(XpathT.DecelerationCard);
                    //Verify presence of the card: Engine Use
                    VerifyElement(XpathT.EngineUseCard);

                    Console.WriteLine("\r\n My Daily widget");
                    // Verified widget presence: My Daily
                    AssertElementIsEqualTo(XpathMD.MyDaily, ValueMD.MyDaily);
                }
				else
				{
					Console.WriteLine("No check can be perfomed - Data is not available in the dashboard");
				}
			}
			catch (Exception e)
			{
				GetScreenshotAndPrintError(e);
			}
		}
	}
}