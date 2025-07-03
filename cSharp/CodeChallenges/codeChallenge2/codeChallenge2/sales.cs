using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeChallenge2
{
    class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
    }

    class Sales
    {
        static void Main()
        {
            List<Product> products = new List<Product>();

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Enter the product details:");

                Console.Write("Enter the Product ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the Product Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter the Product Price: ");
                double price = Convert.ToDouble(Console.ReadLine());
                products.Add(new Product{ ProductID = id,ProductName = name,ProductPrice = price});
            }

            products.Sort((a, b) => a.ProductPrice.CompareTo(b.ProductPrice));

            Console.WriteLine("The product Details after Sorting....");

            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductID}, Name: {product.ProductName}, Price: {product.ProductPrice}");
            }

            Console.ReadLine();
        }
    }
}
