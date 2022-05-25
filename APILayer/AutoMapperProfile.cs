using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILayer.Models;
using DataAccess.Entities;
namespace APILayer
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User_Account,User_AccountDTO>();

            CreateMap<Ingredients, IngredientsDTO>();
        }
    }
}
