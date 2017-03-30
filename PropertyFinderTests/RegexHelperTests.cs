using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Property_Finder_App;

namespace PropertyFinderTests
{
    [TestClass]
    public class RegexHelperTests
    {
        [TestMethod]
        public void GetRegexMatchValue_MatchValueReturned_Test()
        {
            // Arrange
            var testText = "11308 total results";
            var testPattern = @"^\d*";
            var expectedMatchValue = 11308;

            // Act
            var actualMatchValue = Convert.ToInt32(RegexHelper.GetRegexMatchValue(testText, testPattern));

            // Assert
            Assert.AreEqual(expectedMatchValue, actualMatchValue);
        }
    }
}
