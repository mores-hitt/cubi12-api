using Cubitwelve.Src.DataAnnotations;

namespace Cubitwelve.Tests.Src.DataAnnotations
{
    public class RutRegexTests
    {
        private const string RUT_WITHOUT_HYPHEN = "20.767.6918";
        private const string RUT_WITHOUT_DOTS = "20767691-8";
        private const string RUT_WITHOUT_DOTS_AND_HYPHEN = "207676918";
        private const string RUT_WITHOUT_SOME_DIGITS = "20.761-8";
        private const string STRING_NULL = null;

        private static RutAttribute RutAttributeProvider()
        {
            return new RutAttribute();
        }

        [Theory]
        [InlineData("20.767.691-8")]
        [InlineData("20.778.529-6")]
        [InlineData("6.700.613-5")]
        public void IsValid_ValidRut_ReturnTrue(string rut)
        {
            // Arrange
            var rutAttribute = RutAttributeProvider();

            // Act
            var result = rutAttribute.IsValid(rut);

            // Assert
            Assert.True(result, $"Rut: {rut} should be valid");
        }

        [Theory]
        [InlineData(RUT_WITHOUT_DOTS_AND_HYPHEN)]
        [InlineData(RUT_WITHOUT_DOTS)]
        [InlineData(RUT_WITHOUT_HYPHEN)]
        [InlineData(RUT_WITHOUT_SOME_DIGITS)]
        [InlineData(STRING_NULL)]
        [InlineData("'20.778.529-6")]
        [InlineData("20.778.529-66")]
        [InlineData("7.199.716-02")]
        [InlineData("2.077.852-96")]
        [InlineData("20.778.529-7")]

        public void IsValid_RutWithErrors_ReturnFalse(string rut)
        {
            // Arrange
            var rutAttribute = RutAttributeProvider();

            // Act
            var result = rutAttribute.IsValid(rut);

            // Assert
            Assert.False(result, $"Rut: {rut} should be invalid");
        }
    }
}