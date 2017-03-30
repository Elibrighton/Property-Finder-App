using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Property_Finder_App
{
    public class RegexHelper
    {
        public static string GetRegexMatchValue(string text, string pattern)
        {
            var match = string.Empty;
            var r = new Regex(pattern, RegexOptions.IgnoreCase);
            Match m = r.Match(text);

            if (m.Success)
            {
                match = m.Value;
            }

            return match;
        }
    }
}
