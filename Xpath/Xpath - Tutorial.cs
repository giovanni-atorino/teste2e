using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__Tutorial
    {
        public String Menu = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String Tutorial = "//*[@id='root']//a[contains(text(),'Tutorial')]";
        public String TutorialTitle = "//*[@id='root']//div[contains(text(),'Tutorial')]";
        public String WatchVideoButton1="//*[@id='root']/div[2]/app-faq-page/div/div[3]/div/div[2]/div/pfe-card[1]/pfe-cta/a";
        public String WatchVideoButton2 = "//*[@id='root']/div[2]/app-faq-page/div/div[3]/div/div[2]/div/pfe-card[2]/pfe-cta/a";
        public String WatchVideoButton3 = "//*[@id='root']/div[2]/app-faq-page/div/div[3]/div/div[2]/div/pfe-card[3]/pfe-cta/a";
        public String TutorialVideoContainer="//*[@id='tutorialVideoContainer']";
        public String CloseVideoButton = "//*[@id='tutorialVideoModal']//section/div[2]/div/button/svg/path";
        //public String Video= "//body[contains (@style,'overflow: hidden')]//*[id='tutorialVideoContainer']";
    }
}
