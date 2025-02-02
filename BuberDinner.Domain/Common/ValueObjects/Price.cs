﻿using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public sealed class Price : ValueObject
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
        public static Price Create(decimal amount, string currency)
        {
            return new(amount, currency);
        }

        public override IEnumerable<object> GetEqualityObjects()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
