using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name { get; }
        public string Description { get; }
        public IReadOnlyList<MenuItem> Items => _items.ToList();

        private MenuSection(
            MenuSectionId menuSectionId,
            string name,
            string description) : base(menuSectionId)
        {
            Name = name;
            Description = description;
        }

        public MenuSection Create(
            MenuSectionId menuSectionId,
            string name,
            string description)
        {
            return new(
                MenuSectionId.CreateUnique(),
                name,
                description);
        }
    }
}
