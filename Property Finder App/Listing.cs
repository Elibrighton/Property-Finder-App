using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_Finder_App
{
    public class Listing
    {
        public List<string> ListingPageUrls { get; set; }
        public List<ListingPage> ListingPages { get; set; }
        public int TotalResults { get; set; }
        public int TotalListings { get; set; }

        private readonly string url;
        private Search search;
        private string response;
        private ListingPage listingPage;

        public Listing(string url)
        {
            this.url = url;
            search = new Search();
            search.SetUrl(url);
            response = search.GetWebResponse();
            listingPage = new ListingPage(response);
            listingPage.SetProperties();
            TotalResults = listingPage.TotalResults;
            TotalListings = listingPage.TotalListings;
            ListingPageUrls = GetListingPageUrls(TotalListings);
            ListingPages = GetListingPages(ListingPageUrls);
        }

        public List<string> GetListingPageUrls(int totalListings)
        {
            var listingPageUrls = new List<string>();

            for (int i = 0; i < totalListings; i++)
            {
                var listingPageUrl = url.Replace(string.Concat("list-", i), string.Concat("list-", i + 1));
                listingPageUrls.Add(listingPageUrl);
            }

            return listingPageUrls;
        }

        public List<ListingPage> GetListingPages(List<string> listingPageUrls)
        {
            var listingPages = new List<ListingPage>();

            foreach (var listingPageUrl in listingPageUrls)
            {
                search = new Search();
                search.SetUrl(url);
                response = search.GetWebResponse();
                listingPage = new ListingPage(response);
                listingPage.SetProperties();
                listingPages.Add(listingPage);
            }

            return listingPages;
        }
    }
}
