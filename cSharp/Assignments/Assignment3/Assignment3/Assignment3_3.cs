using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{

    //program to find salesDetails and total amount of the product per price and quantity
    class saleDetails
    {
        int salesNo, productNo, qty;
        double price, totalAmount=0;
        DateTime dateOfSale;

        public saleDetails(int salesNo, int productNo, double price, int qty, DateTime dateOfSale)
        {
            this.salesNo = salesNo;
            this.productNo = productNo;
            this.price = price;
            this.qty = qty;
            this.dateOfSale = dateOfSale;
        }

        public double sales(int qty, double price)
        {
           return totalAmount = price * (double)qty;
        }

        public void display()
        {
            Console.WriteLine($"Sales No is {salesNo}");
            Console.WriteLine($"Product No is {productNo}");
            Console.WriteLine($"Date of the Sale is {DateTime.Now}");
            Console.WriteLine($"Quantity of the Product is {qty}");
            Console.WriteLine($"Price of the product is {price}");
            Console.WriteLine($"Total Amount is {totalAmount}");
        }




    }

    class code
    {
        static void Main()
        {
            saleDetails s = new saleDetails(10, 101, 1000.12, 10, DateTime.Now);
            s.sales(10, 1000.12);
            s.display();
            Console.ReadLine();
        }
    }

    /*Output:
     *  Sales No is 10
        Product No is 101
        Date of the Sale is 6/24/2025 11:13:46 PM
        Quantity of the Product is 10
        Price of the product is 1000.12
        Total Amount is 10001.2 */
}
