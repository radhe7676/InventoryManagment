namespace InventoryManagmentAPI.Application.Mappers
{
    using AutoMapper;
    using InventoryManagmentAPI.DataAccess.Models;
    using InventoryManagmentAPI.Infrastructure.Dtos;

    public class InventoryManagementMapperProfile : Profile
    {
        public InventoryManagementMapperProfile()
        {
            CreateMap<Product, ProductDto>()
            .ReverseMap();
        }
    }
}
