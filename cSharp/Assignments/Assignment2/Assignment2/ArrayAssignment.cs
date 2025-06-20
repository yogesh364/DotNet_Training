using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class ArrayAssignment
    {   
        public static void Main()
        {
            Console.WriteLine("-------------Finding Min and Max value in an array----------------");
            minMax();
            Console.WriteLine("-----------------------------");

            Console.WriteLine("-------------Finding total,average,min,max,ascending and descending order of array----------------");
            totAvg();
            Console.WriteLine("-----------------------------");

            Console.WriteLine("-------------Copy of array----------------");
            copyArray();
            Console.WriteLine("-----------------------------");
            
            
            Console.Read();
        }

        //Average value of Array elements, Minimum and Maximum value in an array
        public static void minMax()
        {
            Console.Write("Enter the length of the array : ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for(int i = 0; i < n; i++)
            {
                Console.Write("Enter the value of array in index {0} : ", i);
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            float avg=0;
            Array.Sort(arr);
            foreach(int i in arr)
            {
                avg += i;   
            }
            avg /= n;
            int min = arr[0], max = arr[n - 1];
            Console.WriteLine("The average of the Array is : "+avg);
            Console.WriteLine("The Minimum value of the Array is : "+min);
            Console.WriteLine("The Maximum value of the Array is : "+max);

            /* Output 
             *  The average of the Array is : 2.5
                The Minimum value of the Array is : 1
                The Maximum value of the Array is : 4
            */
        }

        //Total, Average, Minimum marks, Maximum marks, Display marks in ascending order, Display marks in descending order

        public static void totAvg()
        {
            int n = 10;
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Enter the mark {0}: ", i);
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Array.Sort(arr);
            int tot=0, min, max;
            float avg = 0;

            foreach(int i in arr)
            {
                tot += i;
            }
            avg = tot / n;
            min = arr[0];
            max = arr[n - 1];
            Console.WriteLine("The Total Value of the Array is : " + tot);
            Console.WriteLine("The average of the Array is : " + avg);
            Console.WriteLine("The Minimum of the Array is : " + min);
            Console.WriteLine("The Maximum of the Array is : " + max);
            Console.WriteLine("The Array in Ascending Order is : " + string.Join(",",arr));
            Array.Reverse(arr);
            Console.WriteLine("The Array in Descending Order is : " + string.Join(",", arr));

            /* Output ;
             *  The Total Value of the Array is : 55
                The average of the Array is : 5.5
                The Minimum of the Array is : 1
                The Maximum of the Array is : 10
                The Array in Ascending Order is : 1,2,3,4,5,6,7,8,9,10
                The Array in Descending Order is : 10,9,8,7,6,5,4,3,2,1  */
        }

        //Write a C# Sharp program to copy the elements of one array into another array.
        public static void copyArray()
        {
            int n = 10;
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Enter the mark {0}: ", i);
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            int[] arr1 = new int[n];
            for(int i=0;i<n;i++)
            {
                arr1[i] = arr[i];
            }
            Console.WriteLine("The elements in Array1 is : " + string.Join(",", arr1));
            Console.WriteLine("The elements in Array2 after copying from Array1 is : " + string.Join(",", arr1));

            /*Output :
             *  The elements in Array1 is : 2,3,4,5,6,7,8,9,10,1
                The elements in Array2 after copying from Array1 is : 2,3,4,5,6,7,8,9,10,1 */
        }



    }
}
