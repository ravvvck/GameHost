using GameHost.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.Event.ValueObjects
{
    public sealed class EventId : ValueObject
    {
        public Guid Value { get; set; }
        private EventId(Guid value)
        {
            Value= value;
        }

        public static EventId CreateUnique()
        {
            return new (Guid.NewGuid());
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
