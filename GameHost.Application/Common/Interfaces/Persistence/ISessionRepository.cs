using GameHost.Domain.Session;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Common.Interfaces.Persistence
{
    public interface ISessionRepository
    {
        void Add(Session e);
    }
}
