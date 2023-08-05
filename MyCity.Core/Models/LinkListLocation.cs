namespace MyCity.Core.Models;

public class LinkListLocation
{
    public long CurrentIdLocation { get; set; }
    public LinkListLocation? NextLocation { get; set; }
    public string? LocationComment { get; set; }
}