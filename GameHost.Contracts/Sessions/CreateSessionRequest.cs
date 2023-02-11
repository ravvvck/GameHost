using GameHost.Domain.Common.ValueObjects;
using GameHost.Domain.Sessions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Contracts.Sessions
{
    public record CreateSessionRequest(
    string Name,
    string Description,
    Address Address,
    DateTime Date,
    List<Game> Games){};

    public record Game(
        string Name,
        string Description,
        string InfoURL
       );
   
}
