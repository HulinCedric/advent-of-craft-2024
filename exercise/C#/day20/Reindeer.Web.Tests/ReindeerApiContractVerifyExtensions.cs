using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace Reindeer.Web.Tests;

public static class ReindeerApiContractVerifyExtensions
{
    public static async Task Verify(
        this ReindeerWebApplicationFactory webApplication,
        VerifySettings? settings = null,
        [CallerFilePath] string sourceFile = "")
    {
        await Verifier.Verify(
                webApplication.Recording.Sends.FirstOrDefault(),
                settings,
                sourceFile)
            .ScrubInlineGuids();
    }
}