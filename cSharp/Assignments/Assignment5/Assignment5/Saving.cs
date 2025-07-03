using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    //program for doing transaction and throw exception if needed
    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }
    class accounts
    {
        int acc_No, money, balance = 0;
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

        public void getData()
        {
            try
            {
                Console.Write("Enter the Transaction type [credit/debit] : ");
                transaction_type = Console.ReadLine();
                if (transaction_type.ToLower() == "credit")
                {
                    Console.Write("Enter the amount to be credited to your account : ");
                    money = Convert.ToInt32(Console.ReadLine());
                    credit(money);

                }
                else if(transaction_type.ToLower() == "debit")
                {

                    Console.Write("Enter the amount to be debited from your account : ");
                    money = Convert.ToInt32(Console.ReadLine());
                    
                    if (balance <= 0 || balance < money)
                    {
                        throw new InsufficientBalanceException("You do not have enough Amount to Withdraw from Your Account");
                    }
                    else
                    {
                        debit(money);
                    }
                }
                else
                {
                    Console.WriteLine("Enter a Valid Input");
                }
            }
            catch(InsufficientBalanceException ibe)
            {
                Console.WriteLine(ibe.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
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
}
