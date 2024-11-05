using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__PayPerUse
    {
        public String TotVehicleinFilterBar = "//*[@id='filterBar']/div[@class='dashboard-type-container standard-filters-breadcrumb']/div[5]/strong";
        public String TitlePayPerUse = "//app-widget-header/div[@class='row widget-header']/div[contains(text(), 'Pay Per Use')]";
        
        public String VIN = "//*[@id='widgetContainer39']//app-payxuse-widget//span[contains (text () , 'VIN')]";
        public String Plate = "//*[@id='widgetContainer39']//app-payxuse-widget//span[contains (text () , 'Plate number')]";
        public String Model = "//*[@id='widgetContainer39']//app-payxuse-widget//span[contains (text () , 'Model')]";
        public String Fuel = "//*[@id='widgetContainer39']//app-payxuse-widget//span[contains (text () , 'Fuel system')]";
        public String DiscoverMoreButton = "//*[@id='widgetContainer39']//a[contains (text(), 'DISCOVER MORE')]";
        
        //pop-up to ask the info via mail
        public String TitlePopUP = "//*[@class='tip-detail']//*[@id='2edo5fbyo']";
        public String  EmailField = "//pfe-input[@name='userEmail']";
        public String PhoneField = "//pfe-input[@name='userPhone']";
    }
}
