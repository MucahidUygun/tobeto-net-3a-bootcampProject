using Business.Dtos.ApplicantDtos.Request;
using Business.Dtos.ApplicantDtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApplicantService
    {
        Task<List<GetAllApplicantResponse>> GetAll();
        Task<GetByIdApplicantResponse> GetById(int id);
        Task<CreateApplicantResponse> AddAsync(CreateApplicantRequest request);
        Task<DeleteApplicantResponse> DeleteAsync(DeleteApplicantRequest request);
        Task<UpdateApplicantResponse> UpdateAsync(UpdateApplicantRequest request);

        //List<GetAllApplicantResponse> GetAll();
        //GetByIdApplicantResponse GetById(int id);
        //CreateApplicantResponse Add(CreateApplicantRequest request);
        //DeleteApplicantResponse Delete(DeleteApplicantRequest request);
        //UpdateApplicantResponse Update(UpdateApplicantRequest request);
    }
}
