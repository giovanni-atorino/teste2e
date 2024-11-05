using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__DealerManagement
    {
        public String Menu="//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String DealerManagement = "//*[@id='shoulder-left']//h5[contains (text(),'Dealer management')]";
        public String DealerManagementTitle = "//h1[contains (text(),'Dealer Management')]";
        public String Name="//*[@id='hdsListTable']//span[contains (text(),'Name')]";
        public String City = "//*[@id='hdsListTable']//span[contains (text(),'City')]";
        public String Country = "//*[@id='hdsListTable']//span[contains (text(),'Country')]";
        public String SapCode = "//*[@id='hdsListTable']//span[contains (text(),'Sap Code')]";
        public String IsHDS = "//*[@id='hdsListTable']//span[contains (text(),'Service Point')]";
        public String SalesPoint = "//*[@id='hdsListTable']//span[contains (text(),'Sales Point')]";
        public String Range = "//*[@id='hdsListTable']//span[contains (text(),'Range')]";
        public String Fuel = "//*[@id='hdsListTable']//span[contains (text(),'Fuel')]";
        public String Active = "//*[@id='hdsListTable']//span[contains (text(),'Active')]";
        public String ParentDealerSapCode = "//*[@id='hdsListTable']//span[contains (text(),'Parent dealer SAP Code')]";
    }
}
