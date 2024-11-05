using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__ChargingCard
    {
        public String Menu = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String ChargingCard = "//*[@id='shoulder-left']//*[contains(text(),'Charging card')]";
        public String Card = "//*[contains(text(),'Cards')]";
        public String VIN = "//*[@class='ag-header-cell-text'][contains(text(), 'VIN')]";
        public String VehicleName = "//*[@class='ag-header-cell-text'][contains(text(), 'Vehicle name')]";
        public String PlateNumber = "//*[@class='ag-header-cell-text'][contains(text(), 'Plate number')]";
        public String ContractNumber = "//*[@class='ag-header-cell-text'][contains(text(), 'Contract number')]";
        public String CardNumber = "//*[@class='ag-header-cell-text'][contains(text(), 'Card number')]";
        public String Type = "//*[@class='ag-header-cell-text'][contains(text(), 'Type')]";
        public String Date = "//*[@class='ag-header-cell-text'][contains(text(), 'Date')]";
        public String Status = "//*[@class='ag-header-cell-text'][contains(text(), 'Status')]";
        public String Actions = "//*[@class='ag-header-cell-text'][contains(text(), 'Actions')]";
        public String SearchButton = "//*[@class='search-icon PFElement']";
        public String TitleEdit = "//h2[contains(text(), 'Associate charging card')]";
        public String CardSerialNumber = "//*[@id='associateCard']//*[contains(text(), 'Card serial number *')]";
        public String Edit = "//*[@title='Edit']";
    }
}
