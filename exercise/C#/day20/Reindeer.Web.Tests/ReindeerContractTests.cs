using System.Net.Http.Json;
using Reindeer.Web.Service;

namespace Reindeer.Web.Tests
{
    public class ReindeerContractTests
    {
        private readonly HttpClient _client;

        public ReindeerContractTests()
        {
            var webApplication = new ReindeerWebApplicationFactory();
            _client = webApplication.CreateClient();
        }

        [Fact]
        public async Task ShouldGetReindeer()
        {
            var response = await _client.GetAsync("reindeer/40F9D24D-D3E0-4596-ADC5-B4936FF84B19");

            await Verify(response);
        }

        [Fact]
        public async Task NotFoundForNotExistingReindeer()
        {
            var nonExistingReindeer = Guid.NewGuid().ToString();
            var response = await _client.GetAsync($"reindeer/{nonExistingReindeer}");

            await Verify(response);
        }

        [Fact]
        public async Task ConflictWhenTryingToCreateExistingOne()
        {
            var request = new ReindeerToCreateRequest("Petar", ReindeerColor.Purple);
            var response = await _client.PostAsync("reindeer", JsonContent.Create(request));

            await Verify(response);
        }
    }
}