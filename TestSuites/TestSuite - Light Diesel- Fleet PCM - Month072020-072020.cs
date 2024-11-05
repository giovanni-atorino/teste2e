using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_Light_Diesel_PCM_Month
    {
        // Define query parameters used in filters
        static string frequency = "m";
        static string from_date = "1593554400000";// "1593561600000";//"1593554400000";//local time
        static string to_date = "1596232799000"; //"1596239999000";//"1596232799000"; //local time
        static string vehicle_list = "ZCFC535F305303296-ZCFC735B305302706";
        static string fuel_type = "1";
        static string fleet_id = "17";
        static string vehicle_type = "2";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes

        public class Score_Summary_Light_Diesel_PCM_Month : Score_Summary_Widget
        {
            //Eco Score, Fuel Consumption, Total distance, Total trip time, trips, average speed, CO2 Emissions
            Values__Score_Summary_Light Value = new Values__Score_Summary_Light("70","10,24","9.035,03","05:11:35","224","68,66","2.421,5");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary_Light Xpath = new Xpath__Score_Summary_Light();

            [Test]
            public void ScoreSummary() => FleetManagerViewForLightFleets(Xpath, Value, Filters);
        }
        

        public class CO2_Emissions_Light_Diesel_PCM_Month : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // Day COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{ "1", "15,9", "2", "51,80",  "2" },
            new List<string>{ "2", "1.568,0", "2", "5.760,99",  "85" },
            new List<string>{ "3", "1.166,6", "1", "4.254,99",  "66" },
            new List<string>{ "4", "2.230,9", "2", "8.573,05","141" },
            new List<string>{ "5", "2.421,5", "2", "9.035,03",  "132" },


          

        };
            static string weeklyEmissionKPI = "2.421,5";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, weeklyEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsLight(Xpath, Value, Filters);
        }


        public class Fuel_Consumption_Light_Diesel_PCM_Month : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("10,24 l/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }


        public class DSE_Light_Diesel_PCM_Month : DSE_Widget_Vehicles_Acceleration
        {
            //Eco Score Value, Acceleration Value, Deceleration Value, Engine Use Value,
            Values__DSE_Light Value = new Values__DSE_Light("70","76","37","95");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE_Light Xpath = new Xpath__DSE_Light();

            [Test]
            public void DSE() => DSEkpiAnalysisLight(Xpath, Value, Filters);


        }

        public class Trip_Details_Light_Diesel_PCM_Monthly : Trip_Details_Widget
        {

                static string[,] datasetTripDetailsMatrix { get; set; } = new string[,] {
                {"7,10","01:09:03","00:05:49","00:07:18","00:15:28","01:09:03","58,45","FP-487-MM","-","35S16HA8 V","31-07-2020 13:13","ZCFC735B305302706","68,67","10,33","18,6"},
                {"7,65","00:58:05","00:03:18","00:04:22","00:09:22","00:58:05","63,92","FP-487-MM","-","35S16HA8 V","31-07-2020 11:13","ZCFC735B305302706","63,17","12,12","20,0"},
                {"0,66","00:07:54","00:01:14","00:01:35","00:02:05","00:07:54","43,06","FP-487-MM","-","35S16HA8 V","31-07-2020 10:20","ZCFC735B305302706","5,80","11,30","1,7"},
                {"2,80","00:25:11","00:02:07","00:02:44","00:04:11","00:25:11","55,17","FP-487-MM","-","35S16HA8 V","31-07-2020 09:48","ZCFC735B305302706","23,65","11,86","7,3"},
                {"5,07","00:28:03","00:01:29","00:02:00","00:02:39","00:28:03","85,70","FP-487-MM","-","35S16HA8 V","31-07-2020 08:27","ZCFC735B305302706","40,92","12,39","13,3"},
                {"1,06","00:15:34","00:03:08","00:03:58","00:02:07","00:15:34","31,89","FP-487-MM","-","35S16HA8 V","31-07-2020 08:07","ZCFC735B305302706","8,46","12,55","2,8"},
                {"1,28","00:12:31","00:00:18","00:00:57","00:01:46","00:12:31","56,52","FP-487-MM","-","35S16HA8 V","31-07-2020 07:45","ZCFC735B305302706","12,05","10,63","3,4"},
                {"0,10","00:02:14","00:00:54","00:01:14","00:00:18","00:02:14","20,79","FQ-109-DK","-","35S21HA8 V","31-07-2020 06:14","ZCFC535F305303296","0,77","12,53","0,3"},
                {"4,29","00:43:23","00:04:23","00:05:51","00:06:00","00:43:23","58,67","FP-487-MM","-","35S16HA8 V","31-07-2020 06:01","ZCFC735B305302706","43,31","9,91","11,2"},
                {"0,41","00:07:50","00:00:46","00:01:26","00:01:33","00:07:50","26,05","FQ-109-DK","-","35S21HA8 V","30-07-2020 16:49","ZCFC535F305303296","3,48","11,86","1,1"}};

                Values__Trip_details Value = new Values__Trip_details(datasetTripDetailsMatrix, "70", "10,24", "05:11:35", "68,66", "2.421,5");
                Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
                Xpath__Trip_Details Xpath = new Xpath__Trip_Details();

                [Test]
                public void TripDetails() => TripDetailsWidget(Xpath, Value, Filters);
            }
        }
    }
