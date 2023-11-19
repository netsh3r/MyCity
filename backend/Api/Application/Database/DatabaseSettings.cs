using Core;
using JetBrains.Annotations;

namespace Api.Application.Database;

public record DatabaseSettings : ISettings
{
    public string ConnectionString { get; init; } = string.Empty;

    public DatabaseHeathCheckSettings HeathCheck { get; init; } = new();

    public bool IsEnabledAutomaticMigrations { get; init; } = true;
}

[PublicAPI]
public record DatabaseHeathCheckSettings
{
    public bool IsEnabled { get; init; }

    public string HeathCheckName { get; init; } = string.Empty;

    public string[] HeathCheckTags { get; init; } = Array.Empty<string>();
}
