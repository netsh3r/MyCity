using Common;
using Core;

namespace Api.Application.WebHost;

public record StartupSettings : ISettings
{
    public AssemblyFilter AssemblyFilter { get; init; } = new();

    public ICollection<string> RootAssemblies { get; set; } = new List<string>();
}

public record AssemblyFilter
{
    public ICollection<string> Filters { get; init; } = new List<string>();
}
