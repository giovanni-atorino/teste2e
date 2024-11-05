using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__ServiceReferences
    {
        public String Menu="//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String CompanyTitle = "//h3[contains (text(),'Company')]";
        public String VATnumber = "//*[@name='vatNumber']";
        public String Company = "//*[@name='companyName']";
        public String FleetManagerTitle = "//h3[contains (text(),'Fleet Manager')]";
        public String NameFleetManager = "//*[@name='fmFirstName']";
        public String SurnameFleetManager = "//*[@name='fmSurname']";
        public String ClientEmailFleetManager = "//*[@name='fmEmail']";
        public String PhoneFleetManager = "//*[@name='fmPhone']";
        public String VehicleDetailsIconContracted =        "//div[@col-id='0_0']//span[@class='ag-icon ag-icon-contracted']";
        public String ContractDetailsIconContracted =       "//div[@col-id='1_0']//span[@class='ag-header-icon ag-header-expand-icon ag-header-expand-icon-collapsed']";
        public String ContractDealerDetailsIconContracted = "//div[@col-id='2_0']//span[@class='ag-header-icon ag-header-expand-icon ag-header-expand-icon-collapsed']";
        public String ServicePointsDetailsIconContracted = "//div[@col-id='3_0']//span[@class='ag-header-icon ag-header-expand-icon ag-header-expand-icon-collapsed']";
        public String ServiceKeyAccountIconContracted = "//div[@col-id='4_0']//span[@class='ag-header-icon ag-header-expand-icon ag-header-expand-icon-collapsed']";
        public String VIN = "//*[@id='tableTopcareVinList']//span[contains (text(),'VIN')]";
        public String Range = "//*[@id='tableTopcareVinList']//span[contains (text(),'Range')]";
        public String Fuel = "//*[@id='tableTopcareVinList']//span[contains (text(),'Fuel')]";
        public String ContractNumber = "//*[@id='tableTopcareVinList']//span[contains (text(),'Contract number')]";
        public String StartDate = "//*[@id='tableTopcareVinList']//span[contains (text(),'Start date')]";
        public String EndDate = "//*[@id='tableTopcareVinList']//span[contains (text(),'End date')]";
        public String ContractDealerName = "//*[@id='tableTopcareVinList']//span[contains (text(),'Contract Dealer Name')]";
        public String ContractDealerSAPcode = "//*[@id='tableTopcareVinList']//span[contains (text(),'Contract Dealer SAP code')]";
        public String ServicePointSAPcode = "//*[@id='tableTopcareVinList']//span[contains (text(),'Service Point SAP code')]";
        public String ServicePointName = "//*[@id='tableTopcareVinList']//span[contains (text(),'Service Point Name')]";
        public String ServicePointActiveStatus = "//*[@id='tableTopcareVinList']//span[contains (text(),'Service Point active status')]";
        public String PushNotificationsEnabled = "//*[@id='tableTopcareVinList']//span[contains (text(),'Push Notifications enabled')]";
        public String ManageMultipleAssignButton = "//a[contains (text(),'Manage Multiple Assign')]";
        public String CheckBoxFirstRow = "//div[@row-index='0']//div[@ref='eCheckbox']//*[@ref='eInput']";
        public String ManageMultipleAssignPopupTitle = "//div[contains(@class,'header-wrapper')]//*[contains(text(),' Manage Multiple Assign ')]";
        public String SKACheckBox="//*[@id='assignSKAunchecked']";
        public String SKACheckBoxChecked = "//*[@id='assignSKAchecked']";
        public String CustomerContactable = "//div[contains(@class,'margin-r col-lg-9 row')]//*[contains(text(),'Customer contactable')]";
        public String BoxCustomerContactable = "//*[@id='assignCCchecked']";
        public String HDSCheckBox = "//*[@id='assignHDSunchecked']";
        public String HDSCheckBoxChecked = "//*[@id='assignHDSchecked']";
        public String SetPushNotification="//*[@id='assignHDSunchecked' and @value='setPush']";
        public String SetPushNotificationChecked = "//*[@id='assignHDSchecked' and @value='setPush']";
        public String SaveButton= "//*[@class=\"PFElement\"]//*[contains (text(),'SAVE')]";
        
        public String HDSSapCodeValueTableFirstRow="//*[@id='tableTopcareVinList']//div[@row-index='0']//div[@col-id='homedealer_service_sapcode']";
        public String HDSNameValueTableFirstRow = "//*[@id='tableTopcareVinList']//div[@row-index='0']//div[@col-id='homedealer_service_name']";
        public String PushNotificationEnabledFirtRow=     "//*[@id='tableTopcareVinList']//div[@row-index='0']//div[@col-id='push_notification']//div[@class='ag-wrapper ag-input-wrapper ag-checkbox-input-wrapper ag-checked ag-disabled']";
        public String PushNotificationNotEnabledFirtRow = "//*[@id='tableTopcareVinList']//div[@row-index='0']//div[@col-id='push_notification']//div[@class='ag-wrapper ag-input-wrapper ag-checkbox-input-wrapper ag-disabled']";


        public String SKAEmailValueTableFirstRow =   "//*[@id='tableTopcareVinList']//div[@row-index='0']//div[@col-id='ska_email']";
        public String SKANameValueTableFirstRow =    "//*[@id='tableTopcareVinList']//div[@row-index='0']//div[@col-id='ska_firstname']";
        public String SKASurnameValueTableFirstRow = "//*[@id='tableTopcareVinList']//div[@row-index='0']//div[@col-id='ska_lastname']";
        public String SKAPhoneValueTableFirstRow =   "//*[@id='tableTopcareVinList']//div[@row-index='0']//div[@col-id='ska_phone']";
        public String CustomerContactableTableFirstRow = "//*[@id='tableTopcareVinList']//div[@row-index='0']//div[@col-id='ska_customerContactable']";

        public String testSKAyopmailemail = "//*[@id='pfe-select-1']/option[@value='testSKA@yopmail.com']";
        public String ARASPA = "//*[@value='0000001014']";
      


    }
}
