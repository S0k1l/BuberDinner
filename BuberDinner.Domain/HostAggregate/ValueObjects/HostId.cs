using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.HostAggregate.ValueObjects
{
    public sealed class HostId : ValueObject
    {
        public Guid Value { get; }

        public HostId(Guid value)
        {
            Value = value;
        }
        public static HostId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static HostId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityObjects()
        {
            yield return Value;
        }
    }
}
