namespace Telegram.GateWay.Abstractions.Models;

public class CheckVerificationStatusRequest(string requestId)
{
    public string RequestId { get; init; } = requestId;
    
    public string? Code { get; set; }
}
