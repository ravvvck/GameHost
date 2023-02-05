using GameHost.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.SessionReview.ValueObjects
{
    public sealed class SessionReviewId : ValueObject
    {
        public Guid Value { get; set; }
        private SessionReviewId(Guid value)
        {
            Value = value;
        }

        public static SessionReviewId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
