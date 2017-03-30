using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Property_Finder_App;
using System.IO;

namespace PropertyFinderTests
{
    [TestClass]
    public class PropertyFinderTests
    {
        private PropertyFinder TestPropertyFinder;
        private string TestResponse;

        [TestInitialize]
        public void Initialize()
        {
            TestPropertyFinder = new PropertyFinder();

            // Open the file to read from.
            TestResponse = File.ReadAllText(@"C:\Users\Dj Music\Documents\Visual Studio 2015\Projects\Property Finder App\PropertyFinderTests\Supplied files\TestResponse.html");
        }

        [TestMethod]
        public void GetBuyUrlWithLocation_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = PropertyFinder.PropertyType.All;
            var testMinBeds = PropertyFinder.Bed.Any;
            var testMinPrice = PropertyFinder.Price.MinAny;
            var testMaxPrice = PropertyFinder.Price.MaxAny;
            var testLocation = PropertyFinder.Location.BrisbaneGreaterRegion;
            var testMaxBeds = PropertyFinder.Bed.Any;
            var testListing = 1;
            var expectedUrl = "http://www.realestate.com.au/buy/in-brisbane+-+greater+region%2c+qld%3b+/list-1?source=location-search";

            // Act
            var actualUrl = TestPropertyFinder.GetBuyUrl(testPropertyType, testMinBeds, testMinPrice, testMaxPrice, testLocation, testMaxBeds, testListing);

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetBuyUrlWithPropertyType_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = PropertyFinder.PropertyType.House;
            var testMinBeds = PropertyFinder.Bed.Any;
            var testMinPrice = PropertyFinder.Price.MinAny;
            var testMaxPrice = PropertyFinder.Price.MaxAny;
            var testLocation = PropertyFinder.Location.BrisbaneGreaterRegion;
            var testMaxBeds = PropertyFinder.Bed.Any;
            var testListing = 1;
            var expectedUrl = "http://www.realestate.com.au/buy/property-house-in-brisbane+-+greater+region%2c+qld%3b+/list-1?source=location-search";

            // Act
            var actualUrl = TestPropertyFinder.GetBuyUrl(testPropertyType, testMinBeds, testMinPrice, testMaxPrice, testLocation, testMaxBeds, testListing);

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetBuyUrlWithMinBeds_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = PropertyFinder.PropertyType.All;
            var testMinBeds = PropertyFinder.Bed.Two;
            var testMinPrice = PropertyFinder.Price.MinAny;
            var testMaxPrice = PropertyFinder.Price.MaxAny;
            var testLocation = PropertyFinder.Location.BrisbaneGreaterRegion;
            var testMaxBeds = PropertyFinder.Bed.Any;
            var testListing = 1;
            var expectedUrl = "http://www.realestate.com.au/buy/with-2-bedrooms-in-brisbane+-+greater+region%2c+qld%3b+/list-1?maxBeds=any&source=location-search";

            // Act
            var actualUrl = TestPropertyFinder.GetBuyUrl(testPropertyType, testMinBeds, testMinPrice, testMaxPrice, testLocation, testMaxBeds, testListing);

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetBuyUrlWithMinBedsAndMaxBeds_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = PropertyFinder.PropertyType.All;
            var testMinBeds = PropertyFinder.Bed.Two;
            var testMinPrice = PropertyFinder.Price.MinAny;
            var testMaxPrice = PropertyFinder.Price.MaxAny;
            var testLocation = PropertyFinder.Location.BrisbaneGreaterRegion;
            var testMaxBeds = PropertyFinder.Bed.Four;
            var testListing = 1;
            var expectedUrl = "http://www.realestate.com.au/buy/with-2-bedrooms-in-brisbane+-+greater+region%2c+qld%3b+/list-1?maxBeds=4&source=location-search";

            // Act
            var actualUrl = TestPropertyFinder.GetBuyUrl(testPropertyType, testMinBeds, testMinPrice, testMaxPrice, testLocation, testMaxBeds, testListing);

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetBuyUrlWithMinPrice_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = PropertyFinder.PropertyType.All;
            var testMinBeds = PropertyFinder.Bed.Any;
            var testMinPrice = PropertyFinder.Price.FiveHundredThousand;
            var testMaxPrice = PropertyFinder.Price.MaxAny;
            var testLocation = PropertyFinder.Location.BrisbaneGreaterRegion;
            var testMaxBeds = PropertyFinder.Bed.Any;
            var testListing = 1;
            var expectedUrl = "http://www.realestate.com.au/buy/between-500000-any-in-brisbane+-+greater+region%2c+qld%3b+/list-1?source=location-search";

