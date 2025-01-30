using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.Common.Entities
{
    public class Rating : Entity<RatingId>
    {

        public HostId HostId { get; }
        public DinnerId DinnerId { get; }
        public int Value { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Rating(
            RatingId ratingId,
            HostId hostId,
            DinnerId dinnerId,
            int value,
            DateTime createdDateTime,
            DateTime updatedDateTime) 
            : base(ratingId)
        {
            HostId = hostId;
            DinnerId = dinnerId;
            Value = value;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Rating Create(
            HostId hostId,
            DinnerId dinnerId,
            int value)
        {
            return new(
                RatingId.CreateUnique(),
                hostId,
                dinnerId,
                value,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
