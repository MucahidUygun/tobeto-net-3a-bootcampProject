using AutoMapper;
using Business.Dtos.BootcampStateDto.Request;
using Business.Dtos.BootcampStateDto.Response;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.BootcampStates
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BootcampState, CreateBootcampStateRequest>().ReverseMap();
            CreateMap<BootcampState, DeleteBootcampStateRequest>().ReverseMap();
            CreateMap<BootcampState, UpdateBootcampStateRequest>().ReverseMap();

            CreateMap<BootcampState, CreateBootcampStateResponse>().ReverseMap();
            CreateMap<BootcampState, DeleteBootcampStateResponse>().ReverseMap();
            CreateMap<BootcampState, UpdateBootcampStateResponse>().ReverseMap();
            CreateMap<BootcampState, GetAllBootcampStateResponse>().ReverseMap();
            CreateMap<BootcampState, GetByIdBootcampStateResponse>().ReverseMap();
        }
    }
}
