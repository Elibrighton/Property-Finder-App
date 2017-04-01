using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Property_Finder_App;
using System.IO;
using System.Collections.Generic;

namespace PropertyFinderTests
{
    [TestClass]
    public class SearchTests
    {
        private Search testSearch;
        private string testSearchResponse;

        [TestInitialize]
        public void Initialize()
        {
            testSearch = new Search();

            // Open the file to read from.
            testSearchResponse = File.ReadAllText(@"C:\Users\Dj Music\Documents\Visual Studio 2015\Projects\Property Finder App\PropertyFinderTests\Supplied files\TestSearchResponse.html");
        }

        [TestMethod]
        public void GetUrlWithLocation_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = Search.PropertyType.All;
            var testMinBeds = Search.Bed.Any;
            var testMinLand = 0;
            var testMinPrice = Search.Price.MinAny;
            var testMaxPrice = Search.Price.MaxAny;
            var testLocation = Search.Location.BrisbaneGreaterRegion;
            var testConstructionType = Search.ConstructionType.Any;
            var testMinCarSpaces = Search.CarSpace.Any;
            var testMinBathrooms = Search.Bathroom.Any;
            var testMaxBeds = Search.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;var expectedUrl = "http://www.realestate.com.au/buy/in-brisbane+-+greater+region%2c+qld%3b+/list-1?source=location-search";

            // Act
            testSearch.Set(testPropertyType, testMinBeds, testMinLand, testMinPrice, testMaxPrice, testLocation, testConstructionType, testMinCarSpaces, testMinBathrooms, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract);
            testSearch.GenerateUrl();
            var actualUrl = testSearch.Url;

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetUrlWithPropertyType_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = Search.PropertyType.House;
            var testMinBeds = Search.Bed.Any;
            var testMinLand = 0;
            var testMinPrice = Search.Price.MinAny;
            var testMaxPrice = Search.Price.MaxAny;
            var testLocation = Search.Location.BrisbaneGreaterRegion;
            var testConstructionType = Search.ConstructionType.Any;
            var testMinCarSpaces = Search.CarSpace.Any;
            var testMinBathrooms = Search.Bathroom.Any;
            var testMaxBeds = Search.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var expectedUrl = "http://www.realestate.com.au/buy/property-house-in-brisbane+-+greater+region%2c+qld%3b+/list-1?source=location-search";

            // Act
            testSearch.Set(testPropertyType, testMinBeds, testMinLand, testMinPrice, testMaxPrice, testLocation, testConstructionType, testMinCarSpaces, testMinBathrooms, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract);
            testSearch.GenerateUrl();
            var actualUrl = testSearch.Url;

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetUrlWithMinBeds_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = Search.PropertyType.All;
            var testMinBeds = Search.Bed.Two;
            var testMinLand = 0;
            var testMinPrice = Search.Price.MinAny;
            var testMaxPrice = Search.Price.MaxAny;
            var testLocation = Search.Location.BrisbaneGreaterRegion;
            var testConstructionType = Search.ConstructionType.Any;
            var testMinCarSpaces = Search.CarSpace.Any;
            var testMinBathrooms = Search.Bathroom.Any;
            var testMaxBeds = Search.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var expectedUrl = "http://www.realestate.com.au/buy/with-2-bedrooms-in-brisbane+-+greater+region%2c+qld%3b+/list-1?maxBeds=any&source=location-search";

            // Act
            testSearch.Set(testPropertyType, testMinBeds, testMinLand, testMinPrice, testMaxPrice, testLocation, testConstructionType, testMinCarSpaces, testMinBathrooms, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract);
            testSearch.GenerateUrl();
            var actualUrl = testSearch.Url;

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetUrlWithMinBedsAndMaxBeds_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = Search.PropertyType.All;
            var testMinBeds = Search.Bed.Two;
            var testMinLand = 0;
            var testMinPrice = Search.Price.MinAny;
            var testMaxPrice = Search.Price.MaxAny;
            var testLocation = Search.Location.BrisbaneGreaterRegion;
            var testConstructionType = Search.ConstructionType.Any;
            var testMinCarSpaces = Search.CarSpace.Any;
            var testMinBathrooms = Search.Bathroom.Any;
            var testMaxBeds = Search.Bed.Four;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var expectedUrl = "http://www.realestate.com.au/buy/with-2-bedrooms-in-brisbane+-+greater+region%2c+qld%3b+/list-1?maxBeds=4&source=location-search";

