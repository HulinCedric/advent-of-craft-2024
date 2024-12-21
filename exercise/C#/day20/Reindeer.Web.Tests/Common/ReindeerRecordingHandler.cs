using System.Collections.Concurrent;

namespace Reindeer.Web.Tests.Common;

public class ReindeerRecordingHandler : DelegatingHandler
{
    private readonly ConcurrentQueue<ReindeerLoggedSend> _sends = new();

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);

        _sends.Enqueue(new ReindeerLoggedSend(request, response));

        return response;
    }
    
    public IReadOnlyList<ReindeerLoggedSend> Logs() => _sends.ToList().AsReadOnly();
}