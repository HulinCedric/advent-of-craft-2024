using System.Runtime.CompilerServices;

namespace Reindeer.Web.Tests;

public static class ReindeerApiContractVerifyExtensions
{
    public static async Task Verify(
        this Task<HttpResponseMessage> call,
        VerifySettings? settings = null,
        [CallerFilePath] string sourceFile = "")
    {
        var response = await call;

        await Verifier.Verify(
                new
                {
                    Request = response.RequestMessage,
                    Response = response
                },
                settings,
                sourceFile)
            .ScrubInlineGuids();
    }
}