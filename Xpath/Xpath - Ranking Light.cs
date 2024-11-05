using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__Ranking_Light
    {
        public String DashboardView = "//div[@class='dashboard-type-container']";
        public String VehiclesRanking = "//*[@id=\"widgetContainer16\"]//div[1]/app-widget-header/div[1]";

        // Ranking Driver KPI xpath
        public String FuelSavingScoreDrivers = "//app-ranking-widget-data-handler//pfe-tab-panel[1]//app-widget-card-extended/div/div[@class='label']";
        public String FuelSavingScoreValueDrivers = "//app-ranking-widget-data-handler//pfe-tab-panel[1]//app-widget-card-extended//div[@class='value']";
        public String VehicleCareDrivers = "//app-ranking-widget-data-handler//pfe-tab-panel[1]//div[contains (text(),'Vehicle care')]";
        public String VehicleCareValueDrivers = "//pfe-tab-panel[1]/div[1]//div[2]//pfe-kpi-card/div[@slot='pfe-kpi-card--value']";
        public String AverageTotalFuelDrivers = "//pfe-tab-panel[1]//div[3]//pfe-kpi-card/div[@slot='pfe-kpi-card--label']";
        public String AverageTotalFuelValueDrivers = "//pfe-tab-panel[1]//div[3]//pfe-kpi-card/div[@slot='pfe-kpi-card--value']";
        public String DegreeOfDifficultyDrivers = "//pfe-tab-panel[1]//div[1]/div/app-widget-card//div[@slot='pfe-kpi-card--label']";
        public String DegreeOfDifficultyValueDrivers = "//pfe-tab-panel[1]//div[1]/div/app-widget-card//div[@slot='pfe-kpi-card--value']";
        public String CO2EmissionsDrivers = "//pfe-tab-panel[1]//div[5]/div/app-widget-card//div[@slot='pfe-kpi-card--label']";
        public String CO2EmissionsValueDrivers = "//pfe-tab-panel[1]//div[5]/div/app-widget-card//div[@slot='pfe-kpi-card--value']";

        
        // Ranking Driver matrix xpath 
        public String DriverUserButton =                    "//pfe-table[@id='myGridDrivers']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='1_0']//span[@class='ag-icon ag-icon-contracted']";
        public String DriverDriverButton =                  "//pfe-table[@id='myGridDrivers']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='2_0']//span[@class='ag-icon ag-icon-contracted']";
        public String DriverMissionButton =                 "//pfe-table[@id='myGridDrivers']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='3_0']//span[@class='ag-icon ag-icon-contracted']";
        public String DriverBehaviorButton =                "//pfe-table[@id='myGridDrivers']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='4_0']//span[@class='ag-icon ag-icon-contracted']";
        public String DriverFuelConsumptionButton =         "//pfe-table[@id='myGridDrivers']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='5_0']//span[@class='ag-icon ag-icon-contracted']";
        public String DriverVehicleButton =                 "//pfe-table[@id='myGridDrivers']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='7_0']//span[@class='ag-icon ag-icon-contracted']";

        public String DriverUserButtonExpanded =             "//pfe-table[@id='myGridDrivers']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='1_0']//span[@class='ag-icon ag-icon-expanded']";
        public String DriverDriverButtonExpanded =           "//pfe-table[@id='myGridDrivers']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='2_0']//span[@class='ag-icon ag-icon-expanded']";
        public String DriverMissionButtonExpanded =          "//pfe-table[@id='myGridDrivers']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='3_0']//span[@class='ag-icon ag-icon-expanded']";
        public String DriverBehaviorButtonExpanded=          "//pfe-table[@id='myGridDrivers']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='4_0']//span[@class='ag-icon ag-icon-expanded']";
        public String DriverFuelConsumptionButtonExpanded =  "//pfe-table[@id='myGridDrivers']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='5_0']//span[@class='ag-icon ag-icon-expanded']";
        public String DriverVehicleButtonExpanded =          "//pfe-table[@id='myGridDrivers']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='7_0']//span[@class='ag-icon ag-icon-expanded']";


        public String GridDrivers = "myGridDrivers";


        // Ranking Vehicles KPI xpath
        public String FuelSavingScoreVehicles = "//pfe-tab-panel[2]//app-widget-card-extended/div/div[@class='label']";
        public String FuelSavingScoreValueVehicles = "//pfe-tab-panel[2]//app-widget-card-extended//div[@class='value']";
        public String VehicleCareVehicles = "//pfe-tab-panel[2]//div[contains (text(),'Vehicle care')]";
        public String VehicleCareValueVehicles = "//pfe-tab-panel[2]/div[1]//div[2]//pfe-kpi-card/div[@slot='pfe-kpi-card--value']";
        public String AverageTotalFuelVehicles = "//pfe-tab-panel[2]//div[3]//pfe-kpi-card/div[@slot='pfe-kpi-card--label']";
        public String AverageTotalFuelValueVehicles = "//pfe-tab-panel[2]//div[3]//pfe-kpi-card/div[@slot='pfe-kpi-card--value']";
        public String DegreeOfDifficultyVehicles = "//pfe-tab-panel[2]//div[1]/div/app-widget-card//div[@slot='pfe-kpi-card--label']";
        public String DegreeOfDifficultyValueVehicles = "//pfe-tab-panel[2]//div[1]/div/app-widget-card//div[@slot='pfe-kpi-card--value']";
        public String CO2EmissionsVehicles = "//pfe-tab-panel[2]//div[5]/div/app-widget-card//div[@slot='pfe-kpi-card--label']";
        public String CO2EmissionsValueVehicles = "//pfe-tab-panel[2]//div[5]/div/app-widget-card//div[@slot='pfe-kpi-card--value']";
        // Ranking Vehicles KPI xpath for TWAY
        public String AverageTotalFuelVehiclesTway = "//app-ranking-widget//*[@id='scoreSummaryContent']/div[1]//app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--label']";
        public String AverageTotalFuelValueVehiclesTway = "//app-ranking-widget//*[@id='scoreSummaryContent']/div[1]//app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--value']";
        public String PTOVehicles = "//app-ranking-widget//*[@id='scoreSummaryContent']/div[2]//app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--label']";
        public String PTOValueVehicles = "//app-ranking-widget//*[@id='scoreSummaryContent']/div[2]//app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--value']";
        public String IdlingVehicles = "//app-ranking-widget//*[@id='scoreSummaryContent']/div[3]//app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--label']";
        public String IdlingValueVehicles = "//app-ranking-widget//*[@id='scoreSummaryContent']/div[3]//app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--value']";
        public String NOfStopsVehicles = "//app-ranking-widget//*[@id='scoreSummaryContent']/div[4]//app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--label']";
        public String NOfStopsValueVehicles = "//app-ranking-widget//*[@id='scoreSummaryContent']/div[4]//app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--value']";
        public String CO2EmissionsVehiclesTway = "//app-ranking-widget//*[@id='scoreSummaryContent']/div[5]//app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--label']";
        public String CO2EmissionsValueVehiclesTway = "//app-ranking-widget//*[@id='scoreSummaryContent']/div[5]//app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--value']";
        // Ranking Vehicles KPI xpath for HeavyBus 
        public String VehicleVehicleButtonHeavyBus = "//pfe-table[@id='myGridVehicles']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='1_0']//span[@class='ag-icon ag-icon-contracted']";
        public String VehicleDrivingStyleButtonHeavyBus = "//pfe-table[@id='myGridVehicles']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='2_0']//span[@class='ag-icon ag-icon-contracted']";
        public String VehicleMissionButtonHeavyBus = "//pfe-table[@id='myGridVehicles']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='3_0']//span[@class='ag-icon ag-icon-contracted']";

        public String FuelSavingScoreVehiclesHeavyBus = "//app-ranking-widget-data-handler//app-score-summary-widget-content//app-widget-card-extended//div[@class='label']";
        public String FuelSavingScoreValueVehiclesHeavyBus = "//app-ranking-widget-data-handler//app-score-summary-widget-content//app-widget-card-extended//div[@class='value']";
        public String AverageTotalFuelVehiclesHeavyBus = "//app-ranking-widget//app-score-summary-widget-content/div/div[2]/div/app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--label']";
        public String AverageTotalFuelValueVehiclesHeavyBus = "//app-ranking-widget//app-score-summary-widget-content/div/div[2]/div/app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--value']";
        public String AverageSpeedVehiclesHeavyBus = "//app-ranking-widget//app-score-summary-widget-content/div/div[3]/div/app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--label']";
        public String AverageSpeedValueVehiclesHeavyBus = "//app-ranking-widget//app-score-summary-widget-content/div/div[3]/div/app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--value']";
        public String CO2EmissionsVehiclesHeavyBus = "//app-ranking-widget//app-score-summary-widget-content/div/div[4]/div/app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--label']";
        public String CO2EmissionsValueVehiclesHeavyBus = "//app-ranking-widget//app-score-summary-widget-content/div/div[4]/div/app-widget-card/pfe-kpi-card/div[@slot='pfe-kpi-card--value']";

        // Ranking Vehicles matrix xpath
        public String DriversRankingTab = "//pfe-tabs[@id='ranking-tabs']/pfe-tab[@id='driversTab']";
        public String VehiclesRankingTab = "//pfe-tabs[@id='ranking-tabs']/pfe-tab[@id='vehiclesTab']";
        public String VehicleVehicleButton =                  "//pfe-table[@id='myGridVehicles']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='1_0']//span[@class='ag-icon ag-icon-contracted']";
        public String VehicleFuelConsumptionButton =          "//pfe-table[@id='myGridVehicles']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='2_0']//span[@class='ag-icon ag-icon-contracted']";
        public String VehicleDriverButton =                   "//pfe-table[@id='myGridVehicles']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='3_0']//span[@class='ag-icon ag-icon-contracted']";
        public String VehicleMissionButton =                  "//pfe-table[@id='myGridVehicles']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='4_0']//span[@class='ag-icon ag-icon-contracted']";
        public String VehicleBehaviorButton =                 "//pfe-table[@id='myGridVehicles']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='5_0']//span[@class='ag-icon ag-icon-contracted']";

        public String VehicleVehicleButtonExpanded =           "//pfe-table[@id='myGridVehicles']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='1_0']//span[@class='ag-icon ag-icon-expanded']";
        public String VehicleFuelConsumptionButtonExpanded =   "//pfe-table[@id='myGridVehicles']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='2_0']//span[@class='ag-icon ag-icon-expanded']";
        public String VehicleDriverButtonExpanded =            "//pfe-table[@id='myGridVehicles']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='3_0']//span[@class='ag-icon ag-icon-expanded']";
        public String VehicleMissionButtonExpanded =           "//pfe-table[@id='myGridVehicles']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='4_0']//span[@class='ag-icon ag-icon-expanded']";
        public String VehicleBehaviorButtonExpanded =          "//pfe-table[@id='myGridVehicles']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='5_0']//span[@class='ag-icon ag-icon-expanded']";
        public String GridVehicles = "myGridVehicles";


        // Download test xpath
        public String ExportDataDrivers = "(//a[contains(text(),'Export Data')])[1]";
        public String ExportDataVehicles = "(//a[contains(text(),'Export Data')])[2]";
        public String ExportDataGreyDrivers = "(//pfe-cta[@aria-disabled='true'])[1]";
        public String ExportDataGreyVehicles = "(//pfe-cta[@aria-disabled='true'])[2]";


        //KPI Bus electric
        public String VehicleEnergyUsageButtonHeavyBus = "//pfe-table[@id='myGridVehicles']//div[@class='ag-header-row ag-header-row-column-group']/div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group' and @col-id='4_0']//span[@class='ag-icon ag-icon-contracted']";
        public String EnergyConsumption = "//app-ranking-widget-data-handler//div[contains (text(),'Energy consumption')]";
        public String RecoveredEnergyUsedEnergy = "//app-ranking-widget-data-handler//div[contains (text(),'Recovered energy/Used energy')]";
        public String AirConditioningEnergyUsedEnergy = "//app-ranking-widget-data-handler//div[contains (text(),'Air conditioning energy/Used energy')]";
        public String EnergyEfficiencyScore="//app-ranking-widget-data-handler//div[contains (text(),'Energy efficiency score')]";
    }
}
