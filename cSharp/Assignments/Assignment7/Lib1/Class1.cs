using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib1
{
    public class Class1
    {
        public const int totalFare = 5000;

        
        public void calculateConcession(int age)
        {

            if(age <= 5)
            {
                Console.WriteLine("Little Champs - Free Ticket");
            }else if(age > 60)
            {
                double res = totalFare * 0.3;
                double finRes = totalFare - res;
                Console.WriteLine("Senior Citizen - Calculated Fare : " + finRes);
            }
            else
            {
                Console.WriteLine("Ticket Booked - Calculated Fare : "+totalFare);
            }
            
        }

    }
}
