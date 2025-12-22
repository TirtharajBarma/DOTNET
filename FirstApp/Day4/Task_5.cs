using System;

class Students
{
    private int reg_no, admissionYear;
    private double marks;

    // set only from class not from outside
    public int Reg_no{get; private set;}
    public Students(int val)
    {
        Reg_no = val;
    }

    // set value only at the time of object creation
    public int AdmissionYear {get; init;}

    public double Marks
    {
        get => marks;
        set
        {
            if (value >= 0 && value <= 100)
                marks = value;
        }
    }
    public double Percentage => marks;
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



// class Account
// {
//     public int AccountNo { get; private set; }

//     public Account(int accNo)
//     {
//         AccountNo = accNo;
//     }
// }

// class Student
// {
//     public int RollNo { get; init; }
//     public string Name { get; init; }
// }

// class Rectangle
// {
//     public double Length { get; set; }
//     public double Width { get; set; }
//     public double Area => Length * Width;
// }

// Expression-Bodied Properties

// what are all these 3 block of code
