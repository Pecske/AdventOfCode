using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    class DayThree
    {
        private static readonly string PATH = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\..\..\..\DayThree\input.txt";
        private static readonly char TREE_SYMBOL = '#';


        public static List<string> ProcessInput()
        {
            return File.ReadAllLines(PATH).ToList<string>();
        }

        public static int FindPartOneSolution(List<string> inputLines)
        {
            Movement movement = new Movement(3, 1);
            return GetTrees(movement, inputLines);
        }

        public static double FindPartTwoSolution(List<string> inputLines)
        {
            List<Movement> movements = new List<Movement> { new Movement(1,1),
                                                            new Movement(3,1),
                                                            new Movement(5,1),
                                                            new Movement(7,1),
                                                            new Movement(1,2)
        };

            return movements
                  .Select(movement => GetTrees(movement, inputLines))
                  .Select(tree => Convert.ToDouble(tree))
                  .Aggregate((x, y) => x * y);                  
        }

        private static int GetTrees(Movement movement, List<string> map)
        {
            int column = 0;
            int treeCounter = 0;
            for (int i = movement.Horizontal; i < map.Count; i+=movement.Horizontal)
            {
                int newColumn = column + movement.Vertical;
                column = newColumn;
                string currentLine = map[i];
                if (newColumn> currentLine.Length-1)
                {
                    column = (newColumn-currentLine.Length);
                }
                if (currentLine[column].Equals(TREE_SYMBOL))
                {
                    treeCounter++;
                }
            }
            return treeCounter;
        }
        private class Movement
        {
            public int Vertical { get; set; }
            public int Horizontal { get; set; }

            public Movement(int vertical, int horizontal)
            {
                Vertical = vertical;
                Horizontal = horizontal;
            }
        }

    }
}
