﻿using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Domain.MenuAggregate;
using DuberDinner.Contracts.Menus;
using Mapster;

using MenuSection = BuberDinner.Domain.MenuAggregate.Entities.MenuSection;
using MenuItem = BuberDinner.Domain.MenuAggregate.Entities.MenuItem;

namespace BuberDinner.API.Mapping
{
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(
                    dest => dest.AverageRating,
                    src => src.AverageRating.NumRatings > 0 ? src.AverageRating.Value : 0)
                .Map(dest => dest.HostId, src => src.HostId.Value)
                .Map(dest => dest.DinnersIds, src => src.DinnerIds.Select(d => d.Value))
                .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(mr => mr.Value));
                

            config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<MenuItem, MenuItemResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

        }
    }
}
