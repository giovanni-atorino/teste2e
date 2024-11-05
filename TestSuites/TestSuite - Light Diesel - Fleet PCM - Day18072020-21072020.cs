using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_Light_Diesel_PCM_Day
    {
        // Define query parameters used in filters
        static string frequency = "d";
        static string from_date = "1595023200000";//"1595030400000";//Local time
        static string to_date = "1595368799000";//"1595375999000"; //Local time
        static string vehicle_list = "ZCFC535F305303296-ZCFC735B305302706";
        static string fuel_type = "1";
        static string fleet_id = "17";
        static string vehicle_type = "2";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes

        public class Score_Summary_Light_Diesel_PCM_Day : Score_Summary_Widget
        {
            //Eco Score, Fuel Consumption, Total distance, Total trip time, trips, average speed, CO2 Emissions
            Values__Score_Summary_Light Value = new Values__Score_Summary_Light("63","10,43","243,61","04:21:04","14","55,99","66,5");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary_Light Xpath = new Xpath__Score_Summary_Light();

            [Test]
            public void ScoreSummary() => FleetManagerViewForLightFleets(Xpath, Value, Filters);
        }
        

        public class CO2_Emissions_Light_Diesel_PCM_Day : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // WEEK COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{ "1","98,7", "1", "346,92",  "6" },
            //new List<string>{ "2","-","-","-","-" },
            //new List<string>{ "3","-","-","-","-"},
            new List<string>{ "2","19,8", "1", "74,30", "1" },
            new List<string>{ "3", "46,7", "1", "169,31", "3" }


        };
            static string weeklyEmissionKPI = "33,2";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, weeklyEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsLight(Xpath, Value, Filters);
        }


        public class Fuel_Consumption_Light_Diesel_PCM_Day : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("10,43 l/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }


        public class DSE_Light_Diesel_PCM_Day : DSE_Widget_Vehicles_Acceleration
        {
            //Eco Score Value, Acceleration Value, Deceleration Value, Engine Use Value,
            Values__DSE_Light Value = new Values__DSE_Light("63","73","28","100");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE_Light Xpath = new Xpath__DSE_Light();

            [Test]
            public void DSE() => DSEkpiAnalysisLight(Xpath, Value, Filters);

        }

        public class Trip_Details_Light_Diesel_PCM_Day : Trip_Details_Widget
        {

            static string[,] datasetTripDetailsMatrix { get; set; } = new string[,] {
            {"2,89","00:29:29","00:01:52","00:02:38","00:04:25","00:29:29","59,86","FP-487-MM","-","35S16HA8 V","21-07-2020 16:14","ZCFC735B305302706","30,03","9,63","7,6"},
            {"0,51","00:08:19","00:01:48","00:02:25","00:01:13","00:08:19","33,05","FP-487-MM","-","35S16HA8 V","21-07-2020 14:57","ZCFC735B305302706","4,68","10,83","1,3"},
            {"3,44","00:18:01","00:00:22","00:00:39","00:01:41","00:18:01","93,82","FP-487-MM","-","35S16HA8 V","21-07-2020 14:36","ZCFC735B305302706","28,78","11,96","9,0"},
            {"0,94","00:16:40","00:02:20","00:03:25","00:03:11","00:16:40","38,43","FP-487-MM","-","35S16HA8 V","21-07-2020 12:31","ZCFC735B305302706","10,90","8,64","2,5"},
            {"0,42","00:05:06","00:01:03","00:01:26","00:00:40","00:05:06","28,70","FP-487-MM","-","35S16HA8 V","21-07-2020 12:15","ZCFC735B305302706","2,49","16,99","1,1"},
            {"1,12","00:14:27","00:01:04","00:01:44","00:02:30","00:14:27","41,93","FP-487-MM","-","35S16HA8 V","21-07-2020 10:00","ZCFC735B305302706","10,32","10,86","2,9"},
            {"2,54","00:19:31","00:00:30","00:01:22","00:02:39","00:19:31","78,13","FP-487-MM","-","35S16HA8 V","21-07-2020 09:26","ZCFC735B305302706","25,96","9,79","6,6"},
            {"0,73","00:09:54","00:00:19","00:00:38","00:01:59","00:09:54","45,61","FP-487-MM","-","35S16HA8 V","21-07-2020 09:14","ZCFC735B305302706","7,69","9,50","1,9"},
            {"0,65","00:10:27","00:01:52","00:02:38","00:01:26","00:12:30","37,70","FP-487-MM","-","35S16HA8 V","21-07-2020 08:45","ZCFC735B305302706","6,72","9,73","1,7"},
            {"3,62","00:21:03","00:00:19","00:00:28","00:02:36","00:21:03","87,89","FP-487-MM","-","35S16HA8 V","21-07-2020 08:15","ZCFC735B305302706","31,50","11,50","9,5"}};
            
            Values__Trip_details Value = new Values__Trip_details(datasetTripDetailsMatrix, "63", "10,43", "04:21:04", "55,99", "66,5");
            //string ecoScore, string fuelConsumption, string totalTripTime, string averageSpeed, string co2Emissions)
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Trip_Details Xpath = new Xpath__Trip_Details();

            [Test]
            public void TripDetails() => TripDetailsWidget(Xpath, Value, Filters);
        }
    }
}