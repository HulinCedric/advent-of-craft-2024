using Microsoft.AspNetCore.Mvc.Testing;

namespace Reindeer.Web.Tests;

public class ReindeerWebApplicationFactory : WebApplicationFactory<Program>
{
    public readonly ReindeerRecordingHandler Recording = new();

    public new HttpClient CreateClient() => CreateDefaultClient(ClientOptions.BaseAddress, Recording);
}