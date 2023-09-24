using My.City.Common;

namespace My.City.Api.Application.WebHost;

[PublicAPI]
public record StartupSettings : ISettings
{
    public AssemblyFilter AssemblyFilter { get; init; } = new();

    public ICollection<string> RootAssemblies { get; set; } = new List<string>();
}

[PublicAPI]
public record AssemblyFilter
{
    public ICollection<string> Filters { get; init; } = new List<string>();
}
