using AutoMapper;
using PRN232.Lab1.CoffeeStore.Application.ViewModels.Menus;
using PRN232.Lab1.CoffeeStore.Application.ViewModels.Products;
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
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>().ReverseMap();
            CreateMap<Product, CreateProductRequest>().ReverseMap();
            CreateMap<ProductInMenu, AddProductInMenuRequest>().ReverseMap();
            CreateMap<ProductInMenu, ProductInMenuResponse>()
               .ForMember(dest => dest.ProductName,
                          opt => opt.MapFrom(src => src.Product.ProductName))
               .ForMember(dest => dest.ProductDescription,
                          opt => opt.MapFrom(src => src.Product.ProductDescription));

        }
    }
}
