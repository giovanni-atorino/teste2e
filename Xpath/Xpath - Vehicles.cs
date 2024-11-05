using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__Vehicles
    {
        public String Menu = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String VehiclesManagement = "//*[@id='pfe-accordion-vehicles']//h5[contains (text (),'Vehicles management')]";
        public String Vehicles = "//*[@id='shoulder-left']//a[@href='/fleets']";
        public String VehiclesMaintenance = "//*[@id='shoulder-left']//a[@href=\"/vehicle-maintenance\"]";
        public String HeavyTab = "//pfe-tab[@id='heavyTab']";
        public String LightTab = "//pfe-tab[@id='lightTab']";
        public String HeavyBusTab = "//pfe-tab[@id='busTab']";
        public String TwayTab = "//pfe-tab[@id='twayTab']";
        public String YourVehicleHeavy = "//*[@id='tableHeavyFleets']//span[contains (text(),'Your vehicle')]";
        public String YourVehicleLight = "//*[@id='tableLightFleets']//span[contains (text(),'Your vehicle')]";
        public String YourVehicleHeavyBus = "//*[@id='tableBusFleets']//span[contains (text(),'Your vehicle')]";
        public String YourVehicleTway = "//*[@id='tableTwayFleets']//span[contains (text(),'Your vehicle')]";
        public String VehicleNameHeavy = "//*[@id='tableHeavyFleets']//span[contains(text(), 'Vehicle name')]";
        public String VehicleNameLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Vehicle name')]";
        public String VehicleNameHeavyBus = "//*[@id='tableBusFleets']//span[contains(text(), 'Vehicle name')]";
        public String VehicleNameTway = "//*[@id='tableTwayFleets']//span[contains(text(), 'Vehicle name')]";
        public String VINHeavy = "//*[@id='tableHeavyFleets']//span[contains(text(), 'VIN')]";
        public String VINLight = "//*[@id='tableLightFleets']//span[contains(text(), 'VIN')]";
        public String VINHeavyBus = "//*[@id='tableBusFleets']//span[contains(text(), 'VIN')]";
        public String VINTway = "//*[@id='tableTwayFleets']//span[contains(text(), 'VIN')]";
        public String ModelHeavy = "//*[@id='tableHeavyFleets']//span[contains(text(), 'Model')]";
        public String ModelLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Model')]";
        public String ModelHeavyBus = "//*[@id='tableBusFleets']//span[contains(text(), 'Model')]";
        public String ModelTway = "//*[@id='tableTwayFleets']//span[contains(text(), 'Model')]";
        public String FuelHeavy = "//*[@id='tableHeavyFleets']//span[contains(text(), 'Fuel')]";
        public String FuelLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Fuel')]";
        public String FuelHeavyBus = "//*[@id='tableBusFleets']//span[contains(text(), 'Fuel')]";
        public String FuelTway = "//*[@id='tableTwayFleets']//span[contains(text(), 'Fuel')]";
        public String PlateNumberHeavy = "//*[@id='tableHeavyFleets']//span[contains(text(), 'Plate number')]";
        public String PlateNumberLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Plate number')]";
        public String PlateNumberHeavyBus = "//*[@id='tableBusFleets']//span[contains(text(), 'Plate number')]";
        public String PlateNumberTway = "//*[@id='tableTwayFleets']//span[contains(text(), 'Plate number')]";
        public String OdemeterHeavy = "//*[@id='tableHeavyFleets']//span[contains(text(), 'Odometer')]";
        public String OdemeterLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Odometer')]";
        public String OdemeterTway = "//*[@id='tableTwayFleets']//span[contains(text(), 'Odometer')]";
        public String EngineHeavy = "//*[@id='tableHeavyFleets']//span[contains(text(), 'Engine work hours')]";
        public String EngineLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Engine work hours')]";
        public String EngineTway = "//*[@id='tableTwayFleets']//span[contains(text(), 'Engine work hours')]";
        public String NextMaintenanceHeavy = "//*[@id='tableHeavyFleets']//span[contains(text(), 'Next maintenance')]";
        public String NextMaintenanceLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Next maintenance')]";
        public String NextMaintenanceTway = "//*[@id='tableTwayFleets']//span[contains(text(), 'Next maintenance')]";
        public String SeverityHeavy = "//*[@id='tableHeavyFleets']//span[contains(text(), 'Severity')]";
        public String SeverityLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Severity')]";
        public String SeverityTway = "//*[@id='tableTwayFleets']//span[contains(text(), 'Severity')]";
        public String ConnectivityBoxHeavy = "//*[@id='tableHeavyFleets']//span[contains(text(), 'Connectivity Box')]";
        public String ConnectivityBoxLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Connectivity Box')]";
        public String ConnectivityBoxHeavyBus = "//*[@id='tableBusFleets']//span[contains(text(), 'Connectivity Box')]";
        public String ConnectivityBoxTway = "//*[@id='tableTwayFleets']//span[contains(text(), 'Connectivity Box')]";
        public String AssociatedFleetsHeavy = "//*[@id='tableHeavyFleets']//span[contains(text(), 'Associated fleets')]";
        public String AssociatedFleetsLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Associated fleets')]";
        public String AssociatedFleetsHeavyBus = "//*[@id='tableBusFleets']//span[contains(text(), 'Associated fleets')]";
        public String AssociatedFleetsTway = "//*[@id='tableTwayFleets']//span[contains(text(), 'Associated fleets')]";
        public String EngineWorkFleetsHeavy = "//*[@id='tableHeavyFleets']//span[contains(text(), 'Engine work hours')]";
        public String EngineWorkFleetsLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Engine work hours')]";
        public String ServiceBatteryFleetsHeavy = "//*[@id='tableHeavyFleets']//span[contains(text(), 'Service battery charge')]";
        public String ServiceBatteryFleetsLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Service battery charge')]";
        public String OdometerFleetsLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Odometer')]";
        public String FuelLevelFleetsLight = "//*[@id='tableLightFleets']//span[contains(text(), 'fuel level')]";
        public String TractionBatteryFleetsLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Traction battery charge')]";
        public String DrivingModeFleetsLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Driving mode')]";
        public String RegenerativeFleetsLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Regenerative mode')]";
        public String ElectricityFleetsLight = "//*[@id='tableLightFleets']//span[contains(text(), 'electricity load priority')]";
        public String TemperatureFleetsLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Temperature')]";
        public String ClimaFleetsLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Climatization mode')]";
        public String ElectricPowerFleetsLight = "//*[@id='tableLightFleets']//span[contains(text(), 'Electric Power Take-off')]";


        public String AddFleet = "//*[@id='root']/div[2]/app-fleets-page/div/div/div[2]/app-create-fleet/div/pfe-cta/a";
        public String InsertFleetNameLabelTextBox = "//*[@id='root']/div[2]/app-fleets-page/div/div/div[2]/app-create-fleet/pfe-modal/div/div[2]/pfe-input/label";
        public String InsertFleetNameTextBox = "//div[@class='margin padding']//pfe-input[@class='mr-input PFElement']";
        public String Submit = "(//a[contains(text(),'Submit')])[8]";
        public String AddIcon = "//*[@id='addIcon_0']";

        public String ExportDataHeavy = "//*[@id='tableHeavyFleets']//a[contains(text(),'Export Data')]";
        public String ExportDataHeavyGreyButton = "//*[@id='tableHeavyFleets']//pfe-cta[@aria-disabled='true']//a[contains(text(),'Export Data')]";
        public String ExportDataLight = "//*[@id='tableLightFleets']//a[contains(text(),'Export Data')]";
        public String ExportDataLightGreyButton = "//*[@id='tableLightFleets']//pfe-cta[@aria-disabled='true']//a[contains(text(),'Export Data')]";
        public String ExportDataHeavyBus = "//*[@id='tableBusFleets']//a[contains(text(),'Export Data')]";
        public String ExportDataHeavyBusGreyButton = "//*[@id='tableBusFleets']//pfe-cta[@aria-disabled='true']//a[contains(text(),'Export Data')]";
        public String ExportDataTway = "//*[@id='tableTwayFleets']//a[contains(text(),'Export Data')]";
        public String ExportDataTwayGreyButton = "//*[@id='tableTwayFleets']//pfe-cta[@aria-disabled='true']//a[contains(text(),'Export Data')]";

    }
}