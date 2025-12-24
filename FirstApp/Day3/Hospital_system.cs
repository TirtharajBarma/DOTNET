class Patient
{
    private readonly int _patientId;
    public string? Name { get; set; }
    public int Age { get; set; }
    private string? MedicalHistory;
    public int PatientId
    {
        get => _patientId;
    }

    public Patient(int PatientId){
        _patientId = PatientId;
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
    public void basicAppointment(string str)
    {
        Console.WriteLine($"appointment: {str}");
    }
    public void basicAppointment(string str, int data)
    {
        Console.WriteLine($"appointment: {str}, date: {data}");
    }

    public void basicAppointment(string str, int data, int mode)
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

        static string determineRisk(double avg, int patientAge)
        {
            if(avg > 80 && patientAge < 40)
                return "Low Risk";
            else if(avg > 50)
                return "Medium Risk";
            else
                return "High Risk";
        }

        double averageScore = CalculateAvg();
        if(averageScore < 50)
            condition = "Critical";
        else
            condition = "Stable";
        
        risk = determineRisk(averageScore, age);
    }
}

class Bill
{
    
}


