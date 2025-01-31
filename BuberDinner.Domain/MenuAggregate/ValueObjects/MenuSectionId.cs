﻿using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects
{
    public sealed class MenuSectionId : ValueObject
    {
        public Guid Value { get; }

        public MenuSectionId(Guid value)
        {
            Value = value;
        }
        public static MenuSectionId CreateUnique()
        {
            return new(Guid.NewGuid());
        }        
        public static MenuSectionId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityObjects()
        {
            yield return Value;
        }
    }
}
