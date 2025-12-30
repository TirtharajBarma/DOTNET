using System;

class CreatorStats
{
    public string? CreatorName{get; set;}
    public double[] WeeklyLikes = new double[4];
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
}

static class Program
{
    public static void RegisterCreator(CreatorStats record)
    {
        string name = Console.ReadLine()!;
        record.CreatorName = name;

        for(int i = 0; i < 4; i++)
            record.WeeklyLikes[i] = int.Parse(Console.ReadLine()!);

        CreatorStats.EngagementBoard.Add(record);
        Console.WriteLine("Creator registered successfully");
    }

    public static Dictionary<string, int> GetTopPostCounts(List<CreatorStats> record, double likeThreshold)
    {
        Dictionary<string, int> dict = [];
        foreach(var it in record)
        {
            int ctn = 0;
            foreach(var likes in it.WeeklyLikes)
            {
                if(likes >= likeThreshold)
                    ctn++;
            }
            if(ctn > 0 && it.CreatorName != null)
                dict[it.CreatorName] = ctn;
        }

        return dict;
    }

    public static double CalculateAverageLikes()
    {
        double total = 0;
        int ctn = 0;

        foreach(var it in CreatorStats.EngagementBoard)
        {
            foreach(var likes in it.WeeklyLikes)
            {
                total += likes;
                ctn++;
            }
        }
        if(ctn == 0)
            return 0;
        
        return total / ctn;
    }
}