using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Distance_Finder;
using Property_Finder_App;
using System.IO;

namespace Distance_Finder_Tests
{
    [TestClass]
    public class DistanceFinderTests
    {
        private DistanceFinder testDistanceFinder;
        private string testDistanceResponse;

        [TestInitialize]
        public void Initialize()
        {
            testDistanceFinder = new DistanceFinder();
            testDistanceResponse = File.ReadAllText(@"C:\Users\Dj Music\Documents\Visual Studio 2015\Projects\Property Finder App\Supplied files\TestDistanceResponse.html");

        }

        [TestMethod]
        public void GetAddressQuery_AddressQueryReturned_Test()
        {
            // Arrange
            var testAddress = new Address
            {
                StreetAddress = "139 Sumners Rd",
                AddressLocality = "Jamboree Heights",
                AddressRegion = "Qld",
                PostalCode = "4074"
            };
            var expectedAddressQuery = "139+Sumners+Rd,+Jamboree+Heights+QLD+4074";

            // Act
            var actualAddressQuery = testDistanceFinder.GetAddressQuery(testAddress);

            // Assert
            Assert.AreEqual(expectedAddressQuery, actualAddressQuery);
        }

        [TestMethod]
        public void GetUrl_UrlReturned_Test()
        {
            // Arrange
            var testStartingAddress = new Address
            {
                StreetAddress = "Central Station",
                AddressLocality = "Brisbane City",
                AddressRegion = "Qld",
                PostalCode = "4000"
            };
            var testDestinationAddress = new Address
            {
                StreetAddress = "139 Sumners Rd",
                AddressLocality = "Jamboree Heights",
                AddressRegion = "Qld",
                PostalCode = "4074"
            };
            //var expectedUrl = "https://www.google.com.au/maps/dir/Central+Station,+Brisbane+City+QLD+4000/139+Sumners+Rd,+Jamboree+Heights+QLD+4074/";
            var expectedUrl = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=Central+Station,+Brisbane+City+QLD+4000&destinations=139+Sumners+Rd,+Jamboree+Heights+QLD+4074";

            // Act
            var actualUrl = testDistanceFinder.GetUrl(testStartingAddress, testDestinationAddress);

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        //[TestMethod]
        //public void GetWebResponse()
        //{
        //    // Arrange
        //    //var testUrl = "https://www.google.com.au/maps/dir/Central+Station,+Brisbane+City+QLD+4000/139+Sumners+Rd,+Jamboree+Heights+QLD+4074/";
        //    var testUrl = "https://www.google.com.au/maps/dir/Central+Station,+Brisbane+City+QLD+4000/9+Carolina+Parade,+Forest+Lake+QLD+4078/";

        //    // Act
        //    var actualResponse = testDistanceFinder.GetWebResponse(testUrl);

        //    // Assert
        //    Assert.AreEqual(testDistanceResponse, actualResponse);
        //}

        [TestMethod]
        public void GetDistance_DistanceReturned_Test()
        {
            // Arrange
            var expectedDistance = 18.0f;

            // Act
            var actualDistance = testDistanceFinder.GetDistance(testDistanceResponse);

            // Assert
            Assert.AreEqual(expectedDistance, actualDistance);
        }
    }
}
