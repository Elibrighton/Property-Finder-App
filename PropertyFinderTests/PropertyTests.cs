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
        public void InstantiateProperty_PropertyInstantiated_Test()
        {
            // Arrange
            var expectedAddress = new Address(testPropertyResponse)
            {
                StreetAddress = "18 Callitris Street",
                AddressLocality = "Acacia Ridge",
                AddressRegion = "Qld",
                PostalCode = "4110"
            };

            var expectedPropertyNo = 125115106;
            var expectedUrl = "http://www.realestate.com.au/property-house-qld-upper+mount+gravatt-125119870";
            var expectedPrice = "Auction";
            var expectedPropertyType = "House";
            var expectedBedrooms = 3;
            var expectedBathrooms = 2;
            var expectedLandSize = 1055;
            var expectedCarSpaces = 2;

            // Act
            var actualAddress = testProperty.Address;
            var actualPropertyNo = testProperty.PropertyNo;
            var actualPrice = testProperty.Price;
            var actualPropertyType = testProperty.PropertyType;
            var actualBedrooms = testProperty.Bedrooms;
            var actualBathrooms = testProperty.Bathrooms;
            var actualLandSize = testProperty.LandSize;
            var actualCarSpaces = testProperty.CarSpaces;


            // Assert
            Assert.AreEqual(expectedAddress.StreetAddress, actualAddress.StreetAddress);
            Assert.AreEqual(expectedAddress.AddressLocality, actualAddress.AddressLocality);
            Assert.AreEqual(expectedAddress.AddressRegion, actualAddress.AddressRegion);
            Assert.AreEqual(expectedAddress.PostalCode, actualAddress.PostalCode);
            Assert.AreEqual(expectedPropertyNo, actualPropertyNo);
            Assert.AreEqual(expectedPrice, actualPrice);
            Assert.AreEqual(expectedPropertyType, actualPropertyType);
            Assert.AreEqual(expectedBedrooms, actualBedrooms);
            Assert.AreEqual(expectedBathrooms, actualBathrooms);
            Assert.AreEqual(expectedLandSize, actualLandSize);
            Assert.AreEqual(expectedCarSpaces, actualCarSpaces);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Property response is null")]
        public void InstantiateProperty_ArgumentNullExceptionRaised_Test()
        {
            // Arrange
            var testPropertyResponse = string.Empty;

            // Act
            testProperty = new Property(testPropertyResponse);

            // Assert
        }

        [TestMethod]
        public void GetPrice_PriceReturned_Test()
        {
            // Arrange
            var expectedPrice = 0;

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
            var expectedLandSize = 1055;

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
            var actualCarSpaces = testProperty.GetCarportSpaces();

            // Assert
            Assert.AreEqual(expectedCarSpaces, actualCarSpaces);
        }

        [TestMethod]
        public void GetPropertyNo_PropertyNoReturned_Test()
        {
            // Arrange
            var expectedPropertyNo = 125115106;

            // Act
            var actualPropertyNo = testProperty.GetPropertyNo();

            // Assert
            Assert.AreEqual(expectedPropertyNo, actualPropertyNo);
        }
    }
}
