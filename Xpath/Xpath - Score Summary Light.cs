using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__Score_Summary_Light
    {
        //Diesel and NP
        public String DashboardView = "//div[@class='dashboard-type-container']";
        public String EcoScore = "//app-score-summary-widget-content[@class='ng-star-inserted']//div[@id='extendedCard']/div[@class='label']";
        public String EcoScoreValue = "//app-score-summary-widget-content[@class='ng-star-inserted']//div[@class='kpiInfoValue']";
        public String FuelConsumption = "//div/div/div[1]//div/div[2]/div/app-widget-card/pfe-kpi-card/div[1]";
        public String FuelConsumptionValue = "//div/div/div[1]//div/div[2]/div/app-widget-card/pfe-kpi-card/div[2]";
        public String TotalDistance = "//app-score-summary-widget-data-handler//div/div[3]/div/app-widget-card//div[1]";
        public String TotalDistanceValue = "//app-score-summary-widget-data-handler//div/div[3]/div/app-widget-card//div[2]";
        public String TotalTripTime = "//app-score-summary-widget-data-handler//div[4]//pfe-kpi-card/div[1]";
        public String TotalTripTimeValue = "//app-score-summary-widget-data-handler//div[4]//pfe-kpi-card/div[2]";
        public String Trips = "//app-score-summary-widget-data-handler//div[5]//pfe-kpi-card/div[1]";
        public String TripsValue = "//app-score-summary-widget-data-handler//div[5]//pfe-kpi-card/div[2]";
        public String AverageSpeed = "//app-score-summary-widget-data-handler//div[6]//pfe-kpi-card/div[1]";
        public String AverageSpeedValue = "//app-score-summary-widget-data-handler//div[6]//pfe-kpi-card/div[2]";
        public String CO2Emissions = "//app-score-summary-widget-data-handler//div[7]//pfe-kpi-card/div[1]";
        public String CO2EmissionsValue = "//app-score-summary-widget-data-handler//div[7]//pfe-kpi-card/div[2]";
        public String DataNotAvailable = "//*[@id='widgetContainer5']//*[@id='scoreSummaryError']/div/label";


        // KPI Daily electric tab Energy
        public String EnergyEfficiencyScoreDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Energy efficiency score')]";
		public String EnergyEfficiencyScoreValueeDailyElectric = "//*[@id='scoreSummaryContent']//div[contains (text(),'Energy efficiency score')]/following-sibling::div[@class='kpiInfoValue']";
        public String EnergyConsumptionDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Energy consumption')]";
        public String EnergyConsumptionValueeDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Energy consumption')]/following-sibling::div[@slot='pfe-kpi-card--value']";
        public String EnergyRegeneratedDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Energy regenerated vs. used')]";
        public String EnergyRegeneratedValueeDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Energy regenerated vs. used')]/following-sibling::div[@slot='pfe-kpi-card--value']";
        public String EnergyForClimatizationDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Energy for climatization vs. used')]";
        public String EnergyForClimatizationValueeDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Energy for climatization vs. used')]/following-sibling::div[@slot='pfe-kpi-card--value']";
        public String AverageRechargeTimeDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Average recharge time')]";
        public String AverageRechargeTimeValueeDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Average recharge time')]/following-sibling::div[@slot='pfe-kpi-card--value']";
        public String AverageRechargeEnergyDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Average recharged energy')]";
        public String AverageRechargeEnergyValueDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Average recharged energy')]/following-sibling::div[@slot='pfe-kpi-card--value']";
        
        // KPI Daily electric tab Mission
        public String AverageDistancePerUnitDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Average distance per unit')]";
        public String AverageDistancePerUnitValueeDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Average distance per unit')]/following-sibling::div[@slot='pfe-kpi-card--value']";
        public String AverageTripTimeDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Average trip time')]";
        public String AverageTripTimeValueeDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Average trip time')]/following-sibling::div[@slot='pfe-kpi-card--value']";
        public String AverageSpeedDailyElectric = "//*[@id='scoreSummaryContent']//pfe-kpi-card/div[contains(text(), 'Average speed')]";
        public String AverageSpeedValueeDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Average speed')]/following-sibling::div[@slot='pfe-kpi-card--value']";
        public String AverageGrossCombinationWeightDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Average gross combination weight')]";
        public String AverageGrossCombinationWeightValueeDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Average gross combination weight')]/following-sibling::div[@slot='pfe-kpi-card--value']";
        public String TractionBatteryStateOfHealthDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Traction battery state of health')]";
        public String TractionBatteryStateOfHealthValueeDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Traction battery state of health')]/following-sibling::div[@slot='pfe-kpi-card--value']";
        public String EnergyThroughputDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Energy throughput')]";
        public String EnergyThroughputValueeDailyElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Energy throughput')]/following-sibling::div[@slot='pfe-kpi-card--value']";

        //Mission Tab
        public String MissionTab = "//*[@id='widgetContainer41']//span[contains (text(),'Mission')]";


    }
}
