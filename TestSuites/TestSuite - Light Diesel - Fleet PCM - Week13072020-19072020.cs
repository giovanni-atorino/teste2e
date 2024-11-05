using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_Light_Diesel_PCM_Week
    {
        // Define query parameters used in filters
        static string frequency = "w";
        static string from_date = "1594591200000";// "1594598400000"; //Local time
        static string to_date = "1595195999000";// "1595203199000"; //Local time
        static string vehicle_list = "ZCFC535F305303296-ZCFC735B305302706";
        static string fuel_type = "1";
        static string fleet_id = "17";
        static string vehicle_type = "2";
        static string dashboard = vehicle_type + fuel_type;

        // Test classes
        public class Score_Summary_Light_Diesel_PCM_Week : Score_Summary_Widget
        {
            //Eco Score, Fuel Consumption, Total distance, Total trip time, trips, average speed, CO2 Emissions
            Values__Score_Summary_Light Value = new Values__Score_Summary_Light("67","10,33","610,96","11:03:31","31","55,25","165,2");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary_Light Xpath = new Xpath__Score_Summary_Light();

            [Test]
            public void ScoreSummary() => FleetManagerViewForLightFleets(Xpath, Value, Filters);
        }
        

        public class CO2_Emissions_Light_Diesel_PCM_Week : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // WEEK COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{ "1", "484,3","2", "1.884,64",  "31" },
            new List<string>{ "2", "654,5", "2", "2.582,86",  "45" },
            new List<string>{ "3", "442,4","2", "1.722,42",  "29" },
            new List<string>{ "4", "760,4", "2", "2.767,49", "35" },
            new List<string>{ "5", "165,2", "1", "610,96",  "11" }
        };
            static string weeklyEmissionKPI = "165,2";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, weeklyEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsLight(Xpath, Value, Filters);
        }


        public class Fuel_Consumption_Light_Diesel_PCM_Week : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("10,33 l/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }


        public class DSE_Light_Diesel_PCM_Week : DSE_Widget_Vehicles_Acceleration
        {
            //Eco Score Value, Acceleration Value, Deceleration Value, Engine Use Value,
            Values__DSE_Light Value = new Values__DSE_Light("67","78","31","99");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE_Light Xpath = new Xpath__DSE_Light();

            [Test]
            public void DSE() => DSEkpiAnalysisLight(Xpath, Value, Filters);

           
            
        }

        public class Trip_Details_Light_Diesel_PCM_Week : Trip_Details_Widget
        {

            static string[,] datasetTripDetailsMatrix { get; set; } = new string[,] {
                   {"2,35","00:25:09","00:01:35","00:03:10","00:02:57","00:25:09","49,21","FP-487-MM","-","35S16HA8 V","17-07-2020 16:23","ZCFC735B305302706","21,07","11,15","6,1"},
                   {"0,55","00:08:57","00:01:41","00:02:40","00:01:39","00:08:57","27,53","FP-487-MM","-","35S16HA8 V","17-07-2020 16:07","ZCFC735B305302706","4,20","13,03","1,4"},
                   {"1,58","00:21:11","00:02:00","00:03:09","00:03:27","00:21:11","47,07","FP-487-MM","-","35S16HA8 V","17-07-2020 15:42","ZCFC735B305302706","16,97","9,29","4,1"},
                   {"12,75","01:18:19","00:01:53","00:02:56","00:11:45","01:18:19","80,26","FP-487-MM","-","35S16HA8 V","17-07-2020 14:17","ZCFC735B305302706","106,96","11,92","33,4"},
                   {"3,32","00:45:28","00:07:15","00:08:29","00:07:19","00:45:28","43,01","FP-487-MM","-","35S16HA8 V","17-07-2020 13:26","ZCFC735B305302706","33,27","9,97","8,7"},
                   {"9,50","00:53:06","00:02:47","00:03:36","00:05:21","00:53:06","95,93","FP-487-MM","-","35S16HA8 V","17-07-2020 12:15","ZCFC735B305302706","86,67","10,96","24,9"},
                   {"0,79","00:14:11","00:02:04","00:02:45","00:02:21","00:14:11","40,25","FP-487-MM","-","35S16HA8 V","17-07-2020 11:58","ZCFC735B305302706","9,72","8,15","2,1"},
                   {"0,44","00:07:59","00:04:21","00:04:41","00:00:50","00:07:59","18,29","FP-487-MM","-","35S16HA8 V","17-07-2020 11:43","ZCFC735B305302706","2,49","17,86","1,2"},
                   {"2,42","00:25:59","00:02:02","00:02:51","00:04:06","00:27:34","59,85","FP-487-MM","-","35S16HA8 V","17-07-2020 08:55","ZCFC735B305302706","26,47","9,13","6,3"},
                   {"0,44","00:07:44","00:00:37","00:01:33","00:01:05","00:08:25","36,18","FP-487-MM","-","35S16HA8 V","17-07-2020 08:43","ZCFC735B305302706","4,77","9,31","1,2"}
                   };

            Values__Trip_details Value = new Values__Trip_details(datasetTripDetailsMatrix, "67", "10,33", "11:03:31", "55,25", "165,2");
            //string ecoScore, string fuelConsumption, string totalTripTime, string averageSpeed, string co2Emissions)
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Trip_Details Xpath = new Xpath__Trip_Details();

            [Test]
            public void TripDetails() => TripDetailsWidget(Xpath, Value, Filters);
        }
    }
}