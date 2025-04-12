using EShop.Application.Services;
using Xunit;

namespace EShop.Application.Tests.ServicesTests
{
    public class CreditCardServiceTests
    {
        private readonly CreditCardService _service = new();

        [Theory]
        [InlineData("3497 7965 8312 797", true, "American Express")]
        [InlineData("345-470-784-783-010", true, "American Express")]
        [InlineData("378523393817437", true, "American Express")]
        [InlineData("4024-0071-6540-1778", true, "Visa")]
        [InlineData("4532 2080 2150 4434", true, "Visa")]
        [InlineData("4532289052809181", true, "Visa")]
        [InlineData("5530016454538418", true, "MasterCard")]
        [InlineData("5551561443896215", true, "MasterCard")]
        [InlineData("5131208517986691", true, "MasterCard")]
        [InlineData("0000 0000 0000 0000", false, null)]
        [InlineData("1234-5678-9012-3456", false, null)]
        public void Validate_ShouldReturnExpectedResults(string number, bool expectedValid, string expectedType)
        {
            var result = _service.Validate(number);

            Assert.Equal(expectedValid, result.IsValid);
            Assert.Equal(expectedType, result.CardType);
        }

        [Theory]
        [InlineData("378523393817437", "American Express")]
        [InlineData("4532 2080 2150 4434", "Visa")]
        [InlineData("5530016454538418", "MasterCard")]
        [InlineData("6011000000000004", "Discover")]
        [InlineData("3528000700000000", "JCB")]
        [InlineData("30569309025904", "Diners Club")]
        [InlineData("6759649826438453", "Maestro")]
        [InlineData("9999999999999999", "Unknown")]
        public void GetCardType_ShouldDetectCorrectIssuer(string cardNumber, string expectedType)
        {
            var actualType = _service.GetCardType(cardNumber);

            Assert.Equal(expectedType, actualType);
        }

        [Fact]
        public void ValidateCard_ShouldReturnFalseForInvalidCharacters()
        {
            var result = _service.ValidateCard("4111-11ab-1111-1111");
            Assert.False(result);
        }
    }
}
