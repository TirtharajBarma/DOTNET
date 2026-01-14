using System;

namespace studentScholarship
{
    public delegate bool isEligibleforScholarship(Student std);
    public class Student
    {
        public int RollNo{set; get;}
        public string? Name{set; get;}
        public int Marks{set; get;}
        public char SportsGrade{set; get;}
        
        public static string GetEligibleStudents(List<Student> studentsList, isEligibleforScholarship isEligible)
        {
            List<string> list = new List<string>();

            foreach(var it in studentsList)
            {
                if(isEligible(it))
                    list.Add(it.Name);
            }
            return String.Join(", ", list);
        }
    }

    public class Program
    {
        public static bool ScholarshipEligibility(Student std)
        {
            if(std.Marks >= 80 && std.SportsGrade == 'A')
                return true;
            else
                return false;
        }
        public static void main()
        {
            List<Student> ls = new List<Student>();

            ls.Add(new Student { RollNo = 1, Name = "Raj", Marks = 75, SportsGrade = 'A' });
            ls.Add(new Student { RollNo = 2, Name = "Rahul", Marks = 82, SportsGrade = 'A' });

            string result = Student.GetEligibleStudents(
                ls,
                ScholarshipEligibility  
            );

            Console.WriteLine(result);
        }
    }
}