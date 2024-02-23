using AutoMapper;
using Business.Dtos.ApplicantDtos.Request;
using Business.Dtos.ApplicantDtos.Response;
using Business.Dtos.ApplicationStateDto.Request;
using Business.Dtos.ApplicationStateDto.Response;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.ApplicationStates
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApplicationState, CreateApplicationStateRequest>().ReverseMap();
            CreateMap<ApplicationState, DeleteApplicationStateRequest>().ReverseMap();
            CreateMap<ApplicationState, UpdateApplicationStateRequest>().ReverseMap();

            CreateMap<ApplicationState, CreateApplicationStateResponse>().ReverseMap();
            CreateMap<ApplicationState, DeleteApplicationStateResponse>().ReverseMap();
            CreateMap<ApplicationState, UpdateApplicationStateResponse>().ReverseMap();
            CreateMap<ApplicationState, GetAllApplicationStateResponse>().ReverseMap();
            CreateMap<ApplicationState, GetByIdApplicationStateResponse>().ReverseMap();
        }
    }
}
