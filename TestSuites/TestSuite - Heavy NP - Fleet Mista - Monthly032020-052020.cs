using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_Heavy_NP_Mista_Monthly
    {   // Define query parameters used in filters

        static string frequency = "m";
        static string from_date = "1583103600000"; //"1583020800000"; //"1583103600000"; //local time
        static string to_date = "1590962399000"; // "1590969599000";//"1590962399000"; //local time
        static string vehicle_list = "WJMM62AT7KC409938-WJMM62AT2KC410057-WJMM62ATXKC409934-WJMMG2ATZLC430309-WJMMG2ATZLC430308";
        static string fuel_type = "2";
        static string fleet_id = "13";
        static string vehicle_type = "1";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes
        public class Score_Summary_Heavy_NP_Mista_Monthly : Score_Summary_Widget
        {
            //Fuel Saving Score, Fuel Consuption, Degree Of Difficulty, Average Gross Combination Weight, Average Distance Per Unit, CO2 Emissions
            Values__Score_Summary Value = new Values__Score_Summary("88","21,80","35","19,09","5.542,72","13,4");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            public void ScoreSummary() => FleetManagerViewForHeavyFleets(Xpath, Value, Filters);
        }


        public class CO2_Emissions_Heavy_NP_Mista_Monthly : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            //month COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{"1", "8,4", "2", "12.110,69", "159"},
            new List<string>{"2", "12,7", "3", "19.446,99",  "257"},
            new List<string>{"3", "9,5", "2", "15.264,58",  "200"},
            new List<string>{"4","3,9", "2", "6.906,29", "94" }
        };
            static string EmissionKPI = "6,7";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist,EmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsHeavy(Xpath, Value, Filters);
        }


        public class Fuel_Consumption_Heavy_NP_Mista_Monthly : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("21,80 kg/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }


        public class DSE_Heavy_NP_Mista_Monthly : DSE_Widget_Vehicles_Acceleration
        {
            //Fuel Saving Score Value, Acceleration Value, Deceleration Value, Engine Use Value,
            //Vehicle Care Score Value, Brake Use Value, Tyres Value, Safe Driving Score Value
            Values__DSE Value = new Values__DSE("88", "95", "86", "100", "67", "52", "100", "94");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE Xpath = new Xpath__DSE();

            [Test]
            public void DSE() => DSEkpiAnalysisHeavy(Xpath, Value, Filters);

        }


        public class Monitored_Drivers_Heavy_NP_Mista_Monthly : Monitored_Driver_Test
        {
            static List<List<string>> driverVinList = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Vehicle Care Score, Safe Driving Score
            new List<string>{ "28:1940331036720000", "-", "-", "-" },
            new List<string>{ "28:1840724101740001", "-", "-", "-" },
            new List<string>{ "28:1531018021980002", "-", "-", "-" }
        };
            Values__Monitored_Drivers Value = new Values__Monitored_Drivers(driverVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Drivers Xpath = new Xpath__Monitored_Drivers();

            [Test]
            public void MonitoredDrivers() => AddVerifyRemoveANewDriver(Xpath, Value, Filters);
        }


        public class Monitored_Vehicles_Heavy_NP_Mista_Monthly : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Vehicle Care Score, Average total fuel consumption (/100km), CO2 emissions (t), Safe driving score
            new List<string>{ "WJMM62AT7KC409938 - DSR58613", "-", "-", "-" , "-", "-" },
            new List<string>{ "WJMM62AT2KC410057 - DJA23051", "86", "39", "24,18" , "4,7", "-"},
            new List<string>{ "WJMMG2ATZLC430309 - WE080YU", "51", "96", "21,31", "2,0", "93"}
        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles Xpath = new Xpath__Monitored_Vehicles();

            [Test]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicle(Xpath, Value, Filters);
        }



        public class Ranking_Drivers_Heavy_NP_Mista_Monthly : Rankings_Widget
        {
            static string[,] datasetDriversMatrix { get; set; } = new string[,] {
            {"DJA23848","Test vehicle 06","22,55","2","74","-","!","3","1","-","-","-","-","1","44","764,75","27,12","76,64","-","Acceleration style","97","94","94","58","-","-","1","PL 1930130009700001","=","94","100","74","22,62","626,6","WJMM62ATXKC409934"},
            {"DJA23848","Test vehicle 06","20,01","3","55","-","!","4","1","-","-","-","-","0","30","3.682,20","18,50","74,90","-","Acceleration style","99","93","87","65","-","-","2","PL 1900304077330001","=","93","-","55","20,11","557,1","WJMM62ATXKC409934"},
            {"DJA23848","Test vehicle 06","24,97","5","49","-","OK","5","1","-","-","-","-","0","46","131,00","30,31","65,76","-","Stop approach","99","92","77","91","-","-","3","PL 1850914060300000","=","92","-","49","25,19","697,8","WJMM62ATXKC409934"},
            {"DJA23848","Test vehicle 06","19,80","3","-","-","!","6","1","-","-","-","-","0","29","2.715,55","17,95","74,16","-","Acceleration style","98","90","75","69","-","-","4","PL 1840803109960001","▼","90","-","-","19,89","550,8","WJMM62ATXKC409934"},
            {"DJA23051","Test vehicle 05","27,97","11","65","-","OK","8","1","-","-","-","-","0","45","239,82","29,67","56,95","-","Acceleration style","96","88","71","79","-","-","5","PL 1821003051350001","=","88","-","65","28,56","791,2","WJMM62AT2KC410057"},
            {"DJA23848","Test vehicle 06","21,30","3","-","-","OK","4","1","-","-","-","-","0","26","217,15","17,76","73,67","-","Stop approach","99","86","65","86","-","-","6","PL 1911121000520000","▼","86","-","-","21,41","593,2","WJMM62ATXKC409934"},
            {"DJA23051","Test vehicle 05","22,61","4","38","-","OK","4","0","-","-","-","-","0","40","6.177,14","21,68","75,84","-","Acceleration style","96","86","50","75","-","-","7","I  I-00000688730011","=","86","100","38","22,75","630,0","WJMM62AT2KC410057"},
            {"DJA23848","Test vehicle 06","24,60","2","-","-","OK","5","1","-","-","-","-","0","29","218,85","19,16","73,67","-","Acceleration style","99","84","41","66","-","-","8","PL 1950908026900000","=","84","-","-","24,67","683,5","WJMM62ATXKC409934"},
            {"DJA23848","Test vehicle 06","24,85","2","77","-","OK","13","1","-","-","-","-","0","29","268,58","19,90","60,83","-","Stop approach","99","84","66","66","-","-","9","PL 1890303070370010","▼","84","-","77","24,95","691,0","WJMM62ATXKC409934"},
            {"PZ679WR","Test vehicle 12","18,86","5","80","100","OK","6","35","35","98","-","94","0","22","3.132,86","15,99","73,38","-","Engine use","84","71","60","86","-","-","10","28:1690314006320002","=","84","100","96","19,05","527,6","WJMMG2ATZLC430308"}};


            // Ranking Matrix, Fuel Saving Score, Average Total Fuel, Degree Of Difficulty, CO2 Emissions, Vehicle care
            Values__Ranking_Drivers Value = new Values__Ranking_Drivers(datasetDriversMatrix, "88", "21,22", "33", "587,9", "67");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy")]
            public void RankingDrivers() => RankingDriversWidget(Xpath, Value, Filters);
        }



        public class Ranking_Vehicles_Heavy_NP_Mista_Monthly : Rankings_Widget
        {
            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {
           {"80","100","OK","6","38","38","98","-","3.567,87","15,71","72,57","-","Engine use","85","70","59","84","100","18,99","6","PZ679WR","Test vehicle 12","AS440S46T/P 2LNG","3.644,21","19,20","=","83","21","97","531,8","1","WJMMG2ATZLC430308"},
           {"64","-","!","5","1","-","-","-","8.310,18","19,38","73,91","-","Acceleration style","98","92","81","67","100","21,03","3","DJA23848","Test vehicle 06","AS440S46T/FP LT LNG","77.094,65","21,12","=","92","31","64","585,0","2","WJMM62ATXKC409934"},
           {"61","100","!!","5","67","67","21","-","3.338,43","16,26","72,03","-","Engine use","97","58","46","87","46","21,07","6","WE080YU","Test vehicle 11","AS440S46T/P 2LNG","4.748,55","21,31","=","51","49","96","590,4","3","WJMMG2ATZLC430309"},
           {"39","-","OK","4","0","-","-","-","6.954,40","21,79","75,29","-","Acceleration style","96","86","52","75","100","24,03","4","DJA23051","Test vehicle 05","AS440S46T/FP LT LNG","82.234,85","24,18","▼","86","40","39","669,8","4","WJMM62AT2KC410057"}}; 


            Values__Ranking_Vehicles Value = new Values__Ranking_Vehicles(datasetVehiclesMatrix, "82", "21,80", "35", "603,8", "76");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy")]
            public void RankingVehicles() => RankingVehiclesWidget(Xpath, Value, Filters);
        }
    }
}