            // Act
            var actualUrl = TestPropertyFinder.GetBuyUrl(testPropertyType, testMinBeds, testMinPrice, testMaxPrice, testLocation, testMaxBeds, testListing);

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetBuyUrlWithMaxPrice_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = PropertyFinder.PropertyType.All;
            var testMinBeds = PropertyFinder.Bed.Any;
            var testMinPrice = PropertyFinder.Price.MinAny;
            var testMaxPrice = PropertyFinder.Price.SevenHundredAndFiftyThousand;
            var testLocation = PropertyFinder.Location.BrisbaneGreaterRegion;
            var testMaxBeds = PropertyFinder.Bed.Any;
            var testListing = 1;
            var expectedUrl = "http://www.realestate.com.au/buy/between-0-750000-in-brisbane+-+greater+region%2c+qld%3b+/list-1?source=location-search";

            // Act
            var actualUrl = TestPropertyFinder.GetBuyUrl(testPropertyType, testMinBeds, testMinPrice, testMaxPrice, testLocation, testMaxBeds, testListing);

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetBuyUrlWithLocationPropertyTypeMinBedMinPriceMaxPriceMaxBed_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = PropertyFinder.PropertyType.House;
            var testMinBeds = PropertyFinder.Bed.Two;
            var testMinPrice = PropertyFinder.Price.TwoHundredAndFiftyThousand;
            var testMaxPrice = PropertyFinder.Price.FiveHundredThousand;
            var testLocation = PropertyFinder.Location.BrisbaneGreaterRegion;
            var testMaxBeds = PropertyFinder.Bed.Four;
            var testListing = 1;
            var expectedUrl = "http://www.realestate.com.au/buy/property-house-with-2-bedrooms-between-250000-500000-in-brisbane+-+greater+region%2c+qld%3b+/list-1?maxBeds=4&source=location-search";

            // Act
            var actualUrl = TestPropertyFinder.GetBuyUrl(testPropertyType, testMinBeds, testMinPrice, testMaxPrice, testLocation, testMaxBeds, testListing);

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetWebResonse_ResponseReturned_Test()
        {
            // Arrange
            var testUrl = "http://www.realestate.com.au/buy/in-brisbane+-+greater+region%2c+qld%3b/list-1";
            var expectedResponse = string.Empty;

            // Act
            var actualResponse = TestPropertyFinder.GetWebResponse(testUrl);

            // Assert
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestMethod]
        public void GetTotalHomes_TotalReturned_Test()
        {
            // Arrange
            var testParagraph = "Showing 1 - 20 of 11308 total results";
            var expectedTotalHomes = 11308;

            // Act
            var actualTotalHomes = TestPropertyFinder.GetTotalHomes(testParagraph);

            // Assert
            Assert.AreEqual(expectedTotalHomes, actualTotalHomes);
        }

        [TestMethod]
        public void GetPropertyTypes_PropertyTypeRetured_Test()
        {
            // Arrange
            var testPropertyType = PropertyFinder.PropertyType.House;
            var expectedPropertyType = "property-house-";

            // Act
            var actualPropertyType = TestPropertyFinder.GetPropertyTypes(testPropertyType);

            // Assert
            Assert.AreEqual(expectedPropertyType, actualPropertyType);
        }

        [TestMethod]
        public void GetMinBedsWithAny_MinBedsRetured_Test()
        {
            // Arrange
            var testMinBeds = PropertyFinder.Bed.Any;
            var expectedMinBeds = string.Empty;

            // Act
            var actualMinBeds = TestPropertyFinder.GetMinBeds(testMinBeds);

            // Assert
            Assert.AreEqual(expectedMinBeds, actualMinBeds);
        }

        [TestMethod]
        public void GetMinBedsWithStudio_MinBedsRetured_Test()
        {
            // Arrange
            var testMinBeds = PropertyFinder.Bed.Studio;
            var expectedMinBeds = "with-studio-";

            // Act
            var actualMinBeds = TestPropertyFinder.GetMinBeds(testMinBeds);

            // Assert
            Assert.AreEqual(expectedMinBeds, actualMinBeds);
        }

        [TestMethod]
        public void GetMinBedsWith1Bedroom_MinBedsRetured_Test()
        {
            // Arrange
            var testMinBeds = PropertyFinder.Bed.One;
            var expectedMinBeds = "with-1-bedroom-";

            // Act
            var actualMinBeds = TestPropertyFinder.GetMinBeds(testMinBeds);

            // Assert
            Assert.AreEqual(expectedMinBeds, actualMinBeds);
        }

