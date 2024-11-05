using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__CompanyManagement
    {
        public String Menu="//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String CompanyManagement = "//*[@id='shoulder-left']//h5[contains (text(),'Company Management')]";
        public String CompanyManagementTitle = "//h1[contains (text(),'Company Management')]";
        public String CompanyName= "//*[@id='companyListTable']//span[contains (text(),'Company Name')]";
        public String VatNumberEurope = "//*[@id='companyListTable']//span[contains (text(),'VAT Number Europe')]";
        public String VatNumberA = "//*[@id='companyListTable']//span[contains (text(),'VAT Number A')]";
        public String VatNumberB = "//*[@id='companyListTable']//span[contains (text(),'VAT Number B')]";
        public String Country = "//*[@id='companyListTable']//span[contains (text(),'Country')]";
        public String MainAccount = "//*[@id='companyListTable']//span[contains (text(),'Main account')]";
        public String FleetManagerId = "//*[@id='companyListTable']//span[contains (text(),'Fleet Manager Id')]";
        public String FleetManager = "//*[@id='companyListTable']//span[contains (text(),'Fleet Manager')]";
        public String FleetManagerFirstname = "//*[@id='companyListTable']//span[contains (text(),'Fleet Manager Firstname')]";
        public String FleetManagerLastname = "//*[@id='companyListTable']//span[contains (text(),'Fleet Manager Lastname')]";
        public String FleetManagerPhone = "//*[@id='companyListTable']//span[contains (text(),'Fleet Manager Phone')]";

        public String CountryAustria = "//*[@id='pfe-select-1']/*[@value='14']";
        public String ManageServiceAccountsTooltip = "//*[@row-index='0']//*[@title='Manage service accounts']";
        public String Account = "//*[@id='root']//app-mainaccount-manage-user/div[1]//span[contains (text(),'Account')]";
        public String Name = "//*[@id='root']//app-mainaccount-manage-user/div[1]//span[contains (text(),'Name')]";
        public String Phone = "//*[@id='root']//app-mainaccount-manage-user/div[1]//span[contains (text(),'Phone')]";
        public String Email = "//*[@id='root']//app-mainaccount-manage-user/div[1]//span[contains (text(),'Email')]";
        public String LastUpdate = "//*[@id='root']//app-mainaccount-manage-user/div[1]//span[contains (text(),'Last update')]";
    }
}
