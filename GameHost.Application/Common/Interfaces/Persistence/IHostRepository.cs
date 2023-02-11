using GameHost.Domain.Hosts;
using GameHost.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Common.Interfaces.Persistence
{
    public interface IHostRepository
    {
        Host Add(Host host);
        Host FindByUserId(UserId userId);
        Host FindByUserIdOrCreate(UserId userId);
    }
}
