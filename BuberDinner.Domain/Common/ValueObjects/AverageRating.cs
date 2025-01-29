using BuberDinner.Domain.Common.Entities;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public sealed class AverageRating : ValueObject
    {
        public double Value { get; private set; }
        public int NumRatings { get; private set; }

        public AverageRating(double value, int numRatinds)
        {
            Value = value;
            NumRatings = numRatinds;
        }
        public static AverageRating Create(double value, int numRatinds)
        {
            return new(value, numRatinds);
        }

        public void AddNewRating(Rating rating)
        {
            Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;
        }

        internal void RemoveRating(Rating rating)
        {
            Value = ((Value * NumRatings) - rating.Value) / --NumRatings;
        }

        public override IEnumerable<object> GetEqualityObjects()
        {
            yield return Value;
        }
        
    }
}
