// See https://aka.ms/new-console-template for more information
using System;
using ItemAlias = LibrarySystem.Items;
using LibrarySystem;
using LibrarySystem.Users;
using LibrarySystem.Items;
using Trading;

class Area
{
    static void Main(string[] args)
    {
        // AOC.Calculate();
        // Feet.Calculate();
        // Second.Calculate();
        // Conditional.cal();
        // While.cal();
        // DoWhile.cal();
        // ForLoop.cal();
        // Continue.cal();
        // Loan.cal();
        // Financial.Run();


        //! DAY-4
        //* Deposit d = new(5, 6.5, 10000);
        // [ it call "Bank class" then "Deposit class" ]

        // Deposit d1 = new Deposit(5, 6.5, 10000);
        // Deposit d2 = new Deposit(3, 5.0, 5000);


        //! parameterized constructor vs default constructor
        // Product p = new Product          //! This is object initializer not parameterized constructor
        // {
        //     Name = "Laptop",
        //     Price = 50000
        // };

        //! indexer overloading
        // Library library = new Library();

        // // 2️⃣ Add books using INTEGER indexer
        // library[101] = "C# Basics";
        // library[102] = "Java Fundamentals";
        // library[103] = "Python Programming";

        // // 3️⃣ Retrieve using Book ID (int indexer)
        // Console.WriteLine(library[101]);   // C# Basics
        // Console.WriteLine(library[102]);   // Java Fundamentals

        // // 4️⃣ Retrieve using Book Title (string indexer)
        // Console.WriteLine(library["C# Basics"]);          // C# Basics
        // Console.WriteLine(library["Python Programming"]); // Python Programming

        // // 5️⃣ Check behavior when NOT found
        // Console.WriteLine(library[999]);        // Book Id not found
        // Console.WriteLine(library["Data"]);     // Book Title not fo

        //! Day-5
        // ItemAlias.Book book = new ItemAlias.Book
        // {
        //     Title = "C# Fundamentals",
        //     Author = "John Doe",
        //     ItemId = 101
        // };

        // ItemAlias.Magazine magazine = new ItemAlias.Magazine
        // {
        //     Title = "tech Today",
        //     Author = "Jane Doe",
        //     ItemId = 201
        // };

        // Console.WriteLine();
        // book.Display();
        // Console.WriteLine($"fine: {book.Calculate(3)}");

        // magazine.Display();
        // Console.WriteLine($"fine: {magazine.Calculate(3)}");
        // Console.WriteLine();

        // IReservable r = book;
        // r.Reserving();

        // INotifiable n = book;
        // n.Accepting("Book ready to pickup");
        // Console.WriteLine();

        // //* polymorphism
        // List<ItemAlias.LibraryItem> items = [
        //     book,
        //     magazine
        // ];

        // foreach(var it in items)    // "it" is of type Library item not Book or Magazine
        // {
        //     it.Display();
        // }
        // Console.WriteLine();

        // Console.WriteLine("Static members are used to share data across all objects.");
        // LibraryAnalytics.totalBorrowedItem = 5;
        // LibraryAnalytics.Display();
        // Console.WriteLine();

        // eBook e = new eBook
        // {
        //     Title = "Leaning c#",
        //     Author = "jane",
        //     ItemId = 102,
        // };

        // e.Display();
        // e.Download();
        // Console.WriteLine();
        
        // //* enum
        // ItemStatus status = ItemStatus.Borrowed;
        // UserRole role = UserRole.Librarian;

        // Member m = new Member
        // {
        //     Name = "Alex",
        //     Role = role
        // };

        // Console.WriteLine(m.Name);
        // Console.WriteLine($"User Role: {m.Role}");
        // Console.WriteLine($"Item Status: {status}\n");

        //! Day-6
        // StockPrice sp1 = new StockPrice
        // {
        //     StockSymbol = "SBI",
        //     Price = 450.80  
        // };

        // StockPrice copiedSp1 = sp1;     // create object copy [different memory]
        // copiedSp1.Price = 230.90;

        // Console.WriteLine($"original struct: {sp1.Price}");
        // Console.WriteLine($"copied struct: {copiedSp1.Price}");
        // Console.WriteLine();

        // Trade t1 = new Trade
        // {
        //     TradeId = 123,
        //     StockSymbol = "ICICI",
        //     Quantity = 100
        // };

        // Trade copiedT1 = t1;        // by reference [same memory]
        // copiedT1.Quantity = 200;

        // Console.WriteLine($"original class: {t1.Quantity}");
        // Console.WriteLine($"original struct: {copiedT1.Quantity}");

        //! Task-6
        PriceSnapshot Ps = new PriceSnapshot
        {
            Symbol = "SBI",
            Price = 120.90  
        };
        Console.WriteLine($"Stock Symbol: {Ps.Symbol}");
        Console.WriteLine($"Stock Price: {Ps.Price}");

        TradeRepository<EquityTrade> rep = new TradeRepository<EquityTrade>();

        EquityTrade t1 = new EquityTrade
        {
            TradeId = 1,
            StockSymbol = "AAPL",
            Quantity = 100,
            MarketPrice = 150.50 
        };
        EquityTrade t2 = new EquityTrade
        {
            TradeId = 2,
            StockSymbol = "MSFT",
            Quantity = 50,
            MarketPrice = null
        };

        rep.Add(t1);
        rep.Add(t2);

        TradeProcess.Process(t1);
        Console.WriteLine();
        TradeProcess.Process(t2);
        Console.WriteLine();

        TradeAnalytics.DisplayAnalytics();


    }
}

// method overriding -> virtual, overridden
// method hiding -> new

// overriding
// overloading