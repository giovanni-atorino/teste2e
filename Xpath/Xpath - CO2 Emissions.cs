using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Xpath__CO2_Emissions
    {

        public String CO2Emissions = "//div[@id='widgetContainer2']//div[@class='widget-title text-subtitle-1 padding-tb']";
        public String Emissions = "//div[@id='co2EmissionsContent']//div[@class='co2-emissions-summary-label text-body']/span";
        public String EmissionsValue = "//div[@id='co2EmissionsContent']//div[@class='co2-emissions-summary-value margin-r']/div/strong";

        public String GenericColumn = "//*[contains(@class, 'highcharts-point highcharts-color-0')]";

        public String FirstColumn = "//*[contains(@class, 'highcharts-point highcharts-color-0')][1]";
        public String SecondColumn = "//*[contains(@class, 'highcharts-point highcharts-color-0')][2]";
        public String ThirdColumn = "//*[contains(@class, 'highcharts-point highcharts-color-0')][3]";
        public String FourthColumn = "//*[contains(@class, 'highcharts-point highcharts-color-0')][4]";
        public String FifthColumn = "//*[contains(@class, 'highcharts-point highcharts-color-0')][5]";
        public String ColumnValue = "//*[contains(@class, 'highcharts-label highcharts-tooltip')]//div[2]";


        //eDaily Electric
        public String CO2Saved = "//div[@id='widgetContainer2']//div[@class='widget-title text-subtitle-1 padding-tb']";
        public String SavedValue = "//*[@id=\"co2EmissionsContent\"]//div/strong";

    }
}
