using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class DayOne
    {
        private static readonly string PATH = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\..\..\..\DayOne\input.txt";
        private static readonly int NUMBER_TO_REACH = 2020;

        public static List<int> ReadAndProcessFile()
        {
            string[] inputs = File.ReadAllLines(PATH);
            return inputs
                .Select(line => ConvertString(line))
                .ToList();
        }
        private static int ConvertString(string convertable)
        {
            int number;
            int.TryParse(convertable, out number);
            return number;
        }
        
        public static int FindPartOneSolution(List<int> numberList)
        {
            int foundNumber = numberList.FirstOrDefault(number => numberList.Contains((NUMBER_TO_REACH-number)));
            return foundNumber * (NUMBER_TO_REACH - foundNumber);
        }

        public static int FindPartTwoSolution(List<int> numberList)
        {
            Solution solution = new Solution();
            bool solutionFound = false;
            for (int i = 0; i < numberList.Count-2 && !solutionFound; i++)
            {
                for (int j = 1; j < numberList.Count-1 && !solutionFound; j++)
                {
                    int sum = numberList[i] + numberList[j];
                    if (sum<NUMBER_TO_REACH && numberList.Contains(NUMBER_TO_REACH - sum))
                    {
                        solution = new Solution(numberList[i],numberList[j],NUMBER_TO_REACH-sum);
                        solutionFound = true;
                    }
                }
            }
            return solution.GetMulipliedValue();
        }
        private class Solution
        {      
            public int numberOne { get; set; }
            public int numberTwo { get; set; }
            public int numberThree { get; set; }
            public Solution(int numberOne, int numberTwo, int numberThree)
            {
                this.numberOne = numberOne;
                this.numberTwo = numberTwo;
                this.numberThree = numberThree;
            }

            public Solution()
            {
            }

            public int GetMulipliedValue()
            {
                return this.numberOne * this.numberTwo * this.numberThree;
            }
        }

        


    }
}
