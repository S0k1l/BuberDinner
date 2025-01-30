using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Entities;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;


namespace BuberDinner.Domain.GuestAggregate
{
    public sealed class Guest : AggregateRoot<GuestId>
    {
        private readonly List<DinnerId> _upcomingDinnerIds = new();
        private readonly List<DinnerId> _pastDinnerIds = new();
        private readonly List<DinnerId> _pendingDinnerIds = new();
        private readonly List<BillId> _billIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        private readonly List<Rating> _ratings = new();

        public string FirstName { get; }
        public string LastName { get; }
        public string ProfileImage { get; }
        public AverageRating AverageRating { get; private set; }
        public UserId UserId { get; }

        public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.ToList();
        public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.ToList();
        public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.ToList();
        public IReadOnlyList<BillId> BillIds => _billIds.ToList();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.ToList();
        public IReadOnlyList<Rating> Ratings => _ratings.ToList();

        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; private set; }

        private Guest(
            GuestId guestId,
            string firstName,
            string lastName,
            string profileImage,
            AverageRating averageRating,
            UserId userId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(guestId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Guest Create(
            string firstName,
            string lastName,
            string profileImage,
            UserId userId)
        {
            return new(
                GuestId.CreateUnique(),
                firstName,
                lastName,
                profileImage,
                AverageRating.Create(0, 0),
                userId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

        public void AddUpcomingDinner(DinnerId dinnerId)
        {
            _upcomingDinnerIds.Add(dinnerId);
            UpdatedDateTime = DateTime.UtcNow;
        }

        public void AddPastDinner(DinnerId dinnerId)
        {
            _upcomingDinnerIds.Add(dinnerId);
            UpdatedDateTime = DateTime.UtcNow;

        }

        public void AddPendingDinner(DinnerId dinnerId)
        {
            _upcomingDinnerIds.Add(dinnerId);
            UpdatedDateTime = DateTime.UtcNow;

        }

        public void AddBill(BillId billId)
        {
            _billIds.Add(billId);
            UpdatedDateTime = DateTime.UtcNow;
        }

        public void AddMenuReview(MenuReviewId menuReviewId)
        {
            _menuReviewIds.Add(menuReviewId);
            UpdatedDateTime = DateTime.UtcNow;
        }

        public void AddRating(Rating rating)
        {
            _ratings.Add(rating);
            AverageRating.AddNewRating(rating);
            UpdatedDateTime = DateTime.UtcNow;
        }

        public void RemoveRating(Rating rating)
        {
            _ratings.Remove(rating);
            AverageRating.RemoveRating(rating);
            UpdatedDateTime = DateTime.UtcNow;
        }
    }
}
