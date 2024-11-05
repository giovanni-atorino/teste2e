using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__MeR
    {

        //Remote Commands
        public String Menu = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String Contracts = "//h5[contains(text(), 'Contracts')]";
        public String MeR = "//*[@id='pfe-link-mandrContracts']//*[contains(text(),'M&R')]";
        public String Maintenance = "//*[@class='page-background padding']/h1[contains(text(), ' Maintenance & Repair contracts list ')]";
        public String ContractNumber = "//*[@id='mandrListTable']//span[contains(text(), 'Contract number')]";
        public String ContractType = "//*[@id='mandrListTable']//span[contains(text(), 'Contract type')]";
        public String ContractContent = "//*[@id='mandrListTable']//span[contains(text(), 'Contract content')]";
        public String ContractualMission = "//*[@id='mandrListTable']//span[contains(text(), 'Contractual mission')]";
        public String Total = "//*[@id='mandrListTable']//span[contains(text(), 'Total')]";
        public String ContractDuration = "//*[@id='mandrListTable']//span[contains(text(), 'Contract duration')]";
        public String Payer = "//*[@id='mandrListTable']//span[contains(text(), 'Payer')]";
        public String Customer = "//*[@id='mandrListTable']//span[contains(text(), 'Customer')]";
        public String Instalment = "//*[@id='mandrListTable']//span[contains(text(), 'Instalment')]";
        public String ViewButton = "//*[@id='mandrListTable']//span/div/span/span"; 
        public String ContractNumberDetail = "//*[@id='mandrDetailTable']//span[contains(text(), 'Contract number')]";
        public String VINDetail = "//*[@id='mandrDetailTable']//span[contains(text(), 'VIN')]";
        public String StartDateDetail = "//*[@id='mandrDetailTable']//span[contains(text(), 'Start date')]";
        public String EndDateDetail = "//*[@id='mandrDetailTable']//span[contains(text(), 'End date')]";
        public String SuspensionDateDetail = "//*[@id='mandrDetailTable']//span[contains(text(), 'Suspension date')]";
        public String ReactivationDateDetail = "//*[@id='mandrDetailTable']//span[contains(text(), 'Reactivation date')]";
        public String SuspensionDetail = "//*[@id='mandrDetailTable']//span[contains(text(), 'Suspension (km)')]";
        public String ReactivationDetail = "//*[@id='mandrDetailTable']//span[contains(text(), 'Reactivation (km)')]";
    }
}