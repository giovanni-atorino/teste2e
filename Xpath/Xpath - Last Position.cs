using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__LastPosition
    {
        public String TitleLastPosition = "//app-widget-header/div[@class='row widget-header']/div[contains(text(), 'Vehicle last position')]";
        public String LastPosition = "//app-location-widget-content//label[contains(text(), 'Last position')]";
        public String Route = "//app-location-widget-content//label[contains(text(), 'Route')]";
        public String From = "//app-location-widget-content//label[contains(text(), 'From')]";
        public String To = "//app-location-widget-content//label[contains(text(), 'To')]";
        public String Start = "//app-location-widget-content//span[contains(text(), 'Start')]";
        public String End = "//app-location-widget-content//span[contains(text(), 'End')]";
        public String Duration = "//app-location-widget-content//span[contains(text(), 'Duration')]";
        public String TotalDistance = "//app-location-widget-content//span[contains(text(), 'Total distance')]";
        public String TotalTripTime = "//app-location-widget-content//span[contains(text(), 'Total trip time')]";
        public String FuelConsumption = "//app-location-widget-content//span[contains(text(), 'Fuel consumption')]";

        //Buttons
        public String ButtonResetView = "//app-location-widget-content//span[contains(text(), 'Reset view')]";
        public String ButtonRefresh = "//app-location-widget-content//span[contains(text(), 'Refresh')]";

        //Maps
        public String Pin = "//*[@id='mapContainerElement']//div[2]/div/div[4]/div";
        public String ActionButton = "//*[@id='radio']";
        public String ChooseVehicle = "//*[@id='location-position-vehicle-dropdown']/div[@slot='heading']";
        public String DeselectAll = "//*[@id='location-position-vehicle-dropdown']//pfe-cta/a[@clearalllabel='Deselect all']";
        public String FirstVehicle = "//*[@id='location-position-vehicle-dropdown']//pfe-dropdown-item[1]/span";
        public String VIN = "//*[@id='mapContainerElement']//div[contains(text(),'VIN:')]";
        public String Name = "//*[@id='mapContainerElement']//div[contains(text(),'Name:')]";
        public String Plate = "//*[@id='mapContainerElement']//div[contains(text(),'Plate:')]";
        public String Model = "//*[@id='mapContainerElement']//div[contains(text(),'Model:')]";
        public String Fuel = "//*[@id='mapContainerElement']//div[contains(text(),'Fuel:')]";
        public String LastUpdate = "//*[@id='mapContainerElement']//div[contains(text(),'Last Update:')]";
        public String Type = "//*[@id='mapContainerElement']//div[contains(text(),'Type:')]";
    }
}
