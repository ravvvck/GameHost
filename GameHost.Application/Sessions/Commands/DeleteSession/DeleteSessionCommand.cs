using GameHost.Domain.Sessions.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Sessions.Commands.DeleteSession
{
    public class DeleteSessionCommand : IRequest<Unit>
    {
        public SessionId SessionId { get; set; }
    }
}
