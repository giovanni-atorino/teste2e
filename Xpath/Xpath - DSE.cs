using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__DSE
    {
        public String DashboardView = "//div[@class='dashboard-type-container']";
        public String DSEDriverRelatedLabelPath = "//div[@class='row widget-header']/div[contains(text(), 'Driving Style Evaluation')]";
        public String FuelSavingScoreLabelPath = "//div[contains(@class, 'kpi-section') and text()=' Fuel saving score ']";
        public String FuelSavingScoreValuePath = "//*[@id='widgetContainer3']//app-dse-sections/div/div[1]/div/div[2]";
        public String AccelerationLabelPath = "//div[contains(@class, 'kpi-section') and text()=' Acceleration ']";
        public String AccelerationValuePath = "//div[contains(@class, 'kpi-section') and text()=' Acceleration ']/following-sibling::div";
        public String InertiaLabelPath = "//div[contains(@class, 'kpi-section') and text()=' Inertia ']";
        public String InertiaValuePath = "//div[contains(@class, 'kpi-section') and text()=' Inertia ']/following-sibling::div";
        public String StopLabelPath = "//div[contains(@class, 'kpi-section') and text()=' Stop ']";
        public String StopValuePath = "//div[contains(@class, 'kpi-section') and text()=' Stop ']/following-sibling::div";
        public String DecelerationLabelPath = "//div[contains(@class, 'kpi-section') and text()=' Deceleration ']";
        public String DecelerationValuePath = "//div[@class='section-container ng-star-inserted'][2]//div[contains(@class, 'kpi-value')]";
        public String EngineUseLabelPath = "//div[contains(@class, 'kpi-section') and text()=' Engine use ']";
        public String EngineUseValuePath = "//div[@class='section-container ng-star-inserted'][3]//div[contains(@class, 'kpi-value')]";
        public String VehicleCareScoreLabelPath = "//div[contains(@class, 'kpi-section') and text()=' Vehicle care score ']";
        public String VehicleCareScoreValuePath = "//div[@class='section-container ng-star-inserted'][4]//div[contains(@class, 'kpi-value')]";
        public String BrakeUseLabelPath = "//div[contains(@class, 'kpi-section') and text()=' Brake use ']";
        public String BrakeUseValuePath = "//div[@class='section-container ng-star-inserted'][5]//div[contains(@class, 'kpi-value')]";
        public String TyresLabelPath = "//div[contains(@class, 'kpi-section') and text()=' Tyres ']";
        public String TyresValuePath = "//div[@class='section-container ng-star-inserted'][6]//div[contains(@class, 'kpi-value')]";
        public String SafeDrivingScoreLabelPath = "//div[contains(@class, 'kpi-section') and text()=' Safe driving score ']";
        public String SafeDrivingScoreValuePath = "//div[@class='section-container ng-star-inserted'][7]//div[contains(@class, 'kpi-value')]";
        public String ComfortScoreValuePath = "//div[contains(@class, 'kpi-section') and text()=' Comfort score ']/following-sibling::div";
        public String LateralComfortValuePath = "//div[contains(@class, 'kpi-section') and text()=' Lateral comfort score ']/following-sibling::div";
        public String LongitudinalComfortValuePath = "//div[contains(@class, 'kpi-section') and text()=' Longitudinal comfort score ']/following-sibling::div";
        public String VerticalComfortValuePath = "//div[contains(@class, 'kpi-section') and text()=' Vertical comfort score ']/following-sibling::div";


        // Heavy Bus Electric
        public String DrivingEfficiencyScoreLabelPath = "//div[contains(@class, 'kpi-section') and text()=' Driving efficiency score ']";
        public String DrivingEfficiencyScoreElectricValuePath = "//div[contains(@class, 'kpi-section') and text()=' Driving efficiency score ']/following-sibling::div";
        public String AccelerationElectricValuePath = "//div[contains(@class, 'kpi-section') and text()=' Acceleration ']/following-sibling::div";
        public String InertiaElectricValuePath = "//div[contains(@class, 'kpi-section') and text()=' Inertia ']/following-sibling::div";
        public String InertiaElectricLabelPath = "//div[contains(@class, 'kpi-section') and text()=' Inertia ']";
        public String StopElectricValuePath = "//div[contains(@class, 'kpi-section') and text()=' Stop ']/following-sibling::div";
        public String StopElectricLabelPath = "//div[contains(@class, 'kpi-section') and text()=' Stop ']";
        public String EnergyManagementElectricValuePath = "//*[@id=\"widgetContainer3\"]//app-dse-widget//div[4]/div/div[2]";
        public String ComfortScoreLabelPath = "//div[contains(@class, 'kpi-section') and text()=' Comfort score ']";
        public String ComfortScoreElectricValuePath = "//div[contains(@class, 'kpi-section') and text()=' Comfort score ']/following-sibling::div";
        public String LateralComfortLabelPath = "//div[contains(@class, 'kpi-section') and text()=' Lateral comfort score ']";
        public String LateralComfortElectricValuePath = "//div[contains(@class, 'kpi-section') and text()=' Lateral comfort score ']/following-sibling::div";
        public String LongitudinalComfortLabelPath = "//div[contains(@class, 'kpi-section') and text()=' Longitudinal comfort score ']";
        public String LongitudinalComfortElectricValuePath = "//div[contains(@class, 'kpi-section') and text()=' Longitudinal comfort score ']/following-sibling::div";
        public String VerticalComfortLabelPath = "//div[contains(@class, 'kpi-section') and text()=' Vertical comfort score ']";
        public String VerticalComfortElectricValuePath = "//div[contains(@class, 'kpi-section') and text()=' Vertical comfort score ']/following-sibling::div";

        //Heavy Bus Electric
        public String EnergyManagement="//*[@id='widgetContainer3']//div[contains (text(),'Energy management')]";

       

    }
}
