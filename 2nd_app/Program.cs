// See https://aka.ms/new-console-template for more information
using AutonomousRobot.AI;
using CalculatorDLL;
class Program1
{
    public static async Task Main()
    {
        // Console.WriteLine("Creating object....");
        // for(int i = 0; i < 5; i++)
        // {
        //     Garbage g = new Garbage();
        // }
        // Console.WriteLine("Forcing garbage collection...");
        // GC.Collect();
        // GC.WaitForPendingFinalizers();

        // Console.WriteLine("Garbage collection completed..");

        //* anomalous type
        // Tuple.cal();
        // Linq.cal();
        // GarbageCollection.cal();

        //! Day-12
        // StringBuilder1.cal();

        //! Day-13 [Delegate]
        //* Payment.cs
        // PaymentSystem ps = new PaymentSystem();
        // PaymentDelegate pd;     
        // pd = ps.ProcessPayment;         //* delegate assignment
        // pd(4000);

        // PaymentSystem ps = new PaymentSystem();
        // // PaymentDelegate pd = ps.ProcessPayment; // assign delegate to method
        // PaymentDelegate pd = null!;
        // pd += ps.ProcessPayment;
        // pd += ps.RTGS;

        // decimal amt = 5000;
        // if (amt.isValid())
        //     pd(amt);
        // else 
        //     Console.WriteLine("no amt.");

        //* Action Delegates
        // Action<string> LogActivity = message => Console.WriteLine($"Log message {message}");
        // LogActivity("User logged in at 10.20AM");

        //* Function delegate
        // Func<decimal, decimal, decimal> calculateDiscount = (price, discount) => price - (price * discount / 100);

        // Console.WriteLine("Function delegate: " + calculateDiscount(1000, 10));

        // //* Predicate delegate
        // Predicate<int> isEligible = age => age >= 18;
        // Console.WriteLine(isEligible(17));

        //* Event delegate [eventDelegates.cs]
        // Button btn = new Button();
        // // btn.Clicked += () => Console.WriteLine("Button was clicked");    //* lambda
        // btn.Clicked += ButtonClick;     //* static method [down]
        // btn.Click();

        //* [delegates.cs]
        // SmartHomeSecurity.Program.main();

        //* [notification.cs]
        // CallbackDemo.Program.main();

        //* Comparison delegate
        // Comparison<int> sortDescending = (a, b) => b.CompareTo(a);
        // Console.WriteLine(sortDescending(10, 5));       //* -1
        // Console.WriteLine(sortDescending(5, 10));    //* +1
        // Console.WriteLine(sortDescending(5, 5));     //* 0

        // EcommerceAssessment.Program.main();
        // FileExample.cal();
        // StreamExample.cal();
        // SugarBliss.Program.main();
        // debugging.Program.main();
        // AutonomousRobot.AI.Program.main();

        //! day-17
        // AssemblyExample.AssemblyDemo.Run();
        // ReflectionExample.TypeDemo.Run();

        //! day-18
        // Threading.Program.main();
        // Threading1.Program.main();
        // await async.Program.main();
        // await file.Program.main();

        //! day-19
        // process.cal();
        // Join.main();
        // process1.Program.main();
        // MiniSocialMedia.Program.main();

        //! day-20
        Calculator c = new Calculator();
        Console.WriteLine(c.add(8, 2));
        Console.WriteLine(c.sub(8, 2));
    }

    static void ButtonClick()
    {
        Console.WriteLine("Button was Click");
    }
}
