using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__Permissions
    {
        public String Menu = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String Permissions= "//pfe-shoulder-menu[@id='shoulder-left']/pfe-accordion/pfe-accordion-header//*[contains (text(),'Permission')]";
        public String Permissions2 = "//a[contains(text(),'Permissions')]";

        public String AddNewUserTitle = "//*[@id='root']//app-permissions-app//app-permissions-driver-list//div[contains(text(),'Contact')]";
        public String AddNewUserAccountEmail = "//*[@id='root']//app-permissions-app//app-permissions-driver-list//span[contains(text(),'Account *')]";
        public String AddNewUserRegistered = "//*[@id='root']//app-permissions-app//app-permissions-driver-list//span[contains(text(),'Registered :')]";
        public String AddNewUserName = "//*[@id='root']//app-permissions-app//app-permissions-driver-list//span[contains(text(),'Name*')]";
        public String AddNewUserLastName = "//*[@id='root']//app-permissions-app//app-permissions-driver-list//span[contains(text(),'Surname*')]";
        public String AddNewUserPhone = "//*[@id='root']//app-permissions-app//app-permissions-driver-list//span[contains(text(),'Phone*')]";
        public String AddNewUserPrefixArrow = "//app-permissions-driver-list//div[@class='iti__selected-flag dropdown-toggle']//div[@class='iti__arrow']";
        public String AddNewUserPrefix = "//*[@id='iti-0__item-it']/span[@class='iti__dial-code' and contains (text (),'";
        public String AddNewUserSaveButton = "//*[@id='root']//app-permissions-app//app-permissions-driver-list//a[contains(text(),'SAVE')]";

        public String Account = "//*[@id='ewaDriverList']//span[contains(text(),'Account')]";
        public String AccountHeavy = "//*[@id='ewaHeavyPermissionList']//span[contains(text(),'Account')]";
        public String AccountLight = "//*[@id='ewaLightPermissionList']//span[contains(text(),'Account')]";
        public String AccountHeavyBus = "//*[@id='ewaBusPermissionList']//span[contains(text(),'Account')]";
        public String AccountTway = "//*[@id='ewaTwayPermissionList']//span[contains(text(),'Account')]";

        public String Registered = "//*[@id='ewaDriverList']//span[contains(text(),'Registered')]";
        public String Name = "//*[@id='ewaDriverList']//span[contains(text(),'Name')]";
        public String Surname = "//*[@id='ewaDriverList']//span[contains(text(),'Surname')]";
        public String PhoneNumber = "//*[@id='ewaDriverList']//span[contains(text(),'Phone Number')]";
        public String VehiclesVisibility = "//*[@id='ewaDriverList']//span[contains(text(),'Vehicles visibility')]";
        public String Actions = "//*[@id='ewaDriverList']//span[contains(text(),'Actions')]";
        public String AssignPermission = "//*[@class='title-subtitle']//*[contains(text(),'Assign Permission')]";
        public String History = "//*[@id='ewaHeavyPermissionList']//label[contains(.,'History')]";
        public String PermissionHistory = "//*[@class='title-subtitle']//*[contains(text(),'Permissions History')]";

        public String ActionsHeavy= "//*[@id='ewaHeavyPermissionList']//span[contains(text(),'Actions')]";
        public String ActionsLight = "//*[@id='ewaLightPermissionList']//span[contains(text(),'Actions')]";
        public String ActionsHeavyBus = "//*[@id='ewaBusPermissionList']//span[contains(text(),'Actions')]";
        public String ActionsTway = "//*[@id='ewaTwayPermissionList']//span[contains(text(),'Actions')]";
        public String Back = "//*[@class='permission-header']//*[contains(text(),'Back')]";

        public String ShowVehicleDetail = "//a[contains(text(),'Show vehicles detail')]";
        public String VINHeavy = "//*[@id='ewaHeavyPermissionList']//span[contains(text(), 'VIN')]";
        public String VINLight = "//*[@id='ewaLightPermissionList']//span[contains(text(), 'VIN')]";
        public String VINHeavyBus = "//*[@id='ewaBusPermissionList']//span[contains(text(), 'VIN')]";
        public String VINTway = "//*[@id='ewaTwayPermissionList']//span[contains(text(), 'VIN')]";
        public String AliasHeavy = "//*[@id='ewaHeavyPermissionList']//span[contains(text(),'Alias')]";
        public String AliasLight = "//*[@id='ewaLightPermissionList']//span[contains(text(), 'Alias')]";
        public String AliasHeavyBus = "//*[@id='ewaBusPermissionList']//span[contains(text(), 'Alias')]";
        public String AliasTway = "//*[@id='ewaTwayPermissionList']//span[contains(text(), 'Alias')]";
        public String ContractReferenceHeavy = "//*[@id='ewaHeavyPermissionList']//span[contains(text(),'Contract')]";
        public String ContractReferenceLight = "//*[@id='ewaLightPermissionList']//span[contains(text(),'Contract')]";
        public String ContractReferenceHeavyBus = "//*[@id='ewaBusPermissionList']//span[contains(text(),'Contract')]";
        public String ContractReferenceTway =  "//*[@id='ewaTwayPermissionList']//span[contains(text(),'Contract')]";
        public String Operator = "//span[contains(text(),'Operator')]";

        public String OverTheAirUpdateHeavyOPENED = "//*[@id='ewaHeavyPermissionList']//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][1]//span[@class='ag-icon ag-icon-contracted']";
        public String OverTheAirUpdateLightOPENED = "//*[@id='ewaLightPermissionList']//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][1]//span[@class='ag-icon ag-icon-contracted']";
        public String OverTheAirUpdateHeavyBusOPENED = "//*[@id='ewaBusPermissionList']//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][1]//span[@class='ag-icon ag-icon-contracted']";
        public String OverTheAirUpdateTwayOPENED = "//*[@id='ewaTwayPermissionList']//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][1]//span[@class='ag-icon ag-icon-contracted']";
        
        public String OverTheAirUpdateHeavyCLOSED = "//*[@id='ewaHeavyPermissionList']//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][1]//span[@class='ag-icon ag-icon-expanded']";
        public String OverTheAirUpdateLightCLOSED = "//*[@id='ewaLightPermissionList']//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][1]//span[@class='ag-icon ag-icon-expanded']";
        public String OverTheAirUpdateHeavyBusCLOSED = "//*[@id='ewaBusPermissionList']//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][1]//span[@class='ag-icon ag-icon-expanded']";
        public String OverTheAirUpdateTwayCLOSED = "//*[@id='ewaTwayPermissionList']//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][1]//span[@class='ag-icon ag-icon-expanded']";
        public String SFMHeavyOPENED = "//*[@id='ewaHeavyPermissionList']//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][3]//span[@class='ag-icon ag-icon-contracted']";
        public String SFMLightOPENED = "//*[@id='ewaLightPermissionList']//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][2]//span[@class='ag-icon ag-icon-contracted']";
        public String SFMHeavyBusOPENED = "//*[@id='ewaBusPermissionList']//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][2]//span[@class='ag-icon ag-icon-contracted']";
        public String SFMTwayOPENED = "//*[@id='ewaTwayPermissionList']//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][3]//span[@class='ag-icon ag-icon-contracted']";

        public String EWAHeavyOPENED = "//*[@id='ewaHeavyPermissionList']//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][2]//span[@class='ag-icon ag-icon-contracted']";
        public String EWATwayOPENED = "//*[@id='ewaTwayPermissionList']//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][2]//span[@class='ag-icon ag-icon-contracted']";
        public String EWAHeavyCLOSED = "//*[@id='ewaHeavyPermissionList']//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][2]//span[@class='ag-icon ag-icon-expanded']";
        public String EWATwayCLOSED = "//*[@id='ewaTwayPermissionList']//div[@class='ag-header-group-cell ag-focus-managed ag-header-group-cell-with-group'][2]//span[@class='ag-icon ag-icon-expanded']";

        public String LightTab="//*[@id='lightTab']/span";
        public String HeavyTab = "//*[@id='heavyTab']/span";
        public String HeavyBusTab = "//*[@id='busTab']/span";
        public String TwayTab = "//*[@id='twayTab']/span";

        public String TypeHeavy = "//*[@id='ewaHeavyPermissionList']//span[contains(text(), 'Type')]";
        public String TypeLight = "//*[@id='ewaLightPermissionList']//span[contains(text(), 'Type')]";
        public String TypeHeavyBus = "//*[@id='ewaBusPermissionList']//span[contains(text(), 'Type')]";
        public String TypeTway = "//*[@id='ewaTwayPermissionList']//span[contains(text(), 'Type')]";
        public String GivenByHeavy = "//*[@id='ewaHeavyPermissionList']//span[contains(text(), 'Given by')]";
        public String GivenByLight = "//*[@id='ewaLightPermissionList']//span[contains(text(), 'Given by')]";
        public String GivenByHeavyBus = "//*[@id='ewaBusPermissionList']//span[contains(text(), 'Given by')]";
        public String GivenByTway =  "//*[@id='ewaTwayPermissionList']//span[contains(text(), 'Given by')]";
        public String WhenHeavy = "//*[@id='ewaHeavyPermissionList']//span[contains(text(), 'When')]";
        public String WhenLight = "//*[@id='ewaLightPermissionList']//span[contains(text(), 'When')]";
        public String WhenHeavyBus = "//*[@id='ewaBusPermissionList']//span[contains(text(), 'When')]";
        public String WhenTway = "//*[@id='ewaTwayPermissionList']//span[contains(text(), 'When')]";

        public String AddButton = "//pfe-cta//a[contains (text(),'Add')]";
        public String ResendButton = "(//label[@class='link margin-r' and contains(text(),'Resend')])[1]";
        public String RemoveButton = "(//label[@class='link margin-r' and contains(text(),'Remove')])[1]";
        public String YesButton = "//pfe-modal[2]//pfe-cta[2]/a";
        public String TestAccount= "//span[contains(.,'a_demo_test_permission@yopmail.com')]";
        public String Details = "//*[@id='ewaDriverList']//label[contains(.,'Detail')]";
        public String VinHistory = "//*[@id='permissionHistoryTable']//span[contains(text(),'VIN')]";
        public String AliasHistory = "//*[@id='permissionHistoryTable']//span[contains(text(),'Alias')]";
        public String AccountHistory = "//*[@id='permissionHistoryTable']//span[contains(text(),'Account')]";
        public String ServiceTypeHistory = "//*[@id='permissionHistoryTable']//span[contains(text(),'Service Type')]";
        public String StatusHistory = "//*[@id='permissionHistoryTable']//span[contains(text(),'Status')]";
        public String StartDateHistory = "//*[@id='permissionHistoryTable']//span[contains(text(),'Start date')]";
        public String EndDateHistory = "//*[@id='permissionHistoryTable']//span[contains(text(),'End date')]";

        public String ExportData = "//a[contains(text(),'Export Data')]";
    }
}
