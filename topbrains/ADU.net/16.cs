using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AdoNetDataReaderExample
{
    // Product Model
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }

    class Program
    {
        private static string connectionString =
            "Server=localhost,1433;Database=adu .net;User Id=sa;Password=StrongPassword@123;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            List<Product> products = GetProducts();

            foreach (var item in products)
            {
                Console.WriteLine($"{item.ProductId} - {item.ProductName} - {item.Price}");
            }

            Console.ReadLine();
        }

        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductId, ProductName, Price FROM Product";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product p = new Product
                        {
                            ProductId = Convert.ToInt32(reader["ProductId"]),
                            ProductName = reader["ProductName"].ToString(),
                            Price = Convert.ToDecimal(reader["Price"])
                        };

                        products.Add(p);
                    }
                }
            }

            return products;
        }
    }
}