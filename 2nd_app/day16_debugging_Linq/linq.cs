using System;

namespace AutonomousRobot.AI
{
    class SensorReading
    {
        public int SensorId{get; set;}
        public string Type{get; set;}
        public double Value{get; set;}
        public DateTime Timestamp{get; set;}
        public double Confidence{get; set;}

    }
    enum RobotAction
    {
        Stop, SlowDown, Reroute, Continue
    }

    class DecisionEngine
    {
        public List<SensorReading> GetRecentReadings(List<SensorReading> sensorHistory, DateTime fromTime)
        {
            return sensorHistory.Where(r => r.Timestamp >= fromTime).ToList();
        }

        public bool IsBatteryCritical(List<SensorReading> readings)
        {
            return readings.Any(r => r.Type == "Battery" && r.Value < 20);
        }

        public double GetNearestObstacleDistance(List<SensorReading> readings)
        {
            var res = readings.Where(ex => ex.Type == "Distance").Select(ex => ex.Value);

            return res.Any() ? res.Min() : double.MaxValue;
        }

        public bool IsTemperatureSafe(List<SensorReading> readings)
        {
            return readings.Where(r => r.Type == "Temperature").All(r => r.Value < 90);
        }

        public double GetAverageVibration(List<SensorReading> readings)
        {
            var res = readings.Where(r => r.Type == "Vibration")
                                .Select(r => r.Value);
            return res.Any() ? res.Average() : 0;
        }

        public Dictionary<string, double> CalculateSensorHealth(List<SensorReading> readings)
        {
            return readings.GroupBy(r => r.Type)
                            .ToDictionary(g => g.Key, g => g.Average(r => r.Confidence));
        }

        public List<string> DetectFaultySensors(List<SensorReading> sensorHistory)
        {
            return sensorHistory.GroupBy(ep => ep.Type)
                                .Where(g => g.Count(rp => rp.Confidence < 0.4) > 2)
                                .Select(g => g.Key).ToList();
        }  

        // public bool IsBatteryDrainingFast(List<SensorReading> sensorHistory)
        // {
        //     var batteryReadings = sensorHistory.Where(r => r.Type == "Battery").OrderBy(r => r.Timestamp).ToList();
        //     if (batteryReadings.Count < 2) return false;
            
        //     double initialBattery = batteryReadings.First().Value;
        //     double currentBattery = batteryReadings.Last().Value;
        //     double batteryDrop = initialBattery - currentBattery;
            
        //     return batteryDrop > 10;
        // }

        public double GetWeightedDistance(List<SensorReading> recentReadings)
        {
            var distanceReading = recentReadings.Where(r => r.Type == "Distance");
            double total = distanceReading.Sum(r => r.Confidence);
            if(total == 0) 
                return double.MaxValue;

            return distanceReading.Sum(r => r.Value * r.Confidence) / total;
        }

        public RobotAction DecideRobotAction(List<SensorReading> recentReadings, List<SensorReading> sensorHistory)
        {
            if (recentReadings.Any(r => r.Type == "Battery" && r.Value < 20))
                return RobotAction.Stop;

            // if(IsBatteryDrainingFast(sensorHistory))
            //     return RobotAction.Stop;

            double nearestDistance = recentReadings
                .Where(r => r.Type == "Distance")
                .Select(r => r.Value)
                .DefaultIfEmpty(double.MaxValue)
                .Min();

            if (nearestDistance < 1.0)
                return RobotAction.Reroute;

            if (recentReadings.Any(r => r.Type == "Temperature" && r.Value >= 90))
                return RobotAction.SlowDown;
            
            return RobotAction.Continue;
        }
    }
    public class Program
    {
        public static void main()
        {
            List<SensorReading> sensorHistory = new List<SensorReading>
            {
                new SensorReading { SensorId = 1, Type = "Distance", Value = 0.8, Confidence = 0.9, Timestamp = DateTime.Now.AddSeconds(-9) },
                new SensorReading { SensorId = 2, Type = "Battery", Value = 18, Confidence = 0.8, Timestamp = DateTime.Now.AddSeconds(-8) },
                new SensorReading { SensorId = 3, Type = "Temperature", Value = 92, Confidence = 0.7, Timestamp = DateTime.Now.AddSeconds(-7) },
                new SensorReading { SensorId = 4, Type = "Vibration", Value = 8.2, Confidence = 0.6, Timestamp = DateTime.Now.AddSeconds(-6) },
                new SensorReading { SensorId = 5, Type = "Battery", Value = 75, Confidence = 0.9, Timestamp = DateTime.Now.AddSeconds(-5) },
                new SensorReading { SensorId = 6, Type = "Distance", Value = 2.5, Confidence = 0.5, Timestamp = DateTime.Now.AddSeconds(-4) }
            };

            DecisionEngine engine = new DecisionEngine();

            DateTime fromTime = DateTime.Now.AddSeconds(-10);

            // TASK 1
            List<SensorReading> recentReadings = engine.GetRecentReadings(sensorHistory, fromTime);

            // TASK 2
            bool isBatteryCritical = engine.IsBatteryCritical(recentReadings);

            // TASK 3
            double nearestObstacle = engine.GetNearestObstacleDistance(recentReadings);

            // TASK 4
            bool isTemperatureSafe = engine.IsTemperatureSafe(recentReadings);

            // TASK 5
            double averageVibration = engine.GetAverageVibration(recentReadings);

            // TASK 6
            Dictionary<string, double> sensorHealth = engine.CalculateSensorHealth(sensorHistory);

            // TASK 7
            List<string> faultySensors = engine.DetectFaultySensors(sensorHistory);

            // TASK 8
            // bool isBatteryDrainingFast = engine.IsBatteryDrainingFast(sensorHistory);

            // TASK 9
            double weightedDistance = engine.GetWeightedDistance(recentReadings);

            // TASK 10
            RobotAction action = engine.DecideRobotAction(recentReadings, sensorHistory);

            Console.WriteLine("Robot Action: " + action);
        }
    }
}