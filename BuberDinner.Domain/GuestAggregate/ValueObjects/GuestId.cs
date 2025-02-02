﻿using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects
{
    public sealed class GuestId : ValueObject
    {
        public Guid Value { get; }

        public GuestId(Guid value)
        {
            Value = value;
        }
        public static GuestId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityObjects()
        {
            yield return Value;
        }
    }
}
