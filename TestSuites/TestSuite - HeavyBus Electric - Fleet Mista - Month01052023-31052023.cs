using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_HeavyBus_Electric_Mista_Month
    {
        // Define query parameters used in filters
        static string frequency = "d";
        static string from_date = "1682902800000"; //TEST "1682899200000"; //"1682902800000"; //local time
        static string to_date = "1685581199000"; // TEST "1685577599000";//"1685581199000"; //local time
        static string vehicle_list = "VJ14514F00N004043-VJ14516F10N006235-VJ14516F10N006297-VJ14515F70N004054";
        static string fuel_type = "3";
        static string fleet_id = "17";
        static string vehicle_type = "3";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes

        public class Score_Summary_HeavyBus_Electric_Mista_Month : Score_Summary_Widget
        {
            //Eco Score, Fuel Consumption, Total distance, Total trip time, trips, average speed, CO2 Emissions
            Values__Score_Summary_HeavyBusElectric Value = new Values__Score_Summary_HeavyBusElectric("67","3,01","2.762","02:16:05","04:12:16","30,07");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            public void ScoreSummary() => FleetManagerViewForHeavyBusElectricFleets(Xpath, Value, Filters);
        }

        public class Energy_Consumption_HeavyBus_Electric_Day : Energy_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Energy_Usage Value = new Values__Energy_Usage("3,01");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void EnergyConsumption() => TotalEnergyConsumptionInformation(Xpath, Value, Filters);
        }
        public class Monitored_Vehicles_HeavyBus_Electric_Month : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Energy Consumption, Energy Score, Comfort Score, SOC
            new List<string>{ "VJ14514F00N004043 - GG186XZ - Test", "8,39", "78", "-" , "43"},
            new List<string>{ "VJ14515F70N004054 - 2253LSB", "-", "-", "-", "-"},
            new List<string>{ "VJ14516F10N006235", "0,92", "68", "-", "91"},
            new List<string>{ "VJ14516F10N006297 - GB-578-AG", "0,91", "65", "-", "30"}};

            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles_Light Xpath = new Xpath__Monitored_Vehicles_Light();

            [Test]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicleHeavyBusElectric(Xpath, Value, Filters);
        }
        public class DSE_HeavyBus_HeavyBus_Electric_Month : DSE_Widget_Vehicles_Acceleration
        {
            //
            Values__DSE_HeavyBus Value = new Values__DSE_HeavyBus("67", "65", "43", "76", "-", "-", "-", "-");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE Xpath = new Xpath__DSE();

            [Test]
            public void DSE() => DSEkpiAnalysisHeavyBus(Xpath, Value, Filters);
        }
        public class Ranking_Vehicles_HeavyBus_Electric_Month : Rankings_Widget
        {
            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {
            {"63","42","75","-","-","-","-","Stop approach","5.025,00","30,07","0,91","GB-578-AG","-","CE2Z 3D SIEMENS","77.492,00","Electric","280","1","VJ14516F10N006297","111:02","=","65",},
            {"61", "44", "78", "-", "-", "-", "-", "Stop approach", "930,00", "29,90", "0,92", "-", "-", "CE2Z 3D SIEMENS", "53.256,00", "Electric", "308", "2", "VJ14516F10N006235", "120:47", "▼", "68"},
            {"88", "45", "72", "-", "-", "-", "-", "Stop approach", "2.330,00", "30,12", "8,39", "GG186XZ", "Test", "-BUSXTRA IVECO", "27.165,00", "Electric", "196", "3", "VJ14514F00N004043", "93:00", "=", "78"}};

            Values__Ranking_Vehicles_Light_Electric Value = new Values__Ranking_Vehicles_Light_Electric(datasetVehiclesMatrix);
            //string ecoScore, string fuelConsumption, string totalTripTime, string averageSpeed, string co2Emissions)
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            public void RankingVehicles() => RankingVehiclesWidgetHeavyBusElectric(Xpath, Value, Filters);
        }

    }
}