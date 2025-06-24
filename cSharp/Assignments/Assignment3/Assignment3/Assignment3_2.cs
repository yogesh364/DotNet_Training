using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    //program to get student details and display the result of the student with details 
    class student
    {
        private int rollNo;
        public int total=0, avg;
        private string name, cl, semester, branch;
        int check = 1;
        int[] marks = new int[5];

        public student(int rollNo,string name, string cl, string semester, string branch)
        {
            this.rollNo = rollNo;
            this.name = name;
            this.cl = cl;
            this.semester = semester;
            this.branch = branch;
        }

        public void getMarks()
        {
            for(int i = 0; i < 5; i++){
                Console.Write("Enter the Mark {0} : ",i+1);
                marks[i] = Convert.ToInt32(Console.ReadLine());

                if (marks[i] < 35) check = 0;

                total += marks[i];
            }
            avg = total / 5;
        }

        public void displayResult()
        {
            String result = (check == 0) ? "Failed" :(check == 1 && avg<50) ?"Failed" :"Passed";
            Console.WriteLine(result);
        }

        public void showData()
        {
            Console.WriteLine($"Student name is {name}");
            Console.WriteLine($"Student Roll No is {rollNo}");
            Console.WriteLine($"Student Class is {cl}");
            Console.WriteLine($"Student is in Semester {semester}");
            Console.WriteLine($"Student is from branch {branch}");
            Console.WriteLine("Marks of the student is " + string.Join(",", marks));
            Console.WriteLine($"Total Marks of the student is {total}");
            Console.WriteLine($"Average Mark of the student is {avg}");
            displayResult();
        }

        
    }


    class program
    {
        static void Main()
        {
            student s = new student(100, "Yogesh", "ECE", "8", "B.E");
            s.getMarks();
            s.showData();
            Console.Read();
        }

        /* Output :
         *  Enter the Mark 1 : 39
            Enter the Mark 2 : 65
            Enter the Mark 3 : 78
            Enter the Mark 4 : 91
            Enter the Mark 5 : 84
            Student name is Yogesh
            Student Roll No is 100
            Student Class is ECE
            Student is in Semester 8
            Student is from branch B.E
            Marks of the student is 39,65,78,91,84
            Total Marks of the student is 357
            Average Mark of the student is 71
            Passed */
    }
}
