using System.Collections.Concurrent;

namespace Reindeer.Web.Tests;

public class ReindeerRecordingHandler : DelegatingHandler
{
    public readonly ConcurrentQueue<ReindeerLoggedSend> Sends = new();

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);

        Sends.Enqueue(new ReindeerLoggedSend(request, response));

        return response;
    }
}