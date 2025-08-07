namespace GPBA.Domain.Common;

public class Error
{
    /// <summary>
    /// Константа "разделитель строки"
    /// </summary>
    private const string SEPARATOR = "||";

    /// <summary>
    /// Ошибка с пустыми полями
    /// </summary>
    public static readonly Error None = new(String.Empty, String.Empty);

    /// <summary>
    /// Код ошибки
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Сообщение ошибки
    /// </summary>
    public string Message { get; }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    /// <summary>
    /// Метод сериализация сообщения
    /// </summary>
    /// <returns></returns>
    public string Serialize()
    {
        return $"{Code}{SEPARATOR}{Message}";
    }

    /// <summary>
    /// Метод десериализации сообщения
    /// </summary>
    /// <param name="serialized"></param>
    /// <returns></returns>
    public static Error Deserialize(string serialized)
    {
        var data = serialized.Split([SEPARATOR], StringSplitOptions.RemoveEmptyEntries);

        if (data.Length < 2)
            return new Error("unexpected", data[0]);

        return new(data[0], data[1]);
    }
}
