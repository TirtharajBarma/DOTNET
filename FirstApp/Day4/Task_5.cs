using System;

class Students
{
    //Task1 -> set only from class not from outside
    public int Reg_no{get; private set;}
    public Students(int val)
    {
        Reg_no = val;
    }

    //Task2 -> set value only at the time of object creation
    public int AdmissionYear {get; init;}
    // object-initializer not s.AdmissionYear = 2024; 

    // Task3 -> expression-bodied property    
    private double _marks;      //! storage
    public double Marks         //! logic/access control
    {
        get => _marks;
        set
        {
            if (value >= 0 && value <= 100)
                _marks = value;
        }
    }
    public double Percentage => _marks;
}
        // 1️⃣ Create object using constructor
        // Students s = new Students(101)
        // {
        //     // 2️⃣ init property → allowed ONLY here
        //     AdmissionYear = 2003
        // };

        // // 3️⃣ set normal property
        // s.Marks = 85.5;

        // // 4️⃣ read values
        // Console.WriteLine("Registration No: " + s.Reg_no);
        // Console.WriteLine("Admission Year: " + s.AdmissionYear);
        // Console.WriteLine("Marks: " + s.Marks);
        // Console.WriteLine("Percentage: " + s.Percentage);

        // // 5️⃣ Try invalid marks (will be ignored)
        // s.Marks = 150;
        // Console.WriteLine("Marks after invalid input: " + s.Marks);

        // ❌ NOT allowed (uncomment to see compile error)
        // s.AdmissionYear = 2004;
        // s.Reg_no = 999;

