using Business.Dtos.ApplicationDto.Request;
using Business.Dtos.ApplicationDto.Response;
using DataAccess.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApplicationService
    {
        Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync();
        Task<IDataResult<GetByIdApplicationResponse>> GetByIdAsync(int id);
        Task<IResult> DeleteAsync(DeleteApplicationRequest id);
        Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request);
        Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request);
    }
}
