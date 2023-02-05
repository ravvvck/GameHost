using AutoMapper;
using GameHost.Application.Authentication.Commands.Register;
using GameHost.Application.Authentication.Queries;
using GameHost.Application.Common.Interfaces.Services;
using GameHost.Contracts.Authentication;
using Microsoft.Extensions.Logging;

namespace GameHost.Api.Mapping
{
    public class AuthenticationMappingConfig : Profile
    {
        public AuthenticationMappingConfig() 
        {
            CreateMap<AuthenticationResult, AuthenticationResponse>()
                .ForMember(result => result.FirstName, r => r.MapFrom(response => response.user.FirstName))
                .ForMember(result => result.LastName, r => r.MapFrom(response => response.user.LastName))
                .ForMember(result => result.Email, r => r.MapFrom(response => response.user.Email));
            CreateMap<RegisterRequest, RegisterCommand>();
            CreateMap<LoginRequest, LoginQuery>();
        }
    }
}
