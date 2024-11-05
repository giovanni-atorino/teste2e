using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__Monitored_Vehicles_Light
    {

        //KPI eDaily Electric
        public String DashboardView = "//div[@class='dashboard-type-container']";
        public String AddVehicleButton = "//*[@id='monitoredVehiclesContent']/div/div[2]/pfe-cta/a";
        public String MonitoredVehicles = "//*[@class='row widget-header']//div[contains (text(),'Monitored vehicles')]";
        public String ActionButton = "//*[@id='widgetContainer14']//*[contains(@id, 'action-tooltip')]";
        public String MonitoredVegiclesContent = "//*[@id=\"monitoredVehiclesContent\"]/div[1]//div[1]/span[2]";
        public String EnergyUsageScore = "//*[@id='monitoredVehiclesContent']//span[contains (text(),'Energy usage score')]";
        public String EnergyUsageScoreValue = "//*[@id='monitoredVehiclesContent']//span[contains (text(),'Energy usage score')]/following-sibling::span";
        public String EnergyUsed = "//*[@id='monitoredVehiclesContent']//span[contains (text(),'Energy used')]";
        public String EnergyUsedValue = "//*[@id='monitoredVehiclesContent']//span[contains (text(),'Energy used')]/following-sibling::span";
        public String EnergyRegenerated = "//*[@id='monitoredVehiclesContent']//span[contains (text(),'Energy regenerated vs. used')]";
        public String EnergyRegeneratedValue = "//*[@id='monitoredVehiclesContent']//span[contains (text(),'Energy regenerated vs. used')]/following-sibling::span";
        public String EnergyCliatization = "//*[@id='monitoredVehiclesContent']//span[contains (text(),'Energy for climatization vs. used')]";
        public String EnergyCliatizationValue = "//*[@id='monitoredVehiclesContent']//span[contains (text(),'Energy for climatization vs. used')]/following-sibling::span";
        public String AverageTimeRecharge = "//*[@id='monitoredVehiclesContent']//span[contains (text(),'Average time to recharge')]";
        public String AverageTimeRechargeValue = "//*[@id='monitoredVehiclesContent']//span[contains (text(),'Average time to recharge')]/following-sibling::span";
        public String YesButton = "//div[@id='monitoredVehiclesContent']//button[@class='button confirm padding-lr text-body']";

        //KPI eDaily Electric
        public String EnergyConsumption = "//*[@id='monitoredVehiclesContent']//span[contains (text(),'Energy consumption')]";
        public String EnergyConsumptionValue = "//*[@id='monitoredVehiclesContent']//span[contains (text(),'Energy consumption')]/following-sibling::span";
        public String EnergyScore = "//*[@id='monitoredVehiclesContent']//span[contains (text(),'Energy score')]";
        public String EnergyScoreValue = "//*[@id='monitoredVehiclesContent']//span[contains (text(),'Energy score')]/following-sibling::span";
        public String ComfortScore = "//*[@id='monitoredVehiclesContent']//span[contains (text(),'Comfort score')]";
        public String ComfortScoreValue = "//*[@id='monitoredVehiclesContent']//span[contains (text(),'Comfort score')]/following-sibling::span";
        public String SOC = "//*[@id='monitoredVehiclesContent']//span[contains (text(),'SOC')]";
        public String SOCValue = "//*[@id='monitoredVehiclesContent']//span[contains (text(),'SOC')]/following-sibling::span";


    }
}