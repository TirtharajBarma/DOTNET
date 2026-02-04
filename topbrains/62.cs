using System;

class Solution
{
    public static double? AverageNonNull(double?[] values)
    {
        double sum = 0;
        int cnt = 0;

        foreach (var v in values)
        {
            if (v != null)
            {
                sum += v.Value;
                cnt++;
            }
        }

        if (cnt == 0)
            return null;

        double avg = sum / cnt;
        return Math.Round(avg, 2, MidpointRounding.AwayFromZero);
    }
}