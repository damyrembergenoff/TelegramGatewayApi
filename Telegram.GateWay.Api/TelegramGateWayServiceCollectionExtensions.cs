using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Telegram.GateWay.Abstractions;
using Telegram.GateWay.Abstractions.Models;

namespace Telegram.GateWay.Api;

public static class TelegramGateWayServiceCollectionExtensions
{
    public static IServiceCollection AddTelegramGateWay(this IServiceCollection services, Action<TelegramGateWayOptions> configureOptions)
    {
        var options = new TelegramGateWayOptions();
        configureOptions(options);
        
        if(string.IsNullOrWhiteSpace(options.AccessToken))
            throw new ArgumentException("AccessToken TelegramGateWayOptions ichida korsatilishi shart");

        services.AddHttpClient<ITelegramGatewayClient, TelegramGateWayClient>(client =>
        {
            client.BaseAddress = new Uri(options.BaseUrl ?? "https://gatewayapi.telegram.org/");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {options.AccessToken}");
        });


        services.AddKeyedSingleton(nameof(TelegramGateWayClient), (_, _) =>
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                PropertyNameCaseInsensitive = true
            };

            jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter<EDeliveryStatus>(JsonNamingPolicy.SnakeCaseLower));
            jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter<EVerificationStatus>(JsonNamingPolicy.SnakeCaseLower));

            return jsonSerializerOptions;
        });

        
        return services;
    }

    public static IServiceCollection AddTelegramGateWay(this IServiceCollection services, string token)
    {
        services.AddTelegramGateWay(options => options.AccessToken = token);
        
        return services;
    }
}