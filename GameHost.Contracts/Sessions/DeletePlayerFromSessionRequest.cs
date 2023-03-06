using GameHost.Domain.Sessions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Contracts.Sessions
{
    public class DeletePlayerFromSessionRequest
    {
        public SessionId SessionId { get; set; }
    }
}
