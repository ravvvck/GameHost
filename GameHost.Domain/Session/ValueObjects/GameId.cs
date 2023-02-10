using GameHost.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.Session.ValueObjects
{
    public sealed class GameId : ValueObject
    {
        public Guid Value { get; set; }
        private GameId(Guid value)
        {
            Value = value;
        }

        public static GameId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public static GameId Create(Guid value)
        {
            return new GameId(value);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
