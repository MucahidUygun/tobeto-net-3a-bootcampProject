using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IApplicationStateRepository : IAsyncRepository<ApplicationState, int>, IRepository<ApplicationState, int>
    {
    }
}
