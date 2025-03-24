namespace Telegram.GateWay.Abstractions;

public class ApiResponse<T>
{
    public bool Ok { get; set; }
    public T? Result { get; set; }
    public string? Error { get; set; }
}