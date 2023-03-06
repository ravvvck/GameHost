﻿using AutoMapper;
using GameHost.Application.Authentication.Commands.Register;
using GameHost.Application.Authentication.Queries;
using GameHost.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameHost.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("register")]
        
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var command = _mapper.Map<RegisterCommand>(registerRequest);
            
            var authResult = await _mediator.Send(command);
            var response = _mapper.Map<AuthenticationResponse>(authResult);
            
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest )
        {
            var query = _mapper.Map<LoginQuery>(loginRequest);
            var authResult = await _mediator.Send(query); 
            var response = _mapper.Map<AuthenticationResponse>(authResult);
            return Ok(response);
        }
    
}
}
