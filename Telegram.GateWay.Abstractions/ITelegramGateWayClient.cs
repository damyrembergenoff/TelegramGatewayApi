using Telegram.GateWay.Abstractions.Models;

namespace Telegram.GateWay.Abstractions;

public interface ITelegramGatewayClient
{
    Task<ApiResponse<RequestStatus>> SendVerificationMessageAsync(SendVerificationMessageRequest request, CancellationToken cancellationToken = default);
    Task<ApiResponse<RequestStatus>> CheckSendAbilityAsync(string phoneNumber, CancellationToken cancellationToken = default);
    Task<ApiResponse<RequestStatus>> CheckVerificationStatusAsync(CheckVerificationStatusRequest request, CancellationToken cancellationToken = default);
    Task<ApiResponse<bool>> RevokeVerificationMessageAsync(string requestId, CancellationToken cancellationToken = default);
}
