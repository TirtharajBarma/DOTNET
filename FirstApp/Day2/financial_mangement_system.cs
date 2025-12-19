using System;

class Account
{
    public static int Balance = 0;
}

class Debit
{
    public static void ATMWithdrawal()
    {
        Console.Write("Enter withdrawal amount: ");
        int amt = Convert.ToInt32(Console.ReadLine());
        int limit = 40000;

        if (amt <= limit)
            Console.WriteLine("Withdrawal permitted within daily limit.");
        else
            Console.WriteLine("Daily ATM withdrawal limit exceeded.");
    }

    public static void EMICheck()
    {
        Console.Write("Enter monthly income: ");
        int income = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter EMI amount: ");
        int emi = Convert.ToInt32(Console.ReadLine());

        if (emi <= income * 40 / 100)
            Console.WriteLine("EMI is financially manageable.");
        else
            Console.WriteLine("EMI exceeds safe income limit.");
    }

    public static void DailyTransactions()
    {
        Console.Write("Enter number of transactions: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double total = 0;
        for (int i = 1; i <= n; i++)
        {
            Console.Write($"Enter amount for transaction {i}: ");
            string input = Console.ReadLine();
            
            if (!double.TryParse(input, out double amt))
            {
                Console.WriteLine("Invalid number skipped.");
                continue;
            }

            if (amt < 0)
            {
                Console.WriteLine("Negative amount skipped.");
                continue;
            }

            total += amt;
        }

        Console.WriteLine($"Total debit amount for the day: ₹{total}");
    }

    public static void MinBalanceCheck()
    {
        if (Account.Balance < 2000)
            Console.WriteLine("Minimum balance not maintained. Penalty applicable.");
        else
            Console.WriteLine("Minimum balance requirement satisfied.");
    }

    public static void DebitMenu()
    {
        while (true)
        {
            Console.WriteLine("1. ATM Withdrawal Check");
            Console.WriteLine("2. EMI Check");
            Console.WriteLine("3. Daily Transactions");
            Console.WriteLine("4. Minimum Balance Check");
            Console.WriteLine("5. Back");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: 
                    ATMWithdrawal();
                     Console.WriteLine(); 
                    break;
                case 2: 
                    EMICheck();
                    Console.WriteLine(); 
                    break;
                case 3: 
                    DailyTransactions();
                     Console.WriteLine(); 
                    break;
                case 4: 
                    MinBalanceCheck();
                    Console.WriteLine(); 
                    break;
                case 5:
                    Console.WriteLine(); 
                    return;
                default: 
                    Console.WriteLine("Invalid option");
                    Console.WriteLine();
                    break;
            }
        }
    }
}

class Credit
{
    public static void SalaryCredit()
    {
        Console.Write("Enter gross salary: ");
        int salary = Convert.ToInt32(Console.ReadLine());

        int netSalary = salary - (salary * 10 / 100);
        Account.Balance += netSalary;

        Console.WriteLine($"Net salary credited: ₹{netSalary}");
    }

    public static void FixedDeposit()
    {
        Console.Write("Enter principal: ");
        double p = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter rate: ");
        double r = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter time (years): ");
        double t = Convert.ToDouble(Console.ReadLine());

        double si = (p * r * t) / 100;
        double maturity = p + si;

        Console.WriteLine($"Fixed Deposit maturity amount: ₹{maturity}");
    }

    public static void RewardPoints()
    {
        Console.Write("Enter total spending: ");
        int spend = Convert.ToInt32(Console.ReadLine());

        int points = spend / 100;
        Console.WriteLine($"Reward points earned: {points}");
    }

    public static void BonusEligibility()
    {
        Console.Write("Enter annual salary: ");
        int salary = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter years of service: ");
        int years = Convert.ToInt32(Console.ReadLine());

        if (salary >= 500000 && years >= 3)
            Console.WriteLine("Employee is eligible for bonus.");
        else
            Console.WriteLine("Employee is not eligible for bonus.");
    }

    public static void CreditMenu()
    {
        while (true)
        {
            Console.WriteLine("1. Salary Credit");
            Console.WriteLine("2. Fixed Deposit");
            Console.WriteLine("3. Reward Points");
            Console.WriteLine("4. Bonus Eligibility");
            Console.WriteLine("5. Back");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: 
                    SalaryCredit(); 
                    Console.WriteLine();
                    break;
                case 2: 
                    FixedDeposit(); 
                     Console.WriteLine();
                    break;
                case 3: 
                    RewardPoints(); 
                     Console.WriteLine();
                    break;
                case 4: 
                    BonusEligibility(); 
                     Console.WriteLine();
                    break;
                case 5: 
                     Console.WriteLine();
                    return;
                default: 
                    Console.WriteLine("Invalid option"); 
                    Console.WriteLine();
                    break;
            }
        }
    }
}

class Financial
{
    public static void Run()
    {
        while (true)
        {
            Console.WriteLine("1. Debit Operations");
            Console.WriteLine("2. Credit Operations");
            Console.WriteLine("3. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: 
                    Debit.DebitMenu(); 
                    Console.WriteLine();
                    break;
                case 2: 
                    Credit.CreditMenu(); 
                    Console.WriteLine();
                    break;
                case 3: 
                    Console.WriteLine();
                    return;
                default: 
                    Console.WriteLine("Invalid option"); 
                    Console.WriteLine();
                    break;
            }
        }
    }
}

// Console.Write("Enter gross salary: ");
// if (!int.TryParse(Console.ReadLine(), out int salary))
// {
//     Console.WriteLine("Invalid salary input.");
//     return;
// }