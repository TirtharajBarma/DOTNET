using System;

class Feet
{
    public static void Calculate()
    {   
        Console.Write("Enter foot: ");
        double fm = Convert.ToDouble(Console.ReadLine());

        double ans = fm * 30.48;

        Console.WriteLine($"{fm} foot into cm is {ans.ToString("F2")} ");
    }
}