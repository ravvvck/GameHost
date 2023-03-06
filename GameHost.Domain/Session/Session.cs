using GameHost.Domain.Common.Models;
using GameHost.Domain.Common.ValueObjects;
using GameHost.Domain.Exceptions;
using GameHost.Domain.Hosts;
using GameHost.Domain.Session.Entities;
using GameHost.Domain.Sessions.Entities;
using GameHost.Domain.Sessions.ValueObjects;
using GameHost.Domain.Users;

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
        private readonly List<Player> _players = new();
        public List<Player> Players => _players;

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

        public void AddPlayer(User user)
        {
            var alreadyExist = this.Players.Any(p => p.User == user);
            if (alreadyExist)
            {
                throw new UserIsAlreadyAttendingSessionException("User is already attending this session.");
            }
            var player = Player.Create(user, this);
            Players.Add(player);
        }
        public void DeletePlayer(User user)
        {
            var player = this.Players.FirstOrDefault(p => p.User == user);
            if (player == null)
            {
                throw new UserIsNotAttendingSessionException("User is not attending this session.");
            }
            Players.Remove(player);
        }


        private Session()
        {

        }
    }
}
