using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();

        public string Name { get; private set; }
        public string Description { get; private set; }
        public AverageRating AverageRating { get; private set; }
        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

        public HostId HostId { get; private set; }
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Menu(
            MenuId menuId,
            string name,
            string description,
            HostId hostId,
            AverageRating averageRating,
            List<MenuSection> sections,
            DateTime createdDateTime,
            DateTime updatedDateTime) 
            : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            AverageRating = averageRating;
            _sections = sections;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Menu Create(
            HostId hostId,
            string name,
            string description,
            List<MenuSection>? sections)
        {
            return new(
                MenuId.CreateUnique(),
                name,
                description,
                hostId,
                AverageRating.Create(0,0),
                sections ?? new(),
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

        private Menu()
        {          
        }

    }
}
