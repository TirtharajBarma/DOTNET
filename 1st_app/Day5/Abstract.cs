abstract class Enemy
{
    public int health = 100; // Abstract classes can have variables

    // You only write it ONCE here.
    public void TakeDamage(int amount)
    {
        health -= amount;
        Console.WriteLine($"Ouch! Health is now {health}");
    }

    // We don't know HOW they attack yet, so we leave this "Abstract"
    public abstract void Attack(); 
}

class Zombie : Enemy
{
    public override void Attack() 
    {
        Console.WriteLine("Biting!");
    }
}