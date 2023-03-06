using AutoMapper;
using GameHost.Application.Authentication.Commands.RefreshToken;
using GameHost.Application.Authentication.Commands.Register;
using GameHost.Application.Authentication.Queries;
using GameHost.Application.Common.Interfaces.Services;
using GameHost.Contracts.Authentication;
using GameHost.Domain.Common.Models;
using Microsoft.Extensions.Logging;

namespace GameHost.Api.Mapping
{
    public class AuthenticationMappingConfig : Profile
    { 
        public AuthenticationMappingConfig() 
        {
            CreateMap<AuthenticationResult, AuthenticationResponse>()
                .ForMember(result => result.Id, r => r.MapFrom(response => response.User.Id.Value))
                .ForMember(result => result.FirstName, r => r.MapFrom(response => response.User.FirstName))
                .ForMember(result => result.LastName, r => r.MapFrom(response => response.User.LastName))
                .ForMember(result => result.Email, r => r.MapFrom(response => response.User.Email))
                .ForMember(result => result.Token, r => r.MapFrom(response => response.Token));

            CreateMap<RegisterRequest, RegisterCommand>();
            CreateMap<LoginRequest, LoginQuery>();
            CreateMap<(RefreshTokenRequest request, string token), RefreshTokenCommand>()
                .ForMember(dst => dst.RefreshToken, r => r.MapFrom(src => src.token));


        }
    }
}
