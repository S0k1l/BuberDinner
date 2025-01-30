using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;
using System.Text.Json;

namespace DuberDinner.Infrastructure.Persistence
{
    public class MenuRepository : IMenuRepository
    {
        private static readonly List<Menu> _menus = new();
        public void Add(Menu menu)
        {
            _menus.Add(menu);
        }
    }
}
