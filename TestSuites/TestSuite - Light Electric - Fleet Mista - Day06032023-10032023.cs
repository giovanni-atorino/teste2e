using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_Light_Electric_Day
    {
        // Define query parameters used in filters
        static string frequency = "d";
        static string from_date = "1678064400000";//"1678060800000";//"1678064400000";
        static string to_date = "1678409999000";//"1678406399000"; //"1678409999000";
        static string vehicle_list = "ZCFC652C405453839-ZCFC642CX05485317-ZCFCX38E305523308";
        static string fuel_type = "3";
        static string fleet_id = "17";
        static string vehicle_type = "2";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes

        public class Score_Summary_Light_Electric_Day : Score_Summary_Widget
        {
            //Driving efficiency score (index); Driving efficiency score (kWh/h); Energy regenerated vs. used (%); Energy for climatization vs. used (%); Average recharge time (hh:mm); Average recharged energy  (kWh)
            Values__Score_Summary_Light_Electric Value = new Values__Score_Summary_Light_Electric("83", "0,30", "10,58", "0,08", "00:59", "93", "646,27", "13:26", "46,60", "5,66", "99", "3.009");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary_Light Xpath = new Xpath__Score_Summary_Light();

            [Test]
            public void ScoreSummary() => FleetManagerViewForLightElectricFleets(Xpath, Value, Filters);
        }


        public class CO2_Emissions_Light_Electric_Day : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // WEEK COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{ "1","28,3", "3", "94,21", "1" },
            //new List<string>{ "2","-","-","-","-" },
            new List<string>{ "2","131,4","2","346,67","3"},
            new List<string>{ "3","149,3", "2", "409,36", "5" },
            new List<string>{ "4", "162,5", "3", "459,24", "3" }


        };
            static string weeklyEmissionKPI = "117,9";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, weeklyEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsElectric(Xpath, Value, Filters);
        }


        public class Energy_Usage_Light_Electric_Day : Energy_usage_Widget
        {
            // KPI Fuel Consumption
            Values__Energy_Usage Value = new Values__Energy_Usage("0,30");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void EnergyUsage() => TotalEnergyUsageInformation(Xpath, Value, Filters);

        }


        public class DSE_Light_Electric_Day : DSE_Widget_Vehicles_Acceleration
        {
            //Eco Score Value, Acceleration Value, Deceleration Value, Engine Use Value,
            Values__DSE_Electric Value = new Values__DSE_Electric("83", "91", "75", "95", "98", "78", "98", "90");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE_Light Xpath = new Xpath__DSE_Light();

            [Test]
            public void DSE() => DSEkpiAnalysisElectric(Xpath, Value, Filters);

        }

        public class Monitored_Vehicles_Light_Electric_Day : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Energy usage score (index), Energy used (kWh/km), Energy regenerated vs used(%), Energy for climatization vs used(%), Average time to recharge(hh:mm)
            new List<string>{ "ZCFC642CX05485317", "100", "0,33", "54" , "-", "00:00"},
            new List<string>{ "ZCFC652C405453839 - ddddd", "96", "0,30", "32", "0", "02:35"},
            new List<string>{ "ZCFCX38E305523308 - CH 299", "-", "0,50", "-", "-", "00:00"}
        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles_Light Xpath = new Xpath__Monitored_Vehicles_Light();

            [Test]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicleElectric(Xpath, Value, Filters);
        }

        public class Ranking_Vehicles_Light_Electric_Day : Rankings_Widget
        {

            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {
            {"0,69", "0,07", "-", "0,09", "99", "8.803", "78", "91", "74", "▼", "83", "Regeneration", "98", "79", "99", "100", "0", "-", "-", "-", "5", "8", "87", "-", "-", "-", "-", "1.906,31", "5,70", "48,27", "146", "2", "ddddd", "-", "-", "16.117,80", "1", "ZCFC652C405453839", "54", "0", "0,30", "96", "445,6"},
            {"0,50", "-", "-", "0,18", "99", "150", "89", "97", "84", "▲", "86", "Regeneration", "99", "96", "99", "69", "12", "-", "-", "-", "30", "14", "56", "-", "-", "-", "-", "20,49", "4,11", "15,34", "722", "-", "-", "-", "-", "4.558,13", "2", "ZCFC642CX05485317", "65", "19", "0,33", "100", "5,3"},
            {"0,17", "-", "-", "-", "99", "73", "-", "-", "-", "=", "-", "-", "-", "-", "-", "-", "-", "-", "-","-", "22", "-", "78", "-", "-", "-", "-", "12,02", "3,32", "16,12", "175", "-", "CH 299", "-", "38S14E V", "123,47", "3", "ZCFCX38E305523308", "-", "100", "0,50", "-", "4,7"}};

            Values__Ranking_Vehicles_Light_Electric Value = new Values__Ranking_Vehicles_Light_Electric(datasetVehiclesMatrix);
            //string ecoScore, string fuelConsumption, string totalTripTime, string averageSpeed, string co2Emissions)
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking_Light Xpath = new Xpath__Ranking_Light();

            [Test]
            public void RankingVehicles() => RankingVehiclesWidgetLightElectric(Xpath, Value, Filters);
        }

    }
}