using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IBootcampRepository : IAsyncRepository<Bootcamp, int>, IRepository<Bootcamp, int>
    {
    }
}
