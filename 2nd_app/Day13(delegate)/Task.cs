namespace EcommerceAssessment
{
    class Repository<T>
    {
        private List<T> list = new List<T>();

        public void Add(T item)
        {
            list.Add(item);
        }

        public List<T> GetALL()
        {
            return list;
        }
    }

    class Order
    {
        public int OrderId{get; set;}
        public string? CustomerName{get; set;}
        public double Amount{get; set;}

        public override string ToString()
        {
            return $"OrderId: {OrderId}, CustomerName: {CustomerName}, Amount: {Amount}";
        }
    }
    public delegate void OrderCallback(string message);

    class OrderProcessor
    {
        public event Action<String>? OrderProcessed;

        public void ProcessOrder(Order order, Func<double, double> taxCalculator, Func<double, double> discountCalculator, Predicate<Order> validator, OrderCallback callback) 
        {
            if (!validator(order))
            {
                callback("Order validation failed");
                return;
            }
            double tax = taxCalculator(order.Amount);
            double discount = discountCalculator(order.Amount);
            order.Amount = order.Amount + tax - discount;
            callback($"Order {order.OrderId} processed");
            OrderProcessed?.Invoke($"Event: Order {order.OrderId}");
        }
    }

    class Program
    {
        public static void main()
        {
            Repository<Order> repo = new Repository<Order>();
            repo.Add(new Order{OrderId = 1, CustomerName = "xyz", Amount = 5000});
            repo.Add(new Order{OrderId = 2, CustomerName = "abc", Amount = 2000});
            repo.Add(new Order{OrderId = 3, CustomerName = "ijk", Amount = 8000});

            OrderProcessor process = new OrderProcessor();
            Func<double, double> taxCalculator = amt => amt * 0.18;
            Func<double, double> discountCalculator = amt =>
            {
                if(amt > 5000)
                    return amt * 0.10;
                else
                    return amt * 0.05;
            };
            Predicate<Order> validator = order => order.Amount >= 2500;
            OrderCallback callback = msg => Console.WriteLine($"Callback: {msg}");

            Action<string> logger = msg => Console.WriteLine($"Logger: Event {msg}");
            Action<string> notifier = msg => Console.WriteLine($"Notifier: Event {msg}");

            process.OrderProcessed += logger;
            process.OrderProcessed += notifier;

            foreach(Order orders in repo.GetALL())
            {
                process.ProcessOrder(orders, taxCalculator, discountCalculator, validator, callback);
            }

            List<Order> order = repo.GetALL();
            order.Sort((o1, o2) => o2.Amount.CompareTo(o1.Amount));
            Console.WriteLine("SortedOrder: ");
            foreach(var it in order)
                Console.WriteLine(it);
        }
    }
}