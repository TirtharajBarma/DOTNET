namespace LibrarySystem{
    
    namespace Items
    {
        abstract class LibraryItem
        {
            public String Title{get; set;}
            public String Author{get; set;}
            public int ItemId{get; set;}

            public abstract void Display();
            public abstract double Calculate(int days);
        }

        interface IReservable
        {
            void Reserving();
        }

        interface INotifiable
        {
            void Accepting(string msg);
        }

        class Book : LibraryItem, IReservable, INotifiable
        {
            public override void Display()
            {
                Console.WriteLine($"Book Title: {Title}, Author: {Author}, ItemId: {ItemId}");
            }

            public override double Calculate(int days)
            {
                return 1.0 * days;
            }

            void IReservable.Reserving()
            {
                Console.WriteLine("Reservation successful");
            }

            void INotifiable.Accepting(string msg)
            {
                Console.WriteLine($"{msg} Notification Message sent");
            }
        }

        class Magazine : LibraryItem
        {
            public override void Display()
            {
                Console.WriteLine($"Magazine Title: {Title}, Author: {Author}, ItemId: {ItemId}");
            }

            public override double Calculate(int days)
            {
                return 0.5 * days;
            }
        }

        class eBook : LibraryItem
        {
            public override double Calculate(int days)
            {
                return 0.8 * days;
            }

            public override void Display()
            {
                Console.WriteLine($"Book Title: {Title}, Author: {Author}, ItemId: {ItemId}");
            }

            public void Download()
            {
                Console.WriteLine("Download");
            }
        }
    }

    namespace Users
    {
        public enum UserRole
        {
            Admin,
            Librarian,
            Member
        }
        public enum ItemStatus
        {
            Available,
            Borrowed,
            Reserved,
            Lost
        }

        class Member
        {
            public string Name{get; set;}
            public UserRole Role{get; set;}
        }
    }

    partial class LibraryAnalytics
    {
        public static int totalBorrowedItem{get; set;}
    }

    partial class LibraryAnalytics
    {
        public static void Display()
        {
            Console.WriteLine($"Borrowed items: {totalBorrowedItem}");
        }
    }
}
