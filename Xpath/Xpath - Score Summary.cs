using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__Score_Summary
    {
        public String DashboardView = "//div[@class='dashboard-type-container']";
        public String FuelSavingScorePath = "//app-score-summary-widget-content[@class='ng-star-inserted']//div[@id='extendedCard']/div[@class='label']";
        public String FuelSavingScore = "#extendedCard > .label";
        public String FuelSavingScoreValue = ".value-number";
        public String FuelConsuption = "div:nth-child(2) > .score-summary-card div:nth-child(1)";
        public String FuelConsuptionValue = "div:nth-child(2) > .score-summary-card div:nth-child(2)";
        public String DegreeOfDifficulty = "div:nth-child(3) > .score-summary-card div:nth-child(1)";
        public String DegreeOfDifficultyValue = "div:nth-child(3) > .score-summary-card div:nth-child(2)";
        public String AverageGrossCombinationWeight = "div:nth-child(4) > .score-summary-card div:nth-child(1)";
        public String AverageGrossCombinationWeightValue = "div:nth-child(4) > .score-summary-card div:nth-child(2)";
        public String AverageDistancePerUnit = "div:nth-child(5) > .score-summary-card div:nth-child(1)";
        public String AverageDistancePerUnitValue = "div:nth-child(5) > .score-summary-card div:nth-child(2)";
        public String CO2Emissions = "div:nth-child(6) > .score-summary-card div:nth-child(1)";
        public String CO2EmissionsValue = "div:nth-child(6) > .score-summary-card div:nth-child(2)";
        public String DataNotAvailable = "//*[@id='widgetContainer5']//*[@id='scoreSummaryError']/div/label";

        // KPI TWAY
        public String FuelConsuptionTway = "//app-score-summary-widget-data-handler//*[@id='scoreSummaryContent']/div[1]/div/app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--label']";
        public String FuelConsuptionValueTway = "//app-score-summary-widget-data-handler//*[@id='scoreSummaryContent']/div[1]/div/app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--value']";
        public String AverageGrossCombinationWeightTway = "//app-score-summary-widget-data-handler//*[@id='scoreSummaryContent']/div[2]/div/app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--label']";
        public String AverageGrossCombinationWeightValueTway = "//app-score-summary-widget-data-handler//*[@id='scoreSummaryContent']/div[2]/div/app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--value']";
        public String AverageDistancePerUnitTway = "//app-score-summary-widget-data-handler//*[@id='scoreSummaryContent']/div[3]/div/app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--label']";
        public String AverageDistancePerUnitValueTway = "//app-score-summary-widget-data-handler//*[@id='scoreSummaryContent']/div[3]/div/app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--value']";
        public String AverageSpeed = "//app-score-summary-widget-data-handler//*[@id='scoreSummaryContent']/div[4]/div/app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--label']";
        public String AverageSpeedValue = "//app-score-summary-widget-data-handler//*[@id='scoreSummaryContent']/div[4]/div/app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--value']";
        public String CO2EmissionsTway = "//app-score-summary-widget-data-handler//*[@id='scoreSummaryContent']/div[5]/div/app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--label']";
        public String CO2EmissionsValueTway = "//app-score-summary-widget-data-handler//*[@id='scoreSummaryContent']/div[5]/div/app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--value']";

        // KPI Heavy Bus diesel + NP 
        public String FuelSavingScoreHeavyBus = "//app-score-summary-widget-data-handler//div[contains(text(), 'Fuel saving score (vehicle related)')]";
        public String FuelSavingScoreValueHeavyBus = "//app-score-summary-widget-data-handler//app-widget-card-extended//div[@class='value-number']";
        public String FuelConsumptionHeavyBus = "//*[@id='scoreSummaryContent']//pfe-kpi-card/div[contains(text(), 'Fuel consumption')]";
        public String FuelConsumptionValueHeavyBus = "//app-score-summary-widget-data-handler//div/div[2]//pfe-kpi-card/div[@slot='pfe-kpi-card--value']";
        public String AverageDistancePerUnitHeavyBus = "//*[@id='scoreSummaryContent']//pfe-kpi-card/div[contains(text(), 'Average distance per unit')]";
        public String AverageDistancePerUnitValueHeavyBus = "//app-score-summary-widget-data-handler//div[3]//pfe-kpi-card/div[@slot='pfe-kpi-card--value']";
        public String CO2EmissionsHeavyBus = "//app-score-summary-widget-data-handler//pfe-kpi-card/div[contains(text(),'CO2 emissions')]";
        public String CO2EmissionsValueHeavyBus = "//app-score-summary-widget-data-handler//div[4]//pfe-kpi-card/div[@slot='pfe-kpi-card--value']";

        // KPI Heavy Bus electric Energy Tab
        public String DrivingEfficiencyScoreHeavyBusElectric = "//*[@id='widgetContainer41']//*[contains (text(),'Driving efficiency score')]";
        public String DrivingEfficiencyScoreHeavyBusElectricValue = "//*[@id='widgetContainer41']//*[contains (text(),'Driving efficiency score')]/following-sibling::div";
        public String EnergyConsumptionScoreHeavyBusElectric = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Energy consumption')]";
        public String EnergyConsumptionHeavyBusElectricValue = "//*[@id='scoreSummaryContent']//div[contains(text(), 'Energy consumption')]/following-sibling::div[@slot='pfe-kpi-card--value']";
        public String AverageDistanceHeavyBusElectric = "//*[@id='widgetContainer41']//*[contains (text(),'Average distance per unit')]";
        public String AverageDistanceHeavyBusElectricValue = "//*[@id='widgetContainer41']//*[contains (text(),'Average distance per unit')]/following-sibling::div[@slot='pfe-kpi-card--value']";
        public String AverageOctHeavyBusElectric = "//*[@id='widgetContainer41']//*[contains (text(),'Average overnight charging time per unit')]";
        public String AverageOctHeavyBusElectricValue = "//*[@id='widgetContainer41']//*[contains (text(),'Average overnight charging time per unit')]/following-sibling::div[@slot='pfe-kpi-card--value']";
        public String AverageTripTimeHeavyBusElectric = "//*[@id='widgetContainer41']//*[contains (text(),'Average trip time')]";
        public String AverageTripTimeHeavyBusElectricValue = "//*[@id='widgetContainer41']//*[contains (text(),'Average trip time')]/following-sibling::div[@slot='pfe-kpi-card--value']";
        public String AverageSpeedHeavyBusElectric = "//*[@id='widgetContainer41']//*[contains (text(),'Average speed')]";
        public String AverageSpeedHeavyBusElectricValue = "//*[@id='widgetContainer41']//*[contains (text(),'Average speed')]/following-sibling::div[@slot='pfe-kpi-card--value']";
        
        //Mission Tab
        public String MissionTab = "//*[@id='widgetContainer41']//span[contains (text(),'Mission')]";
    }
}
