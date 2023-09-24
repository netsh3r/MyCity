using Business.Model.Route;
using Business.Service.Route;
using Microsoft.AspNetCore.Mvc;

namespace My.City.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RouteController : ControllerBase
{
    private readonly IRouteService _routeService;

    public RouteController(IRouteService routeService)
    {
        _routeService = routeService;
    }

    
    [HttpGet, Route("List")]
    public async Task<IEnumerable<RouteListDto>> List()
    {
        return await _routeService.ListAsync();
    }

    [HttpPut, Route("CreateRoute")]
    public async Task<ActionResult<RouteDto>> Create(RouteDto dto)
    {
        return await _routeService.CreateOrUpdateAsync(dto);
    }

    [HttpPut, Route("UpdateRoute")]
    public async Task<ActionResult<RouteDto>> Update(RouteDto dto)
    {
        return await _routeService.CreateOrUpdateAsync(dto);
    }

    [HttpDelete]
    public void Delete(long id)
    {
        _routeService.Delete(id);
    }

    [HttpGet("Get")]
    public async Task<ActionResult<RouteDto>> Get(long id)
    {
        return await _routeService.GetAsync(id);
    }
}