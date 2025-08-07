namespace GPBA.Domain.Common;

public static class StringExtension
{
    /// <summary>
    /// Метод переопределения "string.IsNullOrWhiteSpace"
    /// </summary>
    /// <param name="stringExtended"></param>
    /// <returns></returns>
    public static bool IsEmpty(this string? stringExtended)
    {
        return string.IsNullOrWhiteSpace(stringExtended);
    }
}
