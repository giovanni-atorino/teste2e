using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__FinancialService
    {
        public String Menu = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String InvoicesManagement = "//*[@id='shoulder-left']//h5[contains(text(),' Invoices management ')]";
        public String InvoicesManagementTitle = "//h1[contains(text(),'Invoices management ')]";
        public String LegalEntity = "//*[@id='invoicesListTable']//*[contains(text(),'Legal entity')]";
        public String Creditor = "//*[@id='invoicesListTable']//*[contains(text(),'Creditor')]";
        public String InvoiceNumber = "//*[@id='invoicesListTable']//*[contains(text(),'Invoice number')]";
        public String InvoiceDate = "//*[@id='invoicesListTable']//*[contains(text(),'Invoice date')]";
        public String DueDate = "//*[@id='invoicesListTable']//*[contains(text(),'Due date')]";
        public String Sign = "//*[@id='invoicesListTable']//*[contains(text(),'Sign')]";
        public String Currency = "//*[@id='invoicesListTable']//*[contains(text(),'Currency')]";
        public String TotalAmount = "//*[@id='invoicesListTable']//*[contains(text(),'Total amount')]";
        public String OutstandingAmount = "//*[@id='invoicesListTable']//*[contains(text(),'Outstanding amount')]";
        public String Asset = "//*[@id='invoicesListTable']//*[contains(text(),'Asset')]";
        public String Status = "//*[@id='invoicesListTable']//*[contains(text(),'Status')]";
        public String PaymentDate = "//*[@id='invoicesListTable']//*[contains(text(),'Payment date')]";

        public String DirectXButton = "//app-invoices-management//a[contains (text(),' MANAGE MY INVOICES ')]";
        public String LogoDirectX= "//*[@class='button-logo']";

        public String FirstLine = "//*[@id='invoicesListTable']//div[@row-index='0']";
        public String OPENIVOICESButton = "//app-invoices-management//a[contains (text(),'OPEN INVOICES')]";
    }
}
