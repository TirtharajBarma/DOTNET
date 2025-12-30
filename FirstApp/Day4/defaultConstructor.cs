class Product
{
    public string Name = string.Empty;
    public int Price;

    public Product()
    {
        Console.WriteLine("Default constructor called");
    }                     

    public Product(string name, int price)   
    {
        Name = name;
        Price = price;
    }
}