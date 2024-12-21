using System.Net.Http.Json;
using Reindeer.Web.Service;
using VerifyTests.Http;

namespace Reindeer.Web.Tests;

public class ReindeerContractTests
{
    private readonly HttpClient _client;
    private readonly ReindeerWebApplicationFactory _webApplication;

    public ReindeerContractTests()
    {
        _webApplication = new ReindeerWebApplicationFactory();
        _client = _webApplication.CreateClient();
        _client.DefaultRequestHeaders.Add("API_KEY", Guid.NewGuid().ToString());
    }

    [Fact]
    public async Task UnauthorizedWithoutApiKeyOnGet()
    {
        _client.DefaultRequestHeaders.Clear();
        await _client.GetAsync("reindeer/40F9D24D-D3E0-4596-ADC5-B4936FF84B19");
        await _webApplication.Verify();
    }

    [Fact]
    public async Task UnauthorizedWithoutApiKeyOnPost()
    {
        _client.DefaultRequestHeaders.Clear();
        var request = new ReindeerToCreateRequest("Vixes", ReindeerColor.Black);
        await _client.PostAsync("reindeer", JsonContent.Create(request));
        await _webApplication.Verify();
    }

    [Fact]
    public async Task ShouldGetReindeer()
    {
        await _client.GetAsync("reindeer/40F9D24D-D3E0-4596-ADC5-B4936FF84B19");
        await _webApplication.Verify();
    }

    [Fact]
    public async Task NotFoundForNotExistingReindeer()
    {
        var nonExistingReindeer = Guid.NewGuid().ToString();
        await _client.GetAsync($"reindeer/{nonExistingReindeer}");
        await _webApplication.Verify();
    }

    [Fact]
    public async Task ShouldCreateReindeer()
    {
        var request = new ReindeerToCreateRequest("Vixes", ReindeerColor.Black);
        await _client.PostAsync("reindeer", JsonContent.Create(request));
        await _webApplication.Verify();
    }

    [Fact]
    public async Task ConflictWhenTryingToCreateExistingOne()
    {
        var request = new ReindeerToCreateRequest("Petar", ReindeerColor.Purple);
        await _client.PostAsync("reindeer", JsonContent.Create(request));
        await _webApplication.Verify();
    }
}