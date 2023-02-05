using GameHost.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.User.ValueObjects
{
    public sealed class UserRatingId : ValueObject
    {
        public Guid Value { get; }

        private UserRatingId(Guid value)
        {
            Value = value;
        }

        public static UserRatingId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
