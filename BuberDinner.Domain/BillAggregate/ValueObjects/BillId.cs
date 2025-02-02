﻿using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.BillAggregate.ValueObjects
{
    public sealed class BillId : ValueObject
    {
        public Guid Value { get; }

        public BillId(Guid value)
        {
            Value = value;
        }
        public static BillId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityObjects()
        {
            yield return Value;
        }
    }
}
