using Core.DataAccess.EntityFramework.EfRepositoryBase;
using DataAccess.Abstract;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.Repository
{
    public class UserRepository : EfRepositoryBase<User, int, BaseDbContext>, IUserRepository
    {
        protected readonly BaseDbContext _dbContext;

        public UserRepository(BaseDbContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
