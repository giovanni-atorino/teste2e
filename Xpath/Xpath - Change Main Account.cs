using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__ChangeMainAccount
    {
        public String Menu = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String CompanyManagement = "//*[@id='shoulder-left']//h5[contains (text(),'Company Management')]";
        public String CompanyManagementTitle = "//h1[contains (text(),'Company Management')]";

        public String CountryAustria = "//*[@id='pfe-select-1']/*[@value='14']";
        public String ChangeMainAccountTooltip = "//*[@row-index='0']//*[@title='Manage service accounts']";
        public String ChangeMainAccountTitle = "//div[contains (text(),'Manage service accounts')]";

        public String VATnumber = "//*[@name='companyVat']";
        public String Company = "//*[@name='companyName']";
        public String MainAccountLabel = "//*[@id='root']//span[contains(text(), 'Main account')]";
        public String MasterFleetManagerLabel = "//*[@id='root']//span[contains(text(), 'Master fleet manager')]";
        public String EditMAicon = "//span[text()=' Main account ']/parent::div/parent::div//pfe-icon[@icon='dcx-repeat']";
        public String PopupMainChange = "//*[@id='masterAccountsContainer']//div[contains(text(),'MAIN ACCOUNT: ACCOUNT CHANGE')]";

        public String CurrentAccountTitle = "//*[@class='padding fleet-manager-data-container']//div[contains (text(),'Current account')]";
        public String NameMainAccount = "//*[@name='accountName']";
        public String SurnameMainAccount = "//*[@name='accountSurname']";
        public String AccountMainAccount = "//*[@name='accountUsername']";
        public String PrefixMainAccount = "//*[@name='accountPhonePrefix']";
        public String PhoneMainAccount = "//*[@name='accountPhone']";
        public String LanguageMainAccount = "//*[@name='accountLanguage']";

        public String ChangeInTitle = "//*[@id='masterAccountsContainer']//div[contains(text(),'Change in')]";
        public String NewAccount = "//*[@name='newAccountUsername']";
        public String CurrentlyActiveServicesTitle = "//div[contains (text(),'Currently active services')]";
        public String LanguageDropDownDisabled = "//*[@id='pfe-select' and @disabled='true']";
        public String LanguageDropDownEnabled = "//*[@id='pfe-select']";
        public String SelectPrefixArrow = "//app-fleet-manager-change//div[@class='iti__selected-flag dropdown-toggle']//div[@class='iti__arrow']";
        public String NewPrefix = "//*[@id='iti-0__item-it']/span[@class='iti__dial-code' and contains (text (),'";
        public String PhoneDisabled = "//pfe-input[@name='newAccountPhone' and @disabled]";
        public String PhoneEnabled = "//pfe-input[@name='newAccountPhone']";
        public String NameDisabled = "//pfe-input[@name='newAccountName' and @disabled]";
        public String NameEnabled = "//pfe-input[@name='newAccountName']";
        public String SurnameDisabled = "//pfe-input[@name='newAccountSurname' and @disabled]";
        public String SurnameEnabled = "//pfe-input[@name='newAccountSurname']";
        public String SearchButton = "//app-fleet-manager-change//pfe-input[@name='newAccountUsername']/pfe-icon";
        public String ErrorPopUpSameMA = "//pfe-icon[@icon='dcx-alert-triangle-line']";
        public String SaveButton = "//*[@class='is-center padding button-footer']/pfe-cta//a[contains (text(),'SAVE')]";
        public String ConfirmChangeMAPopUp = "//app-mainaccount-manage-user//pfe-cta//a[contains (text(),'YES')]";
        public String SuccessfulPopUp = "//app-mainaccount-manage-user//h2[contains (text(),'Operation completed')]";
        public String YesConfirmButton = "//app-mainaccount-manage-user//pfe-cta//a[contains (text(),'YES')]";
        public String Xbutton = "//app-mainaccount-manage-user//h2[contains (text(),'Operation completed')]/parent::div/parent::*";

        public String NewMAfield = "//pfe-input[@name='newAccountUsername']";
        public String NewPhoneField = "//pfe-input[@name='newAccountPhone']";
        public String NewNameField = "//pfe-input[@name='newAccountName']";
        public String NewSurnameField = "//pfe-input[@name='newAccountSurname']";
        public String FilterForCompanyNameColumn = "//*[@id='companyListTable']//div[@col-id='business-name']//span[@ref='eMenu']";
        public String TextBoxForCompanyName = "//*[@id='filterTextbusiness-name']";
        public String ApplyButton = "//*[@id='applyButton']";

    }
}