using Business.Dtos.ApplicationStateDto.Request;
using Business.Dtos.ApplicationStateDto.Response;
using DataAccess.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApplicationStateService
    {
        Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request);
        Task<IResult> DeleteAsync(DeleteApplicationStateRequest request);
        Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request);
        Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync();
        Task<IDataResult<GetByIdApplicationStateResponse>> GetByIdApplicationStateAsync(int id);
    }
}
