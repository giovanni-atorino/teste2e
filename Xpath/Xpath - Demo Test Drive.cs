using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__DemoTestDrive
    {
        public String Menu = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String DemoTestDrive = "//pfe-accordion[5]//h5[contains (text (),'Demo Test Drive')]";
        public String VehicleFleet = "//*[@id='shoulder-left']//a[@href='/demo-test-drive/vehicles']";
        public String Report = "//*[@id='shoulder-left']//a[@href='/demo-test-drive/report']";
        public String Planning = "//*[@id='shoulder-left']//a[@href='/demo-test-drive/planning']";
        public String AddVehicles = "//div[@class='row margin']//a[contains(text(),'Add vehicles')]";

        public String VehicleDataTabOPENED = "//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][1]//span[@class='ag-icon ag-icon-contracted']";
        public String CompanyDataTabOPENED = "//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][2]//span[@class='ag-icon ag-icon-contracted']";
        public String VehicleDataTabCLOSED = "//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][1]//span[@class='ag-icon ag-icon-expanded']";

        //Vehicle fleet
        public String VINCode = "//span[contains(text(),'VIN code')]";
        public String VehicleName = "//span[contains(text(),'Vehicle name')]";
        public String Model = "//span[contains(text(),'Model')]";
        public String Fuel = "//span[contains(text(),'Fuel')]";
        public String DemoOnDate = "//span[contains(text(),'Demo on date')]";
        public String DemoOffDate = "//span[contains(text(),'Demo off date')]";
        public String WarrantyStartDate = "//span[contains(text(),'Warranty start date')]";
        public String DemoExpire = "//span[contains(text(),'Demo Expire (dd)')]";
        public String Market = "//span[contains(text(),'Market')]";
        public String MarketNetwork = "//span[contains(text(),'Market/Network')]";
        public String CompanyName = "//span[contains(text(),'Company Name')]";
        public String SapCode = "//span[contains(text(),'Sap Code')]";
        public String Status = "//span[contains(text(),'Status')]";
        public String Action = "//span[contains(text(),'Action')]";
        public String ServiceEndDate = "//span[contains(text(),'Service end date')]";
        public String LightTab = "//*[@id='lightTab']/span";
        public String HeavyTab = "//*[@id='heavyTab']/span";
        public String HeavyBusTab = "//*[@id='busTab']/span";
        public String TwayTab = "//*[@id='twayTab']/span";
        public String FilterStatusIcon = "//app-dtd-list-view-vehicles//div[@col-id='status']//span[@class='ag-icon ag-icon-menu']";
        public String FilterFuelIcon = "//app-dtd-list-view-vehicles//div[@col-id='fuel']//span[@class='ag-icon ag-icon-menu']";
        public String DemoONSelection = "//*[@id='Demo on']";
        public String DieselSelection = "//*[@id='Diesel']";
        public String NPSelection = "//*[@id='NP']";
        public String TotalCountDemoON = "//*[@id='vehiclesListDemoTestDriver']//span[@ref='lbRecordCount']";
        //Planning
        public String month = "//*[@id='planning-tabs']//button[contains(text(),'month')]";
        public String week = "//*[@id='planning-tabs']//button[contains(text(),'week')]";
        public String day = "//*[@id='planning-tabs']//button[3][contains(text(),'Day')]";
        public String List = "//*[@id='planning-tabs']//button[contains(text(),'List')]";
        public String VIN = "//span[contains(text(), 'VIN')]";
        public String Plate = "//span[contains(text(),'Plate')]";
        public String Company = "//span[contains(text(),'Company')]";
        public String StartDate = "//span[contains(text(),'Start date')]";
        public String EndDate = "//span[contains(text(),'End date')]";
        public String Id = "//span[contains(text(),'Id')]";
        public String Duration = "//span[contains(text(),'Duration')]";
        public String Name = "//span[contains(text(),'Name')]";
        public String Surname = "//span[contains(text(),'Surname')]";
        public String Email = "//span[contains(text(),'Email')]";
        public String CreationDate = "//span[contains(text(),'Creation date')]";
        public String AccountUser = "//span[contains(text(),'Account user')]";
        public String AccountName = "//span[contains(text(),'Account Name')]";
        public String DealerDataOPENED = "//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='0_0']//span[@class='ag-icon ag-icon-contracted']";
        public String CustomerDataOPENED = "//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='1_0']//span[@class='ag-icon ag-icon-contracted']";
        public String VehicleDataOPENED = "//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='2_0']//span[@class='ag-icon ag-icon-contracted']";
        public String DataCreationOPENED = "//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='3_0']//span[@class='ag-icon ag-icon-contracted']";

        //Report
        public String DemosDieselCount = "//*[@id='report-tabs']/pfe-tab-panel[1]//div[1]/div/div[2]/div[1]/div[3]";
        public String DemosGasCount = "//*[@id='report-tabs']/pfe-tab-panel[1]//div[1]/div/div[2]/div[2]/div[3]";
        public String DemoElectricCount = "//*[@id='report-tabs']/pfe-tab-panel[2]//div[1]/div/div[2]/div[3]/div[3]";
        public String FiltersButton = "//*[@id='root']//a[contains(text(), 'Filters')]";
        public String FilterFrom = "//*[@id='root']//app-dtd-report-filters//div[3]/div/div[@class='time-filter padding']";
        public String FilterTo = "//*[@id='root']//app-dtd-report-filters//div[4]/div/div[@class='time-filter padding']";
        public String ApplyButton = "//*[@id='root']//a[contains(text(), 'Apply')]";
        //CARD Heavy
        public String DemoDieselCardHeavy = "//pfe-tab-panel[1]/div[2]/div[1]//div[contains (text (),'Diesel')]";
        public String DemoTestDriveDieselHeavy = "//pfe-tab-panel[1]/div[2]/div[2]//div[contains (text (),'Diesel')]";
        public String AverageDistanceTestDriveDieselHeavy = "//pfe-tab-panel[1]/div[2]/div[3]//div[contains (text (),'Diesel')]";
        public String AverageTimeTestDriveDieselHeavy = "//pfe-tab-panel[1]/div[2]/div[4]//div[contains (text (),'Diesel')]";
        public String DemosGasHeavy = "//pfe-tab-panel[1]/div[2]/div[1]//div[contains (text (),'NP')]";
        public String DemoTestDriveGasHeavy = "//pfe-tab-panel[1]/div[2]/div[2]//div[contains (text (),'NP')]";
        public String AverageDistanceTestDriveGasHeavy = "//pfe-tab-panel[1]/div[2]/div[3]//div[contains (text (),'NP')]";
        public String AverageTimeDriveGasHeavy = "//pfe-tab-panel[1]/div[2]/div[4]//div[contains (text (),'NP')]";
        //CARD Light
        public String DemoDieselCardLight = "//pfe-tab-panel[2]/div[2]/div[1]//div[contains (text (),'Diesel')]";
        public String DemoTestDriveDieselLight = "//pfe-tab-panel[2]/div[2]/div[2]//div[contains (text (),'Diesel')]";
        public String AverageDistanceTestDriveDieselLight = "//pfe-tab-panel[2]/div[2]/div[3]//div[contains (text (),'Diesel')]";
        public String AverageTimeTestDriveDieselLight = "//pfe-tab-panel[2]/div[2]/div[4]//div[contains (text (),'Diesel')]";
        public String DemosGasLight = "//pfe-tab-panel[2]/div[2]/div[1]//div[contains (text (),'NP')]";
        public String DemoTestDriveGasLight = "//pfe-tab-panel[2]/div[2]/div[2]//div[contains (text (),'NP')]";
        public String AverageDistanceTestDriveGasLight = "//pfe-tab-panel[2]/div[2]/div[3]//div[contains (text (),'NP')]";
        public String AverageTimeDriveGasLight = "//pfe-tab-panel[2]/div[2]/div[4]//div[contains (text (),'NP')]";
        //CARD HeavyBus
        public String DemoDieselCardHeavyBus = "//pfe-tab-panel[3]/div[2]/div[1]//div[contains (text (),'Diesel')]";
        public String DemoTestDriveDieselHeavyBus = "//pfe-tab-panel[3]/div[2]/div[2]//div[contains (text (),'Diesel')]";
        public String AverageDistanceTestDriveDieselHeavyBus = "//pfe-tab-panel[3]/div[2]/div[3]//div[contains (text (),'Diesel')]";
        public String AverageTimeTestDriveDieselHeavyBus = "//pfe-tab-panel[3]/div[2]/div[4]//div[contains (text (),'Diesel')]";
        public String DemosGasHeavyBus = "//pfe-tab-panel[3]/div[2]/div[1]//div[contains (text (),'NP')]";
        public String DemoTestDriveGasHeavyBus = "//pfe-tab-panel[3]/div[2]/div[2]//div[contains (text (),'NP')]";
        public String AverageDistanceTestDriveGasHeavyBus = "//pfe-tab-panel[3]/div[2]/div[3]//div[contains (text (),'NP')]";
        public String AverageTimeDriveGasHeavyBus = "//pfe-tab-panel[3]/div[2]/div[4]//div[contains (text (),'NP')]";
        //CARD Tway
        public String DemoDieselCardTway = "//pfe-tab-panel[4]/div[2]/div[1]//div[contains (text (),'Diesel')]";
        public String DemoTestDriveDieselTway = "//pfe-tab-panel[4]/div[2]/div[2]//div[contains (text (),'Diesel')]";
        public String AverageDistanceTestDriveDieselTway = "//pfe-tab-panel[4]/div[2]/div[3]//div[contains (text (),'Diesel')]";
        public String AverageTimeTestDriveDieselTway = "//pfe-tab-panel[4]/div[2]/div[4]//div[contains (text (),'Diesel')]";
        public String DemosGasTway = "//pfe-tab-panel[4]/div[2]/div[1]//div[contains (text (),'NP')]";
        public String DemoTestDriveGasTway = "//pfe-tab-panel[4]/div[2]/div[2]//div[contains (text (),'NP')]";
        public String AverageDistanceTestDriveGasTway = "//pfe-tab-panel[4]/div[2]/div[3]//div[contains (text (),'NP')]";
        public String AverageTimeDriveGasTway = "//pfe-tab-panel[4]/div[2]/div[4]//div[contains (text (),'NP')]";

        /**public String ShowVehicleDetail = "//a[contains(text(),'Show vehicles detail')]";
        public String TypeLight = "//*[@id='ewaLightPermissionList']//span[contains(text(), 'Type')]";
        public String GivenByLight = "//*[@id='ewaLightPermissionList']//span[contains(text(), 'Given by')]";
        public String WhenLight = "//*[@id='ewaLightPermissionList']//span[contains(text(), 'When')]";
        **/
        public String ExportData = "//a[contains(text(),'Export Data')]";
        public String ExportDataHeavyFleet = "//a[contains(text(),'Export Data')]";
        public String ExportDataLightFleet = "//a[contains(text(),'Export Data')]";
        public String DownloadMask = "//div[@id='maskBooking']";
    }
}