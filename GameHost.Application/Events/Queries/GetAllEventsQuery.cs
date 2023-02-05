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
    public class GetAllEventsQuery : IRequest<List<Event>>
    {
    }
}
