using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__Settings
    {
        public String Account = "//*[@id='pfe-navigation-user']/h3/a";
        public String ManageProfile = "//*[@id='pfe-navigation-user']//a[contains(text(),' Manage profile and preferences')]";
        public String PrivacySettings = "//*[@id='pfe-navigation-user']//a[contains(text(),'Privacy settings')]";
        //UserData
        public String NameLabel = "//*[@id='root']//pfe-input/label[contains(text(),'Name')]";
        public String SurnameLabel = "//*[@id='root']//pfe-input/label[contains(text(),'Surname')]";
        public String NotificationEmailLabel = "//*[@id='root']//pfe-input/label[contains(text(),'Notification email')]";
        public String PrefixLabel = "//*[@id='root']/div[2]/app-user-profile-page/div/div[1]/div[3]/app-personal-info-summary/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/form";
        public String MobileUserLabel = "//*[@id='root']//pfe-input/label[contains(text(),'Mobile')]";
        public String CountryUserLabel = "//*[@id='select-country-dropdown']";

        public String UserName = "//pfe-input[@name='userName']";

        //CompanyData                       
        public String CountryCompanyLabel = "//*[@id='select-company-country-dropdown']";
        public String VATNumberLabel = "//app-personal-info-summary//label[contains(text(),'VAT number')]";
        public String CompanyLabel = "//app-personal-info-summary//label[contains(text(),'Company')]";
        public String PhoneCompanyLabel = "//app-personal-info-summary//label[contains(text(),'Phone')]";
        public String CityLabel = "//app-personal-info-summary//label[contains(text(),'City')]";
        public String ZIPLabel = "//app-personal-info-summary//label[contains(text(),'ZIP')]";
        public String AddressLabel = "//app-personal-info-summary//label[contains(text(),'Address')]";
        //Site preferences
        public String LanguageLabel = "//app-site-preferences//label[contains(text(),'Language')]";
        public String FuelConsumptionUnitsDieselLabel = "//app-site-preferences//label[contains(text(),'Fuel consumption units for Diesel')]";
        public String FuelConsumptionUnitsNPLabel = "//app-site-preferences//label[contains(text(),'Fuel consumption units for NP')]";
        public String EnergyConsumptionUnitsElectricLabel = "//app-site-preferences//label[contains(text(),'Energy consumption units for Electric')]";
        public String TimezoneLabel = "//app-site-preferences//label[contains(text(),'Time zone')]";
        public String FuelConsumptionUnitslkm = "//*[@id='pfe-select-2']/*[contains(text(), 'l/100km')]";
        public String FuelConsumptionUnitskml = "//*[@id='pfe-select-2']/*[contains(text(), 'km/l')]";
        public String FuelConsumptionUnitskgkm = "//*[@id='pfe-select-3']/*[contains(text(), 'kg/100km')]";
        public String FuelConsumptionUnitskmkg = "//*[@id='pfe-select-3']/*[contains(text(), 'km/kg')]";
        public String EnergyConsumptionUnitskWh100km = "//*[@id='pfe-select-4']/*[contains(text(), 'kWh/100km')]";
        public String EnergyConsumptionUnitskWhkm = "//*[@id='pfe-select-4']/*[contains(text(), 'kWh/km')]";


        public String LanguageDropDown = "//pfe-select[@id='user-language-input']/select";
        public String FuelConsumptionUnitsDropDown = "//*[@id='pfe-select-1']";
        public String TimezoneDropDown = "//*[@id='pfe-select-2']";
        public String EmailsSettings = "//*[@class='emails-settings-outline']//*[contains(text(),'Emails settings')]";
        public String Trucks = "//*[@class='emails-settings-outline']//label[contains(text(),'Trucks')]";
        public String TWay = "//*[@class='emails-settings-outline']//label[contains(text(),'T-Way')]";
        public String Daily = "//*[@class='emails-settings-outline']//label[contains(text(),'Daily')]";
        public String Heavy = "//*[@class='emails-settings-outline']//label[contains(text(),'Heavy')]";

        //Report Settings
        public String SmartReport = "//*[@id='smartTab']";
        public String SafeDrivingReport = "//*[@id='safeTab']";
        public String VehiclesDropdownSmartHeavy = "//*[@id='vehiclesDropdownSmartHeavy']//div";
        public String FrequenciesSmartHeavy = "//*[@id='reports-tabs']/pfe-tab-panel[1]//app-report-settings-summary[1]//div[3]/label";
        public String VehiclesMaintenanceAlertDiesel = "//*[@id='reports-tabs']/pfe-tab-panel[1]/div/app-report-settings-summary[1]/div/div[4]/div/div[1]/pfe-input/label";
        public String VehiclesMaintenanceAlertGas = "//*[@id='reports-tabs']/pfe-tab-panel[1]/div/app-report-settings-summary[1]/div/div[4]/div/div[2]/pfe-input/label";
        public String VehiclesDropdownSmartLight = "//*[@id='vehiclesDropdownSmartLight']//div";
        public String FrequenciesSmartLight = "//*[@id='reports-tabs']/pfe-tab-panel[1]//app-report-settings-summary[2]//div[3]/label";
        public String CheckBoxEmailSmartHeavy = "//*[@id='reports-tabs']/pfe-tab-panel[1]/div/app-report-settings-summary[1]/div/div[5]/div/label";
        public String CheckBoxEmailSmartLight = "//*[@id='reports-tabs']/pfe-tab-panel[1]/div/app-report-settings-summary[2]/div/div[4]/div/label";

        public String SaveButton = "//app-root[@id='root']/div[2]/app-user-profile-page/pfe-modal";
        //Change password
        public String ClickHere = "//*[@id='root']//a[contains(text(),'Click here')]";
        public String OldPassword = "//*[@id='root']//label[contains(text(),'Old password')]";
        public String NewPassword = "//*[@id='root']//label[contains(text(),'New password')]";
        public String ConfirmNewPassword = "//*[@id='root']//label[contains(text(),'Confirm new password')]";
        //Privacy
        public String PrivacyNotice = "//*[@id='root']//div[contains(text(),'Privacy Notice')]";
        public String MarketingActivities = "//*[@id='root']//div[contains(text(),'Marketing Activities')]";
        public String MarketingThirdParties = "//*[@id='root']//div[contains(text(),'Marketing Third Parties ')]";
        public String RadioAgreeMarketingActivities = "//*[@id='1']/pfe-radio[1]";
        public String RadioAgreeCheckedMarketingActivities = "//*[@id='1']/pfe-radio[1][@checked]";
        public String RadioNotAgreeMarketingActivities = "//*[@id='1']/pfe-radio[2]";
        public String RadioNotAgreeCheckedMarketingActivities = "//*[@id='1']/pfe-radio[2][@checked]";
        public String Save = "//span[contains (text(), 'Save')]";
        public String SuccessufulPrivacySave = "//div[contains (text(),'Operation completed. Your settings have been saved! ')]";

        public String SaveButtonSettings = "//a[contains (text(),'Save')]";
        public String SuccessfulPopUp = "//body[contains (@style,'overflow: hidden')]//*[@class='pfe-modal__title pd-v-20 pd-h-20' and contains (text(),'Preferences saved successfully')]";
        public String FuelConsumptionTitle = "//div[@class=('row widget-header')]//div[contains(text(), 'Fuel consumption')]";
        public String EnergyusageTitle = "//div[@class=('row widget-header')]//div[contains(text(), 'Energy usage')]";
        public String UnitOfMeasurekml = "//div[contains (text(),' km/l')]";
        public String UnitOfMeasurelkm = "//div[contains (text(),' l/100km')]";
        public String UnitOfMeasurekmkg = "//div[contains (text(),' km/kg')]";
        public String UnitOfMeasurekgkm = "//div[contains (text(),' kg/100km')]";
        public String UnitOfMeasurekWh100km = "//div[contains (text(),' kWh/100km')]";
        public String UnitOfMeasurekWhkm = "//div[contains (text(),' kWh/km')]";

        public String FuelTypeLabel = "//*[@id='filterBar']//div[@class='dashboard-type-label']/strong";
    }
}
