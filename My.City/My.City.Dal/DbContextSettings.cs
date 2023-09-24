using My.City.Common;
using JetBrains.Annotations;

namespace My.City.Dal;

[PublicAPI]
public record DbContextSettings : ISettings
{
    public bool IsEnabledSensitiveDataLogging { get; init; }
}