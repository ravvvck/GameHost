using GameHost.Domain.Common.Models;
using GameHost.Domain.Common.ValueObjects;
using GameHost.Domain.Hosts.ValueObjects;
using GameHost.Domain.Sessions;
using GameHost.Domain.Sessions.Entities;
using GameHost.Domain.Sessions.ValueObjects;
using GameHost.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GameHost.Domain.Hosts
{
    public sealed class Host : AggregateRoot<HostId>
    {
        private readonly List<GameHost.Domain.Sessions.Session>? _sessions = new();
        public IReadOnlyList<GameHost.Domain.Sessions.Session>? Sessions => _sessions;
        public GameHost.Domain.Users.User User { get; private set; }
        private Host()
        {

        }

        private Host(HostId hostId, GameHost.Domain.Users.User user, List<GameHost.Domain.Sessions.Session> sessions)
        : base(hostId)
        {

            _sessions = sessions;
            User = user;
            
        }

        public static Host Create(GameHost.Domain.Users.User user)
        {
            return new(HostId.CreateUnique(), user, new List <GameHost.Domain.Sessions.Session>());
        }
    }
}
