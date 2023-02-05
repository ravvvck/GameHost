using GameHost.Contracts.Events;
using GameHost.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Common.Interfaces.Persistence
{
    public interface IEventRepository
    {
        List<Event> GetAllEvents();
        void Add(Event e);
    }
}
