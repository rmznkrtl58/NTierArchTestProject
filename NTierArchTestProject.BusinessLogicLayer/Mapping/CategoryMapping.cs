using AutoMapper;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.CategoryCommands;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Results.CategoryResults;
using NTierArchTestProject.NTierArchTestProject.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Mapping
{
    internal sealed class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, GetAllCategoryQueryResult>().ReverseMap();
            CreateMap<Category, GetCategoryByIdQueryResult>().ReverseMap();
        }
    }
}
