using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__Marketplace
    {
        public String Menu = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String Marketplace = "//*[@id='shoulder-left']/a[1]/pfe-icon-panel/h5";
        public String DashboardHeavyDiesel = "//a[contains(text(),'Trucks Diesel')]";
        public String DashboardHeavyNP = "//a[contains(text(),'Trucks NP')]";
        public String DashboardLightDiesel = "//a[contains(text(),'Daily Diesel')]";
        public String DashboardLightNP = "//a[contains(text(),'Daily NP')]";
        public String DashboardHeavyBusDiesel = "//a[contains(text(),'Bus Diesel')]";
        public String DashboardHeavyBusNP = "//a[contains(text(),'Bus NP')]";
        public String DashboardTwayDiesel = "//a[contains(text(),'T-Way Diesel')]";
        public String DashboardBusElectric = "//a[contains(text(),'Bus Electric')]";
        public String DashboardDailyElectric = "//a[contains(text(),'Daily Electric')]";
        public String AddRemoveFuelConsumption = "//*[@id='marketplace-tabs']/pfe-tab-panel[1]/div[@class='container-widget mt']//pfe-card[3]/pfe-cta/a";

        public String GotoDashboard = "//app-market-place-modal/pfe-modal//a[contains (text(),'Go to dashboard')]";
        public String FuelConsumptionTitle = "//*[@id='widgetContainer1']/app-widget-box-floating/div/div[1]/app-widget-header/div[1]/div[1]";

        public String Trucks = "//*[@id='pfe-accordion-dashboard']//h5[contains(text(), 'Trucks')]";
        public String TrucksDiesel = "//*[@id='shoulder-left']//a[@href='/dashboard?db=11']";

        //Heavy widget
        public String Overview = "//h4[contains(@class, 'title-card') and text() = ' OVERVIEW ']";
        public String NewsFeed = "//h4[contains(@class, 'title-card') and text() = ' NEWS FEED ']";
        public String FuelConsumption = "//h4[contains(@class, 'title-card') and text() = ' FUEL CONSUMPTION ']";
        public String CO2Emissions = "//h4[contains(@class, 'title-card') and text() = ' CO2 EMISSIONS ']";
        public String DrivingStyleEvaluation = "//h4[contains(@class, 'title-card') and text() = ' DRIVING STYLE EVALUATION ']";
        public String MonitoredDrivers = "//h4[contains(@class, 'title-card') and text() = ' MONITORED DRIVERS ']";
        public String MonitoredVehicle = "//h4[contains(@class, 'title-card') and text() = ' MONITORED VEHICLES ']";
        public String Ranking = "//h4[contains(@class, 'title-card') and text() = ' RANKING ']";
        public String VehicleRoute = "//h4[contains(@class, 'title-card') and text() = ' VEHICLE ROUTES ']";
        public String Tips = "//h4[contains(@class, 'title-card') and text() = ' TIPS ']";
        public String ServiceBooking = "//h4[contains(@class, 'title-card') and text() = ' SERVICE BOOKING ']";
    }
}