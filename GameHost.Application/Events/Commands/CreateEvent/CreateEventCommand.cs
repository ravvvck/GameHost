using GameHost.Contracts.Events;
using GameHost.Domain.Common.ValueObjects;
using GameHost.Domain.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Events.Commands.CreateEvent
{
    public record CreateEventCommand(
       string Name,
       string Description,
       Address Address,
       DateTime Date

       ) : IRequest<Event>;
    
}
