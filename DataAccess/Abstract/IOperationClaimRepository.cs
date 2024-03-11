using Core.DataAccess;
using Core.Utilities.Security.Entities;

namespace DataAccess.Abstract
{
    public interface IOperationClaimRepository : IAsyncRepository<OperationClaim, int>
    {
    }
}
