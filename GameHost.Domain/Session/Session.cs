using GameHost.Domain.Common.Models;
using GameHost.Domain.Common.ValueObjects;
using GameHost.Domain.Session.Entities;
using GameHost.Domain.Session.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace GameHost.Domain.Session
{
    public sealed class Session : AggregateRoot<SessionId>
    {
        
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Address Address { get; private set; }
        public HostId HostId { get; private set; }
        public DateTime Date { get; private set; }
        public bool AlreadyHappend { get; private set; }
        private readonly List<Game> _games = new ();
        public IReadOnlyList<Game> Games => _games;

        private Session(SessionId sessionId , HostId hostId, string name, string description, Address address, DateTime date, List<Game> games) : base(sessionId)
        {
            HostId = hostId;
            Name = name;
            Description = description;
            Address = address;
            Date = date;
            _games = games;

        }

        public static Session Create(HostId hostId, string name, string description, Address address, DateTime date, List<Game> games)
        {
            return new(SessionId.CreateUnique(), hostId, name, description, address, date, games);
        }

        private Session()
        {

        }
    }
}
