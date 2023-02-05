using AutoMapper;
using GameHost.Application.Events.Commands.CreateEvent;
using GameHost.Application.Events.Queries;
using GameHost.Contracts.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameHost.Api.Controllers
{
    [Route("events")]
    public class EventsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public EventsController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody]CreateEventRequest request)
        {
            var command = mapper.Map<CreateEventCommand>(request);
            await mediator.Send(command);
            return Ok(request);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents(GetAllEventsQuery request)
        {
            var eventsList = await mediator.Send(request);
            var eventsResult = mapper.Map<List<EventResponse>>(eventsList);
            return Ok(eventsResult);
        }
    }
}
