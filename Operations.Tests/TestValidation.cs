using Shouldly;

namespace Operations.Tests
{
    public class TestValidation
    {
        [Theory]
        [InlineData("123.45", true, 123.45)]
        [InlineData("abc", false, 0.0)]
        [InlineData("qwer", false, 0.0)]
        [InlineData("123.45abc", false, 0.0)]
        [InlineData("123.45,67", false, 0.0)]
        [InlineData("123,4567", true, 1234567.0)]
        [InlineData(null, false, double.MinValue)]
        [InlineData("", false, double.MinValue)]
        public void TestNullSafeConvertToDouble(string? input, bool expected, double expectedOutValue)
        {
            //arrange & act
            var result = Validation.NullSafeConvertToDouble(input, out double outValue);

            //assert
            result.ShouldBe(expected, $"Result of conversion success: {result} - was not as expected: {expected}");
            outValue.ShouldBe(expectedOutValue, $"Output value: {outValue} - was not as expected: {expectedOutValue}");
        }
    }
}
