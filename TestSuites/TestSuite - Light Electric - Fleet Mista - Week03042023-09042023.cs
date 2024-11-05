using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_Light_Electric_Week
    {
        // Define query parameters used in filters
        static string frequency = "w";
        static string from_date = "1684080000000";//"1680480000000";//"1684080000000";
        static string to_date = "1681088399000";//"1681084799000"; //"1681088399000";
        static string vehicle_list = "ZCFC642CX05485317-ZCFC652C405453839-ZCFCX38E305523308";
        static string fuel_type = "3";
        static string fleet_id = "17";
        static string vehicle_type = "2";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes

        public class Score_Summary_Light_Electric_Week : Score_Summary_Widget
        {
            //Driving efficiency score (index); Driving efficiency score (kWh/h); Energy regenerated vs. used (%); Energy for climatization vs. used (%); Average recharge time (hh:mm); Average recharged energy  (kWh)
            Values__Score_Summary_Light_Electric Value = new Values__Score_Summary_Light_Electric("94", "0,34", "7,70", "0,01", "01:13", "14", "69,99", "03:16", "21,16", "4,16", "99", "3.551");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary_Light Xpath = new Xpath__Score_Summary_Light();

            [Test]
            public void ScoreSummary() => FleetManagerViewForLightElectricFleets(Xpath, Value, Filters);
        }


        public class CO2_Emissions_Light_Electric_Week : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // WEEK COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{ "1","792,1","3","1.605,89","18"},
            new List<string>{ "2", "32,2","3","131,42","1"},
            new List<string>{ "3","56,5","3","209,97","3"}};

            static string weeklyEmissionKPI = "56,5";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, weeklyEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsElectric(Xpath, Value, Filters);
        }


        public class Energy_Usage_Light_Electric_Week : Energy_usage_Widget
        {
            // KPI Fuel Consumption
            Values__Energy_Usage Value = new Values__Energy_Usage("0,34");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void EnergyUsage() => TotalEnergyUsageInformation(Xpath, Value, Filters);

        }


        public class DSE_Light_Electric_Week : DSE_Widget_Vehicles_Acceleration
        {
            //Eco Score Value, Acceleration Value, Deceleration Value, Engine Use Value,
            Values__DSE_Electric Value = new Values__DSE_Electric("94","95","91","98","100","98","100","100");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE_Light Xpath = new Xpath__DSE_Light();

            [Test]
            public void DSE() => DSEkpiAnalysisElectric(Xpath, Value, Filters);

        }

        public class Monitored_Vehicles_Light_Electric_Week : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Energy usage score (index), Energy used (kWh/km), Energy regenerated vs used(%), Energy for climatization vs used(%), Average time to recharge(hh:mm)
            new List<string>{ "ZCFC642CX05485317", "98","0,33","24","-","02:26"},
            new List<string>{ "ZCFC652C405453839 - ddddd", "99","0,35","14","1","01:12"},
            new List<string>{ "ZCFCX38E305523308 - CH 299", "-","3,85","-","-","00:00"}
        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles_Light Xpath = new Xpath__Monitored_Vehicles_Light();

            [Test]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicleElectric(Xpath, Value, Filters);
        }

        public class Ranking_Vehicles_Light_Electric_Week : Rankings_Widget
        {

            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {
            {"0,41", "-", "-", "0,08", "99", "351", "91", "95", "92", "▼", "94", "Acceleration style", "100", "100", "100", "62", "38", "-", "-", "-", "6", "12", "82", "-", "-", "-", "-", "195,81", "4,06", "21,34", "309", "-", "-", "-", "-", "5.052,74", "1", "ZCFC642CX05485317", "64", "0", "0,33", "98", "51,2"},
            {"0,45", "0,19", "-", "0,05", "99", "10.228", "73", "99", "78", "=", "85", "Deceleration style", "99", "74", "99", "100", "-", "-", "-", "-", "-", "-", "100", "-", "-", "-", "-", "13,64", "5,44", "20,90", "477", "-", "ddddd", "-", "-", "18.871,02", "2", "ZCFC652C405453839", "48", "-", "0,35", "99", "3,7"},
            {"0,35", "-", "-", "-", "99", "74", "-", "-", "-", "=", "-", "-", "-", "-", "-", "-", "-", "-", "-","-", "11", "-", "89", "-", "-", "-", "-", "0,52", "3,23", "2,92", "1.154", "-", "CH 299", "-", "38S14E V", "125,58", "3", "ZCFCX38E305523308", "-", "100", "3,85", "-", "1,6",}};

            Values__Ranking_Vehicles_Light_Electric Value = new Values__Ranking_Vehicles_Light_Electric(datasetVehiclesMatrix);
            //string ecoScore, string fuelConsumption, string totalTripTime, string averageSpeed, string co2Emissions)
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking_Light Xpath = new Xpath__Ranking_Light();

            [Test]
            public void RankingVehicles() => RankingVehiclesWidgetLightElectric(Xpath, Value, Filters);
        }

    }
}