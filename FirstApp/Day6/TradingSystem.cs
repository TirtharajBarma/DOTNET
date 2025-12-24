namespace Trading
{
    struct PriceSnapshot{
        public string? Symbol;
        public double Price;
    }

    abstract class Trade
    {
        public int TradeId;
        public string? StockSymbol;
        public double Quantity;

        abstract public double CalculateValue();
        public override string ToString()
        {
            return $"TradeId: {TradeId}, StockSymbol: {StockSymbol}, Quantity: {Quantity}";
        }
    }

    // EquityTrade "IS-A Trade"
    // can a EquityTrade object be treated as Trade obj -> YES
    class EquityTrade : Trade
    {
        public double? MarketPrice = null;

        public override double CalculateValue()
        {
            return (MarketPrice ?? 0.0) * Quantity;
        }
    }

    // It must be "Trade" or "Child of Trade"
    class TradeRepository<T> where T : Trade
    {
        private List<T> trades = new List<T>();

        public void Add(T Trade)
        {
            trades.Add(Trade);
            TradeAnalytics.TotalTrade++;
        }
        public void DisplayAll()
        {
            foreach(var it in trades)
            {
                Console.WriteLine(it);
            }
        }

    }

    static class TradeAnalytics
    {
        static public int TotalTrade;

        static public void DisplayAnalytics()
        {
            Console.WriteLine($"Total Trade: {TotalTrade}");
        }
    }

    static class FinancialCalculations 
    {
        public static double BrokerageCalculations(this double val)
        {
            return val * 0.001;
        }
        public static double TaxCalculations(this double charge)
        {
            return charge * 0.18;
        }
    }

    static class TradeProcess
    {
        // I can accept anything that "IS-A Trade"
        public static void Process(Trade trade)
        {
            if(trade is EquityTrade eq)
            {
                double TradeValue = eq.CalculateValue();

                double brokerage = TradeValue.BrokerageCalculations();
                double gst = brokerage.TaxCalculations();

                Console.WriteLine("Processing Equity Trade");
                Console.WriteLine($"Calculate: {TradeValue}");
                Console.WriteLine($"Brokerage: {brokerage}");
                Console.WriteLine($"GST: {gst}");
                Console.WriteLine(eq);
            }
        }
    }
}





