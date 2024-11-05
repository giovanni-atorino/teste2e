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
    public class TestAccountLight
    {
        static string fm2_account_runsettings = NUnit.Framework.TestContext.Parameters["fm_account2"].ToString();
        static string fm2_pwd_runsettings = NUnit.Framework.TestContext.Parameters["fm_pwd2"].ToString();

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
            Xpath__MyDaily XpathMyDaily = new Xpath__MyDaily();


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
            Xpath__MyDaily XpathMyDaily = new Xpath__MyDaily();

            [Test]
            public void BasicTestLightNP()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                BasicTestLight(XpathScoreSummary, XpathNewsFeed, XpathFuelConsuption, XpathTripDetails, XpathDSE, XpathCO2Emissions, XpathTips);
             

            }
        }

        public class Test_Account_Daily_Electric : Basic_Test

        {
            static string fuel_type = "3";
            static string vehicle_type = "2";
            static string dashboard = vehicle_type + fuel_type;

            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary_Light XpathScoreSummary = new Xpath__Score_Summary_Light();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__Monitored_Vehicles_Light XpathMonitoredVehicles = new Xpath__Monitored_Vehicles_Light();
            Xpath__Ranking_Light XpathRanking = new Xpath__Ranking_Light();
            Xpath__DSE_Light XpathDSE = new Xpath__DSE_Light();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();
            Xpath__Tips XpathTips = new Xpath__Tips();
            Xpath__MyDaily_Light XpathMyDaily = new Xpath__MyDaily_Light();

            Values__CO2_Emissions_Label ValueCO2Emissions = new Values__CO2_Emissions_Label();
            Values__Score_Summary_Label ValueScoreSummary = new Values__Score_Summary_Label();
            Values__Fuel_Consumption_Label ValueFuelConsuption = new Values__Fuel_Consumption_Label();
            Values__Monitored_Vehicles_Label ValueMonitoredVehicles = new Values__Monitored_Vehicles_Label();
            Values__Ranking_Label ValueRanking = new Values__Ranking_Label();
            Values__DSE_Label ValueDSE = new Values__DSE_Label();
            Values__Tips_Label ValueTips = new Values__Tips_Label();
            Values__MyDaily ValueMyDaily = new Values__MyDaily();


            [Test]
            public void BasicTestDaily_Electric()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                BasicTestDailyElectric(XpathScoreSummary, XpathRanking, XpathTips, XpathCO2Emissions, XpathMonitoredVehicles, XpathNewsFeed, XpathDSE, XpathFuelConsuption, XpathMyDaily, ValueScoreSummary, ValueRanking, ValueTips, ValueCO2Emissions, ValueMonitoredVehicles, ValueDSE, ValueFuelConsuption, ValueMyDaily);
            }
        }

        public class TestMyDaily
        {
            static string fm2_account_runsettings = NUnit.Framework.TestContext.Parameters["fm_account2"].ToString();
            static string fm2_pwd_runsettings = NUnit.Framework.TestContext.Parameters["fm_pwd2"].ToString();

            public class Test_MyDaily : MyDaily_Widget

            {
                static string fuel_type_diesel = "1";
                static string fuel_type_NP = "2";
                static string vehicle_type = "2";
                static string dashboardLightDiesel = vehicle_type + fuel_type_diesel;
                static string dashboardLightNP = vehicle_type + fuel_type_NP;

                Xpath__MyDaily XpathMyDaily = new Xpath__MyDaily();
                Values__MyDaily ValueMyDaily = new Values__MyDaily();


                [Test]
                public void MyDailyWidget()
                {
                    //Recover the data for dashboard Light Diesel
                    DashboardChoice(dashboardLightDiesel);
                    RefreshCheck(XpathMyDaily.ScoreSummaryWidget);
                    MyDailyWidget( XpathMyDaily, ValueMyDaily);

                    //Recover the data for dashboard Light NP
                    DashboardChoice(dashboardLightNP);
                    RefreshCheck(XpathMyDaily.ScoreSummaryWidget);
                    MyDailyWidget(XpathMyDaily, ValueMyDaily);



                }
            }
        }
        public class LastPositionTest : LastPositionWidget
        {
            static string fuel_type_diesel = "1";
            static string fuel_type_NP = "2";
            static string vehicle_type = "2";
            static string dashboardLightDiesel = vehicle_type + fuel_type_diesel;
            static string dashboardLightNP = vehicle_type + fuel_type_NP;

            Values__LastPosition Value = new Values__LastPosition();
            Xpath__LastPosition Xpath = new Xpath__LastPosition();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();

            [Test]
            [Category("Last Position Widget")]
            public void LastPositionWidgetLightTest()
            {
                //Recover the data for dashboard Light Diesel
                DashboardChoice(dashboardLightDiesel);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                LastPositionTestLight(Xpath, Value);

                //Recover the data for dashboard Light NP
                DashboardChoice(dashboardLightNP);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                LastPositionTestLight(Xpath, Value);
            }
        }

        public class NextMaintenanceMonitoringTest : NextMaintenanceMonitoringWidget
        {
            static string fuel_type_diesel = "1";
            static string fuel_type_NP = "2";
            static string vehicle_type = "2";
            static string dashboardLightDiesel = vehicle_type + fuel_type_diesel;
            static string dashboardLightNP = vehicle_type + fuel_type_NP;

            Values__NextMaintenanceMonitoring Value = new Values__NextMaintenanceMonitoring();
            Xpath__NextMaintenanceMonitoring Xpath = new Xpath__NextMaintenanceMonitoring();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();

            [Test]
            [Category("Next Maintenance Monitoring Widget")]
            public void NextMaintenanceMonitoringLightTest()
            {
                //Recover the data for dashboard Light Diesel
                DashboardChoice(dashboardLightDiesel);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                NextMaintenanceMonitoringTest(Xpath, Value);

                //Recover the data for dashboard Light NP
                DashboardChoice(dashboardLightNP);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                NextMaintenanceMonitoringTest(Xpath, Value);
            }
        }


        public class PayPerUseWidget : PayPerUse
        {
            static string fuel_type_diesel = "1";
            static string fuel_type_NP = "2";
            static string vehicle_type = "2";
            static string dashboardLightDiesel = vehicle_type + fuel_type_diesel;
            static string dashboardLightNP = vehicle_type + fuel_type_NP;

            Values__PayPerUse Value = new Values__PayPerUse();
            Xpath__PayPerUse Xpath = new Xpath__PayPerUse();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();

            [Test]
            [Category("Pay Per Use Widget")]
            public void PayPerUseTest()
            {
                //Recover the data for dashboard Light Diesel
                DashboardChoice(dashboardLightDiesel);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                PayPerUseView(Xpath, Value);

                //Recover the data for dashboard Light NP
                DashboardChoice(dashboardLightNP);
                RefreshCheck(XpathNewsFeed.NewsFeedContent);
                PayPerUseView(Xpath, Value);
            }
        }
    }
}
