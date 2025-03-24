namespace Telegram.GateWay.Abstractions.Models;

public class SendVerificationMessageRequest(string phoneNumber)
{
    public string PhoneNumber { get; init; } = phoneNumber;
    
    public string? RequestId { get; set; }
    public string? SenderUsername { get; set; }
    public string? Code { get; set; }
    public int? CodeLength { get; set; }
    public string? CallbackUrl { get; set; }
    public string? Payload { get; set; }
    public int? Ttl { get; set; }
}
