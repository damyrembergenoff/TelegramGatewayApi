namespace Telegram.GateWay.Abstractions.Models;


public class DeliveryStatus
{
    public EDeliveryStatus Status { get; set; }
    public int UpdatedAt { get; set; }
}

public enum EDeliveryStatus
{
    sent,
    delivered,
    read,
    expired,
    revoked
}