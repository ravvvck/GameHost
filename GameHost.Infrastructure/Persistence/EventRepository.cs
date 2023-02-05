using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Contracts.Events;
using GameHost.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Infrastructure.Persistence
{
    public class EventRepository : IEventRepository
    {
        
        private readonly List<Event> _events = new();
        public void Add(Event e)
        {
            _events.Add(e);
        }

        public List<Event> GetAllEvents()
        {
            return _events;
        }
    }
}
