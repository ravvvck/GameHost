using GameHost.Domain.Common.Models;
using GameHost.Domain.Common.ValueObjects;
using GameHost.Domain.Event.ValueObjects;
using GameHost.Domain.Session.Entities;
using GameHost.Domain.Session.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.Session
{
    public sealed class Session : AggregateRoot<SessionId>
    {
        
        public string Name { get; }
        public string Description { get; }
        public Address Address { get; }
        public DateTime Date { get; }
        public bool AlreadyHappend { get; }
        private readonly List<Game> _games = new ();
       

        private Session(SessionId sessionId , string name, string description, Address address, DateTime date) : base(sessionId)
        {
            Name = name;
            Description = description;
            Address = address;
            Date = date;

        }

        public static Session Create(string name, string description, Address address, DateTime date)
        {
            return new(SessionId.CreateUnique(), name, description, address, date);
        }
    }
}
