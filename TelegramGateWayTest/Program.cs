using Microsoft.AspNetCore.Mvc;
using Telegram.GateWay.Abstractions;
using Telegram.GateWay.Abstractions.Models;
using Telegram.GateWay.Api;

var builder = WebApplication.CreateBuilder(args);

// 1-usul
builder.Services.AddTelegramGateWay(options =>
{
    options.AccessToken = builder.Configuration["TelegramGateWay:AccessToken"];
    options.BaseUrl = "https://gatewayapi.telegram.org/"; // optinal yozmasangizham bolaveradi
});

// 2-usul
// builder.Services.AddTelegramGateWay(
//     builder.Configuration["TelegramGateWay:AccessToken"]
//     ?? throw new Exception("Token is required")
// ); 

var app = builder.Build();

app.MapGet("/checkSendAbility", async (
    [FromQuery] string phone, 
    [FromServices] ITelegramGatewayClient client) =>
{
    var result = await client.CheckSendAbilityAsync(phone);
    return Results.Ok(result);
});


app.MapGet("/checkVerificationStatus", async (
    [FromQuery] string requestId,
    [FromQuery] string? code,
    [FromServices] ITelegramGatewayClient client) =>
{
    var result = await client.CheckVerificationStatusAsync(new CheckVerificationStatusRequest(requestId) { Code = code });
    return Results.Ok(result);
});

app.MapGet("/revokeVerificationMessage", async (
    [FromQuery] string requestId,
    [FromServices] ITelegramGatewayClient client) =>
{
    try
    {
        var result = await client.RevokeVerificationMessageAsync(requestId);
        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.MapGet("/sendVerificationMessage", async (
    [FromQuery] string phone,
    [FromQuery] string? code,
    [FromQuery] string? codeLength,
    [FromServices] ITelegramGatewayClient client) =>
{
    try
    {
        var result = await client.SendVerificationMessageAsync(new SendVerificationMessageRequest(phone)
        {
            Code = code,
            CodeLength = int.Parse(codeLength ?? "6")
        });
        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.Run();