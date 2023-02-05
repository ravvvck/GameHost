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
        
        public string Name { get; }
        public string Description { get; }
        public Address Address { get; }
        public HostId HostId { get; }
        public DateTime Date { get; }
        public bool AlreadyHappend { get; }
        private readonly List<Game> _games = new ();
        public IReadOnlyList<Game> Sections => _games;

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
    }
}
