using Core.DataAccess.EntityFramework.EfRepositoryBase;
using DataAccess.Abstract;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class InstructorRepository : EfRepositoryBase<Instructor, int,BaseDbContext>,IInstructorRepository
    {
        public InstructorRepository(BaseDbContext baseDbContext):base(baseDbContext)
        {
        }
    }
}
