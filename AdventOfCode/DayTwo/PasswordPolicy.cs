using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    class PasswordPolicy
    {
        public PasswordPolicy(int min, int max, char singleCharacter, string password)
        {
            Min = min;
            Max = max;
            SingleCharacter = singleCharacter;
            Password = password;
        }

        public int Min { get; set; }
        public int Max { get; set; }
        public char SingleCharacter { get; set; }
        public string Password { get; set; }

    }
}
