using System;

sealed class Security
{
    public void message()
    {
        Console.WriteLine("Authentication successful");
    }
}

abstract class InsurancePolicy
{
    public int Policy_Number{get; init;}
    public string PolicyHolderName{get; set;}

    private double _premium;
    public double Premium
    {
        get => _premium; 
        protected set
        {
            if(value <= 0) throw new Exception();
            _premium = value;
        }
    }

    public virtual void CalculatePremium()
    {
        Console.WriteLine("premium from InsurancePolicy");
    }

    public void display()
    {
        Console.WriteLine("generic policy information");
    }
}

class LifeInsurance : InsurancePolicy
{
    private readonly double LifeCharge = 500;
    public override void CalculatePremium()
    {
        Premium += LifeCharge;
    }

    public new void display()
    {
        Console.WriteLine("generic policy information");
    }
}

class HealthInsurance : InsurancePolicy
{
    public sealed override void CalculatePremium()
    {
        Premium *= 1.6;
    }
}

class PolicyDirectory
{
    private List <InsurancePolicy> pol = [];
    // -> whose types IS Insurance Policy
    
    public void AddPolicy(InsurancePolicy policy)
    {
        pol.Add(policy);
    }
    // Internally
    // pol
    // ├── [0] → LifeInsurance object
    // └── [1] → HealthInsurance object

    public InsurancePolicy this[int index]
    {
        get => pol[index];
    }

    public InsurancePolicy this[string name]
    {
        get => pol.FirstOrDefault(p => p.PolicyHolderName == name);
    }
}

// PolicyDirectory dir = new PolicyDirectory();

// LifeInsurance life = new LifeInsurance();
// HealthInsurance health = new HealthInsurance();

// dir.AddPolicy(life);
// dir.AddPolicy(health);