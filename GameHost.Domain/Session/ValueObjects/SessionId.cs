using GameHost.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.Session.ValueObjects
{
    public sealed class SessionId : ValueObject
    {
        public Guid Value { get; set; }
        private SessionId(Guid value)
        {
            Value = value;
        }

        public static SessionId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static SessionId Create(Guid value)
        {
            return new SessionId(value);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
