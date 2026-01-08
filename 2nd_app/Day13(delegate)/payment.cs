using System;

delegate void PaymentDelegate(decimal amt);

class PaymentSystem
{
    public void ProcessPayment(decimal amt)
    {
        Console.WriteLine($"payment of {amt} processed successfully");
    }

    public void RTGS(decimal amt)
    {
        Console.WriteLine($"{amt} processed successfully in RTGS");
    }
}

static class PaymentExtension
{
    public static bool isValid(this decimal amt)
    {
        return amt > 0 && amt <= 10_000_000;
    }
}

// delegate