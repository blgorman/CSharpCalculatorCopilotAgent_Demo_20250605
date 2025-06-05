using Shouldly;

namespace Operations.Tests
{
    public class TestCalculations
    {
        [Theory]
        [InlineData(2.0, 3.0, 5.0)]
        [InlineData(-1.0, 1.0, 0.0)]
        [InlineData(0.0, 0.0, 0.0)]
        [InlineData(10.5, 2.3, 12.8)]
        [InlineData(-5.2, -3.1, -8.3)]
        [InlineData(double.MaxValue, 0, double.MaxValue)]
        [InlineData(double.MinValue, 0, double.MinValue)]
        public void TestAdd(double a, double b, double expected)
        {
            // arrange & act
            var result = Calculations.Add(a, b);

            // assert
            result.ShouldBe(expected, tolerance: 0.000001);
        }

        [Theory]
        [InlineData(5.0, 3.0, 2.0)]
        [InlineData(0.0, 1.0, -1.0)]
        [InlineData(0.0, 0.0, 0.0)]
        [InlineData(10.5, 2.3, 8.2)]
        [InlineData(-5.2, -3.1, -2.1)]
        [InlineData(double.MaxValue, 0, double.MaxValue)]
        [InlineData(double.MinValue, 0, double.MinValue)]
        public void TestSubtract(double a, double b, double expected)
        {
            // arrange & act
            var result = Calculations.Subtract(a, b);

            // assert
            result.ShouldBe(expected, tolerance: 0.000001);
        }

        [Theory]
        [InlineData(2.0, 3.0, 6.0)]
        [InlineData(-2.0, 3.0, -6.0)]
        [InlineData(0.0, 5.0, 0.0)]
        [InlineData(5.0, 0.0, 0.0)]
        [InlineData(2.5, 4.0, 10.0)]
        [InlineData(-2.5, -4.0, 10.0)]
        [InlineData(1.5, 2.0, 3.0)]
        public void TestMultiply(double a, double b, double expected)
        {
            // arrange & act
            var result = Calculations.Multiply(a, b);

            // assert
            result.ShouldBe(expected, tolerance: 0.000001);
        }

        [Theory]
        [InlineData(6.0, 2.0, 3.0)]
        [InlineData(-6.0, 2.0, -3.0)]
        [InlineData(6.0, -2.0, -3.0)]
        [InlineData(-6.0, -2.0, 3.0)]
        [InlineData(0.0, 5.0, 0.0)]
        [InlineData(7.5, 2.5, 3.0)]
        [InlineData(1.0, 0.5, 2.0)]
        public void TestDivide(double a, double b, double expected)
        {
            // arrange & act
            var result = Calculations.Divide(a, b);

            // assert
            result.ShouldBe(expected, tolerance: 0.000001);
        }

        [Theory]
        [InlineData(0.0)]
        public void TestDivideByZeroThrowsException(double divisor)
        {
            // arrange & act & assert
            Should.Throw<DivideByZeroException>(() => Calculations.Divide(10.0, divisor));
        }

        [Theory]
        [InlineData(7.0, 3.0, 1.0)]
        [InlineData(10.0, 4.0, 2.0)]
        [InlineData(-7.0, 3.0, -1.0)]
        [InlineData(7.0, -3.0, 1.0)]
        [InlineData(-7.0, -3.0, -1.0)]
        [InlineData(5.5, 2.0, 1.5)]
        [InlineData(0.0, 5.0, 0.0)]
        public void TestRemainder(double a, double b, double expected)
        {
            // arrange & act
            var result = Calculations.Remainder(a, b);

            // assert
            result.ShouldBe(expected, tolerance: 0.000001);
        }

        [Theory]
        [InlineData(0.0)]
        public void TestRemainderByZeroThrowsException(double divisor)
        {
            // arrange & act & assert
            Should.Throw<DivideByZeroException>(() => Calculations.Remainder(10.0, divisor));
        }
    }
}