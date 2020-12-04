using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    class Passport
    {
        public Dictionary<PassportAttribute,string> Attribute { get; set; }

        public Passport()
        {
            Attribute = new Dictionary<PassportAttribute, string>();
        }

        public void AddItem(PassportAttribute key, string value)
        {
            Attribute.Add(key, value);
        }

        public bool IsAllAttributeValid()
        {
          return this.Attribute.All(pair => IsAttributeValid(pair.Key, pair.Value));            
        }

        private bool IsAttributeValid(PassportAttribute attribute, string value)
        {
            bool valid = false;
            switch (attribute)
            {
                case PassportAttribute.BYR:valid = isByrValid(value);
                    break;
                case PassportAttribute.IYR:
                    valid = IsIyrValid(value);
                    break;
                case PassportAttribute.EYR:
                    valid = IsEyrValid(value);
                    break;
                case PassportAttribute.HGT:
                    valid = IsHgtValid(value);
                    break;
                case PassportAttribute.HCL:
                    valid = IsHclValid(value);
                    break;
                case PassportAttribute.ECL:
                    valid = IsEclValid(value);
                    break;
                case PassportAttribute.PID:
                    valid = IsPidValid(value);
                    break;
                case PassportAttribute.CID:
                    valid = true;
                    break;
                default:
                    break;
            }

            return valid;
        }

        private bool isByrValid(string value)
        {
            int year = Convert.ToInt32(value);

            return year >= 1920 && year <= 2002;
        }

        private bool IsIyrValid(string value)
        {
            int year = Convert.ToInt32(value);

            return year >= 2010 && year <= 2020;
        }
        private bool IsEyrValid(string value)
        {
            int year = Convert.ToInt32(value);

            return year >= 2020 && year <= 2030;
        }
        private bool IsHgtValid(string value)
        {
            bool valid = false;
            int heightLength = value.Length - 2;
           int height= Convert.ToInt32(value.Substring(0, heightLength));
            string unit = value.Substring(heightLength);
            if (unit.Equals("cm"))
            {
                valid = height >= 150 && height <= 193;
            }
            else if (unit.Equals("in"))
            {
                valid = height >= 59 && height <= 76;
            }
            return valid;
        }

        private bool IsHclValid(string value)
        {
            string characterValidator = "#0123456789abdcdef";

            List<char> characters = value.ToList();

            return value.StartsWith("#") 
                && characters.All(character => characterValidator.Contains(character))
                && value.Length==7;
        }

        private bool IsEclValid(string value)
        {
            return ((EyeColor[])Enum.GetValues(typeof(EyeColor)))
                .Any(color => color.ToString().ToLower().Equals(value));
        }

        private bool IsPidValid(string value)
        {
            return value.Length==9;
        }

        private enum EyeColor
        {
            AMB,
            BLU,
            BRN,
            GRY,
            GRN,
            HZL,
            OTH
        }

        public override string ToString()
        {
            string line = "";
            return Attribute.Select(attribute => attribute.Key + ":" + attribute.Value+"\n").Aggregate((x, y) => x = x + y);
        }


    }
}
