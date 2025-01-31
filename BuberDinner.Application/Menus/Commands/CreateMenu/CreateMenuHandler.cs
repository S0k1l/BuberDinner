using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuAggregate;
using ErrorOr;
using MediatR;
using BuberDinner.Application.Common.Interfaces.Persistence;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateMenuHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var menu = Menu.Create(
                hostId: HostId.Create(Guid.Parse(request.HostId)),
                name: request.Name,
                description: request.Description,
                sections: request.Sections.ConvertAll(
                    s => MenuSection.Create(
                        s.Name,
                        s.Description,
                        s.Items.ConvertAll(i => MenuItem.Create(
                            i.Name,
                            i.Description)))));

            _menuRepository.Add(menu);

            return menu;
        }
    }
}
