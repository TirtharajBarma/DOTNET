
class RobotSafetyException : Exception
{
    public RobotSafetyException(string msg) : base(msg){}
}

class RobotHazardAuditor
{
    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {
        if(armPrecision < 0.0 || armPrecision > 1.0)
            throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");
        
        if(workerDensity < 1 || workerDensity > 20)
            throw new RobotSafetyException("Error: Worker density must be 1-20");
        
        if(machineryState != "Worn" && machineryState != "Faulty" && machineryState != "Critical")
            throw new RobotSafetyException("Error: Unsupported machinery state");

        double machineRiskFactor = 0.0;
        if(machineryState == "Work")
            machineRiskFactor = 1.3;
        else if(machineryState == "Faulty")
            machineRiskFactor = 2.0;
        else    
            machineRiskFactor = 3.0;

        double hazardRisk = ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor);

        return hazardRisk;
    }
}

class Program
{
    public static void Main()
    {
        try
        {
            RobotHazardAuditor r = new RobotHazardAuditor();
            double armPrecision = double.Parse(Console.ReadLine());
            int workerDensity = int.Parse(Console.ReadLine());
            string machineryState = Console.ReadLine();
            
            double ans = r.CalculateHazardRisk(armPrecision, workerDensity, machineryState);
            Console.WriteLine(ans);
        } 
        catch(RobotSafetyException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message);
        }

    }
}