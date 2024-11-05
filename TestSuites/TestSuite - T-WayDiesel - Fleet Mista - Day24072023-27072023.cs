using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_Tway_Diesel_Mista_Day
    {
        // Define query parameters used in filters
        static string frequency = "d";
        static string from_date = "1690243200000";//"1690239600000";//"1690243200000";//local time;
        static string to_date = "1690498799000";//"1690495199000";//"1690498799000";//local time;
        static string vehicle_list = "WJMJ64CS0MC456234-WJMJ64CSZMC444660-WJMJ64CT00C449268-WJMJ64CVZ0C451440";
        static string fuel_type = "1";
        static string fleet_id = "5";
        static string vehicle_type = "5";
        static string dashboard = vehicle_type + fuel_type;

        // Test classes
        public class Score_Summary_Tway_Diesel_Mista_Day : Score_Summary_Widget
        {
            //Fuel Consuption, Average Gross Combination Weight, Average Distance Per Unit, Average Speed, CO2 Emissions
            Values__Score_Summary_Tway Value = new Values__Score_Summary_Tway("61,35", "22,07", "187,64", "15,88", "1,2");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            [Category("Widget_Heavy1")]
            public void ScoreSummary() => FleetManagerViewForTwayFleets(Xpath, Value, Filters);
        }
        public class Fuel_Consumption_Tway_Diesel_Day : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("61,35 l/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            [Category("Widget_Heavy")]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }
        public class Monitored_Vehicles_Tway_Diesel_Day : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Vehicle Care Score, Average total fuel consumption (l/100km), CO2 emissions (t), Safe driving score
            new List<string>{ "WJMJ64CS0MC456234 - WZ913EJ", "50,00","-", "67" , "0,1"},
            new List<string>{ "WJMJ64CSZMC444660 - FG0783N", "58,00", "-", "64" , "0,1"},
            new List<string>{ "WJMJ64CT00C449268 - GG699VS", "62,65", "-", "62", "0,8"}

        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles Xpath = new Xpath__Monitored_Vehicles();

            [Test]
            [Category("Widget_Heavy")]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicleTway(Xpath, Value, Filters);
        }
        public class CO2_Emissions_Tway_Diesel_Mista_Day : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // WEEK COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{"1","0,4", "3", "306,15", "16"},
            new List<string>{"2","0,4", "4", "235,45", "16"},
            new List<string>{"3","0,2", "2", "174,91", "10"},
            new List<string>{"4","0,5", "4", "340,21", "17"},
        };
            static string weeklyEmissionKPI = "0,4";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, weeklyEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            [Category("Widget_Heavy")]
            public void CO2Emissions() => CO2testKPIandColumnsHeavy(Xpath, Value, Filters);
        }
        public class Ranking_Vehicles_Tway_Diesel_Day : Rankings_Widget
        {
            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {

            {"5","0","-","-","-","18,71","13,70","63","-","-","37,25","67","WZ913EJ","-","AD410T41B","27.382,69","1","WJMJ64CS0MC456234","50,00","-","59,21","-","1.308,6"},
            {"8","-","-","-","-","31,11","15,09","87","-","-","39,24","64","FG0783N","-","AD410T41B","37.081,68","2","WJMJ64CSZMC444660","58,00","-","87,88","-","1.517,8"},
            {"7","-","-","-","-","20,00","16,51","101","-","-","45,99","62","GG699VS","-","AD410T45","78.683,80","3","WJMJ64CT00C449268","62,65","-","497,26","-","1.639,6"},
            {"14","-","-","-","-","33,37","14,05","-","-","-","63,32","50","GF121XR","-","AD410T51","15.731,16","4","WJMJ64CVZ0C451440","64,33","-","106,22","-","1.683,6"}};


            Values__Ranking_Vehicles_Tway Value = new Values__Ranking_Vehicles_Tway(datasetVehiclesMatrix, "61,35", "-", "62", "98", "1.605,4");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy_Ranking")]
            public void RankingVehicles() => RankingVehiclesTwayWidget(Xpath, Value, Filters);
        }
    }
}
