using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__Monitored_Drivers
    {
        public String DashboardView = "//div[@class='dashboard-type-container']";
        public String AddDriverButton = "//*[@id='monitoredDriversContent']/div/div[2]/pfe-cta/a";
        public String MonitoredDrivers = "#widgetContainer13 .widget-title";
        public String UserID = "div:nth-child(1) > .driver-card .id";
        public String FuelSavingScoreUserID = "div:nth-child(1) > .driver-card .element-detail:nth-child(2) > .label";
        public String VehicleCareScoreUserID = "div:nth-child(1) > .driver-card .element-detail:nth-child(3) > .label";
        public String SafeDrivingScoreUserID = "div:nth-child(1) > .driver-card .element-detail:nth-child(4) > .label";
        public String FuelSavingScoreValueUserID = "div:nth-child(1) > .driver-card .element-detail:nth-child(2) > .value";
        public String VehicleCareScoreValueUserID = "div:nth-child(1) > .driver-card .element-detail:nth-child(3) > .value";
        public String SafeDrivingScoreValueUserID = "div:nth-child(1) > .driver-card .element-detail:nth-child(4) > .value";
        public String ActionButton = "//*[@id='widgetContainer13']//*[contains(@id, 'action-tooltip')]";
    }
}
