using BuberDinner.Domain.Dinner.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public sealed class RatingId
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
