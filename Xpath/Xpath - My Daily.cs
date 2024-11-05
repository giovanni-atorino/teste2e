using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__MyDaily

    {
        public String TotVehicleinFilterBar = "//*[@id='filterBar']/div[@class='dashboard-type-container standard-filters-breadcrumb']/div[5]/strong";
        public String DashboardView = "//div[@class='dashboard-type-container']";
        public String ScoreSummaryWidget = "//*[@id='scoreSummaryContent']";
        public String MyDaily = "//*[@id='widgetContainer21']/app-widget-box-floating/div/div[1]/app-widget-header/div[1]/div[1]";
        // Vehicle details
        public String Model =   "//app-mydaily-widget-data-handler/app-mydaily-widget//div[2]/div[1]/span[1]";//"//*[@class='vehicle-detail padding ng-star-inserted']//span[contains(text(), 'Model')]";
        public String Plate = "//app-mydaily-widget-data-handler/app-mydaily-widget//div[2]/div[2]/span[1]";//"//*[@class='vehicle-detail padding ng-star-inserted']//span[contains(text(), 'Plate')]";
        public String Vin = "//app-mydaily-widget-data-handler/app-mydaily-widget//div[2]/div[3]/span[1]";//"//*[@class='vehicle-detail padding ng-star-inserted']//span[contains(text(), 'VIN')]";
        public String FuelSystem = "//app-mydaily-widget-data-handler/app-mydaily-widget//div[2]/div[4]/span[1]";// "//*[@class='vehicle-detail padding ng-star-inserted']//span[contains(text(), 'Fuel system')]";
        public String Odometer = "//app-mydaily-widget-data-handler/app-mydaily-widget/div[2]//div[3]/div[1]/span[1]";// "//*[@class='vehicle-detail padding ng-star-inserted']//span[contains(text(), 'Odometer')]";
        public String EngineWorkHours = "//app-mydaily-widget-data-handler/app-mydaily-widget/div[2]//div[3]/div[2]/span[1]";//"//*[@class='vehicle-detail padding ng-star-inserted']//span[contains(text(), 'Engine work hours')]";
        public String FuelLevel = "//app-mydaily-widget-data-handler/app-mydaily-widget/div[2]//div[3]/div[3]/span[1]";//"//*[@class='vehicle-detail padding ng-star-inserted']//span[contains(text(), '% fuel level')]";
        public String BatteryChargeLevel = "//app-mydaily-widget-data-handler/app-mydaily-widget/div[2]//div[3]/div[4]/span[1]";//"//*[@class='vehicle-detail padding ng-star-inserted']//span[contains(text(), '% battery charge level')]";
        
        public String NextMaintenance = "//*[@id='widgetContainer21']//div[@class='next-maintenance-container']/span"; 
        public String Select = "//*[@id='widgetContainer21']//pfe-select/select";
        public String VinCode = "//*[@id='widgetContainer21']//div[3]/span[@class='vehicle-detail-value text-body']";

    }
}
