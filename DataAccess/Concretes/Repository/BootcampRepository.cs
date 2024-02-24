using Core.DataAccess.EntityFramework.EfRepositoryBase;
using DataAccess.Abstract;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concretes.Repository
{
    public class BootcampRepository : EfRepositoryBase<Bootcamp, int, BaseDbContext>, IBootcampRepository
    {
        public BootcampRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
