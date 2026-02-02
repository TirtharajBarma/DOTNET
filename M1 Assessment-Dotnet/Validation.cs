using System;

class BankException : Exception
{
    public BankException(string msg) : base(msg){}
}

public class Program
{
    public decimal Balance{get; set;}

    public Program(int bal){
        Balance = bal;
    }
    
    public void Deposit(decimal amt)
    {
        if(amt < 0)
            throw new BankException("Deposit amount cannot be negative");
        Balance += amt;
    }

    public void WithDraw(decimal amt)
    {
        if(amt > Balance)
            throw new BankException("Insufficient funds");
        Balance -= amt;
    }
}

public class UnitTest
{
    
}