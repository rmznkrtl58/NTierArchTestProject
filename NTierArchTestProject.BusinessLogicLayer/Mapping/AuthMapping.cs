using AutoMapper;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Results.AuthResults;
using NTierArchTestProject.DataAccessLayer.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Mapping
{
    internal sealed class AuthMapping:Profile
    {
        public AuthMapping()
        {
            CreateMap<AppRole, GetAllRoleQueryResult>();
        }
    }
}
