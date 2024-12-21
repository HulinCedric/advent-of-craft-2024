using Microsoft.AspNetCore.Mvc.Testing;

namespace Reindeer.Web.Tests.Common;

public class ReindeerWebApplicationFactory : WebApplicationFactory<Program>
{
    private readonly ReindeerRecordingHandler _recording = new();

    public new HttpClient CreateClient() => CreateDefaultClient(ClientOptions.BaseAddress, _recording);

    public IReadOnlyList<ReindeerLoggedSend> Logs() => _recording.Logs();
}