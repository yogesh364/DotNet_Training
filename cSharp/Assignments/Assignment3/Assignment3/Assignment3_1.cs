using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    //program to get information from the user and update the balance amount depending upon the transaction
    class accounts
    {
        int acc_No, money, balance=0;
        string cust_name, acc_type;
        String transaction_type;

        public accounts(int acc_No, string cust_name, string acc_type) 
        {
            this.acc_No = acc_No;
            this.cust_name = cust_name;
            this.acc_type = acc_type;
        }

        public int credit(int amount)
        {
            return balance += amount;
        }

        public int debit(int amount)
        {
            return balance -= amount;
        }

        public void getData() {
            
            Console.Write("Enter the Transaction type [credit/debit] : ");
            transaction_type = Console.ReadLine();
            if (transaction_type == "credit")
            {
                Console.Write("Enter the amount to be credited to your account : ");
                money = Convert.ToInt32(Console.ReadLine());
                credit(money);
          
            }
            else
            {
                if (balance == 0)
                {
                    Console.WriteLine("You do not have enough Balance !!!");
                }
                else
                {
                    Console.Write("Enter the amount to be debited from your account : ");
                    money = Convert.ToInt32(Console.ReadLine());
                    debit(money);
                }
            }
        }
        public void showData()
        {
            Console.WriteLine($"Account Number is {acc_No}");
            Console.WriteLine($"Account Holder Name is {cust_name}");
            Console.WriteLine($"Account Type is {acc_type}");
            Console.WriteLine($"Remaining Balance in the Account is {balance}");
            Console.WriteLine("--------------Last Transaction was successful---------------");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            
            accounts a = new accounts(100, "Yogesh", "Savings");

            a.getData();
            a.showData();
            Console.ReadLine();
        }
    }
                /*  Output 1:
                 *  Enter the Transaction type [credit/debit] : credit
                    Enter the amount to be credited to your account : 500
                    Account Number is 100
                    Account Holder Name is Yogesh
                    Account Type is Savings
                    Remaining Balance in the Account is 100500
                    --------------Last Transaction was successful---------------

                    Output 2:
                    Enter the Transaction type [credit/deposit] : credit
                    Enter the amount to be credited to your account : 500
                    Account Number is 100
                    Account Holder Name is Yogesh
                    Account Type is Savings
                    Remaining Balance in the Account is 100500
                    --------------Last Transaction was successful--------------- */
}
