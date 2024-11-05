using Microsoft.VisualStudio.TestTools.UnitTesting;
using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;
using static myiveco_selenium.TestSuite_NoRegressionTest;

namespace myiveco_selenium
{

    [SetUpFixture]
    [Parallelizable]
    public class TestSuite_NoRegressionTest
    {
        public NUnit.Framework.TestContext TestContext { get; set; }
        static string tco_account_runsettings = NUnit.Framework.TestContext.Parameters["tco_account"].ToString();
        static string tco_pwd_runsettings = NUnit.Framework.TestContext.Parameters["tco_pwd"].ToString();
        static string hq_account_runsettings = NUnit.Framework.TestContext.Parameters["hq_account"].ToString();
        static string hq_pwd_runsettings = NUnit.Framework.TestContext.Parameters["hq_pwd"].ToString();
        static string dealer_account_runsettings = NUnit.Framework.TestContext.Parameters["dealer_account"].ToString();
        static string dealer_pwd_runsettings = NUnit.Framework.TestContext.Parameters["dealer_pwd"].ToString();
        static string fm2_account_runsettings = NUnit.Framework.TestContext.Parameters["fm_account2"].ToString();
        static string fm2_pwd_runsettings = NUnit.Framework.TestContext.Parameters["fm_pwd2"].ToString();
        static string directX_account_runsettings = NUnit.Framework.TestContext.Parameters["directX_account"].ToString();
        static string directX_pwd_runsettings = NUnit.Framework.TestContext.Parameters["directX_pwd"].ToString();
        public class DownloadSection : Download_Section
        {
            Values__Download Value = new Values__Download();
            Xpath__Download Xpath = new Xpath__Download();

            [Test]
            [Category("Download_NRT")]

            public void DownloadSectionTest() => DownloadSection(Xpath, Value);
        }

        public class DownloadNavigation : Download_Navigation
        {

            Values__Download Value = new Values__Download();
            Xpath__Download Xpath = new Xpath__Download();

            [Test]
            [Category("Download_NRT")]
            public void DownloadNavigationTest() => DownloadNavigation(Xpath, Value);
        }

        public class DownloadReport : Download_Report
        {

            Values__Download Value = new Values__Download();
            Xpath__Download Xpath = new Xpath__Download();

            [Test]
            [Category("Download_NRT")]
            public void DownloadReportTest() => DownloadReport(Xpath, Value);
        }

        public class VehiclesNavigation : Vehicles_Navigation
        {

            Values__Vehicles Value = new Values__Vehicles();
            Xpath__Vehicles Xpath = new Xpath__Vehicles();

            [Test]
            [Category("Vehicles_NRT")]
            public void VehiclesNavigationTest() => VehiclesNavigation(Xpath, Value);
        }

        public class VehiclesSection : Vehicles_Section
        {

            Values__Vehicles Value = new Values__Vehicles();
            Xpath__Vehicles Xpath = new Xpath__Vehicles();

            [Test]
            [Category("Vehicles_NRT")]
            public void VehiclesSectionTest() => VehiclesSection(Xpath, Value);
        }

        public class VehiclesMaintenance : Vehicles_Maintenance
        {

            Values__Vehicles Value = new Values__Vehicles();
            Xpath__Vehicles Xpath = new Xpath__Vehicles();

            [Test]
            [Category("Vehicles_NRT")]
            public void VehiclesMaintenanceTest() => VehiclesMaintenance(Xpath, Value);
        }

        public class VehiclesAddRemoveNewFleet : Vehicles_Add_Remove_New_Fleet
        {

            Values__Vehicles Value = new Values__Vehicles();
            Xpath__Vehicles Xpath = new Xpath__Vehicles();

            [Test]
            public void VehiclesAddRemoveNewFleetTest() => VehiclesAddRemoveNewFleet(Xpath, Value);
        }

        public class DriversSection : Driver_Section
        {

            Values__Drivers Value = new Values__Drivers();
            Xpath__Drivers Xpath = new Xpath__Drivers();

            [Test]
            [Category("Drivers_NRT")]
            public void ActiveDriversSectionTest() => DriversSection(Xpath, Value);
        }
        public class ArchivedDriversSection : Driver_Section_Archived_Drivers
        {

            Values__Drivers Value = new Values__Drivers();
            Xpath__Drivers Xpath = new Xpath__Drivers();

            [Test]
            [Category("Drivers_NRT")]
            public void ArchivedDriversSectionTest() => DriversSectionArchivedDrivers(Xpath, Value);
        }

        public class DriverSectionArchiveActiveOneDriver : Driver_Section_Archive_Reactive_One_Driver
        {

            Values__Drivers Value = new Values__Drivers();
            Xpath__Drivers Xpath = new Xpath__Drivers();

            [Test]
            [Category("Drivers_NRT")]
            public void DriverSectionArchiveActiveOneDriverTest() => DriversSectionArchiveReactiveOneDriver(Xpath, Value);
        }

        public class DriversSectionAddData : Driver_Section_Add_Data
        {

            Values__Drivers Value = new Values__Drivers();
            Xpath__Drivers Xpath = new Xpath__Drivers();

            [Test]
            [Category("Drivers_NRT")]
            public void DriversSectionTestData() => DriversSectionAddData(Xpath, Value);
        }

        public class DriversSectionModifyDatas : Driver_Section_Modify_Datas
        {

            Values__Drivers Value = new Values__Drivers();
            Xpath__Drivers Xpath = new Xpath__Drivers();

            [Test]
            [Category("Drivers_NRT")]
            public void DriversSectionModifyDatasTest() => DriversSectionModifyDatas(Xpath, Value);
        }


        public class DriversAddRemoveNewDriver : Driver_AddRemoveNewDriver
        {

            Values__Drivers Value = new Values__Drivers();
            Xpath__Drivers Xpath = new Xpath__Drivers();

            [Test]
            public void DriversAddRemoveNewDriverTest() => DriversAddRemoveNewDriver(Xpath, Value);
        }

        public class DriveSectionAddDriverPopUp : Driver_Section_AddDriverPopUp
        {

            Values__Drivers Value = new Values__Drivers();
            Xpath__Drivers Xpath = new Xpath__Drivers();

            [Test]
            [Category("Drivers_NRT")]
            public void DriveSectionAddDriverPopUpTest() => DriveSectionAddDriverPopUp(Xpath, Value);
        }

