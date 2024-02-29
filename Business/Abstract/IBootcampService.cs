using Business.Dtos.ApplicantDtos.Request;
using Business.Dtos.BootcampDto.Request;
using Business.Dtos.BootcampDto.Response;
using Business.Dtos.BootcampStateDto.Request;
using Business.Dtos.BootcampStateDto.Response;
using DataAccess.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBootcampService
    {
        Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync();
        Task<IDataResult<GetByIdBootcampResponse>> GetByIdAsync(int id);
        Task<IDataResult<CreateBootcampResponse>> CreateAsync(CreateBootcampRequest request);
        Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request);
        Task<IResult> DeleteAsync(DeleteBootcampRequest request);

        Task CheckIdIsExists (int id);
    }
}
