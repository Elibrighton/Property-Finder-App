using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Property_Finder_App;

namespace PropertyFinderTests
{
    [TestClass]
    public class PropertyFinderTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var testSearch = new Search();
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

            // Act
            testSearch.Set(testPropertyType, testMinBeds, testMinLand, testMinPrice, testMaxPrice, testLocation, testConstructionType, testMinCarSpaces, testMinBathrooms, testMaxBeds, testIsIncludingSurroundingSuburbs, testIsExcludingPropertiesUnderContract);
            testSearch.GenerateUrl();
            var testUrl = testSearch.Url;
            var testListing = new Listing(testUrl);

            if (testListing != null)
            {
                foreach (var listingPage in testListing.ListingPages)
                {
                    foreach (var property in listingPage.Properties)
                    {
                        System.Diagnostics.Debug.WriteLine(property.LandSize);
                    }
                }
            }
            // Assert
        }
    }
}
