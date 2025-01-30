using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.Entities;
using BuberDinner.Domain.DinnerAggregate.Enums;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;


namespace BuberDinner.Domain.DinnerAggregate
{
    public sealed class Dinner : AggregateRoot<DinnerId>
    {
        private readonly List<Reservation> _reservations = new();

        public string Name { get; }
        public string Description { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public DateTime? StartedDateTime { get; private set; }
        public DateTime? EndedDateTime { get; private set; }
        public DinnerStatus Status { get; private set; }
        public bool IsPublic { get; }
        public int MaxGuests { get; }
        public Price Price { get; }
        public HostId HostId { get; }
        public MenuId MenuId { get; }
        public string ImageUrl { get; }
        public Location Location { get; }
        public IReadOnlyList<Reservation> Reservations => _reservations.ToList();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; private set; }

        private Dinner(
            DinnerId dinnerId,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DinnerStatus status,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(dinnerId)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Status = status;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            Price = price;
            HostId = hostId;
            MenuId = menuId;
            ImageUrl = imageUrl;
            Location = location;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Dinner Create(
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location)
        {
            return new(
                DinnerId.CreateUnique(),
                name,
                description,
                startDateTime,
                endDateTime,
                DinnerStatus.Upcoming,
                isPublic,
                maxGuests,
                price,
                hostId,
                menuId,
                imageUrl,
                location,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

        public void Start()
        {
            if(Status is not DinnerStatus.Upcoming)
            {
                throw new Exception("Dinner must be in Upcoming state to start.");
            }

            StartedDateTime = DateTime.UtcNow;
            Status = DinnerStatus.InProgress;
            UpdatedDateTime = DateTime.UtcNow;
        }

        public void End()
        {
            if (Status is not DinnerStatus.InProgress)
            {
                throw new Exception("Dinner must be in Progress state to end.");
            }

            EndedDateTime = DateTime.UtcNow;
            Status = DinnerStatus.Ended;
            UpdatedDateTime = DateTime.UtcNow;
        }

        public void Cancel()
        {
            if (Status is not DinnerStatus.Ended)
            {
                throw new Exception("Cannot cancel a dinner that has ended.");
            }

            Status = DinnerStatus.Cancelled;
            UpdatedDateTime = DateTime.UtcNow;
        }

        public void AddReservation(Reservation reservation)
        {
            if (_reservations.Count() >= MaxGuests)
            {
                throw new Exception("Dinner is fully booked.");
            }

            _reservations.Add(reservation);
            UpdatedDateTime = DateTime.UtcNow;
        }

    }
}
