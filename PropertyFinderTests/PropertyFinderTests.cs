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
            var testMinLand = 0;
            var testMinPrice = PropertyFinder.Price.MinAny;
            var testMaxPrice = PropertyFinder.Price.MaxAny;
            var testLocation = PropertyFinder.Location.BrisbaneGreaterRegion;
            var testConstructionType = PropertyFinder.ConstructionType.Any;
            var testMinCarSpaces = PropertyFinder.CarSpace.Any;
            var testMinBathrooms = PropertyFinder.Bathroom.Any;
            var testMaxBeds = PropertyFinder.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var testListing = 1;
            var expectedUrl = "http://www.realestate.com.au/buy/in-brisbane+-+greater+region%2c+qld%3b+/list-1?source=location-search";

            // Act
            var actualUrl = TestPropertyFinder.GetBuyUrl(testPropertyType, testMinBeds, testMinLand, testMinPrice, testMaxPrice, testLocation, testConstructionType, testMinCarSpaces, testMinBathrooms, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testListing);

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetBuyUrlWithPropertyType_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = PropertyFinder.PropertyType.House;
            var testMinBeds = PropertyFinder.Bed.Any;
            var testMinLand = 0;
            var testMinPrice = PropertyFinder.Price.MinAny;
            var testMaxPrice = PropertyFinder.Price.MaxAny;
            var testLocation = PropertyFinder.Location.BrisbaneGreaterRegion;
            var testConstructionType = PropertyFinder.ConstructionType.Any;
            var testMinCarSpaces = PropertyFinder.CarSpace.Any;
            var testMinBathrooms = PropertyFinder.Bathroom.Any;
            var testMaxBeds = PropertyFinder.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var testListing = 1;
            var expectedUrl = "http://www.realestate.com.au/buy/property-house-in-brisbane+-+greater+region%2c+qld%3b+/list-1?source=location-search";

            // Act
            var actualUrl = TestPropertyFinder.GetBuyUrl(testPropertyType, testMinBeds, testMinLand, testMinPrice, testMaxPrice, testLocation, testConstructionType, testMinCarSpaces, testMinBathrooms, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testListing);

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetBuyUrlWithMinBeds_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = PropertyFinder.PropertyType.All;
            var testMinBeds = PropertyFinder.Bed.Two;
            var testMinLand = 0;
            var testMinPrice = PropertyFinder.Price.MinAny;
            var testMaxPrice = PropertyFinder.Price.MaxAny;
            var testLocation = PropertyFinder.Location.BrisbaneGreaterRegion;
            var testConstructionType = PropertyFinder.ConstructionType.Any;
            var testMinCarSpaces = PropertyFinder.CarSpace.Any;
            var testMinBathrooms = PropertyFinder.Bathroom.Any;
            var testMaxBeds = PropertyFinder.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var testListing = 1;
            var expectedUrl = "http://www.realestate.com.au/buy/with-2-bedrooms-in-brisbane+-+greater+region%2c+qld%3b+/list-1?maxBeds=any&source=location-search";

            // Act
            var actualUrl = TestPropertyFinder.GetBuyUrl(testPropertyType, testMinBeds, testMinLand, testMinPrice, testMaxPrice, testLocation, testConstructionType, testMinCarSpaces, testMinBathrooms, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testListing);

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetBuyUrlWithMinBedsAndMaxBeds_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = PropertyFinder.PropertyType.All;
            var testMinBeds = PropertyFinder.Bed.Two;
            var testMinLand = 0;
            var testMinPrice = PropertyFinder.Price.MinAny;
            var testMaxPrice = PropertyFinder.Price.MaxAny;
            var testLocation = PropertyFinder.Location.BrisbaneGreaterRegion;
            var testConstructionType = PropertyFinder.ConstructionType.Any;
            var testMinCarSpaces = PropertyFinder.CarSpace.Any;
            var testMinBathrooms = PropertyFinder.Bathroom.Any;
            var testMaxBeds = PropertyFinder.Bed.Four;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var testListing = 1;
            var expectedUrl = "http://www.realestate.com.au/buy/with-2-bedrooms-in-brisbane+-+greater+region%2c+qld%3b+/list-1?maxBeds=4&source=location-search";

            // Act
            var actualUrl = TestPropertyFinder.GetBuyUrl(testPropertyType, testMinBeds, testMinLand, testMinPrice, testMaxPrice, testLocation, testConstructionType, testMinCarSpaces, testMinBathrooms, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testListing);

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetBuyUrlWithMinPrice_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = PropertyFinder.PropertyType.All;
            var testMinBeds = PropertyFinder.Bed.Any;
            var testMinLand = 0;
            var testMinPrice = PropertyFinder.Price.FiveHundredThousand;
            var testMaxPrice = PropertyFinder.Price.MaxAny;
            var testLocation = PropertyFinder.Location.BrisbaneGreaterRegion;
            var testConstructionType = PropertyFinder.ConstructionType.Any;
            var testMinCarSpaces = PropertyFinder.CarSpace.Any;
            var testMinBathrooms = PropertyFinder.Bathroom.Any;
            var testMaxBeds = PropertyFinder.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var testListing = 1;
            var expectedUrl = "http://www.realestate.com.au/buy/between-500000-any-in-brisbane+-+greater+region%2c+qld%3b+/list-1?source=location-search";

            // Act
            var actualUrl = TestPropertyFinder.GetBuyUrl(testPropertyType, testMinBeds, testMinLand, testMinPrice, testMaxPrice, testLocation, testConstructionType, testMinCarSpaces, testMinBathrooms, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testListing);

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetBuyUrlWithMaxPrice_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = PropertyFinder.PropertyType.All;
            var testMinBeds = PropertyFinder.Bed.Any;
            var testMinLand = 0;
            var testMinPrice = PropertyFinder.Price.MinAny;
            var testMaxPrice = PropertyFinder.Price.SevenHundredAndFiftyThousand;
            var testConstructionType = PropertyFinder.ConstructionType.Any;
            var testLocation = PropertyFinder.Location.BrisbaneGreaterRegion;
            var testMinCarSpaces = PropertyFinder.CarSpace.Any;
            var testMinBathrooms = PropertyFinder.Bathroom.Any;
            var testMaxBeds = PropertyFinder.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var testListing = 1;
            var expectedUrl = "http://www.realestate.com.au/buy/between-0-750000-in-brisbane+-+greater+region%2c+qld%3b+/list-1?source=location-search";

            // Act
            var actualUrl = TestPropertyFinder.GetBuyUrl(testPropertyType, testMinBeds, testMinLand, testMinPrice, testMaxPrice, testLocation, testConstructionType, testMinCarSpaces, testMinBathrooms, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testListing);

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetBuyUrlWithLocationPropertyTypeMinBedsMinLandMinPriceMaxPriceConstructionTypeMinCarSpacesMinBathroomsMaxBedsSurroundingSuburbs_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = PropertyFinder.PropertyType.House;
            var testMinBeds = PropertyFinder.Bed.Three;
            var testMinLand = 0;
            var testMinPrice = PropertyFinder.Price.TwoHundredAndFiftyThousand;
            var testMaxPrice = PropertyFinder.Price.FiveHundredThousand;
            var testLocation = PropertyFinder.Location.BrisbaneGreaterRegion;
            var testConstructionType = PropertyFinder.ConstructionType.EstablishedProperty;
            var testMinCarSpaces = PropertyFinder.CarSpace.TwoPlus;
            var testMinBathrooms = PropertyFinder.Bathroom.TwoPlus;
            var testMaxBeds = PropertyFinder.Bed.Four;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = true;
            var testListing = 1;
            var expectedUrl = "http://www.realestate.com.au/buy/property-house-with-3-bedrooms-between-250000-500000-in-brisbane+-+greater+region%2c+qld%3b+/list-1?newOrEstablished=established&numParkingSpaces=2&numBaths=2&maxBeds=4&misc=ex-under-contract&source=location-search";

            // Act
            var actualUrl = TestPropertyFinder.GetBuyUrl(testPropertyType, testMinBeds, testMinLand, testMinPrice, testMaxPrice, testLocation, testConstructionType, testMinCarSpaces, testMinBathrooms, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testListing);

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        //[TestMethod]
        //public void GetWebResonse_ResponseReturned_Test()
        //{
        //    // Arrange
        //    var testUrl = "http://www.realestate.com.au/buy/in-brisbane+-+greater+region%2c+qld%3b/list-1";
        //    var expectedResponse = string.Empty;

        //    // Act
        //    var actualResponse = TestPropertyFinder.GetWebResponse(testUrl);

        //    // Assert
        //    Assert.AreEqual(expectedResponse, actualResponse);
        //}

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
            var actualPropertyType = TestPropertyFinder.GetPropertyTypesQuery(testPropertyType);

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
            var actualMinBeds = TestPropertyFinder.GetMinBedsQuery(testMinBeds);

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
            var actualMinBeds = TestPropertyFinder.GetMinBedsQuery(testMinBeds);

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
            var actualMinBeds = TestPropertyFinder.GetMinBedsQuery(testMinBeds);

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
            var actualMinBeds = TestPropertyFinder.GetMinBedsQuery(testMinBeds);

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
            var actualLocation = TestPropertyFinder.GetLocationQuery(testLocation);

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
            var actualLocation = TestPropertyFinder.GetLocationQuery(testLocation);

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
            var actualListing = TestPropertyFinder.GetListingQuery(testListing);

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
            var actualMaxBeds = TestPropertyFinder.GetMaxBedsQuery(testMaxBeds);

            // Assert
            Assert.AreEqual(expectedMaxBeds, actualMaxBeds);
        }

        [TestMethod]
        public void GetParameters_ParametersReturned_Test()
        {
            // Arrange
            var testConstructionType = PropertyFinder.ConstructionType.Any;
            var testMinCarSpaces = PropertyFinder.CarSpace.Any;
            var testMinBathrooms = PropertyFinder.Bathroom.Any;
            var testMinBeds = PropertyFinder.Bed.Any;
            var testMaxBeds = PropertyFinder.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var testSource = "location-search";
            var expectedParameters = "?source=location-search";

            // Act
            var actualParameters = TestPropertyFinder.GetParameters(testConstructionType, testMinCarSpaces, testMinBathrooms, testMinBeds, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testSource);

            // Assert
            Assert.AreEqual(expectedParameters, actualParameters);
        }

        [TestMethod]
        public void GetParametersWithMaxBeds_ParametersReturned_Test()
        {
            // Arrange
            var testConstructionType = PropertyFinder.ConstructionType.Any;
            var testMinCarSpaces = PropertyFinder.CarSpace.Any;
            var testMinBathrooms = PropertyFinder.Bathroom.Any;
            var testMinBeds = PropertyFinder.Bed.Two;
            var testMaxBeds = PropertyFinder.Bed.Four;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var testSource = "location-search";
            var expectedParameters = "?maxBeds=4&source=location-search";

            // Act
            var actualParameters = TestPropertyFinder.GetParameters(testConstructionType, testMinCarSpaces, testMinBathrooms, testMinBeds, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testSource);

            // Assert
            Assert.AreEqual(expectedParameters, actualParameters);
        }

        [TestMethod]
        public void GetParametersWithMinBathrooms_ParametersReturned_Test()
        {
            // Arrange
            var testConstructionType = PropertyFinder.ConstructionType.Any;
            var testMinCarSpaces = PropertyFinder.CarSpace.Any;
            var testMinBathrooms = PropertyFinder.Bathroom.TwoPlus;
            var testMinBeds = PropertyFinder.Bed.Any;
            var testMaxBeds = PropertyFinder.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var testSource = "location-search";
            var expectedParameters = "?numBaths=2&source=location-search";

            // Act
            var actualParameters = TestPropertyFinder.GetParameters(testConstructionType, testMinCarSpaces, testMinBathrooms, testMinBeds, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testSource);

            // Assert
            Assert.AreEqual(expectedParameters, actualParameters);
        }

        [TestMethod]
        public void GetParametersWithMinCarSpaces_ParametersReturned_Test()
        {
            // Arrange
            var testConstructionType = PropertyFinder.ConstructionType.Any;
            var testMinCarSpaces = PropertyFinder.CarSpace.TwoPlus;
            var testMinBathrooms = PropertyFinder.Bathroom.Any;
            var testMinBeds = PropertyFinder.Bed.Any;
            var testMaxBeds = PropertyFinder.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var testSource = "location-search";
            var expectedParameters = "?numParkingSpaces=2&source=location-search";

            // Act
            var actualParameters = TestPropertyFinder.GetParameters(testConstructionType, testMinCarSpaces, testMinBathrooms, testMinBeds, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testSource);

            // Assert
            Assert.AreEqual(expectedParameters, actualParameters);
        }

        [TestMethod]
        public void GetParametersWithConstructionType_ParametersReturned_Test()
        {
            // Arrange
            var testConstructionType = PropertyFinder.ConstructionType.EstablishedProperty;
            var testMinCarSpaces = PropertyFinder.CarSpace.Any;
            var testMinBathrooms = PropertyFinder.Bathroom.Any;
            var testMinBeds = PropertyFinder.Bed.Any;
            var testMaxBeds = PropertyFinder.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var testSource = "location-search";
            var expectedParameters = "?newOrEstablished=established&source=location-search";

            // Act
            var actualParameters = TestPropertyFinder.GetParameters(testConstructionType, testMinCarSpaces, testMinBathrooms, testMinBeds, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testSource);

            // Assert
            Assert.AreEqual(expectedParameters, actualParameters);
        }

        [TestMethod]
        public void GetParametersWithoutIncludingSurroundingSuburbs_ParametersReturned_Test()
        {
            // Arrange
            var testConstructionType = PropertyFinder.ConstructionType.Any;
            var testMinCarSpaces = PropertyFinder.CarSpace.Any;
            var testMinBathrooms = PropertyFinder.Bathroom.Any;
            var testMinBeds = PropertyFinder.Bed.Any;
            var testMaxBeds = PropertyFinder.Bed.Any;
            var testIsIncludingSurroundingSuburbs = false;
            var testIsExcludingPropertiesUnderContract = false;
            var testSource = "location-search";
            var expectedParameters = "?includeSurrounding=false&source=location-search";

            // Act
            var actualParameters = TestPropertyFinder.GetParameters(testConstructionType, testMinCarSpaces, testMinBathrooms, testMinBeds, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testSource);

            // Assert
            Assert.AreEqual(expectedParameters, actualParameters);
        }

        [TestMethod]
        public void GetParametersWithExcludingPropertiesUnderContract_ParametersReturned_Test()
        {
            // Arrange
            var testConstructionType = PropertyFinder.ConstructionType.Any;
            var testMinCarSpaces = PropertyFinder.CarSpace.Any;
            var testMinBathrooms = PropertyFinder.Bathroom.Any;
            var testMinBeds = PropertyFinder.Bed.Any;
            var testMaxBeds = PropertyFinder.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = true;
            var testSource = "location-search";
            var expectedParameters = "?misc=ex-under-contract&source=location-search";

            // Act
            var actualParameters = TestPropertyFinder.GetParameters(testConstructionType, testMinCarSpaces, testMinBathrooms, testMinBeds, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testSource);

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
            var actualPrices = TestPropertyFinder.GetPriceRangeQuery(testMinPrice, testMaxPrice);

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
            var actualPrices = TestPropertyFinder.GetPriceRangeQuery(testMinPrice, testMaxPrice);

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
            var actualPrices = TestPropertyFinder.GetPriceRangeQuery(testMinPrice, testMaxPrice);

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
            var actualPrices = TestPropertyFinder.GetPriceRangeQuery(testMinPrice, testMaxPrice);

            // Assert
            Assert.AreEqual(expectedPrices, actualPrices);
        }

        [TestMethod]
        public void GetSourceQuery_SourceReturned_Test()
        {
            // Arrange
            var testSource = "location-search";
            var expectedSource = "source=location-search";

            // Act
            var actualSource = TestPropertyFinder.GetSourceQuery(testSource);

            // Assert
            Assert.AreEqual(expectedSource, actualSource);
        }

        [TestMethod]
        public void GetMinBathroomsQuery_MinBathroomsReturned_Test()
        {
            // Arrange
            var testMinBathroom = PropertyFinder.Bathroom.TwoPlus;
            var expectedMinBathroom = "numBaths=2";

            // Act
            var actualMinBathroom = TestPropertyFinder.GetMinBathroomsQuery(testMinBathroom);

            // Assert
            Assert.AreEqual(expectedMinBathroom, actualMinBathroom);
        }

        [TestMethod]
        public void GetMinCarSpacesQuery_MinCarSpacesReturned_Test()
        {
            // Arrange
            var testMinCarSpaces = PropertyFinder.CarSpace.TwoPlus;
            var expectedMinCarSpaces = "numParkingSpaces=2";

            // Act
            var actualMinCarSpaces = TestPropertyFinder.GetMinCarSpacesQuery(testMinCarSpaces);

            // Assert
            Assert.AreEqual(expectedMinCarSpaces, actualMinCarSpaces);
        }

        [TestMethod]
        public void GetConstructionTypeQuery_ConstructionTypeReturned_Test()
        {
            // Arrange
            var testConstructionType = PropertyFinder.ConstructionType.EstablishedProperty;
            var expectedConstructionType = "newOrEstablished=established";

            // Act
            var actualConstructionType = TestPropertyFinder.GetConstructionTypeQuery(testConstructionType);

            // Assert
            Assert.AreEqual(expectedConstructionType, actualConstructionType);
        }

        [TestMethod]
        public void GetMinLandQuery_MinLandReturnedEmpty_Test()
        {
            // Arrange
            var testMinLand = 0;
            var expectedMinLand = string.Empty;

            // Act
            var actualMinLand = TestPropertyFinder.GetMinLandQuery(testMinLand);

            // Assert
            Assert.AreEqual(expectedMinLand, actualMinLand);
        }

        [TestMethod]
        public void GetMinLandQuery_MinLandReturned_Test()
        {
            // Arrange
            var testMinLand = 700;
            var expectedMinLand = "size-700-";

            // Act
            var actualMinLand = TestPropertyFinder.GetMinLandQuery(testMinLand);

            // Assert
            Assert.AreEqual(expectedMinLand, actualMinLand);
        }
    }
}
