using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_Finder_App
{
    public class Property
    {
        private const string realEstateDomain = "http://www.realestate.com.au/";

        public string GetUrl(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("Property url path is null");

            return string.Concat(realEstateDomain, path.Replace("/", ""));
        }
    }
}
