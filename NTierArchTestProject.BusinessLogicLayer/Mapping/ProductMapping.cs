using AutoMapper;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.ProductCommands;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Results.ProductResults;
using NTierArchTestProject.NTierArchTestProject.CoreLayer.Entities;

namespace NTierArchTestProject.BusinessLogicLayer.Mapping
{
    internal sealed class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, GetAllProductQueryResult>().ReverseMap();
            CreateMap<Product, GetProductByIdQueryResult>().ReverseMap();
        }
    }
}
