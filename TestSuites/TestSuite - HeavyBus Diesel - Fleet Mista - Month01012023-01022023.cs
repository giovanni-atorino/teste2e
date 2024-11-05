using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_HeavyBus_Diesel_Mista_Month
    {
        // Define query parameters used in filters
        static string frequency = "m";
        static string from_date = "1672534800000"; //TEST "1672531200000"; //"1672534800000"; //local time
        static string to_date = "1675213200000"; // TEST "1675209600000";//"1675213200000"; //local time
        static string vehicle_list = "VNE4826NX00313205-VNE5246P60M048374-VNE5246PX0M047812-VNE6236P00M049602-VNE6236P20M047611-VNE6236P20M049617";
        static string fuel_type = "1";
        static string fleet_id = "17";
        static string vehicle_type = "3";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes

        public class Score_Summary_HeavyBus_Diesel_Mista_Month : Score_Summary_Widget
        {
            //Eco Score, Fuel Consumption, Total distance, Total trip time, trips, average speed, CO2 Emissions
            Values__Score_Summary_HeavyBus Value = new Values__Score_Summary_HeavyBus("59","32,51","6.105,35","31,2");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            public void ScoreSummary() => FleetManagerViewForHeavyBusFleets(Xpath, Value, Filters);
        }

        public class DSE_HeavyBus_Diesel_Mista_Month : DSE_Widget_Vehicles_Acceleration
        {
            //
            Values__DSE_HeavyBus Value = new Values__DSE_HeavyBus("59", "67", "52", "60", "-", "-", "-", "-");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE Xpath = new Xpath__DSE();

            [Test]
            public void DSE() => DSEkpiAnalysisHeavyBus(Xpath, Value, Filters);

        }

        public class Fuel_Consumption_HeavyBus_Diesel_Mista_Month : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("32,51 l/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }

        public class CO2_Emissions_HeavyBus_Diesel_Mista_Month : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // day COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{ "1","10,8", "6", "12.673,95", "466" },
            new List<string>{ "2","10,6", "6", "12.925,97", "439" },
            new List<string>{ "3","15,1", "6", "18.144,84", "620" },
            new List<string>{ "4","17,1", "6", "22.140,69", "645" },
            new List<string>{ "5", "17,3", "6", "20.203,29", "792" }
        };
            static string dayEmissionKPI = "17,3";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, dayEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsHeavy(Xpath, Value, Filters);
        }

        public class Monitored_Vehicles_HeavyBus_Diesel_Mista_Month : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Average total fuel consumption (kg/100km), CO2 emissions (t), Comfort score
            new List<string>{ "VNE4826NX00313205", "50", "30,34", "4,6" , "-"},
            new List<string>{ "VNE5246P60M048374 - 6L31062", "60", "37,79", "10,3", "-"},
            new List<string>{ "VNE6236P00M049602 - GB125YX", "63", "28,23", "3,4", "-"}
        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles Xpath = new Xpath__Monitored_Vehicles();

            [Test]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicleHeavyBus(Xpath, Value, Filters);
        }


        public class Ranking_Vehicles_HeavyBus_Diesel_Mista_Month : Rankings_Widget
        {
            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {

            {"Inertia","80","64","66","-","-","-","-","4.577,77","26,77","81","28,23","34","738,9","GB125YX","-","CWCE 12,1M", "1", "VNE6236P00M049602","▲","63","34.633,44"},
            {"Acceleration style","73","50","66","-","-","-","-","11.959,50","29,05","80","29,55","33","773,2","-","-","LICE 12.05M TER", "2", "VNE5246PX0M047812","▲","67","58.492,87"},
            {"Inertia","75","50","67","-","-","-","-","1.279,82","27,23","67","30,12","42","788,3","GC032GR","-","CWCE 12,1M", "3", "VNE6236P20M049617","▲","72","22.131,40"},
            {"Acceleration style","43","58","61","-","-","-","-","5.746,85","25,63","130","30,34","30","794,0","-","-","BGL2 3D MH", "4", "VNE4826NX00313205","▲","50","15.916,74"},
            {"Acceleration style","70","50","58","-","-","-","-","10.446,71","24,80","102","37,79","40","988,9","6L31062","-","LICE 12.05M TER", "5", "VNE5246P60M048374","▲","60","76.285,11"},
            {"Inertia","62","30","40","-","-","-","-","2.621,48","26,05","86","38,34","45","1.003,3","n/a","-","CWCE 12,1M", "6", "VNE6236P20M047611","▲","36","30.433,92" } };

            Values__Ranking_Vehicles_HeavyBus Value = new Values__Ranking_Vehicles_HeavyBus(datasetVehiclesMatrix, "59", "32,51", "26,61", "850,7");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy_Ranking")]
            public void RankingVehicles() => RankingVehiclesWidgetHeavyBus(Xpath, Value, Filters);
        }

    }
}