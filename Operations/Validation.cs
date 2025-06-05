namespace Operations;

public class Validation
{
    /// <summary>
    /// Null safe Convert String to Double
    /// </summary>
    /// <param name="input">The string to convert</param>
    /// <param name="result">The result of the conversion</param>
    /// <returns>true if successful, otherwise false</returns>
    public static bool NullSafeConvertToDouble(string? input, out double result)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            result = double.MinValue;
            return false;
        }
        return double.TryParse(input, out result);
    }
}
