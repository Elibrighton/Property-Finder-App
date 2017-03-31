using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Property_Finder_App;
using System.IO;

namespace PropertyFinderTests
{
    [TestClass]
    public class AddressTests
    {
        private Address testAddress;
        private string testPropertyResponse;

        [TestInitialize]
        public void Initialize()
        {
            testPropertyResponse = File.ReadAllText(@"C:\Users\Dj Music\Documents\Visual Studio 2015\Projects\Property Finder App\PropertyFinderTests\Supplied files\TestPropertyResponse.html");
            testAddress = new Address(testPropertyResponse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Address response is null")]
        public void InstantiateAddress_AddressInstantiated_Test()
        {
            // Arrange
            var testPropertyResponse = string.Empty;

            // Act
            testAddress = new Address(testPropertyResponse);

            // Assert
        }

        [TestMethod]
        public void GetStreetAddress_StreetAddressReturned_Tests()
        {
            // Arrange
            var expectedStreetAddress = "18 Callitris Street";

            // Act
            var actualStreetAddress = testAddress.GetStreetAddress();

            // Assert
            Assert.AreEqual(expectedStreetAddress, actualStreetAddress);
        }

        [TestMethod]
        public void GetAddressLocality_AddressLocalityReturned_Tests()
        {
            // Arrange
            var expectedAddressLocality = "Acacia Ridge";

            // Act
            var actualAddressLocality = testAddress.GetAddressLocality();

            // Assert
            Assert.AreEqual(expectedAddressLocality, actualAddressLocality);
        }

        [TestMethod]
        public void GetAddressRegion_AddressRegionReturned_Tests()
        {
            // Arrange
            var expectedAddressRegion = "Qld";

            // Act
            var actualAddressRegion = testAddress.GetAddressRegion();

            // Assert
            Assert.AreEqual(expectedAddressRegion, actualAddressRegion);
        }

        [TestMethod]
        public void GetPostalCode_PostalCodeReturned_Tests()
        {
            // Arrange
            var expectedPostalCode = "4110";

            // Act
            var actualPostalCode = testAddress.GetPostalCode();

            // Assert
            Assert.AreEqual(expectedPostalCode, actualPostalCode);
        }
    }
}
