using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_Tway_Diesel_Mista_Month
    {
        // Define query parameters used in filters
        static string frequency = "w";
        static string from_date = "1685574000000";//"1685570400000";//"1685574000000";//local time;
        static string to_date = "1688165999000";//"1688162399000";//"1688165999000";//local time;
        static string vehicle_list = "WJMJ64CVZ0C450892-WJMJ64CVZ0C446363-WJMJ64CT00C449268";
        static string fuel_type = "1";
        static string fleet_id = "5";
        static string vehicle_type = "5";
        static string dashboard = vehicle_type + fuel_type;

        // Test classes
        public class Score_Summary_Tway_Diesel_Mista_Month : Score_Summary_Widget
        {
            //Fuel Consuption, Average Gross Combination Weight, Average Distance Per Unit, Average Speed, CO2 Emissions
            Values__Score_Summary_Tway Value = new Values__Score_Summary_Tway("63,77", "22,92", "3.963,75", "15,65", "19,8");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            [Category("Widget_Heavy1")]
            public void ScoreSummary() => FleetManagerViewForTwayFleets(Xpath, Value, Filters);
        }
        public class Fuel_Consumption_Tway_Diesel_Month : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("63,77 l/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            [Category("Widget_Heavy")]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }
        public class Monitored_Vehicles_Tway_Diesel_Month : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Vehicle Care Score, Average total fuel consumption (l/100km), CO2 emissions (t), Safe driving score
            new List<string>{ "WJMJ64CVZ0C450892 - GG074CC", "66,72","-", "62" , "6,2"},
            new List<string>{ "WJMJ64CVZ0C446363 - GG044WG", "69,11", "-", "64" , "6,6"},
            new List<string>{ "WJMJ64CT00C449268 - GG699VS", "57,34", "-", "58", "7,0"}

        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles Xpath = new Xpath__Monitored_Vehicles();

            [Test]
            [Category("Widget_Heavy")]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicleTway(Xpath, Value, Filters);
        }
        public class CO2_Emissions_Tway_Diesel_Mista_Month : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // WEEK COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{"1","4,4", "3", "2.733,80", "153"},
            new List<string>{"2","3,4", "3", "2.049,28", "120"},
            new List<string>{"3","3,8", "3", "2.201,05", "146"},
            new List<string>{"4","3,7", "3", "2.145,61", "149"},
            new List<string>{"5","4,6", "3", "2.772,98", "154"},};
            static string weeklyEmissionKPI = "3,9";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, weeklyEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            [Category("Widget_Heavy")]
            public void CO2Emissions() => CO2testKPIandColumnsHeavy(Xpath, Value, Filters);
        }
        public class Ranking_Vehicles_Tway_Diesel_Month : Rankings_Widget
        {
            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {

            {"8","0","-","-","-","23,00","18,11","93","-","-","41,86","58","GG699VS","-","AD410T45","75.271,29","1","WJMJ64CT00C449268","57,34","-","4.676,74","-","1.500,5"},
            {"9","0","-","-","-","22,91","14,75","120","-","-","47,44","62","GG074CC","-","AD410T51","55.280,70","2","WJMJ64CVZ0C450892","66,72","-","3.554,80","-","1.746,2"},
            {"6","1","-","-","-","22,82","13,98","131","-","-","43,48","64","GG044WG","-","AD410T51","49.066,18","3","WJMJ64CVZ0C446363","69,11","-","3.659,70","-","1.808,6"}};


            Values__Ranking_Vehicles_Tway Value = new Values__Ranking_Vehicles_Tway(datasetVehiclesMatrix, "63,77", "-", "61", "110", "1.668,8");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy_Ranking")]
            public void RankingVehicles() => RankingVehiclesTwayWidget(Xpath, Value, Filters);
        }
    }
}
