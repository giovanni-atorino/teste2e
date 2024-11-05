using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_Heavy_Diesel_Mista_Monthly
    {
        // Define query parameters used in filters
        static string frequency = "m";
        static string from_date = "1590969600000";//"1590969600000";//"1590962400000";//local time;
        static string to_date = "1593561599000";//"1593561599000";//"1593554340000";//local time;
        static string vehicle_list = "WJMM62AU1KC410897-WJME62RT9KC414003-WJME62RT3KC414126-WJMM62AUZ0C423627-WJMM62AUZ0C421747-WJMM62AUZ0C423759-WJMM62AVZ0C423882";
        static string fuel_type = "1";
        static string fleet_id = "-1";
        static string vehicle_type = "1";
        static string dashboard = vehicle_type + fuel_type;

        // Test classes
        public class Score_Summary_Heavy_Diesel_Mista_Monthly : Score_Summary_Widget
        {
            //Fuel Saving Score, Fuel Consuption, Degree Of Difficulty, Average Gross Combination Weight, Average Distance Per Unit, CO2 Emissions
            Values__Score_Summary Value = new Values__Score_Summary("71","27,65","29","26,19","2.299,58","10,0");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            [Category("Widget_Heavy1")]
            public void ScoreSummary() => FleetManagerViewForHeavyFleets(Xpath, Value, Filters);
        }

        
        public class CO2_Emissions_Heavy_Diesel_Mista_Monthly : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // WEEK COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{"1","6,3", "3", "9.700,40","133"},
            new List<string>{"2","11,3", "3", "16.194,99","241"},
            new List<string>{"3","6,4", "4", "8.226,34","142"},
            new List<string>{"4","16,6","4","23.777,10","334"},
            new List<string>{"5","10,0", "6", "13.797,47","216"},
         
        };
            static string weeklyEmissionKPI = "10,0";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, weeklyEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            [Category("Widget_Heavy")]
            public void CO2Emissions() => CO2testKPIandColumnsHeavy(Xpath, Value, Filters);
        }


        public class Fuel_Consumption_Heavy_Diesel_Mista_Monthly : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("27,65 l/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            [Category("Widget_Heavy")]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }


        public class DSE_Heavy_Diesel_Mista_Monthly : DSE_Widget_Vehicles_Acceleration
        {
            //Fuel Saving Score Value, Acceleration Value, Deceleration Value, Engine Use Value,
            //Vehicle Care Score Value, Brake Use Value, Tyres Value, Safe Driving Score Value
            Values__DSE Value = new Values__DSE("71","83","75","59","91","83","100","94");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE Xpath = new Xpath__DSE();

            [Test]
            [Category("Widget_Heavy")]
            public void DSE() => DSEkpiAnalysisHeavy(Xpath, Value, Filters);

        }


        public class Monitored_Drivers_Heavy_Diesel_Mista_Monthly : Monitored_Driver_Test
        {
            static List<List<string>> driverVinList = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Vehicle Care Score, Safe Driving Score
            new List<string>{ "08:BIHV000008676001", "-", "-", "-" },
            new List<string>{ "29:000000000CAJ3000", "66", "-", "69" },
            new List<string>{ "PL 1640229013340002", "-", "-", "-" }
        };
            Values__Monitored_Drivers Value = new Values__Monitored_Drivers(driverVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Drivers Xpath = new Xpath__Monitored_Drivers();

            [Test]
            [Category("Widget_Heavy")]
            public void MonitoredDrivers() => AddVerifyRemoveANewDriver(Xpath, Value, Filters);
        }


        public class Monitored_Vehicles_Heavy_Diesel_Mista_Monthly : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Vehicle Care Score, Average total fuel consumption (l/100km), CO2 emissions (t), Safe driving score
            new List<string>{ "WJME62RT3KC414126 - WZ537GA", "75","-", "35,56" , "0,0", "-" },
            new List<string>{ "WJMM62AU1KC410897 - WE481VT", "-", "-", "-" , "-", "-"},
            new List<string>{ "WJME62RT9KC414003 - WE200WJ", "92", "-", "26,77", "0,0", "-"}
            
        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles Xpath = new Xpath__Monitored_Vehicles();

            [Test]
            [Category("Widget_Heavy")]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicle(Xpath, Value, Filters);
        }




        public class Ranking_Drivers_Heavy_Diesel_Mista_Monthly : Rankings_Widget
        {
            static string[,] datasetDriversMatrix { get; set; } = new string[,] {

           {"B13YVE","Test vehicle 10","17,47","5","-","100","OK","7","38","38","98","-","100","0","29","27,71","4,78","46,36","-","Acceleration style","99","92","93","84","-","-","1","29:0000000009QTB000","=","97","100","100","17,71","463,5","WJMM62AVZ0C423882"},
           {"B13YVE","Test vehicle 10","25,74","42","-","100","OK","6","5","5","99","-","91","0","17","16,61","9,30","14,31","-","Acceleration style","96","86","75","92","-","-","2","29:000000000D59Q000","=","93","100","100","30,74","804,4","WJMM62AVZ0C423882"},
           {"WE200WJ","Test vehicle 02","26,41","9","-","-","OK","11","1","-","-","-","-","0","22","65,33","16,44","54,59","-","Stop approach","88","92","89","90","-","-","3","PL 1691228015710001","▼","92","-","-","26,79","701,1","WJME62RT9KC414003"},
           {"B25YVE","Test vehicle 08","25,70","4","44","100","OK","5","8","8","98","-","95","0","21","1.029,26","33,38","63,66","-","Acceleration style","99","68","62","91","-","-","4","29:0000000008CJ2000","=","86","100","60","25,84","676,1","WJMM62AUZ0C421747"},
           {"B25YVE","Test vehicle 08","26,63","8","49","100","OK","7","10","10","98","-","96","0","20","1.704,11","22,82","52,24","-","Acceleration style","98","62","54","83","-","-","5","29:000000000957V000","=","84","100","72","27,01","706,7","WJMM62AUZ0C421747"},
           {"B13YVE","Test vehicle 10","19,87","44","-","100","OK","9","11","11","100","-","81","0","9","14,60","9,29","24,04","-","Acceleration style","80","78","62","97","-","-","6","29:0000000008604000","=","81","100","100","22,87","598,6","WJMM62AVZ0C423882"},
           {"B13YVE","Test vehicle 10","17,10","16","-","100","OK","7","58","58","97","-","84","0","7","31,14","8,55","42,20","-","Acceleration style","86","53","43","71","-","-","7","15:DB19067162062100","=","72","100","100","17,71","463,5","WJMM62AVZ0C423882"},
           {"B13YVE","Test vehicle 10","16,73","3","-","100","OK","7","69","69","99","-","98","0","6","55,55","10,44","62,14","-","Acceleration style","76","54","31","89","-","-","8","29:000000000CHXO000","=","70","100","100","16,82","440,1","WJMM62AVZ0C423882"},
           {"-","Test vehicle 07","27,41","8","93","100","!","8","62","62","-","1","94","0","32","10.363,33","26,63","67,03","-","Engine use","78","79","75","79","-","-","9","29:0000000002F6S002","▲","68","47","97","27,65","723,6","WJMM62AUZ0C423627"},
           {"B17YVE","Test vehicle 09","20,32","12","-","-","-","19","-","-","98","-","69","0","15","22,98","11,05","45,54","-","Acceleration style","87","45","31","69","-","-","10","29:000000000CAJ3000","=","66","100","-","20,89","546,7","WJMM62AUZ0C423759"}};


            // Ranking Matrix, Fuel Saving Score, Average Total Fuel, Degree Of Difficulty, CO2 Emissions, Vehicle care
            Values__Ranking_Drivers Value = new Values__Ranking_Drivers(datasetDriversMatrix, "71", "27,29", "29", "714,1", "91");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy")]
            public void RankingDrivers() => RankingDriversWidget(Xpath, Value, Filters);
        }



        public class Ranking_Vehicles_Heavy_Diesel_Mista_Monthly : Rankings_Widget
        {
            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {

            {"-","100","!","7","41","41","98","-","256,62","7,09","43,02","-","Acceleration style","85","61","46","90","100","19,04","19","B13YVE","Test vehicle 10","AS440S51T/P","13.702,42","19,77","▲","78","11","100","517,4","1","WJMM62AVZ0C423882"},
            {"-","-","-","13","-","-","98","-","48,18","10,90","43,26","-","Acceleration style","86","36","24","59","100","19,97","14","B17YVE","Test vehicle 09","AS440S48T/P","14.328,67","20,59","▼","58","18","-","538,7","2","WJMM62AUZ0C423759"},
            {"-","-","OK","11","1","-","-","-","65,38","16,44","54,59","-","Stop approach","88","92","89","90","-","26,39","9","WE200WJ","Test vehicle 02","AS260S46Y/FP GV","44.762,94","26,77","▼","92","22","-","700,5","3","WJME62RT9KC414003"},
            {"47","100","OK","6","9","9","98","-","2.929,17","26,71","55,07","-","Acceleration style","98","63","56","85","100","26,81","8","B25YVE","Test vehicle 08","AS440S48T/P","3.490,45","27,13","=","84","21","69","710,1","4","WJMM62AUZ0C421747"},
            {"93","100","!","8","62","62","-","1","10.492,49","26,63","67,03","-","Engine use","78","79","75","79","47","27,78","8","-","Test vehicle 07","AS440S48T/P","19.077,31","28,02","▲","68","32","97","733,2","5","WJMM62AUZ0C423627"},
            {"-","-","OK","19","-","-","-","-","5,63","19,80","24,05","-","Stop approach","68","75","54","45","-","34,46","9","WZ537GA","Test vehicle 03","AS260S46Y/FP GV","40.850,29","35,56","=","75","31","-","930,5","6","WJME62RT3KC414126"}};


            Values__Ranking_Vehicles Value = new Values__Ranking_Vehicles(datasetVehiclesMatrix, "71", "27,65", "29", "723,5", "91");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy_Ranking")]
            public void RankingVehicles() => RankingVehiclesWidget(Xpath, Value, Filters);
        }

    }
}
