using AutoMapper;
using PRN232.Lab1.CoffeeStore.Application.ViewModels.Menus;
using PRN232.Lab1.CoffeeStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Infrastructure.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Menu, MenuResponse>().ReverseMap();
            CreateMap<Menu, CreateMenuRequest>().ReverseMap();
            CreateMap<Menu, UpdateMenuRequest>().ReverseMap();

        }
    }
}
