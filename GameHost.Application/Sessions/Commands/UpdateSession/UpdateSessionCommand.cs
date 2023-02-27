using GameHost.Contracts.Sessions;
using GameHost.Domain.Common.ValueObjects;
using GameHost.Domain.Sessions;
using GameHost.Domain.Sessions.ValueObjects;
using GameHost.Domain.Users.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Sessions.Commands.UpdateSession
{
    public class UpdateSessionCommand : IRequest<SessionResponse>
    {
        public SessionId SessionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public DateTime Date { get; set; }
        public List<GameCommand> Games { get; set; }
    }

    public class GameCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string InfoURL { get; set; }
    }
    
    }

