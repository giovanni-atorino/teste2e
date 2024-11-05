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
    public class TestAccountHeavyAndLight
    {
        static string fm2_account_runsettings = NUnit.Framework.TestContext.Parameters["fm_account2"].ToString();
        static string fm2_pwd_runsettings = NUnit.Framework.TestContext.Parameters["fm_pwd2"].ToString();
        public class Test_Account_Heavy_Diesel : Basic_Test
        {

            static string fuel_type = "1";
            static string vehicle_type = "1";
            static string dashboard = vehicle_type + fuel_type ;

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
            static string dashboard = vehicle_type + fuel_type ;

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


        public class Test_Account_Light_Diesel : Basic_Test

        {
            static string fuel_type = "1";
            static string vehicle_type = "2";
            static string dashboard = vehicle_type + fuel_type ;

            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary_Light XpathScoreSummary = new Xpath__Score_Summary_Light();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__Trip_Details XpathTripDetails = new Xpath__Trip_Details();
            Xpath__DSE_Light XpathDSE = new Xpath__DSE_Light();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();
            Xpath__Tips XpathTips = new Xpath__Tips();
            [Test]
            public void BasicTestLightDiesel()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                BasicTestLight(XpathScoreSummary, XpathNewsFeed, XpathFuelConsuption, XpathTripDetails, XpathDSE, XpathCO2Emissions, XpathTips);
            }
        }

        public class Test_Account_Light_NP : Basic_Test

        {
            static Account Account = new Account(fm2_account_runsettings, fm2_pwd_runsettings);
            public Test_Account_Light_NP() : base(Account) { }
            static string fuel_type = "2";
            static string vehicle_type = "2";
            static string dashboard = vehicle_type + fuel_type ;

            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary_Light XpathScoreSummary = new Xpath__Score_Summary_Light();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__Trip_Details XpathTripDetails = new Xpath__Trip_Details();
            Xpath__DSE_Light XpathDSE = new Xpath__DSE_Light();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();
            Xpath__Tips XpathTips = new Xpath__Tips();

            [Test]
            public void BasicTestLightNP()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                BasicTestLight(XpathScoreSummary, XpathNewsFeed, XpathFuelConsuption, XpathTripDetails, XpathDSE, XpathCO2Emissions, XpathTips);
            }
        }

            public class KPI_Dashboard1 : KPI_Dashboard
            {
            static Account Account = new Account(fm2_account_runsettings, fm2_pwd_runsettings);
            public KPI_Dashboard1() : base(Account) { }
            static string fuel_type = "1";
            static string vehicle_type = "1";
            static string dashboard = vehicle_type + fuel_type ;

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
                public void KPIDashboardHeavyDiesel()
                {
                DashboardChoice(dashboard);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                KPIDashboardHeavy(XpathScoreSummary,  XpathRanking, XpathCO2Emissions, XpathDSE, XpathFuelConsuption,dashboard);
                }
            }

        public class KPI_Dashboard2 : KPI_Dashboard
        {
            static Account Account = new Account(fm2_account_runsettings, fm2_pwd_runsettings);
            public KPI_Dashboard2() : base(Account) { }
            static string fuel_type = "2";
            static string vehicle_type = "1";
            static string dashboard = vehicle_type + fuel_type ;

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
            public void KPIDashboardHeavyNP()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                KPIDashboardHeavy(XpathScoreSummary, XpathRanking, XpathCO2Emissions, XpathDSE, XpathFuelConsuption, dashboard);
            }
        }

        public class KPI_Dashboard3 : KPI_Dashboard
        {
            static Account Account = new Account(fm2_account_runsettings, fm2_pwd_runsettings);
            public KPI_Dashboard3() : base(Account) { }
            static string fuel_type = "1";
            static string vehicle_type = "2";
            static string dashboard = vehicle_type + fuel_type ;

            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary_Light XpathScoreSummary = new Xpath__Score_Summary_Light();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__Trip_Details XpathTripDetails = new Xpath__Trip_Details();
            Xpath__DSE_Light XpathDSE = new Xpath__DSE_Light();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();
            Xpath__Tips XpathTips = new Xpath__Tips();

            [Test]
            public void KPIDashboardLightDiesel()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                KPIDashboardLight(XpathScoreSummary, XpathFuelConsuption, XpathTripDetails, XpathDSE, XpathCO2Emissions, dashboard);
            }
        }

        public class KPI_Dashboard4 : KPI_Dashboard
        {
            static Account Account = new Account(fm2_account_runsettings, fm2_pwd_runsettings);
            public KPI_Dashboard4() : base(Account) { }
            static string fuel_type = "2";
            static string vehicle_type = "2";
            static string dashboard = vehicle_type + fuel_type ;

            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary_Light XpathScoreSummary = new Xpath__Score_Summary_Light();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__Trip_Details XpathTripDetails = new Xpath__Trip_Details();
            Xpath__DSE_Light XpathDSE = new Xpath__DSE_Light();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();
            Xpath__Tips XpathTips = new Xpath__Tips();

            [Test]
            public void KPIDashboardLightNP()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                KPIDashboardLight(XpathScoreSummary, XpathFuelConsuption, XpathTripDetails, XpathDSE, XpathCO2Emissions, dashboard);
            }
        }

        public class KPI_Dashboard5 : KPI_Dashboard
        {
            static Account Account = new Account(fm2_account_runsettings, fm2_pwd_runsettings);
            public KPI_Dashboard5() : base(Account) { }
            static string fuel_type = "3";
            static string vehicle_type = "2";
            static string dashboard = vehicle_type + fuel_type;

            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary_Light XpathScoreSummary = new Xpath__Score_Summary_Light();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__DSE_Light XpathDSE = new Xpath__DSE_Light();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();
            Xpath__Tips XpathTips = new Xpath__Tips();

            [Test]
            public void KPIDashboard_DailyElectric()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                KPIDashboardDailyElectric(XpathScoreSummary, XpathFuelConsuption, XpathDSE, XpathCO2Emissions, dashboard);
            }
        }


        public class KPI_Dashboard6 : KPI_Dashboard
        {
            static Account Account = new Account(fm2_account_runsettings, fm2_pwd_runsettings);
            public KPI_Dashboard6() : base(Account) { }
            static string fuel_type = "3";
            static string vehicle_type = "3";
            static string dashboard = vehicle_type + fuel_type;

            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Ranking XpathRanking = new Xpath__Ranking();
            Xpath__Score_Summary XpathScoreSummary = new Xpath__Score_Summary();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__DSE XpathDSE = new Xpath__DSE();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();
            Xpath__Tips XpathTips = new Xpath__Tips();


           [Test]
            public void KPIDashboardBus_Electric()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                KPIDashboardBusElectric(XpathScoreSummary, XpathFuelConsuption, XpathRanking, XpathDSE, XpathCO2Emissions, dashboard);
            }
        }


        public class KroneTest : KroneWidget
        {
            Values__KRONE Value = new Values__KRONE();
            Xpath__KRONE Xpath = new Xpath__KRONE();


            [Test]
            [Category("Krone")]
            public void KRONE() => KroneTest(Xpath, Value);
        }
        public class KroneDataTest : KroneWidget
        {
            // Define query parameters used in filters
            static string frequency = "d";
            static string from_date = "1644192000000";
            static string to_date = "1644451199000";
            static string vehicle_list = "WJMM62AUZ0C426214";
            static string fuel_type = "1";
            static string fleet_id = "-1";
            static string vehicle_type = "1";
            static string dashboard = vehicle_type + fuel_type;

            Values__KRONE Value = new Values__KRONE();
            Xpath__KRONE Xpath = new Xpath__KRONE();
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);

            [Test]
            [Category("Krone")]
            public void KRONEData() => KroneDataTest(Xpath, Value, Filters);
        }
    }
}