        public class SettingsSection : Settings_Section
        {

            Values__Settings Value = new Values__Settings();
            Xpath__Settings Xpath = new Xpath__Settings();

            [Test]
            [Category("Settings_NRT")]
            public void SettingsSectionTest() => SettingsSection(Xpath, Value);
        }

        public class SettingsSectionNavigation : Settings_Section_Navigation
        {

            Values__Settings Value = new Values__Settings();
            Xpath__Settings Xpath = new Xpath__Settings();

            [Test]
            [Category("Settings_NRT")]
            public void SettingsSectionNavigationTest() => SettingsSectionNavigation(Xpath, Value);
        }
        public class SettingsSectionChangePassword : Settings_Section_Change_Password
        {

            Values__Settings Value = new Values__Settings();
            Xpath__Settings Xpath = new Xpath__Settings();

            [Test]
            [Category("Settings_NRT")]
            public void SettingsSectionChangePasswordTest() => SettingsSectionChangePassword(Xpath, Value);
        }

        public class SettingsSectionPrivacySettings : Settings_Section_Privacy_Settings
        {

            Values__Settings Value = new Values__Settings();
            Xpath__Settings Xpath = new Xpath__Settings();

            [Test]
            [Category("Settings_NRT")]
            public void SettingsSectionPrivacySettingsTest() => SettingsSectionPrivacySettings(Xpath, Value);
        }

        public class SettingsSectionChangePrivacySettings : Settings_Section_Change_Privacy_Settings
        {

            Values__Settings Value = new Values__Settings();
            Xpath__Settings Xpath = new Xpath__Settings();

            [Test]
            [Category("Settings_NRT")]
            public void SettingsSectionChangePrivacySettingsTest() => SettingsSectionChangePrivacySettings(Xpath, Value);
        }

        public class SettingsSectionUpdateFields : Settings_Section_Update_Fields
        {
            static Account Account = new Account(fm2_account_runsettings, fm2_pwd_runsettings);
            public SettingsSectionUpdateFields() : base(Account) { }
            Values__Settings Value = new Values__Settings();
            Xpath__Settings Xpath = new Xpath__Settings();


            [Test]
            [Category("Settings_NRT")]
            public void SettingsSectionUpdateFieldsTest()
            {
                UpdateFields(Xpath, Value, Xpath.FuelConsumptionUnitskml, Value.FuelConsumptionUnitskml, Xpath.FuelConsumptionUnitskmkg, Value.FuelConsumptionUnitskmkg);
                UpdateFields(Xpath, Value, Xpath.FuelConsumptionUnitslkm, Value.FuelConsumptionUnitslkm, Xpath.FuelConsumptionUnitskgkm, Value.FuelConsumptionUnitskgkm);
            }
        }


        public class SettingsSectionUpdateFieldsElectric : Settings_Section_Update_Fields_Electric
        {
            static Account Account = new Account(fm2_account_runsettings, fm2_pwd_runsettings);
            public SettingsSectionUpdateFieldsElectric() : base(Account) { }
            Values__Settings Value = new Values__Settings();
            Xpath__Settings Xpath = new Xpath__Settings();


            [Test]
            [Category("Settings_NRT")]
            public void SettingsSectionUpdateFieldsElectricTest()
            {
                UpdateFieldsElectric(Xpath, Value, Xpath.EnergyConsumptionUnitskWhkm, Value.EnergyConsumptionUnitskWhkm);
                UpdateFieldsElectric(Xpath, Value, Xpath.EnergyConsumptionUnitskWh100km, Value.EnergyConsumptionUnitskWh100km);

            }
        }

        public class MarketplaceSection : Marketplace_Section
        {

            Values__Marketplace Value = new Values__Marketplace();
            Xpath__Marketplace Xpath = new Xpath__Marketplace();

            [Test]
            //[TestCaseSource("BrowserToRunWith")]
            [Category("Marketplace_NRT")]
            public void MarketplaceSectionTest() => MarketplaceSection(Xpath, Value);
        }


        public class MarketplaceSectionNavigation : Marketplace_Section_Navigation
        {
            static Account Account = new Account(fm2_account_runsettings, fm2_pwd_runsettings);
            public MarketplaceSectionNavigation() : base(Account) { }
            Values__Marketplace Value = new Values__Marketplace();
            Xpath__Marketplace Xpath = new Xpath__Marketplace();

            [Test]
            [Category("Marketplace_NRT")]
            public void MarketplaceSectionNavigationTest() => MarketplaceSectionNavigation(Xpath, Value);
        }

        public class MarketplaceSectionAddRemoveOneWidget : Marketplace_Section_Add_Remove_One_Widget
        {

            Values__Marketplace Value = new Values__Marketplace();
            Xpath__Marketplace Xpath = new Xpath__Marketplace();

            [Test]
            [Category("Marketplace_NRT")]
            public void MarketplaceSectionAddRemoveOneWidgetTest() => MarketplaceSectionAddRemoveOneWidget(Xpath, Value);
        }
        //PERMISSIONS NRT
        public class PermissionsSection : Permissions_Section
        {

            Values__Permissions Value = new Values__Permissions();
            Xpath__Permissions Xpath = new Xpath__Permissions();

            [Test]
            [Category("Permissions_NRT")]
            public void PermissionsSectionTest() => PermissionsSection(Xpath, Value);
        }

        public class PermissionsAssignPermissionSection : Permissions_Assign_Permission_Section
        {

            Values__Permissions Value = new Values__Permissions();
            Xpath__Permissions Xpath = new Xpath__Permissions();

            [Test]
            [Category("Permissions_NRT")]
            public void PermissionsAssignPermissionSectionTest() => PermissionsAssignPermissionSection(Xpath, Value);
        }

        public class PermissionsNavigation : Permissions_Navigation
        {

            Values__Permissions Value = new Values__Permissions();
            Xpath__Permissions Xpath = new Xpath__Permissions();

            [Test]
            [Category("Permissions_NRT")]
            public void PermissionsNavigationTest() => PermissionsNavigation(Xpath, Value);
        }

        public class PermissionsSectionAddRemoveAccount : Permissions_Section_AddRemoveAccount
        {

            Values__Permissions Value = new Values__Permissions();
            Xpath__Permissions Xpath = new Xpath__Permissions();

