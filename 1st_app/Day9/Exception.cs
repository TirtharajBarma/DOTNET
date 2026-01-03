using System;

class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string msg) : base(msg) {}
}

class BankAccount
{
    public decimal Balance{get; set;} = 5000;
    public void WithDraw(decimal amt)
    {
        if(amt <= 0)
            throw new ArgumentException("Amt must be greater than zero");
        if(amt > Balance)
            throw new InsufficientBalanceException("insufficient balance for withdraw");
        Balance -= amt;
    }
}

