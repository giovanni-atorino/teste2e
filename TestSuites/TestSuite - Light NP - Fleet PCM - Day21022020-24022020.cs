using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_Light_NP_PCM_Day
    {
        // Define query parameters used in filters
        static string frequency = "d";
        static string from_date = "1582239600000";//"1582243200000";
        static string to_date = "1582585199000";//"1582588799000";
        static string vehicle_list = "ZCFCM35A605301064;ZCFCM35A605303297;ZCFCM35A805301700;ZCFCN40A205303002";
        static string fuel_type = "2";
        static string fleet_id = "14";
        static string vehicle_type = "2";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes

        public class Score_Summary_Light_NP_PCM_Day : Score_Summary_Widget
        {
            //Eco Score, Fuel Consumption, Total distance, Total trip time, trips, average speed, CO2 Emissions
            Values__Score_Summary_Light Value = new Values__Score_Summary_Light("87","6,93","249,44","04:08:18","7","60,28","44,8");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type,dashboard);
            Xpath__Score_Summary_Light Xpath = new Xpath__Score_Summary_Light();

            [Test]
            public void ScoreSummary() => FleetManagerViewForLightFleets(Xpath, Value, Filters);
        }
        

        public class CO2_Emissions_Light_NP_PCM_Day : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // DAY COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{ "1",  "5,3", "2", "15,84","1"},
            new List<string>{ "2",  "19,8", "2", "102,77","2"},
            //new List<string>{ "3","-","-", "-", "-"},
            //new List<string>{ "4","-","-", "-", "-"},
            new List<string>{ "3","25,0", "1", "146,67","2"}
        };
            static string weeklyEmissionKPI = "22,4";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, weeklyEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsLight(Xpath, Value, Filters);
        }


        public class Fuel_Consumption_Light_NP_PCM_Day : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("6,93 kg/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }


        public class DSE_Light_NP_PCM_Day : DSE_Widget_Vehicles_Acceleration
        {
            //Eco Score Value, Acceleration Value, Deceleration Value, Engine Use Value,
            Values__DSE_Light Value = new Values__DSE_Light("87","88","51","100");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE_Light Xpath = new Xpath__DSE_Light();

            [Test]
            public void DSE() => DSEkpiAnalysisLight(Xpath, Value, Filters);

        }
        public class Trip_Details_Light_NP_PCM_Day : Trip_Details_Widget
        {

            static string[,] datasetTripDetailsMatrix { get; set; } = new string[,] {
            {"-","00:01:50","00:01:02","00:01:23","00:00:06","00:01:50","5,76","HDL HV480",    "-","35S14NA8 V","24-02-2020 09:27","ZCFCM35A605301064","0,18","-","-"},
            {"0,85","00:22:02","00:02:38","00:06:12","00:00:34","00:22:04","21,99","HDL HV480","-","35S14NA8 V","24-02-2020 08:10","ZCFCM35A605301064","8,27","10,27","2,2"},
            {"8,78","01:59:32","00:10:41","00:13:35","00:00:34","01:59:43","67,82","HDL HV480","-","35S14NA8 V","24-02-2020 05:59","ZCFCM35A605301064","138,21","6,35","22,8"},
            {"7,26","01:28:35","00:09:16","00:12:29","00:00:21","01:28:41","66,39","HDL HV480","-","35S14NA8 V","21-02-2020 11:11","ZCFCM35A605301064","100,22","7,25","18,9"},
            {"0,14","00:02:41","00:00:29","00:00:47","00:00:05","00:02:41","22,69","HDL HV480","-","35S14NA8 V","21-02-2020 07:49","ZCFCM35A605301064","1,05","13,39","0,4"},
            {"0,20","00:04:56","00:02:39","00:03:24","00:00:02","00:04:57","8,90","HDL HV480", "-","35S14NA8 V","21-02-2020 07:28","ZCFCM35A605301064","0,75","26,61","0,5"},
            {"-","00:08:22","00:04:26","00:06:20","00:00:01","00:08:22","5,34","FV-835-PZ",    "-","40C14NA8","21-02-2020 07:14"  ,"ZCFCN40A205303002","0,75","-","-"}
            };

            Values__Trip_details Value = new Values__Trip_details(datasetTripDetailsMatrix, "87", "6,93", "04:08:18", "60,28", "44,8");
            //string ecoScore, string fuelConsumption, string totalTripTime, string averageSpeed, string co2Emissions)
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Trip_Details Xpath = new Xpath__Trip_Details();

            [Test]
            public void TripDetails() => TripDetailsWidget(Xpath, Value, Filters);
        }
    }
}