using AutoMapper;
using GameHost.Application.Authentication.Commands.Register;
using GameHost.Application.Authentication.Queries;
using GameHost.Application.Common.Interfaces.Services;
using GameHost.Application.Events.Commands.CreateEvent;
using GameHost.Contracts.Authentication;
using GameHost.Contracts.Events;
using GameHost.Domain.Event;

namespace GameHost.Api.Mapping
{
    public class EventMappingConfig : Profile
    {
        public EventMappingConfig()
        {
            CreateMap<CreateEventRequest, CreateEventCommand>();
            CreateMap<Event, EventResponse>();

        }
    }
}
