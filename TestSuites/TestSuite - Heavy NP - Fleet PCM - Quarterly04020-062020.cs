using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_Heavy_NP_PCM_Quartely
    {
        // Define query parameters used in filters
        static string frequency = "q";
        static string from_date = "1585699200000"; //1585699200000
        static string to_date = "1593554399000"; //1593561599000
        static string vehicle_list = "WJMMG2ATZLC430309-WJMMG2ATZLC430308;";
        static string fuel_type = "2";
        static string fleet_id = "12";
        static string vehicle_type = "1";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes
        public class Score_Summary_Heavy_NP_PCM_Quartely : Score_Summary_Widget
        {

            //Fuel Saving Score, Fuel Consuption, Degree Of Difficulty, Average Gross Combination Weight, Average Distance Per Unit, CO2 Emissions
            Values__Score_Summary Value = new Values__Score_Summary("85", "20,75", "38", "19,14",  "10.385,71", "11,9");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            public void ScoreSummary() => FleetManagerViewForHeavyFleets(Xpath, Value, Filters);
        }


        public class CO2_Emissions_Heavy_NP_PCM_Quartely : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // QUERTER COLUMN, Tons, Vehicles, Total distance, Total trip time
            
            new List<string>{"1", "11,9", "2", "20.771,42", "278"},
            //new List<string>{"2","-","-", "-", "-"},
            //new List<string>{"3","-","-", "-", "-"},
            //new List<string>{"4","-","-", "-", "-"},
            //new List<string>{"5","-","-", "-", "-"},
        };
            static string weeklyEmissionKPI = "11,9";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, weeklyEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsHeavy(Xpath, Value, Filters);
        }


        public class Fuel_Consumption_Heavy_NP_PCM_Quartely : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("20,75 kg/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }


        public class DSE_Heavy_NP_PCM_Quartely : DSE_Widget_Vehicles_Acceleration
        {
            //Fuel Saving Score Value, Acceleration Value, Deceleration Value, Engine Use Value,
            //Vehicle Care Score Value, Brake Use Value, Tyres Value, Safe Driving Score Value
            Values__DSE Value = new Values__DSE("85","86","79","91","97","88","100","87");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE Xpath = new Xpath__DSE();

            [Test]
            public void DSE() => DSEkpiAnalysisHeavy(Xpath, Value, Filters);

        }


        public class Monitored_Drivers_Heavy_NP_PCM_Quartely : Monitored_Driver_Test
        {
            static List<List<string>> driverVinList = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Vehicle Care Score, Safe Driving Score
            new List<string>{ "28:1531018021980002", "97", "97", "97" },
            new List<string>{ "28:1840724101740001", "90", "99", "88" },
            new List<string>{ "28:1940331036720000", "90", "100", "88" }
        };
            Values__Monitored_Drivers Value = new Values__Monitored_Drivers(driverVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Drivers Xpath = new Xpath__Monitored_Drivers();

            [Test]
            public void MonitoredDrivers() => AddVerifyRemoveANewDriver(Xpath, Value, Filters);
        }


        public class Monitored_Vehicles_Heavy_NP_PCM_Quartely : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Vehicle Care Score, Average total fuel consumption (kg/100km), CO2 emissions (t), Safe driving score
            new List<string>{ "WJMMG2ATZLC430309 - WE080YU", "77", "99", "20,65", "6,8", "88" },
            new List<string>{ "WJMMG2ATZLC430308 - PZ679WR", "81", "94", "20,88", "5,1", "88" }
        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles Xpath = new Xpath__Monitored_Vehicles();

            [Test]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicle(Xpath, Value, Filters);
        }


        public class Ranking_Drivers_Heavy_NP_PCM_Quartely : Rankings_Widget
        {
            static string[,] datasetDriversMatrix { get; set; } = new string[,] {
            {"PZ679WR","Test vehicle 12","28,25","2","96","100","OK","13","6","6","98","-","97","0","28","141,25","34,69","58,85","-","Inertia","98","96","99","85","-","-","1","28:1531018021980002","=","97","100","97","28,35","785,4","WJMMG2ATZLC430308"},
            {"WE080YU","Test vehicle 11","18,27","2","-","100","OK","5","85","85","98","-","88","0","49","2.186,20","14,35","76,89","-","Engine use","100","81","73","97","-","-","2","28:1940331036720000","=","90","100","100","18,35","508,4","WJMMG2ATZLC430309"},
            {"PZ679WR","Test vehicle 12","20,63","9","94","100","OK","12","37","37","97","0","88","0","16","1.826,92","17,72","59,03","-","Acceleration style","96","82","78","87","-","-","3","28:1840724101740001","=","90","100","99","21,12","585,0","WJMMG2ATZLC430308"},
            {"WE080YU","Test vehicle 11","20,91","3","99","100","OK","9","68","68","79","-","86","0","54","5.649,84","24,95","73,49","-","Preventive driving","90","89","88","90","-","-","4","28:1740207058300002","=","88","88","100","21,05","582,9","WJMMG2ATZLC430309"},
            {"PZ679WR","Test vehicle 12","22,19","6","99","100","OK","6","36","36","98","-","97","0","37","540,01","25,33","64,72","-","-","86","81","83","78","-","-","5","28:1720420050110002","=","86","100","100","22,49","623,0","WJMMG2ATZLC430308"},
            {"PZ679WR","Test vehicle 12","18,86","5","80","100","OK","6","35","35","98","-","94","0","22","3.132,86","15,99","73,38","-","Engine use","84","71","60","86","-","-","6","28:1690314006320002","=","84","100","96","19,05","527,6","WJMMG2ATZLC430308"},
            {"PZ679WR","Test vehicle 12","41,25","48","11","100","OK","7","-","-","98","-","100","0","29","15,66","26,59","14,71","-","Acceleration style","99","62","32","72","-","-","7","28:1741225052710011","=","80","100","52","50,89","1.409,7","WJMMG2ATZLC430308"},
            {"WE080YU","Test vehicle 11","17,96","14","-","100","OK","13","22","22","-","1","60","0","21","45,62","9,03","49,64","-","Inertia","-","70","55","100","-","-","8","28:1881225120180000","=","69","60","100","18,79","520,4","WJMMG2ATZLC430309"},
            {"PZ679WR","Test vehicle 12","25,23","22","24","100","OK","12","9","9","98","-","81","0","29","34,36","22,94","43,86","-","Acceleration style","67","69","45","94","-","-","9","28:1820825098770002","=","69","100","37","26,90","745,1","WJMMG2ATZLC430308"},
            {"PZ679WR","Test vehicle 12","19,41","9","-","100","OK","6","28","28","98","-","44","0","11","599,35","12,81","64,99","-","Acceleration style","79","47","27","80","-","-","10","28:1820829068100002","=","68","100","100","19,77","547,6","WJMMG2ATZLC430308"}};



            // Ranking Matrix, Fuel Saving Score, Average Total Fuel, Degree Of Difficulty, CO2 Emissions, Vehicle care
            Values__Ranking_Drivers Value = new Values__Ranking_Drivers(datasetDriversMatrix, "85", "20,41", "37", "565,2", "97");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy")]
            public void RankingDrivers() => RankingDriversWidget(Xpath, Value, Filters);
        }


        public class Ranking_Vehicles_Heavy_NP_PCM_Quartely : Rankings_Widget
        {
            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {
          {"90","100","!!","7","70","70","61","0","11.912,00","19,76","73,25","-","Engine use","94","78","72","91","76","20,48","4","WE080YU","Test vehicle 11","AS440S46T/P 2LNG","13.322,13","20,65","=","77","50","99","571,9","1","WJMMG2ATZLC430309"},
          {"76","100","OK","8","31","31","85","0","8.859,41","18,20","66,03","-","Acceleration style","86","71","62","84","91","20,58","8","PZ679WR","Test vehicle 12","AS440S46T/P 2LNG","8.935,75","20,88","=","81","19","94","578,4","2","WJMMG2ATZLC430308"}};

            // Ranking Matrix, Fuel Saving Score, Average Total Fuel, Degree Of Difficulty, CO2 Emissions, Vehicle care
            Values__Ranking_Vehicles Value = new Values__Ranking_Vehicles(datasetVehiclesMatrix, "78", "20,75", "38", "574,7", "97");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy_Ranking")]
            public void RankingVehicles() => RankingVehiclesWidget(Xpath, Value, Filters);
        }
    }
}
