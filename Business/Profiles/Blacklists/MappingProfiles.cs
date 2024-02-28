using AutoMapper;
using Business.Dtos.ApplicantDtos.Request;
using Business.Dtos.ApplicantDtos.Response;
using Business.Dtos.ApplicationStateDto.Request;
using Business.Dtos.ApplicationStateDto.Response;
using Business.Dtos.Blacklists.Requests;
using Business.Dtos.Blacklists.Responses;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Blacklists
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Blacklist, CreateBlacklistRequest>().ReverseMap();
            CreateMap<Blacklist, DeleteBlacklistRequest>().ReverseMap();
            CreateMap<Blacklist, UpdateBlacklistRequest>().ReverseMap();

            CreateMap<Blacklist, CreatedBlacklistResponse>().ReverseMap();
            CreateMap<Blacklist, DeletedBlacklistResponse>().ReverseMap();
            CreateMap<Blacklist, UpdatedBlacklistResponse>().ReverseMap();
            CreateMap<Blacklist, GetAllBlacklistResponse>().ReverseMap();
            CreateMap<Blacklist, GetByIdBlacklistResponse>().ReverseMap();
            CreateMap<Blacklist, GetByApplicantIdResponse>().ReverseMap();
        }
    }
}
