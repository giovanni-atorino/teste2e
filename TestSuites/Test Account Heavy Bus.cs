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
    public class TestAccountHeavyBus
    {
        static string fm2_account_runsettings = NUnit.Framework.TestContext.Parameters["fm_account2"].ToString();
        static string fm2_pwd_runsettings = NUnit.Framework.TestContext.Parameters["fm_pwd2"].ToString();
        public class Test_Account_HeavyBus_Diesel : Basic_Test

        {
            static string fuel_type = "1";
            static string vehicle_type = "3";
            static string dashboard = vehicle_type + fuel_type;

            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary XpathScoreSummary = new Xpath__Score_Summary();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__Monitored_Vehicles XpathMonitoredVehicles = new Xpath__Monitored_Vehicles();
            Xpath__Ranking XpathRanking = new Xpath__Ranking();
            Xpath__DSE XpathDSE = new Xpath__DSE();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();
            Xpath__Tips XpathTips = new Xpath__Tips();

            [Test]
            public void BasicTestHeavyBusDiesel()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                BasicTestHeavyBus(XpathScoreSummary, XpathRanking, XpathTips, XpathCO2Emissions, XpathMonitoredVehicles, XpathNewsFeed, XpathDSE, XpathFuelConsuption);
            }
        }

        public class Test_Account_HeavyBus_NP : Basic_Test

        {
            static string fuel_type = "2";
            static string vehicle_type = "3";
            static string dashboard = vehicle_type + fuel_type;

            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary XpathScoreSummary = new Xpath__Score_Summary();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__Monitored_Vehicles XpathMonitoredVehicles = new Xpath__Monitored_Vehicles();
            Xpath__Ranking XpathRanking = new Xpath__Ranking();
            Xpath__DSE XpathDSE = new Xpath__DSE();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();
            Xpath__Tips XpathTips = new Xpath__Tips();

            [Test]
            public void BasicTestHeavyBusNP()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                BasicTestHeavyBus(XpathScoreSummary, XpathRanking, XpathTips, XpathCO2Emissions, XpathMonitoredVehicles, XpathNewsFeed, XpathDSE, XpathFuelConsuption);
            }
        }

        public class Test_Account_HeavyBus_Electric : Basic_Test

        {
            static string fuel_type = "3";
            static string vehicle_type = "3";
            static string dashboard = vehicle_type + fuel_type;

            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary XpathScoreSummary = new Xpath__Score_Summary();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__Monitored_Vehicles XpathMonitoredVehicles = new Xpath__Monitored_Vehicles();
            Xpath__Ranking XpathRanking = new Xpath__Ranking();
            Xpath__DSE XpathDSE = new Xpath__DSE();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();
            Xpath__Tips XpathTips = new Xpath__Tips();

            Values__CO2_Emissions_Label ValueCO2Emissions = new Values__CO2_Emissions_Label();
            Values__Score_Summary_Label ValueScoreSummary = new Values__Score_Summary_Label();
            Values__Fuel_Consumption_Label ValueFuelConsuption = new Values__Fuel_Consumption_Label();
            Values__Monitored_Vehicles_Label ValueMonitoredVehicles = new Values__Monitored_Vehicles_Label();
            Values__Ranking_Label ValueRanking = new Values__Ranking_Label();
            Values__DSE_Label ValueDSE = new Values__DSE_Label();
            Values__Tips_Label ValueTips = new Values__Tips_Label();

            [Test]
            public void BasicTestHeavyBusElectric()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                BasicTestHeavyBusElectric(XpathScoreSummary, XpathRanking, XpathTips, XpathCO2Emissions, XpathMonitoredVehicles, XpathNewsFeed, XpathDSE, XpathFuelConsuption, ValueScoreSummary, ValueRanking, ValueTips, ValueCO2Emissions, ValueMonitoredVehicles, ValueDSE, ValueFuelConsuption);
            }
        }

        public class KPI_DashboardHeavyBusDiesel : KPI_Dashboard
        {
            static Account Account = new Account(fm2_account_runsettings, fm2_pwd_runsettings);
            public KPI_DashboardHeavyBusDiesel() : base(Account) {}
            static string fuel_type = "1";
            static string vehicle_type = "3";
            static string dashboard = vehicle_type + fuel_type;

            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary XpathScoreSummary = new Xpath__Score_Summary();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__Monitored_Vehicles XpathMonitoredVehicles = new Xpath__Monitored_Vehicles();
            Xpath__Ranking XpathRanking = new Xpath__Ranking();
            Xpath__DSE XpathDSE = new Xpath__DSE();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();

            [Test]
            public void KPIDashboardHeavyBusDiesel()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                KPIDashboardHeavyBus(XpathScoreSummary, XpathRanking, XpathCO2Emissions, XpathDSE, XpathFuelConsuption, dashboard);
            }
        }
        public class KPI_DashboardHeavyBusNP : KPI_Dashboard
        {
            static Account Account = new Account(fm2_account_runsettings, fm2_pwd_runsettings);
            public KPI_DashboardHeavyBusNP() : base(Account) {}
            static string fuel_type = "2";
            static string vehicle_type = "3";
            static string dashboard = vehicle_type + fuel_type;

            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary XpathScoreSummary = new Xpath__Score_Summary();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__Monitored_Vehicles XpathMonitoredVehicles = new Xpath__Monitored_Vehicles();
            Xpath__Ranking XpathRanking = new Xpath__Ranking();
            Xpath__DSE XpathDSE = new Xpath__DSE();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();

            [Test]
            public void KPIDashboardHeavyBusNP()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                KPIDashboardHeavyBus(XpathScoreSummary, XpathRanking, XpathCO2Emissions, XpathDSE, XpathFuelConsuption, dashboard);
            }
        }
        public class LastPositionTest : LastPositionWidget
        {
            static string fuel_type_diesel = "1";
            static string fuel_type_NP = "2";
            static string vehicle_type = "3";
            static string dashboardHeavyBusDiesel = vehicle_type + fuel_type_diesel;
            static string dashboardHeavyBusNP = vehicle_type + fuel_type_NP;

            Values__LastPosition Value = new Values__LastPosition();
            Xpath__LastPosition Xpath = new Xpath__LastPosition();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();

            [Test]
            [Category("Last Position Widget")]
            public void LastPositionWidgetHeavyBusTest()
            {
                //Recover the data for dashboard HeavyBus Diesel
                DashboardChoice(dashboardHeavyBusDiesel);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                LastPositionTestHeavy(Xpath, Value);

                //Recover the data for dashboard HeavyBus NP
                DashboardChoice(dashboardHeavyBusNP);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                LastPositionTestHeavy(Xpath, Value);
            }
        }
    }
}
