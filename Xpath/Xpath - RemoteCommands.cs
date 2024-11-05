using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__RemoteCommands
    {

        //Remote Commands
        public String RemoteCommands = "//*[@class='eDaily']//div[contains(text(), 'Control panel')]";
        public String ChargingTab = "//*[@class='tabs margin-t mt-4']//*[contains(text(), 'CHARGING')]";
        public String Charging = "//*[@class='eDaily']//div[contains(text(), 'Charging')]";
        public String ChargingStatus = "//*[@class='eDaily']//span[contains(text(), 'Charging status')]";
        public String StateOfCharge = "//*[@class='eDaily']//span[contains(text(), 'State of charge')]";
        public String Range = "//*[@class='eDaily']//span[contains(text(), 'Range')]";
        public String ToCompleteTheCharge = "//*[@class='eDaily']//span[contains(text(), 'To complete the charge')]";
        public String ElectricityPriority = "//*[@class='eDaily']//*[contains(text(), 'Electricity load priority')]";
        public String ClimatizationTab = "//*[@class='tabs margin-t mt-4']//*[contains(text(), 'CLIMATIZATION')]";
        public String Climatization = "//*[@class='eDaily']//span[contains(text(), 'Climatization')]";
        public String ClimatizationMode = "//*[@class='eDaily']//span[contains(text(), 'Climatization mode')]";
        public String TargetVehicleTemperature = "//*[@class='eDaily']//span[contains(text(), 'Target vehicle temperature')]";
        public String ClimatizationEcoMode = "//*[@class='commonCls'][contains(text(), 'Climatization eco mode')]";
        public String ClimatizationEcoModeNormal = "//*[@class='mt-2 mb-2 PFElement'][contains(text(), 'Normal')]";
        public String ClimatizationEcoModeEco = "//*[@class='mt-2 mb-2 PFElement'][contains(text(), 'Eco')]";
        public String DrivingModeTab = "//*[@class='tabs margin-t mt-4']//*[contains(text(), 'DRIVING MODE')]";
        public String CurrentStatus2 = "//*[@class='eDaily']//*[contains(text(), 'Current status')]";
        public String NextStatus2 = "//*[@class='eDaily']//*[contains(text(), 'Next status')]";
        public String ChangeDrivingMode = "//*[@class='eDaily']//*[contains(text(), 'CHANGE DRIVING MODE')]";
        public String DetailsButton = "//*[@class='eDaily']//*[contains(text(), 'DETAILS')]";
        public String RegenerationModeTab = "//*[@class='tabs margin-t mt-4']//*[contains(text(), 'REGENERATION MODE')]";
        public String ChangeRegenerationMode = "//*[@class='eDaily']//*[contains(text(), 'CHANGE REGENERATION MODE')]";
        public String ePTOtab = "//*[@class='tabs margin-t mt-4']//*[contains(text(), 'ePTO')]";


        public String VehicleSettings = "//*[@class='eDaily']//div[contains(text(), 'Vehicle settings')]";
        public String VehicleDrivingMode = "//*[@class='commonCls'][contains(text(), 'Driving mode')]";
        public String VehicleDrivingModeAll = "//*[@class='m-3 PFElement'][contains(text(), 'All driving modes')]";
        public String VehicleDrivingModeNatural = "//*[@class='m-3 PFElement'][contains(text(), 'Natural')]";
        public String VehicleDrivingModeEco = "//*[@class='m-3 PFElement'][contains(text(), 'Eco')]";
        public String VehicleRegenerationMode = "//*[@class='commonCls'][contains(text(), 'Regeneration mode')]";
        public String VehicleRegenerationModeAll = "//*[@class='m-3 PFElement'][contains(text(), ' All regenerative modes ')]";
        public String VehicleRegenerationRegenerative = "//*[@class='m-3 PFElement'][contains(text(), 'Regenerative')]";
        public String VehicleRegenerationModeOnePedal = "//*[@class='m-3 PFElement'][contains(text(), 'One-pedal drive')]";
        public String VehicleRegenerationModeSailing = "//*[@class='m-3 PFElement'][contains(text(), 'Sailing')]";
        public String VehicleePTODeactivation = "//*[@class='commonCls'][contains(text(), 'ePTO Deactivation')]";



        //Remote commands Section
        public String Menu = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String ControlPanelTruck = "//*[@class='text-title mb-4'][contains(text(), 'Control panel')]";
        public String ControlPanel = "//*[@class='eDaily']//div[contains(text(), 'Control Panel')]";
        public String VehiclesManagement = "//*[@id='pfe-accordion-vehicles']//h5[contains (text (),'Vehicles management')]";
        public String RemoteCommandsSection = "//*[@id='shoulder-left']//a[@href='/remote-commands']";
        public String RemoteCommandsLabel = "//*[@class='text-title padding'][contains(text(), 'Remote commands')]";
        public String TrucksTab = "//*[@id='heavyTab']/span";
        public String DailyTab = "//*[@id='lightTab']/span";
        public String VehicleNameTruck = "//*[@id='tableHeavyFleets']//span[contains (text(),'Vehicle name')]";
        public String VehicleNameDaily = "//*[@id='tableLightFleets']//span[contains (text(),'Vehicle name')]";
        public String VINTruck = "//*[@id='tableHeavyFleets']//span[contains (text(),'VIN')]";
        public String VINDaily = "//*[@id='tableLightFleets']//span[contains (text(),'VIN')]";
        public String PlateNumberTruck = "//*[@id='tableHeavyFleets']//span[contains (text(),'Plate number')]";
        public String PlateNumberDaily = "//*[@id='tableLightFleets']//span[contains (text(),'Plate number')]";
        public String EngineWorkHoursTruck = "//*[@id='tableHeavyFleets']//span[contains (text(),'Engine work hours')]";
        public String ServiceBatteryChargeTruck = "//*[@id='tableHeavyFleets']//span[contains (text(),'Service battery charge %')]";
        public String ChargingStatusColumnDaily = "//*[@id='tableLightFleets']//span[contains (text(),'Charging status')]";
        public String DrivingModeDaily = "//*[@id='tableLightFleets']//span[contains (text(),'Driving mode')]";
        public String RegenerativeModeDaily = "//*[@id='tableLightFleets']//span[contains (text(),'Regenerative mode')]";
        public String ElectricityLoadDaily = "//*[@id='tableLightFleets']//span[contains (text(),'% electricity load priority')]";
        public String TemperatureDaily = "//*[@id='tableLightFleets']//span[contains (text(),'Temperature (°C)')]";
        public String ElectricityPowerDaily = "//*[@id='tableLightFleets']//span[contains (text(),'Electric Power Take-off (ePTO)')]";


        //Remote commands MY24
        public String DOORS = "//*[@class='tabs margin-t mt-4']//*[contains(text(), 'DOORS')]";
        public String WINDOWS = "//*[@class='tabs margin-t mt-4']//*[contains(text(), 'WINDOWS')]";
        public String CRANKING = "//*[@class='tabs margin-t mt-4']//*[contains(text(), 'CRANKING')]";
        public String ADASSETTINGS = "//*[@class='tabs margin-t mt-4']//*[contains(text(), 'ADAS SETTINGS')]";
        public String ECOLOCK = "//*[@class='tabs margin-t mt-4']//*[contains(text(), 'ECO LOCK')]";
        public String DoorsButton = "//*[@class='section']//*[contains (text (),'CHANGE DOORS')]";
        public String WindowsButton = "//*[@class='section']//*[contains (text (),'CHANGE WINDOWS')]";
        public String CrankingButton = "//*[@class='section']//*[contains (text (),'CHANGE CRANKING')]";
        public String AdassettingsButton = "//*[@class='section']//*[contains (text (),'CHANGE ADAS SETTINGS')]";
        public String EcolockButton = "//*[@class='section']//*[contains (text (),'CHANGE ECO LOCK')]";
        public String CurrentStatus = "//*[@class='section']//*[contains(text(), 'Current status')]";
        public String NextStatus = "//*[@class='section']//*[contains(text(), 'Next status')]";
    }
}