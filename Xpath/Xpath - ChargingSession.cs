using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__ChargingSession
    {
        public String Menu = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String ChargingSession = "//*[@id='shoulder-left']//*[contains(text(),'Charging sessions')]";
        public String Charging = "//*[@class='page-background']/*[contains(text(),'Charging sessions')]";


        public String SessionID = "//*[@class='ag-header-cell-text'][contains(text(), 'Session ID')]";
        public String VIN = "//*[@class='ag-header-cell-text'][contains(text(), 'VIN')]";
        public String VehicleName = "//*[@class='ag-header-cell-text'][contains(text(), 'Vehicle name')]";
        public String PlateNumber = "//*[@class='ag-header-cell-text'][contains(text(), 'Plate number')]";
        public String Status = "//*[@class='ag-header-cell-text'][contains(text(), 'Status')]";
        public String Date = "//*[@class='ag-header-cell-text'][contains(text(), 'Date')]";
        public String Charger = "//*[@class='ag-header-cell-text'][contains(text(), 'Charger serial number')]";
        public String RFID = "//*[@class='ag-header-cell-text'][contains(text(), 'RFID serial number')]";
        public String Amount = "//*[@class='ag-header-cell-text'][contains(text(), 'Amount')]";
        public String Currency = "//*[@class='ag-header-cell-text'][contains(text(), 'Currency')]";
        public String Actions = "//*[@class='ag-header-cell-text'][contains(text(), 'Actions')]";

    }
}
