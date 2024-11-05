using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__ContentManager
    {
        public String Menu = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String ContentManager = "//h5[contains (text(),' Custom notification management ')]";
        public String ContentManagerTitle = "//app-content-manager-list//div[contains(text(),'Content creation')]";
        public String ID = "//*[@ref='headerRoot']//span[contains (text(),'Id')]";
        public String ContentName = "//*[@ref='headerRoot']//span[contains (text(),'Content name')]";
        public String Channel = "//*[@ref='headerRoot']//span[contains (text(),'Channel')]";
        public String CreationDate = "//*[@ref='headerRoot']//span[contains (text(),'Creation date')]";
        public String CreatedBy = "//*[@ref='headerRoot']//span[contains (text(),'Created by')]";
        public String ScheduledDate = "//*[@ref='headerRoot']//span[contains (text(),'Scheduled date')]";
        public String SentDate = "//*[@ref='headerRoot']//span[contains (text(),'Send date')]";
        public String ApprovedDate = "//*[@ref='headerRoot']//span[contains (text(),'Approval date')]";
        public String ApprovedBy = "//*[@ref='headerRoot']//span[contains (text(),'Approved by')]"; 
        public String ContentStatus = "//*[@ref='headerRoot']//span[contains (text(),'Content status')]"; 



        public String ApplyAdvancedFiltersButton="//a[contains(text(), 'Apply advanced filters')]";
        public String Country = "//pfe-radio[1]//pfe-select";
        public String SelectAllButton = "//*[@id='dropdownContracts']//pfe-cta/a[contains(text(), 'Select all')]";
        public String DeselectAllButton = "//*[@id='dropdownContracts']//pfe-cta/a[contains(text(), 'Deselect all')]";
        //public String CountryItaly = "//pfe-radio[1]//option[contains (text(),'Italy')]";
    }
}