        [TestMethod]
        public void GetMinBedsWith2Bedrooms_MinBedsRetured_Test()
        {
            // Arrange
            var testMinBeds = PropertyFinder.Bed.Two;
            var expectedMinBeds = "with-2-bedrooms-";

            // Act
            var actualMinBeds = TestPropertyFinder.GetMinBeds(testMinBeds);

            // Assert
            Assert.AreEqual(expectedMinBeds, actualMinBeds);
        }

        [TestMethod]
        public void GetLocationRegion_LocationRetured_Test()
        {
            // Arrange
            var testLocation = PropertyFinder.Location.BrisbaneGreaterRegion;
            var expectedLocation = "in-brisbane+-+greater+region%2c+qld%3b+";

            // Act
            var actualLocation = TestPropertyFinder.GetLocation(testLocation);

            // Assert
            Assert.AreEqual(expectedLocation, actualLocation);
        }

        [TestMethod]
        public void GetLocatioSuburb_LocationRetured_Test()
        {
            // Arrange
            var testLocation = PropertyFinder.Location.Toowong;
            var expectedLocation = "in-toowong%2c+qld+4066%3b+";

            // Act
            var actualLocation = TestPropertyFinder.GetLocation(testLocation);

            // Assert
            Assert.AreEqual(expectedLocation, actualLocation);
        }

        [TestMethod]
        public void GetListing_ListinngRetured_Test()
        {
            // Arrange
            var testListing = 1;
            var expectedListing = "list-1";

            // Act
            var actualListing = TestPropertyFinder.GetListing(testListing);

            // Assert
            Assert.AreEqual(expectedListing, actualListing);
        }

        [TestMethod]
        public void GetMaxBeds_MaxBedsReturned_Test()
        {
            // Arrange
            var testMaxBeds = PropertyFinder.Bed.Any;
            var expectedMaxBeds = "maxBeds=any";

            // Act
            var actualMaxBeds = TestPropertyFinder.GetMaxBeds(testMaxBeds);

            // Assert
            Assert.AreEqual(expectedMaxBeds, actualMaxBeds);
        }

        [TestMethod]
        public void GetParameters_ParametersReturned_Test()
        {
            // Arrange
            var testMinBeds = PropertyFinder.Bed.Two;
            var testMaxBeds = PropertyFinder.Bed.Four;
            var testSource = "location-search";
            var expectedParameters = "?maxBeds=4&source=location-search";

            // Act
            var actualParameters = TestPropertyFinder.GetParameters(testMinBeds, testMaxBeds, testSource);

            // Assert
            Assert.AreEqual(expectedParameters, actualParameters);
        }

        [TestMethod]
        public void GetPricesAny_PriceEmpty_Test()
        {
            // Arrange
            var testMinPrice = PropertyFinder.Price.MinAny;
            var testMaxPrice = PropertyFinder.Price.MaxAny;
            var expectedPrices = string.Empty;

            // Act
            var actualPrices = TestPropertyFinder.GetPriceRange(testMinPrice, testMaxPrice);

            // Assert
            Assert.AreEqual(expectedPrices, actualPrices);
        }

        [TestMethod]
        public void GetPricesWithMinPrice_PriceReturned_Test()
        {
            // Arrange
            var testMinPrice = PropertyFinder.Price.FiftyThousand;
            var testMaxPrice = PropertyFinder.Price.MaxAny;
            var expectedPrices = "between-50000-any-";

            // Act
            var actualPrices = TestPropertyFinder.GetPriceRange(testMinPrice, testMaxPrice);

            // Assert
            Assert.AreEqual(expectedPrices, actualPrices);
        }

        [TestMethod]
        public void GetPricesWithMaxPrice_PriceReturned_Test()
        {
            // Arrange
            var testMinPrice = PropertyFinder.Price.MinAny;
            var testMaxPrice = PropertyFinder.Price.FiveHundredAndFiftyThousand;
            var expectedPrices = "between-0-550000-";

            // Act
            var actualPrices = TestPropertyFinder.GetPriceRange(testMinPrice, testMaxPrice);

            // Assert
            Assert.AreEqual(expectedPrices, actualPrices);
        }

        [TestMethod]
        public void GetPricesWithMinPriceAndMaxPrice_PriceReturned_Test()
        {
            // Arrange
            var testMinPrice = PropertyFinder.Price.TwoHundredAndFiftyThousand;
            var testMaxPrice = PropertyFinder.Price.SixHundredThousand;
            var expectedPrices = "between-250000-600000-";

            // Act
            var actualPrices = TestPropertyFinder.GetPriceRange(testMinPrice, testMaxPrice);

            // Assert
            Assert.AreEqual(expectedPrices, actualPrices);
        }
    }
}
