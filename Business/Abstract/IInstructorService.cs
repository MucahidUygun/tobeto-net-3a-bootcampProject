using Business.Dtos.InstructorDto.Request;
using Business.Dtos.InstructorDto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IInstructorService
    {
        Task<List<GetAllInstructorResponse>> GetAll();
        Task<GetByIdInstructorResponse> GetById(int id);
        Task<CreateInstructorResponse> AddAsync(CreateInstructorRequest request);
        Task<DeleteInstructorResponse> DeleteAsync(DeleteInstructorRequest request);
        Task<UpdateInstructorResponse> UpdateAsync(UpdateInstructorRequest request);

        //List<GetAllInstructorResponse> GetAll();
        //GetByIdInstructorResponse GetById(int id);
        //CreateInstructorResponse Add(CreateInstructorRequest request);
        //DeleteInstructorResponse Delete(DeleteInstructorRequest request);
        //UpdateInstructorResponse Update(UpdateInstructorRequest request);
    }
}
