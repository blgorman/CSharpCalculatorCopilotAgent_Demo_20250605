namespace Operations;

public class Calculations
{
    /// <summary>
    /// Adds two numbers together
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number</param>
    /// <returns>The sum of a and b</returns>
    public static double Add(double a, double b)
    {
        return a + b;
    }

    /// <summary>
    /// Subtracts the second number from the first number
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number to subtract</param>
    /// <returns>The difference of a and b</returns>
    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    /// <summary>
    /// Multiplies two numbers together
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number</param>
    /// <returns>The product of a and b</returns>
    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    /// <summary>
    /// Divides the first number by the second number
    /// </summary>
    /// <param name="a">Dividend</param>
    /// <param name="b">Divisor</param>
    /// <returns>The quotient of a and b</returns>
    /// <exception cref="DivideByZeroException">Thrown when b is zero</exception>
    public static double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }
        return a / b;
    }

    /// <summary>
    /// Calculates the remainder when the first number is divided by the second number
    /// </summary>
    /// <param name="a">Dividend</param>
    /// <param name="b">Divisor</param>
    /// <returns>The remainder of a divided by b</returns>
    /// <exception cref="DivideByZeroException">Thrown when b is zero</exception>
    public static double Remainder(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot calculate remainder with divisor of zero");
        }
        return a % b;
    }
}