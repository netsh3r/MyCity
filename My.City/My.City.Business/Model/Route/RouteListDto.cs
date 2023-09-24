using Business.Model.Location;

namespace Business.Model.Route;

public class RouteListDto: BaseDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}