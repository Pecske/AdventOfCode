using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    class DayTwo
    {
        private static readonly int MAX_OCCURENCES = 1;

        private static readonly string PATH = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\..\..\..\DayTwo\input.txt";
        public static List<PasswordPolicy> ProcessInput()
        {
            string[] inputs = File.ReadAllLines(PATH);
            return inputs
                .Select(line => CreatePasswordPolicy(line))
                .ToList();
        }

        public static int FindPartOneSolution(List<PasswordPolicy> passwordPolicies)
        {
            return passwordPolicies.Count(password => IsRightPassword(password));
        }

        private static bool IsRightPassword(PasswordPolicy passwordPolicy)
        {
            int characterNumber = passwordPolicy.Password.Count(character => character == passwordPolicy.SingleCharacter);
            return (characterNumber >= passwordPolicy.Min) && (characterNumber <= passwordPolicy.Max);
        }

        private static PasswordPolicy CreatePasswordPolicy(string line)
        {
            int firstSeparator = line.IndexOf("-");
            int secondSeparator = line.IndexOf(" ");

            int min = Convert.ToInt32(line.Substring(0, firstSeparator));
            int max = Convert.ToInt32(line.Substring(firstSeparator + 1, (secondSeparator - firstSeparator)));
            char character = Convert.ToChar(line.Substring(secondSeparator + 1, 1));
            firstSeparator = line.IndexOf(":");
            string password = line.Substring(firstSeparator + 2);

            return new PasswordPolicy(min, max, character, password);

        }

        public static int FindPartTwoSolution(List<PasswordPolicy> passwordPolicies)
        {
            return passwordPolicies.Count(password => IsRightPasswordPartTwo(password));
        }

        private static bool IsRightPasswordPartTwo(PasswordPolicy passwordPolicy)
        {
            int counter = 0;
            if (passwordPolicy.Password[passwordPolicy.Min - 1] == passwordPolicy.SingleCharacter)
            {
                counter++;
            }
            if (passwordPolicy.Password[passwordPolicy.Max - 1] == passwordPolicy.SingleCharacter)
            {
                counter++;
            }

            return MAX_OCCURENCES == counter;
        }
    }
}
