﻿using Microsoft.AspNetCore.Mvc;
using MyCity.Core.Models;
using MyCity.Core.Services;
using RouteEntity = MyCity.DataAccess.Entities.Route;

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

    [HttpGet]
    public async Task<IEnumerable<RouteEntity>> List()
    {
        return await _routeService.ListAsync();
    }

    [HttpPut, Route("CreateRoute")]
    public async Task<ActionResult<RouteEntity>> Create(RouteDto dto)
    {
        return await _routeService.CreateAsync(dto);
    }

    [HttpPut, Route("UpdateRoute")]
    public async Task<ActionResult<RouteEntity>> Update(RouteDto dto)
    {
        return await _routeService.UpdateAsync(dto);
    }

    [HttpDelete]
    public async Task Delete(long id)
    {
        await _routeService.DeleteAsync(id);
    }

    [HttpGet("Get")]
    public async Task<ActionResult<RouteEntity>> Get(long id)
    {
        return await _routeService.GetAsync(id);
    }

    #region Route and RoutePoints
    [HttpPut("CreateOrUpdateRoute")]
    public async Task<ActionResult> CreateOrUpdate(ClientRouteDto clientRouteDto)
    {
        try
        {
            await _routeService.CreateOrUpdateAsync(clientRouteDto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
    #endregion
}