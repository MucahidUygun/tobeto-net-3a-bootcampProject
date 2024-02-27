using Business.Dtos.BootcampStateDto.Request;
using Business.Dtos.BootcampStateDto.Response;
using DataAccess.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBootcampStateService
    {
        public Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync();
        public Task<IDataResult<GetByIdBootcampStateResponse>> GetByIdAsync(int id);
        public Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request);
        public Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request);
        public Task<IResult> DeleteAsync(DeleteBootcampStateRequest request);
    }
}
