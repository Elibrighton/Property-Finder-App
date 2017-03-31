using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Property_Finder_App;
using System.IO;

namespace PropertyFinderTests
{
    [TestClass]
    public class PropertyTests
    {
        private Property testProperty;
        private string testPropertyResponse;

        [TestInitialize]
        public void Initialize()
        {
            testPropertyResponse = File.ReadAllText(@"C:\Users\Dj Music\Documents\Visual Studio 2015\Projects\Property Finder App\PropertyFinderTests\Supplied files\TestPropertyResponse.html");
            testProperty = new Property(testPropertyResponse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Property response is null")]
        public void InstantiateProperty_PropertyInstantiated_Test()
        {
            // Arrange
            var testPropertyResponse = string.Empty;

            // Act
            testProperty = new Property(testPropertyResponse);

            // Assert
        }

        [TestMethod]
        public void SetUrl_UrlSet_Test()
        {
            // Arrange
            var testPath = "/property-house-qld-upper+mount+gravatt-125119870";
            var expectedUrl = "http://www.realestate.com.au/property-house-qld-upper+mount+gravatt-125119870";

            // Act
            testProperty.SetUrl(testPath);
            var actualUrl = testProperty.Url;

            // Assert
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Property url path is null")]
        public void GetUrl_ArgumentNullException_Test()
        {
            // Arrange
            var testPath = string.Empty;

            // Act
            testProperty.SetUrl(testPath);

            // Assert
        }

        [TestMethod]
        public void GetPrice_PriceReturned_Test()
        {
            // Arrange
            var expectedPrice = "Auction";

            // Act
            var actualPrice = testProperty.GetPrice();

            // Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        public void GetPropertyType_PropertyTypeReturned_Test()
        {
            // Arrange
            var expectedPropertyType = "House";

            // Act
            var actualPropertyType = testProperty.GetPropertyType();

            // Assert
            Assert.AreEqual(expectedPropertyType, actualPropertyType);
        }

        [TestMethod]
        public void GetBedrooms_BedroomsReturned_Test()
        {
            // Arrange
            var expectedBedrooms = 3;

            // Act
            var actualBedrooms = testProperty.GetBedrooms();

            // Assert
            Assert.AreEqual(expectedBedrooms, actualBedrooms);
        }

        [TestMethod]
        public void GetBathrooms_BathroomsReturned_Test()
        {
            // Arrange
            var expectedBathrooms = 2;

            // Act
            var actualBathrooms = testProperty.GetBathrooms();

            // Assert
            Assert.AreEqual(expectedBathrooms, actualBathrooms);
        }
        
        [TestMethod]
        public void GetLandSize_LandSizeReturned_Test()
        {
            // Arrange
            var expectedLandSize = "1055 m² (approx)";

            // Act
            var actualLandSize = testProperty.GetLandSize();

            // Assert
            Assert.AreEqual(expectedLandSize, actualLandSize); // this property has no land size
        }

        [TestMethod]
        public void GetCarSpaces_CarSpacesReturned_Test()
        {
            // Arrange
            var expectedCarSpaces = 2;

            // Act
            var actualCarSpaces = testProperty.GetCarSpaces();

            // Assert
            Assert.AreEqual(expectedCarSpaces, actualCarSpaces);
        }
    }
}
