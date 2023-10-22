using Core;

namespace Dal;

public record DbContextSettings : ISettings
{
    public bool IsEnabledSensitiveDataLogging { get; init; }
}