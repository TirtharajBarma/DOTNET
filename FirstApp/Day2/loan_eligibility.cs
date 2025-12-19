using System;

class Loan
{
    static int totalAmt = 0;
    public static void checkEligibility()
    {
        Console.Write("Enter your Age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        if(age <= 21)
        {
            Console.WriteLine("Not eligible");
        }
        else
        {
            Console.WriteLine("Eligible");
        }
    }

    public static void calculateTax()
    {
        Console.Write("Enter your Income: ");
        int income = Convert.ToInt32(Console.ReadLine());
        int annualIncome = income * 12;

        if(annualIncome <= 250000)
        {
            Console.WriteLine("0%");
        } else if(annualIncome > 250000 && annualIncome <= 500000)
        {
            int tax = annualIncome * 5 /100;
            Console.WriteLine($"5% tax i.e {tax}");
        } else if(annualIncome > 500000 && annualIncome <= 1000000)
        {
            int tax = annualIncome * 20 /100;
            Console.WriteLine($"20% tax i.e {tax}");
        } else
        {
            int tax = annualIncome * 30 /100;
            Console.WriteLine($"30% tax i.e {tax}");
        }
    }

    public static void EnterTransaction()
    {
        Console.WriteLine("Choose 1 option \n 1. Deposit 2. Withdraw ");
        int choice = Convert.ToInt32(Console.ReadLine());
        
        if(choice == 1)
        {
            Console.Write("Enter amt to deposit: ");
            int amt = Convert.ToInt32(Console.ReadLine());
            if (amt > 0) 
                totalAmt += amt;
            else    
                Console.WriteLine("Amt can't be less than 0");
        }
        else if(choice == 2)
        {
            Console.Write("Enter amt to withdraw: ");
            int amt = Convert.ToInt32(Console.ReadLine());
            if(amt > totalAmt)
                Console.WriteLine("Total Amt is less than 0");
            else
                totalAmt -= amt;
        } else
        {
            Console.WriteLine("Invalid choice");
        }
        Console.WriteLine("Total amt: " + totalAmt);
    }
    public static void cal()
    {
        while(true){
            Console.WriteLine("Main Menu Loop ");
            Console.WriteLine(" 1. Check Loan Eligibility \n 2. Calculate Tax \n 3. Enter Transaction \n 4. Exit");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    checkEligibility();
                    Console.WriteLine();
                    break;
                case 2: 
                    calculateTax();
                    Console.WriteLine();
                    break;
                case 3:
                    EnterTransaction();
                    Console.WriteLine();
                    break;
                case 4: 
                    Console.WriteLine("Exiting....");
                    Console.WriteLine();
                    return;
                default:
                    Console.WriteLine("Invalid Choice");
                    Console.WriteLine();
                    break;
            }
        }
    }
}