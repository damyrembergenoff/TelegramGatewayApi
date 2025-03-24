namespace Telegram.GateWay.Abstractions.Models;


public class VerificationStatus
{
    public EVerificationStatus Status { get; set; }
    public int UpdatedAt { get; set; }
    public string? CodeEntered { get; set; }
}

public enum EVerificationStatus
{
    CodeValid,
    CodeInvalid,
    CodeMaxAttemptsExceeded,
    Expired
}
