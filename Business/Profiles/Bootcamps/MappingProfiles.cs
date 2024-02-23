using AutoMapper;
using Business.Dtos.BootcampDto.Request;
using Business.Dtos.BootcampDto.Response;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Bootcamps
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Bootcamp, CreateBootcampRequest>().ReverseMap();
            CreateMap<Bootcamp, DeleteBootcampRequest>().ReverseMap();
            CreateMap<Bootcamp, UpdateBootcampRequest>().ReverseMap();

            CreateMap<Bootcamp, CreateBootcampResponse>().ReverseMap();
            CreateMap<Bootcamp, DeleteBootcampResponse>().ReverseMap();
            CreateMap<Bootcamp, UpdateBootcampResponse>().ReverseMap();
            CreateMap<Bootcamp, GetAllBootcampResponse>().ReverseMap();
            CreateMap<Bootcamp, GetByIdBootcampResponse>().ReverseMap();
        }
    }
}
