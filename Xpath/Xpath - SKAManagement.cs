using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__SKAManagement
    {
        public String Menu="//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String SKAManagement = "//h5[contains (text(),'SKA Management')]";
        public String Id = "//*[@id='skaListTable']//*[@class='ag-header-container']//span[contains (text(),'Id')]";
        public String Name = "//*[@id='skaListTable']//*[@class='ag-header-container']//span[contains (text(),'Name')]";
        public String Surname = "//*[@id='skaListTable']//*[@class='ag-header-container']//span[contains (text(),'Surname')]";
        public String PhoneNumber = "//*[@id='skaListTable']//*[@class='ag-header-container']//span[contains (text(),'Phone Number')]";
        public String Email = "//*[@id='skaListTable']//*[@class='ag-header-container']//span[contains (text(),'Email')]";
        public String Country = "//*[@id='skaListTable']//*[@class='ag-header-container']//span[contains (text(),'Country')]";
        public String Active = "//*[@id='skaListTable']//*[@class='ag-header-container']//span[contains (text(),'Active')]";
        public String AddSKA = "//span[contains (text(),'Add SKA')]";
        public String CountryDropDownAddSKA="//*[@id='countryDropdow']";
        public String ItalyCountry = "//*[@id='countryDropdown']//p[contains (text(),'Italy')]";
        public String ITALYCountry="//*[@id='pfe-select']/option[contains(text(),'ITALY')]";
        public String ServiceKeyAccountManagerTitle = "//h1";
        public String CountryDropDown="//*[@id='root']/div[2]/app-handle-dealer/div/div/div/div[2]/pfe-select//div[2]/pfe-icon";
    }
}
