using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_HeavyBus_NP_Mista_Week
    {
        // Define query parameters used in filters
        static string frequency = "w";
        static string from_date = "1670803200000"; //TEST "1670799600000"; //"1670803200000"; //local time
        static string to_date = "1671407999000"; //TEST "1671404399000";//"1671407999000"; //local time
        static string vehicle_list = "VNE6436P50M051145-VNE6436P50M051419-VNE6436P70M051406-VNE6436P80M051477";
        static string fuel_type = "2";
        static string fleet_id = "17";
        static string vehicle_type = "3";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes

        public class Score_Summary_HeavyBus_NP_Mista_Week : Score_Summary_Widget
        {
            //Eco Score, Fuel Consumption, Total distance, Total trip time, trips, average speed, CO2 Emissions
            Values__Score_Summary_HeavyBus Value = new Values__Score_Summary_HeavyBus("57","27,32","1.028,47","96,6");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            public void ScoreSummary() => FleetManagerViewForHeavyBusFleets(Xpath, Value, Filters);
        }

        public class DSE_HeavyBus_NP_Mista_Week : DSE_Widget_Vehicles_Acceleration
        {
            //
            Values__DSE_HeavyBus Value = new Values__DSE_HeavyBus("57", "38", "41", "56", "-", "-", "-", "-");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE Xpath = new Xpath__DSE();

            [Test]
            public void DSE() => DSEkpiAnalysisHeavyBus(Xpath, Value, Filters);

        }

        public class Fuel_Consumption_HeavyBus_NP_Mista_Week : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("27,32 kg/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }
        public class CO2_Emissions_HeavyBus_NP_Mista_Week : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // day COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{ "1","59,3", "4", "2.829,27", "2.602" },
            new List<string>{ "2","65,0", "4", "2.562,29", "2.907" },
            new List<string>{ "3","78,7", "4", "2.674,64", "3.124" },
            new List<string>{ "4", "75,7", "4", "3.031,78", "3.097" },
            new List<string>{ "5","96,6", "4", "4.113,90", "3.708" }
        };
            static string dayEmissionKPI = "96,6";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, dayEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsHeavy(Xpath, Value, Filters);
        }

        public class Monitored_Vehicles_HeavyBus_NP_Mista_Week : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Average total fuel consumption (kg/100km), CO2 emissions (t), Comfort score
            new List<string>{ "VNE6436P50M051145 - GE-902-FQ", "56", "31,86", "1,1" , "-"},
            new List<string>{ "VNE6436P50M051419 - GE-780-ME", "57", "27,23", "94,4" , "-"},
            new List<string>{ "VNE6436P70M051406 - GE-741-FQ", "50", "30,00", "0,3", "-"}
        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles Xpath = new Xpath__Monitored_Vehicles();

            [Test]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicleHeavyBus(Xpath, Value, Filters);
        }

        public class Ranking_Vehicles_HeavyBus_NP_Mista_Week : Rankings_Widget
        {
            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {

            {"Acceleration style","38","41","56","-","-","-","-","1.389,43","36,98","51","27,23","14","708,0","GE-780-ME","-","CWGE 12M", "1", "VNE6436P50M051419","▲","57","52.382,41"},
            {"Acceleration style","39","69","64","-","-","-","-","402,08","27,59","83","30,00","27","780,1","GE-741-FQ","-","CWGE 12M", "2", "VNE6436P70M051406","=","50","30.049,78"},
            {"Acceleration style","44","62","66","-","-","-","-","946,31","27,14","72","31,58","30","821,0","GE-750-ML","-","CWGE 12M", "3", "VNE6436P80M051477","▲","53","42.698,02"},
            {"Acceleration style","52","55","68","-","-","-","-","1.376,08","25,41","64","31,86","33","828,2","GE-902-FQ","-","CWGE 12M", "4", "VNE6436P50M051145","▼","56","37.065,72" } };

            Values__Ranking_Vehicles_HeavyBus Value = new Values__Ranking_Vehicles_HeavyBus(datasetVehiclesMatrix, "57", "27,32", "36,69", "710,2");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy_Ranking")]
            public void RankingVehicles() => RankingVehiclesWidgetHeavyBus(Xpath, Value, Filters);
        }
    }
}