using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    class DayFour
    {
        private static readonly string PATH = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\..\..\..\DayFour\input.txt";

        public static List<Passport> ProcessInput()
        {
            string[] inputLines = File.ReadAllLines(PATH);
            List<Passport> passports = new List<Passport>();
            Passport passport = new Passport();

            for (int i = 0; i < inputLines.Length; i++)
            {

                if (inputLines[i] != "")
                {
                    List<string> attributeList = inputLines[i].Split(" ").ToList();
                    for (int j = 0; j < attributeList.Count; j++)
                    {
                        string[] keyValue = attributeList[j].Split(":");
                        PassportAttribute key = AttributeExtension.GetAttribute(keyValue[0]);
                        passport.AddItem(key, keyValue[1]);
                    }
                }
                else
                {
                    passports.Add(passport);
                    passport = new Passport();
                }
            }
            return passports;
        }

        public static int FindPartOneSolution(List<Passport> passports)
        {
            return passports.Count(passport => IsProperPassport(passport));
        }

        public static int FindPartTwoSolution(List<Passport> passports)
        {
            return passports.Count(passport => (IsProperPassport(passport) && passport.IsAllAttributeValid()));
        }

        private static bool IsProperPassport(Passport passport)
        {
            int attributeCount = Enum.GetValues(typeof(PassportAttribute)).Length;
            bool hasAllAttribute = passport.Attribute.Count == attributeCount;

            bool cidMissing = passport.Attribute.Count == attributeCount - 1 && !passport.Attribute.ContainsKey(PassportAttribute.CID);

            return cidMissing || hasAllAttribute;
        }
    }
}

