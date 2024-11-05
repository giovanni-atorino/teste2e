using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using myiveco_selenium.TestCases;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    [Parallelizable]
    public class TestAccountHeavy
    {
        public class Test_Account_Heavy_Diesel : Basic_Test

        {
            static string fuel_type = "1";
            static string vehicle_type = "1";
            static string dashboard = vehicle_type + fuel_type;

            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary XpathScoreSummary = new Xpath__Score_Summary();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__Monitored_Vehicles XpathMonitoredVehicles = new Xpath__Monitored_Vehicles();
            Xpath__Monitored_Drivers XpathMonitoredDrivers = new Xpath__Monitored_Drivers();
            Xpath__Ranking XpathRanking = new Xpath__Ranking();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();
            Xpath__Tips XpathTips = new Xpath__Tips();
            Xpath__DSE XpathDSE = new Xpath__DSE();


            [Test]
            public void BasicTestHeavyDiesel()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                BasicTestHeavy(XpathScoreSummary, XpathRanking, XpathTips, XpathCO2Emissions, XpathMonitoredVehicles, XpathMonitoredDrivers, XpathNewsFeed, XpathDSE, XpathFuelConsuption);
            }
        }

        public class Test_Account_Heavy_NP : Basic_Test
        {
            static string fuel_type = "2";
            static string vehicle_type = "1";
            static string dashboard = vehicle_type + fuel_type;

            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary XpathScoreSummary = new Xpath__Score_Summary();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__Monitored_Vehicles XpathMonitoredVehicles = new Xpath__Monitored_Vehicles();
            Xpath__Monitored_Drivers XpathMonitoredDrivers = new Xpath__Monitored_Drivers();
            Xpath__Ranking XpathRanking = new Xpath__Ranking();
            Xpath__DSE XpathDSE = new Xpath__DSE();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();
            Xpath__Tips XpathTips = new Xpath__Tips();

            [Test]
            public void BasicTestHeavyNP()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                BasicTestHeavy(XpathScoreSummary, XpathRanking, XpathTips, XpathCO2Emissions, XpathMonitoredVehicles, XpathMonitoredDrivers, XpathNewsFeed, XpathDSE, XpathFuelConsuption);
            }
        }
        public class LastPositionTest : LastPositionWidget
        {
            static string fuel_type_diesel = "1";
            static string fuel_type_NP = "2";
            static string vehicle_type = "1";
            static string dashboardHeavyDiesel = vehicle_type + fuel_type_diesel;
            static string dashboardHeavyNP = vehicle_type + fuel_type_NP;

            Values__LastPosition Value = new Values__LastPosition();
            Xpath__LastPosition Xpath = new Xpath__LastPosition();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();

            [Test]
            [Category("Last Position Widget")]
            public void LastPositionWidgetHeavyTest()
            {
                //Recover the data for dashboard Heavy Diesel
                DashboardChoice(dashboardHeavyDiesel);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                LastPositionTestHeavy(Xpath, Value);

                //Recover the data for dashboard Heavy NP
                DashboardChoice(dashboardHeavyNP);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                LastPositionTestHeavy(Xpath, Value);
            }
        }

        public class NextMaintenanceMonitoringTest : NextMaintenanceMonitoringWidget
        {
            static string fuel_type_diesel = "1";
            static string fuel_type_NP = "2";
            static string vehicle_type = "1";
            static string dashboardHeavyDiesel = vehicle_type + fuel_type_diesel;
            static string dashboardHeavyNP = vehicle_type + fuel_type_NP;

            Values__NextMaintenanceMonitoring Value = new Values__NextMaintenanceMonitoring();
            Xpath__NextMaintenanceMonitoring Xpath = new Xpath__NextMaintenanceMonitoring();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();

            [Test]
            [Category("Next Maintenance Monitoring Widget")]
            public void NextMaintenanceMonitoringWidgetHeavyTest()
            {
                //Recover the data for dashboard Heavy Diesel
                DashboardChoice(dashboardHeavyDiesel);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                NextMaintenanceMonitoringTest(Xpath, Value);

                //Recover the data for dashboard Heavy NP
                DashboardChoice(dashboardHeavyNP);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                NextMaintenanceMonitoringTest(Xpath, Value);
            }
        }
    }
}