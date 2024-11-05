using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_HeavyBus_NP_Mista_Day
    {
        // Define query parameters used in filters
        static string frequency = "d";
        static string from_date = "1678064400000"; //TEST "1678060800000"; //"1678064400000"; //local time
        static string to_date = "1678323599000"; //TEST "1678319999000";//"1678323599000"; //local time
        static string vehicle_list = "VNE6436P50M051145-VNE6436P50M051419-VNE6436P70M051406-VNE6436P80M051477";
        static string fuel_type = "2";
        static string fleet_id = "17";
        static string vehicle_type = "3";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes

        public class Score_Summary_HeavyBus_NP_Mista_Day : Score_Summary_Widget
        {
            //Eco Score, Fuel Consumption, Total distance, Total trip time, trips, average speed, CO2 Emissions
            Values__Score_Summary_HeavyBus Value = new Values__Score_Summary_HeavyBus("66","27,19","811,84","10,3");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            public void ScoreSummary() => FleetManagerViewForHeavyBusFleets(Xpath, Value, Filters);
        }

        public class DSE_HeavyBus_NP_Mista_Day : DSE_Widget_Vehicles_Acceleration
        {
            //
            Values__DSE_HeavyBus Value = new Values__DSE_HeavyBus("66", "74", "40", "74", "-", "-", "-", "-");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE Xpath = new Xpath__DSE();

            [Test]
            public void DSE() => DSEkpiAnalysisHeavyBus(Xpath, Value, Filters);

        }

        public class Fuel_Consumption_HeavyBus_NP_Mista_Day : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("27,19 kg/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }
        public class CO2_Emissions_HeavyBus_NP_Mista_Day : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // day COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{ "1","5,5", "3", "764,40", "196" },
            new List<string>{ "2","4,7", "4", "668,28", "174" },
            new List<string>{ "3","2,4", "4", "818,20", "97" },
            new List<string>{ "4", "2,5", "4", "787,65", "120" },
            new List<string>{ "5","0,7", "4", "962,74", "34" }
        };
            static string dayEmissionKPI = "2,6";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, dayEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsHeavy(Xpath, Value, Filters);
        }

        public class Monitored_Vehicles_HeavyBus_NP_Mista_Day : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Average total fuel consumption (kg/100km), CO2 emissions (t), Comfort score
            new List<string>{ "VNE6436P50M051145 - GE-902-FQ", "81", "32,12", "0,8" , "-"},
            new List<string>{ "VNE6436P50M051419 - GE-780-ME", "64", "26,61", "8,6" , "-"},
            new List<string>{ "VNE6436P70M051406 - GE-741-FQ", "75", "29,48", "0,5", "-"}
        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles Xpath = new Xpath__Monitored_Vehicles();

            [Test]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicleHeavyBus(Xpath, Value, Filters);
        }

        public class Ranking_Vehicles_HeavyBus_NP_Mista_Day : Rankings_Widget
        {
            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {

            {"Acceleration style","73","35","73","-","-","-","-","1.119,41","35,85","55","26,61","19","691,8","GE-780-ME","-","CWCE 12", "1", "VNE6436P50M051419","▼","64","66.207,17"},
            {"Acceleration style","74","55","76","-","-","-","-","613,75","31,21","58","29,48","25","766,5","GE-750-ML","-","CWCE 12", "2", "VNE6436P80M051477","▼","69","58.370,41"},
            {"Acceleration style","85","45","77","-","-","-","-","588,21","27,91","69","29,48","28","766,6","GE-741-FQ","-","CWCE 12", "3", "VNE6436P70M051406","▲","75","47.814,83"},
            {"Acceleration style","83","72","83","-","-","-","-","925,98","24,87","42","32,12","31","835,1","GE-902-FQ","-","CWCE 12", "4", "VNE6436P50M051145","=","81","53.701,90" } };

            Values__Ranking_Vehicles_HeavyBus Value = new Values__Ranking_Vehicles_HeavyBus(datasetVehiclesMatrix, "66", "27,19", "34,28", "707,1");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy_Ranking")]
            public void RankingVehicles() => RankingVehiclesWidgetHeavyBus(Xpath, Value, Filters);
        }
    }
}