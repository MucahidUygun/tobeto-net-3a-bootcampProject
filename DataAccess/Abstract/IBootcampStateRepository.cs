using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IBootcampStateRepository : IAsyncRepository<BootcampState, int>, IRepository<BootcampState, int>
    {
    }
}
