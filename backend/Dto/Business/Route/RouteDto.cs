using Business.Model.Location;
using Business.Model.RoutePoints;

namespace Business.Model.Route;

public class RouteDto : BaseDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public RoutePointDto[] RoutePointDto { get; set; }
}