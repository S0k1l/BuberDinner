﻿using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public sealed class RatingId : ValueObject
    {
        public Guid Value { get; }

        public RatingId(Guid value)
        {
            Value = value;
        }
        public static RatingId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityObjects()
        {
            yield return Value;
        }
    }
}
