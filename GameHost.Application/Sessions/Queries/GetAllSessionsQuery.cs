using GameHost.Domain.Sessions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Sessions.Queries
{
    public class GetAllSessionsQuery : IRequest<List<Session>>
    {
    }
}
