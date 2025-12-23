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
        // // 2️⃣ Create Life Insurance Policy
        // LifeInsurance life = new LifeInsurance
        // {
        //     Policy_Number = 101,
        //     PolicyHolderName = "Amit",
        // };
        // life.Premium = 2000;          // allowed (protected set, inside derived logic)
        // life.CalculatePremium();      // adds LifeCharge

        // // 3️⃣ Create Health Insurance Policy
        // HealthInsurance health = new HealthInsurance
        // {
        //     Policy_Number = 102,
            // PolicyHolderName = "Ravi",
        // };
        // health.Premium = 3000;
        // health.CalculatePremium();    // multiplies premium

        // // 4️⃣ Add policies to directory
        // dir.AddPolicy(life);
        // dir.AddPolicy(health);

        // // 5️⃣ Access using indexer (int)
        // InsurancePolicy p1 = dir[0];
        // Console.WriteLine(p1.PolicyHolderName);

        // // 6️⃣ Access using indexer (string)
        // InsurancePolicy p2 = dir["Ravi"];
        // Console.WriteLine(p2.Policy_Number);

        // // 7️⃣ Polymorphism in action
        // p1.CalculatePremium();  // calls LifeInsurance version
        // p2.CalculatePremium();  // calls HealthInsurance version