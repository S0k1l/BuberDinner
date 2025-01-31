﻿using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects
{
    public sealed class MenuItemId : ValueObject
    {
        public Guid Value { get; }

        public MenuItemId(Guid value)
        {
            Value = value;
        }
        public static MenuItemId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static MenuItemId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityObjects()
        {
            yield return Value;
        }
    }
}
