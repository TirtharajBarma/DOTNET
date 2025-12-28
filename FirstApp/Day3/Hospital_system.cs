class Patient
{
    private readonly int _patientId;
    public string? Name { get; set; }
    public int Age { get; set; }
    private string? MedicalHistory;
    
    // Default constructor
    public Patient()
    {
        _patientId = 0;
        Name = "Unknown";
        Age = 0;
    }

    // Parameterized constructor
    public Patient(int patientId, string name, int age)
    {
        _patientId = patientId;
        Name = name;
        Age = age;
    }

    public Patient(int PatientId){
        _patientId = PatientId;
    }

    public int PatientId
    {
        get => _patientId;
    }


    public void setMedicalHistory(string str)
    {
        this.MedicalHistory = str;
    }

    public string retrieveMedicalHistory()
    {
        return MedicalHistory;
    }
}

class Doctor
{
    public string Name{get; set;}
    public string Specialization{get; set;}
    public int LicenseNumber {get;}         // read-only

    static private int _totalDoctor;
    public static int TotalDoctor => _totalDoctor;

    static Doctor(){
        _totalDoctor = 10;
        Console.WriteLine("Static Constructor");
    }

    public Doctor(int licenseNumber)
    {
        LicenseNumber = licenseNumber;
        _totalDoctor++;
        Console.WriteLine("Normal Constructor");
    }
}

class Appointment
{
    public void ScheduleAppointment(string str)
    {
        Console.WriteLine($"appointment: {str}");
    }
    public void ScheduleAppointment(string str, int data)
    {
        Console.WriteLine($"appointment: {str}, date: {data}");
    }

    public void ScheduleAppointment(string str, int data, int mode)
    {
        Console.WriteLine($"appointment: {str}, date: {data}, mode: {mode}");
    }
}

class MedicalRecord
{
    private string? diagnosis, history;

    public string getDiagnosis()
    {
        return diagnosis;
    }
    public void setDiagnosis(string diagnosis)
    {
        this.diagnosis = diagnosis;
    }
}

class DiagnosisService
{
    public void Diagnose(in int age, ref string condition, out string risk, params int[] score)
    {
        double CalculateAvg()
        {
            int sum = 0;
            foreach(var it in score)
                sum += it;
            
            return (double) sum / score.Length;
        }

        double averageScore = CalculateAvg();
        if(averageScore < 50)
            condition = "Critical";
        else
            condition = "Stable";

        static string determineRisk(double avg, int patientAge)
        {
            if(avg > 80 && patientAge < 40)
                return "Low Risk";
            else if(avg > 50)
                return "Medium Risk";
            else
                return "High Risk";
        }

        risk = determineRisk(averageScore, age);
    }
}

class Bill
{
    public double ConsultationFee{set; get;}
    public double TestCharges{set; get;}
    public double RoomCharges{set; get;}

    // Full bill calculation
    public double BillCalculate()
    {
        return ConsultationFee + TestCharges + RoomCharges;
    }

    // Billing without room charges
    public double BillCalculate(double consultationFee, double testCharges)
    {
        return consultationFee + testCharges;
    }

    // Billing with only consultation fee
    public double BillCalculate(double consultationFee)
    {
        return consultationFee;
    }
}

class Insurance
{
    public int PolicyNumber { get; private set; }
    public double CoveragePercentage { get; private set; }

    public int CalculatePayableAmount(double totalBill)
    {
        string policyInput = "1001"; 
        PolicyNumber = int.Parse(policyInput);      // Parse

        Console.Write("Enter insurance coverage percentage: ");
        string? coverageInput = Console.ReadLine();

        if (!double.TryParse(coverageInput, out double coverage))   // Try-parse
        {
            Console.WriteLine("Invalid coverage input. No insurance applied.");
            CoveragePercentage = 0;
        }
        else
        {
            CoveragePercentage = coverage;
        }

        double coverageAmount = (CoveragePercentage / 100) * totalBill; // implicit
        int coveredAmount = (int)coverageAmount;    // explicit
        int finalPayable = Convert.ToInt32(totalBill) - coveredAmount;   // convert

        return finalPayable;
    }
}

static class HospitalStayCalculator
{
    public static int CalculateTotalStay(this int days)
    {
        // Base case
        if (days <= 0)
            return 0;

        // Recursive case
        return 1 + CalculateTotalStay(days - 1);
    }
}

class InputHelper
{
    public static void ValidateAge(int age)
    {
        if (age <= 0)
            throw new ArgumentException("Patient age must be greater than zero.");
    }

    public static void ValidateBillingAmount(double amount)
    {
        if (amount < 0)
            throw new ArgumentException("Billing amount cannot be negative.");
    }
}


// class Program
// {
//     static void Main()
//     {
//         // Task 2: Patient
//         Patient patient = new Patient(101, "Amit", 30);
//         InputHelper.ValidateAge(patient.Age);
//         patient.setMedicalHistory("Diabetes");

//         Console.WriteLine($"Patient ID   : {patient.PatientId}");
//         Console.WriteLine($"Patient Name : {patient.Name}");
//         Console.WriteLine($"Patient Age  : {patient.Age}");

//         // Task 3: Doctor
//         Doctor doctor1 = new Doctor(5551);
//         Doctor doctor2 = new Doctor(5552);

//         Console.WriteLine($"Total Doctors: {Doctor.TotalDoctor}");

//         // Task 4: Appointment
//         Appointment appointment = new Appointment();
//         appointment.ScheduleAppointment("General Checkup");
//         appointment.ScheduleAppointment("Dental", 20250101);
//         appointment.ScheduleAppointment("Surgery", 20250102, 1);

//         // Task 6: Diagnosis
//         DiagnosisService diagnosisService = new DiagnosisService();
//         string condition = "Unknown";
//         diagnosisService.Diagnose(
//             patient.Age,
//             ref condition,
//             out string risk,
//             70, 80, 90
//         );

//         Console.WriteLine($"Condition : {condition}");
//         Console.WriteLine($"Risk      : {risk}");

//         // Task 7: Billing
//         Bill bill = new Bill
//         {
//             ConsultationFee = 500,
//             TestCharges = 1200,
//             RoomCharges = 3000
//         };

//         double totalBill = bill.BillCalculate();
//         InputHelper.ValidateBillingAmount(totalBill);
//         Console.WriteLine($"Total Bill : {totalBill}");

//         // Task 8: Insurance
//         Insurance insurance = new Insurance();
//         int payableAmount = insurance.CalculatePayableAmount(totalBill);
//         Console.WriteLine($"Final Payable Amount: {payableAmount}");

//         // Task 9: Hospital Stay (Recursion) Extension
//         int totalStay = 5;
//         Console.WriteLine($"Total Hospital Stay Days: {totalStay.CalculateTotalStay()}");

//         Console.WriteLine("=== System Execution Completed ===");
//     }
// }
