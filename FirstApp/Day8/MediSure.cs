using System;

class PatientBill
{
    public string BillId { get; set; } = "";
    public string PatientName { get; set; } = "";
    public bool HasInsurance { get; set; }

    public decimal ConsultationFee { get; set; }
    public decimal LabCharges { get; set; }
    public decimal MedicineCharges { get; set; }

    public decimal GrossAmount { get; private set; }
    public decimal DiscountAmount { get; private set; }
    public decimal FinalPayable { get; private set; }

    public void CalculateBill()
    {
        GrossAmount = ConsultationFee + LabCharges + MedicineCharges;

        if (HasInsurance)
            DiscountAmount = GrossAmount * 0.10m;
        else
            DiscountAmount = 0;

        FinalPayable = GrossAmount - DiscountAmount;
    }
}

static class BillingService
{
    public static PatientBill? LastBill;            //* IMPORTANT
    public static bool HasLastBill = false;

    public static void CreateBill()
    {
        PatientBill bill = new PatientBill();

        Console.Write("Enter Bill Id: ");
        bill.BillId = Console.ReadLine() ?? "";

        if (bill.BillId == "")
        {
            Console.WriteLine("Bill Id cannot be empty.");
            return;
        }

        Console.Write("Enter Patient Name: ");
        bill.PatientName = Console.ReadLine() ?? "";

        Console.Write("Is the patient insured? (Y/N): ");
        string insuranceInput = Console.ReadLine() ?? "N";
        bill.HasInsurance = insuranceInput.Equals("Y", StringComparison.OrdinalIgnoreCase);

        Console.Write("Enter Consultation Fee: ");
        bill.ConsultationFee = decimal.Parse(Console.ReadLine()!);

        Console.Write("Enter Lab Charges: ");
        bill.LabCharges = decimal.Parse(Console.ReadLine()!);

        Console.Write("Enter Medicine Charges: ");
        bill.MedicineCharges = decimal.Parse(Console.ReadLine()!);

        bill.CalculateBill();

        LastBill = bill;
        HasLastBill = true;

        Console.WriteLine("\nBill created successfully.");
        Console.WriteLine($"Gross Amount: {bill.GrossAmount:F2}");
        Console.WriteLine($"Discount Amount: {bill.DiscountAmount.ToString("F2")}");
        Console.WriteLine($"Final Payable: {bill.FinalPayable:F2}");
    }

    public static void ViewLastBill()
    {
        if (!HasLastBill || LastBill == null)
        {
            Console.WriteLine("No bill available. Please create a new bill first.");
            return;
        }

        Console.WriteLine("\n----------- Last Bill -----------");
        Console.WriteLine($"BillId: {LastBill.BillId}");
        Console.WriteLine($"Patient: {LastBill.PatientName}");
        Console.WriteLine($"Insured: {(LastBill.HasInsurance ? "Yes" : "No")}");
        Console.WriteLine($"Consultation Fee: {LastBill.ConsultationFee:F2}");
        Console.WriteLine($"Lab Charges: {LastBill.LabCharges:F2}");
        Console.WriteLine($"Medicine Charges: {LastBill.MedicineCharges:F2}");
        Console.WriteLine($"Gross Amount: {LastBill.GrossAmount:F2}");
        Console.WriteLine($"Discount Amount: {LastBill.DiscountAmount:F2}");
        Console.WriteLine($"Final Payable: {LastBill.FinalPayable:F2}");
    }

    public static void ClearLastBill()
    {
        LastBill = null;
        HasLastBill = false;
        Console.WriteLine("Last bill cleared.");
    }
}