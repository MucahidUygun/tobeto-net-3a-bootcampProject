using Business.Dtos.InstructorDto.Request;
using Business.Dtos.InstructorDto.Response;
using DataAccess.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IInstructorService
    {
        Task<IDataResult<List<GetAllInstructorResponse>>> GetAllAsync();
        Task<IDataResult<GetByIdInstructorResponse>> GetByIdAsync(int id);
        Task<IDataResult<CreateInstructorResponse>> AddAsync(Instructor request);
        Task<IResult> DeleteAsync(DeleteInstructorRequest request);
        Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request);

        Task CheckIdIsExists(int id);

        //List<GetAllInstructorResponse> GetAll();
        //GetByIdInstructorResponse GetById(int id);
        //CreateInstructorResponse Add(CreateInstructorRequest request);
        //DeleteInstructorResponse Delete(DeleteInstructorRequest request);
        //UpdateInstructorResponse Update(UpdateInstructorRequest request);
    }
}