            [Test]
            [Category("Permissions_NRT")]
            public void PermissionsSectionAddRemoveAccountTest() => PermissionsSectionAddRemoveAccount(Xpath, Value);
        }

        public class PermissionsDetailsSection : Permissions_Details_Section
        {

            Values__Permissions Value = new Values__Permissions();
            Xpath__Permissions Xpath = new Xpath__Permissions();

            [Test]
            [Category("Permissions_NRT")]
            public void PermissionsDetailsSectionTest() => PermissionsDetailsSection(Xpath, Value);
        }
        public class PermissionsSectionHistory : Permissions_Section_History
        {

            Values__Permissions Value = new Values__Permissions();
            Xpath__Permissions Xpath = new Xpath__Permissions();

            [Test]
            [Category("Permissions_NRT")]
            public void PermissionsSectionHistoryTest() => PermissionsSectionHistory(Xpath, Value);
        }
        public class DemoTestDriveSectionVehicleFleet : Demo_Test_Drive_Section_Vehicle_Fleet
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public DemoTestDriveSectionVehicleFleet() : base(Account) { }

            Values__DemoTestDrive Value = new Values__DemoTestDrive();
            Xpath__DemoTestDrive Xpath = new Xpath__DemoTestDrive();

            [Test]
            [Category("Demo_test_drive")]
            public void DemoTestDriveSectionVehicleFleetTest() => DemoTestDriveSectionVehicleFleet(Xpath, Value);
        }

        public class DemoTestDriveSectionVehicleFleetAddVehiclePopup : Demo_Test_Drive_Section_Vehicle_Fleet_Add_Vehicle_Pop_up
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public DemoTestDriveSectionVehicleFleetAddVehiclePopup() : base(Account) { }

            Values__DemoTestDrive Value = new Values__DemoTestDrive();
            Xpath__DemoTestDrive Xpath = new Xpath__DemoTestDrive();

