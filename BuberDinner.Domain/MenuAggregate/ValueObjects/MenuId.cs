﻿using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects
{
    public sealed class MenuId : ValueObject
    {
        public Guid Value { get; }

        public MenuId(Guid value)
        {
            Value = value;
        }
        public static MenuId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public static MenuId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityObjects()
        {
            yield return Value;
        }
    }
}
