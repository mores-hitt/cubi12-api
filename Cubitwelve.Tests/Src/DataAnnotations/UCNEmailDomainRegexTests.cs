using Cubitwelve.Src.DataAnnotations;
using FluentAssertions;

namespace Cubitwelve.Tests.Src.DataAnnotations
{
    public class UCNEmailDomainRegexTests
    {
        private static UCNEmailAddressAttribute CreateDefaultUCNEmailAdressAttribute()
        {
            return new UCNEmailAddressAttribute();
        }


        [Fact]
        public void IsValid_NewStudentEmail_ReturnTrue()
        {
            // Arrange
            var regex = CreateDefaultUCNEmailAdressAttribute();
            var newStudentEmail = "david.araya@alumnos.ucn.cl";

            // Act
            var result = regex.IsValid(newStudentEmail);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_OldStudentEmail_ReturnTrue()
        {
            // Arrange
            var oldStudentEmail = "dac003@alumnos.ucn.cl";
            var regex = CreateDefaultUCNEmailAdressAttribute();

            // Act
            var result = regex.IsValid(oldStudentEmail);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_ExtudentEmail_ReturnTrue()
        {
            // Arrange
            var exStudentEmail = "diego.duarte@ce.ucn.cl";
            var regex = CreateDefaultUCNEmailAdressAttribute();

            // Act
            var result = regex.IsValid(exStudentEmail);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_DiscEmail_ReturnTrue()
        {
            // Arrange
            var discEmail = "ignacia.rivas@disc.ucn.cl";
            var regex = CreateDefaultUCNEmailAdressAttribute();

            // Act
            var result = regex.IsValid(discEmail);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_OldTeacherEmail_ReturnTrue()
        {
            // Arrange
            var oldTeacherEmail = "durrutia@ucn.cl";
            var regex = CreateDefaultUCNEmailAdressAttribute();

            // Act
            var result = regex.IsValid(oldTeacherEmail);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_NewTeacherEmail_ReturnTrue()
        {
            // Arrange
            var newTeacherEmail = "diego.duarte@ucn.cl";
            var regex = CreateDefaultUCNEmailAdressAttribute();

            // Act
            var result = regex.IsValid(newTeacherEmail);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_NullValue_ReturnFalse()
        {
            // Arrange
            string? invalidEmail = null;
            var regex = CreateDefaultUCNEmailAdressAttribute();

            // Act
            var result = regex.IsValid(invalidEmail);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_GmailEmail_ReturnFalse()
        {
            // Arrange
            var gmailEmail = "david@gmail.com";
            var regex = CreateDefaultUCNEmailAdressAttribute();

            // Act
            var result = regex.IsValid(gmailEmail);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_InvalidEmail_ReturnFalse()
        {
            // Arrange
            var invalidEmail = "aa";
            var regex = CreateDefaultUCNEmailAdressAttribute();

            // Act
            var result = regex.IsValid(invalidEmail);

            // Assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("david.araya@ucn.co")]
        [InlineData("david.araya@ucn.com")]
        [InlineData("david.araya@ucn.net")]
        [InlineData("david.araya@ucn.ar")]
        [InlineData("david.araya@ucn.ch")]
        [InlineData("david.araya@ucn.org")]
        [InlineData("david.araya@ucn.io")]
        public void IsValid_InvalidRegionUcnEmail_ReturnFalse(string email)
        {
            // Arrange
            var regex = CreateDefaultUCNEmailAdressAttribute();

            // Act
            var result = regex.IsValid(email);

            // Assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void IsValid_EmptyString_ReturnFalse(string email)
        {
            // Arrange
            var regex = CreateDefaultUCNEmailAdressAttribute();

            // Act
            var result = regex.IsValid(email);

            // Assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("david@ucn..cl")]
        [InlineData("david@.ucn.cl")]
        [InlineData("david@ce.ucn..cl")]
        [InlineData("david@.ce.ucn.cl")]
        [InlineData("david@.ce.ucn..cl")]
        [InlineData("david@.disc.ucn.cl")]
        [InlineData("david@.disc.ucn..cl")]
        public void IsValid_InvalidDotsUcnEmail_ReturnFalse(string email)
        {
            // Arrange
            var regex = CreateDefaultUCNEmailAdressAttribute();

            // Act
            var result = regex.IsValid(email);

            // Assert
            result.Should().BeFalse();
        }

    }
}