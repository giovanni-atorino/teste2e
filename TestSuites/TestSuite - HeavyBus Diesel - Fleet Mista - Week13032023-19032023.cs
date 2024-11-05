using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_HeavyBus_Diesel_Mista_Week
    {
        // Define query parameters used in filters
        static string frequency = "w";
        static string from_date = "1676246400000"; //"1676246400000"; //TEST "1676242800000"; //local time
        static string to_date = "1676851199000"; // "1676851199000";//TEST "1676847599000"; //local time
        static string vehicle_list = "VNE4826NX00313205-VNE5246P60M048374-VNE5246PX0M047812-VNE6236P00M049602-VNE6236P20M047611-VNE6236P20M049617";
        static string fuel_type = "1";
        static string fleet_id = "17";
        static string vehicle_type = "3";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes

        public class Score_Summary_HeavyBus_Diesel_Mista_Week : Score_Summary_Widget
        {
            //Eco Score, Fuel Consumption, Total distance, Total trip time, trips, average speed, CO2 Emissions
            Values__Score_Summary_HeavyBus Value = new Values__Score_Summary_HeavyBus("58","30,55","693,61","3,3");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            public void ScoreSummary() => FleetManagerViewForHeavyBusFleets(Xpath, Value, Filters);
        }

        public class DSE_HeavyBus_Diesel_Mista_Week : DSE_Widget_Vehicles_Acceleration
        {
            //
            Values__DSE_HeavyBus Value = new Values__DSE_HeavyBus("58","66","50","62","-","-","-","-");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE Xpath = new Xpath__DSE();

            [Test]
            public void DSE() => DSEkpiAnalysisHeavyBus(Xpath, Value, Filters);

        }

        public class Fuel_Consumption_HeavyBus_Diesel_Mista_Week : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("30,55 l/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }

        public class CO2_Emissions_HeavyBus_Diesel_Mista_Week : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // day COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{ "1","3,5", "6", "4.033,93", "164" },
            new List<string>{ "2","4,4", "6", "4.909,88", "204" },
            new List<string>{ "3","3,6", "6", "4.110,65", "169" },
            new List<string>{ "4","3,4", "6", "3.839,30", "128" },
            new List<string>{ "5","3,3", "6", "4.161,65", "134" }
        };
            static string dayEmissionKPI = "3,3";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, dayEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsHeavy(Xpath, Value, Filters);
        }

        public class Monitored_Vehicles_HeavyBus_Diesel_Mista_Week : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Average total fuel consumption (kg/100km), CO2 emissions (t), Comfort score
            new List<string>{ "VNE4826NX00313205", "53", "16,47", "0,3" , "-"},
            new List<string>{ "VNE5246P60M048374 - 6L31062", "67", "37,03", "1,1", "-"},
            new List<string>{ "VNE6236P00M049602 - GB125YX", "-", "-", "-", "-"}
        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles Xpath = new Xpath__Monitored_Vehicles();

            [Test]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicleHeavyBus(Xpath, Value, Filters);
        }

        public class Ranking_Vehicles_HeavyBus_Diesel_Mista_Week : Rankings_Widget
        {
            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {

            {"Acceleration style","37","69","75","-","-","-","-","664,84","63,03","20","16,47","14","431,0","-","-","BGL2 3D MH", "1", "VNE4826NX00313205","▲","53","15.874,65" },
            {"-","89","61","81","-","-","-","-","140,02","29,32","44","26,42","48","691,5","GC032GR","-","CWCE 12,1M", "2", "VNE6236P20M049617","▲","77","21.940,25"},
            {"Acceleration style","73","48","67","-","-","-","-","1.511,08","31,11","83","28,69","27","750,8","-","-","LICE 12.05M TER", "3", "VNE5246PX0M047812","▲","64","55.974,44"},
            {"Acceleration style","78","52","65","-","-","-","-","1.126,17","25,75","111","37,03","36","969,0","6L31062","-","LICE 12.05M TER", "4", "VNE5246P60M048374","▲","67","74.326,38"},
            {"Inertia","58","30","35","-","-","-","-","719,54","27,14","91","38,15","43","998,4","n/a","-","CWCE 12,1M", "5", "VNE6236P20M047611","▼","33","29.946,26"},
            {"-","-","-","-","-","-","-","-","0,00","-","300","-","100","-","GB125YX","-","CWCE 12,1M", "6", "VNE6236P00M049602","=","-","33.544,34",}};

            Values__Ranking_Vehicles_HeavyBus Value = new Values__Ranking_Vehicles_HeavyBus(datasetVehiclesMatrix, "58", "30,55", "30,98", "799,6");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy_Ranking")]
            public void RankingVehicles() => RankingVehiclesWidgetHeavyBus(Xpath, Value, Filters);
        }
    }
}