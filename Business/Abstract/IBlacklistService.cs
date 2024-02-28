using Business.Dtos.ApplicantDtos.Request;
using Business.Dtos.Blacklists.Requests;
using Business.Dtos.Blacklists.Responses;
using DataAccess.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlacklistService
    {
        Task<IDataResult<CreatedBlacklistResponse>> AddAsync(CreateBlacklistRequest request);
        Task<IDataResult<UpdatedBlacklistResponse>> UpdateAsync(UpdateBlacklistRequest request);
        Task<IResult> DeleteAsync(DeleteBlacklistRequest request);
        Task<IDataResult<List<GetAllBlacklistResponse>>> GetAllAsync();
        Task<IDataResult<GetByIdBlacklistResponse>> GetByIdBlacklistAsync(int  id);
        Task<IDataResult<GetByApplicantIdResponse>> GetByApplicantIdAsync(int id);
    }
}
