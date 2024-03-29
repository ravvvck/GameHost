﻿using GameHost.Domain.Common.Models;
using GameHost.Domain.Sessions.ValueObjects;
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
        public static PlayerId Create(Guid value)
        {
            return new PlayerId(value);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
