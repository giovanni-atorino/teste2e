using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__MyDaily_Light

    {
        public String DashboardView = "//div[@class='dashboard-type-container']";
        public String MyDaily = "//*[@id=\"widgetContainer21\"]//app-widget-header/div[1]/div[1]";
        // Vehicle details
        public String Model =   "//*[@class='vehicle-detail padding ng-star-inserted']//span[contains(text(), 'Model')]";
        public String Plate = "//*[@class='vehicle-detail padding ng-star-inserted']//span[contains(text(), 'Plate number')]";
        public String Vin = "//*[@class='vehicle-detail padding ng-star-inserted']//span[contains(text(), 'VIN')]";
        public String FuelSystem = "//*[@class='vehicle-detail padding ng-star-inserted']//span[contains(text(), 'Fuel system')]";
        public String Odometer = "//*[@class='vehicle-detail padding ng-star-inserted']//span[contains(text(), 'Odometer (km)')]";
        public String EngineThroughput = "//*[@class='vehicle-detail padding ng-star-inserted']//span[contains(text(), 'Energy throughput')]";
        public String TractionBatterySOC = "//*[@class='vehicle-detail padding ng-star-inserted']//span[contains(text(), 'Traction battery state of charge (SOC)')]";
        public String ServiceBatterySOC = "//*[@class='vehicle-detail padding ng-star-inserted']//span[contains(text(), 'Service battery state of charge (SOC)')]";
        
        public String NextMaintenance = "//*[@id='widgetContainer21']//div[@class='next-maintenance-container']/span"; 
        public String Select = "//*[@id='widgetContainer21']//pfe-select/select";
        public String VinCode = "//*[@id='widgetContainer21']//div[3]/span[@class='vehicle-detail-value text-body']";

    }
}
