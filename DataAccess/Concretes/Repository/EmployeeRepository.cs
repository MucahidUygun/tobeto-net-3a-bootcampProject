using Core.DataAccess.EntityFramework.EfRepositoryBase;
using DataAccess.Abstract;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.Repository
{
    public class EmployeeRepository : EfRepositoryBase<Employee, int, BaseDbContext>, IEmployeeRepository
    {
        public EmployeeRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
