using AutoMapper;
using GameHost.Application.Sessions.Commands.CreateSession;
using GameHost.Contracts.Sessions;
using GameHost.Domain.Users.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [Authorize]
        [HttpPost()]
        public async Task<IActionResult> CreateEvent(CreateSessionRequest request)
        {

            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var command = mapper.Map<CreateSessionCommand>((request, userId));
            
            await mediator.Send(command);
            return Ok(command);
        }

        
    }
}
