using GameHost.Domain.Common.Models;
using GameHost.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.Hosts.ValueObjects
{
    public sealed class HostId : ValueObject
    {
        public Guid Value { get; set; }
        private HostId(Guid value)
        {
            Value = value;
        }

        public static HostId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public static HostId Create(Guid value)
        {
            return new HostId(value);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
