using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using GraphQLEntityFramework.Data.Entities;

namespace GraphQLEntityFramework.Data.AutoMapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
             CreateMap<Blog , BlogModel>();
             CreateMap<Review , ReviewModel>();
        }
    }
}
