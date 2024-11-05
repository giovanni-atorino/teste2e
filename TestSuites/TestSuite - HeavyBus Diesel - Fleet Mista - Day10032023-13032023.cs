using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_HeavyBus_Diesel_Mista_Day
    {
        // Define query parameters used in filters
        static string frequency = "d";
        static string from_date = "1678410000000"; //TEST "1678406400000"; //"1678410000000"; //local time
        static string to_date = "1678755599000"; // TEST "1678751999000";//"1678755599000"; //local time
        static string vehicle_list = "VNE4826NX00313205-VNE5246P60M048374-VNE5246PX0M047812-VNE6236P00M049602-VNE6236P20M047611-VNE6236P20M049617";
        static string fuel_type = "1";
        static string fleet_id = "17";
        static string vehicle_type = "3";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes

        public class Score_Summary_HeavyBus_Diesel_Mista_Day : Score_Summary_Widget
        {
            //Eco Score, Fuel Consumption, Total distance, Total trip time, trips, average speed, CO2 Emissions
            Values__Score_Summary_HeavyBus Value = new Values__Score_Summary_HeavyBus("61","31,01","349,31","1,4");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            public void ScoreSummary() => FleetManagerViewForHeavyBusFleets(Xpath, Value, Filters);
        }

        public class DSE_HeavyBus_Diesel_Mista_Day : DSE_Widget_Vehicles_Acceleration
        {
            //
            Values__DSE_HeavyBus Value = new Values__DSE_HeavyBus("61", "78", "48", "65", "-", "-", "-", "-");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE Xpath = new Xpath__DSE();

            [Test]
            public void DSE() => DSEkpiAnalysisHeavyBus(Xpath, Value, Filters);

        }

        public class Fuel_Consumption_HeavyBus_Diesel_Mista_Day : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("31,01 l/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }

        public class CO2_Emissions_HeavyBus_Diesel_Mista_Day : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // day COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{ "1","0,5", "5", "608,36", "21" },
            new List<string>{ "2","0,0", "1", "13,64", "0" },
            //new List<string>{ "3","-", "1", "0,12", "0" },
            new List<string>{ "3","0,4", "5", "552,47", "19" },
            new List<string>{ "4", "0,4", "4", "571,98", "20" }
        };
            static string dayEmissionKPI = "0,4";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, dayEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsHeavy(Xpath, Value, Filters);
        }

        public class Monitored_Vehicles_HeavyBus_Diesel_Mista_Day : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Average total fuel consumption (kg/100km), CO2 emissions (t), Comfort score
            new List<string>{ "VNE4826NX00313205", "91", "-", "-" , "-"},
            new List<string>{ "VNE5246P60M048374 - 6L31062", "61", "36,67", "0,6", "-"},
            new List<string>{ "VNE6236P00M049602 - GB125YX", "65", "26,39", "0,4", "-"}
        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles Xpath = new Xpath__Monitored_Vehicles();

            [Test]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicleHeavyBus(Xpath, Value, Filters);
        }


        public class Ranking_Vehicles_HeavyBus_Diesel_Mista_Day : Rankings_Widget
        {
            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {

            {"Inertia","83","57","66","-","-","-","-","621,54","32,92","58","26,39","32","690,5","GB125YX","-","CWCE 12,1M", "1", "VNE6236P00M049602","▼","65","36.390,94"},
            {"Inertia","81","44","71","-","-","-","-","417,22","32,93","70","27,92","34","730,7","GC032GR","-","CWCE 12,1M", "2", "VNE6236P20M049617","▼","60","23.306,85"},
            {"Acceleration style","70","47","61","-","-","-","-","625,90","24,89","114","36,67","37","959,6","6L31062","-","LICE 12.05M TER", "3", "VNE5246P60M048374","▼","61","78.577,79"},
            {"Inertia","85","27","58","-","-","-","-","81,81","26,62","71","38,50","47","1.007,6","n/a","-","CWCE 12,1M", "4", "VNE6236P20M047611","▲","44","31.016,51"},
            {"Acceleration style","91","-","-","-","-","-","-","0,09","0,19","16.667","-","99","-","-","-","BGL2 3D MH", "5", "VNE4826NX00313205","▲","91","15.946,75" } };

            Values__Ranking_Vehicles_HeavyBus Value = new Values__Ranking_Vehicles_HeavyBus(datasetVehiclesMatrix, "61", "31,01", "28,99", "811,4");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy_Ranking")]
            public void RankingVehicles() => RankingVehiclesWidgetHeavyBus(Xpath, Value, Filters);
        }

    }
}