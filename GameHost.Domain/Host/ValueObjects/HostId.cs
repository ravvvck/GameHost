using GameHost.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.Session.ValueObjects
{
    public sealed class HostId : ValueObject
    {
        public string Value { get; set; }
        private HostId(string value)
        {
            Value = value;
        }

        public static HostId Create(string id)
        {
            return new(id);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
