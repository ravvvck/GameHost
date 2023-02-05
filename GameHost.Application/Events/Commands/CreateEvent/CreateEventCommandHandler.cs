using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Contracts.Events;
using GameHost.Domain.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Event>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<Event> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = Event.Create(request.Name,
                request.Description,
                request.Address,
                request.Date);

            _eventRepository.Add(newEvent);

            return newEvent;
        }


    }
}
