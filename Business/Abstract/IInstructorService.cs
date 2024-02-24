using Business.Dtos.InstructorDto.Request;
using Business.Dtos.InstructorDto.Response;
using DataAccess.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IInstructorService
    {
        Task<IDataResult<List<GetAllInstructorResponse>>> GetAll();
        Task<IDataResult<GetByIdInstructorResponse>> GetById(int id);
        Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request);
        Task<IDataResult<DeleteInstructorResponse>> DeleteAsync(DeleteInstructorRequest request);
        Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request);

        //List<GetAllInstructorResponse> GetAll();
        //GetByIdInstructorResponse GetById(int id);
        //CreateInstructorResponse Add(CreateInstructorRequest request);
        //DeleteInstructorResponse Delete(DeleteInstructorRequest request);
        //UpdateInstructorResponse Update(UpdateInstructorRequest request);
    }
}
