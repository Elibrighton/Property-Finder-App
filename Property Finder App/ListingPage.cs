using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_Finder_App
{
    public class ListingPage
    {
        public List<Property> Properties { get; set; }
        public int TotalResults { get; set; }
        public int TotalListings { get; set; }
        public List<string> PropertyUrls { get; set; }
        public string Url { get; set; }


        private const string realEstateDomain = "http://www.realestate.com.au/";
        private const int listingsPerPage = 20;
        
        private readonly string response;

        public ListingPage(string response, string url)
        {
            if (string.IsNullOrEmpty(response)) throw new ArgumentNullException("Listing Page Response is null");

            this.response = response;
            Url = url;
            Properties = new List<Property>();
            TotalResults = GetTotalResults();
            TotalListings = GetTotalListings(TotalResults);
            PropertyUrls = GetPropertyUrls();
        }

        public int GetTotalResults()
        {
            //<p>Showing 1 - 20 of 11308 total results</p>

            var totalResults = 0;
            var matchValue = RegexHelper.GetRegexMatchValue(response, @"\d*\stotal\sresults");
            matchValue = RegexHelper.GetRegexMatchValue(matchValue, @"^\d*");

            if (!string.IsNullOrEmpty(matchValue))
            {
                totalResults = Convert.ToInt32(matchValue);
            }

            return totalResults;
        }

        public int GetTotalListings(int totalResults)
        {
            var totalListings = 0;

            if (totalResults > 0)
            {
                totalListings = totalResults / listingsPerPage;

                if (totalResults % listingsPerPage > 0)
                {
                    totalListings++;
                }
            }

            return totalListings;
        }

        public List<string> GetPropertyUrls()
        {
            //<a href="/property-house-qld-upper+mount+gravatt-125119870" >

            var propertyUrls = new List<string>();
            var propertyPaths = RegexHelper.GetMatchesList(response, "/property-house-qld-\\D*\\d*\"\\s?>").Distinct().ToList();

            for (int i = 0; i < propertyPaths.Count; i++)
            {
                propertyUrls.Add(GetPropertyUrl(propertyPaths[i]));
            }

            return propertyUrls;
        }

        public string GetPropertyUrl(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("Property path is null");

            return string.Concat(realEstateDomain, path.Replace("/", "").Replace("\" >", "").Replace("\">", ""));
        }

        public void SetProperties()
        {
            foreach (var url in PropertyUrls)
            {
                var search = new Search();
                search.SetUrl(url);
                var response = search.GetWebResponse();
                var property = new Property(response);
                property.SetUrl(url);
                Properties.Add(property);
            }
        }
    }
}
