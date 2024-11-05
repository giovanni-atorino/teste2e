using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_Light_NP_PCM_Month
    {
        // Define query parameters used in filters
        static string frequency = "m";
        static string from_date = "1580511600000";//"1580515200000";//"1580511600000";//local time
        static string to_date = "1583017199000";// "1583020799000";//"1583017199000";//local time
        static string vehicle_list = "ZCFCM35A605301064-ZCFCM35A605303297-ZCFCM35A805301700-ZCFCN40A205303002";
        static string fuel_type = "2";
        static string fleet_id = "14";
        static string vehicle_type = "2";
        static string dashboard = vehicle_type + fuel_type;



        // Test classes

        public class Score_Summary_Light_NP_PCM_Month : Score_Summary_Widget
        {
            //Eco Score, Fuel Consumption, Total distance, Total trip time, trips, average speed, CO2 Emissions
            Values__Score_Summary_Light Value = new Values__Score_Summary_Light("81","7,85","318,75","06:29:45","19","49,07","64,7");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary_Light Xpath = new Xpath__Score_Summary_Light();

            [Test]
            public void ScoreSummary() => FleetManagerViewForLightFleets(Xpath, Value, Filters);
        }
        

        public class CO2_Emissions_Light_NP_PCM_Month : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // Day COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{ "1","7,2", "1", "22,95",  "2" },
            new List<string>{ "2","11,2", "2", "35,18",  "1" },
            new List<string>{ "3","36,0", "2", "172,06",  "3" },
            new List<string>{ "4","64,7", "2", "318,75",  "6" },
          
        };
            static string weeklyEmissionKPI = "64,7";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, weeklyEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsLight(Xpath, Value, Filters);
        }


        public class Fuel_Consumption_Light_NP_PCM_Month : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("7,85 kg/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }


        public class DSE_Light_NP_PCM_Month : DSE_Widget_Vehicles_Acceleration
        {
            //Eco Score Value, Acceleration Value, Deceleration Value, Engine Use Value,
            Values__DSE_Light Value = new Values__DSE_Light("81","88","45","100");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE_Light Xpath = new Xpath__DSE_Light();

            [Test]
            public void DSE() => DSEkpiAnalysisLight(Xpath, Value, Filters);

        }

        public class Trip_Details_Light_NP_PCM_Monthly : Trip_Details_Widget
        {
            static string[,] datasetTripDetailsMatrix { get; set; } = new string[,] {
                {"1,38","00:22:57","00:04:50","00:06:14","00:00:26","00:22:57","35,71","FV-835-PZ","-","40C14NA8","27-02-2020 10:52", "ZCFCN40A205303002","13,68","10,09","3,6"},
                {"-","00:01:14","00:00:33","00:00:55","00:00:00","00:01:14","5,56","FV-835-PZ",    "-","40C14NA8","26-02-2020 15:44", "ZCFCN40A205303002","0,11","-","-"},
                {"0,67","00:11:52","00:01:09","00:01:45","00:00:23","00:11:52","32,51","HDL HV480","-","35S14NA8 V","26-02-2020 09:36","ZCFCM35A605301064","6,58","10,19","1,7"},
                {"0,88","00:14:36","00:01:00","00:01:37","00:00:11","00:14:36","37,15","HDL HV480","-","35S14NA8 V","26-02-2020 08:52","ZCFCM35A605301064","9,24","9,48","2,3"},
                {"-","00:04:45","00:00:31","00:04:31","00:00:00","00:04:45","1,22","HDL HV480",    "-","35S14NA8 V","26-02-2020 08:10","ZCFCM35A605301064","0,10","-","-"},
                {"-","00:04:16","00:01:41","00:03:57","00:00:02","00:04:21","2,80","HDL HV480",    "-","35S14NA8 V","25-02-2020 15:46","ZCFCM35A605301064","0,20","-","-"},
                {"-","00:02:54","00:01:54","00:02:32","00:00:07","00:02:54","3,69","HDL HV480",    "-","35S14NA8 V","25-02-2020 15:40","ZCFCM35A605301064","0,18","-","-"},
                {"0,23","00:03:42","00:00:44","00:01:02","00:00:19","00:03:42","22,00","HDL HV480","-","35S14NA8 V","25-02-2020 15:06","ZCFCM35A605301064","1,39","16,16","0,6"},
                {"1,39","00:24:48","00:07:15","00:08:15","00:00:57","00:24:48","29,47","HDL HV480","-","35S14NA8 V","25-02-2020 14:37","ZCFCM35A605301064","12,45","11,19","3,6"},
                {"1,08","00:18:26","00:05:25","00:06:21","00:00:08","00:18:26","30,29","HDL HV480","-","35S14NA8 V","25-02-2020 14:04","ZCFCM35A605301064","9,51","11,32","2,8"}};


            Values__Trip_details Value = new Values__Trip_details(datasetTripDetailsMatrix, "81", "7,85", "06:29:45", "49,07", "64,7");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Trip_Details Xpath = new Xpath__Trip_Details();

            [Test]
            public void TripDetails() => TripDetailsWidget(Xpath, Value, Filters);
        }



    }
}