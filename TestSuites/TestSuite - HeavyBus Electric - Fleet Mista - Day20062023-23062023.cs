using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_HeavyBus_Electric_Mista_Day
    {
        // Define query parameters used in filters
        static string frequency = "d";
        static string from_date = "1687222800000"; //TEST "1687219200000"; //"1687222800000"; //local time
        static string to_date = "1687568399000"; // TEST "1687564799000";//"1687568399000"; //local time
        static string vehicle_list = "VJ14515F60N004126-VJ14515F80N004127-VJ14514F80N004064-VJ14515F70N004054";
        static string fuel_type = "3";
        static string fleet_id = "17";
        static string vehicle_type = "3";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes

        public class Score_Summary_HeavyBus_Electric_Mista_Day : Score_Summary_Widget
        {
            //Eco Score, Fuel Consumption, Total distance, Total trip time, trips, average speed, CO2 Emissions
            Values__Score_Summary_HeavyBusElectric Value = new Values__Score_Summary_HeavyBusElectric("67","0,69","465","07:33","22:56","15,44");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            public void ScoreSummary() => FleetManagerViewForHeavyBusElectricFleets(Xpath, Value, Filters);
        }
        public class Energy_Consumption_HeavyBus_Electric_Day : Energy_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Energy_Usage Value = new Values__Energy_Usage("0,69");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void EnergyConsumption() => TotalEnergyConsumptionInformation(Xpath, Value, Filters);

        }
        public class Monitored_Vehicles_HeavyBus_Electric_Day : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Energy Consumption, Energy Score, Comfort Score, SOC
            new List<string>{ "VJ14515F60N004126 - GE-687-GE", "0,67", "65", "-" , "89"},
            new List<string>{ "VJ14515F80N004127 - GE-793-GE", "0,70", "69", "-", "71"},
            new List<string>{ "VJ14514F80N00406", "0,69", "69", "-", "83"},
            new List<string>{ "VJ14515F70N004054 - 2253LSB", "0,75", "64", "-", "77"}};

            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles_Light Xpath = new Xpath__Monitored_Vehicles_Light();

            [Test]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicleHeavyBusElectric(Xpath, Value, Filters);
        }      
        public class DSE_HeavyBus_HeavyBus_Electric_Day : DSE_Widget_Vehicles_Acceleration
        {
            //
            Values__DSE_HeavyBus Value = new Values__DSE_HeavyBus("67", "76", "47", "70", "-", "-", "-", "-");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE Xpath = new Xpath__DSE();

            [Test]
            public void DSE() => DSEkpiAnalysisHeavyBus(Xpath, Value, Filters);
        }
        public class Ranking_Vehicles_HeavyBus_Electric_Day : Rankings_Widget
        {
            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {
            {"77","44","68","-","-","-","-","Stop approach","926,00","14,49","0,67","GE-687-GE","-","-BUSXTRA IVECO","61.484,00","Electric","252","1","VJ14515F60N004126","46:28","▼","65"},
            {"73","51","81","-","-","-","-","Stop approach","37,00","12,77","0,69","-","-","-BUSXTRA IVECO","18.844,00","Electric","196","2","VJ14514F80N004064","01:59","=","69"},
            {"74","50","74","-","-","-","-","Stop approach","843,00","16,14","0,70","GE-793-GE","-","-BUSXTRA IVECO","47.151,00","Electric","252","3","VJ14515F80N004127","41:57","▼","69"},
            {"82","52","51","-","-","-","-","-","53,00","39,71","0,75","2253LSB","-","-BUSXTRA IVECO","11.519,00","Electric","280","4","VJ14515F70N004054","01:19","=","64"}};

            Values__Ranking_Vehicles_Light_Electric Value = new Values__Ranking_Vehicles_Light_Electric(datasetVehiclesMatrix);
            //string ecoScore, string fuelConsumption, string totalTripTime, string averageSpeed, string co2Emissions)
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            public void RankingVehicles() => RankingVehiclesWidgetHeavyBusElectric(Xpath, Value, Filters);
        }
    }
}