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
    public class TestAccountTway
    {
        static string fm2_account_runsettings = NUnit.Framework.TestContext.Parameters["fm_account2"].ToString();
        static string fm2_pwd_runsettings = NUnit.Framework.TestContext.Parameters["fm_pwd2"].ToString();
        public class Test_Account_Tway_Diesel : Basic_Test
        {

            static string fuel_type = "1";
            static string vehicle_type = "5";
            static string dashboard = vehicle_type + fuel_type;

            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary XpathScoreSummary = new Xpath__Score_Summary();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__Monitored_Vehicles XpathMonitoredVehicles = new Xpath__Monitored_Vehicles();
            Xpath__Ranking XpathRanking = new Xpath__Ranking();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();
            Xpath__Tips XpathTips = new Xpath__Tips();

            [Test]
            public void BasicTestTwayDiesel()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                BasicTestTway(XpathScoreSummary, XpathRanking, XpathCO2Emissions, XpathMonitoredVehicles, XpathNewsFeed, XpathFuelConsuption);
            }
        }


        public class KPI_DashboardTway : KPI_Dashboard
        {
            static Account Account = new Account(fm2_account_runsettings, fm2_pwd_runsettings);
            public KPI_DashboardTway() : base(Account)
            {
            }
            static string fuel_type = "1";
            static string vehicle_type = "5";
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
            public void KPIDashboardTwayDiesel()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathScoreSummary.AverageSpeed);
                KPIDashboardTway(XpathScoreSummary, XpathRanking, XpathCO2Emissions, XpathFuelConsuption, dashboard);
            }
        }
        public class LastPositionTest : LastPositionWidget
        {
            static string fuel_type_diesel = "1";
            static string vehicle_type = "5";
            static string dashboardTwayDiesel = vehicle_type + fuel_type_diesel;

            Values__LastPosition Value = new Values__LastPosition();
            Xpath__LastPosition Xpath = new Xpath__LastPosition();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();

            [Test]
            [Category("Last Position Widget")]
            public void LastPositionWidgetTwayTest()
            {
                //Recover the data for dashboard Tway Diesel
                DashboardChoice(dashboardTwayDiesel);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                LastPositionTestHeavy(Xpath, Value);
            }
        }
        public class NextMaintenanceMonitoringTest : NextMaintenanceMonitoringWidget
        {
            static string fuel_type_diesel = "1";
            static string vehicle_type = "5";
            static string dashboardTwayDiesel = vehicle_type + fuel_type_diesel;

            Values__NextMaintenanceMonitoring Value = new Values__NextMaintenanceMonitoring();
            Xpath__NextMaintenanceMonitoring Xpath = new Xpath__NextMaintenanceMonitoring();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();

            [Test]
            [Category("Next Maintenance Monitoring Widget")]
            public void NextMaintenanceMonitoringTwayTest()
            {
                //Recover the data for dashboard Tway Diesel
                DashboardChoice(dashboardTwayDiesel);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                NextMaintenanceMonitoringTest(Xpath, Value);
            }
        }
    }
}
