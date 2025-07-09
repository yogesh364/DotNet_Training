using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeChallenge3
{
    class cricketTeam
    {
        public (int matchCount, int sum, double average) pointsCalculation(int noOfMatches)
        {
            int sum = 0;

            for (int i = 1; i <= noOfMatches; i++)
            {
                Console.Write("Enter the Score of the Match {0} : ", i);
                int score = Convert.ToInt32(Console.ReadLine());
                if (score < 0)
                {
                    throw new Exception("Enter a Valid Integer");
                }
                else
                {
                    sum += score;
                }
            }
            double average = sum / noOfMatches;
            return (noOfMatches, sum, average);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the No of Matched Played : ");
            int matches = Convert.ToInt32(Console.ReadLine());
            try
            {
                cricketTeam ct = new cricketTeam();
                var ans = ct.pointsCalculation(matches);

                Console.WriteLine($"The Total Number of Teams Played  : {ans.matchCount}");
                Console.WriteLine($"The Total Scores of the Match : {ans.sum}");
                Console.WriteLine($"The Average Scores of the Match : {ans.average}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
    }
}
