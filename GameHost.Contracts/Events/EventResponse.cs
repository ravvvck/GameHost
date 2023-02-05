using GameHost.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Contracts.Events
{
    public record EventResponse(
        Guid Id,
        string Name,
        string Description,
        Address Address,
        DateTime Date);
    
    
}
