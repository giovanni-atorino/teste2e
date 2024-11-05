using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_HeavyBus_Electric_Mista_Week
    {
        // Define query parameters used in filters
        static string frequency = "w";
        static string from_date = "1685926800000"; //TEST "1685923200000"; //"1685926800000"; //local time
        static string to_date = "1686445199000"; // TEST "1686441599000";//"1686445199000"; //local time
        static string vehicle_list = "VJ14516F00N006131-VJ14516F70N006238-VJ14514F40N004062-VJ14516F10N006235";
        static string fuel_type = "3";
        static string fleet_id = "17";
        static string vehicle_type = "3";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes

        public class Score_Summary_HeavyBus_Electric_Mista_Week : Score_Summary_Widget
        {
            //Eco Score, Fuel Consumption, Total distance, Total trip time, trips, average speed, CO2 Emissions
            Values__Score_Summary_HeavyBusElectric Value = new Values__Score_Summary_HeavyBusElectric("65","0,88","323","01:04:58","03:02:25","12,37");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            public void ScoreSummary() => FleetManagerViewForHeavyBusElectricFleets(Xpath, Value, Filters);
        }

        public class Energy_Consumption_HeavyBus_Electric_Day : Energy_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Energy_Usage Value = new Values__Energy_Usage("0,88");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void EnergyConsumption() => TotalEnergyConsumptionInformation(Xpath, Value, Filters);
        }
        public class Monitored_Vehicles_HeavyBus_Electric_Week : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Energy Consumption, Energy Score, Comfort Score, SOC
            new List<string>{ "VJ14514F40N004062", "-", "-", "-" , "-"},
            new List<string>{ "VJ14516F00N006131 - FY-923-MZ", "0,88", "60", "-", "100"},
            new List<string>{ "VJ14516F10N006235", "-", "70", "-", "100"},
            new List<string>{ "VJ14516F70N006238", "-", "66", "-", "100"}};

            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles_Light Xpath = new Xpath__Monitored_Vehicles_Light();

            [Test]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicleHeavyBusElectric(Xpath, Value, Filters);
        }
        public class DSE_HeavyBus_HeavyBus_Electric_Week : DSE_Widget_Vehicles_Acceleration
        {
            //
            Values__DSE_HeavyBus Value = new Values__DSE_HeavyBus("65", "65", "39", "73", "-", "-", "-", "-");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE Xpath = new Xpath__DSE();

            [Test]
            public void DSE() => DSEkpiAnalysisHeavyBus(Xpath, Value, Filters);
        }
        public class Ranking_Vehicles_HeavyBus_Electric_Week : Rankings_Widget
        {
            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {
            {"66","37","65","-","-","-","-","Stop approach","970,00","12,37","0,88","FY-923-MZ","-","CE2Z 2D SIEMENS","106.603,00","Electric","280","1","VJ14516F00N006131","55:29","▼","60"},
            {"63","38","76","-","-","-","-","Stop approach","0,00","-","-","-","-","CE2Z 3D SIEMENS","-","Electric","308","2","VJ14516F70N006238","83:23","▼","66"},
            {"65","42","78","-","-","-","-","Stop approach","0,00","-","-","-","-","CE2Z 3D SIEMENS","-","Electric","308","3","VJ14516F10N006235","84:24","▼","70"}};

            Values__Ranking_Vehicles_Light_Electric Value = new Values__Ranking_Vehicles_Light_Electric(datasetVehiclesMatrix);
            //string ecoScore, string fuelConsumption, string totalTripTime, string averageSpeed, string co2Emissions)
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            public void RankingVehicles() => RankingVehiclesWidgetHeavyBusElectric(Xpath, Value, Filters);
        }
    }
}