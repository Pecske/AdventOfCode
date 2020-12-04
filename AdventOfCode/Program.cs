using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //   ExecuteDayOne();
            //   ExecuteDayTwo();
            //  ExecuteDayThree();
              ExecuteDayFour();
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

        private static void ExecuteDayThree()
        {
            List<string> inputLines = DayThree.ProcessInput();
            int solutionOne = DayThree.FindPartOneSolution(inputLines);
            double solutionTwo = DayThree.FindPartTwoSolution(inputLines);

            WriteToConsole(solutionOne, solutionTwo);

        }

        private static void ExecuteDayFour()
        {
            List<Passport> passportList = DayFour.ProcessInput();

            int solutionOne = DayFour.FindPartOneSolution(passportList);
            int solutionTwo = DayFour.FindPartTwoSolution(passportList);
            WriteToConsole(solutionOne, solutionTwo);

        }

        private static void WriteToConsole(double solutionOne, double solutionTwo)
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
