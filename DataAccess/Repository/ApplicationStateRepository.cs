using Core.DataAccess.EntityFramework.EfRepositoryBase;
using DataAccess.Abstract;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Repository
{
    public class ApplicationStateRepository : EfRepositoryBase<ApplicationState, int, BaseDbContext>, IApplicationStateRepository
    {
        public ApplicationStateRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
