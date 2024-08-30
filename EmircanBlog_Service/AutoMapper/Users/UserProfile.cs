using AutoMapper;
using EmircanBlog_Entity.Dtos;
using EmircanBlog_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Service.AutoMapper.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserProfileDto, BlogUser>().ReverseMap();
        }
    }
}
