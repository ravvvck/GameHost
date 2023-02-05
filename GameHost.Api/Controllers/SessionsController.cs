using AutoMapper;
using GameHost.Application.Sessions.Commands.CreateSession;
using GameHost.Contracts.Sessions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameHost.Api.Controllers
{
    [ApiController]
    [Route("sessions")]
    public class SessionController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public SessionController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }


        [HttpPost("host/{hostId}")]
        public async Task<IActionResult> CreateEvent( CreateSessionRequest request, string hostId)
        {

            var command = mapper.Map<CreateSessionCommand>((request, hostId));
            await mediator.Send(command);
            return Ok(command);
        }

        
    }
}
