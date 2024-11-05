using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__ChangeFleetManager
    {
        public String Menu = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String CompanyManagement = "//*[@id='shoulder-left']//h5[contains (text(),'Company Management')]";
        public String CompanyManagementTitle = "//h1[contains (text(),'Company Management')]";

        public String CountryAustria = "//*[@id='pfe-select-1']/*[@value='14']";
        public String ChangeFleetManagerTooltip = "//*[@row-index='0']//*[@title='Manage service accounts']";
        public String ChangeFleetManagerTitle = "//div[contains (text(),'Manage service accounts')]";

        public String VATnumber = "//*[@name='companyVat']";
        public String Company = "//*[@name='companyName']";
        public String MainAccountLabel = "//*[@id='root']//span[contains(text(), 'Main account')]";
        public String MasterFleetManagerLabel = "//*[@id='root']//span[contains(text(), 'Master fleet manager')]";
        public String EditMFMIcon = "//span[text()=' Master fleet manager ']/parent::div/parent::div//pfe-icon[@icon='dcx-repeat']";

        public String NameFleetManager = "//*[@name='fmName']";
        public String SurnameFleetManager = "//*[@name='fmSurname']";
        public String AccountFleetManager = "//*[@name='fmAccount']";
        public String PrefixFleetManager = "//*[@name='fmPhonePrefix']";
        public String PhoneFleetManager = "//*[@name='fmPhone']";
        public String LanguageFleetManager = "//*[@name='fmLanguage']";

        public String ChangeInTitle = "//*[@class='padding fleet-manager-data-container']//div[contains (text(),'Change in')]";
        public String NewAccount = "//*[@name='newFmAccount']";
        public String CurrentlyActiveServicesTitle = "//div[contains (text(),'Currently active services')]";
        public String LanguageDropDownDisabled = "//*[@id='pfe-select' and @disabled='true']";
        public String LanguageDropDownEnabled = "//*[@id='pfe-select']";
        public String SelectPrefixArrow = "//app-fleet-manager-change/pfe-modal//*[@class='iti__selected-flag dropdown-toggle']//div[@class='iti__arrow']";
        public String NewPrefix = "//*[@id='iti-0__item-it']/span[@class='iti__dial-code' and contains (text (),'";
        public String PhoneDisabled = "//pfe-input[@name='newFmPhone' and @disabled]";
        public String PhoneEnabled = "//pfe-input[@name='newFmPhone']";
        public String NameDisabled = "//pfe-input[@name='newFmName' and @disabled]";
        public String NameEnabled = "//pfe-input[@name='newFmName']";
        public String SurnameDisabled = "//pfe-input[@name='newFmSurname' and @disabled]";
        public String SurnameEnabled = "//pfe-input[@name='newFmSurname']";
        public String SearchButton = "//app-fleet-manager-change//pfe-input[@name='newFmAccount']/pfe-icon";
        public String ErrorPopUpSameMFM = "//pfe-icon[@icon='dcx-alert-triangle-line']";
        public String SuccessfulPopUp = "//pfe-modal[2]//h2[contains (text(),'Operation completed')]";
        public String SaveButton = "//*[@class='is-center padding button-footer']/pfe-cta//a[contains (text(),'SAVE')]";
        public String ConfirmChangeMFMPopUp = "//*[@id='root']//app-fleet-manager-change//h2[@id='itcvqe2ty']";
        public String YesConfirmButton = "//app-fleet-manager-change/pfe-modal[1]//pfe-cta[@pfe-priority='primary']/a";
        public String Xbutton = "//app-fleet-manager-change/pfe-modal//h2[contains(text(), 'Operation completed')]/parent::div/parent::*";


        public String NewMfmField = "//pfe-input[@name='newFmAccount']";
        public String NewPhoneField = "//pfe-input[@name='newFmPhone']";
        public String NewNameField = "//pfe-input[@name='newFmName']";
        public String NewSurnameField = "//pfe-input[@name='newFmSurname']";
        public String FilterForCompanyNameColumn = "//*[@id='companyListTable']//div[@col-id='business-name']//span[@ref='eMenu']";
        public String TextBoxForCompanyName = "//*[@id='filterTextbusiness-name']";
        public String ApplyButton = "//*[@id='applyButton']";

    }
}