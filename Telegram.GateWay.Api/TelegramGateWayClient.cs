using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Telegram.GateWay.Abstractions;
using Telegram.GateWay.Abstractions.Models;

namespace Telegram.GateWay.Api;

public class TelegramGateWayClient(HttpClient httpClient, IServiceProvider serviceProvider) : ITelegramGatewayClient
{
    private readonly JsonSerializerOptions jsonSerializerOptions = serviceProvider.GetKeyedService<JsonSerializerOptions>(nameof(TelegramGateWayClient))
        ?? throw new InvalidOperationException($"{nameof(TelegramGateWayClient)}: {nameof(JsonSerializerOptions)} not found");

    public async Task<ApiResponse<RequestStatus>> CheckSendAbilityAsync(string phoneNumber, CancellationToken cancellationToken)
    {
        var response = await httpClient.PostAsJsonAsync("checkSendAbility", new { phoneNumber }, jsonSerializerOptions, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ApiResponse<RequestStatus>>(jsonSerializerOptions, cancellationToken) 
        ?? throw new InvalidOperationException("Failed to deserialize response");

    }

    public async Task<ApiResponse<RequestStatus>> CheckVerificationStatusAsync(CheckVerificationStatusRequest request, CancellationToken cancellationToken)
    {
        var response = await httpClient.PostAsJsonAsync("checkverificationStatus", request, jsonSerializerOptions, cancellationToken);
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<RequestStatus>>(jsonSerializerOptions, cancellationToken);

        if(apiResponse == null)
        {
            throw new Exception("Failed to deserialize response");
        }

        return apiResponse;
    }

    public async Task<ApiResponse<bool>> RevokeVerificationMessageAsync(string requestId, CancellationToken cancellationToken)
    {
        var response = await httpClient.PostAsJsonAsync("revokeVerificationMessage", new { requestId }, jsonSerializerOptions, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ApiResponse<bool>>(jsonSerializerOptions, cancellationToken)
        ?? throw new Exception("Failed to deserialize response");
    }

    public async Task<ApiResponse<RequestStatus>> SendVerificationMessageAsync(SendVerificationMessageRequest request, CancellationToken cancellationToken)
    {
        var response = await httpClient.PostAsJsonAsync("sendverificationMessage", request, jsonSerializerOptions, cancellationToken);
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<RequestStatus>>(jsonSerializerOptions, cancellationToken);

        if(apiResponse == null)
        {
            throw new Exception("Failed to deserialize response");
        }

        return apiResponse;
    }
}
