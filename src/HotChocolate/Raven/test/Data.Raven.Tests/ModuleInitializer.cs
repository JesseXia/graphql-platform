using System.Runtime.CompilerServices;

namespace HotChocolate.Data.Raven.Test;

internal static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        CookieCrumbleXunit.Initialize();
        CookieCrumbleHotChocolate.Initialize();
    }
}