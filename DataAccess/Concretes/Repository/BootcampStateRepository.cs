using Core.DataAccess.EntityFramework.EfRepositoryBase;
using DataAccess.Abstract;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concretes.Repository
{
    public class BootcampStateRepository : EfRepositoryBase<BootcampState, int, BaseDbContext>, IBootcampStateRepository
    {
        public BootcampStateRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
