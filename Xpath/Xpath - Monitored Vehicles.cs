using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__Monitored_Vehicles
    {
        public String DashboardView = "//div[@class='dashboard-type-container']";
        public String AddVehicleButton = "//*[@id='monitoredVehiclesContent']/div/div[2]/pfe-cta/a";
        public String MonitoredVehicles = "#widgetContainer14 .widget-title";  
        public String MonitoredVehicle1 = ".ng-star-inserted:nth-child(1) > .vehicle-card .id";
        public String FuelSavingScore1 = ".ng-star-inserted:nth-child(1) > .vehicle-card .element-detail:nth-child(2) > .label";
        public String FuelSavingScoreValue1 = ".ng-star-inserted:nth-child(1) > .vehicle-card .element-detail:nth-child(2) > .value";
        public String VehicleCareScore1 = ".ng-star-inserted:nth-child(1) > .vehicle-card .element-detail:nth-child(3) > .label";
        public String VehicleCareScoreValue1 = ".ng-star-inserted:nth-child(1) > .vehicle-card .element-detail:nth-child(3) > .value";
        public String TotalAverageFuelConsuption1 = ".ng-star-inserted:nth-child(1) > .vehicle-card .element-detail:nth-child(4) > .label";
        public String TotalAverageFuelConsuptionValue1 = ".ng-star-inserted:nth-child(1) > .vehicle-card .element-detail:nth-child(4) > .value";
        public String CO2Emissions1 = ".ng-star-inserted:nth-child(1) > .vehicle-card .element-detail:nth-child(5) > .label";
        public String CO2EmissionsValue1 = ".ng-star-inserted:nth-child(1) > .vehicle-card .element-detail:nth-child(5) > .value";
        public String SafeGuideScore1 = ".ng-star-inserted:nth-child(1) > .vehicle-card .element-detail:nth-child(6) > .label";
        public String SafeGuideScoreValue1 = ".ng-star-inserted:nth-child(1) > .vehicle-card .element-detail:nth-child(6) > .value";
        public String ActionButton = "//*[@id='widgetContainer14']//*[contains(@id, 'action-tooltip')]";
        public String FuelSavingScore = "//div[@class='element-detail text-body ng-star-inserted']//span[contains (text(),'Fuel saving score')]";
        public String FuelSavingScoreValue = "//div[@class='element-detail text-body ng-star-inserted']//span[contains (text(),'Fuel saving score')]/following-sibling::span";
        public String AvgTotalFuelConsumption = "//div[@class='element-detail text-body ng-star-inserted']//span[contains (text(),' Average total fuel consumption')]";
        public String AvgTotalFuelConsumptionValue = "//div[@class='element-detail text-body ng-star-inserted']//span[contains (text(),' Average total fuel consumption')]/following-sibling::span";
        public String PTOvalue = "//div[@class='element-detail text-body ng-star-inserted']//span[contains (text(),'PTO')]/following-sibling::span";
        public String IdlingValue = "//div[@class='element-detail text-body ng-star-inserted']//span[contains (text(),'Idling')]/following-sibling::span";
        public String CO2Emission = "//div[@class='element-detail text-body ng-star-inserted']//span[contains (text(),'CO2 emission')]";
        public String CO2EmissionValue = "//div[@class='element-detail text-body ng-star-inserted']//span[contains (text(),'CO2 emission')]/following-sibling::span";
        public String ComfortScore = "//div[@class='element-detail text-body ng-star-inserted']//span[contains (text(),'Comfort score')]";
        public String ComfortScoreValue = "//div[@class='element-detail text-body ng-star-inserted']//span[contains (text(),'Comfort score')]/following-sibling::span";
        public String YesButton = "//div[@id='monitoredVehiclesContent']//button[@class='button confirm padding-lr text-body']";
    }
}