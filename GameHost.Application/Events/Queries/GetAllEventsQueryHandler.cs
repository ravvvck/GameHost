using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Contracts.Events;
using GameHost.Domain.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Events.Queries
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, List<Event>>
    {
        private readonly IEventRepository _eventRepository;

        public GetAllEventsQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<Event>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var eventsList = _eventRepository.GetAllEvents();
            return eventsList;
        }
    }
}
