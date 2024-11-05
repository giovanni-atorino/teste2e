using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__NextMaintenanceMonitoring
    {
        public String TitleNextMaintenanceMonitoring = "//app-widget-header/div[@class='row widget-header']/div[contains(text(), 'Next maintenance monitoring')]";
        public String VehiclesMaintenance = "//app-vehicle-maintenance//div[contains (text (),'Vehicles maintenance')]";
        public String TotalVehicles = "//*[@id=\"highcharts-zi7turc-274\"]/span/div/span";
        public String CloseToMaintenance = "//app-nmm-widget-data-handler//label[contains(text(), 'Close to maintenance')]";
        public String Expired = "//app-nmm-widget-data-handler//div[contains(text(), 'Expired')]";
        public String NoMaintenance = "//app-nmm-widget-data-handler//div[contains(text(), 'No upcoming maintenance foreseen')]";
        public String DataNotAvailable = "//app-nmm-widget-data-handler//div[contains(text(), 'Data not available')]";
        public String DiscovereMoreButton = "//app-nmm-widget-data-handler//pfe-cta/a";
    }
}
