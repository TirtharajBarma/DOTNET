using System;

class SaleTransaction
{
    public string? InvoiceNo{get; set;}
    public string? CustomerName{get; set;}
    public string? ItemName{get; set;}
    public int Quantity{get; set;}
    public decimal PurchaseAmt{get; set;}
    public decimal SellingAmt{get; set;}
    public string? ProfitOrLossStatus{get; set;}
    public decimal ProfitOrLossAmt{get; set;}
    public decimal ProfitMarginPercent{get; set;}
}

static class Sale
{
    public static SaleTransaction? LastTransaction;
    public static bool HasLastTransaction = false;

    public static void NewTransaction()
    {
        SaleTransaction st = new();
        while (true)
        {
            Console.Write("Enter Invoice No: ");
            string input1 = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(input1))
            {
                st.InvoiceNo = input1;
                break;
            }
            Console.WriteLine("Invoice No cannot be empty.");
        }
    
        Console.Write("Customer Name: ");
        string customerName = Console.ReadLine()!;
        st.CustomerName = customerName;

        Console.Write("Item name: ");
        string itemName = Console.ReadLine()!;
        st.ItemName = itemName;
        
        Console.Write("Quantity: ");
        string input = Console.ReadLine() ?? "";
        if(!int.TryParse(input, out int quantity))
            Console.WriteLine("Invalid Format");
        if(quantity >= 0)
            st.Quantity = quantity;

        Console.Write("Purchase Amt: ");
        decimal purchaseAmt = Decimal.Parse(Console.ReadLine()!);
        if(purchaseAmt > 0)
            st.PurchaseAmt = purchaseAmt;   
        
        Console.Write("Selling Amt: ");
        decimal sellingAmt = Decimal.Parse(Console.ReadLine()!);
        if(sellingAmt >= 0)
            st.SellingAmt = sellingAmt;

        LastTransaction = st;
        HasLastTransaction = true;

        ProfitStatus();
        Console.WriteLine("Transaction created");
        Console.WriteLine($"Status: {LastTransaction.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amt: {LastTransaction.ProfitOrLossAmt:F2}");
        Console.WriteLine($"Profit Margin: {LastTransaction.ProfitMarginPercent:F2}");
    }

    public static void Display()
    {
        if (HasLastTransaction)
        {
            Console.WriteLine("Last Transaction");
            Console.WriteLine($"InvoiceNo: {LastTransaction.InvoiceNo}");
            Console.WriteLine($"Customer: {LastTransaction.CustomerName}");
            Console.WriteLine($"Item: {LastTransaction.ItemName}");
            Console.WriteLine($"Quantity: {LastTransaction.Quantity}");
            Console.WriteLine($"Purchase Amt: {LastTransaction.PurchaseAmt}");
            Console.WriteLine($"Selling Amt: {LastTransaction.SellingAmt}");
            Console.WriteLine($"Status: {LastTransaction.ProfitOrLossStatus}");
            Console.WriteLine($"Profit/loss Amt: {LastTransaction.ProfitOrLossAmt}:F2");
            Console.WriteLine($"Profit Margin (%): {LastTransaction.ProfitMarginPercent:2F}");
        } else
        {
            Console.WriteLine("No Transaction available");
        }
    }

    public static void ProfitStatus()
    {
        if (HasLastTransaction)
        {
            if(LastTransaction.SellingAmt > LastTransaction.PurchaseAmt){
                LastTransaction.ProfitOrLossStatus = "Profit";
                LastTransaction.ProfitOrLossAmt = LastTransaction.SellingAmt - LastTransaction.PurchaseAmt;
            }
            else if(LastTransaction.SellingAmt < LastTransaction.PurchaseAmt)
            {
                LastTransaction.ProfitOrLossStatus = "Loss";
                LastTransaction.ProfitOrLossAmt = LastTransaction.PurchaseAmt - LastTransaction.SellingAmt;
            }
            else
            {
                LastTransaction.ProfitOrLossStatus = "BREAK-EVEN";
                LastTransaction.ProfitOrLossAmt = 0;
            }
            LastTransaction.ProfitMarginPercent = (LastTransaction.ProfitOrLossAmt / LastTransaction.PurchaseAmt) * 100;
            Console.WriteLine($"Percentage: {LastTransaction.ProfitMarginPercent:F2}");
        }
        else
        {
            Console.WriteLine("No Transaction available.");
        }
    }

}