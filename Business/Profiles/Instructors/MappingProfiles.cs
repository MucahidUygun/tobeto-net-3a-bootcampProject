using AutoMapper;
using Business.Dtos.InstructorDto.Request;
using Business.Dtos.InstructorDto.Response;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Instructors
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();
            CreateMap<Instructor, DeleteInstructorRequest>().ReverseMap();
            CreateMap<Instructor, UpdateInstructorRequest>().ReverseMap();

            CreateMap<Instructor, CreateInstructorResponse>().ReverseMap();
            CreateMap<Instructor, DeleteInstructorResponse>().ReverseMap();
            CreateMap<Instructor, UpdateInstructorResponse>().ReverseMap();
            CreateMap<Instructor, GetAllInstructorResponse>().ReverseMap();
            CreateMap<Instructor, GetByIdInstructorResponse>().ReverseMap();
        }
    }
}
