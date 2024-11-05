using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__Download
    {
        public String Menu = "//*[@id='root']/div[1]/app-main-menu/pfe-navigation/pfe-navigation-item[1]/h2/a";
        public String Download = "//h5[contains(text(), 'Download')]";
        public String Filters = "//span[contains(text(),'Filters')]";
        public String HeavyTab = "//pfe-tab[@id='heavyTab']";
        public String LightTab = "//pfe-tab[@id='lightTab']";
        public String HeavyBusTab = "//pfe-tab[@id='busTab']";
        public String TwayTab = "//pfe-tab[@id='twayTab']";
        public String StartPeriodHeavy = "//*[@id='tableHeavyDownloadReport']//span[contains(text(), 'Start Period') and @class='ag-header-cell-text']";
        public String EndPeriodHeavy =   "//*[@id='tableHeavyDownloadReport']//span[contains(text(), 'End Period') and @class='ag-header-cell-text']";
        public String ReportTypeHeavy =  "//*[@id='tableHeavyDownloadReport']//span[contains(text(), 'Report Type') and @class='ag-header-cell-text']";
        public String FrequencyHeavy =   "//*[@id='tableHeavyDownloadReport']//span[contains(text(), 'Frequency') and @class='ag-header-cell-text']";
        public String FileFormatHeavy =  "//*[@id='tableHeavyDownloadReport']//span[contains(text(), 'File Format') and @class='ag-header-cell-text']";
        public String ActionHeavy =      "//*[@id='tableHeavyDownloadReport']//span[contains(text(), 'Action') and @class='ag-header-cell-text']";

        public String StartPeriodLight = "//*[@id='tableLightDownloadReport']//span[contains(text(), 'Start Period') and @class='ag-header-cell-text']";
        public String EndPeriodLight =   "//*[@id='tableLightDownloadReport']//span[contains(text(), 'End Period') and @class='ag-header-cell-text']";
        public String ReportTypeLight =  "//*[@id='tableLightDownloadReport']//span[contains(text(), 'Report Type') and @class='ag-header-cell-text']";
        public String FrequencyLight =   "//*[@id='tableLightDownloadReport']//span[contains(text(), 'Frequency') and @class='ag-header-cell-text']";
        public String FileFormatLight =  "//*[@id='tableLightDownloadReport']//span[contains(text(), 'File Format') and @class='ag-header-cell-text']";
        public String ActionLight =      "//*[@id='tableLightDownloadReport']//span[contains(text(), 'Action') and @class='ag-header-cell-text']";

        public String ExportDataHeavy = "(//a[contains(text(),'Export Data')])[1]";
        public String ExportDataLight = "(//a[contains(text(),'Export Data')])[2]";
        public String ExportDataHeavyBus = "(//a[contains(text(),'Export Data')])[3]";
        public String ExportDataTway = "(//a[contains(text(),'Export Data')])[4]";
    }
}
