using AutoMapper;
using GameHost.Application.Sessions.Commands.CreateSession;
using GameHost.Contracts.Sessions;
using GameHost.Domain.Session;
using Microsoft.Extensions.Logging;
using System;

namespace GameHost.Api.Mapping
{
    public class SessionMappingConfig : Profile
    {
        public SessionMappingConfig()
        {
            CreateMap<Session, SessionResponse>();
            CreateMap<Game, GameCommand>();
            CreateMap<(CreateSessionRequest request, string HostId), CreateSessionCommand>()
                .ForMember(dest => dest.HostId, r => r.MapFrom(src => src.HostId))
            //.ForAllMembers(r => r.MapFrom(src => src.request)); 
            .ForMember(dest => dest.Name, r => r.MapFrom(src => src.request.Name))
            .ForMember(dest => dest.Description, r => r.MapFrom(src => src.request.Description))
            .ForMember(dest => dest.Address, r => r.MapFrom(src => src.request.Address))
            .ForMember(dest => dest.Games, r => r.MapFrom(src => src.request.Games))
            .ForMember(dest => dest.Date, r => r.MapFrom(src => src.request.Date));


            CreateMap<Session, SessionResponse>();
           

        }
    }
}
