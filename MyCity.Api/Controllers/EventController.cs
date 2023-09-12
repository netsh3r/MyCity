using Microsoft.AspNetCore.Mvc;
using MyCity.Core.Models;

namespace MyCity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EventDto>))]
        public Task<ActionResult<IEnumerable<EventDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EventDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Exception))]
        public Task<ActionResult<EventDto>> GetById()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EventDto))]
        public Task<ActionResult<EventDto>> CreateEvent([FromBody] EventDto eventDto)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EventDto))]
        public Task<ActionResult<EventDto>> UpdateEvent([FromBody] EventDto eventDto)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EventDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Exception))]
        public Task<ActionResult<EventDto>> DeleteEvent([FromBody] long eventId)
        {
            throw new NotImplementedException();
        }
    }
}