            // Act
            testSearch.Set(testPropertyType, testMinBeds, testMinLand, testMinPrice, testMaxPrice, testLocation, testConstructionType, testMinCarSpaces, testMinBathrooms, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract);
            testSearch.GenerateUrl();
            var actualUrl = testSearch.Url;

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetUrlWithMinPrice_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = Search.PropertyType.All;
            var testMinBeds = Search.Bed.Any;
            var testMinLand = 0;
            var testMinPrice = Search.Price.FiveHundredThousand;
            var testMaxPrice = Search.Price.MaxAny;
            var testLocation = Search.Location.BrisbaneGreaterRegion;
            var testConstructionType = Search.ConstructionType.Any;
            var testMinCarSpaces = Search.CarSpace.Any;
            var testMinBathrooms = Search.Bathroom.Any;
            var testMaxBeds = Search.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var expectedUrl = "http://www.realestate.com.au/buy/between-500000-any-in-brisbane+-+greater+region%2c+qld%3b+/list-1?source=location-search";

            // Act
            testSearch.Set(testPropertyType, testMinBeds, testMinLand, testMinPrice, testMaxPrice, testLocation, testConstructionType, testMinCarSpaces, testMinBathrooms, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract);
            testSearch.GenerateUrl();
            var actualUrl = testSearch.Url;

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetUrlWithMaxPrice_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = Search.PropertyType.All;
            var testMinBeds = Search.Bed.Any;
            var testMinLand = 0;
            var testMinPrice = Search.Price.MinAny;
            var testMaxPrice = Search.Price.SevenHundredAndFiftyThousand;
            var testConstructionType = Search.ConstructionType.Any;
            var testLocation = Search.Location.BrisbaneGreaterRegion;
            var testMinCarSpaces = Search.CarSpace.Any;
            var testMinBathrooms = Search.Bathroom.Any;
            var testMaxBeds = Search.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var expectedUrl = "http://www.realestate.com.au/buy/between-0-750000-in-brisbane+-+greater+region%2c+qld%3b+/list-1?source=location-search";

