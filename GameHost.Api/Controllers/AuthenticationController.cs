using AutoMapper;
using GameHost.Application.Authentication.Commands.Register;
using GameHost.Application.Authentication.Queries;
using GameHost.Contracts.Authentication;
using GameHost.Domain.Users.ValueObjects;
using GameHost.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using GameHost.Application.Exceptions;
using GameHost.Application.Authentication.Commands.RefreshToken;

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
        private void SetRefreshTokenInCookie(RefreshToken refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.Expires,
                SameSite = SameSiteMode.None,
                Secure = true
            };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

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
            SetRefreshTokenInCookie(authResult.RefreshToken);
            return Ok(response);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (refreshToken == null)
            {
                throw new BadRequestException("Refresh token is required.");
            }
            var command = _mapper.Map<RefreshTokenCommand>((refreshTokenRequest, refreshToken));
            var authResult = await _mediator.Send(command);
            var response = _mapper.Map<AuthenticationResponse>(authResult);
            return Ok(response);
        }

    }
}
