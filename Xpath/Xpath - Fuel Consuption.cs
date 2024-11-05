using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__Fuel_Consumption
    {
        public String DashboardView = "//div[@class='dashboard-type-container']";
        public String FuelConsumption = "//div[@class=('row widget-header')]//div[contains(text(), 'Fuel consumption')]";
        public String AverageLabelFleet = ".fuel-consumption-summary-label > span";
        public String AverageFleetValue = "//div[@id='fuelConsumptionContent']//div[@class='fuel-consumption-summary-value margin-r']";//".fuel-consumption-summary-value > div";
        public String FuelConsumption2 = "#cdk-drop-list-1 .widget-title";
        public String AverageFleetValueKPI = "//div[@id='fuelConsumptionContent']//div[@class='fuel-consumption-summary-value margin-r']//strong"; //solo valore;

        //eDaily Electric
        public String EnergyUsage = "//div[@class=('row widget-header')]//div[contains(text(), 'Energy usage')]";
        public String EnergyUsageVallue = "//*[@id='fuelConsumptionContent']//div/strong";

        //eBus Electric
        public String EnergyConsumption = "//div[@class=('row widget-header')]//div[contains(text(), 'Energy consumption')]";
        public String EnergyConsumptionValue = "//*[@id='fuelConsumptionContent']//strong";
    }
}
