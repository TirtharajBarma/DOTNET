using System;
using System.Diagnostics;

class process
{
    public static void cal()
    {
        Process curr = Process.GetCurrentProcess();
        Console.WriteLine($"Current process id: {curr.Id}");    // 2778
        Console.WriteLine($"Process name: {curr.ProcessName}"); // 2nd_app
        Console.WriteLine($"Process time: {curr.TotalProcessorTime}"); // 2nd_app

    }
}