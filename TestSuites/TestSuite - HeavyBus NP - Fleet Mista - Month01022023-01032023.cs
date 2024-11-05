using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_HeavyBus_NP_Mista_Month
    {
        // Define query parameters used in filters
        static string frequency = "m";
        static string from_date = "1675213200000"; //TEST "1675209600000"; //"1675213200000"; //local time
        static string to_date = "1677632400000"; //TEST "1677628800000";//"1677632400000"; //local time
        static string vehicle_list = "VNE6436P50M051145-VNE6436P50M051419-VNE6436P70M051406-VNE6436P80M051477";
        static string fuel_type = "2";
        static string fleet_id = "17";
        static string vehicle_type = "3";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes

        public class Score_Summary_HeavyBus_NP_Mista_Month : Score_Summary_Widget
        {
            //Eco Score, Fuel Consumption, Total distance, Total trip time, trips, average speed, CO2 Emissions
            Values__Score_Summary_HeavyBus Value = new Values__Score_Summary_HeavyBus("63","27,76","11.869,40","146,0");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            public void ScoreSummary() => FleetManagerViewForHeavyBusFleets(Xpath, Value, Filters);
        }

        public class DSE_HeavyBus_NP_Mista_Month : DSE_Widget_Vehicles_Acceleration
        {
            //
            Values__DSE_HeavyBus Value = new Values__DSE_HeavyBus("63", "71", "43", "70", "-", "-", "-", "-");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE Xpath = new Xpath__DSE();

            [Test]
            public void DSE() => DSEkpiAnalysisHeavyBus(Xpath, Value, Filters);

        }

        public class Fuel_Consumption_HeavyBus_NP_Mista_Month : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("27,76 kg/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }
        public class CO2_Emissions_HeavyBus_NP_Mista_Month : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // day COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{ "1","289,9", "4", "11.641,28", "11.436" },
            new List<string>{ "2","245,2", "4", "9.920,55", "10.314" },
            new List<string>{ "3","371,8", "4", "17.187,82", "14.979" },
            new List<string>{ "4", "360,0", "4", "24.648,90", "14.310" },
            new List<string>{ "5","34,1", "4", "22.271,61", "1.404" }
        };
            static string dayEmissionKPI = "34,1";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, dayEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsHeavy(Xpath, Value, Filters);
        }

        public class Monitored_Vehicles_HeavyBus_NP_Mista_Month : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Average total fuel consumption (kg/100km), CO2 emissions (t), Comfort score
            new List<string>{ "VNE6436P50M051145 - GE-902-FQ", "75", "33,93", "10,3" , "-"},
            new List<string>{ "VNE6436P50M051419 - GE-780-ME", "61", "27,18", "117,9" , "-"},
            new List<string>{ "VNE6436P70M051406 - GE-741-FQ", "73", "28,20", "9,8", "-"}
        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles Xpath = new Xpath__Monitored_Vehicles();

            [Test]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicleHeavyBus(Xpath, Value, Filters);
        }

        public class Ranking_Vehicles_HeavyBus_NP_Mista_Month : Rankings_Widget
        {
            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {

            {"Acceleration style","70","41","69","-","-","-","-","11.998,66","36,14","49","27,18","20","706,7","GE-780-ME","-","CWGE 12M", "1", "VNE6436P50M051419","▲","61","71.627,78"},
            {"Acceleration style","85","43","69","-","-","-","-","13.374,52","29,43","59","28,20","24","733,1","GE-741-FQ","-","CWGE 12M", "2", "VNE6436P70M051406","▲","73","52.522,82"},
            {"Acceleration style","73","49","76","-","-","-","-","10.470,84","31,06","60","29,52","24","767,4","GE-750-ML","-","CWGE 12M", "3", "VNE6436P80M051477","▲","68","60.859,43"},
            {"Acceleration style","76","59","81","-","-","-","-","11.633,59","24,04","51","33,93","34","882,3","GE-902-FQ","-","CWGE 12M", "4", "VNE6436P50M051145","▲","75","58.289,52" } };

            Values__Ranking_Vehicles_HeavyBus Value = new Values__Ranking_Vehicles_HeavyBus(datasetVehiclesMatrix, "63", "27,76", "34,34", "721,7");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy_Ranking")]
            public void RankingVehicles() => RankingVehiclesWidgetHeavyBus(Xpath, Value, Filters);
        }
    }
}