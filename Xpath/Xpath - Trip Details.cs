using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__Trip_Details
    {
        public String DashboardView = "//div[@class='dashboard-type-container']";
        public String FuelSavingScorePath = "//app-score-summary-widget-content[@class='ng-star-inserted']//div[@id='extendedCard']/div[@class='label']";
        // Trip Details KPI xpath
        public String TripDetailsTab = "//div[@class='widget-title text-subtitle-1 padding-tb' and contains(text(), 'Trip details')]";
        public String EcoScore = "//pfe-tabs[@id='ranking-tabs']//div[@class='score-cards ng-star-inserted']//div[@id='extendedCard']/div[@class='label']";
        public String EcoScoreValue = "//pfe-tabs[@id='ranking-tabs']//div[@class='score-cards ng-star-inserted']//div[@class='ng-star-inserted']//div[@class='value']";
        public String TotalTripTime = "//pfe-tabs[@id='ranking-tabs']//div[@class='ng-star-inserted'][2]//app-widget-card/pfe-kpi-card[@class='PFElement']/div[1]";
        public String TotalTripTimeValue = "//pfe-tabs[@id='ranking-tabs']//div[@class='ng-star-inserted'][2]//app-widget-card/pfe-kpi-card[@class='PFElement']/div[2]";
        public String AverageSpeed = "//pfe-tabs[@id='ranking-tabs']//div[@class='ng-star-inserted'][3]//app-widget-card/pfe-kpi-card[@class='PFElement']/div[1]";
        public String AverageSpeedValue = "//pfe-tabs[@id='ranking-tabs']//div[@class='ng-star-inserted'][3]//app-widget-card/pfe-kpi-card[@class='PFElement']/div[2]";
        public String FuelConsumption = "//pfe-tabs[@id='ranking-tabs']//div[@class='ng-star-inserted'][5]//app-widget-card/pfe-kpi-card[@class='PFElement']/div[1]";
        public String FuelConsumptionValue = "//pfe-tabs[@id='ranking-tabs']//div[@class='ng-star-inserted'][5]//app-widget-card/pfe-kpi-card[@class='PFElement']/div[2]";
        public String Co2Emissions = "//pfe-tabs[@id='ranking-tabs']//div[@class='ng-star-inserted'][6]//app-widget-card/pfe-kpi-card[@class='PFElement']/div[1]";
        public String Co2EmissionsValue = "//pfe-tabs[@id='ranking-tabs']//div[@class='ng-star-inserted'][6]//app-widget-card/pfe-kpi-card[@class='PFElement']/div[2]";


        // Trip Details matrix xpath
        public String VehicleButton = "//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][2]//span[@class='ag-header-icon ag-header-expand-icon ag-header-expand-icon-collapsed']/span[@class='ag-icon ag-icon-contracted']";
        public String VehicleButtonExpanded = "//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][2]//span[@class='ag-icon ag-icon-expanded']";
        public String MissionButton = "//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][3]//span[@class='ag-header-icon ag-header-expand-icon ag-header-expand-icon-collapsed']/span[@class='ag-icon ag-icon-contracted']";
        public String MissionButtonExpanded = "//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][3]//span[@class='ag-icon ag-icon-expanded']";
        public String FuelConsumptionButton = "//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][4]//span[@class='ag-header-icon ag-header-expand-icon ag-header-expand-icon-collapsed']/span[@class='ag-icon ag-icon-contracted']";
        public String FuelConsumptionButtonExpanded = "//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][4]//span[@class='ag-icon ag-icon-expanded']";
        public String GridTrips = "myGridTrips";

        // Xpath for Download tests
        public String ExportDataTripDetails = "(//a[contains(text(),'Export Data')])[3]";
        public String ExportDataGrey = "(//pfe-cta[@aria-disabled='true'])[3]";
    }
}
