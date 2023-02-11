using GameHost.Domain.Common.Models;
using GameHost.Domain.Common.ValueObjects;
using GameHost.Domain.Hosts;
using GameHost.Domain.Hosts.ValueObjects;
using GameHost.Domain.Sessions.Entities;
using GameHost.Domain.Sessions.ValueObjects;


namespace GameHost.Domain.Sessions
{
    public sealed class Session : AggregateRoot<SessionId>
    {
        
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Address Address { get; private set; }
        public Host Host { get; private set; }
        public DateTime Date { get; private set; }
        public bool AlreadyHappend { get; private set; }
        private readonly List<Game> _games = new ();
        public IReadOnlyList<Game> Games => _games;

        private Session(SessionId sessionId , Host host, string name, string description, Address address, DateTime date, List<Game> games) : base(sessionId)
        {
            Host = host;
            Name = name;
            Description = description;
            Address = address;
            Date = date;
            _games = games;

        }

        public static Session Create(Host host, string name, string description, Address address, DateTime date, List<Game> games)
        {
            return new(SessionId.CreateUnique(), host, name, description, address, date, games);
        }

        private Session()
        {

        }
    }
}
