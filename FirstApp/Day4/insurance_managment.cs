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
    private double LifeCharge = 500;
    public override void CalculatePremium()
    {
        Premium = Premium + LifeCharge;
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
        Premium = Premium * 1.6;
    }
}

class PolicyDirectory
{
    private List <InsurancePolicy> pol = [];
    
    public void AddPolicy(InsurancePolicy policy)
    {
        pol.Add(policy);
    }

    public InsurancePolicy this[int index]
    {
        get => pol[index];
    }

    public InsurancePolicy this[string name]
    {
        get
        {
            foreach(var policy in pol)
            {
                if(policy.PolicyHolderName == name)
                    return policy;
            }
            return null;
        }
    }
}

