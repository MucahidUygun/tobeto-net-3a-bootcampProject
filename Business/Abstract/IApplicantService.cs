using Business.Dtos.ApplicantDtos.Request;
using Business.Dtos.ApplicantDtos.Response;
using DataAccess.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApplicantService
    {
        Task<IDataResult<List<GetAllApplicantResponse>>> GetAll();
        Task<IDataResult<GetByIdApplicantResponse>> GetById(int id);
        Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request);
        Task<IDataResult<DeleteApplicantResponse>> DeleteAsync(DeleteApplicantRequest request);
        Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request);

        //List<GetAllApplicantResponse> GetAll();
        //GetByIdApplicantResponse GetById(int id);
        //CreateApplicantResponse Add(CreateApplicantRequest request);
        //DeleteApplicantResponse Delete(DeleteApplicantRequest request);
        //UpdateApplicantResponse Update(UpdateApplicantRequest request);
    }
}
