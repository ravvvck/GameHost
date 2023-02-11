﻿using GameHost.Domain.Common.Models;
using GameHost.Domain.Sessions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.Users.ValueObjects
{
    public sealed class UserId : ValueObject
    {
        public Guid Value { get; }

        private UserId(Guid value)
        {
            Value = value;
        }


        public static UserId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public static UserId Create(Guid value)
        {
            return new UserId(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public override string ToString() => Convert.ToString(Value);

    }

}
