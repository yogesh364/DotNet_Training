using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_CC1
{
    class Program
    {
        static void Main(string[] args)
        {
            businesslogic bl = new businesslogic();
            // bl.insertEmp();

            bl.update_salary();
            Console.Read();
        }
    }
}
