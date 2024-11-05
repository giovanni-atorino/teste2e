using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    [SetUpFixture]
    public class TestSuite_Heavy_Diesel_UTP_Week
    {
        // Define query parameters used in filters
        static string frequency = "w";
        static string from_date = "1581897600000";// "1581894000000";// "1581897600000";// GMT
        static string to_date = "1582502399000";// "1582498799000";//"1582502399000";//GMT
        static string vehicle_list = "WJMM62AU1KC410897-WJME62RT9KC414003-WJME62RT3KC414126";
        static string fuel_type = "1";
        static string fleet_id = "9";
        static string vehicle_type = "1";
        static string dashboard = vehicle_type + fuel_type;
        // Test classes
        public class Score_Summary_Heavy_Diesel_UTP_Week : Score_Summary_Widget
        {
            //Fuel Saving Score, Fuel Consuption, Degree Of Difficulty, Average Gross Combination Weight, Average Distance Per Unit, CO2 Emissions
            Values__Score_Summary Value = new Values__Score_Summary("94", "25,02", "42", "27,24", "729,47", "1,4");
             Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type,dashboard);
            Xpath__Score_Summary Xpath = new Xpath__Score_Summary();

            [Test]
            public void ScoreSummary() => FleetManagerViewForHeavyFleets(Xpath, Value, Filters);
        }


        public class CO2_Emissions_Heavy_Diesel_UTP_Week : CO2_emissions_Widget
        {
            static List<List<string>> cO2Datalist = new List<List<string>>
        {
            // WEEK COLUMN, Tons, Vehicles, Total distance, Total trip time
            new List<string>{ "1", "0,6", "1", "1.015,90",  "16"},
            new List<string>{ "2", "2,0", "1", "3.054,93","43"},
            new List<string>{ "3", "1,6", "2", "2.430,37", "26"},
            new List<string>{ "4", "1,2", "2", "1.912,97",  "27"},
            new List<string>{ "5", "1,4", "3", "2.188,41",  "32"}
        };
            static string weeklyEmissionKPI = "1,4";

            Values__CO2_Emissions Value = new Values__CO2_Emissions(cO2Datalist, weeklyEmissionKPI);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__CO2_Emissions Xpath = new Xpath__CO2_Emissions();

            [Test]
            public void CO2Emissions() => CO2testKPIandColumnsHeavy(Xpath, Value, Filters);
        }


        public class Fuel_Consumption_Heavy_Diesel_UTP_Week : Fuel_consumption_Widget
        {
            // KPI Fuel Consumption
            Values__Fuel_Consumption Value = new Values__Fuel_Consumption("25,02 l/100km");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Fuel_Consumption Xpath = new Xpath__Fuel_Consumption();

            [Test]
            public void FuelConsumption() => TotalFuelConsumptionInformation(Xpath, Value, Filters);

        }


        public class DSE_Heavy_Diesel_UTP_Week : DSE_Widget_Vehicles_Acceleration
        {
            //Fuel Saving Score Value, Acceleration Value, Deceleration Value, Engine Use Value,
            //Vehicle Care Score Value, Brake Use Value, Tyres Value, Safe Driving Score Value
            Values__DSE Value = new Values__DSE("94", "95", "94", "34", "90", "90", "-", "-");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__DSE Xpath = new Xpath__DSE();

            [Test]
            public void DSE() => DSEkpiAnalysisHeavy(Xpath, Value, Filters);

        }


        public class Monitored_Drivers_Heavy_Diesel_UTP_Week : Monitored_Driver_Test
        {
            static List<List<string>> driverVinList = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Vehicle Care Score, Safe Driving Score
            new List<string>{ "PL 1780709050350001", "87", "-", "-" },
            new List<string>{ "UA UAD0000069950000", "96", "90", "-" },
            new List<string>{ "29:000000000CAJ3000", "-", "-", "-" }
        };
            Values__Monitored_Drivers Value = new Values__Monitored_Drivers(driverVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Drivers Xpath = new Xpath__Monitored_Drivers();

            [Test]
            public void MonitoredDrivers() => AddVerifyRemoveANewDriver(Xpath, Value, Filters);
        }


        public class Monitored_Vehicles_Heavy_Diesel_UTP_Week : Monitored_Vehicles_Test
        {
            static List<List<string>> vehicleVinList { get; set; } = new List<List<string>>{
            // Vin ID, Fuel Saving Score, Vehicle Care Score, Average total fuel consumption (l/100km), CO2 emissions (t), Safe driving score
            new List<string>{ "WJME62RT3KC414126 - WZ537GA", "75", "-", "27,78" , "0,1", "-"},
            new List<string>{ "WJMM62AU1KC410897 - WE481VT", "96", "90", "24,55" , "1,2", "-"},
            new List<string>{ "WJME62RT9KC414003 - WE200WJ", "85", "-", "29,44", "0,1", "-"}
        };
            Values__Monitored_Vehicles Value = new Values__Monitored_Vehicles(vehicleVinList);
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Monitored_Vehicles Xpath = new Xpath__Monitored_Vehicles();

            [Test]
            public void MonitoredVehicles() => AddVerifyRemoveANewVehicle(Xpath, Value, Filters);
        }

        public class Ranking_Drivers_Heavy_Diesel_UTP_Week : Rankings_Widget
        {
            static string[,] datasetDriversMatrix { get; set; } = new string[,] {
            {"WE481VT","Test vehicle 01","24,03","3","90","-","-","5","1","-","-","-","-","0","45","1.918,48","29,14","70,71","-","Acceleration style","95","96","99","82","-","-","1","UA UAD0000069950000","▲","96","34","90","24,13","631,6","WJMM62AU1KC410897"},
            {"WE200WJ","Test vehicle 02","24,73","13","-","-","OK","14","0","-","-","-","-","0","14","23,64","11,36","45,83","-","Acceleration style","99","87","51","88","-","-","2","PL 1780709050350001","=","87","-","-","25,38","664,2","WJME62RT9KC414003"},
            {"WE200WJ","Test vehicle 02","26,79","18","-","-","OK","9","1","-","-","-","-","0","19","82,14","13,86","50,75","-","Acceleration style","96","85","52","78","-","-","3","PL 1640229013340002","=","85","-","-","27,39","716,9","WJME62RT9KC414003"},
            {"WZ537GA","Test vehicle 03","25,17","6","-","-","OK","11","0","-","-","-","-","0","17","131,85","12,27","55,30","-","Stop approach","96","78","54","63","-","-","4","PL 1570813030740002","=","78","-","-","25,41","664,9","WJME62RT3KC414126"}};
            // Ranking Matrix, Fuel Saving Score, Average Total Fuel, Degree Of Difficulty, CO2 Emissions, Vehicle care
            Values__Ranking_Drivers Value = new Values__Ranking_Drivers(datasetDriversMatrix, "94", "24,35", "42", "637,2", "90");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            public void RankingDrivers() => RankingDriversWidget(Xpath, Value, Filters);
        }


        public class Ranking_Vehicles_Heavy_Diesel_UTP_Week : Rankings_Widget
        {
            static string[,] datasetVehiclesMatrix { get; set; } = new string[,] {
         {"90","-","-","5","1","-","-","-","1.930,51","29,14","70,71","-","Acceleration style","95","96","99","82","34","24,45","3","WE481VT","Test vehicle 01","AS440S48T/FP LT","95.437,85","24,55","▲","96","45","90","642,6","1","WJMM62AU1KC410897"},
         {"-","-","OK","11","0","-","-","-","145,79","12,26","54,08","-","Stop approach","95","75","51","62","-","27,49","7","WZ537GA","Test vehicle 03","AS260S46Y/FP GV","37.228,46","27,78","▼","75","17","-","727,0","2","WJME62RT3KC414126"},
         {"-","-","OK","10","1","-","-","-","112,11","13,30","49,56","-","Acceleration style","97","85","52","80","-","28,86","17","WE200WJ","Test vehicle 02","AS260S46Y/FP GV","30.419,26","29,44","=","85","18","-","770,3","3","WJME62RT9KC414003"}};

            Values__Ranking_Vehicles Value = new Values__Ranking_Vehicles(datasetVehiclesMatrix, "94", "25,02", "42", "654,7", "90");
            Filter_Query_Params Filters = new Filter_Query_Params(frequency, from_date, to_date, vehicle_list, fuel_type, fleet_id, vehicle_type, dashboard);
            Xpath__Ranking Xpath = new Xpath__Ranking();

            [Test]
            public void RankingVehicles() => RankingVehiclesWidget(Xpath, Value, Filters);
        }
    }
}
