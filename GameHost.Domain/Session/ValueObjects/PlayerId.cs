using GameHost.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.Session.ValueObjects
{
    public sealed class PlayerId : ValueObject
    {
        public Guid Value { get; set; }
        private PlayerId(Guid value)
        {
            Value = value;
        }

        public static PlayerId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
