using Microsoft.AspNetCore.Mvc;
using Reindeer.Web.Security;
using Reindeer.Web.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = "ApiKeyScheme";
        options.DefaultChallengeScheme = "ApiKeyScheme";
    })
    .AddScheme<ReindeerApiKeyAuthenticationOptions, ReindeerApiKeyAuthenticationHandler>("ApiKeyScheme", _ => { });
builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ReindeerService>(_ => new ReindeerService());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseSwagger()
        .UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/reindeer", ([FromBody] ReindeerToCreateRequest request, ReindeerService service)
        => service.Create(request.ToDomain())
            .Match(
                success => Results.Created(success.Id.ToString(), success),
                Results.Conflict
            ))
    .WithName("PostReindeer")
    .RequireAuthorization()
    .WithOpenApi();

app.MapGet("/reindeer/{id:guid}", (Guid id, ReindeerService service)
        => service.Get(id)
            .Match(
                success => Results.Ok(ReindeerResult.From(success)),
                Results.NotFound
            ))
    .WithName("GetReindeer")
    .RequireAuthorization()
    .WithOpenApi();

app.Run();

public partial class Program;