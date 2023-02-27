using AutoMapper;
using GameHost.Application.Sessions.Commands.CreateSession;
using GameHost.Application.Sessions.Commands.DeleteSession;
using GameHost.Application.Sessions.Queries;
using GameHost.Contracts.Sessions;
using GameHost.Domain.Users.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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
        public async Task<IActionResult> Create(CreateSessionRequest request)
        {

            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var command = mapper.Map<CreateSessionCommand>((request, userId));

            await mediator.Send(command);
            return Ok(command);
        }
        [HttpGet()]
        public async Task<IActionResult> GetAll(GetAllSessionsQuery getAllSessionsQuery)
        {
            var sessions = await mediator.Send(getAllSessionsQuery);
            var sessionsResponse = mapper.Map<List<SessionResponse>>(sessions);
            return Ok(sessionsResponse);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteSessionCommand deleteSessionCommand)
        {
            await mediator.Send(deleteSessionCommand);
            return NoContent();
        }

        
    }
}
