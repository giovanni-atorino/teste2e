using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_Heavy_Diesel_PCM_Week
    {
        // Define query parameters used in filters
        static string frequency = "w";
        static string from_date = "1589155200000";//"1589155200000";//"1589148000000";//localtime
        static string to_date = "1592179199000";//"1592179199000";// "1592171940000";//localtime
        static string vehicle_list = "WJMM62AUZ0C423627-WJMM62AUZ0C421747-WJMM62AUZ0C423759-WJMM62AVZ0C423882";
        static string fuel_type = "1";
        static string fleet_id = "11";
        static string vehicle_type = "1";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes
        public class Score_Summary_Heavy_Diesel_PCM_Week : Score_Summary_Widget
        {
            //Fuel Saving Score, Fuel Consuption, Degree Of Difficulty, Average Gross Combination Weight, Average Distance Per Unit, CO2 Emissions
            Values__Score_Summary Value = new Values__Score_Summary("70","26,67","32","28,06","4.408,36","12,3");
           Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type,dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            public void ScoreSummary() => FleetManagerViewForHeavyFleets(Xpath, Value, Filters);
        }


        public class CO2_Emissions_Heavy_Diesel_PCM_Week : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // WEEK COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{ "1","2,8","3","4.186,25","61"},
            new List<string>{ "2","4,0", "3", "5.727,90", "81" },
            new List<string>{ "3","1,3", "1", "1.922,32", "27" },
            new List<string>{ "4","2,0", "2", "2.815,27",  "39" },
            new List<string>{ "5","1,5", "2", "2.113,26",  "32" }
        };
            static string EmissionKPI = "2,3";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, EmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsHeavy(Xpath, Value, Filters);
        }


        public class Fuel_Consumption_Heavy_Diesel_PCM_Week : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("26,67 l/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }


        public class DSE_Heavy_Diesel_PCM_Week : DSE_Widget_Vehicles_Acceleration
        {
            //Fuel Saving Score Value, Acceleration Value, Deceleration Value, Engine Use Value,
            //Vehicle Care Score Value, Brake Use Value, Tyres Value, Safe Driving Score Value
            Values__DSE Value = new Values__DSE("70","80","67","63","94","88","100","92");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE Xpath = new Xpath__DSE();

            [Test]
            public void DSE() => DSEkpiAnalysisHeavy(Xpath, Value, Filters);

        }


        public class Monitored_Drivers_Heavy_Diesel_PCM_Week : Monitored_Driver_Test
        {
            static List<List<string>> driverVinList = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Vehicle Care Score, Safe Driving Score
            new List<string>{ "08:BIHV000008676001", "-", "-", "-" },
            new List<string>{ "29:000000000CAJ3000", "66", "-", "69" },
            new List<string>{ "29:0000000000X0Y002", "80", "87", "88" }
        };
            Values__Monitored_Drivers Value = new Values__Monitored_Drivers(driverVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Drivers Xpath = new Xpath__Monitored_Drivers();

            [Test]
            public void MonitoredDrivers() => AddVerifyRemoveANewDriver(Xpath, Value, Filters);
        }


        public class Monitored_Vehicles_Heavy_Diesel_PCM_Week : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Vehicle Care Score, Average total fuel consumption (l/100km), CO2 emissions (t), Safe driving score
            new List<string>{ "WJMM62AU1KC410897 - WE481VT", "-", "-", "-" , "-", "-" },
            new List<string>{ "WJME62RT3KC414126 - WZ537GA", "75", "-", "35,56" , "0,0", "-"},
            new List<string>{ "WJMM62AUZ0C423759 - B17YVE", "79", "87", "26,64", "3,5", "88"}
        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles Xpath = new Xpath__Monitored_Vehicles();

            [Test]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicle(Xpath, Value, Filters);
        }


        public class Ranking_Drivers_Heavy_Diesel_PCM_Week : Rankings_Widget
        {
            static string[,] datasetDriversMatrix { get; set; } = new string[,] {
             {"B17YVE","Test vehicle 09","26,30","7","84","-","-","5","67","-","98","0","88","0","37","4.773,39","27,31","71,14","-","Engine use","89","51","40","86","-","-","1","29:0000000000X0Y002","=","80","100","87","26,48","692,9","WJMM62AUZ0C423759"},
             {"B17YVE","Test vehicle 09","20,32","12","-","-","-","19","-","-","98","-","69","0","15","22,98","11,05","45,54","-","Acceleration style","87","45","31","69","-","-","2","29:000000000CAJ3000","=","66","100","-","20,89","546,7","WJMM62AUZ0C423759"},
             {"-","Test vehicle 07","26,82","7","91","100","!","7","63","63","-","1","95","0","33","8.624,97","29,65","68,39","-","Acceleration style","75","77","73","77","-","-","3","29:0000000002F6S002","▲","65","42","97","27,04","707,6","WJMM62AUZ0C423627"},
             {"-","Test vehicle 07","17,77","10","-","100","OK","9","11","11","-","-","52","0","20","247,94","9,59","60,17","-","Acceleration style","80","35","20","66","-","-","4","29:0000000002OB6001","=","63","58","100","18,05","472,3","WJMM62AUZ0C423627"}};
                


            // Ranking Matrix, Fuel Saving Score, Average Total Fuel, Degree Of Difficulty, CO2 Emissions, Vehicle care
            Values__Ranking_Drivers Value = new Values__Ranking_Drivers(datasetDriversMatrix, "70", "26,67", "34", "697,9", "94");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy")]
            public void RankingDrivers() => RankingDriversWidget(Xpath, Value, Filters);
        }

        public class Ranking_Vehicle_Heavy_Diesel_PCM_Week : Rankings_Widget
        {
            static string[,] datasetDriversMatrix { get; set; } = new string[,] {
           {"74","100","OK","5","54","54","98","0","2.831,94","26,38","67,33","-","Acceleration style","82","45","31","85","100","24,54","7","B13YVE","Test vehicle 10","AS440S51T/P","13.442,00","24,74","▼","70","24","90","647,4","1","WJMM62AVZ0C423882"},
           {"-","100","OK","4","-","-","98","-","13,62","10,74","17,34","-","Acceleration style","100","45","19","74","100","20,91","52","B25YVE","Test vehicle 08","AS440S48T/P","574,90","26,59","=","75","8","100","695,8","2","WJMM62AUZ0C421747"},
           {"84","-","-","5","66","-","98","0","4.954,44","27,17","70,74","-","Engine use","89","51","40","85","100","26,46","7","B17YVE","Test vehicle 09","AS440S48T/P","14.328,67","26,64","=","79","37","87","697,2","3","WJMM62AUZ0C423759"},
           {"91","100","!","7","62","62","-","1","9.833,42","29,09","68,13","-","Acceleration style","76","76","72","76","43","27,04","7","-","Test vehicle 07","AS440S48T/P","13.451,54","27,24","▲","65","33","97","712,8","4","WJMM62AUZ0C423627"}};



            // Ranking Matrix, Fuel Saving Score, Average Total Fuel, Degree Of Difficulty, CO2 Emissions, Vehicle care
            Values__Ranking_Vehicles Value = new Values__Ranking_Vehicles(datasetDriversMatrix, "70", "26,67", "32", "697,9", "93");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy")]
            public void RankingVehicles() => RankingVehiclesWidget(Xpath, Value, Filters);
        }
    }
}
