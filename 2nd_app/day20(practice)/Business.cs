using System;

namespace Sales
{
    public class Customer
    {
        public int Customer_id{get; set;}
        public string? First_name{get; set;}
        public string? Last_name{get; set;}
        public int Phone{get; set;}
        public string? Email{get; set;}
        public string? Street{get; set;}
        public string? City{get; set;}
        public string? State{get; set;}
        public int Zip_Code{get; set;}
        public List<Orders> Orders{get; set;} = new();
    }

    public class Orders
    {
        public int Order_id{get; set;}
        public int Customer_id{get; set;}
        public Customer? Customer{get; set;}        // navigation property
        public DateTime Order_date{get; set;}
        public DateTime Required_date{get; set;}
        public DateTime Shipped_date{get; set;}
        public int Store_id{get; set;}
        public int Staff_id{get; set;}
    }

    public class Staff
    {
        public int Staff_id{get; set;}
        public string? First_name{get; set;}
        public string? Last_name{get; set;}
        public int Phone{get; set;}
        public string? Email{get; set;}
        public bool Active{get; set;}
        public int Store_id{get; set;}
        public Stores? Store{get; set;}
        public int Manager_id{get; set;}
        public Staff? Manager { get; set; }
        public List<Staff>? Subordinates { get; set; }
        public List<Orders> Orders{get; set;} = new();      // 1 staff many orders
    }
    
    public class Stores
    {
        public int Store_id{get; set;}
        public string? Store_name{get; set;}
        public int Phone{get; set;}
        public string? Email{get; set;}
        public string? City{get; set;}
        public string? State{get; set;}
        public int Zip_Code{get; set;}
        public List<Staff> Staffs { get; set; } = new();
        public List<Orders> Orders { get; set; } = new();
    }

    public class Order_Items
    {
        public int Order_Item_id{get; set;}
        public int Order_id{get; set;}
        public Orders? Order { get; set; }
        public int Product_id{get; set;}
        public decimal Quantity{get; set;}
        public decimal List_price{get; set;}
        public decimal Discount{get; set;}
    }

}