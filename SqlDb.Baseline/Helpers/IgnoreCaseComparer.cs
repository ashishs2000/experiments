using System;
using System.Collections.Generic;

namespace SqlDb.Baseline.Helpers
{
    public class IgnoreCaseComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.Equals(y, StringComparison.CurrentCultureIgnoreCase);
        }

        public int GetHashCode(string obj)
        {
            return 0;
        }
    }
}