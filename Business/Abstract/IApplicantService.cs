using Business.Dtos.ApplicantDtos.Request;
using Business.Dtos.ApplicantDtos.Response;
using DataAccess.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApplicantService
    {
        Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync();
        Task<IDataResult<GetByIdApplicantResponse>> GetByIdAsync(int id);
        Task<IDataResult<CreateApplicantResponse>> AddAsync(Applicant request);
        Task<IResult> DeleteAsync(DeleteApplicantRequest request);
        Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request);

        Task CheckIdIsExists(int id);

        //List<GetAllApplicantResponse> GetAll();
        //GetByIdApplicantResponse GetById(int id);
        //CreateApplicantResponse Add(CreateApplicantRequest request);
        //DeleteApplicantResponse Delete(DeleteApplicantRequest request);
        //UpdateApplicantResponse Update(UpdateApplicantRequest request);
    }
}
