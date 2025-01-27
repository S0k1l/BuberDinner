namespace BuberDinner.Domain.Common.Models
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetEqualityObjects();

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            var valueObject = (ValueObject)obj;

            return GetEqualityObjects().SequenceEqual(valueObject.GetEqualityObjects());
        }

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode() 
        {
            return GetEqualityObjects()
                .Select(x => x?.GetHashCode() ?? 0)
                .Aggregate((x,y) => x ^ y);
        }

        public bool Equals(ValueObject? other)
        {
            return Equals((object?)other);
        }
    }
}
