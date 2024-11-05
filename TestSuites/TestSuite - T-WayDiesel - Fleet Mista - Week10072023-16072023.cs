using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_Tway_Diesel_Mista_Week
    {
        // Define query parameters used in filters
        static string frequency = "w";
        static string from_date = "1689030000000";//"1689026400000";//"1689030000000";//local time;
        static string to_date = "1689634799000";//"1689631199000";//"1689634799000";//local time;
        static string vehicle_list = "WJMJ64CVZ0C450892-WJMJ64CVZ0C446363-WJMJ64CT00C449268";
        static string fuel_type = "1";
        static string fleet_id = "5";
        static string vehicle_type = "5";
        static string dashboard = vehicle_type + fuel_type;

        // Test classes
        public class Score_Summary_Tway_Diesel_Mista_Week : Score_Summary_Widget
        {
            //Fuel Consuption, Average Gross Combination Weight, Average Distance Per Unit, Average Speed, CO2 Emissions
            Values__Score_Summary_Tway Value = new Values__Score_Summary_Tway("68,14", "21,56", "1.636,71", "15,01", "8,8");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            [Category("Widget_Heavy1")]
            public void ScoreSummary() => FleetManagerViewForTwayFleets(Xpath, Value, Filters);
        }
        public class Fuel_Consumption_Tway_Diesel_Week : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("68,14 l/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            [Category("Widget_Heavy")]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }
        public class Monitored_Vehicles_Tway_Diesel_Week : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Vehicle Care Score, Average total fuel consumption (l/100km), CO2 emissions (t), Safe driving score
            new List<string>{ "WJMJ64CVZ0C450892 - GG074CC", "69,76","-", "62" , "3,6"},
            new List<string>{ "WJMJ64CVZ0C446363 - GG044WG", "73,03", "-", "64" , "2,5"},
            new List<string>{ "WJMJ64CT00C449268 - GG699VS", "62,50", "-", "61", "2,7"}

        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles Xpath = new Xpath__Monitored_Vehicles();

            [Test]
            [Category("Widget_Heavy")]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicleTway(Xpath, Value, Filters);
        }
        public class CO2_Emissions_Tway_Diesel_Mista_Week : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // WEEK COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{"1","3,7", "3", "2.145,61", "149"},
            new List<string>{"2","4,6", "3", "2.772,98", "154"},
            new List<string>{"3","4,3", "3", "2.722,31", "150"},
            new List<string>{"4","2,7", "3", "2.239,46", "131"},
            new List<string>{"5","3,9", "3", "2.089,95", "157"},};
            static string weeklyEmissionKPI = "3,9";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, weeklyEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            [Category("Widget_Heavy")]
            public void CO2Emissions() => CO2testKPIandColumnsHeavy(Xpath, Value, Filters);
        }
        public class Ranking_Vehicles_Tway_Diesel_Week : Rankings_Widget
        {
            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {

            {"7","2","-","-","-","20,46","16,76","113","-","-","45,94","61","GG699VS","-","AD410T45","77.930,49","1","WJMJ64CT00C449268","62,50","-","1.674,44","-","1.635,5"},
            {"9","0","-","-","-","21,51","14,86","114","-","-","47,11","62","GG074CC","-","AD410T51","57.848,43","2","WJMJ64CVZ0C450892","69,76","-","1.951,87","-","1.825,6"},
            {"6","0","-","-","-","22,94","13,56","128","-","-","45,80","64","GG044WG","-","AD410T51","50.988,82","3","WJMJ64CVZ0C446363","73,03","-","1.283,80","-","1.911,1"}};


            Values__Ranking_Vehicles_Tway Value = new Values__Ranking_Vehicles_Tway(datasetVehiclesMatrix, "68,14", "-", "63", "117", "1.783,1");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy_Ranking")]
            public void RankingVehicles() => RankingVehiclesTwayWidget(Xpath, Value, Filters);
        }
    }
}