            [Test]
            [Category("Demo_test_drive")]
            public void DemoTestDriveSectionVehicleFleetAddVehiclePopupTest() => DemoTestDriveSectionVehicleFleetAddVehiclePopup(Xpath, Value);
        }
        public class DemoTestDriveSectionPlanningNavigation : Demo_Test_Drive_Section_Planning_Navigation
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public DemoTestDriveSectionPlanningNavigation() : base(Account) { }

            Values__DemoTestDrive Value = new Values__DemoTestDrive();
            Xpath__DemoTestDrive Xpath = new Xpath__DemoTestDrive();

            [Test]
            [Category("Demo_test_drive")]
            public void DemoTestDriveSectionPlanningNavigationTest() => DemoTestDriveSectionPlanningNavigation(Xpath, Value);
        }

        public class DemoTestDriveSectionPlanning : Demo_Test_Drive_Section_Planning
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public DemoTestDriveSectionPlanning() : base(Account) { }

            Values__DemoTestDrive Value = new Values__DemoTestDrive();
            Xpath__DemoTestDrive Xpath = new Xpath__DemoTestDrive();

            [Test]
            [Category("Demo_test_drive")]
            public void DemoTestDriveSectionPlanningTest() => DemoTestDriveSectionPlanning(Xpath, Value);
        }


        public class DemoTestDriveSectionReport : Demo_Test_Drive_Section_Report
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public DemoTestDriveSectionReport() : base(Account) { }

            Values__DemoTestDrive Value = new Values__DemoTestDrive();
            Xpath__DemoTestDrive Xpath = new Xpath__DemoTestDrive();

            [Test]
            [Category("Demo_test_drive")]
            public void DemoTestDriveSectionReportTest() => DemoTestDriveSectionReport(Xpath, Value);
        }

        public class DemoTestDriveSectionCards : Demo_Test_Drive_Section_Cards
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public DemoTestDriveSectionCards() : base(Account) { }

            Values__DemoTestDrive Value = new Values__DemoTestDrive();
            Xpath__DemoTestDrive Xpath = new Xpath__DemoTestDrive();

            [Test]
            [Category("Demo_test_drive")]
            public void DemoTestDriveSectionCardsTest() => DemoTestDriveSectionCards(Xpath, Value);
        }

        // COTRACTS NRT
        public class ContractsSectionNavigation : Contracts_Section_Navigation
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public ContractsSectionNavigation() : base(Account) { }

            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();

            [Test]
            [Category("Contracts_NRT")]
            public void ContractsNavigationTest() => ContractsSection(Xpath, Value);
        }

        public class ContractsSectionContractCreation : Contracts_Section_Contract_Creation
        {
            static Account Account = new Account(hq_account_runsettings, hq_pwd_runsettings);
            public ContractsSectionContractCreation() : base(Account) { }

            Values__Contracts Value = new Values__Contracts();
            Xpath__Contracts Xpath = new Xpath__Contracts();

            [Test]
            [Category("Contracts_NRT")]
            public void ContractsSectionContractCreationTest() => ContractsSectionContractCreation(Xpath, Value);
        }



        public class RegistrationTestForm : Registration_Test
        {
            Xpath__Registration Xpath = new Xpath__Registration();

            [Test]
            [Category("Registration")]
            public void RegistrationTest() => RegistrationTestForm(Xpath);
        }

        public class DriverDownloadTest : Driver_Download_Test
        {

            Values__Drivers Value = new Values__Drivers();
            Xpath__Drivers Xpath = new Xpath__Drivers();

            [Test]
            [Category("Download")]
            public void DriverDownloadFlowTest() => DriverDownloadFlow(Xpath, Value);
        }

        public class VehicleDownloadTest : Vehicle_Download_Test
        {

            Values__Vehicles Value = new Values__Vehicles();
            Xpath__Vehicles Xpath = new Xpath__Vehicles();

            [Test]
            [Category("Download")]
            public void VehicleDownloadFlowTest() => VehicleDownloadFlow(Xpath, Value);
        }


        public class DownloadDownloadTest : Download_Download_Test
        {

            Values__Download Value = new Values__Download();
            Xpath__Download Xpath = new Xpath__Download();

            [Test]
            [Category("Download")]
            public void DownloadDownloadFlowTest() => DownloadDownloadFlow(Xpath, Value);
        }

        public class PermissionsDownloadTest : Permissions_Download_Test
        {

            Values__Permissions Value = new Values__Permissions();
            Xpath__Permissions Xpath = new Xpath__Permissions();

            [Test]
            [Category("Download")]
            public void PermissionsDownloadFlowTest() => PermissionsDownloadFlow(Xpath, Value);
        }

        public class RankingDownloadTest : Ranking_Download_Test
        {

            Values__Widget_Export Value = new Values__Widget_Export();
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Download")]
            public void RankingDownloadFlowTest() => RankingDownloadFlow(Xpath, Value);
        }

        public class RankingDownloadHeavyBusTest : Ranking_Download_Test
        {

            Values__Widget_Export Value = new Values__Widget_Export();
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Download")]
            public void RankingDownloadFlowHeavyBusTest() => RankingDownloadFlowHeavyBus(Xpath, Value);
        }

        public class TripDetailsDownloadTest : TripDetails_Download_Test
        {
            static Account Account = new Account(fm2_account_runsettings, fm2_pwd_runsettings);

            public TripDetailsDownloadTest() : base(Account) { }

            Values__Widget_Export Value = new Values__Widget_Export();
            Xpath__Trip_Details Xpath = new Xpath__Trip_Details();

            [Test]
            [Category("Download")]
            public void TripDetailsDownloadFlowTest() => TripDetailsDownloadFlow(Xpath, Value);
        }

        public class DemoTestDriveSectionDownload : Demo_Test_Drive_Section_Download
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public DemoTestDriveSectionDownload() : base(Account) { }

            Values__DemoTestDrive Value = new Values__DemoTestDrive();
            Xpath__DemoTestDrive Xpath = new Xpath__DemoTestDrive();

            [Test]
            [Category("Download")]
            public void DemoTestDriveSectionDownloadTest() => DemoTestDriveSectionDownload(Xpath, Value);
        }

        public class TutorialTest : Tutorial_Test
        {
            Xpath__Tutorial Xpath = new Xpath__Tutorial();

            [Test]
            [Category("Tutorial")]
            public void Tutorial_Test() => Tutorial(Xpath);
        }
        public class AdvancedFiltersHeavyDieselDashboard : Advanced_Filters
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public AdvancedFiltersHeavyDieselDashboard() : base(Account) { }

            //Values__Contracts Value = new Values__Contracts();
            Xpath__AdvancedFilters Xpath = new Xpath__AdvancedFilters();
            static string fuel_type = "1";
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
            [Category("AdvancedFilters")]
            public void AdvancedFiltersTestHeavyDieselDAshboard()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathScoreSummary.DashboardView);
                int flag = AdvancedFilters(Xpath, dashboard);
                if (flag == 0)
                {
                    BasicTestHeavy(XpathScoreSummary, XpathRanking, XpathTips, XpathCO2Emissions, XpathMonitoredVehicles, XpathMonitoredDrivers, XpathNewsFeed, XpathDSE, XpathFuelConsuption);
                }
            }

        }

        public class AdvancedFiltersHeavyNPDAshboard : Advanced_Filters
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public AdvancedFiltersHeavyNPDAshboard() : base(Account) { }

            //Values__Contracts Value = new Values__Contracts();
            Xpath__AdvancedFilters Xpath = new Xpath__AdvancedFilters();
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
            [Category("AdvancedFilters")]
            public void AdvancedFiltersTestHeavyNPDAshboard()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathScoreSummary.DashboardView);
                int flag = AdvancedFilters(Xpath, dashboard);
                if (flag == 0)
                {
                    BasicTestHeavy(XpathScoreSummary, XpathRanking, XpathTips, XpathCO2Emissions, XpathMonitoredVehicles, XpathMonitoredDrivers, XpathNewsFeed, XpathDSE, XpathFuelConsuption);
                }

            }
        }

        public class AdvancedFiltersLightDieselDashboard : Advanced_Filters
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public AdvancedFiltersLightDieselDashboard() : base(Account) { }


            Xpath__AdvancedFilters Xpath = new Xpath__AdvancedFilters();
            static string fuel_type = "1";
            static string vehicle_type = "2";
            static string dashboard = vehicle_type + fuel_type;
            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary_Light XpathScoreSummary = new Xpath__Score_Summary_Light();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__Trip_Details XpathTripDetails = new Xpath__Trip_Details();
            Xpath__DSE_Light XpathDSE = new Xpath__DSE_Light();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();
            Xpath__Tips XpathTips = new Xpath__Tips();



            [Test]
            [Category("AdvancedFilters")]
            public void AdvancedFiltersTestLightDieselDashboard()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathScoreSummary.DashboardView);
                int flag = AdvancedFilters(Xpath, dashboard);
                if (flag == 0)
                {
                    BasicTestLight(XpathScoreSummary, XpathNewsFeed, XpathFuelConsuption, XpathTripDetails, XpathDSE, XpathCO2Emissions, XpathTips);

                }
            }
        }

        public class AdvancedFiltersHeavyBusDieselDashboard : Advanced_Filters
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public AdvancedFiltersHeavyBusDieselDashboard() : base(Account) { }

            Xpath__AdvancedFilters Xpath = new Xpath__AdvancedFilters();
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
            [Category("AdvancedFilters")]
            public void AdvancedFiltersTestHeavyBusDieselDashboard()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathScoreSummary.DashboardView);
                int flag = AdvancedFilters(Xpath, dashboard);
                if (flag == 0)
                {
                    BasicTestHeavyBus(XpathScoreSummary, XpathRanking, XpathTips, XpathCO2Emissions, XpathMonitoredVehicles, XpathNewsFeed, XpathDSE, XpathFuelConsuption);
                }
            }
        }

        public class AdvancedFiltersHeavyBusNPDashboard : Advanced_Filters
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public AdvancedFiltersHeavyBusNPDashboard() : base(Account) { }

            Xpath__AdvancedFilters Xpath = new Xpath__AdvancedFilters();
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
            [Category("AdvancedFilters")]
            public void AdvancedFiltersTestHeavyBusNPDashboard()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathScoreSummary.DashboardView);
                int flag = AdvancedFilters(Xpath, dashboard);
                if (flag == 0)
                {
                    BasicTestHeavyBus(XpathScoreSummary, XpathRanking, XpathTips, XpathCO2Emissions, XpathMonitoredVehicles, XpathNewsFeed, XpathDSE, XpathFuelConsuption);
                }
            }

        }

        public class AdvancedFiltersLightNPDashboard : Advanced_Filters
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public AdvancedFiltersLightNPDashboard() : base(Account) { }

            //Values__Contracts Value = new Values__Contracts();
            Xpath__AdvancedFilters Xpath = new Xpath__AdvancedFilters();
            static string fuel_type = "2";
            static string vehicle_type = "2";
            static string dashboard = vehicle_type + fuel_type;
            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary_Light XpathScoreSummary = new Xpath__Score_Summary_Light();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__Trip_Details XpathTripDetails = new Xpath__Trip_Details();
            Xpath__DSE_Light XpathDSE = new Xpath__DSE_Light();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();
            Xpath__Tips XpathTips = new Xpath__Tips();



            [Test]
            [Category("AdvancedFilters")]
            public void AdvancedFiltersTestLightNPDashboard()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathScoreSummary.DashboardView);
                int flag = AdvancedFilters(Xpath, dashboard);
                if (flag == 0)
                {
                    BasicTestLight(XpathScoreSummary, XpathNewsFeed, XpathFuelConsuption, XpathTripDetails, XpathDSE, XpathCO2Emissions, XpathTips);

                }

            }
        }

        public class AdvancedFiltersTwayDAshboard : Advanced_Filters
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public AdvancedFiltersTwayDAshboard() : base(Account) { }

            //Values__Contracts Value = new Values__Contracts();
            Xpath__AdvancedFilters Xpath = new Xpath__AdvancedFilters();
            static string fuel_type = "1";
            static string vehicle_type = "5";
            static string dashboard = vehicle_type + fuel_type;
            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary XpathScoreSummary = new Xpath__Score_Summary();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__Monitored_Vehicles XpathMonitoredVehicles = new Xpath__Monitored_Vehicles();
            Xpath__Ranking XpathRanking = new Xpath__Ranking();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();

            [Test]
            [Category("AdvancedFilters")]
            public void AdvancedFiltersTestTwayDAshboard()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathScoreSummary.DashboardView);
                int flag = AdvancedFilters(Xpath, dashboard);
                if (flag == 0)
                {
                    BasicTestTway(XpathScoreSummary, XpathRanking, XpathCO2Emissions, XpathMonitoredVehicles, XpathNewsFeed, XpathFuelConsuption);
                }

            }


        }
        public class AdvancedFiltersMultiContractsHeavyDieselDashboard : Advanced_Filters_Multi_Contracts
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public AdvancedFiltersMultiContractsHeavyDieselDashboard() : base(Account) { }

            Xpath__AdvancedFilters Xpath = new Xpath__AdvancedFilters();
            static string fuel_type = "1";
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
            [Category("AdvancedFilters")]
            public void AdvancedFiltersMultiContractsTestHeavyDieselDashboard()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathScoreSummary.DashboardView);
                int flag = AdvancedFiltersMultiContracts(Xpath, dashboard);
                if (flag == 0)
                {
                    BasicTestHeavy(XpathScoreSummary, XpathRanking, XpathTips, XpathCO2Emissions, XpathMonitoredVehicles, XpathMonitoredDrivers, XpathNewsFeed, XpathDSE, XpathFuelConsuption);
                }
            }
        }
        public class AdvancedFiltersMultiContractsHeavyNPDashboard : Advanced_Filters_Multi_Contracts
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public AdvancedFiltersMultiContractsHeavyNPDashboard() : base(Account) { }

            Xpath__AdvancedFilters Xpath = new Xpath__AdvancedFilters();
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
            [Category("AdvancedFilters")]
            public void AdvancedFiltersMultiContractsTestHeavyNPDashboard()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathScoreSummary.DashboardView);
                int flag = AdvancedFiltersMultiContracts(Xpath, dashboard);
                if (flag == 0)
                {
                    BasicTestHeavy(XpathScoreSummary, XpathRanking, XpathTips, XpathCO2Emissions, XpathMonitoredVehicles, XpathMonitoredDrivers, XpathNewsFeed, XpathDSE, XpathFuelConsuption);
                }
            }
        }
        public class AdvancedFiltersMultiContractsLightDieselDashboard : Advanced_Filters_Multi_Contracts
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public AdvancedFiltersMultiContractsLightDieselDashboard() : base(Account) { }

            Xpath__AdvancedFilters Xpath = new Xpath__AdvancedFilters();
            static string fuel_type = "1";
            static string vehicle_type = "2";
            static string dashboard = vehicle_type + fuel_type;
            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary_Light XpathScoreSummary = new Xpath__Score_Summary_Light();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__Trip_Details XpathTripDetails = new Xpath__Trip_Details();
            Xpath__DSE_Light XpathDSE = new Xpath__DSE_Light();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();
            Xpath__Tips XpathTips = new Xpath__Tips();

            [Test]
            [Category("AdvancedFilters")]
            public void AdvancedFiltersMultiContractsTestLightDieselDashboard()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathScoreSummary.DashboardView);
                int flag = AdvancedFiltersMultiContracts(Xpath, dashboard);
                if (flag == 0)
                {
                    BasicTestLight(XpathScoreSummary, XpathNewsFeed, XpathFuelConsuption, XpathTripDetails, XpathDSE, XpathCO2Emissions, XpathTips);
                }
            }
        }
        public class AdvancedFiltersMultiContractsLightNPDashboard : Advanced_Filters_Multi_Contracts
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public AdvancedFiltersMultiContractsLightNPDashboard() : base(Account) { }

            Xpath__AdvancedFilters Xpath = new Xpath__AdvancedFilters();
            static string fuel_type = "2";
            static string vehicle_type = "2";
            static string dashboard = vehicle_type + fuel_type;
            Xpath__CO2_Emissions XpathCO2Emissions = new Xpath__CO2_Emissions();
            Xpath__Score_Summary_Light XpathScoreSummary = new Xpath__Score_Summary_Light();
            Xpath__Fuel_Consumption XpathFuelConsuption = new Xpath__Fuel_Consumption();
            Xpath__Trip_Details XpathTripDetails = new Xpath__Trip_Details();
            Xpath__DSE_Light XpathDSE = new Xpath__DSE_Light();
            Xpath__News_Feed XpathNewsFeed = new Xpath__News_Feed();
            Xpath__Tips XpathTips = new Xpath__Tips();

            [Test]
            [Category("AdvancedFilters")]
            public void AdvancedFiltersMultiContractsTestLightNPDashboard()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathScoreSummary.DashboardView);
                int flag = AdvancedFiltersMultiContracts(Xpath, dashboard);
                if (flag == 0)
                {
                    BasicTestLight(XpathScoreSummary, XpathNewsFeed, XpathFuelConsuption, XpathTripDetails, XpathDSE, XpathCO2Emissions, XpathTips);
                }
            }
        }
        public class AdvancedFiltersMultiContractsHeavyBusDieselDashboard : Advanced_Filters_Multi_Contracts
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public AdvancedFiltersMultiContractsHeavyBusDieselDashboard() : base(Account) { }

            Xpath__AdvancedFilters Xpath = new Xpath__AdvancedFilters();
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
            [Category("AdvancedFilters")]
            public void AdvancedFiltersMultiContractsTestHeavyBusDieselDashboard()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathScoreSummary.DashboardView);
                int flag = AdvancedFiltersMultiContracts(Xpath, dashboard);
                if (flag == 0)
                {
                    BasicTestHeavyBus(XpathScoreSummary, XpathRanking, XpathTips, XpathCO2Emissions, XpathMonitoredVehicles, XpathNewsFeed, XpathDSE, XpathFuelConsuption);
                }
            }
        }

        public class AdvancedFiltersMultiContractsHeavyBusNPDashboard : Advanced_Filters_Multi_Contracts
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public AdvancedFiltersMultiContractsHeavyBusNPDashboard() : base(Account) { }

            Xpath__AdvancedFilters Xpath = new Xpath__AdvancedFilters();
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
            [Category("AdvancedFilters")]
            public void AdvancedFiltersMultiContractsTestHeavyBusNPDashboard()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathScoreSummary.DashboardView);
                int flag = AdvancedFiltersMultiContracts(Xpath, dashboard);
                if (flag == 0)
                {
                    BasicTestHeavyBus(XpathScoreSummary, XpathRanking, XpathTips, XpathCO2Emissions, XpathMonitoredVehicles, XpathNewsFeed, XpathDSE, XpathFuelConsuption);
                }
            }

        }

        public class AdvancedFiltersHeavyBusElectricDashboard : Advanced_Filters
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public AdvancedFiltersHeavyBusElectricDashboard() : base(Account) { }

            Xpath__AdvancedFilters Xpath = new Xpath__AdvancedFilters();
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
            [Category("AdvancedFilters")]
            public void AdvancedFiltersTestHeavyBusElectricDashboard()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathScoreSummary.DashboardView);
                int flag = AdvancedFilters(Xpath, dashboard);
                if (flag == 0)
                {
                    BasicTestHeavyBusElectric(XpathScoreSummary, XpathRanking, XpathTips, XpathCO2Emissions, XpathMonitoredVehicles, XpathNewsFeed, XpathDSE, XpathFuelConsuption, ValueScoreSummary, ValueRanking, ValueTips, ValueCO2Emissions, ValueMonitoredVehicles, ValueDSE, ValueFuelConsuption);
                }
            }
        }

        public class AdvancedFiltersDailyElectricDashboard : Advanced_Filters
        {
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            public AdvancedFiltersDailyElectricDashboard() : base(Account) { }

            Xpath__AdvancedFilters Xpath = new Xpath__AdvancedFilters();
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
            [Category("AdvancedFilters")]
            public void AdvancedFiltersTestDailyElectricDashboard()
            {
                DashboardChoice(dashboard);
                RefreshCheck(XpathScoreSummary.DashboardView);
                int flag = AdvancedFilters(Xpath, dashboard);
                if (flag == 0)
                {
                    BasicTestDailyElectric(XpathScoreSummary, XpathRanking, XpathTips, XpathCO2Emissions, XpathMonitoredVehicles, XpathNewsFeed, XpathDSE, XpathFuelConsuption, XpathMyDaily, ValueScoreSummary, ValueRanking, ValueTips, ValueCO2Emissions, ValueMonitoredVehicles, ValueDSE, ValueFuelConsuption, ValueMyDaily);
                }
            }

        }
        public class SKAManagement : SKA_Management
        {
            static Account Account = new Account(hq_account_runsettings, hq_pwd_runsettings);
            public SKAManagement() : base(Account) { }

            Values__SKAManagement Value = new Values__SKAManagement();
            Xpath__SKAManagement Xpath = new Xpath__SKAManagement();

            [Test]
            [Category("SKAManagement")]
            public void SKAManagementTest() => SKAManagement(Xpath, Value);
        }

        public class DealerManagement : Dealer_Management
        {
            static Account Account = new Account(hq_account_runsettings, hq_pwd_runsettings);
            public DealerManagement() : base(Account) { }

            Values__DealerManagement Value = new Values__DealerManagement();
            Xpath__DealerManagement Xpath = new Xpath__DealerManagement();

            [Test]
            [Category("DealerManagement")]
            public void DealerManagementTest() => DealerManagement(Xpath, Value);
        }

        public class ServiceReferences : Service_References
        {
            static Account Account = new Account(hq_account_runsettings, hq_pwd_runsettings);
            public ServiceReferences() : base(Account) { }

            Values__ServiceReferences Value = new Values__ServiceReferences();
            Xpath__ServiceReferences Xpath = new Xpath__ServiceReferences();

            [Test]
            [Category("ServiceReference")]
            public void ServiceReferenceTest() => ServiceReferences(Xpath, Value);
        }

        public class ServiceReferencesHDSAndSKAAssignment : Service_References_HDSAndSKAAssignment
        {
            static Account Account = new Account(hq_account_runsettings, hq_pwd_runsettings);
            public ServiceReferencesHDSAndSKAAssignment() : base(Account) { }

            Values__ServiceReferences Value = new Values__ServiceReferences();
            Xpath__ServiceReferences Xpath = new Xpath__ServiceReferences();

            [Test]
            [Category("ServiceReference")]
            public void ServiceReferencesHDSAndSKAAssignmentTest() => HDSandSKAAssignment(Xpath, Value);
        }
        public class ServiceReferencesCustomerContactable : Service_References_CustomerContactable
        {
            static Account Account = new Account(hq_account_runsettings, hq_pwd_runsettings);
            public ServiceReferencesCustomerContactable() : base(Account) { }

            Values__ServiceReferences Value = new Values__ServiceReferences();
            Xpath__ServiceReferences Xpath = new Xpath__ServiceReferences();

            [Test]
            [Category("ServiceReference")]
            public void ServiceReferencesCustomerContactableTest() => CustomerContactable(Xpath, Value);
        }

        public class CompanyManagement : Company_Management
        {
            static Account Account = new Account(hq_account_runsettings, hq_pwd_runsettings);
            public CompanyManagement() : base(Account) { }

            Values__CompanyManagement Value = new Values__CompanyManagement();
            Xpath__CompanyManagement Xpath = new Xpath__CompanyManagement();

            [Test]
            [Category("CompanyManagement")]
            public void CompanyManagementTest() => CompanyManagement(Xpath, Value);
        }

        public class ChangeFleetManager : Change_Fleet_Manager_Section
        {
            static Account Account = new Account(hq_account_runsettings, hq_pwd_runsettings);
            public ChangeFleetManager() : base(Account) { }

            Values__ChangeFleetManager Value = new Values__ChangeFleetManager();
            Xpath__ChangeFleetManager Xpath = new Xpath__ChangeFleetManager();

            [Test]
            [Category("CompanyManagement")]
            public void ChangeFleetManagerTest() => ChangeFleetManager(Xpath, Value);
        }

        public class ChangeFleetManagerRegisteredUser : Change_Fleet_Manager
        {
            static Account Account = new Account(hq_account_runsettings, hq_pwd_runsettings);
            public ChangeFleetManagerRegisteredUser() : base(Account) { }

            Values__ChangeFleetManager Value = new Values__ChangeFleetManager();
            Xpath__ChangeFleetManager Xpath = new Xpath__ChangeFleetManager();

            [Test]
            [Category("CompanyManagement")]
            public void ChangeFleetManagerRegisteredUserTest() => ChangeFleetManagerRegisteredUser(Xpath, Value);
        }

        public class ChangeFleetManagerNotRegisteredUser : Change_Fleet_Manager
        {
            static Account Account = new Account(hq_account_runsettings, hq_pwd_runsettings);
            public ChangeFleetManagerNotRegisteredUser() : base(Account) { }

            Values__ChangeFleetManager Value = new Values__ChangeFleetManager();
            Xpath__ChangeFleetManager Xpath = new Xpath__ChangeFleetManager();

            [Test]
            [Category("CompanyManagement")]
            public void ChangeFleetManagerNotRegisteredUserTest() => ChangeFleetManagerNotRegisteredUser(Xpath, Value);
        }

        public class ChangeFleetManagerInsertsSameMFM : Change_Fleet_Manager
        {
            static Account Account = new Account(hq_account_runsettings, hq_pwd_runsettings);
            public ChangeFleetManagerInsertsSameMFM() : base(Account) { }

            Values__ChangeFleetManager Value = new Values__ChangeFleetManager();
            Xpath__ChangeFleetManager Xpath = new Xpath__ChangeFleetManager();

            [Test]
            [Category("CompanyManagement")]
            public void ChangeFleetManagerInsertsSameMFMTest() => ChangeFleetManagerInsertsSameMFM(Xpath, Value);
        }

        public class ChangeFleetManagerInsertsNewMFM : Change_Fleet_Manager
        {
            static Account Account = new Account(hq_account_runsettings, hq_pwd_runsettings);
            public ChangeFleetManagerInsertsNewMFM() : base(Account) { }

            Values__ChangeFleetManager Value = new Values__ChangeFleetManager();
            Xpath__ChangeFleetManager Xpath = new Xpath__ChangeFleetManager();

            [Test]
            [Category("CompanyManagement")]
            public void ChangeFleetManagerInsertsNewMFMTest() => ChangeFleetManagerInsertsNewMFM(Xpath, Value);
        }

        public class ChangeMainAccount : Change_Main_Account_Section
        {
            static Account Account = new Account(hq_account_runsettings, hq_pwd_runsettings);
            public ChangeMainAccount() : base(Account) { }

            Values__ChangeMainAccount Value = new Values__ChangeMainAccount();
            Xpath__ChangeMainAccount Xpath = new Xpath__ChangeMainAccount();

            [Test]
            [Category("CompanyManagement")]
            public void ChangeMainAccountTest() => ChangeMainAccount(Xpath, Value);
        }

        public class ChangeMainAccountRegisteredUser : Change_Main_Account
        {
            static Account Account = new Account(hq_account_runsettings, hq_pwd_runsettings);
            public ChangeMainAccountRegisteredUser() : base(Account) { }

            Values__ChangeMainAccount Value = new Values__ChangeMainAccount();
            Xpath__ChangeMainAccount Xpath = new Xpath__ChangeMainAccount();

            [Test]
            [Category("CompanyManagement")]
            public void ChangeMainAccountRegisteredUserTest() => ChangeMainAccountRegisteredUser(Xpath, Value);
        }

        public class ChangeMainAccountNotRegisteredUser : Change_Main_Account
        {
            static Account Account = new Account(hq_account_runsettings, hq_pwd_runsettings);
            public ChangeMainAccountNotRegisteredUser() : base(Account) { }

            Values__ChangeMainAccount Value = new Values__ChangeMainAccount();
            Xpath__ChangeMainAccount Xpath = new Xpath__ChangeMainAccount();

            [Test]
            [Category("CompanyManagement")]
            public void ChangeMainAccountNotRegisteredUserTest() => ChangeMainAccountNotRegisteredUser(Xpath, Value);
        }
        public class ChangeMainAccountInsertsSameMA : Change_Main_Account
        {
            static Account Account = new Account(hq_account_runsettings, hq_pwd_runsettings);
            public ChangeMainAccountInsertsSameMA() : base(Account) { }

            Values__ChangeMainAccount Value = new Values__ChangeMainAccount();
            Xpath__ChangeMainAccount Xpath = new Xpath__ChangeMainAccount();

            [Test]
            [Category("CompanyManagement")]
            public void ChangeMainAccountInsertsSameMATest() => ChangeMainAccountInsertsSameMA(Xpath, Value);
        }

        public class ChangeMainAccountInsertsNewMA : Change_Main_Account
        {
            static Account Account = new Account(hq_account_runsettings, hq_pwd_runsettings);
            public ChangeMainAccountInsertsNewMA() : base(Account) { }

            Values__ChangeMainAccount Value = new Values__ChangeMainAccount();
            Xpath__ChangeMainAccount Xpath = new Xpath__ChangeMainAccount();

            [Test]
            [Category("CompanyManagement")]
            public void ChangeMainAccountInsertsNewMATest() => ChangeMainAccountInsertsNewMA(Xpath, Value);
        }

        public class NotificationCenter : Notification_Center
        {
            Values__NotificationCenter Value = new Values__NotificationCenter();
            Xpath__NotificationCenter Xpath = new Xpath__NotificationCenter();

            [Test]
            [Category("NotificationCenter")]
            public void NotificationCenterTest() => NotificationCenter(Xpath, Value);
        }

        public class RecallCampaignsVerifyTable : Recall_Campaigns
        {
            Values__RecallCampaigns Value = new Values__RecallCampaigns();
            Xpath__RecallCampaigns Xpath = new Xpath__RecallCampaigns();

            [Test]
            [Category("RecallCampaigns")]
            public void RecallCampaignsVerifyTableTest()
            {
                RecallCampaignsOpenMenu(Xpath, Value);
                RecallCampaignsVerifyTable(Xpath, Value);
            }
        }

        public class RecallCampaignsAdvancedFilters : Recall_Campaigns
        {
            public RecallCampaignsAdvancedFilters() : base(Account) { }
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            Values__RecallCampaigns Value = new Values__RecallCampaigns();
            Xpath__RecallCampaigns Xpath = new Xpath__RecallCampaigns();


            [Test]
            [Category("RecallCampaigns")]
            public void RecallCampaignsAdvancedFiltersTest()
            {
                RecallCampaignsOpenMenu(Xpath, Value);
                RecallCampaignsAdvancedFilters(Xpath, Value);
                RecallCampaignsVerifyTable(Xpath, Value);
            }
        }
        public class RecallCampaignsDifferentCountry : Recall_Campaigns
        {
            public RecallCampaignsDifferentCountry() : base(Account) { }
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            Values__RecallCampaigns Value = new Values__RecallCampaigns();
            Xpath__RecallCampaigns Xpath = new Xpath__RecallCampaigns();


            [Test]
            [Category("RecallCampaigns")]
            public void RecallCampaignsDifferentCountryTest()
            {
                RecallCampaignsOpenMenu(Xpath, Value);
                RecallCampaignsDifferentCountry(Xpath, Value);


            }

        }


        public class FinancialService : Financial_Service
        {
            static Account Account = new Account(directX_account_runsettings, directX_pwd_runsettings);
            public FinancialService() : base(Account) { }

            Values__FinancialService Value = new Values__FinancialService();
            Xpath__FinancialService Xpath = new Xpath__FinancialService();

            [Test]
            [Category("FinancialService_NRT")]
            public void FinancialServiceTest() => FinancialService(Xpath, Value);
        }

        public class FinancialServiceFilters : Financial_Service
        {
            static Account Account = new Account(directX_account_runsettings, directX_pwd_runsettings);
            public FinancialServiceFilters() : base(Account) { }

            Values__FinancialService Value = new Values__FinancialService();
            Xpath__FinancialService Xpath = new Xpath__FinancialService();

            [Test]
            [Category("FinancialService_NRT")]
            public void FinancialServiceFiltersTest() => FinancialServiceFilters(Xpath, Value);
        }

        public class DirectX : Financial_Service
        {
            static Account Account = new Account(directX_account_runsettings, directX_pwd_runsettings);
            public DirectX() : base(Account) { }

            Values__FinancialService Value = new Values__FinancialService();
            Xpath__FinancialService Xpath = new Xpath__FinancialService();

            [Test]
            [Category("FinancialService_NRT")]
            public void DirectXTest() => DirectX(Xpath, Value);
        }

        public class ContentManager : Content_Manager
        {
            public ContentManager() : base(Account) { }
            static Account Account = new Account(tco_account_runsettings, tco_pwd_runsettings);
            Values__ContentManager Value = new Values__ContentManager();
            Xpath__ContentManager Xpath = new Xpath__ContentManager();


            [Test]
            [Category("ContentManager")]
            public void ContentMangerSectionTest()
            {
                ContentManagerSection(Xpath, Value);


            }

        }
        public class ChargingCardSectionSupport : Charging_Card_Section
        {
            static Account Account = new Account(hq_account_runsettings, hq_pwd_runsettings);

            Values__ChargingCard Value = new Values__ChargingCard();
            Xpath__ChargingCard Xpath = new Xpath__ChargingCard();

            [Test]
            [Category("ChargingCardSection")]
            public void ChargingCardSectionTest() => ChargingCardSection(Xpath, Value);
        }

        public class ChargingCardSectionCustomer : Charging_Card_Section
        {

            Values__ChargingCard Value = new Values__ChargingCard();
            Xpath__ChargingCard Xpath = new Xpath__ChargingCard();

            [Test]
            [Category("ChargingCardSection")]
            public void ChargingCardSectionTest() => ChargingCardSection(Xpath, Value);
        }

        public class ChargingSessionSection : Charging_Session_Section
        {
            Values__ChargingSession Value = new Values__ChargingSession();
            Xpath__ChargingSession Xpath = new Xpath__ChargingSession();

            [Test]
            [Category("ChargingSessionSection")]
            public void ChargingSessionSectionTest() => ChargingSessionSection(Xpath, Value);
        }
        public class RemoteCommandsSection : RemoteCommands_Session_Section
        {

            Values__RemoteCommands Value = new Values__RemoteCommands();
            Xpath__RemoteCommands Xpath = new Xpath__RemoteCommands();

            [Test]
            [Category("RemoteCommandsSection")]
            public void RemoteCommandsSectionTest() => RemoteCommandsSection(Xpath, Value);
        }
        public class RemoteCommandsSectionMY24 : RemoteCommandsMY24_Session_Section
        {

            Values__RemoteCommands Value = new Values__RemoteCommands();
            Xpath__RemoteCommands Xpath = new Xpath__RemoteCommands();

            [Test]
            [Category("RemoteCommandsSection")]
            public void RemoteCommandsSectionMY24Test() => RemoteCommandsSectionMY24(Xpath, Value);
        }
        public class MeRsection : MeR_Section
        {

            Values__MeR Value = new Values__MeR();
            Xpath__MeR Xpath = new Xpath__MeR();

            [Test]
            [Category("M&R Section")]
            public void MeRsectionTest() => MeRsection(Xpath, Value);
        }
    }
}