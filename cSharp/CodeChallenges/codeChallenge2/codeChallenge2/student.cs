using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeChallenge2
{
    abstract class student
    {
        public string name;
        public int studentId;
        public double grade;

        public student(string Name, int StudentId, double Grade)
        {
            this.name = Name;
            this.studentId = StudentId;
            this.grade = Grade;
        }
        
        public abstract bool isPassed(double grade);

    }

    class underGratuate : student
    {
        public underGratuate(string Name, int StudentId, double Grade): base(Name, StudentId, Grade) { }
        public override bool isPassed(double grade)
        {
            return grade >= 70.0;
        }
    }

    class graduate : student
    {
        public graduate(string Name, int StudentId, double Grade) : base(Name,StudentId,Grade) { }
        public override bool isPassed(double grade)
        {
            return grade >= 80.0;
        }
    }
    class main
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Name of the Student : ");
            string name = Console.ReadLine();

            Console.Write("Enter the student ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the Grade of the Student : ");
            double grade = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the Graduation of student [UnderGraduate/Graduate] : ");
            string degree = Console.ReadLine();

            if (degree.ToLower() == "undergraduate")
            {
                student ug = new underGratuate(name, id, grade);
                Console.WriteLine($"The result of the Student {name} is : ");
                string str = ug.isPassed(grade) == true ? "Pass" : "Fail";
                Console.Write(str);
            }
            else if(degree.ToLower() == "graduate")
            {
                student pg = new graduate(name, id, grade);
                Console.WriteLine($"The result of the Student {name} is : ");
                string str = pg.isPassed(grade) == true ? "Pass" : "Fail";
                Console.Write(str);
            }
            else
            {
                Console.WriteLine("Enter a Valid graduation Type");
            }

            Console.ReadLine();
        }
    }
}
