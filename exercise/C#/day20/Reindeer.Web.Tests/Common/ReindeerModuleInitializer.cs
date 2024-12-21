using System.Runtime.CompilerServices;

namespace Reindeer.Web.Tests.Common;

public static class ReindeerModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize() => VerifyHttp.Initialize();
}