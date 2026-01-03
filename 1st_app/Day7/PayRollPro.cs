abstract class EmployeeRecord
{
    public string? EmployeeName{get; set;}
    public double[] WeeklyHours{get; set;} = new double[4];

    public abstract double GetMonthPay();
}

class FullTimeEmployee : EmployeeRecord
{
    public double HourlyRate{get; set;}
    public double MonthlyBonus{get; set;}

    public override double GetMonthPay()
    {
        double totalHours = 0.0;
        foreach(var it in WeeklyHours)
            totalHours += it;
        return (totalHours * HourlyRate) + MonthlyBonus;
    }
}

class ContractEmployee : EmployeeRecord
{
    public double HourlyRate{get; set;}
    public override double GetMonthPay()
    {
        double totalHours = 0.0;
        foreach(var it in WeeklyHours)
            totalHours += it;
        return totalHours * HourlyRate;
    }
}

class PayRollService
{
    public static List<EmployeeRecord> PayRollBoard = [];
    public static void RegisterEmployee(EmployeeRecord record)
    {
        PayRollBoard.Add(record);
    }

     public Dictionary<string, int>GetOvertimeWeekCounts(List<EmployeeRecord> records, double hoursThreshold)
    {
        Dictionary<string, int> res = [];
        foreach(var it in records)
        {
            int ctn = 0;
            foreach(var hour in it.WeeklyHours)
            {
                if(hour >= hoursThreshold)
                    ctn++;
            }
            if(ctn > 0)
                res.Add(it.EmployeeName!, ctn);
        }
        return res;
    }

    public double CalculateAverageMonthlyPay()
    {
        if(PayRollBoard.Count == 0)
            return 0;

        double totalPay = 0.0;
        foreach(var it in PayRollBoard)
            totalPay += it.GetMonthPay();

        return totalPay / PayRollBoard.Count;
    }
}