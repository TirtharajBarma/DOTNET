using System;
using System.Net.Mail;

class Bank
{
    private double time, roi, fdAmt;
    private static int bankObjectCount;

    static Bank()           // static constructor
    {
        bankObjectCount = 0;
        Console.WriteLine("Static constructor of Bank called");
    }

    public Bank(double time, double roi, double fdAmt)
    {
        this.time = time;
        this.roi = roi;
        this.fdAmt = fdAmt;

        bankObjectCount++;

        Console.WriteLine("Bank constructor called");
        Console.WriteLine("Total Bank objects: " + bankObjectCount);
    }
}

class Deposit : Bank
{
    public Deposit(double time, double roi, double fdAmt) : base(time, roi, fdAmt)
    {
        Console.WriteLine("Deposit account created");
        Console.WriteLine();
    }
}

// static constructor -> to initialize static member of the class -> run only once
// over-loaded constructor -> more than 1 constructor but with different parameter list
// default constructor run first