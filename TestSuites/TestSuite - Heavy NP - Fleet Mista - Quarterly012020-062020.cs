using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_Heavy_NP_Mista_Quarter
    {   // Define query parameters used in filters

        static string frequency = "q";
        static string from_date = "1577836800000";// "1577833200000";  //"1577836800000";//GMT
        static string to_date = "1593561599000";//"1593554399000";// "1593561599000";//GMT
        static string vehicle_list = "WJMM62AT7KC409938-WJMM62AT2KC410057-WJMM62ATXKC409934-WJMMG2ATZLC430309-WJMMG2ATZLC430308";
        static string fuel_type = "2";
        static string fleet_id = "13";
        static string vehicle_type = "1";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes
        public class Score_Summary_Heavy_NP_Mista_Quarterly : Score_Summary_Widget
        {
            //Fuel Saving Score, Fuel Consuption, Degree Of Difficulty, Average Gross Combination Weight, Average Distance Per Unit, CO2 Emissions
            Values__Score_Summary Value = new Values__Score_Summary("89","22,78","39","22,80","13.522,22","42,7");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            public void ScoreSummary() => FleetManagerViewForHeavyFleets(Xpath, Value, Filters);
        }


        public class CO2_Emissions_Heavy_NP_Mista_Quarterly : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            //month COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{"1", "38,7", "3", "58.035,36", "852"},
            new List<string>{"2", "27,9", "3", "42.214,97",  "628"},
            new List<string>{"3", "64,4", "3", "95.042,30",  "1.301"},
            new List<string>{"4", "30,7", "3", "46.839,68", "617" },
            new List<string>{"5","11,9", "2", "20.771,42", "278" }
        };
            static string EmissionKPI = "21,3";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist,EmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsHeavy(Xpath, Value, Filters);
        }


        public class Fuel_Consumption_Heavy_NP_Mista_Quarterly : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("22,78 kg/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }


        public class DSE_Heavy_NP_Mista_Quarterly : DSE_Widget_Vehicles_Acceleration
        {
            //Fuel Saving Score Value, Acceleration Value, Deceleration Value, Engine Use Value,
            //Vehicle Care Score Value, Brake Use Value, Tyres Value, Safe Driving Score Value
            Values__DSE Value = new Values__DSE("89", "96", "88", "92", "76", "67", "100", "87");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE Xpath = new Xpath__DSE();

            [Test]
            public void DSE() => DSEkpiAnalysisHeavy(Xpath, Value, Filters);

        }


        public class Monitored_Drivers_Heavy_NP_Mista_Quarterly : Monitored_Driver_Test
        {
            static List<List<string>> driverVinList = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Vehicle Care Score, Safe Driving Score
            new List<string>{ "28:1840724101740001", "90", "99", "88" },
            new List<string>{ "28:1940331036720000", "90", "100", "88" },
            new List<string>{ "28:1531018021980002", "97", "97", "97" }
        };
            Values__Monitored_Drivers Value = new Values__Monitored_Drivers(driverVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Drivers Xpath = new Xpath__Monitored_Drivers();

            [Test]
            public void MonitoredDrivers() => AddVerifyRemoveANewDriver(Xpath, Value, Filters);
        }


        public class Monitored_Vehicles_Heavy_NP_Mista_Quarterly : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Vehicle Care Score, Average total fuel consumption (/100km), CO2 emissions (t), Safe driving score
            new List<string>{ "WJMM62AT7KC409938 - DSR58613", "92", "63", "24,20" , "11,4", "-" },
            new List<string>{ "WJMM62AT2KC410057 - DJA23051", "88", "53", "24,99" , "7,9", "-"},
            new List<string>{ "WJMMG2ATZLC430309 - WE080YU", "77", "99", "20,65", "6,8", "88"}
        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles Xpath = new Xpath__Monitored_Vehicles();

            [Test]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicle(Xpath, Value, Filters);
        }



        public class Ranking_Drivers_Heavy_NP_Mista_Quarterly : Rankings_Widget
        {
            static string[,] datasetDriversMatrix { get; set; } = new string[,] {
            {"PZ679WR","Test vehicle 12","28,25","2","96","100","OK","13","6","6","98","-","97","0","28","141,25","34,69","58,85","-","Inertia","98","96","99","85","-","-","1","28:1531018021980002","=","97","100","97","28,35","785,4","WJMMG2ATZLC430308"},
            {"DSR58613","Test vehicle 04","24,39","5","67","-","OK","15","1","-","-","-","-","0","29","320,71","20,02","60,51","-","Stop approach","94","96","95","91","-","-","2","PL 1921103090300000","=","96","-","67","24,63","682,3","WJMM62AT7KC409938"},
            {"DSR58613","Test vehicle 04","22,14","3","96","-","OK","7","1","-","-","-","-","0","36","4.058,24","22,39","74,70","-","Acceleration style","98","95","96","78","-","-","3","PL 1740207058300002","▼","95","-","96","22,25","616,4","WJMM62AT7KC409938"},
            {"DSR58613","Test vehicle 04","25,55","1","66","-","OK","3","1","-","-","-","-","0","61","680,66","38,18","80,19","-","Acceleration style","98","95","93","77","-","-","4","PL 1800808117580000","=","95","-","66","25,56","708,1","WJMM62AT7KC409938"},
            {"DSR58613","Test vehicle 04","21,52","1","55","-","OK","4","1","-","-","-","-","0","32","1.518,66","20,48","76,43","-","Acceleration style","99","94","79","87","-","-","5","UA UAD0000005JWH000","=","94","-","55","21,57","597,4","WJMM62AT7KC409938"},
            {"DJA23848","Test vehicle 06","21,40","3","56","-","!","5","1","-","-","-","-","0","34","5.579,56","20,95","74,06","-","Acceleration style","98","94","87","69","-","-","6","PL 1900304077330001","=","94","-","56","21,51","595,7","WJMM62ATXKC409934"},
            {"DJA23848","Test vehicle 06","22,65","2","74","-","!","4","1","-","-","-","-","1","44","783,22","26,89","75,39","-","Acceleration style","97","94","94","59","-","-","7","PL 1930130009700001","=","94","100","74","22,73","629,5","WJMM62ATXKC409934"},
            {"DSR58613","Test vehicle 04","25,08","3","52","-","OK","3","1","-","-","-","-","0","59","3.749,69","36,61","78,16","-","Acceleration style","97","93","86","79","-","-","8","PL 1680929132970002","=","93","100","52","25,19","697,7","WJMM62AT7KC409938"},
            {"DJA23848","Test vehicle 06","24,97","5","49","-","OK","5","1","-","-","-","-","0","46","131,00","30,31","65,76","-","Stop approach","99","92","77","91","-","-","9","PL 1850914060300000","=","92","-","49","25,19","697,8","WJMM62ATXKC409934"},
            {"DJA23848","Test vehicle 06","23,71","2","-","-","!","7","1","-","-","-","-","0","28","157,65","18,99","71,47","-","Acceleration style","99","92","72","77","-","-","10","PL 1830613027730001","=","92","-","-","23,79","658,9","WJMM62ATXKC409934"}};
                

            // Ranking Matrix, Fuel Saving Score, Average Total Fuel, Degree Of Difficulty, CO2 Emissions, Vehicle care
            Values__Ranking_Drivers Value = new Values__Ranking_Drivers(datasetDriversMatrix, "89", "22,45", "40", "621,7", "76");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy")]
            public void RankingDrivers() => RankingDriversWidget(Xpath, Value, Filters);
        }



        public class Ranking_Vehicles_Heavy_NP_Mista_Quarterly : Rankings_Widget
        {
            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {
            {"90","100","!!","7","70","70","61","0","11.912,00","19,76","73,25","-","Engine use","94","78","72","91","76","20,48","4","WE080YU","Test vehicle 11","AS440S46T/P 2LNG","13.322,13","20,65","=","77","50","99","571,9","1","WJMMG2ATZLC430309"},
            {"76","100","OK","8","31","31","85","0","8.859,41","18,20","66,03","-","Acceleration style","86","71","62","84","91","20,58","8","PZ679WR","Test vehicle 12","AS440S46T/P 2LNG","8.935,75","20,88","=","81","19","94","578,4","2","WJMMG2ATZLC430308"},
            {"67","-","!","6","1","-","-","-","18.408,47","21,14","72,93","-","Acceleration style","98","92","81","70","100","22,28","3","DJA23848","Test vehicle 06","AS440S46T/FP LT LNG","77.094,65","22,38","▼","92","34","67","620,0","3","WJMM62ATXKC409934"},
            {"63","-","OK","5","1","-","-","-","16.968,35","28,73","75,66","-","Acceleration style","98","92","83","79","100","24,08","3","DSR58613","Test vehicle 04","AS440S46T/P LNG","82.887,85","24,20","▲","92","46","63","670,2","4","WJMM62AT7KC409938"},
            {"53","-","OK","4","0","-","-","-","11.462,86","22,88","74,81","-","Acceleration style","96","88","62","75","100","24,84","4","DJA23051","Test vehicle 05","AS440S46T/FP LT LNG","82.234,85","24,99","▼","88","40","53","692,1","5","WJMM62AT2KC410057"}};
            Values__Ranking_Vehicles Value = new Values__Ranking_Vehicles(datasetVehiclesMatrix, "87", "22,78", "39", "630,9", "78");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy")]
            public void RankingVehicles() => RankingVehiclesWidget(Xpath, Value, Filters);
        }
    }
}
