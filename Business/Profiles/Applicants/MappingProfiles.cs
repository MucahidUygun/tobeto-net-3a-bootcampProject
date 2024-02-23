using AutoMapper;
using Business.Dtos.ApplicantDtos.Request;
using Business.Dtos.ApplicantDtos.Response;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Applicants
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Applicant, CreateApplicantRequest>().ReverseMap();
            CreateMap<Applicant, UpdateApplicantRequest>().ReverseMap();
            CreateMap<Applicant, DeleteApplicantRequest>().ReverseMap();

            CreateMap<Applicant, GetAllApplicantResponse>().ReverseMap();
            CreateMap<Applicant, GetByIdApplicantResponse>().ReverseMap();
            CreateMap<Applicant, CreateApplicantResponse>().ReverseMap();
            CreateMap<Applicant, UpdateApplicantResponse>().ReverseMap();
            CreateMap<Applicant, DeleteApplicantResponse>().ReverseMap();
        }
    }
}
