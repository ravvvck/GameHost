using GameHost.Domain.Comments;
using GameHost.Domain.Common.Models;

using GameHost.Domain.Common.ValueObjects;
using GameHost.Domain.Event.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameHost.Domain.Event
{
    public  class Event : AggregateRoot<EventId>
    {
        public EventId EventId { get; set; }
        public string Name { get;  }
        public string Description { get; }
        public Address Address { get;  }
        public DateTime Date { get; }
        public bool AlreadyHappend { get;  }
        public ICollection<Comment> Comments { get; set; }

        private Event(EventId eventId, string name, string description, Address address, DateTime date) : base(eventId) {
            Name = name;
            Description = description;
            Address = address;
            Date = date;

        }

        public static Event Create(string name, string description, Address address, DateTime date)
        {
            return new(EventId.CreateUnique(), name, description, address, date);
        }



    }
}
