using AutoMapper;
using BloggingApp.Domain.Entities;
using BloggingApp.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingApp.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostDTO>();
        }
    }
}
