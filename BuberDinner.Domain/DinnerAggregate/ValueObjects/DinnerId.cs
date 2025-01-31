using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects
{
    public sealed class DinnerId : ValueObject
    {
        public Guid Value { get; }

        public DinnerId(Guid value)
        {
            Value = value;
        }
        public static DinnerId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static DinnerId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityObjects()
        {
            yield return Value;
        }
    }
}
