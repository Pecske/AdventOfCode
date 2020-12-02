using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteDayOne();
            ExecuteDayTwo();
        }

        private static void ExecuteDayOne()
        {
            
            List<int> inputNumbers = DayOne.ReadAndProcessFile();

            int solutionOne = DayOne.FindPartOneSolution(inputNumbers);

            int solutionTwo = DayOne.FindPartTwoSolution(inputNumbers);

            WriteToConsole(solutionOne, solutionTwo);
        }

        private static void ExecuteDayTwo()
        {
            List<PasswordPolicy> passwordPolicies = DayTwo.ProcessInput();
            int solutionOne = DayTwo.FindPartOneSolution(passwordPolicies);

            int solutionTwo = DayTwo.FindPartTwoSolution(passwordPolicies);

            WriteToConsole(solutionOne, solutionTwo);


        }

        private static void WriteToConsole(int solutionOne, int solutionTwo)
        {
            Console.WriteLine("-------------PART ONE---------------");
            Console.WriteLine(solutionOne);
            Console.WriteLine("------------------------------------");

            Console.WriteLine("-------------PART TWO---------------");
            Console.WriteLine(solutionTwo);
            Console.WriteLine("------------------------------------");
        }
    }
}
