using Microsoft.AspNetCore.Mvc;
using MyCity.Core.Models;
using MyCity.Route.Services;

namespace MyCity.Controllers;

[ApiController]
[Route("[controller]")]
public class RoutePointsController : ControllerBase
{
    private readonly RoutePointService _routePointService;

    public RoutePointsController(RoutePointService routePointService)
    {
        _routePointService = routePointService;
    }

    [ProducesResponseType(200,Type = typeof(ClientRouteDto))]
    [HttpGet]
    public async Task<ActionResult<ClientRouteDto>> Get([FromBody] long routeId)
    {
        return Ok(await _routePointService.GetAsync(routeId));
    }
}