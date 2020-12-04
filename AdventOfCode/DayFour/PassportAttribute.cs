using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    enum PassportAttribute
    {
        BYR,
        IYR,
        EYR,
        HGT,
        HCL,
        ECL,
        PID,
        CID
    }

    static class AttributeExtension
    {
        public static PassportAttribute GetAttribute(string attributeString)
        {
            List<PassportAttribute> attributes = new List<PassportAttribute>((PassportAttribute[])Enum.GetValues(typeof(PassportAttribute)));
             return attributes.Find(attribute => attribute.ToString().ToLower().Equals(attributeString));
        }
    }
}