            // Act
            testSearch.Set(testPropertyType, testMinBeds, testMinLand, testMinPrice, testMaxPrice, testLocation, testConstructionType, testMinCarSpaces, testMinBathrooms, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract);
            testSearch.GenerateUrl();
            var actualUrl = testSearch.Url;

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        public void GetUrlWithLocationPropertyTypeMinBedsMinLandMinPriceMaxPriceConstructionTypeMinCarSpacesMinBathroomsMaxBedsSurroundingSuburbs_UrlReturned_Test()
        {
            // Arrange
            var testPropertyType = Search.PropertyType.House;
            var testMinBeds = Search.Bed.Three;
            var testMinLand = 0;
            var testMinPrice = Search.Price.TwoHundredAndFiftyThousand;
            var testMaxPrice = Search.Price.FiveHundredThousand;
            var testLocation = Search.Location.BrisbaneGreaterRegion;
            var testConstructionType = Search.ConstructionType.EstablishedProperty;
            var testMinCarSpaces = Search.CarSpace.TwoPlus;
            var testMinBathrooms = Search.Bathroom.TwoPlus;
            var testMaxBeds = Search.Bed.Four;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = true;
            var expectedUrl = "http://www.realestate.com.au/buy/property-house-with-3-bedrooms-between-250000-500000-in-brisbane+-+greater+region%2c+qld%3b+/list-1?newOrEstablished=established&numParkingSpaces=2&numBaths=2&maxBeds=4&misc=ex-under-contract&source=location-search";

            // Act
            testSearch.Set(testPropertyType, testMinBeds, testMinLand, testMinPrice, testMaxPrice, testLocation, testConstructionType, testMinCarSpaces, testMinBathrooms, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract);
            testSearch.GenerateUrl();
            var actualUrl = testSearch.Url;

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        //[TestMethod]
        //public void GetWebResonse_ResponseReturned_Test()
        //{
        //    // Arrange
        //    //var testUrl = "http://www.realestate.com.au/buy/in-brisbane+-+greater+region%2c+qld%3b/list-1";
        //    var testUrl = "http://www.realestate.com.au/property-house-qld-acacia+ridge-125115106";
        //    var expectedResponse = string.Empty;

        //    // Act
        //    var actualResponse = testSearch.GetWebResponse(testUrl);

        //    // Assert
        //    Assert.AreEqual(expectedResponse, actualResponse);
        ////}

        //[TestMethod]
        //public void GetTotalHomes_TotalReturned_Test()
        //{
        //    // Arrange
        //    var expectedTotalHomes = 11308;

        //    // Act
        //    var actualTotalHomes = testSearch.GetTotalHomes();

        //    // Assert
        //    Assert.AreEqual(expectedTotalHomes, actualTotalHomes);
        //}

        [TestMethod]
        public void GetPropertyTypes_PropertyTypeRetured_Test()
        {
            // Arrange
            var testPropertyType = Search.PropertyType.House;
            var expectedPropertyType = "property-house-";

            // Act
            var actualPropertyType = testSearch.GetPropertyTypesQuery(testPropertyType);

            // Assert
            Assert.AreEqual(expectedPropertyType, actualPropertyType);
        }

        [TestMethod]
        public void GetMinBedsWithAny_MinBedsRetured_Test()
        {
            // Arrange
            var testMinBeds = Search.Bed.Any;
            var expectedMinBeds = string.Empty;

            // Act
            var actualMinBeds = testSearch.GetMinBedsQuery(testMinBeds);

            // Assert
            Assert.AreEqual(expectedMinBeds, actualMinBeds);
        }

        [TestMethod]
        public void GetMinBedsWithStudio_MinBedsRetured_Test()
        {
            // Arrange
            var testMinBeds = Search.Bed.Studio;
            var expectedMinBeds = "with-studio-";

            // Act
            var actualMinBeds = testSearch.GetMinBedsQuery(testMinBeds);

            // Assert
            Assert.AreEqual(expectedMinBeds, actualMinBeds);
        }

        [TestMethod]
        public void GetMinBedsWith1Bedroom_MinBedsRetured_Test()
        {
            // Arrange
            var testMinBeds = Search.Bed.One;
            var expectedMinBeds = "with-1-bedroom-";

            // Act
            var actualMinBeds = testSearch.GetMinBedsQuery(testMinBeds);

            // Assert
            Assert.AreEqual(expectedMinBeds, actualMinBeds);
        }

        [TestMethod]
        public void GetMinBedsWith2Bedrooms_MinBedsRetured_Test()
        {
            // Arrange
            var testMinBeds = Search.Bed.Two;
            var expectedMinBeds = "with-2-bedrooms-";

            // Act
            var actualMinBeds = testSearch.GetMinBedsQuery(testMinBeds);

            // Assert
            Assert.AreEqual(expectedMinBeds, actualMinBeds);
        }

        [TestMethod]
        public void GetLocationRegion_LocationRetured_Test()
        {
            // Arrange
            var testLocation = Search.Location.BrisbaneGreaterRegion;
            var expectedLocation = "in-brisbane+-+greater+region%2c+qld%3b+";

            // Act
            var actualLocation = testSearch.GetLocationQuery(testLocation);

            // Assert
            Assert.AreEqual(expectedLocation, actualLocation);
        }

        [TestMethod]
        public void GetLocatioSuburb_LocationRetured_Test()
        {
            // Arrange
            var testLocation = Search.Location.Toowong;
            var expectedLocation = "in-toowong%2c+qld+4066%3b+";

            // Act
            var actualLocation = testSearch.GetLocationQuery(testLocation);

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
            var actualListing = testSearch.GetListingQuery(testListing);

            // Assert
            Assert.AreEqual(expectedListing, actualListing);
        }

        [TestMethod]
        public void GetMaxBeds_MaxBedsReturned_Test()
        {
            // Arrange
            var testMaxBeds = Search.Bed.Any;
            var expectedMaxBeds = "maxBeds=any";

            // Act
            var actualMaxBeds = testSearch.GetMaxBedsQuery(testMaxBeds);

            // Assert
            Assert.AreEqual(expectedMaxBeds, actualMaxBeds);
        }

        [TestMethod]
        public void GetParameters_ParametersReturned_Test()
        {
            // Arrange
            var testConstructionType = Search.ConstructionType.Any;
            var testMinCarSpaces = Search.CarSpace.Any;
            var testMinBathrooms = Search.Bathroom.Any;
            var testMinBeds = Search.Bed.Any;
            var testMaxBeds = Search.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var testSource = "location-search";
            var expectedParameters = "?source=location-search";

            // Act
            var actualParameters = testSearch.GetParameters(testConstructionType, testMinCarSpaces, testMinBathrooms, testMinBeds, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testSource);

            // Assert
            Assert.AreEqual(expectedParameters, actualParameters);
        }

        [TestMethod]
        public void GetParametersWithMaxBeds_ParametersReturned_Test()
        {
            // Arrange
            var testConstructionType = Search.ConstructionType.Any;
            var testMinCarSpaces = Search.CarSpace.Any;
            var testMinBathrooms = Search.Bathroom.Any;
            var testMinBeds = Search.Bed.Two;
            var testMaxBeds = Search.Bed.Four;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var testSource = "location-search";
            var expectedParameters = "?maxBeds=4&source=location-search";

            // Act
            var actualParameters = testSearch.GetParameters(testConstructionType, testMinCarSpaces, testMinBathrooms, testMinBeds, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testSource);

            // Assert
            Assert.AreEqual(expectedParameters, actualParameters);
        }

        [TestMethod]
        public void GetParametersWithMinBathrooms_ParametersReturned_Test()
        {
            // Arrange
            var testConstructionType = Search.ConstructionType.Any;
            var testMinCarSpaces = Search.CarSpace.Any;
            var testMinBathrooms = Search.Bathroom.TwoPlus;
            var testMinBeds = Search.Bed.Any;
            var testMaxBeds = Search.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var testSource = "location-search";
            var expectedParameters = "?numBaths=2&source=location-search";

            // Act
            var actualParameters = testSearch.GetParameters(testConstructionType, testMinCarSpaces, testMinBathrooms, testMinBeds, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testSource);

            // Assert
            Assert.AreEqual(expectedParameters, actualParameters);
        }

        [TestMethod]
        public void GetParametersWithMinCarSpaces_ParametersReturned_Test()
        {
            // Arrange
            var testConstructionType = Search.ConstructionType.Any;
            var testMinCarSpaces = Search.CarSpace.TwoPlus;
            var testMinBathrooms = Search.Bathroom.Any;
            var testMinBeds = Search.Bed.Any;
            var testMaxBeds = Search.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var testSource = "location-search";
            var expectedParameters = "?numParkingSpaces=2&source=location-search";

            // Act
            var actualParameters = testSearch.GetParameters(testConstructionType, testMinCarSpaces, testMinBathrooms, testMinBeds, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testSource);

            // Assert
            Assert.AreEqual(expectedParameters, actualParameters);
        }

        [TestMethod]
        public void GetParametersWithConstructionType_ParametersReturned_Test()
        {
            // Arrange
            var testConstructionType = Search.ConstructionType.EstablishedProperty;
            var testMinCarSpaces = Search.CarSpace.Any;
            var testMinBathrooms = Search.Bathroom.Any;
            var testMinBeds = Search.Bed.Any;
            var testMaxBeds = Search.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = false;
            var testSource = "location-search";
            var expectedParameters = "?newOrEstablished=established&source=location-search";

            // Act
            var actualParameters = testSearch.GetParameters(testConstructionType, testMinCarSpaces, testMinBathrooms, testMinBeds, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testSource);

            // Assert
            Assert.AreEqual(expectedParameters, actualParameters);
        }

        [TestMethod]
        public void GetParametersWithoutIncludingSurroundingSuburbs_ParametersReturned_Test()
        {
            // Arrange
            var testConstructionType = Search.ConstructionType.Any;
            var testMinCarSpaces = Search.CarSpace.Any;
            var testMinBathrooms = Search.Bathroom.Any;
            var testMinBeds = Search.Bed.Any;
            var testMaxBeds = Search.Bed.Any;
            var testIsIncludingSurroundingSuburbs = false;
            var testIsExcludingPropertiesUnderContract = false;
            var testSource = "location-search";
            var expectedParameters = "?includeSurrounding=false&source=location-search";

            // Act
            var actualParameters = testSearch.GetParameters(testConstructionType, testMinCarSpaces, testMinBathrooms, testMinBeds, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testSource);

            // Assert
            Assert.AreEqual(expectedParameters, actualParameters);
        }

        [TestMethod]
        public void GetParametersWithExcludingPropertiesUnderContract_ParametersReturned_Test()
        {
            // Arrange
            var testConstructionType = Search.ConstructionType.Any;
            var testMinCarSpaces = Search.CarSpace.Any;
            var testMinBathrooms = Search.Bathroom.Any;
            var testMinBeds = Search.Bed.Any;
            var testMaxBeds = Search.Bed.Any;
            var testIsIncludingSurroundingSuburbs = true;
            var testIsExcludingPropertiesUnderContract = true;
            var testSource = "location-search";
            var expectedParameters = "?misc=ex-under-contract&source=location-search";

            // Act
            var actualParameters = testSearch.GetParameters(testConstructionType, testMinCarSpaces, testMinBathrooms, testMinBeds, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testSource);

            // Assert
            Assert.AreEqual(expectedParameters, actualParameters);
        }

        [TestMethod]
        public void GetPricesAny_PriceEmpty_Test()
        {
            // Arrange
            var testMinPrice = Search.Price.MinAny;
            var testMaxPrice = Search.Price.MaxAny;
            var expectedPrices = string.Empty;

            // Act
            var actualPrices = testSearch.GetPriceRangeQuery(testMinPrice, testMaxPrice);

            // Assert
            Assert.AreEqual(expectedPrices, actualPrices);
        }

        [TestMethod]
        public void GetPricesWithMinPrice_PriceReturned_Test()
        {
            // Arrange
            var testMinPrice = Search.Price.FiftyThousand;
            var testMaxPrice = Search.Price.MaxAny;
            var expectedPrices = "between-50000-any-";

            // Act
            var actualPrices = testSearch.GetPriceRangeQuery(testMinPrice, testMaxPrice);

            // Assert
            Assert.AreEqual(expectedPrices, actualPrices);
        }

        [TestMethod]
        public void GetPricesWithMaxPrice_PriceReturned_Test()
        {
            // Arrange
            var testMinPrice = Search.Price.MinAny;
            var testMaxPrice = Search.Price.FiveHundredAndFiftyThousand;
            var expectedPrices = "between-0-550000-";

            // Act
            var actualPrices = testSearch.GetPriceRangeQuery(testMinPrice, testMaxPrice);

            // Assert
            Assert.AreEqual(expectedPrices, actualPrices);
        }

        [TestMethod]
        public void GetPricesWithMinPriceAndMaxPrice_PriceReturned_Test()
        {
            // Arrange
            var testMinPrice = Search.Price.TwoHundredAndFiftyThousand;
            var testMaxPrice = Search.Price.SixHundredThousand;
            var expectedPrices = "between-250000-600000-";

            // Act
            var actualPrices = testSearch.GetPriceRangeQuery(testMinPrice, testMaxPrice);

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
            var actualSource = testSearch.GetSourceQuery(testSource);

            // Assert
            Assert.AreEqual(expectedSource, actualSource);
        }

        [TestMethod]
        public void GetMinBathroomsQuery_MinBathroomsReturned_Test()
        {
            // Arrange
            var testMinBathroom = Search.Bathroom.TwoPlus;
            var expectedMinBathroom = "numBaths=2";

            // Act
            var actualMinBathroom = testSearch.GetMinBathroomsQuery(testMinBathroom);

            // Assert
            Assert.AreEqual(expectedMinBathroom, actualMinBathroom);
        }

        [TestMethod]
        public void GetMinCarSpacesQuery_MinCarSpacesReturned_Test()
        {
            // Arrange
            var testMinCarSpaces = Search.CarSpace.TwoPlus;
            var expectedMinCarSpaces = "numParkingSpaces=2";

            // Act
            var actualMinCarSpaces = testSearch.GetMinCarSpacesQuery(testMinCarSpaces);

            // Assert
            Assert.AreEqual(expectedMinCarSpaces, actualMinCarSpaces);
        }

        [TestMethod]
        public void GetConstructionTypeQuery_ConstructionTypeReturned_Test()
        {
            // Arrange
            var testConstructionType = Search.ConstructionType.EstablishedProperty;
            var expectedConstructionType = "newOrEstablished=established";

            // Act
            var actualConstructionType = testSearch.GetConstructionTypeQuery(testConstructionType);

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
            var actualMinLand = testSearch.GetMinLandQuery(testMinLand);

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
            var actualMinLand = testSearch.GetMinLandQuery(testMinLand);

            // Assert
            Assert.AreEqual(expectedMinLand, actualMinLand);
        }
        
        //[TestMethod]
        //public void GetListing_ListingReturned_Test()
        //{
        //    // Arrange
        //    var testUrl = "http://www.realestate.com.au/buy/property-house-with-3-bedrooms-between-250000-500000-in-brisbane+-+greater+region%2c+qld%3b+/list-1?newOrEstablished=established&numParkingSpaces=2&numBaths=2&maxBeds=4&misc=ex-under-contract&source=location-search";
            
        //    // Act
        //    var actualListing = testSearch.GetListing(testUrl);

        //    // Assert
        //    //Assert.AreEqual(expectedListing, actualListing);
        //}

        //[TestMethod]
        //public void GetListedProperties_ListPropertiesReturned_Test()
        //{
        //    // Arrange
        //    var expectedListedProperties = new List<string>()
        //    {
        //        "/property-house-qld-upper+mount+gravatt-125119870",
        //        "/property-house-qld-stafford-125119566",
        //        "/property-house-qld-kedron-125118974",
        //        "/property-house-qld-graceville-125118530",
        //        "/property-house-qld-sunnybank-125117498",
        //        "/property-house-qld-new+farm-124919330",
        //        "/property-house-qld-aspley-125117566",
        //        "/property-house-qld-camp+hill-125117530",
        //        "/property-house-qld-brighton-125117378",
        //        "/property-house-qld-kelvin+grove-125117386",
        //        "/property-house-qld-new+farm-125117098",
        //        "/property-house-qld-yeronga-125117014",
        //        "/property-house-qld-fairfield-125116802",
        //        "/property-house-qld-wakerley-124854238",
        //        "/property-house-qld-wakerley-124633458",
        //        "/property-house-qld-heathwood-124819522"
        //    };

        //    // Act
        //    var actualListedProperties = testSearch.GetListedProperties(testSearchResponse);

        //    // Assert
        //    Assert.AreEqual(expectedListedProperties.Count, actualListedProperties.Count);
        //    Assert.AreEqual(expectedListedProperties[0], actualListedProperties[0]);
        //    Assert.AreEqual(expectedListedProperties[1], actualListedProperties[1]);
        //    Assert.AreEqual(expectedListedProperties[2], actualListedProperties[2]);
        //    Assert.AreEqual(expectedListedProperties[3], actualListedProperties[3]);
        //    Assert.AreEqual(expectedListedProperties[4], actualListedProperties[4]);
        //    Assert.AreEqual(expectedListedProperties[5], actualListedProperties[5]);
        //    Assert.AreEqual(expectedListedProperties[6], actualListedProperties[6]);
        //    Assert.AreEqual(expectedListedProperties[7], actualListedProperties[7]);
        //    Assert.AreEqual(expectedListedProperties[8], actualListedProperties[8]);
        //    Assert.AreEqual(expectedListedProperties[9], actualListedProperties[9]);
        //    Assert.AreEqual(expectedListedProperties[10], actualListedProperties[10]);
        //    Assert.AreEqual(expectedListedProperties[11], actualListedProperties[11]);
        //    Assert.AreEqual(expectedListedProperties[12], actualListedProperties[12]);
        //    Assert.AreEqual(expectedListedProperties[13], actualListedProperties[13]);
        //    Assert.AreEqual(expectedListedProperties[14], actualListedProperties[14]);
        //    Assert.AreEqual(expectedListedProperties[15], actualListedProperties[15]);
        //}

        //[TestMethod]
        //public void GetTotalListings_TotalListingsReturnedZero_Test()
        //{
        //    // Arrange
        //    var testTotalHomes = 0;
        //    var expectedTotalHomes = 0;

        //    // Act
        //    var actualTotalHomes = testSearch.GetTotalListings(testTotalHomes);

        //    // Assert
        //    Assert.AreEqual(expectedTotalHomes, actualTotalHomes);
        //}

        //[TestMethod]
        //public void GetTotalListings_TotalListingsReturned1_Test()
        //{
        //    // Arrange
        //    var testTotalHomes = 20;
        //    var expectedTotalHomes = 1;

        //    // Act
        //    var actualTotalHomes = testSearch.GetTotalListings(testTotalHomes);

        //    // Assert
        //    Assert.AreEqual(expectedTotalHomes, actualTotalHomes);
        //}

        //[TestMethod]
        //public void GetTotalListings_TotalListingsReturned2_Test()
        //{
        //    // Arrange
        //    var testTotalHomes = 21;
        //    var expectedTotalHomes = 2;

        //    // Act
        //    var actualTotalHomes = testSearch.GetTotalListings(testTotalHomes);

        //    // Assert
        //    Assert.AreEqual(expectedTotalHomes, actualTotalHomes);
        //}

        //[TestMethod]
        //public void GetEverything_EverythingReturned_Test()
        //{
        //    // Arrange
        //    var testPropertyType = Search.PropertyType.House;
        //    var testMinBeds = Search.Bed.Three;
        //    var testMinLand = 0;
        //    var testMinPrice = Search.Price.TwoHundredAndFiftyThousand;
        //    var testMaxPrice = Search.Price.FiveHundredThousand;
        //    var testLocation = Search.Location.BrisbaneGreaterRegion;
        //    var testConstructionType = Search.ConstructionType.EstablishedProperty;
        //    var testMinCarSpaces = Search.CarSpace.TwoPlus;
        //    var testMinBathrooms = Search.Bathroom.TwoPlus;
        //    var testMaxBeds = Search.Bed.Four;
        //    var testIsIncludingSurroundingSuburbs = true;
        //    var testIsExcludingPropertiesUnderContract = true;
        //    var testListing = 1;

        //    // Act
        //    var actualUrl = testSearch.GetUrl(testPropertyType, testMinBeds, testMinLand, testMinPrice, testMaxPrice, testLocation, testConstructionType, testMinCarSpaces, testMinBathrooms, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract, testListing);
        //    var actualResponse = testSearch.GetWebResponse(actualUrl);
        //    var actualTotalHomes = testSearch.GetTotalHomes();
        //    var actualTotalListings = testSearch.GetTotalListings();


        //    // Assert
        //    Assert.AreEqual(expectedTotalHomes, actualTotalHomes);
        //}
    }
}
