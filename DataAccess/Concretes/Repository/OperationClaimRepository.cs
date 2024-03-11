using Core.DataAccess.EntityFramework.EfRepositoryBase;
using Core.Utilities.Security.Entities;
using DataAccess.Abstract;
using DataAccess.Concretes.EntityFramework.Contexts;

namespace DataAccess.Concretes.Repository
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, int, BaseDbContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
