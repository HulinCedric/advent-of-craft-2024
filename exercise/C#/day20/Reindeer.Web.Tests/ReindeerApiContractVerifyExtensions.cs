using System.Runtime.CompilerServices;

namespace Reindeer.Web.Tests;

public static class ReindeerApiContractVerifyExtensions
{
    public static SettingsTask VerifyApiContract(
        HttpResponseMessage response,
        VerifySettings? settings = null,
        [CallerFilePath] string sourceFile = "")
        => Verify(
                new
                {
                    Request = response.RequestMessage,
                    Response = response
                },
                settings,
                sourceFile)
            .ScrubInlineGuids();
}