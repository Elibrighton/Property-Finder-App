using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Property_Finder_App;
using System.IO;
using System.Collections.Generic;

namespace PropertyFinderTests
{
    [TestClass]
    public class ListingPageTests
    {
        private ListingPage testListingPage;
        private string testSearchResponse;

        [TestInitialize]
        public void Initialize()
        {
            testSearchResponse = File.ReadAllText(@"C:\Users\Dj Music\Documents\Visual Studio 2015\Projects\Property Finder App\PropertyFinderTests\Supplied files\TestSearchResponse.html");
            testListingPage = new ListingPage(testSearchResponse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Listing Page Response is null")]
        public void GetListingPageObject_ArgumentNullExceptionRaised_Test()
        {
            // Arrange

            // Act
            var testListingPage = new ListingPage(string.Empty);

            // Assert
        }

        [TestMethod]
        public void GetTotalResults_TotalHomeReturned_Test()
        {
            // Arrange
            var expectedTotalResults = 11308;

            // Act
            var actualTotalResults = testListingPage.GetTotalResults();

            // Assert
            Assert.AreEqual(expectedTotalResults, actualTotalResults);
        }

        [TestMethod]
        public void GetTotalListings_TotalListingsReturnedZero_Test()
        {
            // Arrange
            var testTotalResult = 0;
            var expectedTotaListings = 0;

            // Act
            var actualTotalHomes = testListingPage.GetTotalListings(testTotalResult);

            // Assert
            Assert.AreEqual(expectedTotaListings, actualTotalHomes);
        }

        [TestMethod]
        public void GetTotalListings_1TotalListingReturned_Test()
        {
            // Arrange
            var testTotalResults = 20;
            var expectedTotalListings = 1;

            // Act
            var actualTotalListings = testListingPage.GetTotalListings(testTotalResults);

            // Assert
            Assert.AreEqual(expectedTotalListings, actualTotalListings);
        }

        [TestMethod]
        public void GetTotalListings_TotalListingsReturned2_Test()
        {
            // Arrange
            var testTotalResults = 21;
            var expectedTotalListings = 2;

            // Act
            var actualTotalListings = testListingPage.GetTotalListings(testTotalResults);

            // Assert
            Assert.AreEqual(expectedTotalListings, actualTotalListings);
        }

        [TestMethod]
        public void GetPropertyUrls_PropertyUrlsReturned_Test()
        {
            // Arrange
            var expectedPropertyUrls = new List<string>()
                {
                    "http://www.realestate.com.au/property-house-qld-upper+mount+gravatt-125119870",
                    "http://www.realestate.com.au/property-house-qld-stafford-125119566",
                    "http://www.realestate.com.au/property-house-qld-kedron-125118974",
                    "http://www.realestate.com.au/property-house-qld-graceville-125118530",
                    "http://www.realestate.com.au/property-house-qld-sunnybank-125117498",
                    "http://www.realestate.com.au/property-house-qld-new+farm-124919330",
                    "http://www.realestate.com.au/property-house-qld-aspley-125117566",
                    "http://www.realestate.com.au/property-house-qld-camp+hill-125117530",
                    "http://www.realestate.com.au/property-house-qld-brighton-125117378",
                    "http://www.realestate.com.au/property-house-qld-kelvin+grove-125117386",
                    "http://www.realestate.com.au/property-house-qld-new+farm-125117098",
                    "http://www.realestate.com.au/property-house-qld-yeronga-125117014",
                    "http://www.realestate.com.au/property-house-qld-fairfield-125116802",
                    "http://www.realestate.com.au/property-house-qld-wakerley-124854238",
                    "http://www.realestate.com.au/property-house-qld-wakerley-124633458",
                    "http://www.realestate.com.au/property-house-qld-heathwood-124819522"
                };

            // Act
            var actualPropertyUrls = testListingPage.GetPropertyUrls();

            // Assert
            Assert.AreEqual(expectedPropertyUrls.Count, actualPropertyUrls.Count);
            Assert.AreEqual(expectedPropertyUrls[0], actualPropertyUrls[0]);
            Assert.AreEqual(expectedPropertyUrls[1], actualPropertyUrls[1]);
            Assert.AreEqual(expectedPropertyUrls[2], actualPropertyUrls[2]);
            Assert.AreEqual(expectedPropertyUrls[3], actualPropertyUrls[3]);
            Assert.AreEqual(expectedPropertyUrls[4], actualPropertyUrls[4]);
            Assert.AreEqual(expectedPropertyUrls[5], actualPropertyUrls[5]);
            Assert.AreEqual(expectedPropertyUrls[6], actualPropertyUrls[6]);
            Assert.AreEqual(expectedPropertyUrls[7], actualPropertyUrls[7]);
            Assert.AreEqual(expectedPropertyUrls[8], actualPropertyUrls[8]);
            Assert.AreEqual(expectedPropertyUrls[9], actualPropertyUrls[9]);
            Assert.AreEqual(expectedPropertyUrls[10], actualPropertyUrls[10]);
            Assert.AreEqual(expectedPropertyUrls[11], actualPropertyUrls[11]);
            Assert.AreEqual(expectedPropertyUrls[12], actualPropertyUrls[12]);
            Assert.AreEqual(expectedPropertyUrls[13], actualPropertyUrls[13]);
            Assert.AreEqual(expectedPropertyUrls[14], actualPropertyUrls[14]);
            Assert.AreEqual(expectedPropertyUrls[15], actualPropertyUrls[15]);
        }
        
        [TestMethod]
        public void GetPropertyUrl_PropertyUrlReturned_Test()
        {
            // Arrange
            var testPath = "/property-house-qld-upper+mount+gravatt-125119870";
            var expectedPropertyUrl = "http://www.realestate.com.au/property-house-qld-upper+mount+gravatt-125119870";

            // Act
            var actualPropertyUrl = testListingPage.GetPropertyUrl(testPath);

            // Assert
            Assert.AreEqual(expectedPropertyUrl, actualPropertyUrl);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Property path is null")]
        public void GetPropertyUrl_ArgumentNullExceptionRaised_Test()
        {
            // Arrange
            var testPath = string.Empty;

            // Act
            var actualPropertyUrl = testListingPage.GetPropertyUrl(testPath);

            // Assert
        }
    }
}
