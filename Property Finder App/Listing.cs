﻿using System;
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
        public List<Property> Properties { get; set; }
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
            listingPage = new ListingPage(response, url);
            listingPage.SetProperties();
            TotalResults = listingPage.TotalResults;
            TotalListings = listingPage.TotalListings;
            ListingPageUrls = GetListingPageUrls(TotalListings);
            ListingPages = GetListingPages(ListingPageUrls);
            Properties = GetProperties(ListingPages);
        }

        private List<Property> GetProperties(List<ListingPage> listingPages)
        {
            var properties = new List<Property>();

            foreach (var listingPage in listingPages)
            {
                foreach (var property in listingPage.Properties)
                {
                    properties.Add(property);
                }
            }

            return properties;
        }

        public List<string> GetListingPageUrls(int totalListings)
        {
            var listingPageUrls = new List<string>();
            var listingPageUrl = url;
            listingPageUrls.Add(listingPageUrl);

            for (int i = 1; i < totalListings; i++)
            {
                var currentList = string.Concat("list-", i);
                var nextList = string.Concat("list-", i + 1);
                listingPageUrl = listingPageUrl.Replace(currentList, nextList);
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
                search.SetUrl(listingPageUrl);
                response = search.GetWebResponse();
                listingPage = new ListingPage(response, listingPageUrl);
                listingPage.SetProperties();// add to constructor
                listingPages.Add(listingPage);
            }

            return listingPages;
        }
    }
}
