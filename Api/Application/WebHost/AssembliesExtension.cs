using System.Reflection;
using Common.Extension;

namespace Api.Application.WebHost;

public static class AssembliesExtension
{
    public static IEnumerable<Assembly> GetAssemblies(IConfiguration configuration)
    {
        var startupSettings = configuration.GetSettingsOrDefault<StartupSettings>();
        var entryAssemblies = startupSettings.RootAssemblies.Select(Assembly.Load).Append(Assembly.GetEntryAssembly() 
            ?? throw new Exception("EntryAssembly didn't find. Check the connected packages")).ToList();

        var filters = startupSettings.AssemblyFilter.Filters.ToList();

        var entryAssemblyReferencedAssemblies = entryAssemblies.SelectMany(_ => _.GetReferencedAssemblies())
            .Where(IsFilteredAssemblyName(filters)).Select(Assembly.Load).Concat(entryAssemblies).ToList();

        return entryAssemblyReferencedAssemblies;

        static Func<AssemblyName, bool> IsFilteredAssemblyName(IEnumerable<string> filters)
        {
            return x => filters.Any(filter => !string.IsNullOrEmpty(x.FullName) && x.FullName.Contains(filter));
        }
    }
}
