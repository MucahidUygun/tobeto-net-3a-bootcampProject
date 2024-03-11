using Business.Dtos.ApplicantDtos.Request;
using Business.Dtos.ApplicantDtos.Response;
using Business.Dtos.EmployeeDto.Request;
using Business.Dtos.EmployeeDto.Response;
using Business.Dtos.InstructorDto.Request;
using Business.Dtos.InstructorDto.Response;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.JWT;
using DataAccess.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<AccessToken>> Login(UserForLoginDto userForLoginDto);
        Task<IDataResult<AccessToken>> CreateAccessToken(User user);
        Task<IDataResult<AccessToken>> RegisterApplicant(CreateApplicantRequest request);
        Task<IDataResult<AccessToken>> RegisterEmployee(CreateEmployeeRequest request);
        Task<IDataResult<AccessToken>> RegisterInstruntor(CreateInstructorRequest request);
    }
}
