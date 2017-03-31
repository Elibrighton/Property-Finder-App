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
            testProperty = new Property();
            testPropertyResponse = File.ReadAllText(@"C:\Users\Dj Music\Documents\Visual Studio 2015\Projects\Property Finder App\PropertyFinderTests\Supplied files\TestPropertyResponse.html");
        }

        [TestMethod]
        public void GetUrl_UrlReturned_Test()
        {
            // Arrange
            var testPath = "/property-house-qld-upper+mount+gravatt-125119870";
            var expectedUrl = "http://www.realestate.com.au/property-house-qld-upper+mount+gravatt-125119870";

            // Act
            var actualUrl = testProperty.GetUrl(testPath);

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
            var actualUrl = testProperty.GetUrl(testPath);

            // Assert
        }
    }
}
