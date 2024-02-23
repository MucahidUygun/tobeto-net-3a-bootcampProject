using AutoMapper;
using Business.Dtos.User.Response;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Users
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, GetAllUserResponse>().ReverseMap();
            CreateMap<User, GetByIdResponse>().ReverseMap();
        }
    }
}
