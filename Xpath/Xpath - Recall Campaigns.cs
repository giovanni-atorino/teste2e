using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__RecallCampaigns
    {
        public String Menu = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String VehiclesManagement = "//*[@id='pfe-accordion-vehicles']//h5[contains (text (),'Vehicles management')]";
        public String RecallCampaigns = "//*[@id='shoulder-left']//a[@href='/recaller']";

        public String RecallCampaignsTitle = "//div[contains (text(),'Vehicles recall campaigns')]";
        public String OTARecallCampaignsTitle = "//h4[contains (text(),'OTA RECALL CAMPAIGNS')]";
        public String RecallCampaign = "//div[@class='row padding campaign-header']//div[contains (text(),'Recall campaign')]";
        public String ToBePerformedByAt = "//div[@class='row padding campaign-header']//div[contains (text(),'To be performed by/at')]";
        public String VehiclesToDoOnTotal = "//div[@class='row padding campaign-header']//div[contains (text(),'Vehicles to do on total [to do / total]')]";
        public String ReleaseDate = "//div[@class='row padding campaign-header']//div[contains (text(),'Release date')]";
        public String ExpirationDate = "//div[@class='row padding campaign-header']//div[contains (text(),'Expiration date')]";
        public String DaysToExpiration = "//div[@class='row padding campaign-header']//div[contains (text(),'Days to the expiration')]";
        public String ThereAreNoActiveCampaigns = "//h1[contains (text(),'There are no active campaigns available for your vehicles')]";

        public String AdvancedFiltersTitle = "//app-campaign//div[contains(text(), 'Advanced filters')]";
        public String Country = "//app-campaign//label[contains(text(), 'Country')]";
        public String ITALY = "//app-campaign//p[contains(text(), 'ITALY')]";
        public String UK = "//app-campaign//p[contains(text(), 'UNITED KINGDOM')]";

        public String searchAccount = "//app-campaign//pfe-input[@name='userEmail']";
        public String searchIcon = "//app-campaign//pfe-input[@name='userEmail']/pfe-icon[@icon='dcx-search']";
        public String selectFirstChoice = "//app-campaign//pfe-select/select/option[2]";
        public String selectApply = "//app-campaign//a[contains(text(), 'Apply')]";
        public String selectFirstChoiceDisabled = "//app-campaign//select[@disabled='true']";
    }
}