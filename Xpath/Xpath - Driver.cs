using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__Drivers
    {
        public String Menu = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String Drivers = "//h5[contains(text(), 'Drivers')]";
        public String ActiveDrivers="//*[@id='activeDriversTab']"; 
        public String ArchivedDrivers = "//*[@id='archivedDriversTab']";
        public String YourDrivers = "//*[@id='tableDrivers-active']//span[contains(text(), 'Your drivers') and @class='ag-header-cell-text']";
        public String IDdriver = "//*[@id='tableDrivers-active']//span[contains(text(), 'ID driver') and @class='ag-header-cell-text']";
        public String Email = "//*[@id='tableDrivers-active']//span[contains(text(), 'Email') and @class='ag-header-cell-text']";
        public String DriverFirstName = "//*[@id='tableDrivers-active']//span[contains(text(), 'Driver first name') and @class='ag-header-cell-text']";
        public String DriverLastName = "//*[@id='tableDrivers-active']//span[contains(text(), 'Driver last name') and @class='ag-header-cell-text']";
        public String ExpandTable= "//*[@id='tableDrivers-active']/div[1]/div/div[1]/div[2]/div[1]/div[2]/div/div[1]/div[2]/div[2]/span[3]/span";
        public String Phone = "//*[@id='tableDrivers-active']//span[contains(text(), 'Phone') and @class='ag-header-cell-text']";
        public String Country = "//*[@id='tableDrivers-active']//span[contains(text(), 'Country') and @class='ag-header-cell-text']";
        public String Language= "//*[@id='tableDrivers-active']//span[contains(text(), 'Language') and @class='ag-header-cell-text']";
        public String Action = "//*[@id='tableDrivers-active']//span[contains(text(), 'Action') and @class='ag-header-cell-text']";
        public String YourDriversArchived = "//*[@id='tableDrivers-archived']//span[contains( text(), 'Your drivers')]";
        public String ArchivedYourDrivers = "//*[@id='tableDrivers-archived']//span[contains(text(), 'Your drivers') and @class='ag-header-cell-text']";
        public String ArchivedIDdriver = "//*[@id='tableDrivers-archived']//span[contains(text(), 'ID driver') and @class='ag-header-cell-text']";
        public String ArchivedEmail = "//*[@id='tableDrivers-archived']//span[contains(text(), 'Email') and @class='ag-header-cell-text']";
        public String ArchivedDriverFirstName = "//*[@id='tableDrivers-archived']//span[contains(text(), 'Driver first name') and @class='ag-header-cell-text']";
        public String ArchivedDriverLastName = "//*[@id='tableDrivers-archived']//span[contains(text(), 'Driver last name') and @class='ag-header-cell-text']";
        public String ArchivedExpandTable = "//*[@id='tableDrivers-archived']/div[1]/div/div[1]/div[2]/div[1]/div[2]/div/div[1]/div[2]/div[2]/span[3]/span";
        public String ArchivedPhone = "//*[@id='tableDrivers-archived']//span[contains(text(), 'Phone') and @class='ag-header-cell-text']";
        public String ArchivedCountry = "//*[@id='tableDrivers-archived']//span[contains(text(), 'Country') and @class='ag-header-cell-text']";
        public String ArchivedLanguage = "//*[@id='tableDrivers-archived']//span[contains(text(), 'Language') and @class='ag-header-cell-text']";
        public String ArchivedAction = "//*[@id='tableDrivers-archived']//span[contains(text(), 'Action') and @class='ag-header-cell-text']";
        
        public String ArchivedButton = "//*[@id='tableDrivers-active']//*[@row-id='0']//label[contains(text(), 'Archive')]";
        public String ReactivateButton = "//*[@id='tableDrivers-archived']//*[@row-id='0']//label[contains(text(), 'Reactivate')]";
        public String FirstActiveDriverID ="//*[@id='tableDrivers-active']//*[@id='labelValue_driver_id_0']";
        public String FirstArchivedDriverID = "//*[@id='tableDrivers-archived']//*[@id='labelValue_driver_id_0']";
        public String FilterIDDriverArchivedSection = "//*[@id='tableDrivers-archived']//div[@col-id='driver_id']//span[@class='ag-header-icon ag-header-cell-menu-button']";
        public String FilterIDDriverActiveSection ="//*[@id='tableDrivers-active']//div[@col-id='driver_id']//span[@class='ag-header-icon ag-header-cell-menu-button']";
        public String FieldIDDriverText = "//*[@id='filterTextdriver_id']";
        public String ApplyButton = "//*[@id='applyButton']";

        public String AddNewDriver= "//*[@id='root']/div[2]/app-drivers-page/div/div/app-add-driver/div/pfe-cta/a";
        public String DriverNameLabel = "//*[@id='root']/div[2]/app-drivers-page/div/div/app-add-driver/pfe-modal/div[2]/div[1]/div[1]/pfe-input/label";
        public String DriverIDLabel ="//*[@id='root']/div[2]/app-drivers-page/div/div/app-add-driver/pfe-modal/div[2]/div[1]/div[3]/pfe-input/label";
        public String DriverEmailLabel = "//*[@id='root']/div[2]/app-drivers-page/div/div/app-add-driver/pfe-modal/div[2]/div[1]/div[5]/pfe-input/label";
        public String DriverSurnameLabel = "//*[@id='root']/div[2]/app-drivers-page/div/div/app-add-driver/pfe-modal/div[2]/div[1]/div[2]/pfe-input/label";
        public String DriverPhoneLabel = "//*[@id='root']/div[2]/app-drivers-page/div/div/app-add-driver/pfe-modal/div[2]/div[1]/div[4]/pfe-input/label";
        
        public String DriverID = "//*[@id='root']/div[2]/app-drivers-page/div/div/app-add-driver/pfe-modal/div[2]/div[1]/div[3]/pfe-input";
        public String DriverEmail = "//*[@id='root']/div[2]/app-drivers-page/div/div/app-add-driver/pfe-modal/div[2]/div[1]/div[5]/pfe-input";
        public String Save = "//*[@id='root']/div[2]/app-drivers-page/div/div/app-add-driver/pfe-modal/div[2]/div[2]/pfe-cta[2]/a";
        public String Cancel =" //*[@id='root']/div[2]/app-drivers-page/div/div/app-add-driver/pfe-modal/div[2]/div[2]/pfe-cta[1]/a";
        public String TotalDriversLabel= "//*[@id='root']/div[2]/app-drivers-page/div/div/app-add-driver/div/div";

        public String EmailPencilButton = "//*[@row-index='1']//img[@id='buttonForEdit_email']"; //"(//img[@id='buttonForEdit_email'])[1]"; 
        public String EmailField = "//*[@row-index='1']//input[@id='editDriver']";//"(//input[@id='editDriver'])[1]"; 
        public String EmailSaveButton = "//*[@row-index='1']//img[@id='editDriverSaveAction']";//"(//img[@id='editDriverSaveAction'])[1]";
        
        public String EmailRetrieved = "//*[@row-index='1']//div[@col-id='email']";//"//label[@id='editableLabelValue_email_0']"; 

        public String NamePencilButton = "//*[@row-index='1']//img[@id='buttonForEdit_first_name']";
        public String NameField = "//*[@row-index='1']//input[@id='editDriver']"; 
        public String NameSaveButton = "//*[@row-index='1']//img[@id='editDriverSaveAction']";
        public String NameRetrieved = "//*[@row-index='1']//div[@col-id='first_name']";//"//label[@id='editableLabelValue_first_name_1']";

        public String SurnamePencilButton = "//*[@row-index='1']//img[@id='buttonForEdit_last_name']";//"(//img[@id='buttonForEdit_last_name'])[2]";
        public String SurnameField = "//*[@row-index='1']//input[@id='editDriver']";// "(//input[@id='editDriver'])[2]";
        public String SurnameSaveButton = "//*[@row-index='1']//img[@id='editDriverSaveAction']";//"(//img[@id='editDriverSaveAction'])[2]";
        public String SurnameRetrieved = "//*[@row-index='1']//div[@col-id='last_name']";//"//label[@id='editableLabelValue_last_name_1']";

        public String ExportData = "//a[contains(text(),'Export Data')]";
        public String ExportDataGreyButton ="//pfe-cta[@aria-disabled='true']//a[contains(text(),'Export Data')]";
    }
}
