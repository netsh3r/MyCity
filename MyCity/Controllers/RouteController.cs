using Microsoft.AspNetCore.Mvc;
using MyCity.Core.Services;
using Route = MyCity.DataAccess.Entities.Route;

namespace MyCity.Controllers;

[ApiController]
[Route("[controller]")]
public class RouteController : ControllerBase
{
    private readonly IRouteService _routeService;

    public RouteController(IRouteService routeService)
    {
        _routeService = routeService;
    }

    public async Task<ActionResult<DataAccess.Entities.Route>> Create()
    {
        return await _routeService.CrateAsync(new DataAccess.Entities.Route());
    }
    // public Route Create()
    // {
    //     return new Route();
    // }
    //
    // public Route Update()
    // {
    //     return new Route();
    // }
    //
    // public void Delete()
    // {
    //     
    // }
    //
    // public Route Get(long id)
    // {
    //     return new Route();
    // }
}