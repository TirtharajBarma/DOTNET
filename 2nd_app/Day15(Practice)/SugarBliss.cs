using System;
using System.Diagnostics;

namespace SugarBliss
{
    class Chocolate
    {
        public string? Flavour{set; get;}
        public int Quantity{set; get;}
        public int PricePerUnit{set; get;}
        public double TotalPrice{set; get;}
        public double DiscountedPrice{set; get;}

        public bool ValidateChocolateFlavour()
        {
            if (Flavour == "Dark" || Flavour == "Milk" || Flavour == "White")
                return true;
            else
                return false;
        }
    }

    class Program
    {
        public static Chocolate CalculateDiscountedPrice(Chocolate chocolate)
        {
            double discountPercentage = 0.0;
            chocolate.TotalPrice = chocolate.Quantity * chocolate.PricePerUnit;
            
            if(chocolate.Flavour == "Dark")
                discountPercentage = 18;
            else if(chocolate.Flavour == "Milk")
                discountPercentage = 12;
            else
                discountPercentage = 6;
            
            chocolate.DiscountedPrice = chocolate.TotalPrice - (chocolate.TotalPrice * discountPercentage / 100);

            return chocolate;
        }

        public static void main()
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.WriteLine("Application started");
            try {
                Chocolate chocolate = new Chocolate();
                chocolate.Flavour = Console.ReadLine()!;
                chocolate.Quantity = Convert.ToInt32(Console.ReadLine());
                chocolate.PricePerUnit = Convert.ToInt32(Console.ReadLine());

                if(!chocolate.ValidateChocolateFlavour())
                    Console.WriteLine("false");
                else
                {
                    chocolate = CalculateDiscountedPrice(chocolate);
                    Console.WriteLine("Flavour : " + chocolate.Flavour);
                    Console.WriteLine("Quantity : " + chocolate.Quantity);
                    Console.WriteLine("Price Per Unit : " + chocolate.PricePerUnit);
                    Console.WriteLine("Total Price : " + chocolate.TotalPrice);
                    Console.WriteLine("Discounted Price : " + chocolate.DiscountedPrice);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Exception occurred: " + ex.Message);
            }
            Trace.WriteLine("Application ended");
        }
    }
}
