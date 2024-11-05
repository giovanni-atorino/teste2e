using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_Heavy_Diesel_PCM_Monthly
    {
        // Define query parameters used in filters
        static string frequency = "m";
        static string from_date = "1588291200000";//"1588291200000"; //"1588284000000";// LOCAL TIME
        static string to_date = "1590969599000"; //"1590969599000"; // "1590962399000";// LOCAL TIME
        static string vehicle_list = "WJMM62AUZ0C423627-WJMM62AUZ0C421747-WJMM62AUZ0C423759-WJMM62AVZ0C423882";
        static string fuel_type = "1";
        static string fleet_id = "11";
        static string vehicle_type = "1";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes
        public class Score_Summary_Heavy_Diesel_PCM_Monthly : Score_Summary_Widget
        {
            //Fuel Saving Score, Fuel Consuption, Degree Of Difficulty, Average Gross Combination Weight, Average Distance Per Unit, CO2 Emissions
            Values__Score_Summary Value = new Values__Score_Summary("70", "26,73", "33", "27,09", "5.824,13", "12,2");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            public void ScoreSummary() => FleetManagerViewForHeavyFleets(Xpath, Value, Filters);
        }


        public class CO2_Emissions_Heavy_Diesel_PCM_Monthly : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // WEEK COLUMN, Tons, Vehicles, Total distance, Total trip time
            //new List<string>{"1","-","-","-","-"},
            //new List<string>{"2","-","-","-","-"},
            //new List<string>{"3","-","-","-","-"},
            new List<string>{"1","5,3", "2", "6.613,10","114"},
            new List<string>{"2","12,2", "3", "17.472,39","246"}
        };
            static string weeklyEmissionKPI = "12,2";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, weeklyEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsHeavy(Xpath, Value, Filters);
        }


        public class Fuel_Consumption_Heavy_Diesel_PCM_Monthly : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("26,73 l/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }


        public class DSE_Heavy_Diesel_PCM_Monthly : DSE_Widget_Vehicles_Acceleration
        {
            //Fuel Saving Score Value, Acceleration Value, Deceleration Value, Engine Use Value,
            //Vehicle Care Score Value, Brake Use Value, Tyres Value, Safe Driving Score Value
            Values__DSE Value = new Values__DSE("70","79","60","69","89","79","100","90");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE Xpath = new Xpath__DSE();

            [Test]
            public void DSE() => DSEkpiAnalysisHeavy(Xpath, Value, Filters);

        }


        public class Monitored_Drivers_Heavy_Diesel_PCM_Monthly : Monitored_Driver_Test
        {
            static List<List<string>> driverVinList = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Vehicle Care Score, Safe Driving Score
            new List<string>{ "29:0000000000X0Y002", "80", "87", "88" },
            new List<string>{ "08:BIHV000008676001", "-", "-", "-" },
            new List<string>{ "29:000000000CAJ3000", "-", "-", "-" }
        };
            Values__Monitored_Drivers Value = new Values__Monitored_Drivers(driverVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Drivers Xpath = new Xpath__Monitored_Drivers();

            [Test]
            public void MonitoredDrivers() => AddVerifyRemoveANewDriver(Xpath, Value, Filters);
        }


        public class Monitored_Vehicles_Heavy_Diesel_PCM_Monthly : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Vehicle Care Score, Average total fuel consumption (l/100km), CO2 emissions (t), Safe driving score
            new List<string>{ "WJMM62AU1KC410897 - WE481VT", "-", "-", "-" , "-", "-" },
            new List<string>{ "WJMM62AUZ0C426214 - IF26YVE", "-", "-", "-" , "-", "-"},
            new List<string>{ "WJME62RT9KC414003 - WE200WJ", "96", "7", "26,57", "4,4", "-"}
        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles Xpath = new Xpath__Monitored_Vehicles();

            [Test]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicle(Xpath, Value, Filters);
        }

        public class Ranking_Drivers_Heavy_Diesel_PCM_Monthly : Rankings_Widget
        {
            static string[,] datasetDriversMatrix { get; set; } = new string[,] {
           {"B17YVE","Test vehicle 09","26,30","7","84","-","-","5","67","-","98","0","88","0","37","4.773,39","27,31","71,14","-","Engine use","89","51","40","86","-","-","1","29:0000000000X0Y002","=","80","100","87","26,48","692,9","WJMM62AUZ0C423759"},
           {"-","Test vehicle 07","17,77","10","-","100","OK","9","11","11","-","-","52","0","20","247,94","9,59","60,17","-","Acceleration style","80","35","20","66","-","-","2","29:0000000002OB6001","=","63","58","100","18,05","472,3","WJMM62AUZ0C423627"},
           {"-","Test vehicle 07","26,72","9","88","100","OK","7","61","61","-","1","95","0","34","3.805,56","30,93","67,87","-","Acceleration style","74","74","71","76","-","-","3","29:0000000002F6S002","=","63","38","96","26,96","705,6","WJMM62AUZ0C423627"},
           {"-","Test vehicle 07","26,46","10","19","100","OK","11","20","20","-","0","87","0","31","1.399,76","21,38","58,16","-","Acceleration style","63","50","43","70","-","-","4","29:0000000008F1H000","▼","57","53","70","26,86","702,8","WJMM62AUZ0C423627"}};


            // Ranking Matrix, Fuel Saving Score, Average Total Fuel, Degree Of Difficulty, CO2 Emissions, Vehicle care
            Values__Ranking_Drivers Value = new Values__Ranking_Drivers(datasetDriversMatrix, "70", "26,50", "35", "693,6", "89");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy")]
            public void RankingDrivers() => RankingDriversWidget(Xpath, Value, Filters);
        }

        public class Ranking_Vehicles_Heavy_Diesel_PCM_Monthly : Rankings_Widget
        {
            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {

           {"80","100","!","5","53","53","98","1","6.180,89","26,54","63,92","-","Acceleration style","85","49","33","79","100","26,03","11","B13YVE","Test vehicle 10","AS440S51T/P","13.442,00","26,39","▼","73","30","93","690,5","1","WJMM62AVZ0C423882"},
           {"84","-","-","5","67","-","98","0","4.901,81","27,31","71,14","-","Engine use","89","51","40","86","100","26,50","7","B17YVE","Test vehicle 09","AS440S48T/P","14.276,03","26,68","=","80","37","87","698,2","2","WJMM62AUZ0C423759"},
           {"74","100","OK","8","47","47","-","1","6.389,69","27,51","64,72","-","Acceleration style","71","67","62","74","43","26,86","9","-","Test vehicle 07","AS440S48T/P","8.584,82","27,10","▼","61","33","89","709,3","3","WJMM62AUZ0C423627"}};
            
            Values__Ranking_Vehicles Value = new Values__Ranking_Vehicles(datasetVehiclesMatrix, "71", "26,73", "33", "699,5", "90");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            [Category("Widget_Heavy_Ranking")]
            public void RankingVehicles() => RankingVehiclesWidget(Xpath, Value, Filters);
        }
    }
}
