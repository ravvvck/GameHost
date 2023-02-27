using AutoMapper;
using GameHost.Application.Sessions.Commands.CreateSession;
using GameHost.Contracts.Sessions;
using GameHost.Domain.Sessions;
using Microsoft.Extensions.Logging;
using System;

namespace GameHost.Api.Mapping
{
    public class SessionMappingConfig : Profile
    {
        public SessionMappingConfig()
        {
            CreateMap<Session, SessionResponse>()
                .ForMember(dest => dest.HostId, s => s.MapFrom(src => src.Host.Id.Value))
                .ForMember(dest => dest.SessionId, s => s.MapFrom(src => src.Id));
            CreateMap<GameHost.Domain.Sessions.Entities.Game, GameResponse>()
                .ForMember(dest => dest.GameId, s => s.MapFrom(src => src.Id));
            CreateMap<Game, GameCommand>();
            CreateMap<(CreateSessionRequest request,Guid userId), CreateSessionCommand>()
            //.ForAllMembers(r => r.MapFrom(src => src.request)); 
            .ForMember(dest => dest.UserId, r => r.MapFrom(src => src.userId))
            .ForMember(dest => dest.Name, r => r.MapFrom(src => src.request.Name))
            .ForMember(dest => dest.Description, r => r.MapFrom(src => src.request.Description))
            .ForMember(dest => dest.Address, r => r.MapFrom(src => src.request.Address))
            .ForMember(dest => dest.Games, r => r.MapFrom(src => src.request.Games))
            .ForMember(dest => dest.Date, r => r.MapFrom(src => src.request.Date));


           

        }
    }
}
