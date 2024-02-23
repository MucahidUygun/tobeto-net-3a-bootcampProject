using AutoMapper;
using Business.Dtos.ApplicantDtos.Request;
using Business.Dtos.ApplicationDto.Request;
using Business.Dtos.ApplicationDto.Response;
using Entities.Concrete;

namespace Business.Profiles.Applications
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Application, CreateApplicationRequest>().ReverseMap();
            CreateMap<Application, DeleteApplicationRequest>().ReverseMap();
            CreateMap<Application, UpdateApplicationRequest>().ReverseMap();


            CreateMap<Application, GetAllApplicationResponse>().ReverseMap();
            CreateMap<Application, GetByIdApplicationResponse>().ReverseMap();
            CreateMap<Application, CreateApplicationResponse>().ReverseMap();
            CreateMap<Application, UpdateApplicationResponse>().ReverseMap();
            CreateMap<Application, DeleteApplicationResponse>().ReverseMap();

        }
    }
}
