using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__KRONE
    {
        public String TitleKrone = "//app-widget-header/div[@class='row widget-header']/div[contains(text(),'Krone - Latest data')]";
        public String Date = "//app-krone-widget-list//span[contains(text(),'Date')]";
        public String VIN = "//app-krone-widget-list//span[contains(text(),'VIN')]";
        public String Plate = "//app-krone-widget-list//span[contains(text(),'Plate')]";
        public String Nickname = "//app-krone-widget-list//span[contains(text(),'Nickname')]";
        public String FIN = "//app-krone-widget-list//span[contains(text(),'FIN')]";
        public String TypeKrone = "//app-krone-widget-list//span[contains(text(),'Type')]";
        public String Status = "//app-krone-widget-list//span[contains(text(),'Status')]";
        public String Temperatures = "//app-krone-widget-list//span[contains(text(),'Temperatures')]";
        public String Position = "//app-krone-widget-list//span[contains(text(),'Position')]";
        public String Actions = "//app-krone-widget-list//span[contains(text(),'Actions')]";

        //Details page
        public String Details = "//app-krone-widget-detail//div[contains(text(), 'Details')]";
        public String CommonData = "//app-krone-widget-detail//div[contains(text(), 'Common data')]";
        public String AssetName = "//app-krone-widget-detail//div[contains(text(), 'Asset name')]";
        public String DateCommonData = "//app-krone-widget-detail//div[3]/div[contains(text(), 'Date')]";
        public String TimeReceived = "//app-krone-widget-detail//div[contains(text(), 'Time received')]";
        public String Voltage = "//app-krone-widget-detail//div[contains(text(), 'Voltage')]";
        public String InternalVoltage = "//app-krone-widget-detail//div[contains(text(), 'Internal voltage')]";
        public String TempRecorder = "//app-krone-widget-detail//div[contains(text(), 'Temp. recorder')]";
        public String DurationDriving = "//app-krone-widget-detail//div[contains(text(), 'Duration driving')]";
        public String TemperatureData = "//app-krone-widget-detail//div[contains(text(), 'Temperature data')]";
        public String ValueTemperature = "//app-krone-widget-detail//div[contains(text(), 'Value')]";
        public String GPS = "//app-krone-widget-detail//div[2]/div[contains(text(), 'GPS')]";
        public String Latitude = "//app-krone-widget-detail//div[contains(text(), 'Latitude')]";
        public String Longitude = "//app-krone-widget-detail//div[contains(text(), 'Longitude')]";
        public String Height = "//app-krone-widget-detail//div[contains(text(), 'Height')]";
        public String Location = "//app-krone-widget-detail//div[contains(text(), 'Location')]";
        public String Direction = "//app-krone-widget-detail//div[contains(text(), 'Direction')]";
        public String GPSHeading = "//app-krone-widget-detail//div[contains(text(), 'heading')]";
        public String Satellites = "//app-krone-widget-detail//div[contains(text(), 'Satellites')]";
        public String RefrigeratorData = "//app-krone-widget-detail//div[contains(text(), 'Refrigerator data')]";
        public String RefrigeratorDate = "//app-krone-widget-detail//div[2]/div[contains(text(), 'Date')]";
        public String Fuel = "//app-krone-widget-detail//div[3]/div[contains(text(), 'Fuel')]";
        public String FuelReserve = "//app-krone-widget-detail//div[contains(text(), 'reserve')]";
        public String StandbyHours = "//app-krone-widget-detail//div[contains(text(), 'Standby hours')]";
        public String OperatingHours = "//app-krone-widget-detail//div[contains(text(), 'Operating')]";
        public String SwitchOnHours = "//app-krone-widget-detail//div[contains(text(), 'Switch on')]";
        public String Warning = "//app-krone-widget-detail//div[contains(text(), 'Warning')]";
        
        //Icons
        public String ArrowContracted = "//app-krone-widget-list//div[@ref='eHeaderContainer']//div[@col-id='1_0']/div[@ref='agContainer']/span[@ref='agClosed']/span[@class='ag-icon ag-icon-contracted']";
        public String OpenDetails = "//*[@id='kroneListTable']//div[@row-id=0]//span[@ref='eCellValue']/div/span/span";
    }
}
