using My.City.Abstraction.Dal.Repository;
using Microsoft.AspNetCore.Mvc;
using My.City.Core.Models;

namespace My.City.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly IReadRepository<RoutePoints> _readRepository;

    public HomeController(IReadRepository<RoutePoints> readRepository)
    {
        _readRepository = readRepository;
    }

    [HttpGet]
    public async Task<IReadOnlyCollection<RoutePoints>> Test()
    {
        return await _readRepository.GetAllAsync();
    }
}