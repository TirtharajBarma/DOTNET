using System;

public delegate string ReportGenerator(string patientName);
public delegate void HospitalAlert(string msg);
public delegate void HospitalNotificationHandler(string msg, DateTime time);

class HospitalNotifier
{
    public event HospitalNotificationHandler? PatientAdmitted; //3

    public void AdmitPatient(string name)       //1
    {
        PatientAdmitted?.Invoke($"{name} admitted successfully", DateTime.Now); //2
    }
}

class AdministrationDepartment
{
    public void Notify(string msg, DateTime time)   //4
    {
        Console.WriteLine($"[ADMIN] {msg} | dateTime: {time}");
    }
}

class Program
{
    static public string GenerateDischargeSummary(string patientName)
    {
        return $"Discharge summary generated for {patientName}";
    }

    static public void SendSmsAlert(string msg)
    {
        Console.WriteLine($"sms alert: {msg}");
    }

    static public void SendEmailAlert(string msg)
    {
        Console.WriteLine($"email alert: {msg}");
    }
    static public void SendDashboardAlert(string msg)
    {
        Console.WriteLine($"dashboard alert: {msg}");
    }

    public static void main()
    {
        ReportGenerator rg = GenerateDischargeSummary;
        string summary = rg("Rahul");
        Console.WriteLine(summary);

        HospitalAlert alert;
        alert = SendSmsAlert;
        alert += SendDashboardAlert;
        alert += SendEmailAlert;
        alert("Emergency patient detected");

        HospitalNotifier notifier = new HospitalNotifier();
        AdministrationDepartment admin = new AdministrationDepartment();
        notifier.PatientAdmitted += admin.Notify;
        notifier.AdmitPatient("Meera");

        Func<double, double, double> CalculateBill = (consultation, test) =>
        {
            return consultation + test;
        };
        double total = CalculateBill(600, 1800);
        Console.WriteLine($"total bill: {total}");

        Action<string> logAction = msg => Console.WriteLine($"log label: {msg}");
        logAction("Billing process completed");

        Predicate<int> isSeniorCitizen = age =>
        {
            if(age >= 60)
                return true;
            else
                return false;
        };
        Console.WriteLine(isSeniorCitizen(65));
    }
}