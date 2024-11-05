using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__NotificationCenter
    {
        public String Menu="//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String NotificationCenter = "//*[@id='shoulder-left']//h5[contains (text(),'Notification center')]";
        public String NotificationCenterTitle = "//div[contains (text(),'Notification Center')]";
        public String Vehicles = "//label[contains (text(),'Vehicles')]";
        public String From = "//label[contains (text(),'From')]";
        public String To = "//label[contains (text(),'To')]";
        public String ControlRoom = "//label[contains (text(),'Control Room')]";
        public String OverTheAirRecall = "//label[contains (text(),'Over The Air Recall')]";

        public String LastNotificationDateOfReceipt = "//app-notification-list/div[2]/div[3]/div[1]/div[7]/h5[@class='dateReceipt']";
        public String LastNotificationContent = "//app-notification-list/div[2]/div[3]/div[2]/div/div[@slot='content']/span[@class='description']";
        public String PreviousNotificationDateOfReceipt = "//app-notification-list/div[2]/div[4]/div[1]/div[7]/h5[@class='dateReceipt ng-star-inserted']";
        public String PreviousNotificationContent = "//app-notification-list/div[2]/div[4]/div[2]/div/div[@slot='content']/span[@class='description']";
    }
}
