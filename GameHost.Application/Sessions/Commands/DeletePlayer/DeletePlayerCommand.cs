using GameHost.Domain.Sessions.ValueObjects;
using GameHost.Domain.Users.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Sessions.Commands.DeletePlayer
{
    public class DeletePlayerCommand : IRequest<Unit>
    {
        public SessionId SessionId { get; set; }
        public UserId UserId { get; set; }
    }
}
