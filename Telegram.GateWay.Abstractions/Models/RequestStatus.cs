namespace Telegram.GateWay.Abstractions.Models;

public class RequestStatus
{
    public string? RequestId { get; init; }
    public string? PhoneNumber { get; init; }
    public float RequestCost { get; init; }
    public float? RemainingBalance { get; set; }
    public DeliveryStatus? DeliveryStatus { get; set; }
    public VerificationStatus? VerificationStatus { get; set; }
    public string? Payload { get; set; }
    public bool? IsRefunded { get; set; }
}