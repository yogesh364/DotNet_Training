using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    //program to take marks and fess of student and calculate scholarship of the student
    class NotValidMarks : Exception
    {
        public NotValidMarks(string message) : base(message)
        {

        }
    }
    class scholarship
    {
        double  scholar = 0;

        public void Merit(int mark, double fee)
        {
            if( mark >=70 && mark <= 80)
            {
                scholar = 0.20 * fee;
            }else if(mark >80 && mark<= 90)
            {
                scholar = 0.30 * fee;
            }else if(mark > 90)
            {
                scholar = 0.50 * fee;
            }
            else
            {
                throw new NotValidMarks("Enter the Valid Marks to calculate the Scholarship Amount ");
            }
        }
        static void Main()
        {
            scholarship sc = new scholarship();
            try
            {
                Console.Write("Enter the Fees of the student : ");
                double f = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter the Marks of the Student : ");
                int m = Convert.ToInt32(Console.ReadLine());

                sc.Merit(m, f);
                Console.WriteLine("The scholarship Alloted for the Student is : " + sc.scholar);
            }
            catch(NotValidMarks e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
    
}
